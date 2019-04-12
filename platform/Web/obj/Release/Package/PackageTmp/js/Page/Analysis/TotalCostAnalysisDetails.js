var his_CanLoad = false;
$(function () {
    loadchargeHistoryBill();
})
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
function loadchargeHistoryBill() {
    $('#his_table').datagrid({
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
        onCheck: onCheck,
        onUncheck: onUncheck,
        pageSize: 100,
        pageList: [100, 500],
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
        { field: 'PrintNumber', formatter: formatPrintNumber, title: '收款单号', width: 100 },
        { field: 'ChargeStateDesc', title: '收费状态', width: 100 },
        { field: 'ChargeMan', title: '收款人', width: 100 },
        { field: 'RoomName', title: '房号', width: 100 },
        { field: 'ChargeTypeName', formatter: formatChargeTypeName, title: '收款类别', width: 80 },
        { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 120 },
        { field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'StartTime', formatter: formatTime, title: '计费开始日期', width: 80 },
        { field: 'EndTime', formatter: formatTime, title: '计费结束日期', width: 80 },
        { field: 'UnitPrice', title: '单价', width: 80 },
        { field: 'UseCount', title: '面积/用量', width: 80 },
        { field: 'RealCost', title: '实收金额', width: 80 },
        { field: 'StartPoint', formatter: formatDecimal, title: '上次读数', width: 80 },
        { field: 'EndPoint', formatter: formatDecimal, title: '本次读数', width: 80 },
        { field: 'TotalPoint', formatter: formatDecimal, title: '本次用量', width: 80 },
        { field: 'Remark', title: '备注', width: 100 }
        ]],
        onLoadSuccess: onLoadSuccess
    });
    SearchHis();
}
function SearchHis() {
    var StartChargeTime = $("#tdStartTime").datebox("getValue");
    var EndChargeTime = $("#tdEndTime").datebox("getValue");
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
             show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var idarry = parent.GetSelectedRooms();
    var ProjectID = parent.GetSelectedProjects();
    his_CanLoad = true;
    $("#his_table").datagrid("load", {
        "visit": "loadroomfeehistorylist",
        "RoomID": JSON.stringify(idarry),
        "ProjectID": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "IncludIsCharged": true,
        "CompanyID": CompanyID
    });
}
function formatChargeTypeName(value, row) {
    if (Number(row.ChargeFee) > 0) {
        return "冲抵收费";
    }
    if (row.CategoryID == 3 && row.ReturnGuaranteeFee) {
        return "退保证金";
    }
    if (row.CategoryID == 4) {
        return "预收费用";
    }
    if (row.FeeType == 1) {
        return "常规收费";
    }
    else {
        return "临时收费";
    }
}
function formatPrintNumber(value, row) {
    var PrintID = "'" + row.PrintID + "'";
    var ChargeState = "'" + row.ChargeState + "'";
    return '<a href="javascript:PrintHistoryFee(' + PrintID + ', ' + ChargeState + ')">' + value + '</a>';
}
function onLoadSuccess(data) {
    MergeCells("his_table", "ck,PrintNumber,RoomName,ChargeTypeName,ChargeTime");
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
    if (value < 0) {
        return 0;
    }
    return value;
}
function printHistoryChargeFee() {
    var rows = $('#his_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    PrintIDList = [];
    var SamePrintID = true;
    var canContinue = true;
    var isChongDi = false;
    $.each(rows, function (index, row) {
        if (row.ChargeState != 1 && row.ChargeState != 4) {
            canContinue = false;
            return false;
        }
        if (row.ChargeState == 4) {
            isChongDi = true;
        }
        if (index == 0) {
            PrintIDList.push(row.PrintID);
            return true;
        }
        if ($.inArray(row.PrintID, PrintIDList) == -1) {
            SamePrintID = false;
            return false;
        }
    });
    if (!canContinue) {
        show_message('选中的列表中包含未收费的收费项目，补打取消', 'warning');
        return;
    }
    if (!SamePrintID) {
        show_message('请同一个单号进行打印', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "确认补打单据?", function (r) {
        if (r) {
            var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargefeeview.aspx?PrintID=" + PrintIDList[0] + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            if (isChongDi) {
                iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printoffsetchargefeeview.aspx?PrintID=" + PrintIDList[0] + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            }
            $("<div id='winprint'></div>").appendTo("body").window({
                title: '打印收款收据',
                width: $(window).width() - 250,
                height: $(window).height(),
                top: 0,
                left: 250,
                inline: true,
                content: iframe,
                onClose: function () {
                    $("#winprint").remove();
                }
            });
        }
    })
}
function PrintHistoryFee(PrintID, ChargeState) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargefeeview.aspx?PrintID=" + PrintID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    if (ChargeState == 2) {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargefeeview.aspx?PrintID=" + PrintID + "&op=cancel' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    }
    else if (ChargeState == 3) {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargebackguaranteefeeview.aspx?PrintID=" + PrintID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    }
    else if (ChargeState == 4) {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printoffsetchargefeeview.aspx?PrintID=" + PrintID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    }
    $("<div id='winprint'></div>").appendTo("body").window({
        title: '打印收款收据',
        width: $(window).width() - 250,
        height: $(window).height(),
        top: 0,
        left: 250,
        inline: true,
        content: iframe,
        onClose: function () {
            $("#winprint").remove();
        }
    });
}