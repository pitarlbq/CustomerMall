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
        { field: 'OrderNumber', title: '订单编号', width: 200 },
        { field: 'AddTime', formatter: formatDateTime, title: '订单日期', width: 150 },
        { field: 'ProductTypeDesc', title: '订单类型', width: 100 },
        { field: 'TotalCostDesc', title: '订单金额', width: 100 },
        { field: 'PaymentMethodDesc', title: '付款方式', width: 100 },
        { field: 'PayTime', formatter: formatDateTime, title: '付款日期', width: 100 },
        { field: 'CompleteTime', formatter: formatDateTime, title: '完成日期', width: 100 },
        { field: 'BusinessName', title: '商户名称', width: 100 },
        { field: 'BusinessContactMan', title: '商户联系人', width: 100 },
        { field: 'BusinessBalanceAccount', title: '商户结算账户', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallbusinessbalancegrid",
        "BusinessBalanceID": ID
    });
}