var tt_CanLoad;
var FeeType = 0;
var CategoryID = 0;
$(function () {
    tt_CanLoad = false;
    try {
        canrent = parent.canrent;
        RentToTime = parent.tdRentToTime.datebox('getValue');
    } catch (e) {

    }
    getAllParams();
    $('.AutoChangePrice').show();
    $('#tdAutoChagePrice').bind('click', function () {
        if ($(this).prop('checked')) {
            $('.AutoChangePrice').show();
        }
        else {
            $('.AutoChangePrice').hide();
        }
    })
    $('#tdCalculateType').combobox({
        onSelect: function () {
            change_status();
        }
    })
    change_status();
});
function change_status() {
    var CalculateType = $('#tdCalculateType').combobox('getValue');
    if (CalculateType == '') {
        $('.tiaojia_percent').hide();
        $('.tiaojia_amount').hide();
        $('.tr_CalcualtePriceMonth').hide();
    } else if (CalculateType == 'percent') {
        $('.tr_CalcualtePriceMonth').show();
        $('.tiaojia_percent').show();
        $('.tiaojia_amount').hide();
    } else if (CalculateType == 'amount') {
        $('.tr_CalcualtePriceMonth').show();
        $('.tiaojia_percent').hide();
        $('.tiaojia_amount').show();
    }
}
function getAllParams() {
    var options = { visit: 'getaddcontractchargeparam', guid: guid, ContractID: ContractID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                $('#tdRoomID').combobox({
                    multiple: true,
                    editable: false,
                    data: data.roomlist,
                    valueField: 'RoomID',
                    textField: 'Name',
                    filter: function (q, row) {
                        var opts = $(this).combobox('options');
                        return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                    }
                });
                $('#tdChargeID').combobox({
                    editable: false,
                    data: data.chargelist,
                    valueField: 'ID',
                    textField: 'Name',
                    onSelect: function (rec) {
                        $("#tdRoomUnitPrice").textbox('setValue', rec.SummaryUnitPrice);
                        FeeType = rec.FeeType;
                        CategoryID = rec.CategoryID;
                        if (FeeType == 1) {
                            $('#tr_CalculateMonth').show();
                            $('#pricetable').show();
                            $('#btnTempPrice').show();
                            loadTT();
                        } else {
                            $('#tr_CalculateMonth').hide();
                            $('#pricetable').hide();
                            $('#btnTempPrice').hide();
                        }
                    }
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function closeWin() {
    parent.do_close_dialog(function () {
        parent.AddCharge_Done();
    });
}
function saveDataProcess() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var RoomIDs = $('#tdRoomID').combobox("getValues");
    var ChargeID = $('#tdChargeID').combobox("getValue");
    var ChargeIDList = [];
    ChargeIDList.push(ChargeID);
    var RoomName = $('#tdRoomID').combobox("getText");
    var RoomUnitPrice = $('#tdRoomUnitPrice').textbox("getValue");
    var FirstReadyChargeTime = $('#tdFirstReadyChargeTime').datebox('getValue');
    var options = { visit: 'savecontractcharge', RoomIDs: JSON.stringify(RoomIDs), ChargeIDList: JSON.stringify(ChargeIDList), guid: guid, ContractID: ContractID, RoomName: RoomName, RoomUnitPrice: RoomUnitPrice, canedit: canedit, FirstReadyChargeTime: FirstReadyChargeTime, canrent: canrent };
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                if (canedit == 1 || canrent == 1) {
                    createFee();
                    return;
                }
                show_message('添加成功', 'success', function () {
                    if (FeeType != 4) {
                        $('#pricetable').show();
                        loadTT();
                        return;
                    }
                    closeWin();
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function createFee() {
    var IDList = [];
    IDList.push(ContractID);
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'createcontractfee', IDList: JSON.stringify(IDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                show_message('添加成功', 'success', function () {
                    if (FeeType != 4) {
                        $('#pricetable').show();
                        loadTT();
                        return;
                    }
                    closeWin();
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function doAddPrice() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var CalculateMonth = 0;
    var CalculatePercent = 0;
    var CalculateAmount = 0;
    var CalculateType = "";
    var RoomUnitPrice = $('#tdRoomUnitPrice').textbox('getValue');
    var IsAutoChagePrice = 0;
    var CalcualtePriceMonth = 0;
    var FirstReadyChargePriceTime = '';
    if ($('#tdAutoChagePrice').prop('checked')) {
        IsAutoChagePrice = 1;
        CalculateMonth = $('#tdCalculateMonth').textbox('getValue');
        if (CalculateMonth == '' && CategoryID != 4 && FeeType != 4) {
            show_message('请填写收费周期', 'info');
            return;
        }
        CalculateType = $('#tdCalculateType').combobox('getValue');
        CalculatePercent = $('#tdCalculatePercent').textbox('getValue');
        CalculateAmount = $('#tdCalculateAmount').textbox('getValue');
        if (CalculateType != '') {
            CalcualtePriceMonth = $('#tdCalcualtePriceMonth').textbox('getValue');
            FirstReadyChargePriceTime = $('#tdFirstReadyChargePriceTime').datebox('getValue');
            if (CalcualtePriceMonth == '') {
                show_message('请填写调价周期', 'info');
                return;
            }
            if (FirstReadyChargePriceTime == '' && CategoryID != 4) {
                show_message('请填写调价开始日期', 'info');
                return;
            }
            if (CalculateType == 'percent' && CalculatePercent == "") {
                show_message('请填写调价比例', 'info');
                return;
            }
            if (CalculateType == 'amount' && CalculateAmount == "") {
                show_message('请填写调价金额', 'info');
                return;
            }
        }
    }
    var FirstReadyChargeTime = $('#tdFirstReadyChargeTime').datebox('getValue');
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'savecontracttempprice', RoomUnitPrice: RoomUnitPrice, CalculateMonth: CalculateMonth, CalculateType: CalculateType, CalculatePercent: CalculatePercent, CalculateAmount: CalculateAmount, StartTime: StartTime, EndTime: EndTime, guid: guid, IsAutoChagePrice: IsAutoChagePrice, FirstReadyChargeTime: FirstReadyChargeTime, CategoryID: CategoryID, CalcualtePriceMonth: CalcualtePriceMonth, FirstReadyChargePriceTime: FirstReadyChargePriceTime, FeeType: FeeType, canrent: canrent, RentToTime: RentToTime };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                if (data.MonthInvalid) {
                    show_message('请重新填写收费周期', 'info');
                    return;
                }
                if (data.PriceMonthInvalid) {
                    show_message('请重新填写调价周期', 'info');
                    return;
                }
                if (data.StartTimeInvalid) {
                    show_message('合同开始日期不合法', 'info');
                    return;
                }
                if (data.EndTimeInvalid) {
                    show_message('合同截止日期不合法', 'info');
                    return;
                }
                $('#pricetable').show();
                loadTT();
                return;
            }
            if (data.error) {
                show_message(data.error, 'info');
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function loadTT() {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        onClickRow: onClickTTRow,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'CalculatePrice', editor: 'textbox', title: '单价', width: 100 },
        { field: 'CalculateUseCount', editor: 'textbox', title: '面积', width: 80 },
        { field: 'CalculateCost', editor: 'textbox', formatter: formatCalculateCost, title: '金额', width: 100 },
        { field: 'CalculateStartTime', editor: 'datebox', formatter: formatTime, title: '计费开始日期', width: 100 },
        { field: 'CalculateEndTime', editor: 'datebox', formatter: formatTime, title: '计费结束日期', width: 100 },
        { field: 'ReadyChargeTime', editor: 'datebox', formatter: formatTime, title: '收费日期', width: 100 }
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
            $('#tt_room').datagrid("loadData", {
                tt_table: 0,
                rows: []
            });
        },
        toolbar: '#tb'
    });
    SearchTT();
}
function formatCalculateCost(value, row) {
    if (parseFloat(row.CalculateCost) <= 0) {
        row.CalculateCost = 0;
    }
    return row.CalculateCost;
}
function SearchTT() {
    tt_CanLoad = true;
    var ChargeID = $('#tdChargeID').combobox("getValue");
    $("#tt_table").datagrid("load", {
        "visit": "loadcontractemppricegrid",
        "guid": guid,
        "ChargeID": ChargeID
    });
}
var editIndex = undefined;
function endEditing() {
    if (editIndex == undefined) {
        return true
    }
    if ($('#tt_table').datagrid('validateRow', editIndex)) {
        $('#tt_table').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}
function doAddRow() {
    if (endEditing()) {
        $('#tt_table').datagrid('appendRow', { CalculatePrice: $('#tdRoomUnitPrice').textbox('getValue') });
        editIndex = $('#tt_table').datagrid('getRows').length - 1;
        $('#tt_table').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
    }
}
function doAcceptRows() {
    if (endEditing()) {
        $('#tt_table').datagrid('acceptChanges');
    }
}
function saveData() {
    var isValid = ffObj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var RowList = [];
    try {
        var rows = $('#tt_table').datagrid('getRows');
        if (rows && rows.length > 0) {
            doAcceptRows();
            $.each(rows, function (index, row) {
                var addrow = {};
                addrow.ID = row.ID;
                addrow.CalculatePrice = (row.CalculatePrice == "" ? 0 : row.CalculatePrice);
                addrow.CalculateCost = (row.CalculateCost == "" ? 0 : row.CalculateCost);
                if (row.CalculateStartTime != '') {
                    addrow.CalculateStartTime = row.CalculateStartTime;
                }
                if (row.CalculateEndTime != '') {
                    addrow.CalculateEndTime = row.CalculateEndTime;
                }
                if (row.CalculateStartTime != '') {
                    addrow.CalculateStartTime = row.CalculateStartTime;
                }
                if (row.ReadyChargeTime != '') {
                    addrow.ReadyChargeTime = row.ReadyChargeTime;
                }
                RowList.push(addrow);
            })
        }
    } catch (e) {

    }
    var FirstReadyChargeTime = $('#tdFirstReadyChargeTime').datebox('getValue');
    var RoomUnitPrice = $('#tdRoomUnitPrice').textbox('getValue');
    var CalculateMonth = 0;
    var CalculateType = "";
    var CalculatePercent = 0;
    var CalculateAmount = 0;
    var IsAutoChagePrice = 0;
    var CalcualtePriceMonth = 0;
    var FirstReadyChargePriceTime = '';
    if ($('#tdAutoChagePrice').prop('checked')) {
        IsAutoChagePrice = 1;
        CalculateMonth = $('#tdCalculateMonth').textbox('getValue');
        if (CalculateMonth == '' && CategoryID != 4 && FeeType != 4) {
            show_message('请填写收费周期', 'info');
            return;
        }
        CalculateType = $('#tdCalculateType').combobox('getValue');
        CalculatePercent = $('#tdCalculatePercent').textbox('getValue');
        CalculateAmount = $('#tdCalculateAmount').textbox('getValue');
        if (CalculateType != '') {
            CalcualtePriceMonth = $('#tdCalcualtePriceMonth').textbox('getValue');
            FirstReadyChargePriceTime = $('#tdFirstReadyChargePriceTime').datebox('getValue');
            if (CalcualtePriceMonth == '') {
                show_message('请填写调价周期', 'info');
                return;
            }
            if (FirstReadyChargePriceTime == '' && CategoryID != 4) {
                show_message('请填写调价开始日期', 'info');
                return;
            }
            if (CalculateType == 'percent' && CalculatePercent == "") {
                show_message('请填写调价比例', 'info');
                return;
            }
            if (CalculateType == 'amount' && CalculateAmount == "") {
                show_message('请填写调价金额', 'info');
                return;
            }
        }
    }
    else if (RowList.length == 0) {
        saveDataProcess();
        return;
    }
    var ChargeID = $('#tdChargeID').combobox("getValue");
    var RoomIDs = $('#tdRoomID').combobox("getValues");
    var options = { visit: 'addcontracttemppricelist', TempList: JSON.stringify(RowList), RoomUnitPrice: RoomUnitPrice, CalculateMonth: CalculateMonth, CalculateType: CalculateType, CalculatePercent: CalculatePercent, CalculateAmount: CalculateAmount, StartTime: StartTime, EndTime: EndTime, guid: guid, IsAutoChagePrice: IsAutoChagePrice, FirstReadyChargeTime: FirstReadyChargeTime, CategoryID: CategoryID, CalcualtePriceMonth: CalcualtePriceMonth, FirstReadyChargePriceTime: FirstReadyChargePriceTime, FeeType: FeeType, ChargeID: ChargeID, RoomIDList: JSON.stringify(RoomIDs), canrent: canrent, RentToTime: RentToTime };
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                if (data.MonthInvalid) {
                    show_message('请重新填写收费周期', 'info');
                    return;
                }
                if (data.PriceMonthInvalid) {
                    show_message('请重新填写调价周期', 'info');
                    return;
                }
                if (data.StartTimeInvalid) {
                    show_message('合同开始日期不合法', 'info');
                    return;
                }
                if (data.EndTimeInvalid) {
                    show_message('合同截止日期不合法', 'info');
                    return;
                }
                saveDataProcess();
                return;
            }
        }
    });
}
function doEditRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一行", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一行进行修改", "info");
        return;
    }
    if (endEditing()) {
        editIndex = $('#tt_table').datagrid('getRowIndex', rows[0]);
        $('#tt_table').datagrid('selectRow', editIndex).datagrid('beginEdit', editIndex);
        var time = checktime(rows[0].CalculateStartTime);
        if (time == "") {
            $('#tt_table').datagrid('getEditor', { index: editIndex, field: 'CalculateStartTime' }).target.datebox("setValue", "");
        }
        time = checktime(rows[0].CalculateEndTime);
        if (time == "") {
            $('#tt_table').datagrid('getEditor', { index: editIndex, field: 'CalculateEndTime' }).target.datebox("setValue", "");
        }
        time = checktime(rows[0].ReadyChargeTime);
        if (time == "") {
            $('#tt_table').datagrid('getEditor', { index: editIndex, field: 'ReadyChargeTime' }).target.datebox("setValue", "");
        }
        $('#tt_table').datagrid('getEditor', { index: editIndex, field: 'CalculateCost' }).target.datebox('disable', true);
        return;
        if (FeeType == 4) {
            $('#tt_table').datagrid('getEditor', { index: editIndex, field: 'CalculatePrice' }).target.datebox('disable', true);
        }
        else {
            $('#tt_table').datagrid('getEditor', { index: editIndex, field: 'CalculateCost' }).target.datebox('disable', true);
        }
    }
}
function checktime(time) {
    if (time == undefined || time == "" || time == null || time == '0001-01-01T00:00:00.0000000' || time == '0001-01-01T00:00:00' || time == '1900-01-01T00:00:00.0000000' || time == '1900-01-01T00:00:00') {
        return "";
    }
    return time.substring(0, 16).split("T")[0];
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
function doRemoveRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一行", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        if (Number(row.ID) > 0) {
            IDList.push(row.ID);
        }
    })
    if (IDList.length == 0) {
        $('#tt_table').datagrid('reload');
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'removecontracttempprice', IDList: JSON.stringify(IDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                $('#tt_table').datagrid('reload');
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}

