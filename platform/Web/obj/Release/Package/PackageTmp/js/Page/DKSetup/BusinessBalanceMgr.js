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
        { field: 'BusinessChargeStatusDesc', title: '结算状态', width: 60 },
        { field: 'ContactName', title: '商户', width: 100 },
        { field: 'ColdCost', formatter: formatColdCost, title: '冷藏费', width: 100 },
        { field: 'MoveCost', formatter: formatMoveCost, title: '搬运费', width: 100 },
        { field: 'TotalCost', formatter: formatTotalCost, title: '应收金额', width: 100 },
        { field: 'DiscountCost', formatter: formatDiscountCost, title: '减免金额', editor: { type: 'numberbox', options: { precision: 2 } }, width: 100 },
        { field: 'RealCost', formatter: formatRealCost, title: '实收金额', editor: { type: 'numberbox', options: { precision: 2 } }, width: 100 },
        { field: 'BalanceTime', formatter: formatTime, title: '结算日期', editor: { type: 'datetimebox' }, width: 100 },
        { field: 'InventoryName', title: '库位', width: 60 },
        { field: 'ProductName', title: '货品', width: 100 },
        { field: 'SpecName', title: '规格', width: 150 },
        { field: 'TotalCount', title: '数量', formatter: formatCount, width: 60 },
        { field: 'StartTime', formatter: formatStartTime, title: '入库日期', width: 100 },
        { field: 'EndTime', formatter: formatTime, title: '到期日期', width: 100 },
        { field: 'CarrierName', title: '搬运工', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    var BusinessChargeStatus = $("#tdBusinessChargeStatus").combobox("getValue");
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
        "BusinessChargeStatus": BusinessChargeStatus,
        "InOutType": -1,
        "CarrierChargeStatus": -1,
        "BusinessID": BusinessID,
        "ProductID": ProductID,
        "SpecInfoID": SpecInfoID,
        "InventoryInfoID": InventoryInfoID,
        "CarrierGroupID": CarrierGroupID,
        "CarrierID": CarrierID,
        "BusinessBalanceStartTime": StartTime,
        "BusinessBalanceEndTime": EndTime,
        "IncludeIsNextOrder": true,
        "SortOrder": "order by [StartTime] desc,[ID] desc",
        "ShowCarrierFee": true,
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
function formatRealCost(value, row) {
    if (value <= 0) {
        return 0;
    }
    return calculateRealCost(row);
}
function calculateRealCost(row) {
    var totalcost = calculateTotalCost(row);
    if (Number(row.DiscountCost) < 0) {
        row.DiscountCost = 0;
    }
    return totalcost - row.DiscountCost;
}
function formatMoveCost(value, row) {
    return calculateMoveCost(row);
}
function calculateMoveCost(row) {
    if (Number(row.MoveCost) <= 0) {
        return 0;
    }
    return row.MoveCost;
}

function formatColdCost(value, row) {
    return calculateColdCost(row);
}
function calculateColdCost(row) {
    if (row.InOutType == 2) {
        return 0;
    }
    if (Number(row.ColdCost) <= 0) {
        return 0;
    }
    return row.ColdCost;
    //return (Number(row.ColdPrice) * Number(row.Count) * Number(row.UseDays) / 30).toFixed(2);
}
function formatTotalCost(value, row) {
    return calculateTotalCost(row);
}
function calculateTotalCost(row) {
    var coldcost = calculateColdCost(row);
    var movecost = calculateMoveCost(row);
    return Number(movecost) + Number(coldcost);
}
function formatDiscountCost(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
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
        var realcost = calculateRealCost(row);
        $('#tt_table').datagrid('updateRow', {
            index: index,
            row: {
                RealCost: realcost
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
                RealCost: realcost
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
    if (Number(row.DiscountCost) < 0) {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'DiscountCost' }).target.numberbox("setValue", 0);
    }
    var realcost = calculateRealCost(row);
    $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'RealCost' }).target.numberbox("setValue", realcost);
    $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'RealCost' }).target.numberbox('disable', true);
    if (checktime(row.BalanceTime) == "") {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'BalanceTime' }).target.datetimebox("setValue", "");
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
        show_message("请勾选需要收费的商户信息", "warning");
        return;
    }
    var list = [];
    var ischarged = false;
    $.each(rows, function (index, row) {
        if (row.BusinessChargeStatus == 1) {
            ischarged = true;
            return false;
        }
        row.RealCost = calculateRealCost(row);
        row.ColdCost = calculateColdCost(row)
        row.TotalCost = calculateTotalCost(row);
        if (checktime(row.BalanceTime) == "") {
            row.BalanceTime = $("#tdChargeTime").datetimebox("getValue");
        }
        list.push({ ID: row.ID, TotalCost: row.TotalCost, ColdCost: row.ColdCost, DiscountCost: row.DiscountCost, RealCost: row.RealCost, BalanceTime: row.BalanceTime });
    })
    if (ischarged) {
        show_message("勾选项中包含已结算的费用,操作取消", "warning");
        return;
    }
    var ChargeMan = $("#tdChargeMan").textbox("getValue");
    var ChargeTime = $("#tdChargeTime").datetimebox("getValue");
    var ChargeType1 = $("#tdPayType").combobox("getValue");
    var options = { visit: 'chargebusinessbalance', list: JSON.stringify(list), AddMan: AddMan, ChargeMan: ChargeMan, ChargeTime: ChargeTime, ChargeType1: ChargeType1 };
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
        realtotal += Number(row.RealCost);
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
    var BusinessChargeStatus = $("#tdBusinessChargeStatus").combobox("getValue");
    var CarrierChargeStatus = -1;
    var BusinessBalanceStartTime = $("#tdStartTime").datebox("getValue");
    var BusinessBalanceEndTime = $("#tdEndTime").datebox("getValue");
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
    //var param = "?BusinessChargeStatus=" + BusinessChargeStatus + "&CarrierChargeStatus=" + CarrierChargeStatus + "&InOutType=" + InOutType + "&BusinessBalanceStartTime=" + BusinessBalanceStartTime + "&BusinessBalanceEndTime=" + BusinessBalanceEndTime + "&BusinessID=" + BusinessID + "&ProductID=" + ProductID + "&SpecInfoID=" + SpecInfoID + "&InventoryInfoID=" + InventoryInfoID + "&CarrierGroupID=" + CarrierGroupID + "&CarrierID=" + CarrierID + "&page=" + pageindex + "&rows=" + pagesize;
    var idlist = [];
    $.each(rows, function (index, row) {
        idlist.push(row.ID)
    })
    var param = "?IDList=" + JSON.stringify(idlist);
    var iframe = "../Print/PrintBusinessBalanceMgr.aspx" + param;
    do_open_dialog('打印商家结算列表', iframe);
}