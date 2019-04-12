var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'ContractNo', title: '合同编号', width: 100 },
        { field: 'ContractName', title: '合同名称', width: 100 },
        { field: 'RentName', title: '客户名称', width: 100 },
        { field: 'ContractPhone', title: '联系方式', width: 100 },
        { field: 'ContractBasicRentCost', title: '保底租金', width: 100 },
        { field: 'ContractDivideSellCost', formatter: formatPrice, title: '营业收入', width: 100 },
        { field: 'ContractDevicePercent', formatter: formatPrice, title: '分成比例', width: 100 },
        { field: 'FinalEarnCost', title: '分成金额', width: 100 },
        { field: 'ChargeEarnTypeDesc', title: '收租方式', width: 100 }
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
function formatDecimal(value, row) {
    if (parseFloat(value) < 0) {
        return 0;
    }
    return value;
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
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message("签约开始日期不能大于结束日期", "info");
            return null;
        }
    }
    var RentStartTime = $("#tdRentStartTime").datebox("getValue");
    var RentEndTime = $("#tdRentEndTime").datebox("getValue");
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
    var options = {
        "visit": "loadcontractgrid",
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "ContractStatus": 'tongguo',
        "RentStartTime": RentStartTime,
        "RentEndTime": RentEndTime,
        "IsDivideOn": true,
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids)
    };
    return options;
}
function getContractID() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个扣点合同", "info");
        return 0;
    }
    if (rows.length > 1) {
        show_message("只能选择一个扣点合同", "info");
        return 0;
    }
    var ID = rows[0].ID;
    return ID;
}
function do_create() {
    var ID = getContractID();
    if (ID <= 0) {
        return;
    }
    var iframe = "../ContractEarn/ContractDivideCreate.aspx?ID=" + ID;
    do_open_dialog('账单生成', iframe);
}
function do_process() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个扣点合同", "info");
        return;
    }
    var iframe = "../ContractEarn/ContractEarnProcess.aspx";
    do_open_dialog('批处理', iframe);
}
function do_view() {
    var ID = getContractID();
    if (ID <= 0) {
        return;
    }
    var iframe = GetContextPath + "/ContractEarn/ContractDivideMgr.aspx?ID=" + ID;
    top.addTab('应收账单查看', GetContextPath + '/main/subpage.aspx?pageurl=' + iframe + '&title=应收账单查看')
}