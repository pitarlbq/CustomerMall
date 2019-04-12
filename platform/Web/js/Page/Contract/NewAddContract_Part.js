var tt_CanLoad = false, finalcolumn = [], canInsert = false, dgId = '', CustomerTypeList = [], CustomerTypeEditor;
$(function () {
    canInsert = canEdit;
    dgId = '#tt_table';
    CustomerTypeList = [{ ID: 1, Name: '收款方' }];
    CustomerTypeEditor = {
        type: 'combobox',
        options: {
            valueField: 'ID',
            textField: 'Name',
            data: CustomerTypeList,
            editable: false,
            onSelect: function (ret) {
                var row = getCurrentRow();
                if (row) {
                    row.CustomerType = ret.ID;
                }
            }
        }
    };
    loadColumns();
});
function loadColumns() {
    finalcolumn = [[
        { field: 'CustomerTypeDesc', formatter: formatCustomerType, editor: CustomerTypeEditor, title: '类型', width: 100 },
        { field: 'CustomerName', editor: 'textbox', title: '名称', width: 100 },
        { field: 'Address', editor: 'textbox', title: '地址', width: 100 },
        { field: 'OfficerName', editor: 'textbox', title: '法定代表人', width: 100 },
        { field: 'ContactName', editor: 'textbox', title: '联系人', width: 100 },
        { field: 'PhoneNumber', editor: 'textbox', title: '联系方式', width: 100 },
        { field: 'ChargeName', formatter: formatChargeName, title: '收费项目', width: 100 },
        //{ field: 'ChargePercent', editor: 'textbox', formatter: formatChargePercent, title: '收费比例(%)', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 100 },
    ]]
    getFieldList();
    loadTT();
}
function loadTT() {
    tt_CanLoad = false;
    //加载
    $(dgId).datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: true,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: finalcolumn,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $(dgId).datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $(dgId).datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        onLoadSuccess: function (data) {
            totalIndex = -1;
            if (data.rows.length) {
                totalIndex = data.rows.length - 1;
                currentSelectIndex = data.rows.length - 1;
            }
        },
        onSelect: function (index, row) {
            endTTEditing();
            currentSelectIndex = index;
        },
        onClickCell: onClickCell,
        toolbar: '#tb'
    });
    SearchTT();
}
function formatCustomerType(value, row) {
    var desc = '';
    $.each(CustomerTypeList, function (index, item) {
        if (item.ID == row.CustomerType) {
            row.CustomerTypeDesc = item.Name;
            desc = item.Name;
            return false;
        }
    })
    if (desc == '') {
        row.CustomerType = 1;
        desc = '收款方';
    }
    if (row['CustomerTypeDesc_Editor']) {
        row['CustomerTypeDesc_Editor'] = false;
        desc = row.CustomerType || '';
    }
    return desc;
}
function formatChargePercent(value, row) {
    if (row['ChargePercent_Editor']) {
        row['ChargePercent_Editor'] = false;
        //if (row.CustomerType == 2) {
        //    $(dgId).datagrid('getEditor', { index: currentSelectIndex, field: 'ChargePercent' }).target.textbox('disable', true);
        //} else {
        //    $(dgId).datagrid('getEditor', { index: currentSelectIndex, field: 'ChargePercent' }).target.textbox('enable', true);
        //}
    }
    if (row.CustomerType == 2) {
        row.ChargePercent = '';
        return '';
    }
    if (parseFloat(value, 10) < 0) {
        return '';
    }
    return value;
}
function getCurrentRow() {
    var rows = $(dgId).datagrid('getRows');
    return rows[currentSelectIndex];
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $(dgId).datagrid("load", options);
}
function getContractID() {
    if (parent.ContractID > 0 && ContractID <= 0) {
        ContractID = parent.ContractID;
    }
}
function get_options() {
    getContractID();
    if (ContractID <= 0) {
        return null;
    }
    var options = {
        visit: "getcontractcustomergrid",
        ContractID: ContractID
    };
    return options;
}
function formatChargeName(value, row) {
    if (row.CustomerType == 1) {
        var result = '';
        if (value) {
            result += value + ' ';
        }
        var rowIndex = $(dgId).datagrid('getRowIndex', row);
        result += '<a href="javascript:doChoooseCharge(' + rowIndex + ')">选择</a>';
        return result;
    }
    return '';
}
function doChoooseCharge(rowIndex) {
    var iframe = "../Contract/ChooseChargeSummary.aspx?source=AddContract_Part&rowIndex=" + rowIndex;
    do_open_dialog('选择收费项目', iframe);
}
function doChoooseChargeDoneContractParty(rowIndex, nameList, idList) {
    endTTEditing();
    var ChargeName = '';
    $.each(nameList, function (index, item) {
        if (index == 0) {
            ChargeName = item;
        }
        else {
            ChargeName += ',' + item;
        }
    })
    $(dgId).datagrid('updateRow', {
        index: rowIndex,
        row: {
            ChargeName: ChargeName,
            ChargeIDs: JSON.stringify(idList)
        }
    });
}
function formatOperation(value, row) {
    if (!canEdit) {
        return '';
    }
    var rowIndex = $(dgId).datagrid('getRowIndex', row);
    return '<a href="javascript:do_remove(' + row.ID + ',' + rowIndex + ')">删除</a>';
}
function do_remove(ID, rowIndex) {
    top.$.messager.confirm('提示', '确认删除?', function (r) {
        if (r) {
            if (ID == 0) {
                $(dgId).datagrid('deleteRow', rowIndex);
                return;
            }
            var IDList = [];
            IDList.push(ID);
            parent.MaskUtil.mask('body', '提交中');
            var options = { visit: 'removecontractcustomer', IDList: JSON.stringify(IDList), canedit: canSaveLog };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    parent.MaskUtil.unmask();
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $(dgId).datagrid('deleteRow', rowIndex);
                        });
                        return;
                    }
                    else if (message.msg) {
                        show_message(message.msg, "warning");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function getPartyNameList() {
    endTTEditing();
    var rows = $(dgId).datagrid('getRows');
    var list = [];
    $.each(rows, function (index, row) {
        if (row.FinalCustomerType == 2) {
            return true;
        }
        var ChargeIDList = [];
        if (row.ChargeIDs) {
            ChargeIDList = eval('(' + row.ChargeIDs + ')');
        }
        $.each(ChargeIDList, function (index2, ChargeID) {
            list.push({ id: ChargeID, name: row.CustomerName });
        })
    })
    return list;
}
function do_save_row() {
    var rows = $(dgId).datagrid('getRows');
    //alert(JSON.stringify(rows));
}
function getContractPartyList() {
    endTTEditing();
    var rows = $(dgId).datagrid('getRows');
    var list = [];
    $.each(rows, function (index, row) {
        if (row.CustomerName && row.CustomerType) {
            var ChargeIDs = row.ChargeIDs || '[]';
            var ChargePercent = row.ChargePercent || 100;
            list.push({ ID: row.ID, CustomerName: row.CustomerName, CustomerType: row.CustomerType, Address: row.Address, OfficerName: row.OfficerName, ContactName: row.ContactName, PhoneNumber: row.PhoneNumber, ChargeIDs: ChargeIDs, ChargePercent: ChargePercent });
        }
    })
    return list;
}