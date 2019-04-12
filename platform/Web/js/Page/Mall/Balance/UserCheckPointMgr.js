var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
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
        { field: 'UserName', title: '考核对象', width: 100 },
        { field: 'CategoryName', title: '考核项目', width: 100 },
        { field: 'EarnTypeDesc', title: '项目类型', width: 100 },
        { field: 'InfoName', title: '考核标准', width: 100 },
        { field: 'PointValue', title: '岗位积分', width: 100 },
        { field: 'ApproveUserName', title: '审核人', width: 100 },
        { field: 'ApproveTime', formatter: formatDateTime, title: '考核时间', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallusercheckpointgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
    });
}