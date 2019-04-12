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
        { field: 'AddUserName', title: '申请人', width: 100 },
        { field: 'AddTimeDesc', title: '申请时间', width: 100 },
        { field: 'PointValue', title: '待兑换积分', width: 100 },
        { field: 'CheckPointValue', title: '岗位积分', width: 100 },
        { field: 'StatusDesc', title: '状态', width: 100 },
        { field: 'ApproveUserName', title: '审核人', width: 100 },
        { field: 'ApproveTimeDesc', title: '审核时间', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadpointconvertrecordmgr",
        "keywords": $('#tdKeyword').searchbox('getValue')
    });
}
function do_approve() {
    var ID = 0;
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    var iframe = "../Mall/UserCheckPointConvertRecordApprove.aspx?ID=" + row.ID;
    do_open_dialog('兑换审核', iframe);
}