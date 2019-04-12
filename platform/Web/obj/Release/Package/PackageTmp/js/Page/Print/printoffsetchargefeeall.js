var content, historyidlist;
$(function () {
    historyidlist = parent.historyidlist;
    content = new Vue({
        el: '#print_wrap',
        data: {
            list: []
        },
        methods: {
            getdata: function () {
                var that = this;
                var options = { visit: 'getoffsetchargefeelist', historyidlist: JSON.stringify(historyidlist) };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/PrintHandler.ashx',
                    data: options,
                    success: function (data) {
                        if (data.status) {
                            that.list = data.list;
                            tdWidth.val(data.pageWidth);
                            tdHeight.val(data.pageHeight);
                            setTimeout(function () {
                                $('.easyui_time').addClass('easyui-datetimebox');
                                $('.easyui_combobox').addClass('easyui-combobox');
                                $.parser.parse('#print_wrap');
                            }, 1000);
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            }
        }
    });
    content.getdata();
})
function savedata() {
    saveprocess(true);
}
function saveprocess(popup) {
    $.each(content.list, function (index, item) {
        var chargetime = $('#chargetime_' + item.RoomID).datetimebox('getValue');
        item.ChargeTime = chargetime;
        item.doprint = !popup;
    })
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'saveprintfeelist', list: JSON.stringify(content.list) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                var list = message.list;
                $.each(content.list, function (index, item) {
                    $.each(list, function (index2, item2) {
                        if (item2.RoomID == item.RoomID) {
                            item.PrintID = item2.PrintID;
                        }
                    })
                })
                if (popup) {
                    show_message('保存成功', 'success');
                }
                else {
                    startPrint();
                }
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function cancelFee() {
    var options = { visit: 'cancelprintfee', TempHistoryIDs: JSON.stringify(parent.historyidlist) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            closeWin();
        }
    });
}
function closeWin() {
    parent.do_close_dialog(function () {
        parent.$('#tt_table').datagrid('reload');
    });
}