var tt_CanLoad = false;
var ChargeDiscountList = [];
$(function () {
    loadtt();
    $(document).click(function (e) {
        var target = $(e.target);
        if (target.closest(".datagrid-btable,.calendar-noborder").length == 0) {
            endTTEditing();
        }
    });
    ChargeDiscountList = eval("(" + hdChargeDiscount.val() + ")");
});
function loadtt() {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
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
        onClickRow: onClickTTRow,
        onDblClickRow: onDblClickTTRow,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'RoomName', title: '资源编号', width: 100 },
        { field: 'ContractNo', title: '合同编号', width: 100 },
        { field: 'RentName', title: '客户名称', width: 100 },
        { field: 'Name', title: '收费项目', width: 100 },
        { field: 'CalculateUnitPrice', formatter: formatUnitPrice, editor: { type: 'numberbox', options: { precision: 4 } }, title: '单价', width: 80 },
        { field: 'CalculateUseCount', formatter: formatUseCount, editor: { type: 'numberbox', options: { precision: 2 } }, title: '合同面积', width: 80 },
        { field: 'CalculateStartTime', editor: 'datebox', formatter: formatStartTime, title: '计费开始日期', width: 100 },
        { field: 'CalculateEndTime', editor: 'datebox', formatter: formatEndTime, title: '计费结束日期', width: 100 },
        { field: 'NewEndTime', editor: 'datebox', formatter: formatNewEndTime, title: '计费停用日期', width: 100 },
        { field: 'TotalCost', formatter: formatCost, editor: { type: 'numberbox', options: { precision: 2 } }, title: '应收金额', width: 80 },
        { field: 'PayCost', formatter: formatPayCost, editor: { type: 'numberbox', options: { precision: 2 } }, title: '实收金额', width: 60 },
        { field: 'FormatTotalFinalPayCost', title: '已收金额', width: 60 },
        //{ field: 'TotalRealCost', formatter: formatTotalRealCost, title: '已收金额', width: 80 },
        { field: 'FormatTotalFinalCost', formatter: formatRestCost, title: '未收金额', width: 80 },
        { field: 'Discount', formatter: formatDiscount, editor: { type: 'numberbox', options: { precision: 2 } }, title: '减免金额', width: 60 },
        {
            field: 'DiscountID', formatter: function (value, row) {
                return row.DiscountName;
            },
            editor: {
                type: 'combobox',
                options: {
                    valueField: 'ID',
                    textField: 'DiscountName',
                    data: ChargeDiscountList
                }
            }, title: '减免方案', width: 100
        },
        { field: 'OutDays', formatter: formatOutDays, title: '逾期', width: 80 },
        { field: 'RemarkNote', editor: 'textbox', formatter: formatRemark, title: '备注信息', width: 100 }
        ]],
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
        onLoadSuccess: function (data) {
            var currentcount = data.currentcount || 0;
            var url = '../Handler/FeeCenterHandler.ashx?currentcount=' + currentcount;
            $("#tt_table").datagrid("options").url = url;
        },
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var idarry = parent.GetRoomIDList();
    if (idarry.length == 0) {
        return;
    }
    var url = '../Handler/FeeCenterHandler.ashx?currentcount=0';
    $("#tt_table").datagrid("options").url = url;
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadroomfeelist",
        "RoomID": JSON.stringify(idarry),
        "CategoryID": 0,
        "ContractID": ContractID,
        "IsContractFee": true
    });
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
function onDblClickTTRow(index, row) {
    if (endTTEditing()) {
        editTTRoomFee(row);
        tt_editIndex = index;
    } else {
        setTimeout(function () {
            $('#tt_table').datagrid('selectRow', tt_editIndex);
        }, 100);
    }
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
function setDiscountIDCombobox(index, row) {
    var $edDiscount = $('#tt_table').datagrid('getEditor', { index: index, field: 'Discount' });
    var usecount = calculateUseCount(row);
    var unitprice = calculateUnitPrice(row);
    var totalCost = calculateCost(row, usecount, unitprice);
    var WriteDiscount = calculateFinalDiscount(row);
    var $edDiscountID = $('#tt_table').datagrid('getEditor', { index: index, field: 'DiscountID' });
    $edDiscountID.target.combobox({
        valueField: 'ID',
        textField: 'DiscountName',
        data: getChargeDiscountList(ChargeDiscountList, row.ChargeID),
        onSelect: function (rec) {
            $('#tt_table').datagrid('getRows')[index]['DiscountType'] = rec.DiscountType;
            $('#tt_table').datagrid('getRows')[index]['DiscountValue'] = rec.DiscountValue;
            $('#tt_table').datagrid('getRows')[index]['DiscountName'] = rec.DiscountName;
            $('#tt_table').datagrid('getRows')[index]['DiscountID'] = rec.ID;
            var discountValue = calculateDiscountValue(WriteDiscount, rec.DiscountType, rec.DiscountValue, totalCost, row);
            $edDiscount.target.numberbox('setValue', discountValue);
            if (rec.DiscountType != "writeamount") {
                $edDiscount.target.numberbox('disable', true);
            }
            else {
                $edDiscount.target.numberbox('enable', true);
            }
        }
    });
    var discountValue = calculateDiscountValue(WriteDiscount, row.DiscountType, row.DiscountValue, totalCost);
    $edDiscount.target.numberbox("setValue", discountValue);
    if (row.DiscountID) {
        $edDiscountID.target.combobox("setValue", (Number(row.DiscountID) < 0 ? "" : row.DiscountID));
    }
    if (row.DiscountType) {
        if (row.DiscountType != "writeamount") {
            $edDiscount.target.numberbox('disable', true);
        }
        else {
            $edDiscount.target.numberbox('enable', true);
        }
    }
}
function editTTRoomFee(row) {
    var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
    $('#tt_table').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
    setDiscountIDCombobox(rowIndex, row);
    var $edUseCount = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateUseCount' });
    if (row.CalculateUseCount > 0) {
        //$edUseCount.target.numberbox('disable', true);
    }
    else if (row.CalculateUseCount <= 0) {
        var usecount = calculateUseCount(row);
        $edUseCount.target.numberbox("setValue", usecount);
        if (usecount > 0) {
            //$edUseCount.target.numberbox('disable', true);
        }
    }
    var start = checktime(row.CalculateStartTime);
    if (start == "") {
        row.startnone = true;
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateStartTime' }).target.datebox("setValue", start);
    }
    if (row.TimeAuto && !row.startnone) {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateStartTime' }).target.datebox('disable', true);
    }
    if (checktime(row.CuiShouStartTime) != "") {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateStartTime' }).target.datebox('disable', true);
    }
    var newend = calculateNewEndTime(row);
    $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'NewEndTime' }).target.datebox("setValue", newend);
    //else {
    //$('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'StartTime' }).target.datebox('disable', true);
    //}
    if (row.FeeType == 5) {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateEndTime' }).target.datebox('disable', true);
    }
    else {
        var end = calculateEndTIme(row);
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateEndTime' }).target.datebox("setValue", end);
    }
    if (checktime(row.CuiShouEndTime) != "") {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateEndTime' }).target.datebox('disable', true);
    }
    var $edUnitPrice = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateUnitPrice' });
    if (row.StartPriceRange) {
        var JieTiePrice = calculateJieTiUnitPrice(row);
        $edUnitPrice.target.numberbox("disable", true);
        $edUnitPrice.target.numberbox("setValue", JieTiePrice);
    }
    else {
        if (Number(row.CalculateUnitPrice) <= 0) {
            row.CalculateUnitPrice = calculateUnitPrice(row);
        }
        if (Number(row.CalculateUnitPrice) > 0) {
            $edUnitPrice.target.numberbox("setValue", Number(row.CalculateUnitPrice));
            //$edUnitPrice.target.numberbox('disable', true);
        }
        else {
            $edUnitPrice.target.numberbox("setValue", 0);
        }
    }
    if (row.FeeType != 4) {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'TotalCost' }).target.datebox('disable', true);
    }
}
function accept() {
    var rows = $('#tt_table').datagrid("getSelections");
    $.each(rows, function (index, row) {
        var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
        $('#tt_table').datagrid('endEdit', rowIndex);
    });
    tt_editIndex = undefined;
}
function checkrowsstatus() {
    var results = {};
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {

        return results;
    }
    accept();
    var failedinfo = [];
    var RoomIDs = [];
    var endtimeerror = "";
    var costerror = "";
    var realcosterror = "";
    $.each(rows, function (index, row) {
        if (row.CalculateEndTime == "" && row.FeeType == 1) {
            endtimeerror += (index + 1) + ",";
            return true;
        }
        var cost = formatCost(row.TotalCost, row);
        if (cost <= 0 && row.ContractID <= 0) {
            costerror += (index + 1) + ",";
            return true;
        }
        var paycost = formatPayCost(row.PayCost, row);
        if (paycost < 0 && row.ContractID <= 0) {
            realcosterror += (index + 1) + ",";
            return true;
        }
        var usecount = formatUseCount(row.CalculateUseCount, row);
        usecount = (usecount < 0 ? 0 : usecount);
        var unitprice = calculateUnitPrice(row);
        unitprice = (unitprice < 0 ? 0 : unitprice);
        var outdays = row.OutDays;
        outdays = (outdays < 0 ? 0 : outdays);
        var discount = formatDiscount(row.Discount, row);
        discount = (discount < 0 ? 0 : discount);
        var CalculateStartTime = formatStartTime(row.CalculateStartTime, row);
        var CalculateEndTime = formatEndTime(row.CalculateEndTime, row);
        var NewEndTime = formatNewEndTime(row.NewEndTime, row);
        var discountid = row.DiscountID || 0;
        discountid = (discountid < 0 ? 0 : discountid);
        var strarry = { ID: row.ID, UnitPrice: unitprice, UseCount: usecount, StartTime: CalculateStartTime, EndTime: CalculateEndTime, NewEndTime: NewEndTime, Cost: cost, Discount: discount, RealCost: paycost, OutDays: outdays, Remark: row.RemarkNote, DiscountID: discountid };
        failedinfo.push(strarry);
        RoomIDs.push(row.RoomID);
    });
    if (endtimeerror != "") {
        results.status = false;
        show_message("第" + endtimeerror.substring(0, endtimeerror.length - 1) + "行计算结束日期不能为空", "warning");
        return results;
    }
    if (costerror != "") {
        results.status = false;
        show_message("第" + costerror.substring(0, costerror.length - 1) + "行应收金额不能小于0", "warning");
        return results;
    }
    if (realcosterror != "") {
        results.status = false;
        show_message("第" + realcosterror.substring(0, costerror.length - 1) + "行实收金额不能小于0", "warning");
        return results;
    }
    results.status = true;
    results.failedinfo = failedinfo;
    results.RoomIDs = RoomIDs;
    return results;
}
function chargeroomfee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    var results = checkrowsstatus();
    if (!results.status) {
        return;
    }
    var options = { visit: 'chargeroomfee', CompanyID: companyID, AddMan: AddMan, Fields: JSON.stringify(results.failedinfo) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var RoomID = 0;
                if (results.RoomIDs.length > 0) {
                    RoomID = results.RoomIDs[0];
                }
                var iframe = "../PrintPage/printchargefeenew.aspx?IDs=" + JSON.stringify(message.HistoryListID) + "&RoomIDs=" + JSON.stringify(results.RoomIDs) + "&RoomID=" + RoomID;
                do_open_dialog('打印收款收据', iframe);
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function do_close_printchargefee() {
    $('#tt_table').datagrid("reload");
    parent.GetBalance(0);
    parent.getContractTitleList(ContractID);
}
function formatPoint(value, row) {
    return (Number(row.StartPoint) < 0 ? 0 : row.StartPoint) + "/" + (Number(row.EndPoint) < 0 ? 0 : row.EndPoint);
}

function addTempFee() {
    var roomids = parent.GetRoomIDList();
    if (roomids.length == 0) {
        show_message("请选择一个房间", "warning");
        return;
    }
    var iframe = "../Charge/AddTempFee.aspx?RoomIDs=" + JSON.stringify(roomids) + "&ContractID=" + ContractID;
    do_open_dialog('新增临时收费', iframe);
}
function removeTempFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    var canDel = true;
    var RoomFeeIDList = [];
    $.each(rows, function (index, row) {
        if (row.FeeType != 4) {
            canDel = false;
            return false;
        }
        RoomFeeIDList.push(row.ID)
    });
    if (!canDel) {
        show_message("当前选中的费用中包含非临时费用，删除取消", "warning");
        return;
    }
    top.$.messager.confirm("提示", "确认删除选中的临时费用?", function (r) {
        if (r) {
            var options = { visit: 'deletetemproomfee', RoomFeeIDList: JSON.stringify(RoomFeeIDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success');
                        $('#tt_table').datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    });
}
function getSelectedTTRows() {
    var rows = $('#tt_table').datagrid("getSelections");
    return rows;
}


