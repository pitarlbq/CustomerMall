var tt_CanLoad = false;
$(function () {
    loadComboboxParams();
    loadTT();
});
function loadComboboxParams() {
    var options = { visit: "getdevicemgrparams" };
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/DeviceHandler.ashx',
        success: function (data) {
            tdDeviceGroup.combobox({
                editable: false,
                data: data.devicegroup,
                valueField: 'ID',
                textField: 'Name'
            });
        }
    })
}
function loadTT() {
    var options = { visit: 'loadtablecolumn', pagecode: 'devicemgr' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                tt_CanLoad = false;
                $('#tt_table').datagrid({
                    url: '../Handler/DeviceHandler.ashx',
                    loadMsg: '正在加载',
                    border: false,
                    remoteSort: false,
                    pagination: true,
                    rownumbers: true,
                    fit: true,
                    fitColumns: false,
                    singleSelect: false,
                    selectOnCheck: true,
                    checkOnSelect: true,
                    striped: true,
                    columns: finalcolumn,
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
                    toolbar: '#tb'
                });
                SearchTT();
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}

function SearchTT() {
    var ProjectIDList = [];
    try {
        ProjectIDList = getSelectedProjectIDs();
    } catch (e) {

    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loaddevicegrid",
        "Keywords": tdKeywords.searchbox("getValue"),
        "DeviceGroupID": tdDeviceGroup.combobox("getValue"),
        "ProjectIDList": JSON.stringify(ProjectIDList)
    });
}
function get_options() {
    var ProjectIDList = [];
    try {
        ProjectIDList = getSelectedProjectIDs();
    } catch (e) {

    }
    var options = {
        "visit": "loaddevicegrid",
        "Keywords": tdKeywords.searchbox("getValue"),
        "DeviceGroupID": tdDeviceGroup.combobox("getValue"),
        "ProjectIDList": JSON.stringify(ProjectIDList)
    };
    return options;
}
function addRow() {
    var iframe = "../Device/EditDevice.aspx";
    do_open_dialog('新增设备', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个设备", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个设备", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Device/EditDevice.aspx?ID=" + ID;
    do_open_dialog('修改设备', iframe);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个设备", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的设备", function (r) {
        if (r) {
            var options = { visit: 'removedevice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
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
function openImport() {
    var iframe = "../Device/ImportDevice.aspx";
    do_open_dialog('导入', iframe);
}
function doMore() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个设备", "info");
        return;
    }
    var iframe = "../Device/BatchEdit.aspx";
    do_open_dialog('修改设备', iframe);
}
function doImport() {
    var iframe = "../Device/ImportDevice.aspx";
    do_open_dialog('导入设备', iframe);
}
//列设置
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=devicemgr";
    do_open_dialog('设备列表设置', iframe);
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
        url: '../Handler/DeviceHandler.ashx',
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