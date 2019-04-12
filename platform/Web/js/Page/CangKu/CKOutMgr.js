var tt_CanLoad = false;
$(function () {
    loadComboboxParams();
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadComboboxParams() {
    var options = { visit: 'getoutmgrparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CKHandler.ashx',
        data: options,
        success: function (data) {
            tdAccpetTeam.combobox({
                editable: true,
                data: data.DepartmentList,
                valueField: 'ID',
                textField: 'DepartmentName'
            });
            tdProductCategory.combobox({
                editable: false,
                data: data.ProductCategoryList,
                valueField: 'ID',
                textField: 'Name'
            });
            tdAcceptUser.combobox({
                editable: false,
                data: data.AccpetManList,
                valueField: 'ID',
                textField: 'Name'
            });
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
        pageList: [100],
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
        { field: 'OrderNumber', title: '出库单号', width: 100 },
        { field: 'ApproveStatusDesc', title: '单据状态', width: 100 },
        { field: 'AcceptUserName', title: '领用人', width: 100 },
        { field: 'BelongTeamName', title: '领用部门', width: 100 },
        { field: 'InCategoryName', title: '出库类别', width: 100 },
        { field: 'AddUserName', title: '仓管员', width: 100 },
        { field: 'OutTime', formatter: formatTime, title: '出库时间', width: 120 },
        { field: 'CategoryName', title: '仓库名称', width: 100 },
        { field: 'ProductCategoryName', title: '物品类别', width: 100 },
        { field: 'ProductName', title: '物品名称', width: 100 },
        { field: 'ModelNumber', title: '物品规格', width: 100 },
        { field: 'OutTotalCount', title: '出库数量', width: 100 },
        { field: 'UnitPrice', title: '出库单价', width: 100 },
        { field: 'OutTotalPrice', title: '出库金额', width: 100 },
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
    var DepartmentID = tdAccpetTeam.combobox('getValue');
    var DepartmentName = tdAccpetTeam.combobox('getText');
    var keywords = tdKeyword.searchbox("getValue");
    var ProductCategoryID = tdProductCategory.combobox("getValue");
    var AcceptUserID = tdAcceptUser.combobox("getValue");
    var options = {
        "visit": "loadoutgrid",
        "keywords": keywords,
        "StartTime": StartTime,
        "EndTime": EndTime,
        "CKCategoryID": CKCategoryID,
        "DepartmentID": DepartmentID,
        "DepartmentName": DepartmentName,
        "ProductCategoryID": ProductCategoryID,
        "AcceptUserID": AcceptUserID
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
    MergeCells("tt_table", "ck,OrderNumber,ApproveStatusDesc,AcceptUserName,BelongTeamName,InCategoryName,AddUserName,OutTime,CategoryName");
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
                CurValue = dg.datagrid("getRows")[row]["OutSummaryID"];
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
            if (row.OutSummaryID == data.OutSummaryID && rowIndex != index) {
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
            if (row.OutSummaryID == data.OutSummaryID && rowIndex != index) {
                $('#tt_table').datagrid('unselectRow', rowIndex);
            }
        }
    })
}
function onDblClickRowTT(index, row) {
    editByRow(row.OutSummaryID, row.ApproveStatus)
}
function addRow() {
    var CKCategoryID = GetSelectedID();
    if (CKCategoryID <= 1) {
        show_message('请选择仓库', 'warning');
        return;
    }
    var iframe = "../CangKu/EditCkOut.aspx?CKCategoryID=" + CKCategoryID;
    do_open_dialog("新增出库", iframe);
}
function editRow(op) {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请至少选择一个出库信息进行此操作", "warning");
        return;
    }
    editByRow(row.OutSummaryID, row.ApproveStatus, op);
}
function editByRow(ID, ApproveStatus, op) {
    op = op || 'view';
    if (ApproveStatus == 1 && op == 'edit') {
        show_message("该出库单已审核，禁止修改", "warning");
        return;
    }
    var title = (op == 'edit' ? '编辑' : '查看详情');
    var iframe = "../CangKu/EditCkOut.aspx?ID=" + ID + "&op=" + op;
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
        IDList.push(row.OutSummaryID);
    })
    if (isapproved) {
        show_message("选中的出库单已审核，禁止删除", "warning");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的出库信息", function (r) {
        if (r) {
            var options = { visit: 'removeckout', IDList: JSON.stringify(IDList) };
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
            LODOP.PRINT_INIT("打印单据_出库单");
            LODOP.SET_PRINT_PAGESIZE(1, 2100, 0, '')
            LODOP.ADD_PRINT_TABLE(0, '5%', '90%', '100%', strHtml);
            LODOP.PREVIEW();
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
}
function doPrintIn() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个出库信息进行此操作", "warning");
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        if ($.inArray(this.OutSummaryID, IDList) == -1) {
            IDList.push(this.OutSummaryID);
        }
    });
    doPrintProcess(IDList);
}
function doPrintProcess(IDList) {
    MaskUtil.mask('body', '打印中');
    var iframe = document.getElementById("myframe");
    var url = "../PrintPage/printckoutview.aspx";
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
function doApprove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个进行此操作", "warning");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.OutSummaryID);
    })
    $.messager.defaults.ok = '审核';
    $.messager.defaults.cancel = '取消审核';
    top.$.messager.confirm("提示", "审核出库?", function (r) {
        $.messager.defaults.ok = '确定';
        $.messager.defaults.cancel = '取消';
        var approvestatus = 0;
        if (r) {
            approvestatus = 1;
        }
        var options = { visit: 'approveckout', IDList: JSON.stringify(IDList), approvestatus: approvestatus };
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
