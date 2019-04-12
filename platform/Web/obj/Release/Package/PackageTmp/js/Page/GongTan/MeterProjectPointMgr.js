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
        { field: 'FinalFullName', title: '资源编号', width: 300 },
        { field: 'MeterName', title: '仪表名称', width: 100 },
        { field: 'MeterTypeName', title: '仪表类型', width: 100 },
        { field: 'MeterNumber', title: '仪表编号', width: 100 },
        { field: 'MeterStartPoint', title: '上次读数', width: 100 },
        { field: 'MeterEndPoint', title: '本次读数', width: 100 },
        { field: 'WriteDate', formatter: formatTime, title: '抄表日期', width: 100 },
        { field: 'WriteUserName', title: '抄表人', width: 100 },
        { field: 'FinalChargeName', title: '收费项目', width: 100 },
        { field: 'MeterCategoryName', title: '仪表种类', width: 100 },
        { field: 'MeterSpecDesc', title: '仪表规格', width: 100 },
        { field: 'MeterTotalPoint', title: '用量', width: 100 },
        { field: 'MeterCoefficient', title: '倍率', width: 100 },
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
    var rows = parent.$("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return null;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    var keywords = $("#tdKeyword").searchbox("getValue");
    var MeterCategoryID = $('#tdMeterCategoryID').combobox('getValue');
    var MeterType = $('#tdMeterType').combobox('getValue');
    var MeterChargeID = $('#tdChargeName').combobox('getValue');
    tt_CanLoad = true;
    var options = {
        "visit": "loadmeterpointgrid",
        "keywords": keywords,
        "MeterCategoryID": MeterCategoryID,
        "MeterType": MeterType,
        "MeterChargeID": MeterChargeID,
        "IDList": JSON.stringify(IDList)
    };
    return options;
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
