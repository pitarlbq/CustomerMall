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
        { field: 'CustomerInfo', title: '客户名称', width: 300 },
        { field: 'BalanceTypeDesc', title: '储值类型', width: 100 },
        { field: 'CategoryTypeDesc', title: '储值方式', width: 100 },
        { field: 'BalanceValue', title: '储值现金', width: 100 },
        { field: 'AddTime', formatter: formatDateTime, title: '储值时间', width: 150 },
        { field: 'AddUserName', title: '操作员', width: 100 },
        { field: 'Remark', title: '备注', width: 200 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallmemberamountgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
        "AmountType": $('#tdAmountType').combobox('getValue'),
        "IncomingType": $('#tdIncomingType').combobox('getValue'),
        "OutcomingType": $('#tdOutcomingType').combobox('getValue'),
    });
}
function do_add(BalanceType) {
    var title = (BalanceType == 1 ? '充值' : '消费');
    var iframe = "../Mall/MemberAmountInOutComing.aspx?type=" + BalanceType;
    do_open_dialog(title, iframe);
}