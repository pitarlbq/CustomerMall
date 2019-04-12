var tt_CanLoad = false;
var ProductList;
$(function () {
    loadComboboxParams(true, true, true, true);
});
function getColumnList() {
    var columnslist = [[
        { field: 'ck', checkbox: true },
        { field: 'ProductName', title: '物品名称', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'ModelNumber', title: '规格型号', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'Unit', title: '单位', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'InBasicUnitPrice', formatter: formatInBasicUnitPrice, title: '入库成本', width: 100, editor: { type: 'numberbox', options: { precision: 2, disabled: true } } },
        { field: 'UnitPrice', title: '出库单价', width: 100, editor: { type: 'numberbox', options: { precision: 2 } } },
        { field: 'OutTotalCount', title: '出库数量', width: 100, editor: { type: 'numberbox', options: { precision: 0 } } },
        { field: 'OutTotalPrice', title: '金额', width: 100, editor: { type: 'numberbox', options: { disabled: true, precision: 2 } } },
        { field: 'TotalInventory', title: '库存总数量', width: 100, editor: { type: 'numberbox', options: { disabled: true } } },
        { field: 'Remark', title: '备注', width: 100, editor: { type: 'text' } }
    ]];
    return columnslist;
}
function loadComboboxParams(showuser, showcategory, showteam, dosearch) {
    var options = { visit: 'getoutdetailparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CKHandler.ashx',
        data: options,
        success: function (data) {
            if (showuser) {
                AccpetUserObj.combobox({
                    editable: true,
                    data: data.UserList,
                    valueField: 'AccpetUserID',
                    textField: 'AccpetUserName',
                    filter: function (q, row) {
                        var opts = $(this).combobox('options');
                        return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                    }
                });
            }
            if (ChosenAccpetUserID > 0) {
                AccpetUserObj.combobox('setValue', ChosenAccpetUserID);
            }
            if (showcategory) {
                InCategoryObj.combobox({
                    editable: true,
                    data: data.InCategoryList,
                    valueField: 'ID',
                    textField: 'InCategoryName',
                    filter: function (q, row) {
                        var opts = $(this).combobox('options');
                        return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                    }
                });
                if (ChosenInCategoryID > 0) {
                    InCategoryObj.combobox('setValue', ChosenInCategoryID);
                }
            }
            if (dosearch || (showteam && ChosenDepartmentID > 0)) {
                BelongTeamNameObj.combobox({
                    editable: true,
                    data: data.DepartmentList,
                    valueField: 'ID',
                    textField: 'DepartmentName',
                    filter: function (q, row) {
                        var opts = $(this).combobox('options');
                        return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                    }
                });
                if (ChosenDepartmentID > 0) {
                    BelongTeamNameObj.combobox('setValue', ChosenDepartmentID);
                }
            }
            if (dosearch) {
                loadtt();
            }
        }
    });
}
function loadtt(columnslist) {
    $('#tt_table').datagrid({
        url: '../Handler/CKHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        showFooter: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onClickRow: onClickTTRow,
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
        columns: getColumnList(),
        toolbar: '#tt_mm',
        onLoadSuccess: function (data) {
            if (ID > 0 || ServiceID > 0) {
                setTimeout(function () {
                    reloadTTData();
                }, 500);
            }
        }
    });
    if (ID > 0 || ServiceID > 0 || op == 'intoout') {
        SearchTT();
    }
}
function SearchTT() {
    if (op == 'intoout') {
        //var rows = window.parent.document.getElementById('siteFrame').contentWindow.get_selected_rows();
        var rows = parent.get_selected_rows();
        if (rows.length == 0) {
            show_message("请至少选择一个进行此操作", "warning");
            return;
        }
        var isapproved = true;
        var IDList = [];
        $.each(rows, function (index, row) {
            if (row.ApproveStatus != 1) {
                isapproved = true;
                return false;
            }
            IDList.push(row.InSummaryID);
        })
        if (!isapproved) {
            show_message("选中的入库单未审核，禁止操作", "warning");
            return;
        }
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadoutproductdetailgrid",
        "ID": ID,
        "ServiceID": ServiceID,
        "InIDList": JSON.stringify(IDList)
    });
}
function formatInBasicUnitPrice(value, row, index) {
    row.InBasicUnitPrice = row.InBasicUnitPrice || 0;
    if (parseFloat(row.InBasicUnitPrice) <= 0) {
        row.InBasicUnitPrice = 0;
    }
    if (parseFloat(row.OutTotalCount) <= 0) {
        return 0;
    }
    row.ID = row.ID || 0;
    row.isupdated = row.isupdated || 1;
    if (parseFloat(row.ID) > 0 || row.ProductName == '合计' || row.isupdated == 1) {
        return row.InBasicUnitPrice;
    }
    var options = { visit: 'calculateoutprice', ProductID: row.ProductID, OutCount: row.OutTotalCount, CKCategoryID: CKCategoryID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CKHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                row.InBasicUnitPrice = message.UnitPrice;
            }
            else {
                row.InBasicUnitPrice = 0;
            }
            var rowdata = {
                isupdated: 1,
                InBasicUnitPrice: message.UnitPrice
            }
            if (parseFloat(row.UnitPrice) <= 0) {
                var outtotalprice = (parseFloat(message.UnitPrice) * parseFloat(row.OutTotalCount)).toFixed(2);
                rowdata = {
                    isupdated: 1,
                    InBasicUnitPrice: message.UnitPrice,
                    UnitPrice: message.UnitPrice,
                    OutTotalPrice: outtotalprice
                }
            }
            $("#tt_table").datagrid("updateRow", {
                index: index,
                row: rowdata
            });
        }
    });
    return 0;
}
function calculateTotalPriceByRow(row) {
    var unitprice = row.UnitPrice;
    var intotalcount = row.OutTotalCount;
    var intotalprice = 0;
    if (Number(unitprice) > 0 && Number(intotalcount) > 0) {
        intotalprice = unitprice * intotalcount;
    }
    return intotalprice.toFixed(2);
}
function setProductCombobox(index) {
    var dgUnitPrice = $('#tt_table').datagrid('getEditor', { index: index, field: 'UnitPrice' }).target;
    var dgInTotalCount = $('#tt_table').datagrid('getEditor', { index: index, field: 'OutTotalCount' }).target;
    dgUnitPrice.numberbox({
        onChange: function (value) {
            calculateTotalPrice(index);
        }
    })
    dgInTotalCount.numberbox({
        onChange: function (value) {
            calculateTotalPrice(index);
        }
    })
}
function calculateTotalPrice(index) {
    var dgUnitPrice = $('#tt_table').datagrid('getEditor', { index: index, field: 'UnitPrice' }).target;
    var dgInTotalCount = $('#tt_table').datagrid('getEditor', { index: index, field: 'OutTotalCount' }).target;
    var dgInTotalPrice = $('#tt_table').datagrid('getEditor', { index: index, field: 'OutTotalPrice' }).target;
    var unitprice = dgUnitPrice.numberbox('getValue');
    var intotalcount = dgInTotalCount.numberbox('getValue');
    var intotalprice = 0;
    if (unitprice != '' && intotalcount != '') {
        intotalprice = unitprice * intotalcount;
    }
    dgInTotalPrice.numberbox('setValue', intotalprice);
    reloadTTData();
}
var editIndex;
var rowdefine = {};
var SelectedList = [];
function addRow() {
    var iframe = "../CangKu/AddInOutProduct.aspx?CKCategoryID=" + CKCategoryID;
    do_open_dialog('选择商品', iframe);
}
function choose_product_done() {
    if (SelectedList.length > 0) {
        $.each(SelectedList, function (index, item) {
            $('#tt_table').datagrid('appendRow', item);
        })
        reloadTTData();
    }
}
function reloadTTData() {
    if (canEdit == 1) {
        endEditing();
    }
    var data = $('#tt_table').datagrid('getData');
    if (data.rows && data.rows.length > 0) {
        var totalCount = 0;
        var totalCost = 0;
        $.each(data.rows, function () {
            var inventory = parseFloat(this.OutTotalCount > 0 ? this.OutTotalCount : 0);
            var unitprice = parseFloat(this.UnitPrice > 0 ? this.UnitPrice : 0);
            totalCount += inventory;
            totalCost += (inventory * unitprice);
        })
        var footerow = { ProductName: '合计', OutTotalCount: totalCount, UnitPrice: '', OutTotalPrice: totalCost };
        var footer = [];
        footer.push(footerow);
        $('#tt_table').datagrid('reloadFooter', footer);
    }
}
function removeRow() {
    endEditing();
    var rows = $('#tt_table').datagrid('getSelections');
    var indexlist = [];
    var IDList = [];
    $.each(rows, function (index, row) {
        var rowindex = $('#tt_table').datagrid('getRowIndex', row);
        indexlist.push(rowindex);
        row.ID = row.ID || 0;
        if (row.ID > 0) {
            IDList.push(row.ID);
        }
    })
    if (IDList.length == 0) {
        $.each(indexlist, function (index, item) {
            $('#tt_table').datagrid('cancelEdit', item).datagrid('deleteRow', item - index);
        })
        return;
    }
    top.$.messager.confirm('提示', '确认删除?', function (r) {
        if (r) {
            var options = { visit: 'removeckoutdetail', IDList: JSON.stringify(IDList) };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        $.each(indexlist, function (index, item) {
                            $('#tt_table').datagrid('cancelEdit', item).datagrid('deleteRow', item - index);
                        })
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}
function onClickTTRow(index, row) {
    if (canEdit == 0) {
        return;
    }
    if (editIndex != index) {
        if (endEditing()) {
            $('#tt_table').datagrid('selectRow', index).datagrid('beginEdit', index);
            row.isupdated = 2;
            row.ID = row.ID || 0;
            if (row.ID > 0) {
                $('#tt_table').datagrid('getEditor', { index: index, field: 'UnitPrice' }).target.numberbox('disable', true);
                $('#tt_table').datagrid('getEditor', { index: index, field: 'OutTotalCount' }).target.numberbox('disable', true);
            }
            else {
                setProductCombobox(index);
            }
            editIndex = index;
        } else {
            $('#tt_table').datagrid('selectRow', editIndex);
        }
    }
}
function endEditing() {
    if (editIndex == undefined) {
        return true;
    }
    if ($('#tt_table').datagrid('validateRow', editIndex)) {
        $('#tt_table').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}
function do_save(isprint) {
    var isValid = ffOjb.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var AddUserName = AddUserNameObj.textbox("getValue");
    var OutTime = OutTimeObj.datetimebox("getValue");
    var AccpetUserID = AccpetUserObj.combobox("getValue");
    var AcceptUserName = AccpetUserObj.combobox("getText");
    var AccpetDepartmentName = AccpetDepartmentNameObj.textbox("getText");
    var UseFor = UseForObj.textbox("getText");
    var InCategoryID = InCategoryObj.combobox("getValue");
    var BelongTeamName = BelongTeamNameObj.textbox("getText");
    var BelongTeamID = BelongTeamNameObj.textbox("getValue");
    endEditing();
    var rows = $('#tt_table').datagrid('getRows');
    if (rows.length == 0) {
        show_message('您尚未添加物品', 'warning');
        return;
    }
    var invalidRowError = '';
    var invalidRowErrorMsg = '';

    var validRowList = [];
    $.each(rows, function (index, row) {
        row.ID = row.ID || 0;
        if (row.ProductID == '' || row.UnitPrice == '' || row.OutTotalCount == '') {
            invalidRowError += (index + 1) + ',';
            return false;
        }
        if (row.UnitPrice == '') {
            row.UnitPrice = 0;
            row.OutTotalPrice = 0;
        }
        if (row.OutTotalCount == '') {
            row.OutTotalCount = 0;
            row.OutTotalPrice = 0;
        }
        if (parseFloat(row.OutTotalCount) > parseFloat(row.TotalInventory) && row.ID <= 0) {
            invalidRowError += (index + 1) + ',';
            invalidRowErrorMsg = '出库数量不能大于库存总数';
            return false;
        }
        row.InBasicUnitPrice = row.InBasicUnitPrice || 0;
        validRowList.push({ ID: (row.ID || 0), ProductID: row.ProductID, ModelNumber: row.ModelNumber, Unit: row.Unit, UnitPrice: row.UnitPrice, OutTotalCount: row.OutTotalCount, OutTotalPrice: row.OutTotalPrice, TotalInventory: row.TotalInventory, ProductName: row.ProductName, InBasicUnitPrice: row.InBasicUnitPrice, Remark: row.Remark });
    })
    if (invalidRowError != '') {
        if (invalidRowErrorMsg != '') {
            var errorlines = "第" + invalidRowError.substring(0, invalidRowError.length - 1) + "行" + invalidRowErrorMsg;
            show_message(errorlines, 'warning');
            return;
        }
        var errorlines = "第" + invalidRowError.substring(0, invalidRowError.length - 1) + "行数据不完善";
        show_message(errorlines, 'warning');
        return;
    }
    if (validRowList.length == 0) {
        show_message('请先完善物品', 'warning');
        return;
    }
    var options = { visit: 'saveckoutsummary', ID: ID, AddUserName: AddUserName, OutTime: OutTime, AccpetUserID: AccpetUserID, AcceptUserName: AcceptUserName, AddMan: AddMan, ProductRows: JSON.stringify(validRowList), AccpetDepartmentName: AccpetDepartmentName, UseFor: UseFor, InCategoryID: InCategoryID, BelongTeamName: BelongTeamName, ServiceID: ServiceID, BelongTeamID: BelongTeamID, CKCategoryID: CKCategoryID };
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CKHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                if (isprint) {
                    var id = message.ID;
                    var idlist = [];
                    idlist.push(id);
                    doPrintProcess(idlist);
                }
                else {
                    show_message('保存成功', 'success', function () {
                        do_close();
                    });
                }
            }
            else if (message.error) {
                show_message(message.error, 'warning');
            } else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function doPrintProcess(IDList) {
    MaskUtil.mask('body', '打印中');
    var iframe = document.getElementById("myframe");
    var url = "../PrintPage/printckoutview.aspx?IDList=" + JSON.stringify(IDList);
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
            LODOP.PRINT_INIT("打印单据_出库单");
            LODOP.SET_PRINT_PAGESIZE(1, 2100, 0, '')
            LODOP.ADD_PRINT_TABLE(0, '5%', '90%', '100%', strHtml);
            LODOP.PREVIEW();
            do_close();
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
}
function do_close() {
    parent.do_close_dialog(function () {
        parent.$("#tt_table").datagrid("reload");
    });
}
var ChosenDepartmentID = 0, DepartmentName, ChosenAccpetUserID, ChosenInCategoryID;
function addDepartment() {
    var iframe = "../CangKu/DepartmentMgr.aspx?op=choose";
    do_open_dialog('选择部门', iframe);
}
function do_choose_department_done() {
    loadComboboxParams(false, false, true, false);
}
function addAcceptUserMan() {
    var iframe = "../CangKu/AcceptUserMgr.aspx?op=choose";
    do_open_dialog('选择领用人', iframe);
}
function do_choose_user_done() {
    loadComboboxParams(true, false, true, false);
}
function addCategory() {
    var iframe = "../CangKu/InCategoryMgr.aspx?op=choose&type=chuku";
    do_open_dialog('选择类别', iframe);
}
function do_choose_category_done() {
    loadComboboxParams(false, true, false, false);
}