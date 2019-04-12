var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/SysSettingHandler.ashx',
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
        { field: 'NickName', title: '申请人', width: 100 },
        { field: 'AddTime', formatter: formatDateTime, title: '申请时间', width: 100 },
        { field: 'UserName', title: '服务客服', width: 100 },
        { field: 'AcceptTime', formatter: formatDateTime, title: '服务时间', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 150 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadwechatrequestgrid",
        "keywords": keywords,
        "StartTime": tdStartTime.datetimebox('getValue'),
        "EndTime": tdEndTime.datetimebox('getValue')
    });
}
function formatOperation(value, row) {
    if (!row.CanAccept) {
        return '';
    }
    return '<a href="javascript:do_grab_chat(' + row.ID + ')">开始聊天</a>'
}
function do_grab_chat(ID) {
    var options = { visit: "grabwechatchat", ID: ID }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                show_message('请打开微信在线客服页面开始聊天', 'success', function () {
                    top.window.open('https://mpkf.weixin.qq.com/');
                });
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统异常', 'error');
        }
    });
}