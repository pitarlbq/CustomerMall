var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        gettablecolumn();
    }, 500);
});
function gettablecolumn() {
    var options = { visit: 'loadtablecolumn', pagecode: 'chequeinmgr' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                loadtt(finalcolumn);
            }
        }
    });
}

function loadtt(finalcolumn) {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/ChequeHandler.ashx',
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
        striped: true,
        showFooter: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
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
        onLoadSuccess: onLoadSuccess,
        onCheck: onCheck,
        onUncheck: onUncheck,
        columns: finalcolumn,
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function onLoadSuccess(data) {
    MergeCells("tt_table", "ck,ID,WriteDate,DepartmentName,DepartmentFile,ProjectName,SellerName,SellerTaxNumber,SellerAddressPhone,SellerBankAccount,SignOperator,SignTime,ApproveOperator,ApporveTime,WriteMan,SellerCategoryName,ProjectCategoryName,DepartmentCategoryName,BuyerCategoryName,ChequeNumber,ChequeTime,ChequeTotalCost,BuyerName,BuyerTaxNumber,BuyerAddressPhone,BuyerBankAccount", "ID");
}
function onCheck(index, data) {
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (!isChecked(row)) {
            var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
            if (row.ID == data.ID) {
                $('#tt_table').datagrid('selectRow', rowIndex);
            }
        }
    })
}
function isChecked(row) {
    var allRows = $("#tt_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.DetailID == allRows[i].DetailID) {
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
            if (row.ID == data.ID && rowIndex != index) {
                $('#tt_table').datagrid('unselectRow', rowIndex);
            }
        }
    })
}
function SearchTT() {
    var sellerlist = [];
    var productlist = [];
    var departmentlist = [];
    var projectlist = [];
    try {
        sellerlist = GetSelectSeller();
        productlist = GetSelectProduct();
        departmentlist = GetSelectDepartment();
        projectlist = GetSelectProject();
    } catch (e) {

    }
    var keywords = $("#tdKeyword").searchbox("getValue");
    var StartTime = $('#tdStartTime').datebox('getValue');
    var EndTime = $('#tdEndTime').datebox('getValue');
    var ChequeNo = $('#tdChequeNo').textbox('getValue');
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadchequeingrid",
        "keywords": keywords,
        "sellerlist": JSON.stringify(sellerlist),
        "productlist": JSON.stringify(productlist),
        "departmentlist": JSON.stringify(departmentlist),
        "projectlist": JSON.stringify(projectlist),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "ChequeNo": ChequeNo
    });
    closeSearchwin();
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? value : "");
}
function addRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/EditChequeIn.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '进项登记',
        width: ($(window).width() - 200),
        height: $(window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function editRow() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请选择一个进项进行此操作", "info");
        return;
    }
    EditDataByRow(row);
}
function EditDataByRow(row) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/EditChequeIn.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '进项修改',
        width: ($(window).width() - 200),
        height: $(window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个进项进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "确认删除选中的进项?", function (r) {
        if (r) {
            var options = { visit: 'removechequein', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
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
function doSign() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请选择一个进项进行此操作", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ChequeSign.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '签收',
        width: ($(window).width() - 200),
        height: $(window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function doApprove() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请选择一个进项进行此操作", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ChequeApprove.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '审核',
        width: ($(window).width() - 200),
        height: $(window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function doImport() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ImportInSummary.aspx' style='width:100%;height:" + ($(window).height() - 190) + "px;'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '导入进项',
        width: $(window).width() - 400,
        height: $(window).height() - 150,
        top: 50,
        left: 200,
        modal: false,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function openTableSetUp() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/TableSetUp.aspx?PageCode=chequeinmgr' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '进项列表设置',
        width: $(window).width() - 400,
        height: $(window).height(),
        top: 0,
        left: 300,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            gettablecolumn();
        }
    });
}

function MergeCells(tableID, fldList, firstFld) {
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
                CurValue = dg.datagrid("getRows")[row][firstFld];
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