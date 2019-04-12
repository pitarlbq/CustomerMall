
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
    Search();
})

function Search() {
    var options = { visit: "searchorder", RoomFeeOrderID: RoomFeeOrderID };
    $.post("../Handler/AnalysisHandler.ashx", options, function (data) {
        if (!data.status) {
            show_message('系统错误', 'error');
            return;
        }
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
            $(".finalDetail").hide();
            return;
        }
        $(".finalDetail").show();
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
                $html += '<td>' + data.FuChargeSummaryList[i].RealCost + '</td>';
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
        striped: true,
        onCheck: onShouCheck,
        onUncheck: onShouUncheck,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
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
        { field: 'FullName', title: '资源位置', width: 150 },
        { field: 'RoomName', title: '资源编号', width: 80 },
        { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 120 },
        { field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'StartTime', formatter: formatTime, title: '计费开始日期', width: 80 },
        { field: 'EndTime', formatter: formatTime, title: '计费结束日期', width: 80 },
        { field: 'UseCount', title: '面积/用量', width: 80 },
        { field: 'UnitPrice', title: '单价', width: 80 },
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
    MergeCells("shou_table", "ck,PrintNumber,ChargeStateDesc,ChargeMan,ChargeTime");
    loadfuTT();
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
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
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
function SearchShouTT() {
    shou_CanLoad = true;
    $("#shou_table").datagrid("load", {
        "visit": "loadroomfeehistorylist",
        "RoomFeeOrderID": RoomFeeOrderID,
        "ChargeStatus": "[1,4]"
    });
}
function SearchFuTT() {
    fu_CanLoad = true;
    $("#fu_table").datagrid("load", {
        "visit": "loadroomfeehistorylist",
        "RoomFeeOrderID": RoomFeeOrderID,
        "ChargeStatus": "[3]"
    });
}
function onLoadFuSuccess(data) {
    MergeCells("fu_table", "ck,PrintNumber,ChargeStateDesc,ChargeMan,ChargeTime");
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
function DoApprove() {
    var ApproveTime = tdApproveTime.datetimebox("getValue");
    var ApproveMan = tdApproveMan.textbox("getText");
    var ApproveUserID = hdApproveUserID.val();
    var ApproveStatus = tdApproveStatus.combobox("getValue");
    var ApproveRemark = tdApproveRemark.textbox("getValue");;
    if (ApproveTime == "") {
        show_message("请输入审核日期", "warning");
        return;
    }
    if (ApproveMan == "") {
        show_message("请输入审核人", "warning");
        return;
    }
    if (ApproveStatus == "") {
        show_message("请选择审核状态", "warning");
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: "saveorderapprove", ApproveTime: ApproveTime, ApproveMan: ApproveMan, ApproveUserID: ApproveUserID, ApproveStatus: ApproveStatus, ApproveRemark: ApproveRemark, RoomFeeOrderID: RoomFeeOrderID };
    $.post("../Handler/AnalysisHandler.ashx", options, function (data) {
        MaskUtil.unmask();
        if (!data.status) {
            show_message('系统错误', 'error');
            return;
        }
        show_message('保存成功', 'success', function () {
            closeWin();
        });
    }, "json")
}
function closeWin() {
    parent.do_close_dialog(function () {
        parent.$('#tt_table').datagrid('reload');
    });
}