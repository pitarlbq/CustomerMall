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
        { field: 'NickName', title: '用户昵称', width: 100 },
        { field: 'PhoneNumber', title: '手机号码', width: 100 },
        { field: 'AddTime', formatter: formatDateTime, title: '评价时间', width: 150 },
        { field: 'RateStarDesc', title: '评价等级', width: 100 },
        { field: 'RateComment', title: '评价内容', width: 150 },
        { field: 'OrderNumber', title: '订单号', width: 100 },
        { field: 'TotalPoint', title: '获取积分数', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallratecustomerlist",
        "keywords": $('#tdKeyword').searchbox('getValue')
    });
}
function do_view() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    var iframe = "../Mall/RateCustomerDetail.aspx?ID=" + row.ID;
    do_open_dialog('查看详情', iframe);
}