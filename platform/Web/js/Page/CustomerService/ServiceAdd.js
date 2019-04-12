var tt_CanLoad = false;
var filecount = 0;
$(function () {
    $('#wincomplete').window('close');
    tdHandelFeeObj.textbox({
        onChange: function (newValue, oldValue) {
            calculateTotalFee();
        }
    });
    addFile();
    loadServiceType(true, true, true, true);
    get_accept_user_list(hdDepartmentID.val(), true);
    setTimeout(function () {
        loadtt();
    }, 300);
    if (ID > 0) {
        loadattachs();
    } else {
        tdFullNameObj.textbox({
            readonly: true
        });
        tdProjectNameObj.textbox({
            readonly: true
        });
    }
    checkAccpetMan();
    checkCheckboxStatus(0);
    tdIsSendAPP.bind('click', function () {
        checkAccpetMan();
    });
    tdIsRequireCost.bind('click', function () {
        checkCheckboxStatus(1);
    });
    tdIsRequireProduct.bind('click', function () {
        checkCheckboxStatus(2);
    });
})
function checkAccpetMan() {
    if (tdIsSendAPP.prop('checked')) {
        $('#label_accpetman_combobox').show();
        $('#label_accpetman_textbox').hide();
    }
    else {
        $('#label_accpetman_combobox').hide();
        $('#label_accpetman_textbox').show();
    }
}
function checkCheckboxStatus(id) {
    if (id == 1 || id == 0) {
        if (tdIsRequireCost.prop('checked')) {
            $('#trRequireCost').show();
        }
        else {
            $('#trRequireCost').hide();
        }
    }
    if (id == 2 || id == 0) {
        if (tdIsRequireProduct.prop('checked')) {
            $('#divProductPanel').panel({
                closed: false
            });
        }
        else {
            $('#divProductPanel').panel({
                closed: true
            });
        }
    }
}
function getColumnList() {
    var columnslist;
    columnslist = [[
        { field: 'ck', checkbox: true },
        { field: 'ProductName', title: '物品名称', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'ModelNumber', title: '规格型号', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'Unit', title: '单位', width: 100, editor: { type: 'textbox', options: { disabled: true } } },
        { field: 'UnitPrice', title: '单价', width: 100, editor: { type: 'numberbox', options: { precision: 2 } } },
        { field: 'InTotalCount', title: '数量', width: 100, editor: { type: 'numberbox', options: { precision: 0 } } },
        { field: 'InTotalPrice', title: '金额', width: 100, editor: { type: 'numberbox', options: { disabled: true, precision: 2 } } }
    ]];
    return columnslist;
}
function loadattachs() {
    var options = { visit: 'loadserviceattachs', ID: ID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        data: options,
        success: function (data) {
            var $html = '';
            $("#trExistFiles").html($html);
            if (data.length > 0) {
                $("#trExistFiles").show();
                $html += '<td>已上传附件</td>';
                $html += '<td colspan="3">';
                $.each(data, function (index, item) {
                    $html += '<div><a target="_blank" href="' + item.AttachedFilePath + '"><img style="max-width:100px;" src="' + item.AttachedFilePath + '" /></a> &nbsp;&nbsp;&nbsp;&nbsp;<a href="' + item.AttachedFilePath + '" target="_blank" >下载</a>&nbsp;&nbsp;&nbsp;&nbsp;';
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
            var options = { visit: 'deletefile', ID: AttachID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
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
function calculateTotalFee() {
    var HandelFee = tdHandelFeeObj.textbox("getValue");
    if (HandelFee == "") {
        HandelFee = 0;
    }
    var rows = $('#tt_table').datagrid('getRows');
    var MaterialFee = 0;
    $.each(rows, function (index, row) {
        MaterialFee += (parseFloat(row.InTotalPrice) > 0 ? parseFloat(row.InTotalPrice) : 0);
    })
    var TotalCost = parseFloat(HandelFee) + parseFloat(MaterialFee);
    tdTotalFeeObj.textbox('setValue', TotalCost);
    return TotalCost;
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
        onClickRow: onClickTTRow,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: getColumnList(),
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
        toolbar: '#tt_mm',
        onLoadSuccess: function (data) {
            var originFee = tdTotalFeeObj.textbox('getValue');
            if (originFee == "" || Number(originFee) == 0) {
                calculateTotalFee();
            }
        }
    });
    SearchTT();
}
function formatNumber(value, row) {
    return (parseFloat(value) < 0 ? 0 : value);
}
function SearchTT() {
    tt_CanLoad = true;
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadinproductdetailgrid",
        "ServiceID": ID
    });
}
function addRow() {
    var iframe = "../CangKu/AddInOutProduct.aspx";
    do_open_dialog('选择商品', iframe);
}
function choose_product_done() {
    $.each(SelectedList, function (index, item) {
        $('#tt_table').datagrid('appendRow', item);
    })
}
function removeRow() {
    endEditing();
    var rows = $('#tt_table').datagrid('getSelections');
    var indexlist = [];
    $.each(rows, function (index, row) {
        var rowindex = $('#tt_table').datagrid('getRowIndex', row);
        indexlist.push(rowindex);
    })
    $.each(indexlist, function (index, item) {
        $('#tt_table').datagrid('cancelEdit', item).datagrid('deleteRow', item - index);
    })
}
function pageLoad(RoomID, isNotRoom) {
    ProjectID = RoomID;
    tdFullNameObj.textbox("setValue", "");
    tdAddCustomerNameObj.textbox("setValue", "");
    tdAddCallPhoneObj.textbox("setValue", "");
    tdProjectNameObj.textbox("setValue", "");
    tdServiceNumberObj.textbox("setValue", "");
    hdOrderNumberIDObj.val("");
    var options = { visit: "getroominfo", ProjectID: ProjectID, IsNotRoom: isNotRoom };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        success: function (data) {
            tdFullNameObj.textbox("setValue", data.room.FullName);
            tdProjectNameObj.textbox("setValue", data.ProjectName);
            tdServiceNumberObj.textbox("setValue", data.CustomerNumber);
            hdOrderNumberIDObj.val(data.OrderNumberID);
            if (!isNotRoom) {
                tdFullNameObj.textbox("setValue", data.room.FullName + "-" + data.room.Name);
                tdAddCustomerNameObj.textbox("setValue", data.room.RelationName);
                tdAddCallPhoneObj.textbox("setValue", data.room.RelatePhoneNumber);
                tdServiceAreaObj.combobox("setValue", "个人区域");
            }
            else {
                tdServiceAreaObj.combobox("setValue", "公共区域");
            }
            tdFullNameObj.textbox({
                readonly: true
            });
            tdProjectNameObj.textbox({
                readonly: true
            });
        }
    });
}
function savedata(status) {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    if (tdServiceTypeObj.combobox('getValue') == '') {
        show_message('请选择服务类别', 'info');
        return;
    }
    endEditing();
    var validRowList = [];
    var rows = $('#tt_table').datagrid('getRows');
    if (rows.length > 0) {
        var invalidRowError = '';
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
            show_message(errorlines, 'info');
            return;
        }
        if (validRowList.length == 0) {
            show_message('请先完善物品', 'info');
            return;
        }
    }
    IsRequireCost = 0;
    if (tdIsRequireCost.prop('checked')) {
        IsRequireCost = 1;
    }
    IsRequireProduct = 0;
    if (tdIsRequireProduct.prop('checked')) {
        IsRequireProduct = 1;
    }
    IsSendAPP = 0;
    if (tdIsSendAPP.prop('checked')) {
        IsSendAPP = 1;
    }
    if (status == 100) {
        if (tdAcceptManObj.combobox('getValues') == "") {
            show_message('请选择接单人', 'info');
            return;
        }
    }
    var complete_time = $('#tdCompleteTime').datebox('getValue');
    if (status == 1) {
        if (complete_time == '') {
            $('#wincomplete').window('open');
            return;
        }
        else {
            $('#wincomplete').window('close');
        }
    }
    MaskUtil.mask('body', '提交中');
    $('#ff').form('submit', {
        url: '../Handler/ServiceHandler.ashx',
        onSubmit: function (param) {
            param.visit = 'savecustomerservice';
            param.ProjectID = ProjectID;
            param.ID = ID;
            param.AddMan = AddMan;
            param.ServiceStatus = status;
            param.IsRequireCost = IsRequireCost;
            param.IsRequireProduct = IsRequireProduct;
            param.IsSendAPP = IsSendAPP;
            param.guid = guid;
            param.ProductRows = JSON.stringify(validRowList);
            param.WechatServiceID = WechatServiceID;
            param.CompelteTime = complete_time;
        },
        success: function (data) {
            $('#tdCompleteTime').datebox('setValue', '');
            MaskUtil.unmask();
            var dataObj = eval("(" + data + ")");
            if (dataObj.status) {
                if (dataObj.ID > 0) {
                    ID = dataObj.ID;
                    if (status == 100) {
                        printData(dataObj.ID);
                        return;
                    }
                    show_message('保存成功', 'success', function () {
                        closeWin();
                    });
                    return;
                }
                show_message("任务记录不存在", "info");
                return;
            }
            if (dataObj.error) {
                show_message(dataObj.error, 'warning');
                return;
            }
            show_message("内部异常", "error");
        }
    });
}
function loadServiceType(load_ServiceType, load_AcceptMan, load_TaskType, load_Department) {
    var options = { visit: "getservicetype" };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        success: function (data) {
            if (load_ServiceType) {
                tdServiceTypeObj.combobox({
                    editable: false,
                    data: data.types,
                    valueField: 'ID',
                    textField: 'ServiceTypeName',
                    onSelect: function (rec) {
                        hdServiceTypeNameObj.val(rec.ServiceTypeName);
                    }
                });
                if (data.types.length > 0 && hdServiceTypeNameObj.val() == "") {
                    tdServiceTypeObj.combobox("setValue", data.types[0].ID);
                    hdServiceTypeNameObj.val(data.types[0].ServiceTypeName);
                }
            }
            if (load_TaskType) {
                var tasktype = tdTaskType.combobox('getValue');
                tdTaskType.combobox({
                    editable: false,
                    data: data.tasks,
                    valueField: 'ID',
                    textField: 'Name'
                });
                if (tasktype != '') {
                    tdTaskType.combobox('setValue', tasktype);
                }
            }
            if (load_Department) {
                var departmentid = tdBelongTeamName.combobox('getValue');
                tdBelongTeamName.combobox({
                    editable: false,
                    data: data.departments,
                    valueField: 'ID',
                    textField: 'Name',
                    onSelect: function (ret) {
                        get_accept_user_list(ret.ID, false);
                    }
                });
                if (departmentid != '') {
                    tdBelongTeamName.combobox('setValue', departmentid);
                }
                if (ChosenDepartmentID > 0) {
                    tdBelongTeamName.combobox('setValue', ChosenDepartmentID);
                    get_accept_user_list(ChosenDepartmentID, false);
                }
            }
        }
    });
}
function get_accept_user_list(DepartmentID, is_first_load) {
    var options = { visit: "getacceptuserlistbydepartmentid", DepartmentID: DepartmentID };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        success: function (data) {
            tdAcceptManObj.combobox({
                editable: false,
                data: data.users,
                valueField: 'UserID',
                textField: 'RealName',
                multiple: true,
                onSelect: function (rec) {
                    hdAcceptManObj.val(rec.RealName);
                }
            });
            if (!is_first_load) {
                tdAcceptManObj.combobox('setValues', []);
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
function closeWin() {
    parent.do_close_dialog(function () {
        parent.document.getElementById('SubTabFrame').contentWindow.$("#tt_table").datagrid("reload");
    }, true);
}
var editIndex;
var SelectedList = [];
function onClickTTRow(index, row) {
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
    if (intotalprice > 0) {
        endEditing();
        calculateTotalFee();
    }
}
function sendjpushapp() {
    var options = { visit: "resendjpush", ID: ID };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'html',
        url: '../Handler/ServiceHandler.ashx',
        success: function (data) {
            show_message('推送成功', 'info');
        }
    });
}
function addTask() {
    var iframe = "../SysSeting/EditCustomerServiceTaskCombobox.aspx";
    do_open_dialog('任务标签管理', iframe);
}
function addtask_done() {
    loadServiceType(false, false, true, false);
}
function doprint() {
    savedata(100)
}
function printData(ID) {
    if (ID == 0) {
        return;
    }
    try {
        var LODOP = getLodop();
        if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
            $("#myframe").attr("src", "../CustomerService/ServiceDetailSummary.aspx?ID=" + ID);
            setTimeout(function () {
                LODOP.PRINT_INIT("打印派工单");
                LODOP.SET_PRINT_PAGESIZE(0, 0, 0, "");
                var strHtml = document.getElementsByTagName("iframe")[0].contentWindow.document.documentElement.innerHTML;
                //alert(strHtml);
                LODOP.ADD_PRINT_HTM(0, '5%', "90%", "100%", strHtml);
                LODOP.PREVIEW();
                //LODOP.PRINT();
            }, 1000);
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
}
var ChosenDepartmentID = 0, DepartmentName;
function addDepartment() {
    ChosenDepartmentID = 0;
    var iframe = "../CangKu/DepartmentMgr.aspx?op=choose";
    do_open_dialog('选择部门', iframe);
}
function do_choose_department_done() {
    loadServiceType(false, false, false, true);
}
