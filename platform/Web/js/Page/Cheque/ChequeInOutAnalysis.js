var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});

function loadtt(finalcolumn) {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/ChequeHandler.ashx',
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
        { field: 'Name', title: '名称', width: 100 },
        { field: 'TaxRate', title: '税率', width: 100 },
        { field: 'TotalCount', formatter: formatNumber, title: '张数', width: 100 },
        { field: 'TotalCost', formatter: formatNumber, title: '金额', width: 100 },
        { field: 'TotalTaxCost', formatter: formatNumber, title: '税额', width: 100 },
        { field: 'TotalSumCost', formatter: formatNumber, title: '税收合计', width: 100 }
        ]]
    });
    SearchTT();
}
function SearchTT() {
    var StartTime = $('#tdStartTime').datebox('getValue');
    var EndTime = $('#tdEndTime').datebox('getValue');
    var SearchType = $('#tdType').combobox('getValue');
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadchequeinoutanalysis",
        "SearchType": SearchType,
        "StartTime": StartTime,
        "EndTime": EndTime
    });
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? value : "");
}
