var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
});
function get_columns() {
    var columns = [
        { field: 'ck', checkbox: true },
        { field: 'BusinessName', title: '门店名称', width: 150 },
        { field: 'BusinessAddress', title: '门店地址', width: 200 },
        { field: 'CategoryName', title: '经营类别', width: 100 },
        { field: 'ContactName', title: '联系人', width: 150 },
        { field: 'ContactPhone', title: '联系电话', width: 100 },
        { field: 'LicenseNumber', title: '营业执照号', width: 150 }
    ];
    columns.push({ field: 'StatusDesc', title: '状态', width: 200 });
    columns.push({ field: 'RelatePhoto', formatter: formatPhoto, title: '商家资料', width: 100 });
    columns.push({ field: 'LoginInfo', formatter: formatLoginInfo, title: '帐号管理', width: 100 });
    var finalcolumns = [];
    finalcolumns.push(columns);
    return finalcolumns;
}
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
        columns: get_columns(),
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallbusinessgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "Status": Status
    });
}
function formatPhoto(value, row) {
    return '<a href="javascript:do_view_photo(' + row.ID + ')">查看</a>'
}
function formatLoginInfo(value, row) {
    return '<a href="javascript:do_view_user(' + row.ID + ')">查看</a>'
}
function do_add() {
    var iframe = "../Mall/BusinessEdit.aspx";
    do_open_dialog('新增商家', iframe);
}
function do_edit() {
    var ID = 0;
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    do_edit_byid(row.ID);
}
function do_edit_byid(ID) {
    var iframe = "../Mall/BusinessEdit.aspx?ID=" + ID;
    do_open_dialog('修改商家', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    if (IDList.length == 0) {
        return;
    }
    top.$.messager.confirm("提示", "确认删除选中的商家?", function (r) {
        if (r) {
            var options = { visit: 'removemallbusiness', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
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
function do_approve() {
    var ID = 0;
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    ID = row.ID;
    var iframe = "../Mall/BusinessApprove.aspx?ID=" + ID;
    do_open_dialog('商家审核', iframe);
}
function do_view_photo(ID) {
    var iframe = "../Mall/BusinessViewPhoto.aspx?ID=" + ID;
    do_open_dialog('商家资料', iframe);
}
function do_view_user(ID) {
    var iframe = "../Mall/BusinessUserMgr.aspx?BusinessID=" + ID
    do_open_dialog('商家帐号', iframe);
}
function do_change_sort() {
    var iframe = "../Mall/BusinessSortOrder.aspx";
    do_open_dialog('推荐商家排序', iframe);
}