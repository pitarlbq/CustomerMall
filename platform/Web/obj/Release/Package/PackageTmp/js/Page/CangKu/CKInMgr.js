var tt_CanLoad = false;
$(function () {
    loadSearchCombobox();
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadSearchCombobox() {
    var options = { visit: 'getckinmgrcombobox' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CKHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                tdProductCategory.combobox({
                    editable: false,
                    data: message.ProductCategoryList,
                    valueField: 'ID',
                    textField: 'Name'
                });
            }
        }
    });
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CKHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        onDblClickRow: onDblClickRowTT,
        onCheck: onCheck,
        onUncheck: onUncheck,
        striped: true,
        pageSize: 100,
        pageList: [100, 500],
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $('#tt_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'OrderNumber', title: '入库单号', width: 100 },
        { field: 'ApproveStatusDesc', title: '单据状态', width: 100 },
        { field: 'ContractName', title: '供应商简称', width: 100 },
        { field: 'InCategoryName', title: '入库类别', width: 100 },
        { field: 'AddUserName', title: '仓管员', width: 100 },
        { field: 'InTime', formatter: formatTime, title: '入库时间', width: 120 },
        { field: 'CategoryName', title: '仓库名称', width: 100 },
        { field: 'ProductCategoryName', title: '物品类别', width: 100 },
        { field: 'ProductName', title: '物品名称', width: 100 },
        { field: 'ModelNumber', title: '物品规格', width: 100 },
        { field: 'InTotalCount', title: '入库数量', width: 100 },
        { field: 'UnitPrice', title: '入库单价', width: 100 },
        { field: 'InTotalPrice', title: '入库金额', width: 100 },
        { field: 'Remark', formatter: formatRemark, title: '备注', width: 200 }
        ]],
        toolbar: '#tt_mm',
        onLoadSuccess: onLoadSuccess
    });
    SearchTT();
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var StartTime = tdStartTime.datebox("getValue");
    var EndTime = tdEndTime.datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var CKCategoryID = GetSelectedID();
    var keywords = tdKeyword.searchbox("getValue");
    var ProductCategoryID = tdProductCategory.combobox("getValue");
    tt_CanLoad = true;
    var options = {
        "visit": "loadingrid",
        "keywords": keywords,
        "StartTime": StartTime,
        "EndTime": EndTime,
        "CKCategoryID": CKCategoryID,
        "ProductCategoryID": ProductCategoryID
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
        url: '../Handler/CKHandler.ashx',
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
function formatRemark(value, row) {
    if (value.length > 10) {
        return value.substring(0, 10) + '...';
    }
    return value;
}
function onLoadSuccess(data) {
    MergeCells("tt_table", "ck,OrderNumber,ApproveStatusDesc,ContractName,AddUserName,InTime,InCategoryName,CategoryName");
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
                CurValue = dg.datagrid("getRows")[row]["InSummaryID"];
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
function onCheck(index, data) {
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (!isChecked(row)) {
            var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
            if (row.InSummaryID == data.InSummaryID && rowIndex != index) {
                $('#tt_table').datagrid('selectRow', rowIndex);
            }
        }
    })
}
function isChecked(row) {
    var allRows = $("#tt_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.ID == allRows[i].ID) {
            return true;
        }
    }
    return false;
}
function onUncheck(index, data) {
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (isChecked(row)) {
            var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
            if (row.InSummaryID == data.InSummaryID && rowIndex != index) {
                $('#tt_table').datagrid('unselectRow', rowIndex);
            }
        }
    })
}
function onDblClickRowTT(index, row) {
    editByRow(row.InSummaryID, row.ApproveStatus);
}
function addRow() {
    var CKCategoryID = GetSelectedID();
    if (CKCategoryID <= 1) {
        show_message('请选择仓库', 'warning');
        return;
    }
    var iframe = "../CangKu/EditCkIn.aspx?CKCategoryID=" + CKCategoryID;
    do_open_dialog('新增入库', iframe);
}
function editRow(op) {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请至少选择一个入库信息进行此操作", "warning");
        return;
    }
    editByRow(row.InSummaryID, row.ApproveStatus, op);
}
function editByRow(ID, ApproveStatus, op) {
    op = op || 'view';
    if (ApproveStatus == 1 && op == 'edit') {
        show_message("该入库单已审核，禁止修改", "warning");
        return;
    }
    var title = (op == 'edit' ? '编辑' : '查看详情');
    var iframe = "../CangKu/EditCkIn.aspx?ID=" + ID + "&op=" + op;
    do_open_dialog(title, iframe);
}
function removeRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个进行此操作", "warning");
        return;
    }
    isapproved = false;
    var IDList = [];
    $.each(rows, function (index, row) {
        if (row.ApproveStatus == 1) {
            isapproved = true;
            return false;
        }
        IDList.push(row.InSummaryID);
    })
    if (isapproved) {
        show_message("选中的入库单已审核，禁止删除", "warning");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的入库信息", function (r) {
        if (r) {
            var options = { visit: 'removeckin', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function LODOPPrint(strHtml) {
    var LODOP = null;
    try {
        LODOP = getLodop();
        if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
            LODOP.PRINT_INIT("打印单据_入库单_1");
            LODOP.SET_PRINT_PAGESIZE(1, 2100, 0, '')
            LODOP.ADD_PRINT_TABLE(0, '5%', '90%', '100%', strHtml);
            LODOP.PREVIEW();
        }
        else {
            show_message("Error:该浏览器不支持打印插件!", "warning");
        }
    } catch (err) {
        show_message("Error:本机未安装或需要升级!", "warning");
    }
}
function doPrintIn() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个入库信息进行此操作", "warning");
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        if ($.inArray(this.InSummaryID, IDList) == -1) {
            IDList.push(this.InSummaryID);
        }
    });
    doPrintProcess(IDList);
}
function doPrintProcess(IDList) {
    MaskUtil.mask('body', '打印中');
    var iframe = document.getElementById("myframe");
    var url = "../PrintPage/printckinview.aspx";
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
function openImport() {
    var iframe = "../CangKu/ImportCKIn.aspx";
    do_open_dialog('导入入库单', iframe);
}
function doApprove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个进行此操作", "warning");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.InSummaryID);
    })
    $.messager.defaults.ok = '审核';
    $.messager.defaults.cancel = '取消审核';
    top.$.messager.confirm("提示", "审核入库?", function (r) {
        $.messager.defaults.ok = '确定';
        $.messager.defaults.cancel = '取消';
        var approvestatus = 0;
        if (r) {
            approvestatus = 1;
        }
        var options = { visit: 'approveckin', IDList: JSON.stringify(IDList), approvestatus: approvestatus };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '../Handler/CKHandler.ashx',
            data: options,
            success: function (message) {
                if (message.status) {
                    show_message('操作成功', 'success', function () {
                        $("#tt_table").datagrid("reload");
                    });
                    return;
                }
                if (message.error) {
                    show_message(message.error, 'warning');
                    return;
                }
                show_message('系统错误', 'error');
            }
        });
    })
}
function do_out() {
    var CKCategoryID = GetSelectedID();
    if (CKCategoryID <= 1) {
        show_message('请选择仓库', 'warning');
        return;
    }
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个进行此操作", "warning");
        return;
    }
    var isapproved = true;
    var IDList = [];
    $.each(rows, function (index, row) {
        if (row.ApproveStatus != 1) {
            isapproved = false;
            return false;
        }
        IDList.push(row.InSummaryID);
    })
    if (!isapproved) {
        show_message("选中的入库单未审核，禁止操作", "warning");
        return;
    }
    var iframe = "../CangKu/EditCkOut.aspx?op=intoout&CKCategoryID=" + CKCategoryID;
    do_open_dialog('转出库单', iframe);
}
function get_selected_rows() {
    var rows = $("#tt_table").datagrid("getSelections");
    return rows;
}
