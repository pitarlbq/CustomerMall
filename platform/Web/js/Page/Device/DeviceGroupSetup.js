var tt_CanLoad;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/DeviceHandler.ashx',
        loadMsg: '正在加载',
        border: false,
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
        columns: [[
       { field: 'Code', title: '编码', width: 100 },
       { field: 'DeviceGroupName', title: '分组名称', width: 100 },
       { field: 'RepairUserMan', title: '维保责任人', width: 100 },
       { field: 'CheckUserMan', title: '巡检责任人', width: 300 },
       { field: 'Description', title: '说明', width: 300 },
        ]],
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
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loaddevicegroupgrid",
        "Keywords": $('#tdKeywords').searchbox('getValue')
    });
}
function addRow() {
    var row = $("#tt_table").datagrid("getSelected");
    var ParentID = (row == null ? 0 : row.ID);
    var iframe = "../Device/EditDeviceGroup.aspx";
    do_open_dialog('新增分组', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个分组进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Device/EditDeviceGroup.aspx?ID=" + ID;
    do_open_dialog('修改分组', iframe);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个分组进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的分组", function (r) {
        if (r) {
            var options = { visit: 'deletedevicegroup', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
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