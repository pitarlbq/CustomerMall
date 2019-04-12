var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
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
        { field: 'FinalUserName', title: '分享人姓名', width: 200 },
        { field: 'LoginName', title: '分享人电话', width: 200 },
        { field: 'ProjectName', title: '所属小区', width: 200 },
        { field: 'TotalCount', title: '订单总数', width: 150 },
        { field: 'TotalCost', title: '订单总金额', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadshareorderanlaysis",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
        "OrderStatus": $('#tdOrderStatus').combobox('getValue'),
    });
}
function formatOperation(value, row) {
    return '<a href="javascript:do_view(' + row.UserID + ')">查看</a>'
}
function do_view(UserID) {
    var iframe = "../Mall/OrderMgr.aspx?ShareUserID=" + UserID;
    do_open_dialog('分享订单', iframe);
}