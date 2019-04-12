var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        gettablecolumn();
    }, 500);
});
function gettablecolumn() {
    var options = { visit: 'loadtablecolumn', pagecode: 'chequecheckmgr' };
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
    MergeCells("tt_table", "ck,ID,WriteDate,DepartmentName,ProjectName,SellerName,TakeTime,TakeUser,ChequeTime,ApproveStatusDesc,ApproveRemark,ApproveMonth,ApproveTime,ApproveStatus,TransferTime,TransferMan,TransferMoney,CheckApproveRemark,ApproveMethod,ChequeCode,TakeStatusDesc,TransferStatusDesc", "ID");
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
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadchequecheckgrid",
        "keywords": keywords,
        "sellerlist": JSON.stringify(sellerlist),
        "productlist": JSON.stringify(productlist),
        "departmentlist": JSON.stringify(departmentlist),
        "projectlist": JSON.stringify(projectlist),
        "TakeStatus": $("#tdTakeStatus").combobox('getValue'),
        "ApproveStatus": $("#tdApproveStatus").combobox('getValue'),
        "TransferStatus": $("#tdTransferStatus").combobox('getValue')
    });
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? value : "");
}
function doTakeRow() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请选择一项进行此操作", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ChequeCheck_Take.aspx?ID=" + row.ID + "&InSummaryID=" + row.InSummaryID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '接管',
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
            $("#winaddproduct").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function doTransferRow() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请选择一项进行此操作", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ChequeCheck_Transfer.aspx?ID=" + row.ID + "&InSummaryID=" + row.InSummaryID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '转出',
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
            $("#winaddproduct").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function doApproveRow() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请选择一项进行此操作", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ChequeCheck_Approve.aspx?ID=" + row.ID + "&InSummaryID=" + row.InSummaryID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '认证',
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
            $("#winaddproduct").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function doImport() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ImportChequeCheck.aspx' style='width:100%;height:" + ($(window).height() - 190) + "px;'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '导入认证',
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
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/TableSetUp.aspx?PageCode=chequecheckmgr' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '销项列表设置',
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