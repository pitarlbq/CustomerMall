var tt_CanLoad = false;
var ProductList;
var CommboxDepartment, CommboxProject, CommboxSeller;
var sellerlist = [];
var productlist = [];
var departmentlist = [];
var projectlist = [];
var buyerlist = [];
var filecount = 0;

$(function () {
    addFile();
    if (Number(OutSummaryID) <= 0) {
        sellerlist = parent.GetSelectSeller();
        productlist = parent.GetSelectProduct();
        departmentlist = parent.GetSelectDepartment();
        projectlist = parent.GetSelectProject();
        buyerlist = parent.GetSelectBuyer();
        if (sellerlist.length > 0) {
            loadComboboxParams();
        }
        else {
            getlatestsummary();
        }
    }
    else {
        loadComboboxParams();
        loadattachs();
    }
    if (productlist.length > 0) {
        setTimeout(function () {
            addProductList();
        }, 100);
    }
    else {
        setTimeout(function () {
            loadtt();
        }, 100);
    }
    setTimeout(function () {
        getInCostInfo();
    }, 300);
});
function getInCostInfo() {
    var options = { visit: 'getinsummarycost' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ChequeHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                $("#tdTotalInCost").text(data.TotalInCost.toFixed(2));
                $("#tdConfirmCost").text(data.ConfirmCost.toFixed(2));
                $("#tdNoConfirmCost").text(data.NoConfirmCost.toFixed(2));
            }
            else {
                $("#tdTotalInCost").text(0);
                $("#tdConfirmCost").text(0);
                $("#tdNoConfirmCost").text(0);
            }
        }
    });
}
function addFile() {
    $("#tdFile").find("a.fileadd").hide();
    $("#tdFile").find("a.fileremove").show();
    filecount++;
    var $html = "<div id=\"tdFile_" + filecount + "\">";
    $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%\" />";
    $html += "<a href=\"javascript:void(0)\" onclick=\"addFile()\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
    $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile(" + filecount + ")\" class=\"easyui-linkbutton btnlinkbar fileremove\" style=\"display:none;\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
    $html += "</div>";
    $("#tdFile").append($html);
    $.parser.parse("#tdFile_" + filecount);
}
function deleteFile(id) {
    $("#tdFile_" + id).html("");
}
function loadattachs() {
    var options = { visit: 'loadoutsummaryfiles', ID: InSummaryID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ChequeHandler.ashx',
        data: options,
        success: function (data) {
            var $html = '';
            $("#trExistFiles").html($html);
            if (data.length > 0) {
                $("#trExistFiles").show();
                $html += '<td>已上传图片</td>';
                $html += '<td colspan="3">';
                $.each(data, function (index, item) {
                    $html += '<img src="' + item.FilePath + '" style="width:60px;" /> &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.FilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                    $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                })
                $html += '</td>';
            }
            $("#trExistFiles").append($html);
        }
    });
}
function deleteAttach(AttachID) {
    top.$.messager.confirm("提示", "是否删除选已上传的文件?", function (r) {
        if (r) {
            var options = { visit: 'removeoutsummaryfile', ID: AttachID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            loadattachs();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function getlatestsummary() {
    var options = { visit: 'getlatestcheckoutsummary' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ChequeHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                var sellerid = data.summary.SellerID;
                sellerlist.push(sellerid);
            }
            loadComboboxParams();
        }
    });
}
function addProductList() {
    var options = { visit: 'addtempoutproductlist', list: JSON.stringify(productlist), guid: guid };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ChequeHandler.ashx',
        data: options,
        success: function (data) {
            setTimeout(function () {
                loadtt();
            }, 100);
        }
    })
}
function loadComboboxParams() {
    var options = { visit: 'getoutdetailparams' };
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
            if (departmentlist.length > 0) {
                tdDepartmentIDObj.combobox('setValue', departmentlist[0]);
            }
            tdProjectIDObj.combobox({
                editable: true,
                data: data.ProjectList,
                valueField: 'ID',
                textField: 'ProjectName',
                filter: function (q, row) {
                    var opts = $(this).combobox('options');
                    return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                }
            });
            if (projectlist.length > 0) {
                tdProjectIDObj.combobox('setValue', projectlist[0]);
            }
            tdSellerIDObj.combobox({
                editable: true,
                data: data.SellerList,
                valueField: 'ID',
                textField: 'SellerName',
                filter: function (q, row) {
                    var opts = $(this).combobox('options');
                    return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                },
                onSelect: function (rec) {
                    tdSellerTaxNumberObj.textbox('setValue', rec.SellerTaxNumber);
                    tdSellerAddressPhoneObj.textbox('setValue', rec.SellerAddressPhone);
                    tdSellerBankAccountObj.textbox('setValue', rec.SellerBankAccount);
                }
            });
            if (sellerlist.length > 0) {
                tdSellerIDObj.combobox('select', sellerlist[0]);
            }
            tdBuyerIDObj.combobox({
                editable: true,
                data: data.BuyerList,
                valueField: 'ID',
                textField: 'BuyerName',
                filter: function (q, row) {
                    var opts = $(this).combobox('options');
                    return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                },
                onSelect: function (rec) {
                    tdBuyerTaxNumberObj.textbox('setValue', rec.BuyerTaxNumber);
                    tdBuyerAddressPhoneObj.textbox('setValue', rec.BuyerAddressPhone);
                    tdBuyerBankAccountObj.textbox('setValue', rec.BuyerBankAccount);
                }
            });
            if (buyerlist.length > 0) {
                tdBuyerIDObj.combobox('select', buyerlist[0]);
            }
        }
    });
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/ChequeHandler.ashx',
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
        showFooter: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
         { field: 'ProductName', title: '货物或应税劳务名称', width: 200 },
         { field: 'ModelNumber', title: '规格型号', width: 200 },
         { field: 'Unit', title: '单位', width: 100 },
         { field: 'TotalCount', formatter: formatTotalSummary, title: '数量', width: 100 },
         { field: 'UnitPrice', formatter: formatTotalSummary, title: '单价', width: 100 },
         { field: 'TotalCost', formatter: formatNumber, title: '金额', width: 100 },
         { field: 'TaxRate', title: '税率', width: 100 },
         { field: 'TotalTaxCost', formatter: formatNumber, title: '税额', width: 100 }
        ]],
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
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function formatNumber(value, row) {
    if (row.ProductName == "税价合计(大写)") {
        return "";
    }
    return (parseFloat(value) > 0 ? value : "");
}
function formatTotalSummary(value, row) {
    if (row.ProductName == "税价合计(大写)") {
        return "";
    }
    return (parseFloat(value) > 0 ? value : "");
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadoutproductdetailgrid",
        "OutSummaryID": OutSummaryID,
        "guid": guid
    });
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? Number(value) : "");
}
function addRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/AddOutProduct.aspx?guid=" + guid + "&OutSummaryID=" + OutSummaryID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '添加商品',
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
            $("#tt_table").datagrid('reload');
        }
    });
}
function editRow() {
    var row = $('#tt_table').datagrid('getSelected');
    if (row == null) {
        show_message("请选择一个商品", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/AddOutProduct.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '修改商品',
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
            $("#tt_table").datagrid('reload');
        }
    });
}
function removeRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请至少选择一个进项进行此操作", "info");
        return;
    }
    var idlist = [];
    $.each(rows, function (index, row) {
        idlist.push(row.ID);
    })
    top.$.messager.confirm('info', '确认删除?', function (r) {
        if (r) {
            var options = { visit: 'removechequeoutdetail', IDList: JSON.stringify(idlist) };
            top.$.messager.progress();
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (message) {
                    top.$.messager.progress('close');
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid('reload');
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}
function saveRows() {
    var isValid = ffOjb.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var WriteDate = tdWriteDateObj.datetimebox("getValue");
    var WriteMan = tdWriteManObj.textbox("getValue");
    var DepartmentID = tdDepartmentIDObj.combobox("getValue");
    var ProjectID = tdProjectIDObj.combobox("getValue");
    var SellerID = tdSellerIDObj.combobox("getValue");
    var BuyerID = tdBuyerIDObj.combobox("getValue");
    var ChequeNumber = tdChequeNumberObj.textbox("getValue");
    var ChequeTime = tdChequeTimeObj.datebox("getValue");
    var ChequeCode = tdChequeCodeObj.textbox("getValue");
    var ChequeCategory = tdChequeCategoryObj.textbox("getValue");
    $.messager.progress();
    $('#ff').form('submit', {
        url: '../Handler/ChequeHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savechequeout';
            param.OutSummaryID = OutSummaryID;
            param.WriteDate = WriteDate;
            param.WriteMan = WriteMan;
            param.DepartmentID = DepartmentID;
            param.ProjectID = ProjectID;
            param.SellerID = SellerID;
            param.BuyerID = BuyerID;
            param.ChequeNumber = ChequeNumber;
            param.ChequeTime = ChequeTime;
            param.ChequeCode = ChequeCode;
            param.ChequeCategory = ChequeCategory;
            param.guid = guid;
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
function addProject() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/EditProject.aspx?guid=" + guid + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winsubadd'></div>").appendTo("body").window({
        title: '添加项目',
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
            var options = { visit: 'getcomboboxbyguid', type: "project", guid: guid };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.ID > 0) {
                        tdProjectIDObj.combobox({
                            editable: true,
                            data: data.ProjectList,
                            valueField: 'ID',
                            textField: 'ProjectName',
                            filter: function (q, row) {
                                var opts = $(this).combobox('options');
                                return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                            }
                        });
                        tdProjectIDObj.combobox('select', data.ID);
                    }
                }
            });
        }
    });
}
function addSeller() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/EditSeller.aspx?guid=" + guid + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winsubadd'></div>").appendTo("body").window({
        title: '添加销售单位',
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
            var options = { visit: 'getcomboboxbyguid', type: "seller", guid: guid };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.ID > 0) {
                        tdSellerIDObj.combobox({
                            editable: true,
                            data: data.SellerList,
                            valueField: 'ID',
                            textField: 'SellerName',
                            filter: function (q, row) {
                                var opts = $(this).combobox('options');
                                return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                            },
                            onSelect: function (rec) {
                                tdSellerTaxNumberObj.textbox('setValue', rec.SellerTaxNumber);
                                tdSellerAddressPhoneObj.textbox('setValue', rec.SellerAddressPhone);
                                tdSellerBankAccountObj.textbox('setValue', rec.SellerBankAccount);
                            }
                        });
                        tdSellerIDObj.combobox('select', data.ID);
                    }
                }
            });
        }
    });
}
function addBuyer() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/EditBuyer.aspx?guid=" + guid + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winsubadd'></div>").appendTo("body").window({
        title: '添加购货单位',
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
            var options = { visit: 'getcomboboxbyguid', type: "buyer", guid: guid };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.ID > 0) {
                        tdBuyerIDObj.combobox({
                            editable: true,
                            data: data.BuyerList,
                            valueField: 'ID',
                            textField: 'BuyerName',
                            filter: function (q, row) {
                                var opts = $(this).combobox('options');
                                return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                            },
                            onSelect: function (rec) {
                                tdBuyerTaxNumberObj.textbox('setValue', rec.BuyerTaxNumber);
                                tdBuyerAddressPhoneObj.textbox('setValue', rec.BuyerAddressPhone);
                                tdBuyerBankAccountObj.textbox('setValue', rec.BuyerBankAccount);
                            }
                        });
                        tdBuyerIDObj.combobox('select', data.ID);
                    }
                }
            });
        }
    });
}