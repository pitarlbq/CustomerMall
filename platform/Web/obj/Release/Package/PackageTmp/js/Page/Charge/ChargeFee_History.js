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
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
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
        { field: 'FinalPrintNumber', formatter: formatPrintNumber, title: '收款单号', width: 100 },
        { field: 'ChargeStateDesc', title: '单据状态', width: 100 },
        { field: 'ChargeMan', title: '收款人', width: 100 },
        { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 120 },
        { field: 'RoomName', title: '房号', width: 100 },
        { field: 'ChargeName', title: '收费项目', width: 100 },
        //{ field: 'ChargeTypeName', title: '费项分类', width: 80 },
        { field: 'StartTime', formatter: formatTime, title: '计费开始日期', width: 80 },
        { field: 'EndTime', formatter: formatTime, title: '计费结束日期', width: 80 },
        { field: 'FormatUnitPrice', title: '单价', width: 80 },
        { field: 'UseCount', title: '面积/用量', width: 80 },
        { field: 'FormatSumRealCost', title: '实收合计', width: 80 },
        { field: 'FormatRealCost', title: '实收金额', width: 80 },
        { field: 'Discount', formatter: formatDiscount, title: '减免金额', width: 80 },
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
    var idarry = parent.GetRoomIDList();
    if (idarry.length == 0) {
        return;
    }
    his_CanLoad = true;
    $("#his_table").datagrid("load", {
        "visit": "loadroomfeehistorylist",
        "RoomID": JSON.stringify(idarry)
    });
}
function formatPrintNumber(value, row) {
    var PrintID = "'" + row.PrintID + "'";
    var ChargeState = "'" + row.ChargeState + "'";
    var ChargeStateDesc = "'" + row.ChargeStateDesc + "'";
    var IsChequePrint = row.IsChequePrint;
    if (value == '') {
        value = '未设置'
    }
    return '<a href="javascript:PrintHistoryFee(' + PrintID + ', ' + ChargeState + ',' + ChargeStateDesc + ',' + IsChequePrint + ')">' + value + '</a>';
}
function onLoadSuccess(data) {
    MergeCells("his_table", "ck,PrintNumber,RoomName,ChargeTypeName,ChargeTime,FormatSumRealCost");
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
        show_message("选中的账单已取消", "warning");
        return;
    }
    if (!SamePrintID) {
        show_message("请同一个单号进行打印", "warning");
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
            show_message("Error:该浏览器不支持打印插件!", "warning");
        }
    } catch (err) {
        show_message("Error:本机未安装或需要升级!" + err, "warning");
    }
}
function PrintHistoryFee(PrintID, ChargeState, ChargeStateDesc, IsChequePrint) {
    if (!IsChequePrint) {
        PrintHistoryFeeInvoice(PrintID, ChargeState, ChargeStateDesc);
        return;
    }
    var options = { visit: 'checkprintchequestatus', PrintID: PrintID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/PrintHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status && data.pdfurl) {
                top.window.location.href = data.pdfurl;
            }
            else if (data.reprint) {
                top.$.messager.confirm('提示', '电子发票尚未创建，是否立即创建?', function (r) {
                    if (r) {
                        var iframe = "../PrintPage/PrintChequeView.aspx?PrintID=" + PrintID;
                        do_open_dialog('打印发票', iframe);
                    }
                })
                return;
            }
            else if (data.error) {
                show_message(data.error, 'warning');
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function RePrintCheque(PrintID) {

}
function PrintHistoryFeeInvoice(PrintID, ChargeState, ChargeStateDesc) {
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
        show_message("不能重复作废", "warning");
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
    //                show_message("预收款已经冲销,禁止作废", "warning");
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
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'cancelhistoryfee', CompanyID: companyID, AddMan: AddMan, PrintIDList: JSON.stringify(PrintIDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                if (data.hasorder) {
                    show_message("选中的订单部分已交班，禁止作废操作", "warning");
                    return;
                }
                show_message("作废成功", "success");
                $('#his_table').datagrid("reload");
                parent.GetBalance(0);
            }
            else if (data.error) {
                show_message(data.error, 'warning');
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
