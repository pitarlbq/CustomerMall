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
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
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
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'FinalName', title: '资源编号', width: 300 },
        { field: 'MeterName', title: '仪表名称', width: 100 },
        { field: 'MeterNumber', title: '仪表编号', width: 100 },
        { field: 'MeterCategoryName', title: '仪表种类', width: 100 },
        { field: 'MeterTypeName', title: '仪表类型', width: 100 },
        { field: 'MeterSpecDesc', title: '仪表规格', width: 100 },
        { field: 'MeterCoefficient', title: '倍率', width: 100 },
        //{ field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'MeterHouseNo', title: '缴费户号', width: 100 },
        { field: 'MeterLocation', title: '仪表位置', width: 100 }
        ]],
        toolbar: '#tb'
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
    var MeterChargeID = $('#tdChargeName').combobox('getValue');
    var options = {
        "visit": "loadmetergrid",
        "keywords": keywords,
        "MeterCategoryID": MeterCategoryID,
        "MeterType": MeterType,
        "MeterChargeID": MeterChargeID,
        "RoomIDList": JSON.stringify(roomids),
        "ProjectIDList": JSON.stringify(projectids),
        "IsWritePoint": false
    };
    return options;
}
function do_add(type) {
    var name = '';
    if (type == 1) {
        var iframe = "../GongTan/MeterEditPersional.aspx";
        do_open_dialog('新增住户仪表', iframe);
    } else {
        var iframe = "../GongTan/MeterEditPublic.aspx";
        do_open_dialog('新增公共仪表', iframe, true);
    }
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的数据?", function (r) {
        if (r) {
            var options = { visit: 'deletemeterdata', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
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
function do_import() {
    var iframe = "../GongTan/MeterImport.aspx";
    do_open_dialog('导入仪表', iframe, true);
}
function do_edit() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择数据", "info");
        return;
    }
    var iframe = "../GongTan/MeterEdit.aspx?ID=" + rows[0].ID;
    do_open_dialog('修改仪表', iframe, true);
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
                show_message(data.error, "info");
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function do_view_history() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../GongTan/MeterProjectPointMgr.aspx";
    do_open_dialog('抄表记录', iframe);
}
