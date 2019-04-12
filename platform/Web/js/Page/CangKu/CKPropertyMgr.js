var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadTT();
    }, 500);
});
function loadTT() {
    tt_CanLoad = false;
    var options = { visit: 'loadtablecolumn', pagecode: 'propertymgr' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                //加载
                $('#tt_table').datagrid({
                    url: '../Handler/CKHandler.ashx',
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
                    onDblClickRow: onDblClickRowTT,
                    striped: true,
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
                    columns: finalcolumn,
                    toolbar: '#tt_mm'
                });
                SearchTT();
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var TreeIDList = [];
    try {
        TreeIDList = GetSelectedID();
    } catch (e) {
    }
    var options = {
        "visit": "loadckpropertygrid",
        "TreeIDList": JSON.stringify(TreeIDList),
        "keywords": tdKeyword.searchbox('getValue'),
        "StartTime": tdStartTime.datebox('getValue'),
        "EndTime": tdEndTime.datebox('getValue')
    };
    return options;
}
function formatDecimal(value, row) {
    if (parseFloat(value) > 0) {
        return value;
    }
    return 0;
}
function formatPropertyRemark(value, row) {
    if (value && value.length > 10) {
        return value.substring(0, 10) + "...";
    }
    return value;
}
function onDblClickRowTT(index, row) {
    editByRow(row.ID)
}
function addRow() {
    var iframe = "../CangKu/EditProperty.aspx";
    do_open_dialog('新增资产', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个资产进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    editByRow(rows[0].ID);
}
function editByRow(ID) {
    var iframe = "../CangKu/EditProperty.aspx?ID=" + ID;
    do_open_dialog('修改资产', iframe);
}
function removeRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个资产进行此操作", "warning");
        return;
    }
    var IDList = [];
    var isBalance = false;
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的资产", function (r) {
        if (r) {
            var options = { visit: 'removeckproperty', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
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
function openImport() {
    var iframe = "../CangKu/ImportProperty.aspx";
    do_open_dialog('导入资产信息', iframe);
}
function doChange() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个资产进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    var iframe = "../CangKu/EditProperty.aspx?ID=" + rows[0].ID + "&op=change";
    do_open_dialog('变更资产', iframe);
}
function viewData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个资产进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    var iframe = "../CangKu/EditPropertyMgr.aspx?ID=" + rows[0].ID + "&op=change";
    do_open_dialog('查看资产', iframe);
}
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=propertymgr";
    do_open_dialog('资产列表设置', iframe);
}
function do_export() {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.canexport = true;
    options.page = 1;
    options.rows = 10;
    MaskUtil.mask('body', '导出中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CKHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.downloadurl) {
                window.location.href = data.downloadurl;
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统异常', 'error');
        }
    });
}
