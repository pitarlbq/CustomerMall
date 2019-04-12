var tt_CanLoad = false;
var pp_CanLoad = false;
$(function () {
    addFile();
    if (Number(ID) > 0) {
        loadattachs();
    }
    loadComboboxParams();
    setTimeout(function () {
        loadtt();
    }, 100);
    setTimeout(function () {
        loadpp();
    }, 200);
});
function loadComboboxParams() {
    var options = { visit: 'getoutjzeditparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ChequeHandler.ashx',
        data: options,
        success: function (data) {
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
    var ProjectID = tdProjectIDObj.combobox("getValue");
    var StartTime = tdStartTimeObj.datebox("getValue");
    var EndTime = tdEndTimeObj.datebox("getValue");
    var NotifyTime = tdNotifyTimeObj.datebox("getValue");
    var Operator = tdOperatorObj.textbox("getValue");
    var OperationTime = tdOperationTimeObj.datetimebox("getValue");
    var IDCardStatus = tdIDCardStatusObj.textbox("getValue");
    var BelongCompanyName = tdBelongCompanyNameObj.textbox("getValue");
    var DepartmentID = tdDepartmentIDObj.combobox("getValue");
    var PaperNumber = tdPaperNumberObj.textbox("getValue");
    var OutingAddress = tdOutingAddressObj.textbox("getValue");
    var ApproveMan = tdApproveManObj.textbox("getValue");
    var Remark = tdRemarkObj.textbox("getValue");
    var TaxManName = tdTaxManNameObj.textbox("getValue");
    var TaxNumber = tdTaxNumberObj.textbox("getValue");
    var CompanyInChargeMan = tdCompanyInChargeManObj.textbox("getValue");
    var IDCardType = tdIDCardTypeObj.textbox("getValue");
    var IDCardNumber = tdIDCardNumberObj.textbox("getValue");
    var ProduceAddress = tdProduceAddressObj.textbox("getValue");
    var CompanyRegiserType = tdCompanyRegiserTypeObj.textbox("getValue");
    var BusinessType = tdBusinessTypeObj.textbox("getValue");
    var InChargeMan = tdInChargeManObj.textbox("getValue");
    var OperationComment = tdOperationCommentObj.textbox("getValue");
    $('#ff').form('submit', {
        url: '../Handler/ChequeHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savechequeoutjz';
            param.ID = ID;
            param.ProjectID = ProjectID;
            param.StartTime = StartTime;
            param.EndTime = EndTime;
            param.NotifyTime = NotifyTime;
            param.Operator = Operator;
            param.OperationTime = OperationTime;
            param.IDCardStatus = IDCardStatus;
            param.BelongCompanyName = BelongCompanyName;
            param.DepartmentID = DepartmentID;
            param.PaperNumber = PaperNumber;
            param.OutingAddress = OutingAddress;
            param.ApproveMan = ApproveMan;
            param.Remark = Remark;
            param.TaxManName = TaxManName;
            param.TaxNumber = TaxNumber;
            param.CompanyInChargeMan = CompanyInChargeMan;
            param.IDCardType = IDCardType;
            param.IDCardNumber = IDCardNumber;
            param.ProduceAddress = ProduceAddress;
            param.CompanyRegiserType = CompanyRegiserType;
            param.BusinessType = BusinessType;
            param.InChargeMan = InChargeMan;
            param.OperationComment = OperationComment;
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
function loadattachs() {
    var options = { visit: 'loadoutjzfiles', ID: ID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ChequeHandler.ashx',
        data: options,
        success: function (data) {
            var $html = '';
            $("#trExistFiles").html($html);
            if (data && data.length > 0) {
                $("#trExistFiles").show();
                $html += '<td>已上传附件</td>';
                $html += '<td colspan="3">';
                $.each(data, function (index, item) {
                    $html += '<div>' + item.FileOriName + ' &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.FilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
                    $html += '<a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a></div>';
                })
                $html += '</td>';
            }
            $("#trExistFiles").append($html);
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
function deleteAttach(AttachID) {
    top.$.messager.confirm("提示", "是否删除选已上传的文件?", function (r) {
        if (r) {
            var options = { visit: 'removeoutjzfile', ID: AttachID };
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
function loadtt() {
    tt_CanLoad = false;
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
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
         { field: 'ServiceName', title: '应税劳务名称', width: 200 },
         { field: 'ServiceAddress', title: '劳务地点', width: 100 },
         { field: 'ServiceStartTime', formatter: formatValidTime, title: '有效期限', width: 300 },
         { field: 'ContractMoney', formatter: formatContractMoney, title: '合同金额(元)', width: 100 },
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
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadoutingservicegrid",
        "OutingID": ID,
        "guid": guid
    });
}
function formatValidTime(value, row) {
    var starttime = formatTime(row.ServiceStartTime, row);
    var endtime = formatTime(row.ServiceEndTime, row);
    return starttime + "至" + endtime;
}
function formatContractMoney(value, row) {
    return (Number(value) > 0 ? value : "");
}
function addTTRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/AddOutingService.aspx?guid=" + guid + "&OutingID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '添加应税劳务',
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
function editTTRow() {
    var row = $('#tt_table').datagrid('getSelected');
    if (row == null) {
        show_message("请选择一个应税劳务", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/AddOutingService.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '修改应税劳务',
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
function removeTTRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请至少选择一项进行此操作", "info");
        return;
    }
    var idlist = [];
    $.each(rows, function (index, row) {
        idlist.push(row.ID);
    })
    top.$.messager.confirm('info', '确认删除?', function (r) {
        if (r) {
            var options = { visit: 'removechequeoutingservice', IDList: JSON.stringify(idlist) };
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
function loadpp() {
    pp_CanLoad = false;
    $('#pp_table').datagrid({
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
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
         { field: 'ProductName', title: '货物名称', width: 200 },
         { field: 'TotalCount', title: '数量', width: 100 },
         { field: 'SellerAddress', title: '销售地点', width: 100 },
         { field: 'ProductStartTime', formatter: formatPPValidTime, title: '有效期限', width: 300 },
         { field: 'ProductTotalCost', formatter: formatProductTotalCost, title: '货物总值(元)', width: 100 },
        ]],
        onBeforeLoad: function (data) {
            if (!pp_CanLoad) {
                $('#pp_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return pp_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#pp_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        toolbar: '#pp_mm'
    });
    SearchPP();
}
function SearchPP() {
    pp_CanLoad = true;
    $("#pp_table").datagrid("load", {
        "visit": "loadoutingproductgrid",
        "OutingID": ID,
        "guid": guid
    });
}
function formatPPValidTime(value, row) {
    var starttime = formatTime(row.ProductStartTime, row);
    var endtime = formatTime(row.ProductEndTime, row);
    return starttime + "至" + endtime;
}
function formatProductTotalCost(value, row) {
    return (Number(value) > 0 ? value : "");
}
function addPPRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/AddOutingProduct.aspx?guid=" + guid + "&OutingID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '添加货物',
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
            $("#pp_table").datagrid('reload');
        }
    });
}
function editPPRow() {
    var row = $('#pp_table').datagrid('getSelected');
    if (row == null) {
        show_message("请选择一个货物", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/AddOutingProduct.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winaddproduct'></div>").appendTo("body").window({
        title: '修改货物',
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
            $("#pp_table").datagrid('reload');
        }
    });
}
function removePPRow() {
    var rows = $('#pp_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请至少选择一项进行此操作", "info");
        return;
    }
    var idlist = [];
    $.each(rows, function (index, row) {
        idlist.push(row.ID);
    })
    top.$.messager.confirm('info', '确认删除?', function (r) {
        if (r) {
            var options = { visit: 'removechequeoutingproduct', IDList: JSON.stringify(idlist) };
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
                            $("#pp_table").datagrid('reload');
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