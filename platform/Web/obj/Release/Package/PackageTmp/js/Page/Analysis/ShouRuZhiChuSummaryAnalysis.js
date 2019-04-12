var fee_CanLoad = false;
var type_CanLoad = false;
var yajin_CanLoad = false;
var chongxiao_CanLoad = false;
var zhichu_CanLoad = false;

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
        fit: false,
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
        { field: 'Name', title: '收费项目', width: 200, rowspan: 2 },
        { title: '实收金额', width: 100, colspan: 3 },
        { field: 'FormatALLShiShouCost', title: '合计', width: 100, rowspan: 2, formatter: formatALLShiShouCost },
        ],
        [
        { field: 'FormatMonthBenqiShouBenqi_ShiShou', title: '收本期', width: 100, formatter: formatMonthBenqiShouBenqi },
        { field: 'FormatMonthBenqiShouLishi_ShiShou', title: '收历史', width: 100, formatter: formatMonthBenqiShouLishi },
        { field: 'FormatMonthBenqiYuShou_ShiShou', title: '收以后', width: 100, formatter: formatMonthBenqiYuShou },
        ]],
        onLoadSuccess: onLoadShiShouSuccess,
        toolbar: '#tbfee'
    });
    //SearchFee();
}
function formatALLShiShouCost(value, row) {
    var value = row.MonthBenqiShouBenqi_ShiShou + row.MonthBenqiShouLishi_ShiShou + row.MonthBenqiYuShou_ShiShou;
    return toThousands(value);
}
function formatMonthBenqiShouBenqi(value, row) {
    return '<a style="color:#000;text-decoration:none;" href="#" title="' + row.MonthBenqiShouBenqi_Title + '" class="easyui-tooltip">' + value + '</a>';
}
function formatMonthBenqiShouLishi(value, row) {
    return '<a style="color:#000;text-decoration:none;" href="#" title="' + row.MonthBenqiShouLishi_Title + '" class="easyui-tooltip">' + value + '</a>';
}
function formatMonthBenqiYuShou(value, row) {
    return '<a style="color:#000;text-decoration:none;" href="#" title="' + row.MonthBenqiYuShou_Title + '" class="easyui-tooltip">' + value + '</a>';
}
function SearchFee() {
    var options = getFeeOptions();
    if (options == null) {
        return;
    }
    fee_CanLoad = true;
    $("#fee_table").datagrid("load", options);
}
function loadYaJindg() {
    $('#yajin_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!yajin_CanLoad) {
                $('#yajin_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return yajin_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#yajin_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'Name', title: '收费项目', width: 200 },
        { field: 'FormatPreTotalCost', title: '期初余额', width: 100 },
        { field: 'FormatCost', title: '本期收取', width: 100 },
        { field: 'FormatChargeReturnCost', title: '本期退还', width: 100 },
        { field: 'FormatAfterTotalCost', title: '期末余额', width: 100 }
        ]],
        onLoadSuccess: onLoadYaJinSuccess,
        toolbar: '#tbyajin'
    });
    SearchYaJinFee();
}
function SearchYaJinFee() {
    var options = getYaJinFeeOptions();
    if (options == null) {
        return;
    }
    yajin_CanLoad = true;
    $("#yajin_table").datagrid("load", options);
}
function loadChongXiaodg() {
    $('#chongxiao_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!chongxiao_CanLoad) {
                $('#chongxiao_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return chongxiao_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#chongxiao_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'Name', title: '收费项目', width: 200 },
        { field: 'FormatPreTotalCost', title: '期初余额', width: 100 },
        //{ field: 'FormatCost', title: '本期预收', width: 100 },
        { field: 'FormatChargeBackCost', title: '本期冲抵', width: 100 },
        //{ field: 'FormatChargeReturnCost', title: '本期退款', width: 100 },
        { field: 'FormatAfterTotalCost', title: '期末余额', width: 100 }
        ]],
        onLoadSuccess: onLoadChongXiaoSuccess,
        toolbar: '#tbchongxiao'
    });
    SearchChongXiaoFee();
}
function SearchChongXiaoFee() {
    var options = getChongXiaoFeeOptions();
    if (options == null) {
        return;
    }
    chongxiao_CanLoad = true;
    $("#chongxiao_table").datagrid("load", options);
}
function loadTypedg() {
    $('#type_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!type_CanLoad) {
                $('#type_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return type_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#type_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'Name', title: '收支方式', width: 200 },
        { field: 'ShouRuCost', title: '收入', width: 100 },
        { field: 'ZhiChuCost', title: '支出', width: 100 }
        ]],
        toolbar: '#tbtype'
    });
    SearchType();
}
function SearchType() {
    var options = getTypeOptions();
    if (options == null) {
        return;
    }
    type_CanLoad = true;
    $("#type_table").datagrid("load", options);
}
function loadZhiChu() {
    $('#zhichu_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!zhichu_CanLoad) {
                $('#zhichu_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return zhichu_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#zhichu_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'Name', title: '收费项目', width: 200 },
        { field: 'TotalCost', title: '支出金额', width: 100 },
        ]],
        toolbar: '#tdzhichu',
        onLoadSuccess: onLoadZhiChuSuccess,
    });
    SearchZhiChuFee();
}
function SearchZhiChuFee() {
    var options = getZhiChuFeeOptions();
    if (options == null) {
        return;
    }
    zhichu_CanLoad = true;
    $("#zhichu_table").datagrid("load", options);
}
function onLoadShiShouSuccess(data) {
    if (chongxiao_CanLoad) {
        SearchChongXiaoFee();
    }
    else {
        loadChongXiaodg();
    }
}
function onLoadYaJinSuccess(data) {
    if (chongxiao_CanLoad) {
        SearchChongXiaoFee();
    }
    else {
        loadChongXiaodg();
    }
}
function onLoadChongXiaoSuccess(data) {
    if (zhichu_CanLoad) {
        SearchZhiChuFee();
    }
    else {
        loadZhiChu();
    }
}
function onLoadZhiChuSuccess(data) {
    if (type_CanLoad) {
        SearchType();
    }
    else {
        loadTypedg();
    }
}
function getFeeOptions() {
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var RoomIDs = GetSelectedRooms();
    var ProjectIDs = GetSelectedProjects();
    var options = {
        "visit": "loadshoufeilvquanzebycharge",
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "IsAnalysisQuery": 1,
        "IsShouRuZhiChuAnalysis": 1,
        "source": "ShouRuZhiChuSumaryAnalysis"
    };
    return options;
}
function doExportFee() {
    var options = getFeeOptions();
    if (options == null) {
        return;
    }
    do_export(options);
}
function getYaJinFeeOptions() {
    var idarry = GetSelectedRooms();
    var ProjectID = GetSelectedProjects();
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    var options = {
        "visit": "loaddepositsummarybychargename",
        "RoomIDs": JSON.stringify(idarry),
        "ProjectIDs": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID,
        "showFooter": true
    };
    return options;
}
function doExportYaJinFee() {
    var options = getYaJinFeeOptions();
    if (options == null) {
        return;
    }
    do_export(options);
}
function getTypeOptions() {
    var idarry = GetSelectedRooms();
    var ProjectID = GetSelectedProjects();
    var ALLProjectIDs = GetALLSelectedProjects();
    var StartTime = tdStartTime.datebox("getValue");
    var EndTime = tdEndTime.datebox("getValue");
    var options = {
        "visit": "loadrealcostsummarybychargetype",
        "RoomIDs": JSON.stringify(idarry),
        "ProjectIDs": JSON.stringify(ProjectID),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "ALLProjectIDs": JSON.stringify(ALLProjectIDs)
    };
    return options;
}
function doExportTypeFee() {
    var options = getTypeOptions();
    if (options == null) {
        return;
    }
    do_export(options);
}
function getZhiChuFeeOptions() {
    var idarry = GetSelectedRooms();
    var ProjectID = GetSelectedProjects();
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    var options = {
        "visit": "loadzhichusummaryanalysis",
        "RoomIDs": JSON.stringify(idarry),
        "ProjectIDs": JSON.stringify(ProjectID),
        "StartTime": StartChargeTime,
        "EndTime": EndChargeTime,
    };
    return options;
}
function doExportZhiChuFee() {
    var options = getZhiChuFeeOptions();
    if (options == null) {
        return;
    }
    do_export(options);
}
function getChongXiaoFeeOptions() {
    var idarry = GetSelectedRooms();
    var ProjectID = GetSelectedProjects();
    var ALLProjectIDs = GetALLSelectedProjects();
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    var options = {
        "visit": "loadprechargesummarybychargename",
        "RoomIDs": JSON.stringify(idarry),
        "ProjectIDs": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID,
        "ALLProjectIDs": JSON.stringify(ALLProjectIDs),
        "source": "ShouRuZhiChuSumaryAnalysis"
    };
    return options;
}
function doExportChongXiaoFee() {
    var options = getChongXiaoFeeOptions();
    if (options == null) {
        return;
    }
    do_export(options);
}
function do_export(options) {
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