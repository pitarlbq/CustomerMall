var tt_CanLoad = false;
$(function () {
    loadtt();
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/UserHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
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
        { field: 'HeadImg', formatter: formatHeadImg, title: '头像', width: 100 },
        { field: 'LoginName', title: '登录名', width: 100 },
        { field: 'NickName', title: '昵称', width: 100 },
        { field: 'Gender', title: '性别', width: 100 },
        ]],
        toolbar: '#tt_mm',
        onLoadSuccess: function () {
            $('#tt_table').datagrid('fixRowHeight')
        }
    });
    SearchTT();
}
function onClick() {
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    var keywords = $("#tdKeyword").searchbox("getValue");
    $("#tt_table").datagrid("load", {
        "visit": "loaduserlist",
        "keywords": keywords,
        "IsAPPCustomerFamily": true,
        "ParentUserID": UserID
    });
}
function formatHeadImg(value, row) {
    if (row.HeadImg == '') {
        return '';
    }
    return '<img src="' + row.HeadImg + '" style="width:60px; height:60px;border-radius: 50%;" />';
}
function remove_family() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个用户进行此操作', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.UserID);
    })
    top.$.messager.confirm("提示", "是否将选中的用户移除家庭成员", function (r) {
        if (r) {
            var options = { visit: 'removeuserfamily', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('移除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_close() {
    parent.do_close_dialog()
}