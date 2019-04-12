var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
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
        { field: 'PhoneNumber', title: '联系方式', width: 100 },
        { field: 'SummaryContent', formatter: formatContent, title: '反馈内容', width: 400 },
        { field: 'AddTime', formatter: formatDateTime, title: '反馈时间', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmallsuggestiongrid",
        "keywords": keywords,
    });
}
function formatContent(value, row) {
    if (value.length > 20) {
        return value.substring(0, 20) + "...";
    }
    return value;
}

function do_view() {
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var iframe = "../APPSetup/SuggestionView.aspx?ID=" + row.ID;
    do_open_dialog('查看意见反馈', iframe);
}

