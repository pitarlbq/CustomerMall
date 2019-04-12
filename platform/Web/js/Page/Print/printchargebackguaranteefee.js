$(function () {
    loadchargesummarytype();
    window.onsubmit = false;
    $(".realcost").change(function () {
        calculateAllPayCost();
    });
})
function getAllItems() {
    var list = [];
    var datalist = $('.realcost');
    $.each(datalist, function (index) {
        var index = $(this).attr("data-index");
        var ChargeTime = $.trim($('#chargetime_' + index).text());
        var ChargeName = $.trim($('#chargename_' + index).text());
        var RealCost = parseFloat($(this).val());
        var Remark = $('#remark_' + index).val();
        var BackGuaranteeRemark = $('#backremark_' + index).val();
        var HistoryID = $.trim($(this).attr("data-id"));
        list.push({ ChargeTime: ChargeTime, ChargeName: ChargeName, RealCost: RealCost, Remark: Remark, HistoryID: HistoryID, BackGuaranteeRemark: BackGuaranteeRemark });
    })
    return list;
}
function calculateAllPayCost() {
    Cost = 0;
    var datalist = $('.realcost');
    $.each(datalist, function (index) {
        var RealCost = parseFloat($(this).val());
        Cost += RealCost;
    })
    $('#tdRealPayCost').html('￥' + toThousands(Cost));
    return Cost;
}
function savedata() {
    saveprocess(true);
}
function saveprocess(popup) {
    if (window.onsubmit) {
        show_message("请不要重复提交", "info");
        return;
    }
    window.onsubmit = true;
    MaskUtil.mask('body', '提交中');
    var list = getAllItems();
    var options = { visit: 'cancelguaranteefee', AddMan: AddMan, PrintNumber: PrintNumber.val(), ChargeMan: ChargeMan.val(), ChargeTime: ChargeTime.datetimebox("getValue"), Remark: Remark.val(), Cost: Cost, ChargeMoneyType: $("#tbChargeMoneyType").combobox("getValue"), FullName: FullName, MoneyDaXie: MoneyDaXie, OrderNumberID: hdOrderNumberID.val(), RoomFullName: RoomFullName.val(), RoomOwnerName: RoomOwnerName.val(), itemlist: JSON.stringify(list), doprint: !popup, PrintID: PrintID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/PrintHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            window.onsubmit = false;
            if (data.status) {
                if (!data.PrintID) {
                    show_message("退还保证金不能大于当前保证金余额", "info");
                    return;
                }
                PrintID = data.PrintID;
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
function loadchargesummarytype() {
    var options = { visit: 'loadchargesummarytype' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            $("#tbChargeMoneyType").combobox({
                editable: false,
                data: data.list,
                valueField: 'ChargeTypeID',
                textField: 'ChargeTypeName',
            });
            $("#tbChargeMoneyType").combobox("setValue", hdChargeMoneyType.val());
        }
    });
}
function printpage() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargebackguaranteefeeview.aspx?PrintID=" + PrintID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winprintview'></div>").appendTo("body").window({
        title: '打印退款单',
        width: $(window).width(),
        height: $(window).height(),
        top: 0,
        left: 0,
        inline: true,
        content: iframe,
        onClose: function () {
            parent.$("#winprintview").remove();
        }
    });
};
function cancelFee() {
    var options = { visit: 'cancelguaranteeprintfee', GUID: GUID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                do_close();
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function do_close() {
    parent.do_close_dialog(function () {
        parent.chargeBackGuaranteeFee_done();
    });
}