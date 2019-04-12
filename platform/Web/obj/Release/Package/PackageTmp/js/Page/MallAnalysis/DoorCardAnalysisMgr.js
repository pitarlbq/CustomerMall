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
        { field: 'Title', title: '开卡时间', width: 150 },
        { field: 'Total', title: '开卡数量', width: 100 }
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
        "visit": "getmalldoorcardanalysisgrid",
        "keywords": keywords,
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartTime": StartTime,
        "EndTime": EndTime
    });
}