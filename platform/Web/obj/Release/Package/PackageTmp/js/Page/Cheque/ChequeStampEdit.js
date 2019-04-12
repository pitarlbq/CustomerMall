
$(function () {
    tdUnitPriceObj.textbox({
        onChange: function (newValue, oldValue) {
            calculateTotalSumCost();
        }
    });
    tdTotalCountObj.textbox({
        onChange: function (newValue, oldValue) {
            calculateTotalSumCost();
        }
    });
    loadComboboxParams();
});
function loadComboboxParams() {
    var options = { visit: 'getchequestampeditparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ChequeHandler.ashx',
        data: options,
        success: function (data) {
            tdDepartmentIDObj.combobox({
                editable: true,
                data: data.DepartmentList,
                valueField: 'ID',
                textField: 'DepartmentName',
                filter: function (q, row) {
                    var opts = $(this).combobox('options');
                    return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                }
            });
            tdContractCategoryIDObj.combobox({
                editable: true,
                data: data.ContractCategoryList,
                valueField: 'ID',
                textField: 'ContractCategoryName',
                filter: function (q, row) {
                    var opts = $(this).combobox('options');
                    return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                }
            });
            tdTaxRateIDObj.combobox({
                editable: true,
                data: data.TaxRateList,
                valueField: 'ID',
                textField: 'TaxRateName',
                filter: function (q, row) {
                    var opts = $(this).combobox('options');
                    return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                },
                onSelect: function (rec) {
                    tdTaxRateValueObj.textbox('setValue', rec.TaxRateValue);
                    calculateTotalSumCost();
                }
            });
        }
    });
}
function saveData() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    $.messager.progress();
    var ContractNumber = tdContractNumberObj.textbox("getValue");
    var DepartmentID = tdDepartmentIDObj.combobox("getValue");
    var ContractCategoryID = tdContractCategoryIDObj.combobox("getValue");
    var TaxRateID = tdTaxRateIDObj.combobox("getValue");
    var ContractName = tdContractNameObj.textbox("getValue");
    var UnitPrice = tdUnitPriceObj.textbox("getValue");
    var TotalCount = tdTotalCountObj.textbox("getValue");
    var AddMan = tdAddManObj.textbox("getValue");
    var AddTime = tdAddTimeObj.datetimebox("getValue");
    $('#ff').form('submit', {
        url: '../Handler/ChequeHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savechequestamp';
            param.ID = ID;
            param.ContractNumber = ContractNumber;
            param.DepartmentID = DepartmentID;
            param.ContractCategoryID = ContractCategoryID;
            param.TaxRateID = TaxRateID;
            param.ContractName = ContractName;
            param.UnitPrice = UnitPrice;
            param.TotalCount = TotalCount;
            param.AddMan = AddMan;
            param.AddTime = AddTime;
        },
        success: function (data) {
            $.messager.progress('close');
            var dataObj = eval("(" + data + ")");
            if (dataObj.status) {
                show_message('保存成功', 'success', function () {
                    closeWin();
                });
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function closeWin() {
    parent.$("#winadd").window("close");
}
function addDepartment() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/EditDepartment.aspx?guid=" + guid + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winsubadd'></div>").appendTo("body").window({
        title: '添加部门',
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
            $("#winsubadd").remove();
            var options = { visit: 'getcomboboxbyguid', type: "department", guid: guid };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.ID > 0) {
                        tdDepartmentIDObj.combobox({
                            editable: true,
                            data: data.DepartmentList,
                            valueField: 'ID',
                            textField: 'DepartmentName',
                            filter: function (q, row) {
                                var opts = $(this).combobox('options');
                                return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                            }
                        });
                        tdDepartmentIDObj.combobox('select', data.ID);
                    }
                }
            });
        }
    });
}
function addContractCategory() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/EditContractCategory.aspx?guid=" + guid + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winsubadd'></div>").appendTo("body").window({
        title: '添加合同分类',
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
            $("#winsubadd").remove();
            var options = { visit: 'getcomboboxbyguid', type: "contract", guid: guid };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.ID > 0) {
                        tdContractCategoryIDObj.combobox({
                            editable: true,
                            data: data.ContractCategoryList,
                            valueField: 'ID',
                            textField: 'ContractCategoryName',
                            filter: function (q, row) {
                                var opts = $(this).combobox('options');
                                return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                            }
                        });
                        tdContractCategoryIDObj.combobox('select', data.ID);
                    }
                }
            });
        }
    });
}
function addTaxRate() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/EditTaxRate.aspx?guid=" + guid + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winsubadd'></div>").appendTo("body").window({
        title: '添加印花税税目税率表',
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
            $("#winsubadd").remove();
            var options = { visit: 'getcomboboxbyguid', type: "taxrate", guid: guid };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.ID > 0) {
                        tdTaxRateIDObj.combobox({
                            editable: true,
                            data: data.TaxRateList,
                            valueField: 'ID',
                            textField: 'TaxRateName',
                            filter: function (q, row) {
                                var opts = $(this).combobox('options');
                                return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                            }
                        });
                        tdTaxRateIDObj.combobox('select', data.ID);
                    }
                }
            });
        }
    });
}
function calculateTotalCost() {
    var UnitPrice = tdUnitPriceObj.textbox("getValue");
    var TotalCount = tdTotalCountObj.textbox("getValue");
    UnitPrice = (Number(UnitPrice) > 0 ? Number(UnitPrice) : 0);
    TotalCount = (Number(TotalCount) > 0 ? Number(TotalCount) : 0);
    var TotalCost = Number(UnitPrice) * Number(TotalCount);
    tdTotalCostObj.textbox('setValue', TotalCost);
    return TotalCost;
}
function calculateTotalTaxCost() {
    var TotalCost = calculateTotalCost();
    var TaxRate = tdTaxRateValueObj.textbox('getValue');
    TaxRate = (Number(TaxRate) > 0 ? Number(TaxRate) : 0);
    var TotalTaxCost = (Number(TotalCost) * Number(TaxRate) / 100).toFixed(2);
    tdTotalTaxCostObj.textbox('setValue', TotalTaxCost);
    return TotalTaxCost;
}
function calculateTotalSumCost() {
    var TotalCost = calculateTotalCost();
    var TotalTaxCost = calculateTotalTaxCost();
    var TotalSumCost = Number(TotalCost) + Number(TotalTaxCost);
    return TotalSumCost;
}