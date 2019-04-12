var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: true,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'ContractNo', title: '合同编号', width: 100 },
        { field: 'ContractName', title: '合同名称', width: 100 },
        { field: 'FreeDays', formatter: formatFreeDays, title: '免租期', width: 100 },
        { field: 'TimeLimit', title: '合同期限', width: 100 },
        { field: 'RentStartTime', formatter: formatTime, title: '开始日期', width: 100 },
        { field: 'RentEndTime', formatter: formatTime, title: '结束日期', width: 100 },
        { field: 'ContractStatusDesc', title: '合同状态', width: 150 }
        ]],
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
        toolbar: '#tb'
    });
    SearchTT();
}
function formatFreeDays(value, row) {
    if (Number(value) > 0) {
        return value + '天';
    }
    return "--";
}
function SearchTT() {
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message("签约开始日期不能大于结束日期", "info");
            return;
        }
    }
    var RentStartTime = $("#tdRentStartTime").datebox("getValue");
    var RentEndTime = $("#tdRentEndTime").datebox("getValue");
    if (RentStartTime != '' && RentEndTime != '') {
        if (stringToDate(RentStartTime).valueOf() > stringToDate(RentEndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadcontractgrid",
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "ContractStatus": 'tongguo',
        "RentStartTime": RentStartTime,
        "RentEndTime": RentEndTime,
        "IsDivideOn": true
    });
}
function do_choose() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请先选择一个合同", "info");
        return;
    }
    parent.tdContractNo.textbox('setValue', row.ContractNo);
    parent.tdRentName.textbox('setValue', row.RentName);
    parent.hdContractID.val(row.ID);
    do_close();
}
function do_close() {
    parent.do_close_dialog()
}