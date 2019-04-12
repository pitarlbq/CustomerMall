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
        { field: 'FinalBusinessName', title: '商户名称', width: 100 },
        { field: 'BusinessContactMan', title: '商户联系人', width: 100 },
        { field: 'BusinessAccount', title: '商户结算账户', width: 100 },
        { field: 'BalanceAmount', title: '结算金额', width: 100 },
        { field: 'BalanceRuleName', title: '结算规则', width: 100 },
        { field: 'BalanceStatusDesc', title: '结算状态', width: 100 },
        { field: 'AddTime', formatter: formatDateTime, title: '申请日期', width: 100 },
        { field: 'ApproveTime', formatter: formatDateTime, title: '审核日期', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    var FinalBalance = BalanceStatus;
    try {
        var tdBalanceStatus = $('#tdBalanceStatus').combobox('getValue');
        if (tdBalanceStatus != '') {
            FinalBalance = tdBalanceStatus;
        }
    } catch (e) {
    }
    $("#tt_table").datagrid("load", {
        "visit": "loadmallbalanceapprovegrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
        "BalanceStatus": FinalBalance,
    });
}
function formatOperation(value, row) {
    return '<a href="javascript:do_view(' + row.ID + ')">查看</a>';
}
function do_view(ID) {
    var iframe = "../Mall/BalanceApproveDetail.aspx?ID=" + ID;
    do_open_dialog('查看详情', iframe);
}
function do_approve() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请选择结算申请数据', 'info');
        return;
    }
    var iframe = "../Mall/BalanceApproveApprove.aspx";
    do_open_dialog('结算审核', iframe);
}