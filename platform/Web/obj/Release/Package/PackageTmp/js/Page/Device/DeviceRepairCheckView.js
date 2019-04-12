var tt_CanLoad = false;
$(function () {
    loadTT();
});
function getcolumns() {
    var columns = [];
    if (TaskType === 'repair') {
        columns = [[
        { field: 'TaskTime', formatter: formatTime, title: '维保日期', width: 100 },
        { field: 'TaskChargeManName', title: '维保人员', width: 100 },
        { field: 'TaskCompleteContent', title: '处理记录', width: 400 },
        ]];
    }
    else if (TaskType === 'check') {
        columns = [[
        { field: 'TaskTime', formatter: formatTime, title: '巡检日期', width: 100 },
        { field: 'TaskChargeManName', title: '巡检人员', width: 100 },
        { field: 'TaskCompleteContent', title: '处理记录', width: 400 },
        ]];
    }
    return columns;
}
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
        columns: getcolumns(),
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
        "NewTaskType": TaskType,
        "DeviceID": DeviceID
    });
}
function do_close() {
    parent.do_close_dialog();
}