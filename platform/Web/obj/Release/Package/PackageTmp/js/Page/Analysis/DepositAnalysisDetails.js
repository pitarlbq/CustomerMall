var his_CanLoad = false;
$(function () {
    loadParams();
    loadchargeHistoryBill();
})
function loadParams() {
    $.ajax({
        type: 'POST',
        data: { visit: 'getdepositsearchparams' },
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
    var options = get_options();
    if (options == null) {
        return;
    }
    his_CanLoad = true;
    $("#his_table").datagrid("load", options);
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
    var idarry = parent.GetSelectedRooms();
    var ProjectID = parent.GetSelectedProjects();
    var DepoistStatus = tdDepositStatus.combobox("getValue");
    var ChargeSummarys = tdChargeSummary.combobox("getValues");
    his_CanLoad = true;
    var options = {
        "visit": "loadroomfeehistorylist",
        "RoomID": JSON.stringify(idarry),
        "ProjectID": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID,
        "DepoistStatus": DepoistStatus,
        "IncludeDepoistCharge": true,
        "IncludeFooter": true,
        "ChargeSummarys": JSON.stringify(ChargeSummarys),
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
        url: '../Handler/FeeCenterHandler.ashx',
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
    var PrintID = "'" + row.PrintID + "'";
    var ChargeState = "'" + row.ChargeState + "'";
    return '<a href="javascript:PrintHistoryFee(' + PrintID + ', ' + ChargeState + ')">' + value + '</a>';
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
        show_message("选中的列表中包含未收费的收费项目,补打取消", "warning");
        return;
    }
    if (!SamePrintID) {
        show_message("请同一个单号进行打印", "warning");
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