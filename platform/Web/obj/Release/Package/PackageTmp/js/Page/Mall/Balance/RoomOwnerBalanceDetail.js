var tt_CanLoad = false, isUpdate = false, RoomID = 0;
$(function () {
    get_parent_data();
    loadtt();
});
function get_parent_data() {
    var row = parent.$("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请选择待结算房间', "info");
        return;
    }
    RoomID = row.RoomID;
    tdFullName.text(row.FullName);
    tdRoomName.text(row.RoomName);
    tdTotalCost.text(row.TotalCost);
    tdTotalRestCost.text(row.TotalRestCost);
    tdTotalBalanceAmount.text(row.TotalBalanceAmount);
}
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
        { field: 'OrderNumber', title: '订单编号', width: 200 },
        { field: 'AddTime', formatter: formatDateTime, title: '订单日期', width: 150 },
        { field: 'ProductTypeDesc', title: '订单类型', width: 100 },
        { field: 'TotalCostDesc', title: '订单金额', width: 100 },
        { field: 'PaymentMethodDesc', title: '付款方式', width: 100 },
        { field: 'PayTime', formatter: formatDateTime, title: '付款日期', width: 100 },
        { field: 'CompleteTime', formatter: formatDateTime, title: '完成日期', width: 100 },
        { field: 'RoomOwnerName', title: '业主名称', width: 100 },
        { field: 'LoginName', title: 'APP账号', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallroomownerorderlist",
        "RoomID": RoomID,
        "StartTime": parent.$('#tdStartTime').datebox('getValue'),
        "EndTime": parent.$('#tdEndTime').datebox('getValue')
    });
}