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
        fitColumns: false,
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
        { field: 'DoorNumber', title: '门卡编号', width: 100 },
        { field: 'CardName', title: '门卡名称', width: 100 },
        { field: 'CardUID', title: '门卡UID', width: 100 },
        { field: 'ProjectName', title: '小区', width: 100 },
        { field: 'UserInfo', title: '用户', width: 300 },
        { field: 'DeviceInfo', title: '绑定设备', width: 300 },
        { field: 'ExpireDateDesc', title: '有效期', width: 200 },
        { field: 'FeeEndDateDesc', title: '缴费到期日期', width: 200 },
        { field: 'AddTime', formatter: formatDateTime, title: '开卡时间', width: 150 },
        { field: 'AddUserName', title: '开卡人', width: 100 },
        { field: 'CardSummary', title: '门卡描述', width: 200 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    var RoomIDs = GetSelectedRooms();
    var ProjectIDs = GetSelectedProjects();
    var StartTime = $('#tdStartTime').datebox('getValue');
    var EndTime = $('#tdEndTime').datebox('getValue');
    $("#tt_table").datagrid("load", {
        "visit": "getmalldoorcardgrid",
        "keywords": keywords,
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartTime": StartTime,
        "EndTime": EndTime
    });
}

function do_add() {
    var iframe = "../APPSetup/DoorCardEdit.aspx";
    do_open_dialog('新增门卡', iframe);
}
function do_edit() {
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var iframe = "../APPSetup/DoorCardEdit.aspx?ID=" + row.ID;
    do_open_dialog('修改门卡', iframe);
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
    top.$.messager.confirm('提示', '确认删除选中的门卡?', function (r) {
        if (r) {
            var options = { visit: 'deletedoorcard', IDList: JSON.stringify(IDList) };
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
function do_tongbu() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var List = [];
    $.each(rows, function (index, row) {
        if (row.FeeEndDateDesc != '') {
            List.push({ ID: row.ID, FeeEndDate: row.FeeEndDateDesc });
        }
    })
    top.$.messager.confirm('提示', '确认同步选中的门卡有效期?', function (r) {
        if (r) {
            var options = { visit: 'synchdoorcard', List: JSON.stringify(List) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success');
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

