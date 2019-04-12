var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
    $(document).click(function (e) {
        var target = $(e.target);
        if (target.closest(".datagrid-btable,.calendar-noborder").length == 0) {
            //alert(target.closest(".calendar-noborder").length);
            endTTEditing();
        }
    });
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CommHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: false,
        onCheck: onSelectPre,
        onUncheck: onUnSelectPre,
        onClickRow: onClickTTRow,
        onDblClickRow: onDblClickRowTT,
        striped: true,
        showFooter: true,
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
        { field: 'OrderNumber', title: '单号', width: 150 },
        { field: 'CarrierChargeStatusDesc', title: '结算状态', width: 60 },
        { field: 'CarrierName', title: '搬运工', width: 100 },
        { field: 'CarrierMoveCost', formatter: formatMoveCost, title: '搬运费结算金额', width: 100 },
        { field: 'RemoveCost', formatter: formatRemoveCost, title: '扣款', editor: { type: 'numberbox', options: { precision: 2 } }, width: 100 },
        { field: 'CarrierBalanceCost', formatter: formatCarrierBalanceCost, title: '结算金额', editor: { type: 'numberbox', options: { precision: 2 } }, width: 100 },
        { field: 'CarrierBalanceTime', formatter: formatTime, title: '结算日期', editor: { type: 'datetimebox' }, width: 100 },
        { field: 'ContactName', title: '商户', width: 100 },
        { field: 'InventoryName', title: '库位', width: 60 },
        { field: 'ProductName', title: '货品', width: 100 },
        { field: 'SpecName', title: '规格', width: 150 },
        { field: 'TotalCount', title: '数量', formatter: formatCount, width: 60 },
        { field: 'StartTime', formatter: formatStartTime, title: '入库日期', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    var Businessidarry = parent.GetSelectedByType("Business");
    var Productidarry = parent.GetSelectedByType("Product");
    var SpecInfoidarry = parent.GetSelectedByType("SpecInfo");
    var InventoryInfoidarry = parent.GetSelectedByType("InventoryInfo");
    var Carriergroupidarry = parent.GetSelectedTitleByType("CarrierGroup", 5);
    var Carrieridarry = parent.GetSelectedByType("Carrier");
    var BusinessID = Businessidarry.length > 0 ? Businessidarry[0] : 0;
    var ProductID = Productidarry.length > 0 ? Productidarry[0] : 0;
    var SpecInfoID = SpecInfoidarry.length > 0 ? SpecInfoidarry[0] : 0;
    var InventoryInfoID = InventoryInfoidarry.length > 0 ? InventoryInfoidarry[0] : 0;
    var CarrierGroupID = Carriergroupidarry.length > 0 ? Carriergroupidarry[0] : 0;
    var CarrierID = Carrieridarry.length > 0 ? Carrieridarry[0] : 0;
    var CarrierChargeStatus = $("#tdCarrierChargeStatus").combobox("getValue");
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    //if (BusinessID == 0 && ProductID == 0 && InventoryInfoID == 0 && CarrierGroupID == 0 && CarrierID == 0) {
    //    tt_CanLoad = false;
    //    $('#tt_table').datagrid("loadData", {
    //        total: 0,
    //        rows: []
    //    });
    //    return;
    //}
    $("#tt_table").datagrid("load", {
        "visit": "loadinoutsource",
        "BusinessChargeStatus": -1,
        "CarrierChargeStatus": CarrierChargeStatus,
        "InOutType": -1,
        "BusinessID": BusinessID,
        "ProductID": ProductID,
        "SpecInfoID": SpecInfoID,
        "InventoryInfoID": InventoryInfoID,
        "CarrierGroupID": CarrierGroupID,
        "CarrierID": CarrierID,
        "CarrierBalanceStartTime": StartTime,
        "CarrierBalanceEndTime": EndTime,
        "SortOrder": "order by [StartTime] desc,[ID] desc"
    });
}
function formatStartTime(value, row) {
    if (row.InOutType == 2) {
        return "--";
    }
    return formatTime(value, row)
}
function formatCount(value, row) {
    if (Number(value) <= 0) {
        return 0;
    }
    return value;
}
function formatCarrierBalanceCost(value, row) {
    if (value <= 0) {
        return 0;
    }
    return calculateCarrierBalanceCost(row);
}
function formatRemoveCost(value, row) {
    if (value <= 0) {
        return 0;
    }
    return value;
}

function calculateCarrierBalanceCost(row) {
    var movecost = calculateMoveCost(row);
    if (Number(row.RemoveCost) < 0) {
        row.RemoveCost = 0;
    }
    return movecost - row.RemoveCost;
}
function formatMoveCost(value, row) {
    return calculateMoveCost(row);
}
function calculateMoveCost(row) {
    if (Number(row.CarrierMoveCost) <= 0) {
        return 0;
    }
    return row.CarrierMoveCost;
}
var tt_editIndex = undefined;
function endTTEditing() {
    if (tt_editIndex == undefined) {
        return true;
    }
    $('#tt_table').datagrid('endEdit', tt_editIndex);
    //$('#tt_table').datagrid('acceptChanges');
    tt_editIndex = undefined;
    return true;
}
function onDblClickRowTT(index, row) {
    if (endTTEditing()) {
        editTTFee(row);
        tt_editIndex = index;
    } else {
        setTimeout(function () {
            $('#tt_table').datagrid('selectRow', tt_editIndex);
        }, 100);
    }
}
function onSelectPre(index, row) {
    setTimeout(function () {
        var realcost = calculateCarrierBalanceCost(row);
        $('#tt_table').datagrid('updateRow', {
            index: index,
            row: {
                CarrierBalanceCost: realcost
            }
        });
        calculateTotalRealCost();
    }, 500);
}
function onUnSelectPre(index, row) {
    setTimeout(function () {
        var realcost = 0;
        $('#tt_table').datagrid('updateRow', {
            index: index,
            row: {
                CarrierBalanceCost: realcost
            }
        });
        calculateTotalRealCost();
    }, 500);
}
function onClickTTRow(index, row) {
    if (tt_editIndex != index) {
        endTTEditing();
        return;
    }
    setTimeout(function () {
        $('#tt_table').datagrid('selectRow', index);
    }, 100);
}
function editTTFee(row) {
    var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
    $('#tt_table').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
    if (Number(row.RemoveCost) < 0) {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'RemoveCost' }).target.numberbox("setValue", 0);
    }
    var realcost = calculateCarrierBalanceCost(row);
    $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CarrierBalanceCost' }).target.numberbox("setValue", realcost);
    $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CarrierBalanceCost' }).target.numberbox('disable', true);
    if (checktime(row.CarrierBalanceTime) == "") {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CarrierBalanceTime' }).target.datetimebox("setValue", "");
    }
}
function checktime(time) {
    if (time == undefined || time == "" || time == null || time == '0001-01-01T00:00:00.0000000' || time == '0001-01-01T00:00:00' || time == '1900-01-01T00:00:00.0000000' || time == '1900-01-01T00:00:00') {
        return "";
    }
    return time.substring(0, 16).split("T")[0];
}
function ChargeBalance() {
    endTTEditing();
    var rows = $('#tt_table').datagrid("getChecked");
    if (rows.length == 0) {
        show_message("请勾选需要结算的搬运工信息", "warning");
        return;
    }
    var list = [];
    $.each(rows, function (index, row) {
        row.CarrierBalanceCost = calculateCarrierBalanceCost(row);
        if (checktime(row.CarrierBalanceTime) == "") {
            row.CarrierBalanceTime = $("#tdChargeTime").datetimebox("getValue");
        }
        list.push({ ID: row.ID, CarrierBalanceCost: row.CarrierBalanceCost, RemoveCost: row.RemoveCost, CarrierBalanceTime: row.CarrierBalanceTime });
    })
    var ChargeMan = $("#tdChargeMan").textbox("getValue");
    var ChargeTime = $("#tdChargeTime").datetimebox("getValue");
    var ChargeType1 = $("#tdPayType").combobox("getValue");
    var options = { visit: 'chargecarrierbalance', list: JSON.stringify(list), AddMan: AddMan, ChargeMan: ChargeMan, ChargeTime: ChargeTime, ChargeType1: ChargeType1 };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CommHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message("结算成功", "success", function () {
                    $('#tt_table').datagrid('reload');
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function calculateTotalRealCost() {
    var rows = $('#tt_table').datagrid("getChecked");
    var realtotal = 0;
    $.each(rows, function (index, row) {
        realtotal += Number(row.CarrierBalanceCost);
    });
    $("#tdtotalrealcost").html(realtotal + "元");
}
function PrintTable() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("没有可打印的数据", "warning");
        return;
    }
    var pageindex = $('#tt_table').datagrid('options').pageNumber;
    var pagesize = $('#tt_table').datagrid('options').pageSize;
    var InOutType = -1;
    var BusinessChargeStatus = -1;
    var CarrierChargeStatus = $("#tdCarrierChargeStatus").combobox("getValue");
    var CarrierBalanceStartTime = $("#tdStartTime").datebox("getValue");
    var CarrierBalanceEndTime = $("#tdEndTime").datebox("getValue");
    var Businessidarry = parent.GetSelectedByType("Business");
    var Productidarry = parent.GetSelectedByType("Product");
    var SpecInfoidarry = parent.GetSelectedByType("SpecInfo");
    var InventoryInfoidarry = parent.GetSelectedByType("InventoryInfo");
    var Carriergroupidarry = parent.GetSelectedTitleByType("CarrierGroup", 5);
    var Carrieridarry = parent.GetSelectedByType("Carrier");
    var BusinessID = Businessidarry.length > 0 ? Businessidarry[0] : 0;
    var ProductID = Productidarry.length > 0 ? Productidarry[0] : 0;
    var SpecInfoID = SpecInfoidarry.length > 0 ? SpecInfoidarry[0] : 0;
    var InventoryInfoID = InventoryInfoidarry.length > 0 ? InventoryInfoidarry[0] : 0;
    var CarrierGroupID = Carriergroupidarry.length > 0 ? Carriergroupidarry[0] : 0;
    var CarrierID = Carrieridarry.length > 0 ? Carrieridarry[0] : 0;
    //if (BusinessID == 0 && ProductID == 0 && InventoryInfoID == 0 && CarrierGroupID == 0 && CarrierID == 0) {
    //    show_message("请至少选择一个商户、货品、规格、库存、搬运工", "warning");
    //    return;
    //}
    //var param = "?BusinessChargeStatus=" + BusinessChargeStatus + "&CarrierChargeStatus=" + CarrierChargeStatus + "&InOutType=" + InOutType + "&CarrierBalanceStartTime=" + CarrierBalanceStartTime + "&CarrierBalanceEndTime=" + CarrierBalanceEndTime + "&BusinessID=" + BusinessID + "&ProductID=" + ProductID + "&SpecInfoID=" + SpecInfoID + "&InventoryInfoID=" + InventoryInfoID + "&CarrierGroupID=" + CarrierGroupID + "&CarrierID=" + CarrierID + "&page=" + pageindex + "&rows=" + pagesize;
    var idlist = [];
    $.each(rows, function (index, row) {
        idlist.push(row.ID)
    })
    var param = "?IDList=" + JSON.stringify(idlist);
    var iframe = "../Print/PrintCarrierBalanceMgr.aspx" + param;
    do_open_dialog('打印搬运工结算列表', iframe);
}