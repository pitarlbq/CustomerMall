var fee_CanLoad = false;
var type_CanLoad = false;
var visitvalue;
var columns = [[
        { field: 'FullName', title: '资源位置', width: 200 },
        { field: 'RoomName', title: '房间编号', width: 100 },
        { field: 'Name', title: '收费项目', width: 100 },
        { field: 'FormatPreTotalCost', title: '期初余额', width: 100 },
        { field: 'FormatCost', title: '本期预收', width: 100 },
        { field: 'FormatChargeBackCost', title: '本期冲抵', width: 100 },
        { field: 'FormatChargeReturnCost', title: '本期退款', width: 100 },
        { field: 'FormatAfterTotalCost', title: '期末余额', width: 100 }
]];
$(function () {
    visitvalue = "Project";
    loadParams();
    $('input[name=tabletype]').bind('click', function () {
        visitvalue = $(this).val();
        hdRoomType.val(visitvalue);
        if (visitvalue == "ChargeSummary") {
            columns = [[
        { field: 'Name', title: '收费项目', width: 200 },
        { field: 'FormatPreTotalCost', title: '期初余额', width: 100 },
        { field: 'FormatCost', title: '本期预收', width: 100 },
        { field: 'FormatChargeBackCost', title: '本期冲抵', width: 100 },
        { field: 'FormatChargeReturnCost', title: '本期退款', width: 100 },
        { field: 'FormatAfterTotalCost', title: '期末余额', width: 100 }
            ]];
        }
        else {
            columns = [[
        { field: 'FullName', title: '资源位置', width: 200 },
        { field: 'RoomName', title: '房间编号', width: 100 },
        { field: 'Name', title: '收费项目', width: 100 },
        { field: 'FormatPreTotalCost', title: '期初余额', width: 100 },
        { field: 'FormatCost', title: '本期预收', width: 100 },
        { field: 'FormatChargeBackCost', title: '本期冲抵', width: 100 },
        { field: 'FormatChargeReturnCost', title: '本期退款', width: 100 },
        { field: 'FormatAfterTotalCost', title: '期末余额', width: 100 }
            ]];
        }
        loadFeedg();
    })
})
function loadParams() {
    $.ajax({
        type: 'POST',
        data: { visit: 'getprochargesearchparams' },
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx',
        success: function (data) {
            tdChargeSummary.combobox({
                editable: false,
                data: data.summarys,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
                onSelect: function (rec) {
                    var values = tdChargeSummary.combobox('getValues');
                    hdChargeSummary.val(JSON.stringify(values));
                },
                onUnselect: function (rec) {
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
    $('#fee_table').treegrid({
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
        idField: 'id',
        treeField: 'Name',
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!fee_CanLoad) {
                $('#fee_table').treegrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return fee_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#fee_table').treegrid("loadData", {
                total: 0,
                rows: []
            });
        },
        onBeforeExpand: function (row) {
            //动态设置展开查询的url  
            $("#fee_table").treegrid("options").url = '../Handler/AnalysisHandler.ashx?visit=loadprechargesummarybychargename&RoomID=' + row.RoomID;
            return true;
        },
        onExpand: function (row) {
            var children = $("#fee_table").treegrid('getChildren', row.id);
            if (children.length <= 0) {
                $("#fee_table").treegrid('refresh', row.id);
            }
        },
        onLoadSuccess: function (node, data) {
            init();
            var url = '../Handler/AnalysisHandler.ashx?visit=';
            var visit = "loadprechargesummarybyproject";
            if (visitvalue == "ChargeSummary") {
                visit = "loadprechargesummarybychargename";
            }
            else if (visitvalue == "Project") {
                visit = "loadprechargesummarybyproject";
            }
            else if (visitvalue == "Room") {
                visit = "loadprechargesummarybyroom";
            }
            $("#fee_table").treegrid("options").url = url + visit;
        },
        columns: columns,
        toolbar: '#tb'
    });
    SearchFee();
}
function SearchFee() {
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var visit = "loadprechargesummarybyproject";
    if (visitvalue == "ChargeSummary") {
        visit = "loadprechargesummarybychargename";
    }
    else if (visitvalue == "Project") {
        visit = "loadprechargesummarybyproject";
    }
    else if (visitvalue == "Room") {
        visit = "loadprechargesummarybyroom";
    }
    var options = get_options();
    if (options == null) {
        return;
    }
    $("#fee_table").treegrid("options").url = options.url;
    fee_CanLoad = true;
    $("#fee_table").treegrid("load", options);
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
    var visit = "loadprechargesummarybyproject";
    if (visitvalue == "ChargeSummary") {
        visit = "loadprechargesummarybychargename";
    }
    else if (visitvalue == "Project") {
        visit = "loadprechargesummarybyproject";
    }
    else if (visitvalue == "Room") {
        visit = "loadprechargesummarybyroom";
    }
    var url = '../Handler/AnalysisHandler.ashx?visit=' + visit;
    var ChargeIDs = tdChargeSummary.combobox('getValues');
    var idarry = parent.GetSelectedRooms();
    var ProjectID = parent.GetSelectedProjects();
    var options = {
        "RoomIDs": JSON.stringify(idarry),
        "ProjectIDs": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID,
        "ChargeIDs": JSON.stringify(ChargeIDs)
    };
    options.url = url;
    return options;
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
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