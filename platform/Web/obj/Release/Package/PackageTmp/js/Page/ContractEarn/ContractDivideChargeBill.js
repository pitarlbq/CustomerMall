var tt_CanLoad = false;
$(function () {
    loadTableTT();
});
function loadTableTT() {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
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
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
        { field: 'RoomName', title: '资源编号', width: 100 },
        { field: 'ContractNo', title: '合同编号', width: 100 },
        { field: 'RentName', title: '客户名称', width: 100 },
        { field: 'CalculateStartTime', formatter: formatTime, title: '计费开始日期', width: 100 },
        { field: 'CalculateEndTime', formatter: formatTime, title: '计费结束日期', width: 100 },
        { field: 'NewEndTime', formatter: formatTime, title: '计费停用日期', width: 100 },
        { field: 'FormatTotalCost', title: '应收金额', width: 80 },
        { field: 'FormatTotalFinalPayCost', title: '已收金额', width: 80 },
        { field: 'FormatTotalFinalCost', title: '未收金额', width: 80 },
        { field: 'TotalFinalDiscountCost', title: '减免金额', width: 60 },
        { field: 'OutDays', formatter: formatOutDays, title: '逾期', width: 80 },
        { field: 'RemarkNote', formatter: formatRemark, title: '备注信息', width: 100 }
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
        toolbar: '#tb_bill',
        onLoadSuccess: function (data) {
            currentcount = data.currentcount || 0;
            var url = '../Handler/FeeCenterHandler.ashx?currentcount=' + currentcount;
            $("#tt_table").datagrid("options").url = url;
        }
    });
    SearchTT();
}
function SearchTT() {
    var url = '../Handler/FeeCenterHandler.ashx?currentcount=0';
    $("#tt_table").datagrid("options").url = url;
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadroomfeelist",
        "IsContractFee": true,
        "DivideID": DivideID
    });
}
