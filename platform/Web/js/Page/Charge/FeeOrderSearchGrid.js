function MergeCells(tableID, fldList) {
    var Arr = fldList.split(",");
    var dg = $('#' + tableID);
    var fldName;
    var RowCount = dg.datagrid("getRows").length;
    var span;
    var PerValue = "";
    var CurValue = "";
    var length = Arr.length - 1;
    for (i = length; i >= 0; i--) {
        fldName = Arr[i];
        PerValue = "";
        span = 1;
        for (row = 0; row <= RowCount; row++) {
            if (row == RowCount) {
                CurValue = "";
            }
            else {
                CurValue = dg.datagrid("getRows")[row]["PrintID"];
            }
            if (PerValue == CurValue) {
                span += 1;
            }
            else {
                var index = row - span;
                dg.datagrid('mergeCells', {
                    index: index,
                    field: fldName,
                    rowspan: span,
                    colspan: null
                });
                span = 1;
                PerValue = CurValue;
            }
        }
    }
}
var his_CanLoad = false;
$(function () {
    loadchargeHistoryBill();
});
var all_history_idlist = [];
function loadchargeHistoryBill() {
    $('#his_table').datagrid({
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
        onCheck: onCheck,
        onUncheck: onUncheck,
        pageSize: 100,
        pageList: [100],
        onBeforeLoad: function (data) {
            if (!his_CanLoad) {
                $('#his_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return his_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#his_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'PrintNumber', title: '收款单号', width: 100 },
        { field: 'ChargeStateDesc', title: '单据状态', width: 100 },
        { field: 'ChargeMan', title: '收款人', width: 100 },
        { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 120 },
        { field: 'RoomName', title: '房号', width: 100 },
        { field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'StartTime', formatter: formatTime, title: '计费开始日期', width: 80 },
        { field: 'EndTime', formatter: formatTime, title: '计费结束日期', width: 80 },
        { field: 'UnitPrice', title: '单价', width: 80 },
        { field: 'UseCount', title: '面积/用量', width: 80 },
        { field: 'RealCost', title: '实收金额', width: 80 },
        { field: 'Discount', formatter: formatDecimal, title: '减免金额', width: 80 },
        { field: 'StartPoint', formatter: formatDecimal, title: '上次读数', width: 80 },
        { field: 'EndPoint', formatter: formatDecimal, title: '本次读数', width: 80 },
        { field: 'TotalPoint', formatter: formatDecimal, title: '本次用量', width: 80 },
        { field: 'Remark', title: '备注', width: 100 }
        ]],
        onLoadSuccess: onLoadSuccess,
        toolbar: '#tt_mm'
    });
    SearchHis();
}
function SearchHis() {
    his_CanLoad = true;
    var ProjectIDList = parent.GetProjectIDList();
    var RoomIDList = parent.GetSelectedRooms();
    var StartTime = parent.$("#tdStartTime").datetimebox("getValue");
    var EndTime = parent.$("#tdEndTime").datetimebox("getValue");
    var ChargeStates = parent.$("#tdChargeState").combobox("getValues");
    var ChargeTypes = parent.$("#tdChargeType").combobox("getValues");
    if (ProjectIDList.length == 0 && RoomIDList.length == 0) {
        show_message("请选择资源项", "info");
        return;
    }
    if (StartTime == "") {
        show_message("请输入收费开始日期", "info");
        return;
    }
    if (EndTime == "") {
        show_message("请输入收费结束时间", "info");
        return;
    }
    var Operator = parent.$("#tdOperator").combobox("getText");

    $("#his_table").datagrid("load", {
        "visit": "searchordernew",
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Operator": Operator,
        "RoomIDList": JSON.stringify(RoomIDList),
        "ProjectIDList": JSON.stringify(ProjectIDList),
        "ChargeStates": JSON.stringify(ChargeStates),
        "ChargeTypes": JSON.stringify(ChargeTypes),
    });
}
function onLoadSuccess(data) {
    if (data.historyidlist) {
        all_history_idlist = data.historyidlist;
    }
    MergeCells("his_table", "ck,PrintNumber,ChargeStateDesc,ChargeMan,ChargeTime,RoomName");
}

var checked_id = 0;
var unchecked_id = 0;
function onCheck(index, data) {
    if (checked_id > 0) {
        return;
    }
    checked_id = data.HistoryID;
    var rows = $("#his_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            checked_id = 0;
        }
        if (row.PrintID == data.PrintID) {
            if (!isChecked(row)) {
                var rowIndex = $('#his_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#his_table').datagrid('selectRow', rowIndex);
                }
            }
        }
    })
}
function isChecked(row) {
    var allRows = $("#his_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.HistoryID == allRows[i].HistoryID) {
            return true;
        }
    }
    return false;
}
function onUncheck(index, data) {
    if (unchecked_id > 0) {
        return;
    }
    unchecked_id = data.HistoryID;
    var rows = $("#his_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            unchecked_id = 0;
        }
        if (row.PrintID == data.PrintID) {
            if (isChecked(row)) {
                var rowIndex = $('#his_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#his_table').datagrid('unselectRow', rowIndex);
                }
            }
        }
    })
}
function formatDecimal(value, row) {
    if (parseFloat(value) < 0) {
        return 0;
    }
    return value;
}
function chooserows() {
    parent.top_historyidlist = [];
    var check_all_elem = $('.datagrid-view .datagrid-header .datagrid-header-check').find('input[type="checkbox"]');
    if (check_all_elem.prop('checked')) {
        if (all_history_idlist.length == 0) {
            show_message("请选择历史单据", "info");
            return;
        }
        parent.top_historyidlist = all_history_idlist;
    }
    else {
        var rows = $('#his_table').datagrid('getSelections');
        if (rows.length == 0) {
            show_message("请选择历史单据", "info");
            return;
        }
        $.each(rows, function () {
            parent.top_historyidlist.push(this.HistoryID);
        });
    }
    //parent.SearchByHistoryIDs();
    do_close();
}
