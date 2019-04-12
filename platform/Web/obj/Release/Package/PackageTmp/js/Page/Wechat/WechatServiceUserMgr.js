var tt_CanLoad = false;
$(function () {
    loadtt();
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
        onDblClickRow: onDblClickRowTT,
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
        { field: 'NickName', title: '昵称', width: 100 },
        { field: 'AccountName', title: '客服帐号', width: 100 },
        { field: 'Wx_Account', title: '微信号', width: 100 },
        { field: 'LoginName', title: '关联帐号', width: 60 },
        { field: 'AddTime', formatter: formatDateTime, title: '添加时间', width: 150 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadwechatserviceusergrid",
        "keywords": keywords
    });
}
function onDblClickRowTT(index, row) {
    EditUserByRow(row)
}
function addUser() {
    var iframe = "../Wechat/WechatServiceUserEdit.aspx";
    do_open_dialog('新增客服', iframe);
}
function editUser() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个用户进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    EditUserByRow(rows[0]);
}
function EditUserByRow(row) {
    var iframe = "../Wechat/WechatServiceUserEdit.aspx?ID=" + row.ID;
    do_open_dialog('修改客服', iframe);
}
function removeUser() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个用户进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的客服?", function (r) {
        if (r) {
            var options = { visit: 'removewechatserviceuser', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_set_time() {
    var iframe = "../SysSeting/WechatChatSetup.aspx";
    do_open_dialog('设置', iframe);
}
function do_view_request() {
    var iframe = "../SysSeting/WechatChatRequestMgr.aspx";
    do_open_dialog('设置', iframe);
}
