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
        { field: 'UnitPrice', title: '入库单价', width: 100, editor: { type: 'numberbox', options: { precision: 2 } } },
        { field: 'InTotalCount', title: '入库数量', width: 100, editor: { type: 'numberbox', options: { precision: 0 } } },
        { field: 'InTotalPrice', title: '金额', width: 100, editor: { type: 'numberbox', options: { disabled: true, precision: 2 } } },
        { field: 'RestInventory', title: '剩余库存', width: 100 },
        { field: 'Remark', title: '备注', width: 100, editor: { type: 'text' } }
    ]];
    return columnslist;
}
function loadComboboxParams(showcontract, showcategory, showteam, dosearch) {
    var options = { visit: 'getindetailparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CKHandler.ashx',
        data: options,
        success: function (data) {
            if (dosearch || (showcontract && ChosenContractID > 0)) {
                ContractObj.combobox({
                    editable: false,
                    data: data.ContractList,
                    valueField: 'ID',
                    textField: 'ContractName',
                    onSelect: function (rec) {
                        ContractUserNameObj.textbox('setValue', rec.ContactMan);
                        ContractPhoneNumberObj.textbox('setValue', rec.PhoneNumber);
                    }
                });
                if (ChosenContractID > 0) {
                    ContractObj.combobox('setValue', ChosenContractID);
                }
            }
            if (showcategory) {
                InCategoryObj.combobox({
                    editable: false,
                    data: data.InCategoryList,
                    valueField: 'ID',
                    textField: 'InCategoryName'
                });
                if (ChosenInCategoryID > 0) {
                    InCategoryObj.combobox('setValue', ChosenInCategoryID);
                }
            }
            if (dosearch || (showteam && ChosenDepartmentID > 0)) {
                BelongTeamNameObj.combobox({
                    editable: false,
                    data: data.DepartmentList,
                    valueField: 'ID',
                    textField: 'DepartmentName'
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
function loadtt() {
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
            if (ID > 0) {
                setTimeout(function () {
                    reloadTTData();
                }, 500);
            }
        }
    });
    if (ID > 0) {
        SearchTT();
    }
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadinproductdetailgrid",
        "ID": ID
    });
}
function setProductCombobox(index) {
    var dgUnitPrice = $('#tt_table').datagrid('getEditor', { index: index, field: 'UnitPrice' }).target;
    var dgInTotalCount = $('#tt_table').datagrid('getEditor', { index: index, field: 'InTotalCount' }).target;
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
    var dgInTotalCount = $('#tt_table').datagrid('getEditor', { index: index, field: 'InTotalCount' }).target;
    var dgInTotalPrice = $('#tt_table').datagrid('getEditor', { index: index, field: 'InTotalPrice' }).target;
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
    SelectedList = [];
    var iframe = "../CangKu/AddInOutProduct.aspx";
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
            var inventory = parseFloat(this.InTotalCount > 0 ? this.InTotalCount : 0);
            var unitprice = parseFloat(this.UnitPrice > 0 ? this.UnitPrice : 0);
            totalCount += inventory;
            totalCost += (inventory * unitprice);
        })
        var footerow = { ProductName: '合计', InTotalCount: totalCount, UnitPrice: '', InTotalPrice: totalCost };
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
            var options = { visit: 'removeckindetail', IDList: JSON.stringify(IDList) };
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
function onClickTTRow(index, row) {
    if (canEdit == 0) {
        return;
    }
    if (editIndex != index) {
        if (endEditing()) {
            $('#tt_table').datagrid('selectRow', index).datagrid('beginEdit', index);
            setProductCombobox(index);
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
    var InTime = InTimeObj.datetimebox("getValue");
    var ContractID = ContractObj.combobox("getValue");
    var ContractName = ContractObj.combobox("getValue");
    var ContractUserName = ContractUserNameObj.textbox("getValue");
    var ContractPhoneNumber = ContractPhoneNumberObj.textbox("getValue");
    var InCategoryID = InCategoryObj.combobox("getValue");
    var BelongTeamName = BelongTeamNameObj.combobox("getText");
    var BelongDepartmentID = BelongTeamNameObj.combobox("getValue");
    endEditing();
    var rows = $('#tt_table').datagrid('getRows');
    if (rows.length == 0) {
        show_message('您尚未添加物品', 'warning');
        return;
    }
    var invalidRowError = '';
    var validRowList = [];
    $.each(rows, function (index, row) {
        if (row.ProductID == '') {
            invalidRowError += (index + 1) + ',';
            return false;
        }
        if (row.UnitPrice == '') {
            row.UnitPrice = 0;
            row.InTotalPrice = 0;
        }
        if (row.InTotalCount == '') {
            row.InTotalCount = 0;
            row.InTotalPrice = 0;
        }
        validRowList.push(row);
    })
    if (invalidRowError != '') {
        var errorlines = "第" + invalidRowError.substring(0, invalidRowError.length - 1) + "行数据不完善";
        show_message(errorlines, 'warning');
        return;
    }
    if (validRowList.length == 0) {
        show_message('请先完善物品', 'warning');
        return;
    }
    var options = { visit: 'saveckinsummary', ID: ID, AddUserName: AddUserName, InTime: InTime, ContractID: ContractID, ContractUserName: ContractUserName, ContractPhoneNumber: ContractPhoneNumber, AddMan: AddMan, ProductRows: JSON.stringify(validRowList), InCategoryID: InCategoryID, BelongTeamName: BelongTeamName, BelongDepartmentID: BelongDepartmentID, ContractName: ContractName, CKCategoryID: CKCategoryID };
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
function doPrintProcess(IDList) {
    MaskUtil.mask('body', '打印中');
    var iframe = document.getElementById("myframe");
    var url = "../PrintPage/printckinview.aspx?IDList=" + JSON.stringify(IDList);
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
            LODOP.SET_PRINT_PAGESIZE(1, 2100, 0, '')
            LODOP.ADD_PRINT_TABLE(0, '5%', '90%', '100%', strHtml);
            LODOP.PREVIEW();
            do_close();
        }
        else {
            show_message("Error:该浏览器不支持打印插件!", "warning");
        }
    } catch (err) {
        show_message("Error:本机未安装或需要升级!", "warning");
    }
}
function do_close() {
    parent.do_close_dialog(function () {
        parent.$("#tt_table").datagrid("reload");
    });
}
var ChosenContractID = 0, ContractName, ContractPhoneNumber, ContractContactMan, ChosenDepartmentID = 0, DepartmentName, ChosenInCategoryID;
function addContract() {
    var iframe = "../CangKu/ContractMgr.aspx?op=choose";
    do_open_dialog('选择供应商', iframe);
}
function do_choose_contract_done() {
    loadComboboxParams(true, false, false, false);
    ContractUserNameObj.textbox('setValue', ContractContactMan);
    ContractPhoneNumberObj.textbox('setValue', ContractPhoneNumber);
}
function addDepartment() {
    var iframe = "../CangKu/DepartmentMgr.aspx?op=choose";
    do_open_dialog('选择部门', iframe);
}
function do_choose_department_done() {
    loadComboboxParams(false, false, true, false);
}
function addCategory() {
    var iframe = "../CangKu/InCategoryMgr.aspx?op=choose&type=ruku";
    do_open_dialog('选择类别', iframe);
}
function do_choose_category_done() {
    loadComboboxParams(false, true, false, false);
}