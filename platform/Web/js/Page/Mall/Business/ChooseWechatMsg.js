var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
});
function loadtt() {
    var singleSelect = singleselect == 1;
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: singleSelect,
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
        { field: 'PublishTime', formatter: formatDateTime, title: '发布日期', width: 150 },
        { field: 'MsgTitle', title: '标题', width: 150 },
        { field: 'StartTime', formatter: formatStartTime, title: '有效期', width: 150 },
        { field: 'IsInvalidDesc', title: '是否失效', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function formatStartTime(value, row) {
    var startime = formatDateTime(row.StartTime, row);
    var endtime = formatDateTime(row.EndTime, row);
    if (startime != '--' && endtime != '--') {
        return startime + " 至 " + endtime;
    }
    if (startime != '--') {
        return startime + " 至 " + "无";
    }
    if (endtime != '--') {
        return "无" + " 至 " + endtime;
    }
    return "--";
}
function formatIsInvalid(value, row) {
    var time = formatDateTime(row.EndTime, row);
    if (time != '--') {
        var date = new Date(time.replace(/-/g, "/").replace("T", " "));
        var newDate = new Date();
        if (date < newDate) {
            return '失效';
        }
    }
    return '有效';
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmsglist",
        "keywords": keywords,
        "type": 0,
        "msgtypeid": msgtypeid
    });
}
function do_choose() {
    var list = [];
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择', 'info');
        return;
    }
    var names = '';
    $.each(rows, function (index, row) {
        list.push(row.ID);
        if (index > 0) {
            names += ",";
        }
        names += row.MsgTitle;
    })
    if (from == 'RotatingImageEdit') {
        parent.isupdate = true;
        parent.hdProducts.val(JSON.stringify(list));
        parent.tdURLLinkNames.textbox('setValue', names);
    }
    do_close();
}
function do_close() {
    parent.do_close_dialog();
}