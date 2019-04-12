var his_CanLoad = false;
$(function () {
    loadParams();
    try {
        $('#tdChargeStatus').combobox('setValue', '2');
    } catch (e) {
    }
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
                    pageSize: global_variable.pageSize,
                    pageList: global_variable.pageList,
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
            show_message("系统正忙，请稍候重试", "info");
        }
    });
}
function SearchHis() {
    var RoomID = [];
    var ProjectID = [];
    try {
        RoomID = GetSelectedRooms();
        ProjectID = GetSelectedProjects();
    } catch (e) {

    }
    his_CanLoad = true;
    var StartChargeTime = $("#tdStartTime").datebox("getValue");
    var EndChargeTime = $("#tdEndTime").datebox("getValue");
    var ChargeStatusList = [2];
    try {
        ChargeStatusList = $("#tdChargeStatus").combobox("getValues");
    } catch (e) {
    }
    $("#his_table").datagrid("load", {
        "visit": "loadroomfeehistorylist",
        "RoomID": JSON.stringify(RoomID),
        "ProjectID": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID,
        "ChargeMans": JSON.stringify($("#tdChargeMan").combobox("getValues")),
        "ChargeSummarys": JSON.stringify($("#tdChargeSummary").combobox("getValues")),
        "ChargeTypes": JSON.stringify($("#tdChargeType").combobox("getValues")),
        "Categories": JSON.stringify($("#tdCategory").combobox("getValues")),
        "ChargeStatus": JSON.stringify(ChargeStatusList),
        "IncludeFooter": true
    });
}
//列设置
function openTableSetUp() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/TableSetUp.aspx?PageCode=roomfeehistory' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '实收台帐列表设置',
        width: $(window).width() - 250,
        height: $(window).height(),
        top: 0,
        left: 250,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            loadchargeHistoryBill();
        }
    });
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
    if (value == '') {
        value = '未设置';
    }
    return value;
}
function onLoadSuccess(data) {
    MergeCells("his_table", "ck,PrintNumber,RoomName,ChargeTypeName,ChargeTime,PrintRealCost");
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
function doRemoveAll() {
    var rows = $('#his_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个单据", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.HistoryID);
    })
    top.$.messager.confirm("提示", "确认删除单据?", function (r) {
        if (r) {
            var options = { visit: 'removeroomfeehistory', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#his_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}