﻿var tt_CanLoad = false, currentcount = 0;
$(function () {
    loadParams();
    setTimeout(function () {
        loadTableTT();
    }, 1000);
})
function loadParams() {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx?visit=gettochargesearch',
        success: function (data) {
            $("#tdChargeSummaryName").combobox({
                editable: false,
                data: data.summarys,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
            });
        }
    });
}
function loadTableTT() {
    $('#tt_table').datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
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
        { field: 'RoomName', title: '资源编号', width: 60 },
        { field: 'RelationName', title: '客户名称', width: 80 },
        { field: 'RelatePhoneNumber', title: '联系方式', width: 80 },
        { field: 'Name', title: '收费项目', width: 100 },
        { field: 'CalculateUnitPrice', title: '单价', width: 50 },
        { field: 'CalculateUseCount', title: '面积/用量', width: 80 },
        { field: 'TotalCost', title: '应收金额', width: 60 },
        { field: 'CalculateStartTime', formatter: formatTime, title: '计费开始日期', width: 100 },
        { field: 'CalculateEndTime', formatter: formatTime, title: '计费结束日期', width: 100 },
        { field: 'Point', formatter: formatPoint, title: '上次/本次读数', width: 80 },
        { field: 'OutDays', formatter: formatOutDays, title: '逾期', width: 80 },
        { field: 'CategoryNote', editor: 'textbox', title: '欠费分类', width: 100 },
        { field: 'RemarkNote', editor: 'textbox', title: '沟通备注', width: 100 }
        ]],
        onLoadSuccess: function (data) {
            currentcount = data.currentcount || 0;
            var url = '../Handler/FeeCenterHandler.ashx?currentcount=' + currentcount;
            $("#tt_table").datagrid("options").url = url;
        },
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    $("#tt_table").datagrid("options").url = options.url;
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function formatPoint(value, row) {
    var StartPoint = 0;
    if (Number(row.StartPoint) > 0) {
        StartPoint = row.StartPoint;
    }
    var EndPoint = 0;
    if (Number(row.EndPoint) > 0) {
        EndPoint = row.EndPoint;
    }
    return StartPoint + "/" + EndPoint;
}
function checktime(time) {
    if (time == undefined || time == "" || time == null || time == '0001-01-01T00:00:00.0000000' || time == '0001-01-01T00:00:00' || time == '1900-01-01T00:00:00.0000000' || time == '1900-01-01T00:00:00') {
        return "";
    }
    return time.substring(0, 16).split("T")[0];
}
function formatOutDays(value, row) {
    return calculateOutDays(row.CalculateStartTime) + "天";
}
function calculateOutDays(datetime) {
    var start = checktime(datetime);
    if (start == "") {
        return 0;
    }
    var startdatestr = datetime.substring(0, 16).split("T")[0].replace(/-/g, "/");
    var date1 = new Date(startdatestr);  //计算开始日期
    var date2 = new Date();    //计算结束日期
    var date3 = date2.getTime() - date1.getTime()  //时间差的毫秒数
    var days = Math.floor(date3 / (24 * 3600 * 1000));
    if (days < 0) {
        return 0;
    }
    return days;
}
function get_options() {
    var RoomIDs = [];
    var ProjectIDs = [];
    try {
        RoomIDs = parent.GetSelectedRooms();
        ProjectIDs = parent.GetSelectedProjects();
    } catch (e) {

    }
    var url = '../Handler/FeeCenterHandler.ashx?currentcount=0';
    var options = {
        "visit": "loadroomfeelist",
        "RoomID": JSON.stringify(RoomIDs),
        "ProjectID": JSON.stringify(ProjectIDs),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "CategoryID": 0,
        "CompanyID": CompanyID,
        "IsToCharge": true,
        "ChargeSummarys": JSON.stringify($("#tdChargeSummaryName").combobox("getValues")),
        "ShowFooter": true,
        "IsCharged": -1,
        "IsContractFee": true,
        "ExcludeHistoryChargeTime": true,
        "source": "ToChargeAnalysisDetailsStatisc"
    };
    options.url = url;
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
        url: options.url,
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

