var fee_CanLoad = false;
var type_CanLoad = false;
$(function () {
    loadFeedg();
})
function loadFeedg() {
    $('#fee_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
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
        onBeforeLoad: function (data) {
            if (!fee_CanLoad) {
                $('#fee_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return fee_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#fee_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'Name', title: '收费项目', width: 200 },
        { field: 'Cost', title: '应收', width: 100 },
        { field: 'RealCost', title: '实收', width: 100 },
        { field: 'Discount', title: '减免', width: 100 },
        { field: 'OwnCost', title: '欠费', width: 100 }
        ]]
    });
    SearchFee();
}
function SearchFee() {
    var StartChargeTime = $("#tdStartTime").datebox("getValue");
    var EndChargeTime = $("#tdEndTime").datebox("getValue");
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
             show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var idarry = parent.GetSelectedRooms();
    var ProjectID = parent.GetSelectedProjects();
    fee_CanLoad = true;
    $("#fee_table").datagrid("load", {
        "visit": "loadtotalcostsummarybychargename",
        "RoomID": JSON.stringify(idarry),
        "ProjectID": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID
    });
}