var tt_CanLoad = false;
$(function () {
    loadTT()
})
function loadTT() {
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/SysSettingHandler.ashx',
        loadMsg: '正在加载',
        border: false,
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
        columns: [[
            { field: 'ck', checkbox: true },
            { field: 'BiaoCategory', title: '表种类', width: 100, editor: { type: 'textbox' } }
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
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadchargebiaogrid"
    });
}
var editIndex;
function onClickTTRow(index, row) {
    if (editIndex != index) {
        if (endEditing()) {
            $('#tt_table').datagrid('selectRow', index).datagrid('beginEdit', index);
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
function addRow() {
    if (endEditing()) {
        rowdefine = { ID: 0, BiaoCategory: '' };
        $('#tt_table').datagrid('appendRow', rowdefine);
        editIndex = $('#tt_table').datagrid('getRows').length - 1;
        $('#tt_table').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
    }
}
function removeRowLine() {
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
function chooseRows() {
    var rows = $("#tt_table").datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请至少选择一个表种类", "info");
        return;
    }
    var issave = true;
    $.each(rows, function (index, row) {
        if (row.ID == 0) {
            issave = false;
            return false;
        }
    })
    if (!issave) {
        show_message("请先保存选中的表种类", "info");
        return;
    }
    top.$.messager.confirm('提示', '确认选择该表种类?', function (r) {
        if (r) {
            var IDs = '', BiaoCategorys = '', BiaoNames = '';
            $.each(rows, function (index, row) {
                if (index == 0) {
                    IDs += row.ID;
                    BiaoCategorys += row.BiaoCategory;
                    BiaoNames += row.BiaoName;
                }
                else {
                    IDs += ',' + row.ID;
                    BiaoCategorys += ',' + row.BiaoCategory;
                    BiaoNames += ',' + row.BiaoName;
                }
            })
            parent.pChargeBiaoIDs = IDs;
            parent.pBiaoCategoryNames = BiaoCategorys;
            parent.pBiaoNames = BiaoNames;
            parent.$("#winbiao").window('close');
        }
    })
}
function saveRows() {
    endEditing();
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('您尚未添加表种类', 'info');
        return;
    }
    var invalidRowError = '';
    var countRowError = '';
    var validRowList = [];
    $.each(rows, function (index, row) {
        if (row.BiaoCategory == '') {
            invalidRowError += (index + 1) + ',';
        }
        else {
            validRowList.push(row);
        }
    })
    if (invalidRowError != '') {
        var errorlines = "第" + invalidRowError.substring(0, invalidRowError.length - 1) + "行数据不完善";
        show_message(errorlines, 'info');
        return;
    }
    var options = { visit: 'savechargebiao', BiaoRows: JSON.stringify(validRowList) };
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/SysSettingHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                show_message('保存成功', 'success', function () {
                    $("#tt_table").datagrid('reload');;
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
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一行进行此操作", "info");
        return;
    }
    var IDList = [];
    var deleteserver = false;
    $.each(rows, function (index, row) {
        if (row.ID > 0) {
            deleteserver = true;
        }
        IDList.push(row.ID);
    })
    if (!deleteserver) {
        removeRowLine();
        return;
    }
    top.$.messager.confirm("提示", "确认删除?", function (r) {
        if (r) {
            var options = { visit: 'deletechargebiao', ids: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        removeRowLine();
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
