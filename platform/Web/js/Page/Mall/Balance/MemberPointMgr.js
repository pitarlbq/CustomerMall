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
        { field: 'NickName', title: '客户名称', width: 100 },
        { field: 'MemberLevel', title: '会员等级', width: 100 },
        { field: 'CurrentConsumeAmount', title: '当前账户余额', width: 150 },
        { field: 'AllConsumeAmount', title: '累计充值金额', width: 150 },
        { field: 'CurrentPoint', title: '当前积分', width: 100 },
        { field: 'AllPoint', title: '累计积分', width: 100 },
        { field: 'CurrentFuShunQuan', title: '当前福顺券', width: 100 },
        { field: 'AllFuShunQuan', title: '累计福顺券', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallmemberpointgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
    });
}