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
        { field: 'ProjectName', title: '所属小区', width: 100 },
        { field: 'DeviceID', title: '设备标识', width: 100 },
        { field: 'DeviceName', title: '设备名称', width: 100 },
        { field: 'BindDeviceName', title: '所属楼栋', width: 100 },
        { field: 'DeviceCode', title: '串码', width: 100 },
        { field: 'StatusDesc', formatter: formatStatus, title: '是否在线', width: 100 },
        { field: 'operation', formatter: formatOperation, title: '远程开门', width: 100 },
        { field: 'DisableQrCodeOpen', formatter: formatDisableQrCodeOpen, title: '二维码开门', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var RoomIDs = GetSelectedRooms();
    var ProjectIDs = GetSelectedProjects();
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmalldoordevicegrid",
        "keywords": keywords,
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs)
    });
}
function formatOperation(value, row) {
    if (CanRemoteOpen != 1) {
        return '';
    }
    return '<a href="javascript:do_remote_open_door(' + row.ID + ')">远程开门</a>';
}
function formatDisableQrCodeOpen(value, row) {
    return value ? "停用" : "启用";
}
function formatStatus(value, row) {
    if (row.Status == 1) {
        return '<label class="device_status online">Online</label>';
    }
    return '<label class="device_status offline">Offline</label>';
}
function do_remote_open_door(ID) {
    if (CanRemoteOpen != 1) {
        return;
    }
    top.$.messager.confirm('提示', '确认远程开门?', function (r) {
        if (r) {
            var options = { visit: 'doremoteopendoor', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('开门成功', 'success');
                    }
                    else if (message.error) {
                        show_message(message.error, 'warning');
                    }
                    else {
                        show_message('开门失败', 'error');
                    }
                }
            });
        }
    })
}
function do_add() {
    var iframe = "../APPSetup/DoorDeviceEdit.aspx";
    do_open_dialog('新增设备', iframe);
}
function do_edit() {
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var iframe = "../APPSetup/DoorDeviceEdit.aspx?ID=" + row.ID;
    do_open_dialog('修改设备', iframe);
}
function do_remove() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm('提示', '确认删除选中的设备?', function (r) {
        if (r) {
            var options = { visit: 'deletedoordevice', IDList: JSON.stringify(IDList) };
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

