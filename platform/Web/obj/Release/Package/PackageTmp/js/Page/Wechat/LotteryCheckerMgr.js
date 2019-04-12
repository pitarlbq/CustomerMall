var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $('#tt_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'RealName', title: '姓名', width: 100 },
        { field: 'LoginName', title: '登录名', width: 100 },
        { field: 'NickName', title: '微信昵称', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getlotterycheckergrid",
        "keywords": keywords,
        "ActivityID": ActivityID
    });
}
function addRow() {
    var iframe = "../Wechat/ChooseLotteryChecker.aspx?ActivityID=" + ActivityID;
    do_open_dialog('选择发奖人员', iframe);
}
function removeRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择需要删除的数据', 'info');
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    top.$.messager.confirm('提示', '确认要删除选中的奖项?', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'deletelotterychecker', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('删除成功', 'success');
                        $("#tt_table").datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}
function doImport() {
    var iframe = "../Wechat/ImportLotteryUser.aspx?ActivityID=" + ActivityID;
    do_open_dialog('导入参与人员', iframe);
}
