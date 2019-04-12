var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
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
        singleSelect: true,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'DeviceNo', title: '设备编码', width: 100 },
        { field: 'DeviceTypeName', title: '设备类型', width: 100 },
        { field: 'DeviceGroupName', title: '设备分组', width: 100 },
        { field: 'DeviceName', title: '设备名称', width: 100 },
        { field: 'ModelNo', title: '规格型号', width: 100 },
        { field: 'StatusDesc', title: '设备状态', width: 100 },
        { field: 'DeviceLevel', title: '设备等级', width: 100 },
        { field: 'RepairType', title: '维保类型', width: 100 },
        { field: 'Supplier', title: '供应商单位', width: 100 },
        { field: 'SupplierMan', title: '供应商联系人', width: 100 },
        { field: 'SupplierPhone', title: '供应商联系方式', width: 100 },
        { field: 'RepairCompany', title: '维保单位', width: 100 },
        { field: 'RepairRealName', title: '维保责任人', width: 100 },
        { field: 'RepairUserPhone', title: '维保联系方式', width: 100 },
        { field: 'FirstRepairDate', formatter: formatTime, title: '首次维保日期', width: 150 },
        { field: 'RepairCycleDesc', title: '维保周期', width: 100 },
        { field: 'LastRepairDate', formatter: formatTime, title: '上次维保日期', width: 150 },
        { field: 'ThisRepairDate', formatter: formatTime, title: '本次维保日期', width: 150 },
        { field: 'CheckRealName', title: '巡检责任人', width: 100 },
        { field: 'FirstCheckDate', formatter: formatTime, title: '首次巡检日期', width: 150 },
        { field: 'CheckCycleDesc', title: '巡检周期', width: 100 },
        { field: 'LastCheckDate', formatter: formatTime, title: '上次巡检日期', width: 150 },
        { field: 'ThisCheckDate', formatter: formatTime, title: '本次巡检日期', width: 150 },
        ]],
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
}

function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loaddevicegrid",
        "Keywords": $("#tdKeywords").searchbox("getValue")
    });
}
function do_choose() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个设备", "info");
        return;
    }
    top.$.messager.confirm("提示", "确认选择?", function (r) {
        if (r) {
            parent.hdDeviceID = rows[0].ID;
            parent.tdDeviceName.textbox('setValue', rows[0].DeviceName);
            parent.tdDeviceType.textbox('setValue', rows[0].DeviceTypeName);
            parent.tdDeviceGroup.textbox('setValue', rows[0].DeviceGroupName);
            parent.tdModelNo.textbox('setValue', rows[0].ModelNo);
            do_close();
        }
    })
}
function do_close() {
    parent.do_close_dialog();
}
