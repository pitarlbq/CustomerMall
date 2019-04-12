var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CKHandler.ashx',
        loadMsg: '正在加载',
        border: true,
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
        { field: 'ProductName', title: '物品名称', width: 100 },
        { field: 'CategoryName', title: '物品类别', width: 100 },
        { field: 'Unit', title: '单位', width: 100 },
        { field: 'ArvUnitPrice', title: '单价', width: 100 },
        { field: 'TotalCount', formatter: formatCount, title: '数量', width: 100 },
        { field: 'TotalPrice', formatter: formatCount, title: '金额', width: 100 }
        ]],
        toolbar: '#tb'
    });
    SearchTT();
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
    var StartTime = tdStartTime.datebox('getValue');
    var EndTime = tdEndTime.datebox('getValue');
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var keywords = tdKeyword.searchbox("getValue");
    var TreeID = 0;
    var ProductID = 0;
    try {
        TreeID = GetSelectedID();
    } catch (e) {
    }
    var options = {
        "visit": "loadmateriallingyonganalysis",
        "keywords": keywords,
        "TreeID": TreeID,
        "StartTime": StartTime,
        "EndTime": EndTime
    };
    return options;
}
function formatCount(value, row) {
    if (parseFloat(value) < 0) {
        return 0;
    }
    return value;
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
        url: '../Handler/CKHandler.ashx',
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