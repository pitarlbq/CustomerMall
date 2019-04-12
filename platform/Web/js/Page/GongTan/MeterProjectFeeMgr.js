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
        { field: 'MeterStartPoint', title: '上次读数', width: 100 },
        { field: 'MeterEndPoint', title: '本次读数', width: 100 },
        { field: 'FinalUnitPrice', title: '单价', width: 100 },
        { field: 'MeterTotalPoint', title: '用量', width: 100 },
        { field: 'FinalTotalCost', title: '金额', width: 100 },
        { field: 'FinalStartTime', formatter: formatTime, title: '计费开始日期', width: 100 },
        { field: 'FinalEndTime', formatter: formatTime, title: '计费结束日期', width: 100 },
        { field: 'MeterWriteDate', formatter: formatTime, title: '账单日期', width: 100 },
        { field: 'MeterNumber', title: '仪表编号', width: 100 },
        { field: 'MeterCategoryName', title: '仪表种类', width: 100 },
        { field: 'MeterTypeName', title: '仪表类型', width: 100 },
        { field: 'MeterSpecDesc', title: '仪表规格', width: 100 },
        { field: 'MeterCoefficient', title: '倍率', width: 100 },
        { field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'WriteUserName', title: '抄表人', width: 100 },
        { field: 'MeterHouseNo', title: '缴费户号', width: 100 },
        { field: 'MeterLocation', title: '仪表位置', width: 100 },
        { field: 'ChargeStateDesc', title: '收款状态', width: 100 },
        { field: 'ChargeMan', title: '收款人', width: 100 },
        { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 100 },
        { field: 'PrintNumber', title: '收款单号', width: 100 },
        ]],
        toolbar: '#tb'
    });
    setTimeout(function () {
        SearchTT();
    }, 500)
}
function SearchTT() {
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
    var ChargeState = $('#tdChargeState').combobox('getValue');
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmeterprojectfeegrid",
        "keywords": keywords,
        "MeterCategoryID": MeterCategoryID,
        "MeterType": MeterType,
        "MeterChargeID": MeterChargeID,
        "RoomIDList": JSON.stringify(roomids),
        "ProjectIDList": JSON.stringify(projectids),
        "ChargeState": ChargeState
    });
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var IDList = [];
    var is_charged = false;
    var is_cuishou = false;
    $.each(rows, function (index, row) {
        if (row.IsCharged) {
            is_charged = true;
            return false;
        }
        if (row.ChargeState == 5) {
            is_cuishou = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (is_charged) {
        show_message('选中的单据已收费，操作取消', 'warning');
        return;
    }
    if (is_cuishou) {
        show_message('选中的单据催收中，操作取消', 'warning');
        return;
    }
    top.$.messager.confirm("提示", '确认删除选中的数据?', function (r) {
        if (r) {
            var options = { visit: 'doremovemeterprojectfee', IDList: JSON.stringify(IDList) };
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
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    });
}
function batchEditTime() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var is_charged = false;
    var is_cuishou = false;
    var IDList = [];
    $.each(rows, function (index, row) {
        if (row.IsCharged) {
            is_charged = true;
            return false;
        }
        if (row.ChargeState == 5) {
            is_cuishou = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (is_charged) {
        show_message('选中的单据已收费，操作取消', 'warning');
        return;
    }
    if (is_cuishou) {
        show_message('选中的单据催收中，操作取消', 'warning');
        return;
    }
    if (IDList.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var iframe = "../GongTan/MeterBatchEditTime.aspx";
    do_open_dialog('批处理', iframe);
}
