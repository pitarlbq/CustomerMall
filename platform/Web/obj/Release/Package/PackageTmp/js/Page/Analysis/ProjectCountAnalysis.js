var fee_CanLoad = false;

$(function () {
    loadFeedg();
})

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
        { field: 'ProjectName', title: '项目', width: 200, rowspan: 2 },
        { title: '应收情况', width: 100, colspan: 2 },
        { title: '实收情况', width: 100, colspan: 2 },
        { title: '收费率%', width: 100, colspan: 2 },
        ],
        [
        { field: 'YingShou_Count', title: '户数', width: 100 },
        { field: 'YingShou_Amount', title: '金额', width: 100 },
        { field: 'ShiShou_Count', title: '户数', width: 100 },
        { field: 'ShiShou_Amount', title: '金额', width: 100 },
        { field: 'ShouFeiLv_Count', title: '户数', width: 100 },
        { field: 'ShouFeiLv_Amount', title: '金额', width: 100 },
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
    var RoomIDs = GetSelectedRooms();
    var ProjectIDs = GetSelectedProjects();
    var options= {
        "visit": "loadprojectcountanalysis",
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime
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