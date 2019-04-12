var fee_CanLoad = false;
var columns;
$(function () {
    getdgcolumns();
})
function getdgcolumns() {
    var options = { visit: "getpayserviceanalysicolumns" }
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        success: function (result) {
            if (result.status) {
                columns = eval(result.columns);
                loadFeedg();
            }
            else {
                show_message('请先配置支出项目', 'info');
            }
        }
    });
}
function loadFeedg() {
    fee_CanLoad = false;
    $('#fee_table').datagrid({
        url: '../Handler/ServiceHandler.ashx',
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
        showFooter: true,
        striped: true,
        showFooter: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!fee_CanLoad) {
                $('#tt_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return fee_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: columns,
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
    var StartTime = tdStartTime.datebox("getValue");
    var EndTime = tdEndTime.datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message("支出登记开始日期不能大于结束日期", "info");
            return null;
        }
    }
    var RoomIDs = [];
    var ProjectIDs = [];
    try {
        RoomIDs = GetSelectedRooms();
        ProjectIDs = GetSelectedProjects();
    } catch (e) {
    }
    var options = {
        "visit": "loadpayserviceanalysis",
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartTime": StartTime,
        "EndTime": EndTime
    };
    return options;
}
function formatCostFormat(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return toThousands(value);
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
        url: '../Handler/ServiceHandler.ashx',
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

