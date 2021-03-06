﻿var his_CanLoad = false;
$(function () {
    getcomboboxparams();
    loadchargeHistoryBill();
})
function getcomboboxparams() {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        data: { 'visit': 'getchargeprechargeallparams' },
        url: '../Handler/FeeCenterHandler.ashx',
        success: function (data) {
            tdChargeSummary.combobox({
                editable: false,
                data: data.chargelist,
                valueField: 'ID',
                textField: 'Name',
                multiple: true
            });
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
        showFooter: true,
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
       { field: 'FullName', title: '资源位置', width: 260 },
       { field: 'RoomName', title: '资源编号', width: 100 },
       { field: 'PrintNumber', formatter: formatPrintNumber, title: '收款单号', width: 100 },
       { field: 'ChargeStateDesc', title: '收费状态', width: 100 },
       { field: 'ChargeMan', title: '收款人', width: 100 },
       { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 120 },
       { field: 'ChargeName', title: '收费项目', width: 100 },
       { field: 'ChargeTypeName', title: '费项分类', width: 80 },
       { field: 'StartTime', formatter: formatTime, title: '计费开始日期', width: 80 },
       { field: 'EndTime', formatter: formatTime, title: '计费结束日期', width: 80 },
       { field: 'FormatUnitPrice', title: '单价', width: 80 },
       { field: 'UseCount', title: '面积/用量', width: 80 },
       { field: 'FormatSumRealCost', formatter: formatPrintRealCost, title: '实收合计', width: 80 },
       { field: 'FormatRealCost', formatter: formatRealCost, title: '实收金额', width: 80 },
       { field: 'Remark', title: '备注', width: 100 }
        ]],
        onLoadSuccess: onLoadSuccess,
        toolbar: '#tb'
    });
}
function SearchHis() {
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
             show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var RoomIDs = parent.GetSelectedRooms();
    var ProjectIDs = parent.GetSelectedProjects();
    var ChargeSummarys = tdChargeSummary.combobox("getValues");
    his_CanLoad = true;
    $("#his_table").datagrid("load", {
        "visit": "loadroomfeehistorylist",
        "RoomID": JSON.stringify(RoomIDs),
        "ProjectID": JSON.stringify(ProjectIDs),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "IncludePreCharge": true,
        "CompanyID": CompanyID,
        "IncludeFooter": true,
        "PreChargeStatus": tdChargeStatus.combobox("getValue"),
        "ChargeSummarys": JSON.stringify(ChargeSummarys)
    });
}
function formatRealCost(value, row) {
    if (row.PrintNumber == "总合计") {
        return value;
    }
    if (Number(row.ChargeState) == 3 || Number(row.ChargeState) == 6 || Number(row.ChargeState) == 7) {
        return "-" + value;
    }
    return value;
}
function formatPrintRealCost(value, row) {
    if (row.PrintNumber == "总合计") {
        return value;
    }
    if (Number(row.ChargeState) == 3 || Number(row.ChargeState) == 6) {
        return "-" + value;
    }
    if (value < 0) {
        return 0;
    }
    return value;
}
function formatPrintNumber(value, row) {
    if (value == "总合计") {
        return value;
    }
    var PrintID = "'" + row.PrintID + "'";
    var ChargeState = "'" + row.ChargeState + "'";
    var ChargeStateDesc = "'" + row.ChargeStateDesc + "'";
    var ChargeFee = "'" + row.ChargeFee + "'";
    if (value == '') {
        value = '未设置';
    }
    return '<a href="javascript:PrintHistoryFee(' + PrintID + ', ' + ChargeState + ',' + ChargeStateDesc + ',' + ChargeFee + ')">' + value + '</a>';
}
function onLoadSuccess(data) {
    MergeCells("his_table", "ck,PrintNumber,ChargeStateDesc,ChargeMan,ChargeTime,FormatSumRealCost");
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
    var SamePrintID = true;
    var canContinue = true;
    var PrintIDList = [];
    $.each(rows, function (index, row) {
        if (row.ChargeState == 2) {
            canContinue = false;
            return false;
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
    var ChargeState = rows[0].ChargeState;
    var PrintID = rows[0].PrintID;
    var ChargeStateDesc = rows[0].ChargeStateDesc;
    if (!canContinue) {
        show_message("选中的账单已取消", "info");
        show_message("选中的账单已取消", "info");
        return;
    }
    if (!SamePrintID) {
        show_message("请同一个单号进行打印", "info");
        return;
    }
    saveOperationLog(PrintID);
    var pageWidth = 210;
    var pageHeight = 99;
    MaskUtil.mask('body', '打印中');
    var options = { visit: 'getprinthistorypagesize', PrintID: PrintID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/PrintHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                pageWidth = data.page_width;
                pageHeight = data.page_height;
            }
            var iframe = document.getElementById("myframe");
            var url = "../PrintPage/printchargefeeview.aspx?PrintID=" + PrintID;
            if (ChargeState == 3) {
                url = "../PrintPage/printchargebackguaranteefeeview.aspx?PrintID=" + PrintID;
            }
            else if (ChargeState == 4) {
                url = "../PrintPage/printoffsetchargefeeview.aspx?PrintID=" + PrintID;
            }
            else if (ChargeState == 6) {
                url = "../PrintPage/printchargebackprefeeview.aspx?PrintID=" + PrintID;
            }
            else if (ChargeState == 7) {
                url = "../PrintPage/printchargepayserviceview.aspx?PrintID=" + PrintID;
            }
            else if (ChargeState == 2) {
                if (ChargeStateDesc == "已作废(退预收款)") {
                    url = "../PrintPage/printchargebackprefeeview.aspx?PrintID=" + PrintID;
                }
                else if (ChargeStateDesc == "已作废(退押金)") {
                    url = "../PrintPage/printchargebackguaranteefeeview.aspx?PrintID=" + PrintID;
                }
            }
            url = url + "&PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
            iframe.src = url;
            if (iframe.attachEvent) {
                iframe.attachEvent("onload", function () {
                    MaskUtil.unmask();
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml, pageWidth, pageHeight);
                    }, 1000);
                });
            } else {
                iframe.onload = function () {
                    MaskUtil.unmask();
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml, pageWidth, pageHeight);
                    }, 1000);
                };
            }
        }
    });
}
function LODOPPrint(strHtml, pageWidth, pageHeight) {
    var LODOP = null;
    try {
        LODOP = getLodop();
        if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
            LODOP.PRINT_INIT("打印单据_收款单");
            LODOP.SET_PRINT_PAGESIZE(1, pageWidth + 'mm', pageHeight + 'mm', '')
            LODOP.ADD_PRINT_TABLE(0, '3%', '94%', '100%', strHtml);
            LODOP.PREVIEW();
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
}
function PrintHistoryFee(PrintID, ChargeState, ChargeStateDesc, ChargeFee) {
    var title = "打印收款收据";
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargefeeview.aspx?PrintID=" + PrintID + "&op=view' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    if (ChargeState == 3) {
        title = "打印退款单据";
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargebackguaranteefeeview.aspx?PrintID=" + PrintID + "&op=view' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    }
    else if (ChargeState == 4) {
        title = "打印冲抵单据";
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printoffsetchargefeeview.aspx?PrintID=" + PrintID + "&op=view' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    }
    else if (ChargeState == 6) {
        title = "打印退款单据";
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargebackprefeeview.aspx?PrintID=" + PrintID + "&op=view' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    }
    else if (ChargeState == 7) {
        title = "打印付款单据";
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargepayserviceview.aspx?PrintID=" + PrintID + "&op=view' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    }
    else if (ChargeState == 2) {
        if (ChargeStateDesc == "已作废(退预收款)") {
            iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargebackprefeeview.aspx?PrintID=" + PrintID + "&op=view' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
        }
        else if (ChargeStateDesc == "已作废(退押金)") {
            iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printchargebackguaranteefeeview.aspx?PrintID=" + PrintID + "&op=view' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
        }
        else if (ChargeFee > 0) {
            iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../PrintPage/printoffsetchargefeeview.aspx?PrintID=" + PrintID + "&op=view' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
        }
    }
    parent.$("<div id='winprint'></div>").appendTo("body").window({
        title: title,
        width: $(parent.window).width() - 450,
        height: $(parent.window).height(),
        top: 0,
        left: 250,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winprint").remove();
        }
    });
}
function cancelHistoryChargeFee() {
    var rows = $('#his_table').datagrid("getSelections");
    var PrintIDList = [];
    if (rows.length == 0) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    var canCancel = true;
    var isPreCharge = false;
    var PreChargeID = [];
    $.each(rows, function (index, row) {
        if (row.ChargeState == 2) {
            canCancel = false;
            return false;
        }
        if ($.inArray(row.PrintID, PrintIDList) == -1) {
            PrintIDList.push(row.PrintID);
        }
    });
    if (!canCancel) {
        show_message("不能重复作废", "info");
        return;
    }
    //if (isPreCharge) {
    //    var options = { visit: 'checkprechargeroomfeehistory', RoomIDs: JSON.stringify(PreChargeID) };
    //    $.ajax({
    //        type: 'POST',
    //        dataType: 'json',
    //        url: '../Handler/FeeCenterHandler.ashx',
    //        data: options,
    //        success: function (message) {
    //            if (message.status == 2) {
    //                show_message("预收款已经冲销,禁止作废", "info");
    //                return;
    //            }
    //            if (message.status == 1) {
    //                top.$.messager.confirm("提示", "确认作废选中的单据?", function (r) {
    //                    if (r) {
    //                        CancelRoomFeeHistory(PrintIDList)
    //                    }
    //                })
    //            }
    //        }
    //    });
    //    return;
    //}
    top.$.messager.confirm("提示", "确认作废选中的单据?", function (r) {
        if (r) {
            CancelRoomFeeHistory(PrintIDList)
        }
    })
}
function CancelRoomFeeHistory(PrintIDList) {
    var options = { visit: 'cancelhistoryfee', PrintIDList: JSON.stringify(PrintIDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                if (data.hasorder) {
                    show_message("选中的订单部分已交班，禁止作废操作", "info");
                    return;
                }
                show_message("作废成功", "info");
                $('#his_table').datagrid("reload");
                parent.GetBalance(0);
            }
            else if (data.msg) {
                show_message(data.msg, 'warning');
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function saveOperationLog(PrintID) {
    var options = { visit: 'saveoperationlog', PrintID: PrintID, op: 'HistoryPrint' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
        }
    });
}