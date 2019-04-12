var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/MallHandler.ashx',
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
        { field: 'NickName', title: '用户昵称', width: 100 },
        { field: 'PhoneNumber', title: '手机号码', width: 100 },
        { field: 'ForbiddenTimeDesc', title: '禁言持续时间', width: 300 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var Keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmalluserforbiddengrid",
        "keywords": Keywords,
    });
}
function do_add() {
    var iframe = "../APPSetup/UserForbiddenEdit.aspx";
    do_open_dialog('新增', iframe);
}
function do_edit() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请选择一行数据', 'warning');
        return;
    }
    var ID = row.ID;
    var iframe = "../APPSetup/UserForbiddenEdit.aspx?ID=" + ID;
    do_open_dialog('修改', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm('提示', '确认删除选中的数据?', function (r) {
        if (r) {
            var options = { visit: 'removemalluserforbidden', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
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

