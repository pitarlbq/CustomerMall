var tt_CanLoad = false;
$(function () {
    loadtt();
    var charge_list = [];
    if (hdChargeIDList.val() != '') {
        charge_list = eval('(' + hdChargeIDList.val() + ')');
    }
    $('#tdChargeName').combobox({
        data: charge_list,
        valueField: 'id',
        textField: 'name',
        editable: false
    })
    $(document).click(function (e) {
        var target = $(e.target);
        if (target.closest(".datagrid-btable,.calendar-noborder").length == 0) {
            endTTEditing();
        }
    });
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/ImportFeeHandler.ashx',
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
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        //onDblClickRow: onDblClickTTRow,
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
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'FinalName', title: '资源编号', width: 300 },
        { field: 'MeterName', title: '仪表名称', width: 100 },
        { field: 'FinalFrontStartPoint', editor: { type: 'textbox' }, title: '上次读数', width: 100 },
        { field: 'FinalFrontEndPoint', editor: { type: 'textbox' }, title: '本次读数', width: 100 },
        { field: 'FinalFrontTotalPoint', title: '用量', width: 100 },
        { field: 'WriteStatusDesc', title: '抄表状态', width: 100 },
        { field: 'APPWriteStatusDesc', title: 'APP抄表状态', width: 100 },
        { field: 'FeeStatusDesc', title: '账单状态', width: 100 },
        { field: 'MeterNumber', title: '仪表编号', width: 100 },
        { field: 'MeterCategoryName', title: '仪表种类', width: 100 },
        { field: 'MeterTypeName', title: '仪表类型', width: 100 },
        { field: 'MeterSpecDesc', title: '仪表规格', width: 100 },
        { field: 'MeterCoefficient', title: '倍率', width: 100 },
        //{ field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'WriteDate', formatter: formatTime, title: '上次抄表日期', width: 100 },
        { field: 'WriteUserName', title: '上次抄表人', width: 100 },
        { field: 'MeterHouseNo', title: '缴费户号', width: 100 },
        { field: 'MeterLocation', title: '仪表位置', width: 100 }
        ]],
        toolbar: '#tb',
        rowStyler: function (index, row) {
            if (row.FeeStatus == 1) {
                return 'color:#ff0000;';
            }
        }

    });
    setTimeout(function () {
        SearchTT();
    }, 500)
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
    var roomids = [];
    var projectids = [];
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
    } catch (e) {
    }
    var keywords = $("#tdKeyword").searchbox("getValue");
    var MeterCategoryID = $('#tdMeterCategoryID').combobox('getValue');
    var MeterType = $('#tdMeterType').combobox('getValue');
    //var MeterChargeID = $('#tdChargeName').combobox('getValue');
    var options = {
        "visit": "loadmetergrid",
        "keywords": keywords,
        "MeterCategoryID": MeterCategoryID,
        "MeterType": MeterType,
        "MeterChargeID": 0,
        "RoomIDList": JSON.stringify(roomids),
        "ProjectIDList": JSON.stringify(projectids),
        "IsWritePoint": true
    };
    return options;
}
function check_start_status(type) {//0-开始抄表 1-启动APP抄表
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    var msg = '是否开始抄表?';
    if (type == 1) {
        msg = '是否启动APP抄表?';
    }
    var options = { visit: 'checkwritemeterstatus', IDList: JSON.stringify(IDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                do_start_write(type);
                return;
            }
            if (message.error) {
                top.$.messager.confirm("提示", message.error, function (r) {
                    if (r) {
                        do_start_write(type);
                    }
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function do_start_write(type) {//0-开始抄表 1-启动APP抄表
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    var options = { visit: 'dostartwritemeter', IDList: JSON.stringify(IDList), type: type };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                if (type == 0) {
                    batch_start_write();
                    return;
                }
                show_message('操作成功', 'success');
                $("#tt_table").datagrid("reload");
                return;
            }
            if (message.error) {
                show_message(message.error, 'error');
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function batch_start_write() {
    var rows = $('#tt_table').datagrid('getSelections');
    $.each(rows, function (index, row) {
        var rowIndex = $("#tt_table").datagrid('getRowIndex', row);
        if (row.WriteStatus != 0) {
            $('#tt_table').datagrid('updateRow', {
                index: rowIndex,
                row: {
                    WriteStatus: 0,
                    FeeStatus: 0,
                    WriteStatusDesc: '开始抄表',
                    FeeStatusDesc: '未生成',
                    FinalFrontStartPoint: row.FinalStartPoint,
                    FinalFrontEndPoint: row.FinalEndPoint,
                    FinalFrontTotalPoint: row.FinalTotalPoint
                }
            });
        }
        setTimeout(function () {
            $('#tt_table').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
        }, (index + 1) * 5);
    })
}
function do_finish_write() {
    var rows = $('#tt_table').datagrid('getSelections');
    var is_not_start = false;
    var list = [];
    $.each(rows, function (index, row) {
        if (row.WriteStatus != 0) {
            is_not_start = true;
            return true;
        }
        list.push(row.ID);
        var rowIndex = $("#tt_table").datagrid('getRowIndex', row);
        $('#tt_table').datagrid('endEdit', rowIndex);
    })
    if (is_not_start && list.length == 0) {
        show_message('请选择状态为开始开始抄表的数据，操作取消', 'warning');
        return;
    }
    do_save_writepoint();
}
function do_stop_app_write() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    var options = { visit: 'dostopappwritemeter', IDList: JSON.stringify(IDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message('操作成功', 'success');
                $("#tt_table").datagrid("reload");
                return;
            }
            if (message.error) {
                show_message(message.error, 'error');
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function onDblClickTTRow(index, row) {
    if (row.WriteStatus != 0) {
        show_message('仪表需是开始抄表状态，操作取消', 'warning');
        return;
    }
    if (endTTEditing()) {
        do_start_edit(row, index);
        tt_editIndex = index;
    } else {
        setTimeout(function () {
            $('#tt_table').datagrid('selectRow', tt_editIndex);
        }, 100);
    }
}
var tt_editIndex = undefined;
function endTTEditing() {
    if (tt_editIndex == undefined) {
        return true;
    }
    $('#tt_table').datagrid('endEdit', tt_editIndex);
    do_save_writepoint();
    tt_editIndex = undefined;
    return true;
}
function do_start_edit(row, rowIndex) {
    if (row.WriteStatus != 0) {
        show_message('仪表需是开始抄表状态，操作取消', 'warning');
        return;
    }
    $('#tt_table').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
}
function do_save_writepoint() {
    var rows = $('#tt_table').datagrid("getSelections");
    var list = [];
    var has_total = true;
    $.each(rows, function (index, row) {
        list.push({ ID: row.ID, StartPoint: row.FinalFrontStartPoint, EndPoint: row.FinalFrontEndPoint });
    })
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: { visit: 'savemeterprojectpoint', List: JSON.stringify(list) },
        success: function (data) {
            if (data.status) {
                show_message('操作成功', 'success');
                $("#tt_table").datagrid("reload");
                return;
            }
            if (data.error) {
                show_message(data.error, 'error');
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function do_import() {
    var iframe = "../GongTan/MeterProjectImport.aspx";
    do_open_dialog('导入仪表', iframe);
}
function do_create_fee() {
    var rows = $('#tt_table').datagrid("getSelections");
    var has_total = true;
    var is_public = false;
    $.each(rows, function (index, row) {
        if (row.MeterType == 2) {
            is_public = true;
            return false;
        }
        if (row.FinalFrontTotalPoint <= 0) {
            has_total = false;
            return false;
        }
    })
    if (is_public) {
        show_message('公共表生成账单暂不支持', 'warning');
        return;
    }
    if (!has_total) {
        show_message('用量不能小于0，操作取消', 'warning');
        return;
    }
    var iframe = "../GongTan/MeterProjectFeeCreate.aspx";
    do_open_dialog('账单生成', iframe);
}
function do_export() {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.page = 1;
    options.rows = 1;
    options.canexport = true;
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                window.location.href = data.downloadurl;
                return;
            }
            if (data.error) {
                show_message(data.error, 'error');
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
