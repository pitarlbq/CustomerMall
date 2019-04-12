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
        { field: 'FullName', title: '资源位置', width: 100 },
        { field: 'Name', title: '资源编号', width: 100 },
        { field: 'APPRegisterStatusDesc', title: 'APP注册', width: 100 },
        { field: 'LastTimeRange', title: '上次缴费有效期', width: 100 },
        //{ field: 'ActiveEndTime', formatter: formatTime, title: '上次缴费截至日期', width: 100 },
        { field: 'DelayDate', formatter: formatTime, title: '延期日期', width: 100 },
        { field: 'IsDisableDesc', title: '是否启用', width: 100 },
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
        "visit": "getmalldoorremoteusertimegrid",
        "keywords": keywords,
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
    });
}
function do_delay() {
    var list = [];
    var rows = $('#tt_table').datagrid("getSelections");
    $.each(rows, function (index, row) {
        var item = { RoomID: row.RoomID, TimeID: row.TimeID };
        list.push(item);
    })
    if (list.length == 0) {
        show_message('请选择需要延期的房间', 'warning');
        return;
    }
    top.$.messager.confirm('提示', '确认延期?', function (r) {
        if (r) {
            var options = { visit: 'delayremoteusertime', list: JSON.stringify(list) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: "../Handler/MallHandler.ashx",
                success: function (data) {
                    if (data.status) {
                        show_message('操作成功', 'success');
                        $("#tt_table").datagrid("reload");
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, 'info');
                        return;
                    }
                    show_message('系统异常', 'error');
                }
            });
        }
    })
}
function do_edit() {
    var list = [];
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请选择需要修改的房间', 'warning');
        return;
    }
    var iframe = "../APPSetup/DoorRemoteUserTimeEdit.aspx";
    do_open_dialog('修改', iframe);
}

