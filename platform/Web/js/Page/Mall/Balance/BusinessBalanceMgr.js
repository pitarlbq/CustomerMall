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
        { field: 'ck', checkbox: true },
        { field: 'OrderNumber', title: '订单编号', width: 200 },
        { field: 'AddTime', formatter: formatDateTime, title: '订单日期', width: 150 },
        { field: 'ProductTypeDesc', title: '订单类型', width: 100 },
        { field: 'TotalBasicCost', title: '成本价', width: 100 },
        { field: 'TotalRestCost', title: '利润', width: 100 },
        { field: 'TotalCostDesc', title: '订单金额', width: 100 },
        { field: 'PaymentMethodDesc', title: '付款方式', width: 100 },
        { field: 'PayTime', formatter: formatDateTime, title: '付款日期', width: 100 },
        { field: 'CompleteTime', formatter: formatDateTime, title: '完成日期', width: 100 },
        { field: 'FinalBusinessName', title: '商户名称', width: 100 },
        { field: 'BusinessContactMan', title: '商户联系人', width: 100 },
        { field: 'BusinessBalanceAccount', title: '商户结算账户', width: 100 },
        { field: 'BalanceRuleName', title: '结算规则', width: 100 },
        { field: 'BalanceStatusDesc', title: '结算状态', width: 100 },
        { field: 'BalanceDate', formatter: formatDateTime, title: '结算日期', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallbusinessbalancegrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
        "BalanceStatus": 1,
        "BusinessType": $('#tdBusinessType').combobox('getValue'),
    });
}
function do_balance() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../Mall/BusinessBalanceApplication.aspx";
    do_open_dialog('商家结算申请', iframe);
}
function GetOrderIDList() {
    var IDList = [];
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        return IDList;
    }
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    return IDList;
}