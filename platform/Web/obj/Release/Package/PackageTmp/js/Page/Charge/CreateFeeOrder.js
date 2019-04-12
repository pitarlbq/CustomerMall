
var shou_CanLoad = false;
var fu_CanLoad = false;
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
$(function () {
    loadSearchCombobox();
})
function GetProjectIDList() {
    var list = GetSelectedProjects();
    return list;
}
function getChargeState() {
    var statelist = [];
    statelist.push({ ID: 1, Name: '收款单' });
    statelist.push({ ID: 2, Name: '退款单' });
    statelist.push({ ID: 3, Name: '作废单' });
    return statelist;
}
function loadSearchCombobox() {
    $("#tdChargeState").combobox({
        editable: false,
        data: getChargeState(),
        valueField: 'ID',
        textField: 'Name',
        multiple: true,
    });
    var options = { visit: 'loadcreateorderparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx',
        data: options,
        success: function (data) {
            $("#tdOperator").combobox({
                editable: false,
                data: data.UList,
                valueField: 'UserID',
                textField: 'RealName',
                multiple: true,
            });
            $('#tdChargeType').combobox({
                editable: false,
                data: data.ChargeTypeList,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
            });
        }
    });
}
var top_historyidlist = [];
function Search() {
    var StartTime = $("#tdStartTime").datetimebox("getValue");
    var EndTime = $("#tdEndTime").datetimebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var ProjectIDList = GetProjectIDList();
    var RoomIDList = GetSelectedRooms();
    var ChargeStates = $("#tdChargeState").combobox("getValues");
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
    var Operator = $("#tdOperator").combobox("getText");
    var iframe = "../Charge/FeeOrderSearchGrid.aspx";
    do_open_dialog('历史单据', iframe);
}
var try_count = 0;

function SearchByHistoryIDs() {
    if (top_historyidlist.length == 0) {
        show_message("请选择历史单据", "info");
        return;
    }
    MaskUtil.mask();
    var options = { visit: "searchorderbyids", HistoryIDs: JSON.stringify(top_historyidlist) };
    $.post("../Handler/AnalysisHandler.ashx", options, function (data) {
        MaskUtil.unmask();
        $(".finalDetail").hide();
        $("#spanSave").hide();
        if (!data.status) {
            show_message('系统错误', 'error');
            return;
        }
        if ((data.summary.TotalChargeCount > 0 && data.summary.ShouTotalRealCost <= 0) || (data.summary.TotalChargeBackCount > 0 && data.summary.FuTotalRealCost <= 0)) {
            if (try_count < 2) {
                try_count++;
                SearchByHistoryIDs();
                return;
            }
        }
        try_count = 0;
        $("#totalCount").html(data.summary.TotalALLCount);
        $("#totalPayCount").html(data.summary.TotalChargeCount);
        $("#totalCancelCount").html(data.summary.TotalChargeCancelCount);
        $("#totalPayBackCount").html(data.summary.TotalChargeBackCount);
        $("#startShouOrderNumber").html(data.summary.ShouKuanStartNumber);
        $("#endShouOrderNumber").html(data.summary.ShouKuanEndNumber);
        $("#startFuOrderNumber").html(data.summary.FuKuanStartNumber);
        $("#endFuOrderNumber").html(data.summary.FuKuanEndNumber);
        $("#shouTotalCost").html(data.summary.ShouTotalRealCost);
        $("#fuTotalCost").html(data.summary.FuTotalRealCost);
        $("#weishuTotalCost").html(data.summary.WeiShuTotalCost);
        $("#tableDetails").empty();
        if (data.summary.TotalALLCount == 0) {
            show_message("没有符合条件的订单", "info");
            return;
        }
        $(".finalDetail").show();
        $("#spanSave").show();
        var $html = '';
        for (var i = 0; i < data.totalCount; i++) {
            $html += '<tr>';
            if (i < data.ShouTypeSummaryList.length) {
                $html += '<td>' + data.ShouTypeSummaryList[i].ChargeTypeName + '</td>';
                $html += '<td>￥' + data.ShouTypeSummaryList[i].RealCost + '</td>';
            }
            else {
                $html += '<td></td>';
                $html += '<td></td>';
            }
            if (i < data.ShouChargeSummaryList.length) {
                $html += '<td>' + data.ShouChargeSummaryList[i].Name + '</td>';
                $html += '<td>￥' + data.ShouChargeSummaryList[i].RealCost + '</td>';
            }
            else {
                $html += '<td></td>';
                $html += '<td></td>';
            }
            if (i < data.FuTypeSummaryList.length) {
                $html += '<td>' + data.FuTypeSummaryList[i].ChargeTypeName + '</td>';
                $html += '<td>￥' + data.FuTypeSummaryList[i].RealCost + '</td>';
            }
            else {
                $html += '<td></td>';
                $html += '<td></td>';
            }
            if (i < data.FuChargeSummaryList.length) {
                $html += '<td>' + data.FuChargeSummaryList[i].Name + '</td>';
                $html += '<td>￥' + data.FuChargeSummaryList[i].RealCost + '</td>';
            }
            else {
                $html += '<td></td>';
                $html += '<td></td>';
            }
            $html += '</tr>';
        }
        //alert($html);
        $("#tableDetails").append($html);
        $.parser.parse(".finalDetail");
        setTimeout(function () {
            loadshouTT();
        }, 100);
    }, "json")
}
function loadshouTT() {
    shou_CanLoad = false;
    $('#shou_table').datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
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
        onCheck: onShouCheck,
        onUncheck: onShouUncheck,
        striped: true,
        showFooter: true,
        pageSize: 100,
        pageList: [100],
        onBeforeLoad: function (data) {
            if (!shou_CanLoad) {
                $('#shou_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return shou_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#shou_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'FullName', title: '资源位置', width: 200 },
        { field: 'RoomName', title: '资源编号', width: 80 },
        { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 120 },
        { field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'StartTime', formatter: formatTime, title: '计费开始日期', width: 80 },
        { field: 'EndTime', formatter: formatTime, title: '计费结束日期', width: 80 },
        { field: 'UseCount', title: '面积/用量', width: 80 },
        { field: 'UnitPrice', title: '单价', width: 80 },
        { field: 'FormatSumRealCost', title: '实收合计', width: 80 },
        { field: 'RealCost', title: '实收金额', width: 80 },
        { field: 'PrintNumber', title: '收款单号', width: 100 },
        { field: 'ChargeStateDesc', title: '单据状态', width: 100 },
        { field: 'ChargeMan', title: '收款人', width: 100 },
        { field: 'ChargeTypeName', title: '费项分类', width: 80 },
        { field: 'Discount', formatter: formatDecimal, title: '减免金额', width: 80 },
        { field: 'StartPoint', formatter: formatDecimal, title: '上次读数', width: 80 },
        { field: 'EndPoint', formatter: formatDecimal, title: '本次读数', width: 80 },
        { field: 'TotalPoint', formatter: formatDecimal, title: '本次用量', width: 80 },
        { field: 'Remark', title: '备注', width: 100 }
        ]],
        onLoadSuccess: onLoadShouSuccess
    });
    SearchShouTT();
}
function onLoadShouSuccess(data) {
    if (shou_CanLoad) {
        MergeCells("shou_table", "ck,PrintNumber,ChargeStateDesc,ChargeMan,ChargeTime,FormatSumRealCost");
        loadfuTT();
    }
}
var shou_checked_id = 0;
var shou_unchecked_id = 0;
function onShouCheck(index, data) {
    if (shou_checked_id > 0) {
        return;
    }
    shou_checked_id = data.HistoryID;
    var rows = $("#shou_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            shou_checked_id = 0;
        }
        if (row.PrintID == data.PrintID) {
            if (!isShouChecked(row)) {
                var rowIndex = $('#shou_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#shou_table').datagrid('selectRow', rowIndex);
                }
            }
        }
    })
}
function isShouChecked(row) {
    var allRows = $("#shou_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.HistoryID == allRows[i].HistoryID) {
            return true;
        }
    }
    return false;
}
function onShouUncheck(index, data) {
    if (shou_unchecked_id > 0) {
        return;
    }
    shou_unchecked_id = data.HistoryID;
    var rows = $("#shou_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            shou_unchecked_id = 0;
        }
        if (row.PrintID == data.PrintID) {
            if (isShouChecked(row)) {
                var rowIndex = $('#shou_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#shou_table').datagrid('unselectRow', rowIndex);
                }
            }
        }
    })
}
function SearchShouTT() {
    shou_CanLoad = true;
    $("#shou_table").datagrid("load", {
        "visit": "loadroomfeehistorylist",
        "ChargeStatus": "[1]",
        "IsRoomFeeSearch": true,
        "HistoryIDs": JSON.stringify(top_historyidlist),
        "IncludeFooter": true,
        "IncludeTime": true
    });
}
function loadfuTT() {
    fu_CanLoad = false;
    $('#fu_table').datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
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
        onCheck: onFuCheck,
        onUncheck: onFuUncheck,
        pageSize: 100,
        pageList: [100],
        showFooter: true,
        onBeforeLoad: function (data) {
            if (!fu_CanLoad) {
                $('#fu_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return fu_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#fu_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'FullName', title: '资源位置', width: 200 },
        { field: 'RoomName', title: '资源编号', width: 80 },
        { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 120 },
        { field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'StartTime', formatter: formatTime, title: '计费开始日期', width: 80 },
        { field: 'EndTime', formatter: formatTime, title: '计费结束日期', width: 80 },
        { field: 'UseCount', title: '面积/用量', width: 80 },
        { field: 'UnitPrice', title: '单价', width: 80 },
        { field: 'FormatSumRealCost', title: '实收合计', width: 80 },
        { field: 'RealCost', title: '实收金额', width: 80 },
        { field: 'PrintNumber', title: '收款单号', width: 100 },
        { field: 'ChargeStateDesc', title: '单据状态', width: 100 },
        { field: 'ChargeMan', title: '收款人', width: 100 },
        { field: 'ChargeTypeName', title: '费项分类', width: 80 },
        { field: 'Discount', formatter: formatDecimal, title: '减免金额', width: 80 },
        { field: 'StartPoint', formatter: formatDecimal, title: '上次读数', width: 80 },
        { field: 'EndPoint', formatter: formatDecimal, title: '本次读数', width: 80 },
        { field: 'TotalPoint', formatter: formatDecimal, title: '本次用量', width: 80 },
        { field: 'Remark', title: '备注', width: 100 }
        ]],
        onLoadSuccess: onLoadFuSuccess
    });
    SearchFuTT();
}
function SearchFuTT() {
    fu_CanLoad = true;
    $("#fu_table").datagrid("load", {
        "visit": "loadroomfeehistorylist",
        "ChargeStatus": "[3,6,7]",
        "IsRoomFeeSearch": true,
        "HistoryIDs": JSON.stringify(top_historyidlist),
        "IncludeFooter": true,
        "IncludeTime": true
    });
}
function onLoadFuSuccess(data) {
    MergeCells("fu_table", "ck,PrintNumber,ChargeStateDesc,ChargeMan,ChargeTime, FormatSumRealCost");
}
var fu_checked_id = 0;
var fu_unchecked_id = 0;
function onFuCheck(index, data) {
    if (fu_checked_id > 0) {
        return;
    }
    fu_checked_id = data.HistoryID;
    var rows = $("#fu_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            fu_checked_id = 0;
        }
        if (row.PrintID == data.PrintID) {
            if (!isFuChecked(row)) {
                var rowIndex = $('#fu_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#fu_table').datagrid('selectRow', rowIndex);
                }
            }
        }
    })
}
function isFuChecked(row) {
    var allRows = $("#fu_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.HistoryID == allRows[i].HistoryID) {
            return true;
        }
    }
    return false;
}
function onFuUncheck(index, data) {
    if (fu_unchecked_id > 0) {
        return;
    }
    fu_unchecked_id = data.HistoryID;
    var rows = $("#fu_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            fu_unchecked_id = 0;
        }
        if (row.PrintID == data.PrintID) {
            if (isFuChecked(row)) {
                var rowIndex = $('#fu_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#fu_table').datagrid('unselectRow', rowIndex);
                }
            }
        }
    })
}
function formatDecimal(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
function saveData() {
    if (top_historyidlist.length == 0) {
        show_message("请选择历史单据", "info");
        return;
    }
    var shou_rows = $("#shou_table").datagrid("getRows");
    var fu_rows = $("#fu_table").datagrid("getRows");
    if (shou_rows.length + fu_rows.length <= 0) {
        show_message("收款单据或付款单据没有数据", "info");
        return;
    }
    var StartTime = $("#tdStartTime").datetimebox("getValue");
    var EndTime = $("#tdEndTime").datetimebox("getValue");
    var Operator = $("#tdOperator").combobox("getText");
    var ProjectIDList = GetProjectIDList();
    var RoomIDList = GetSelectedRooms();
    var AddMan = $("#tdAddMan").textbox("getValue");
    var AddManID = $("#hdAddManID").val();
    var OrderTime = $("#tdOrderTime").datetimebox("getValue");
    var TotalCount = $("#totalCount").text();
    var TotalPayCount = $("#totalPayCount").text();
    var TotalPayBackCount = $("#totalPayBackCount").text();
    var TotalCancelCount = $("#totalCancelCount").text();
    var StartShouOrderNumber = $("#startShouOrderNumber").text();
    var EndShouOrderNumber = $("#endShouOrderNumber").text();
    var StartFuOrderNumber = $("#startFuOrderNumber").text();
    var EndFuOrderNumber = $("#endFuOrderNumber").text();
    var ShouTotalCost = $("#shouTotalCost").text();
    var FuTotalCost = $("#fuTotalCost").text();
    var WeiShuTotalCost = $('#weishuTotalCost').text();
    if (StartTime == "") {
        show_message("请输入收费开始日期", "info");
        return;
    }
    if (EndTime == "") {
        show_message("请输入收费结束时间", "info");
        return;
    }
    if (ProjectIDList.length == 0 && RoomIDList.length == 0) {
        show_message("请选择资源项", "info");
        return;
    }
    if (AddMan == "") {
        show_message("请输入交款人", "info");
        return;
    }
    if (OrderTime == "") {
        show_message("请输入交款时间", "info");
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: "saveorder", StartTime: StartTime, EndTime: EndTime, ChargeMan: Operator, ProjectIDList: JSON.stringify(ProjectIDList), RoomIDList: JSON.stringify(RoomIDList), AddMan: AddMan, OrderTime: OrderTime, AddManID: AddManID, TotalCount: TotalCount, TotalPayCount: TotalPayCount, TotalPayBackCount: TotalPayBackCount, TotalCancelCount: TotalCancelCount, StartShouOrderNumber: StartShouOrderNumber, EndShouOrderNumber: EndShouOrderNumber, StartFuOrderNumber: StartFuOrderNumber, EndFuOrderNumber: EndFuOrderNumber, ShouTotalCost: ShouTotalCost, FuTotalCost: FuTotalCost, HistoryIDs: JSON.stringify(top_historyidlist), WeiShuTotalCost: WeiShuTotalCost };
    $.post("../Handler/AnalysisHandler.ashx", options, function (data) {
        MaskUtil.unmask();
        if (data.status) {
            show_message('保存成功', 'success', function () {
                cancelData();
            });
            return;
        }
        else if (data.error) {
            show_message(data.error, 'warning');
            return;
        }
        show_message('系统错误', 'error');
    }, "json")
}
function cancelData() {
    window.location.reload();
}