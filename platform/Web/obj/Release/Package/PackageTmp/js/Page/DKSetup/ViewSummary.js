var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CommHandler.ashx',
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
        showFooter: true,
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
        { field: 'OrderNumber', editor: 'textbox', title: '库单号', width: 150 },
        { field: 'StartTime', formatter: formatTime, title: '入库时间', width: 100 },
        { field: 'InTotalCount', editor: 'numberbox', title: '入库数量', formatter: formatCount, width: 60 },
        { field: 'OutTime', formatter: formatTime, title: '出库时间', width: 100 },
        { field: 'OutTotalCount', editor: 'numberbox', title: '出库数量', formatter: formatCount, width: 60 },
        { field: 'Inventory', editor: 'numberbox', title: '库存总数', formatter: formatCount, width: 60 },
        { field: 'ContactName', editor: 'textbox', title: '商户', width: 150 },        
        { field: 'AddMan', title: '库管员', width: 60 },
        { field: 'Remark', title: '备注', width: 80 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    var OutStartTime = $("#tdOutStartTime").datebox("getValue");
    var OutEndTime = $("#tdOutEndTime").datebox("getValue");
    var Businessidarry = parent.GetSelectedByType("Business");
    var Productidarry = parent.GetSelectedByType("Product");
    var SpecInfoidarry = parent.GetSelectedByType("SpecInfo");
    var InventoryInfoidarry = parent.GetSelectedByType("InventoryInfo");
    var Carriergroupidarry = parent.GetSelectedTitleByType("CarrierGroup", 5);
    var Carrieridarry = parent.GetSelectedByType("Carrier");
    var BusinessID = Businessidarry.length > 0 ? Businessidarry[0] : 0;
    var ProductID = Productidarry.length > 0 ? Productidarry[0] : 0;
    var SpecInfoID = SpecInfoidarry.length > 0 ? SpecInfoidarry[0] : 0;
    var InventoryInfoID = InventoryInfoidarry.length > 0 ? InventoryInfoidarry[0] : 0;
    var CarrierGroupID = Carriergroupidarry.length > 0 ? Carriergroupidarry[0] : 0;
    var CarrierID = Carrieridarry.length > 0 ? Carrieridarry[0] : 0;
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadinoutsummary",
        "StartTime": StartTime,
        "EndTime": EndTime,
        "OutStartTime": OutStartTime,
        "OutEndTime": OutEndTime,
        "BusinessID": BusinessID,
        "ProductID": ProductID,
        "SpecInfoID": SpecInfoID,
        "InventoryInfoID": InventoryInfoID,
        "CarrierGroupID": CarrierGroupID,
        "CarrierID": CarrierID
    });
}
function formatCount(value, row) {
    if (Number(value) <= 0) {
        return 0;
    }
    return value;
}
