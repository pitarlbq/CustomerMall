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
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        showFooter: true,
        columns: [[
        { field: 'ContractNo', title: '合同编号', width: 100 },
        { field: 'ContractName', title: '合同名称', width: 100 },
        { field: 'RentName', title: '租户姓名', width: 100 },
        { field: 'TimeLimit', formatter: formatDecimal, title: '合同期限', width: 100 },
        { field: 'RentStartTime', formatter: formatTime, title: '合同开始日期', width: 100 },
        { field: 'RentEndTime', formatter: formatTime, title: '合同结束日期', width: 100 },
        { field: 'ContractStatusDesc', title: '合同状态', width: 150 },
        { field: 'RentPrice', formatter: formatDecimal, title: '租赁价格', width: 100 },
        { field: 'TotalContractArea', formatter: formatDecimal, title: '合同面积', width: 100 },
        { field: 'ContractDeposit', formatter: formatDecimal, title: '合同金额', width: 100 },
        { field: 'TotalCost', formatter: formatDecimal, title: '合同应收', width: 100 },
        { field: 'ChargedCost', formatter: formatDecimal, title: '合同已收', width: 100 },
        //{ field: 'PreCost', formatter: formatDecimal, title: '预收金额', width: 100 },
        { field: 'DepositCost', formatter: formatDecimal, title: '押金金额', width: 100 },
        //{ field: 'BreakCost', formatter: formatDecimal, title: '违约金额', width: 100 },
        { field: 'RestDays', formatter: formatRestDays, title: '剩余天数', width: 100 }
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
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function formatDecimal(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
function formatRestDays(value, row) {
    if (value == 0) {
        return value;
    }
    if (row.ContractStatus != "tongguo") {
        return value;
    }
    if (Number(row.ContractWarningDayCount) < Number(value)) {
        return value;
    }
    return '<span style="color:red;">' + value + '</span>';
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var StartTime = tdStartTime.datebox("getValue");
    var EndTime = tdEndTime.datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message("签约开始日期不能大于结束日期", "info");
            return null;
        }
    }
    var RentStartTime = tdRentStartTime.datebox("getValue");
    var RentEndTime = tdRentEndTime.datebox("getValue");
    if (RentStartTime != '' && RentEndTime != '') {
        if (stringToDate(RentStartTime).valueOf() > stringToDate(RentEndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var roomids = [];
    var projectids = []
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
    } catch (e) {

    }
    tt_CanLoad = true;
    var options = {
        "visit": "loadcontractsummarygrid",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": tdKeywords.searchbox("getValue"),
        "ContractStatus": tdContractStatus.combobox("getValue"),
        "RentStartTime": RentStartTime,
        "RentEndTime": RentEndTime,
        "onlyexpired": expired
    };
    return options;
}
function do_export() {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.canexport = true;
    options.page = 1;
    options.rows = 10;
    MaskUtil.mask('body', '导出中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.downloadurl) {
                window.location.href = data.downloadurl;
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
