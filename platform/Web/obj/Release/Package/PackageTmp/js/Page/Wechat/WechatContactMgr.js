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
        { field: 'Name', title: '名称', width: 100 },
        { field: 'PhoneNumber', title: '联系电话', width: 100 },
        { field: 'CategoryName', title: '类型', width: 100 },
        { field: 'AddMan', title: '创建人', width: 100 },
        { field: 'Remark', title: '备注说明', width: 120 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var ProjectIDs = [];
    var RoomIDs = [];
    try {
        RoomIDs = GetSelectedRooms();
        ProjectIDs = GetSelectedProjects();
    } catch (e) {
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadwechatcontactgrid",
        "keywords": keywords,
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "PhoneType": PhoneType
    });
}
function onDblClickRowTT(index, row) {
    EditCompanyByRow(row)
}
function addRow() {
    var iframe = "../Wechat/EditWechatContact.aspx?type=" + PhoneType;
    do_open_dialog('新增便民电话', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个便民电话进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    EditCompanyByRow(rows[0]);
}
function EditCompanyByRow(row) {
    var iframe = "../Wechat/EditWechatContact.aspx?ID=" + row.ID + '&type=' + PhoneType;
    do_open_dialog('修改便民电话', iframe);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个便民电话进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的便民电话", function (r) {
        if (r) {
            var options = { visit: 'removewechatcontact', IDList: JSON.stringify(IDList) };
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
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
