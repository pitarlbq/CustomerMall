var tt_CanLoad = false, columns = [];
$(function () {
    loadParams();
    loadtt();
})
function loadtt() {
    var options = { visit: "getmonthfeeanalysiscolumns" }
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx',
        success: function (result) {
            if (result.status) {
                columns = eval(result.columns);
                loaddg();
            }
        }
    });
}
function loadParams() {
    $.ajax({
        type: 'POST',
        data: { visit: 'getmonthfeeanalysisparams' },
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
            tdYear.combobox({
                editable: false,
                data: data.years,
                valueField: 'ID',
                textField: 'Name',
            });
            var myDate = new Date;
            tdYear.combobox('setValue', myDate.getFullYear());
        }
    });
}
function MergeCells(tableID, fldList) {
    var Arr = fldList.split(",");
    var dg = $('#' + tableID);
    var fldName;
    var RowCount = dg.datagrid("getRows").length;
    var span;
    var PerValue = "";
    var CurValue = "";
    var length = Arr.length - 1;
    var list = [];
    for (i = 0; i <= length; i++) {
        fldName = Arr[i];
        PerValue = "";
        span = 1;
        for (row = 0; row <= RowCount; row++) {
            if (row == RowCount) {
                CurValue = "";
            }
            else {
                CurValue = dg.datagrid("getRows")[row]["RoomID"];
            }
            if (PerValue == CurValue) {
                span += 1;
            }
            else {
                var index = row - span;
                list.push({ index: index, fldName: fldName, span: span });
                span = 1;
                PerValue = CurValue;
            }
        }
    }
    if (merge_timeout != null) {
        clearTimeout(merge_timeout);
    }
    do_merge(dg, list, 0);
}
var merge_timeout = null;
function do_merge(dg, list, i) {
    if (i == list.length) {
        return;
    }
    dg.datagrid('mergeCells', {
        index: list[i].index,
        field: list[i].fldName,
        rowspan: list[i].span,
        colspan: null
    });
    merge_timeout = setTimeout(function () {
        do_merge(dg, list, i + 1)
    }, 10);
}

function loaddg() {
    $('#tt_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
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
        onCheck: onCheck,
        onUncheck: onUncheck,
        pageSize: 100,
        pageList: [100, 500, 2000],
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
        columns: columns,
        onLoadSuccess: onLoadSuccess,
        toolbar: '#tb'
    });
}
function SearchHis() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var RoomIDs = GetSelectedRooms();
    var ProjectIDs = GetSelectedProjects();
    var ChargeSummarys = tdChargeSummary.combobox("getValues");
    var Year = tdYear.combobox("getValue");
    Year = (Year = '' ? 2018 : Year);
    var options= {
        "visit": "loadmonthanalysisgrid",
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "ChargeIDs": JSON.stringify(ChargeSummarys),
        "Year": Year
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
function onLoadSuccess(data) {
    var currentcount = data.currentcount || 0;
    var url = '../Handler/AnalysisHandler.ashx?currentcount=' + currentcount;
    $("#tt_table").datagrid("options").url = url;
    MergeCells("tt_table", "ck,FullName,RoomName,DefaultChargeManName");
}
var checked_id = 0;
var unchecked_id = 0;
function onCheck(index, data) {
    if (checked_id > 0) {
        return;
    }
    checked_id = data.ID;
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            checked_id = 0;
        }
        if (row.RoomID == data.RoomID) {
            if (!isChecked(row)) {
                var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#tt_table').datagrid('selectRow', rowIndex);
                }
            }
        }
    })
}
function isChecked(row) {
    var allRows = $("#tt_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.ID == allRows[i].ID) {
            return true;
        }
    }
    return false;
}
function onUncheck(index, data) {
    if (unchecked_id > 0) {
        return;
    }
    unchecked_id = data.ID;
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            unchecked_id = 0;
        }
        if (row.RoomID == data.RoomID) {
            if (isChecked(row)) {
                var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#tt_table').datagrid('unselectRow', rowIndex);
                }
            }
        }
    })
}
function openSetting() {
    var iframe = "../SysSeting/MonthFeeAnalysisColumnSetup.aspx?PageCode=MonthFeeAnalysis";
    do_open_dialog('列配置', iframe);
}