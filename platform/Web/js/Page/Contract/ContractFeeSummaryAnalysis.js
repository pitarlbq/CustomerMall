var tt_CanLoad = false;
function MergeCells(tableID, fldList) {
    var Arr = fldList.split(",");
    var dg = $('#' + tableID);
    var fldName;
    var RowCount = dg.datagrid("getRows").length;
    var span;
    var PerValue = "";
    var CurValue = "";
    var length = Arr.length - 1;
    var list = [];
    for (i = 0; i <= length; i++) {
        fldName = Arr[i];
        PerValue = "";
        span = 1;
        for (row = 0; row <= RowCount; row++) {
            if (row == RowCount) {
                CurValue = "";
            }
            else {
                CurValue = dg.datagrid("getRows")[row]["ContractID"];
            }
            if (PerValue == CurValue) {
                span += 1;
            }
            else {
                var index = row - span;
                list.push({ index: index, fldName: fldName, span: span });
                span = 1;
                PerValue = CurValue;
            }
        }
    }
    if (merge_timeout != null) {
        clearTimeout(merge_timeout);
    }
    do_merge(dg, list, 0);
}
var merge_timeout = null;
function do_merge(dg, list, i) {
    if (i == list.length) {
        return;
    }
    dg.datagrid('mergeCells', {
        index: list[i].index,
        field: list[i].fldName,
        rowspan: list[i].span,
        colspan: null
    });
    merge_timeout = setTimeout(function () {
        do_merge(dg, list, i + 1)
    }, 10);
}
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
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
        showFooter: true,
        onSelect: onCheck,
        onUnselect: onUncheck,
        columns: [[
        { field: 'FullName', title: '资源位置', width: 200 },
        { field: 'RoomName', title: '资源编号', width: 100 },
        { field: 'ContractNo', title: '合同编号', width: 100 },
        { field: 'ContractName', title: '合同名称', width: 100 },
        { field: 'RentName', title: '租户姓名', width: 100 },
        { field: 'Name', title: '收费项目', width: 100 },
        { field: 'CalculateStartTime', formatter: formatTime, title: '计费开始日期', width: 100 },
        { field: 'CalculateEndTime', formatter: formatTime, title: '计费结束日期', width: 100 },
        { field: 'ReadyChargeTime', formatter: formatTime, title: '收费日期', width: 100 },
        { field: 'FormatALLFinalTotalCost', title: '合同应收', width: 80 },
        { field: 'FormatTotalFinalPayCost', title: '已收金额', width: 80 },
        { field: 'FormatTotalFinalCost', title: '未收金额', width: 80 },
        { field: 'ChargeDiscountName', title: '减免方案', width: 80 },
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
        toolbar: '#tt_mm',
        onLoadSuccess: onLoadSuccess
    });
    SearchTT();
}
function onLoadSuccess(data) {
    MergeCells("tt_table", "FullName,RoomName,ContractNo,ContractName,RentName");
    var currentcount = data.currentcount || 0;
    var url = '../Handler/FeeCenterHandler.ashx?currentcount=' + currentcount;
    $("#tt_table").datagrid("options").url = url;
}
var checked_id = 0;
var unchecked_id = 0;
function onCheck(index, data) {
    if (checked_id > 0) {
        return;
    }
    checked_id = data.ID;
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            checked_id = 0;
        }
        if (row.ContractID == data.ContractID) {
            if (!isChecked(row)) {
                var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#tt_table').datagrid('selectRow', rowIndex);
                }
            }
        }
    })
}
function isChecked(row) {
    var allRows = $("#tt_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.ID == allRows[i].ID) {
            return true;
        }
    }
    return false;
}
function onUncheck(index, data) {
    if (unchecked_id > 0) {
        return;
    }
    unchecked_id = data.HistoryID;
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            unchecked_id = 0;
        }
        if (row.ContractID == data.ContractID) {
            if (isChecked(row)) {
                var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#tt_table').datagrid('unselectRow', rowIndex);
                }
            }
        }
    })
}
function formatDecimal(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
function formatRestDays(value, row) {
    if (value == 0) {
        return value;
    }
    if (row.ContractStatus != "tongguo") {
        return value;
    }
    if (ContractWarningOjb == null || ContractWarningOjb == "") {
        return value;
    }
    if (row.ContractStatus == "tongguo") {
        if (Number(ContractWarningOjb) < Number(value)) {
            return value;
        }
        return '<span style="color:red;">' + value + '</span>';
    }
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
    var projectids = []
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
    } catch (e) {

    }
    if (projectids.length == 0 && roomids.length == 0) {
        try {
            roomids = parent.GetSelectedRooms();
            projectids = parent.GetSelectedProjects();
        } catch (e) {

        }
    }
    var url = '../Handler/FeeCenterHandler.ashx?currentcount=0';
    var options = {
        "visit": "loadroomfeelist",
        "RoomID": JSON.stringify(roomids),
        "ProjectID": JSON.stringify(projectids),
        "ShowFooter": true,
        "IsToCharge": true,
        "IsContractFee": true,
        "IsRoomFee": false,
        "IsContractWarning": true,
        "source": 'ContractFeeSummaryAnalysis'
    }
    options.url = url;
    return options;
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
        url: options.url,
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
