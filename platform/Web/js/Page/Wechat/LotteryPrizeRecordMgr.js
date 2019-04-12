var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
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
        { field: 'NickName', formatter: formatDateTime, title: '微信昵称', width: 150 },
        { field: 'LevelName', title: '奖项', width: 100 },
        { field: 'PrizeName', title: '奖品名称', width: 100 },
        { field: 'PrizeTypeDescription', title: '奖品类型', width: 100 },
        { field: 'RecordTime', title: '抽奖时间', width: 100 },
        { field: 'SendTime', formatter: formatDateTime, title: '领奖时间', width: 100 },
        { field: 'Sender', title: '发奖人', width: 100 },
        { field: 'SendResult', title: '备注', width: 100 }
        ]]
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getlotteryprizerecord",
        "keywords": keywords,
        "ActivityID": ActivityID,
        "CompleteSend": $('#tdSendComplete').combobox('getValue')
    });
}
