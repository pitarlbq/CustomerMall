var tt_CanLoad = false;
var ChargeDiscountList = [];
$(function () {
    ChargeDiscountList = eval("(" + hdChargeDiscount.val() + ")");
    $(document).click(function (e) {
        var target = $(e.target);
        if (target.closest(".datagrid-btable,.calendar-noborder").length == 0) {
            endEditing();
        }
    });
    loadTT();
});
function loadTT() {
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
        onClickRow: onClickTTRow,
        onDblClickRow: onDblClickTTRow,
        //onClickCell: onClickCell,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
       { field: 'ck', checkbox: true },
       { field: 'Name', title: '收费项目', width: 150 },
       { field: 'CategoryDesc', title: '科目类别', width: 80 },
       { field: 'SummaryUnitPrice', formatter: formatPrice, editor: { type: 'numberbox', options: { precision: 4 } }, title: '单价', width: 80 },
       { field: 'CalculateUseCount', formatter: formatUseCount, editor: { type: 'numberbox', options: { precision: 2 } }, title: '面积/用量', width: 80 },
       { field: 'Cost', formatter: formatCost, editor: { type: 'numberbox', options: { precision: 2 } }, title: '应收金额', width: 60 },
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
       { field: 'RealCost', formatter: formatRealCost, title: '实收金额', width: 60 },
       { field: 'StartTime', editor: 'datebox', formatter: formatTime, title: '计费开始日期', width: 100 },
       { field: 'EndTime', editor: 'datebox', formatter: formatTime, title: '计费结束日期', width: 100 },
       { field: 'Remark', editor: 'textbox', formatter: formatRemark, title: '备注', width: 100 }
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
        }
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadltempsummarylist",
        "RoomIDs": RoomIDs
    });
}
function formatDiscount(value, row) {
    return calculateFinalDiscount(row);
}
function calculateFinalDiscount(row) {
    row.EndNumberCount = Number(row.EndNumberCount) < 0 ? 2 : row.EndNumberCount;
    if (!row.DiscountType && !row.DiscountValue) {
        var discount = (row.Discount < 0 ? 0 : row.Discount);
        return xround(parseFloat(discount), 2);
    }
    var totalCost = calculateCost(row);
    var discount = calculateDiscountValue(row.Discount, row.DiscountType, row.DiscountValue, totalCost, row);
    return xround(parseFloat(discount), row.EndNumberCount);
}
function calculateDiscountValue(WriteDiscount, DiscountType, DiscountValue, totalCost, row) {
    var Value = 0;
    if (DiscountType == "percent") {
        Value = (totalCost * DiscountValue / 100).toFixed(2);
    }
    else if (DiscountType == "fixedamount") {
        Value = DiscountValue;
    }
    else if (DiscountType == "permonth") {
        var month_price = calculatemonthcost(row);
        Value = month_price * DiscountValue;
    }
    else {
        return (WriteDiscount < 0 ? 0 : WriteDiscount);
    }
    return Value;
}
var editIndex = undefined;
function endEditing() {
    if (editIndex == undefined) {
        return true;
    }
    $('#tt_table').datagrid('endEdit', editIndex);
    editIndex = undefined;
    return true;
}
function onDblClickTTRow(index, row) {
    if (endEditing()) {
        editRoomFee(row);
        editIndex = index;
    } else {
        setTimeout(function () {
            $('#tt_table').datagrid('selectRow', editIndex);
        }, 100);
    }
}
function onClickTTRow(index, row) {
    if (editIndex != index) {
        endEditing();
        return;
    }
    setTimeout(function () {
        $('#tt_table').datagrid('selectRow', index);
    }, 100);
}
function setDiscountIDCombobox(index, row) {
    var $edDiscount = $('#tt_table').datagrid('getEditor', { index: index, field: 'Discount' });
    var totalCost = calculateCost(row);
    var $edDiscountID = $('#tt_table').datagrid('getEditor', { index: index, field: 'DiscountID' });
    var WriteDiscount = calculateFinalDiscount(row);
    $edDiscountID.target.combobox({
        onSelect: function (rec) {
            $('#tt_table').datagrid('getRows')[index]['DiscountType'] = rec.DiscountType;
            $('#tt_table').datagrid('getRows')[index]['DiscountValue'] = rec.DiscountValue;
            $('#tt_table').datagrid('getRows')[index]['DiscountName'] = rec.DiscountName;
            $('#tt_table').datagrid('getRows')[index]['DiscountID'] = rec.ID;
            totalCost = $('#tt_table').datagrid('getEditor', { index: index, field: 'Cost' }).target.numberbox('getValue');
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
    var discountValue = calculateDiscountValue(WriteDiscount, row.DiscountType, row.DiscountValue, totalCost, row);
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
function editRoomFee(row) {
    var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
    $('#tt_table').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
    setDiscountIDCombobox(rowIndex, row);
    var CalculateCost = calculateTrueCost(row);
    var Cost_Target = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'Cost' }).target;
    var Cost_Input = Cost_Target.next('span').find('input');
    Cost_Target.numberbox('enable', true);
    if (CalculateCost > 0 && !row.cost_changed) {
        Cost_Target.numberbox("setValue", CalculateCost);
        //Cost_Target.numberbox('disable', true);
    }
    else if (row.Cost > 0) {
        Cost_Target.numberbox("setValue", row.Cost);
    }
    var SummaryUnitPrice_Target = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'SummaryUnitPrice' }).target;
    var SummaryUnitPrice_Input = SummaryUnitPrice_Target.next('span').find('input');
    SummaryUnitPrice_Input.focus();
    var CalculateUseCount_Target = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'CalculateUseCount' }).target;
    var CalculateUseCount_Input = CalculateUseCount_Target.next('span').find('input');
    if (row.IsPriceRange) {
        var JieTiePrice = calculateJieTiUnitPrice(row);
        //SummaryUnitPrice_Target.numberbox("disable", true);
        SummaryUnitPrice_Target.numberbox("setValue", JieTiePrice);
    }
    else {
        if (Number(row.SummaryUnitPrice) <= 0) {
            row.SummaryUnitPrice = calculatePrice(row);
        }
        if (row.SummaryUnitPrice > 0) {
            SummaryUnitPrice_Target.numberbox("setValue", Number(row.SummaryUnitPrice));
        }
        else {
            SummaryUnitPrice_Target.numberbox("setValue", 0);
        }
    }
    var costchanged = false;
    Cost_Input.bind('input propertychange', function (e) {
        row.cost_changed = true;
        costchanged = true;
    });
    CalculateUseCount_Input.bind('input propertychange', function (e) {
        if (!costchanged) {
            var count_input = CalculateUseCount_Input.val();
            if (count_input == '') {
                costchanged = true;
                row.cost_changed = true;
            } else {
                row.cost_changed = false;
            }
        }
    });
    SummaryUnitPrice_Input.bind('input propertychange', function (e) {
        if (!costchanged) {
            row.cost_changed = false;
        }
    });
}
function formatPrice(value, row) {
    if (row.IsPriceRange) {
        return '<a>阶梯单价</a>';
    }
    return calculatePrice(row);
}
function formatCost(value, row) {
    if (row.cost_changed) {
        if (row.Cost > 0) {
            row.Cost = xround(row.Cost, row.EndNumberCount);
            return row.Cost;
        }
    }
    return calculateCost(row);
}
function calculatePrice(row) {
    //if (row.IsPriceRange) {
    //    var UnitPrice = calculateJieTiUnitPrice(row);
    //    if (UnitPrice > 0) {
    //        return UnitPrice;
    //    }
    //    return 0;
    //}
    if (Number(row.SummaryUnitPrice) < 0) {
        return 0;
    }
    return row.SummaryUnitPrice;
}
function calculateJieTiUnitPrice(row) {
    var PriceRangeValue = hdPriceRangeList.val();
    var UnitPrice = 0;
    if (PriceRangeValue != '') {
        var TotalPoint = calculateUseCount(row);
        var PriceRangeList = eval('(' + (PriceRangeValue) + ')');
        $.each(PriceRangeList, function (index, item) {
            if (item.SummaryID == row.ID) {
                if (TotalPoint >= Number(item.MinValue) && TotalPoint < Number(item.MaxValue)) {
                    UnitPrice = item.BasePrice;
                    return false;
                }
            }
        });
    }
    return UnitPrice;
}
function checktime(time) {
    if (time == undefined || time == "" || time == null || time == '0001-01-01T00:00:00.0000000' || time == '0001-01-01T00:00:00' || time == '1900-01-01T00:00:00.0000000' || time == '1900-01-01T00:00:00') {
        return "";
    }
    return time.substring(0, 16).split("T")[0];
}
function calculatemonth(starttime, endtime) {
    var arry1, arry2, year1, year2, month1, month2, day1, day2, count, newenddate, newday2;
    arry1 = starttime.split("-");
    year1 = parseInt(arry1[0]);
    month1 = parseInt(arry1[1]);
    day1 = parseInt(arry1[2]);
    arry2 = endtime.split("-");
    year2 = parseInt(arry2[0]);
    month2 = parseInt(arry2[1]);
    day2 = parseInt(arry2[2]);
    newenddate = new Date(year2, month2, 0);
    newday2 = newenddate.getDate();
    if (day1 == 1) {
        if (day2 == newday2) {
            count = (year2 - year1) * 12 + (month2 - month1) + 1;
        }
        else {
            count = (year2 - year1) * 12 + (month2 - month1);
        }
    }
    else if (day2 < (day1 - 1)) {
        count = (year2 - year1) * 12 + (month2 - month1) - 1;
    }
    else {
        count = (year2 - year1) * 12 + (month2 - month1);
    }
    return count;
}
function getNextMonth(date, monthnumber) {
    var arr, year1, month1, day1, year2, month2, day2, newmonth2, addyearcount, newdate, lastday;
    arr = date.split('-');
    year1 = arr[0]; //获取当前日期的年份
    month1 = arr[1]; //获取当前日期的月份
    day1 = arr[2]; //获取当前日期的日
    newmonth2 = parseInt(month1) + monthnumber;
    addyearcount = parseInt((newmonth2 - 1) / 12);
    year2 = parseInt(year1) + addyearcount;
    month2 = newmonth2 - (12 * addyearcount);
    day2 = parseInt(day1);
    newdate = new Date(year2, month2, 0);
    lastday = newdate.getDate();
    if (day2 > lastday) {
        day2 = lastday;
    }
    if (month2 < 10) {
        month2 = '0' + month2;
    }
    if (day2 < 10) {
        day2 = '0' + day2;
    }
    var t2 = year2 + '-' + month2 + '-' + day2;
    return t2;
}
function calculateTotaldays(starttime, endtime, monthnumber, isTotal) {
    var newstarttime, newendtime, temp1, temp2, startdate, enddate, date, time, count;
    newstarttime = getNextMonth(starttime, monthnumber);
    if (isTotal) {
        newendtime = getNextMonth(newstarttime, 1);
        count = 0;
    }
    else {
        newendtime = endtime;
        count = 1;
    }
    startdate = ConvertToDate(newstarttime);
    enddate = ConvertToDate(newendtime);
    //startdate = new Date(temp1);
    //enddate = new Date(temp2);
    if (startdate > enddate) {
        if (isTotal) {
            return 1;
        }
        return 0;
    }
    date = enddate.getTime() - startdate.getTime();
    time = Math.floor(date / (1000 * 60 * 60 * 24)) + count;
    return time;
}
function ConvertToDate(time) {
    time = time.replace(/-/g, "/").replace("T", " ");
    var date = new Date(time);
    return date;
}
function xround(x, num) {
    if (x <= 0) {
        return x;
    }
    return Math.round(x * Math.pow(10, num)) / Math.pow(10, num);
}
function calculateCost(row) {
    row.EndNumberCount = Number(row.EndNumberCount) < 0 ? 2 : row.EndNumberCount;
    if (!row.cost_changed) {
        var cost = calculateTrueCost(row);
        if (cost > 0) {
            row.Cost = xround(cost, row.EndNumberCount);
        }
    }
    if (row.Cost > 0) {
        row.Cost = xround(row.Cost, row.EndNumberCount);
        return row.Cost;
    }
    return 0;
}
function calculateTrueCost(row) {
    if (row.IsPriceRange) {
        var JieTiTotalPrice = calculateJieTiTotalPrice(row);
        return JieTiTotalPrice.toFixed(2);
    }
    var count, unit, finalcost, start, end, monthnumber, totaldays, restdays, arr, day1, Coefficient;
    count = calculateUseCount(row);
    unit = calculatePrice(row);
    var ImportCoefficient = (row.ImportCoefficient > 0 ? row.ImportCoefficient : 1);
    if (row.IsReading) {
        var Cost = count * unit * ImportCoefficient;
        if (Cost > 0) {
            return Cost;
        }
        return 0;
    }
    if (Number(row.TypeID) <= 0) {
        return unit;
    }
    if (row.TypeID == 6) {
        finalcost = unit * count;
        return finalcost;
    }
    start = checktime(row.StartTime);
    end = checktime(row.EndTime);
    if (start == "" || end == "") {
        return 0;
    }
    if (ConvertToDate(start) > ConvertToDate(end)) {
        return 0;
    }
    monthnumber = calculatemonth(start, end);
    totaldays = calculateTotaldays(start, end, monthnumber, true);
    restdays = calculateTotaldays(start, end, monthnumber, false);
    //单价*计费面积(月度)
    if (row.TypeID == 1) {
        finalcost = unit * (monthnumber + (restdays / totaldays)) * count;
        return finalcost;
    }
    //定额(月度)
    if (row.TypeID == 2) {
        finalcost = unit * (monthnumber + (restdays / totaldays));
        return finalcost;
    }
    //单价*计费面积*公摊系数(月度)
    if (row.TypeID == 3) {
        Coefficient = Number(row.FenTanCoefficient) > 0 ? Number(row.FenTanCoefficient) : 0;
        finalcost = unit * count * (monthnumber + (restdays / totaldays)) * Coefficient;
        return finalcost;
    }
    //定额(年度)
    if (row.TypeID == 4) {
        finalcost = unit * (monthnumber + (restdays / totaldays)) / 12;
        return finalcost;
    }
    //单价*计费面积(按天)
    if (row.TypeID == 5) {
        totaldays = calculateAllDays(start, end);
        finalcost = unit * totaldays * count;
        return finalcost;
    }
    return 0;
}
function calculateAllDays(starttime, endtime) {
    var startdate, enddate, date, time;
    startdate = ConvertToDate(starttime);
    enddate = ConvertToDate(endtime);
    if (startdate > enddate) {
        return 0;
    }
    date = enddate.getTime() - startdate.getTime();
    time = Math.floor(date / (1000 * 60 * 60 * 24));
    return time + 1;
}
function formatRealCost(value, row) {
    return calculateRealCost(row)
}
function calculateRealCost(row) {
    var finalcost = calculateCost(row);
    var finaldiscount = calculateFinalDiscount(row);
    return Number(finalcost) - Number(finaldiscount);
}
function saveTempFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    $.each(rows, function (index, row) {
        var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
        $('#tt_table').datagrid('endEdit', rowIndex);
    });
    editIndex = undefined;
}
function addFeetoCenter() {
    var summarylist = [];
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "warning");
        return;
    }
    $.each(rows, function (index, row) {
        var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
        row.Cost = calculateCost(row);
        row.RealCost = calculateRealCost(row);
        if (row.SummaryUnitPrice < 0) {
            row.SummaryUnitPrice = 0;
        }
        if (row.Coefficient < 0) {
            row.Coefficient = 0;
        }
        if (Number(row.DiscountID) < 0) {
            row.DiscountID = 0;
        }
        row.RealCost = 0;
        summarylist.push(row);
    });
    var options = { visit: 'savetemproomfee', RoomIDs: RoomIDs, AddMan: AddMan, SummaryList: JSON.stringify(summarylist) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message('添加成功', 'success');
                $('#tt_table').datagrid("reload");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function printTempFee() {
    saveTempFee();
    var summarylist = [];
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "warning");
        return;
    }
    var failedinfo = [];
    var iszero = false;
    var realiszero = false;
    $.each(rows, function (index, row) {
        var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
        var cost = formatCost(row.Cost, row);
        if (cost < 0) {
            iszero = true;
            return false;
        }
        var realcost = formatRealCost(row.RealCost, row);
        if (realcost < 0) {
            realiszero = true;
            return false;
        }
        var usecount = formatUseCount(row.CalculateUseCount, row);
        usecount = (usecount < 0 ? 0 : usecount);
        var price = calculatePrice(row);
        price = (price < 0 ? 0 : price);
        if (!row.StartTime) {
            row.StartTime = "";
        }
        if (!row.EndTime) {
            row.EndTime = "";
        }
        if (!row.DiscountID) {
            row.DiscountID = 0;
        }
        if (Number(row.DiscountID) < 0) {
            row.DiscountID = 0;
        }
        row.Discount = (row.Discount < 0 ? 0 : row.Discount);
        var strarry = { ID: row.ID, UnitPrice: price, UseCount: usecount, Cost: cost, StartTime: row.StartTime, EndTime: row.EndTime, Discount: row.Discount, RealCost: realcost, OutDays: 0, Remark: row.Remark, DiscountID: row.DiscountID };
        failedinfo.push(strarry);
    });
    if (iszero) {
        show_message("应收金额不能小于0", "warning");
        return;
    }
    if (realiszero) {
        show_message("实收金额不能小于0", "warning");
        return;
    }
    var RoomFeeFields = [];
    var results = parent.checkrowsstatus();
    if (results.status) {
        RoomFeeFields = results.failedinfo;
    }
    options = { visit: 'chargetemproomfee', CompanyID: CompanyID, RoomIDs: RoomIDs, AddMan: AddMan, Fields: JSON.stringify(failedinfo), RoomFeeFields: JSON.stringify(RoomFeeFields), ContractID: ContractID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var RoomID = 0;
                if (RoomIDs.length > 0) {
                    RoomID = RoomIDs[0];
                }
                var iframe = "../PrintPage/printchargefeenew.aspx?IDs=" + JSON.stringify(message.HistoryListID) + "&RoomIDs=" + RoomIDs + "&RoomID=" + RoomID;
                do_open_dialog('打印收款收据', iframe);
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function do_close_printchargefee() {
    $('#tt_table').datagrid('reload');
    parent.SearchTT();
}
function formatUseCount(value, row) {
    return calculateUseCount(row);
}
function calculateUseCount(row) {
    if (row.TypeID == 6) {//单价*计费面积/用量(一次性)
        if (Number(row.CalculateUseCount) <= 0) {
            row.CalculateUseCount = calculate_usecount_by(row);
        }
        return row.CalculateUseCount;
    }
    if (Number(row.CalculateUseCount) < 0) {
        return 0;
    }
    return row.CalculateUseCount;
}
function formatRemark(value, row) {
    if (value.length > 10) {
        return value.substring(0, 10) + "...";
    }
    return value;
}
function calculate_usecount_by(row) {
    var unitprice = calculatePrice(row);
    if (parseFloat(unitprice) > 0) {
        return (parseFloat(row.Cost / unitprice)).toFixed(2);
    }
    return 0;
}
function calculatemonthcost(row) {
    var count = calculateUseCount(row);
    var unit = calculatePrice(row);
    //单价*计费面积(月度)
    var finalcost = 0;
    if (row.TypeID == 1) {
        finalcost = unit * count;
        return finalcost;
    }
    //定额(月度)
    if (row.TypeID == 2) {
        finalcost = unit;
    }
    //单价*计费面积*公摊系数(月度)
    if (row.TypeID == 3) {
        var Coefficient = Number(row.FenTanCoefficient) > 0 ? Number(row.FenTanCoefficient) : 0;
        finalcost = unit * count * Coefficient;
    }
    //单价*计费面积(月度进位)
    if (row.TypeID == 7) {
        finalcost = xround(parseFloat(unit * count), 0);
        return finalcost;
    }
    return finalcost;
}
function calculateJieTiTotalPrice(row) {
    var totalPrice = 0;
    var PriceRangeValue = hdPriceRangeList.val()
    if (PriceRangeValue != '' && row.IsPriceRange) {
        var TotalPoint = calculateUseCount(row);
        var ImportCoefficient = (parseFloat(row.ImportCoefficient) > 0 ? row.ImportCoefficient : 1);
        var PriceRangeList = eval('(' + (PriceRangeValue) + ')');
        var LastMaxValue = 0;
        var my_pricerange = get_my_pricerange(PriceRangeList, row.ID);
        for (var i = 0; i < my_pricerange.length; i++) {
            var pricerange = my_pricerange[i];
            if (pricerange.SummaryID == row.ID) {
                var MinValue = Number(pricerange.MinValue);
                var MaxValue = Number(pricerange.MaxValue);
                var NianTotal = 0;
                if (pricerange.BaseType == "qnyl" && row.TotalUseCount) {
                    NianTotal = (Number(row.TotalUseCount) > 0 ? Number(row.TotalUseCount) : 0);
                }
                if ((NianTotal + Number(TotalPoint)) >= MinValue && (NianTotal + Number(TotalPoint)) < MaxValue) {
                    if (NianTotal > MinValue) {
                        totalPrice += Number(TotalPoint) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                    }
                    else {
                        totalPrice += (NianTotal + Number(TotalPoint) - MinValue) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                    }
                    break;
                }
                if ((NianTotal + Number(TotalPoint)) >= MaxValue) {
                    if (i == my_pricerange.length - 1) {
                        totalPrice += (NianTotal + Number(TotalPoint) - MinValue) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                        break;
                    }
                    if (pricerange.BaseType == "qnyl") {
                        if (MaxValue > NianTotal) {
                            MinValue = (NianTotal > MinValue ? NianTotal : MinValue);
                            totalPrice += (MaxValue - MinValue) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                        }
                    }
                    else {
                        totalPrice += (MaxValue - MinValue) * pricerange.BasePrice * (ImportCoefficient > 0 ? ImportCoefficient : 1);
                    }
                }
            }
        }
    }
    return totalPrice;
}
function get_my_pricerange(PriceRangeList, ChargeID) {
    var list = [];
    $.each(PriceRangeList, function (index, item) {
        if (item.SummaryID == ChargeID) {
            list.push(item);
        }
    })
    return list;
}
function do_close() {
    parent.do_close_dialog();
}