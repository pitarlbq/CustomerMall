var his_CanLoad = false;
$(function () {
    loadParams();
    $("#tdChargeStatus").combobox({
        editable: false,
        multiple: true,
    });
    $("#tdChargeStatus").combobox("setValues", []);
    setTimeout(function () {
        loadchargeHistoryBill();
    }, 1000);
})
function loadParams() {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx?visit=getrealcostsearch',
        success: function (data) {
            $("#tdChargeMan").combobox({
                editable: false,
                data: data.users,
                valueField: 'UserID',
                textField: 'RealName',
                multiple: true,
            });
            $("#tdChargeSummary").combobox({
                editable: false,
                data: data.summarys,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
            });
            $("#tdChargeType").combobox({
                editable: false,
                data: data.chargetypes,
                valueField: 'ChargeTypeID',
                textField: 'ChargeTypeName',
                multiple: true,
            });
            $("#tdCategory").combobox({
                editable: false,
                data: data.categories,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
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
                CurValue = dg.datagrid("getRows")[row]["PrintID"];
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

function loadchargeHistoryBill() {
    var options = { visit: 'loadtablecolumn', pagecode: 'roomfeehistory' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                his_CanLoad = false;
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
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
                    showFooter: true,
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
                    columns: finalcolumn,
                    onLoadSuccess: onLoadSuccess,
                    toolbar: '#tb'
                });
                SearchHis();
                return;
            }
            show_message("系统正忙，请稍候重试", "error");
        }
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
    var RoomIDs = [];
    var ProjectIDs = [];
    try {
        RoomIDs = parent.GetSelectedRooms();
        ProjectIDs = parent.GetSelectedProjects();
    } catch (e) {

    }
    var options = {
        "visit": "loadroomfeehistorylist",
        "RoomID": JSON.stringify(RoomIDs),
        "ProjectID": JSON.stringify(ProjectIDs),
        "CompanyID": CompanyID,
        "ChargeMans": JSON.stringify($("#tdChargeMan").combobox("getValues")),
        "ChargeSummarys": JSON.stringify($("#tdChargeSummary").combobox("getValues")),
        "ChargeTypes": JSON.stringify($("#tdChargeType").combobox("getValues")),
        "Categories": JSON.stringify($("#tdCategory").combobox("getValues")),
        "ChargeStatus": '[1]',
        "IncludeFooter": true,
        "StartChargeTime": StartTime,
        "EndChargeTime": EndTime,
        "source": 'RealCostAnalysisDetailsStatics'
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
//列设置
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=roomfeehistory";
    do_open_dialog('实收台帐列表设置', iframe);
}
function formatChargeTypeName(value, row) {
    if (Number(row.CategoryID) < 0) {
        return "";
    }
    if (row.CategoryID == 1) {
        return "收入";
    }
    if (row.CategoryID == 2) {
        return "代收";
    }
    if (row.CategoryID == 3) {
        return "押金";
    }
    if (row.CategoryID = 4) {
        return "预收";
    }
}
function formatPrintNumber(value, row) {
    if (value == "总合计") {
        return value;
    }
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
function formatRealCost(value, row) {
    if (Number(row.ChargeState) == 3) {
        return "-" + value;
    }
    if (value < 0) {
        return 0;
    }
    return value;
}
function formatPrintRealCost(value, row) {
    if (Number(row.ChargeState) == 3) {
        return "-" + value;
    }
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
    var PrintIDList = [];
    var ChargeStateList = [];
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
            ChargeStateList.push(row.ChargeState);
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
    var ChargeState = ChargeStateList[0];
    var PrintID = PrintIDList[0];
    top.$.messager.confirm("提示", "确认补打单据?", function (r) {
        if (r) {
            var iframe = "../PrintPage/printchargefeeview.aspx?PrintID=" + PrintID;
            if (ChargeState == 2) {
                iframe = "../PrintPage/printchargefeeview.aspx?PrintID=" + PrintID + "&op=cancel";
            }
            else if (ChargeState == 3) {
                iframe = "../PrintPage/printchargebackguaranteefeeview.aspx?PrintID=" + PrintID;
            }
            else if (ChargeState == 4) {
                iframe = "../PrintPage/printoffsetchargefeeview.aspx?PrintID=" + PrintID;
            }
            startPrint(iframe);
        }
    })
}
var pageWidth = 210, pageHeight = 93;
function PrintHistoryFee(PrintID, ChargeState) {
    var iframe = "../PrintPage/printchargefeeview.aspx?PrintID=" + PrintID;
    if (ChargeState == 2) {
        iframe = "../PrintPage/printchargefeeview.aspx?PrintID=" + PrintID;
    }
    else if (ChargeState == 3) {
        iframe = "../PrintPage/printchargebackguaranteefeeview.aspx?PrintID=" + PrintID;
    }
    else if (ChargeState == 4) {
        iframe = "../PrintPage/printoffsetchargefeeview.aspx?PrintID=" + PrintID;
    }
    startPrint(iframe);
}
function startPrint(url) {
    MaskUtil.mask('body', '打印预览');
    var iframe = document.getElementById("myframe");
    iframe.src = url;
    if (iframe.attachEvent) {
        iframe.attachEvent("onload", function () {
            MaskUtil.unmask();
            setTimeout(function () {
                var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                LODOPPrint(strHtml);
            }, 1000);
        });
    } else {
        iframe.onload = function () {
            MaskUtil.unmask();
            setTimeout(function () {
                var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                LODOPPrint(strHtml);
            }, 1000);
        };
    }
}
function LODOPPrint(strHtml) {
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