var fee_CanLoad = false;
$(function () {
    loadFeeType();
    loadchargetype();
    setTimeout(function () {
        loadFeedg();
    }, 500)
})
function loadFeeType() {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx?visit=getchargesummarylist&CompanyID=' + CompanyID,
        success: function (data) {
            var list = [];
            list.push({ ID: 0, Name: "不限" });
            $.each(data, function (index, item) {
                list.push({ ID: item.ID, Name: item.Name });
            })
            $("#tdChargeSummary").combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
            });
        }
    });
}
function loadchargetype() {
    var options = { visit: 'loadchargesummarytype' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            var list = [];
            list.push({ ID: -1, Name: "不限" });
            $.each(data.list, function (index, item) {
                list.push({ ID: item.ChargeTypeID, Name: item.ChargeTypeName });
            })
            $("#tdChargeType").combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
            });
            $("#tdChargeType").combobox("setValue", -1);
        }
    });
}
function loadFeedg() {
    $('#fee_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
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
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        showFooter: true,
        onBeforeLoad: function (data) {
            if (!fee_CanLoad) {
                $('#fee_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return fee_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#fee_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'ChargeName', title: '收费项目', width: 200 },
        //{ field: 'FormatYingShou', title: '应收', width: 100 },
        { field: 'FormatTotalDiscount', title: '减免', width: 100 },
        { field: 'FormatShiShou', title: '实收', width: 100 },
        { field: 'FormatALLPrintCost', title: '实收合计', width: 100 },
        ]],
        toolbar: '#tbfee'
    });
    SearchFee();
}
function SearchFee() {
    var options = get_options();
    if (options == null) {
        return;
    }
    fee_CanLoad = true;
    $("#fee_table").datagrid("load", options);
}
function get_options() {
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var RoomIDs = parent.GetSelectedRooms();
    var ProjectIDs = parent.GetSelectedProjects();
    var options = {
        "visit": "loadrealcostanalysissummary",
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "IncludeHeJiRow": true
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
        url: '../Handler/AnalysisHandler.ashx',
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