﻿var his_CanLoad = false;
$(function () {
    loadParams();
    tdChargeStatus.combobox({
        editable: false,
        multiple: true,
    });
    tdChargeStatus.combobox("setValues", []);
    loadTT(false);
})
function loadParams() {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx?visit=getrealcostsearch',
        success: function (data) {
            tdChargeMan.combobox({
                editable: false,
                data: data.users,
                valueField: 'UserID',
                textField: 'RealName',
                multiple: true,
                onSelect: function (rec) {
                    var values = tdChargeMan.combobox('getValues');
                    hdChargeMan.val(JSON.stringify(values));
                },
                onUnselect: function (rec) {
                    var values = tdChargeMan.combobox('getValues');
                    hdChargeMan.val(JSON.stringify(values));
                }
            });
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
            tdChargeType.combobox({
                editable: false,
                data: data.chargetypes,
                valueField: 'ChargeTypeID',
                textField: 'ChargeTypeName',
                multiple: true,
                onSelect: function (rec) {
                    var values = tdChargeType.combobox('getValues');
                    hdChargeType.val(JSON.stringify(values));
                },
                onUnselect: function (rec) {
                    var values = tdChargeType.combobox('getValues');
                    hdChargeType.val(JSON.stringify(values));
                }
            });
            tdCategory.combobox({
                editable: false,
                data: data.categories,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
                onSelect: function (rec) {
                    var values = tdCategory.combobox('getValues');
                    hdCategory.val(JSON.stringify(values));
                },
                onUnselect: function (rec) {
                    var values = tdCategory.combobox('getValues');
                    hdCategory.val(JSON.stringify(values));
                }
            });
            tdChargeStatus.combobox({
                onSelect: function (rec) {
                    var values = tdChargeStatus.combobox('getValues');
                    hdChargeStatus.val(JSON.stringify(values));
                },
                onUnselect: function (rec) {
                    var values = tdChargeStatus.combobox('getValues');
                    hdChargeStatus.val(JSON.stringify(values));
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
function loadTT(can_load) {
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
                if (can_load) {
                    SearchHis();
                }
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
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var RoomID = [];
    var ProjectID = [];
    try {
        RoomID = parent.GetSelectedRooms();
        ProjectID = parent.GetSelectedProjects();
    } catch (e) {
    }
    var options = {
        "visit": "loadroomfeehistorylist",
        "RoomID": JSON.stringify(RoomID),
        "ProjectID": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID,
        "ChargeMans": JSON.stringify(tdChargeMan.combobox("getValues")),
        "ChargeSummarys": JSON.stringify(tdChargeSummary.combobox("getValues")),
        "ChargeTypes": JSON.stringify(tdChargeType.combobox("getValues")),
        "Categories": JSON.stringify(tdCategory.combobox("getValues")),
        "ChargeStatus": JSON.stringify(tdChargeStatus.combobox("getValues")),
        "IncludeFooter": true,
        "ExcludeCuiShou": true,
        "PayOnLineStatus": $('#tdPayOnLineStatus').combobox("getValue")
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
    var ChargeStateDesc = "'" + row.ChargeStateDesc + "'";
    if (value == '') {
        value = '未设置';
    }
    return '<a href="javascript:PrintHistoryFee(' + PrintID + ', ' + ChargeState + ',' + ChargeStateDesc + ')">' + value + '</a>';
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
function PrintHistoryFee(PrintID, ChargeState, ChargeStateDesc) {
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