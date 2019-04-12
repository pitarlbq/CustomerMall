var tt_CanLoad = false;
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
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'TaskFromDesc', title: '任务来源', width: 100 },
        { field: 'TaskTypeDesc', title: '任务类型', width: 100 },
        { field: 'TaskLevel', title: '紧急程度', width: 100 },
        { field: 'TaskStatusDesc', title: '任务状态', width: 100 },
        { field: 'DeviceTypeName', title: '设备类型', width: 100 },
        { field: 'DeviceGroupName', title: '设备分组', width: 100 },
        { field: 'DeviceName', title: '设备名称', width: 100 },
        { field: 'ModelNo', title: '规格型号', width: 100 },
        { field: 'TaskChargeManName', title: '责任人', width: 100 },
        { field: 'TaskChargeManPhone', title: '联系方式', width: 100 },
        { field: 'TaskTime', formatter: formatTime, title: ' 任务时间', width: 150 },
        { field: 'TaskCompleteTime', formatter: formatTime, title: ' 完成时间', width: 150 },
        { field: 'TaskAddMan', title: ' 记录人', width: 150 },
        { field: 'TaskAddTime', formatter: formatTime, title: ' 记录日期', width: 150 },
        ]],
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
        toolbar: '#tb'
    });
    SearchTT();
}

function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loaddevicetaskgrid",
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "TaskFrom": $("#tdTaskFrom").combobox("getValue"),
        "TaskType": $("#tdTaskType").combobox("getValue"),
        "status": status
    });
}
function addRow() {
    var iframe = "../Device/EditDeviceTask.aspx";
    do_open_dialog('新增任务', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个设备", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个设备", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Device/EditDeviceTask.aspx?ID=" + ID;
    do_open_dialog('修改任务', iframe);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个设备", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的设备", function (r) {
        if (r) {
            var options = { visit: 'removedevicetask', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
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
