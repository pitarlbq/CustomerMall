var fee_CanLoad = false;
$(function () {
    loadFeeType();
})
function loadFeeType() {
    var options = { visit: "getchargesummarylist", CompanyID: 0 }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        data: options,
        url: '../Handler/FeeCenterHandler.ashx',
        success: function (data) {
            var list = [];
            list.push({ ID: 0, Name: "全部" });
            $.each(data, function (index, item) {
                list.push({ ID: parseInt(item.ID), Name: item.Name });
            })
            tdChargeSummary.combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
                onSelect: function () {
                    var values = tdChargeSummary.combobox('getValues');
                    hdChargeSummary.val(JSON.stringify(values));
                },
                onUnselect: function () {
                    var values = tdChargeSummary.combobox('getValues');
                    hdChargeSummary.val(JSON.stringify(values));
                }
            });
            loadFeedg();
        }
    });
}
function loadFeedg() {
    fee_CanLoad = false;
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
        { field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'FormatYingShou', title: '应收', width: 100 },
        { field: 'FormatShiShou', title: '实收', width: 100 },
        { field: 'FormatYiShou', title: '已收', width: 100 },
        { field: 'FormatBenQiShouYiHou', title: '本期收以后', width: 100 },
        { field: 'FormatBenQiShouLiShi', title: '本期收历史', width: 100 },
        { field: 'FormatLiShiQianFei', title: '历史欠费', width: 100 }
        ]],
        toolbar: '#tbfee'
    });
    AutoSearchFee();
}
function SearchFee() {
    AutoSearchFee(true)
}
function AutoSearchFee(isclick) {
    var options = get_options(isclick);
    if (options == null) {
        return;
    }
    fee_CanLoad = true;
    $("#fee_table").datagrid("load", options);
}
function get_options(isclick) {
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    if (StartChargeTime == "" && EndChargeTime == "") {
        if (isclick) {
            show_message('日期不能为空', 'warning');
        }
        return null;
    }
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var ChargeIDs = hdChargeSummary.val();
    var RoomIDs = GetSelectedRooms();
    var ProjectIDs = GetSelectedProjects();
    hdRoomIDs.val(JSON.stringify(RoomIDs));
    hdProjectIDs.val(JSON.stringify(ProjectIDs));
    var options= {
        "visit": "loadshourusummaryanalysis",
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "ChargeIDs": ChargeIDs,
        "ChargeMan": tdChargeMan.searchbox('getValue')
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