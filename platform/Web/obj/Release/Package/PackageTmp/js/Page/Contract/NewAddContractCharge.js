var tt_CanLoad, FeeType = 0, CategoryID = 0, content = null, calculateTypeList = [];
$(function () {
    tt_CanLoad = false;
    try {
        canrent = parent.canrent;
        RentToTime = parent.tdRentToTime.datebox('getValue');
    } catch (e) {

    }
    getAllParams();
    load_vue();
    tdCalculateTypeOn.bind('click', function () {
        getCalculateTypeChangeStatus();
    })
    getCalculateTypeChangeStatus();
});
function getCalculateTypeChangeStatus() {
    if (tdCalculateTypeOn.prop('checked')) {
        $('#calculateBox').show();
    } else {
        $('#calculateBox').hide();
    }
}
function load_vue() {
    content = new Vue({
        el: '#fieldcontent',
        data: {
            list: [],
            count: 0,
            currentitem: null
        },
        methods: {
            getdata: function () {
                var that = this;
                if (ContractID <= 0) {
                    return;
                }
                var options = { visit: 'getcontractfreetime', ContractID: ContractID };
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/ContractHandler.ashx',
                    data: options,
                    success: function (data) {
                        if (data.status) {
                            that.list = data.list;
                            that.count = that.list.length;
                            that.reset_easyui(true);
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            reset_easyui_box: function (index) {
                var that = this;
                var elemCalculateType = $('#' + index + '_CalculateType');
                if (elemCalculateType) {
                    elemCalculateType.addClass('easyui-combobox');
                }
                var elemCalculateMonthType = $('#' + index + '_CalculateMonthType');
                if (elemCalculateMonthType) {
                    elemCalculateMonthType.addClass('easyui-combobox');
                }
                var elemFirstReadyChargePriceTime = $('#' + index + '_FirstReadyChargePriceTime');
                if (elemFirstReadyChargePriceTime) {
                    elemFirstReadyChargePriceTime.addClass('easyui-datebox');
                }
                var elemLastReadyChargePriceTime = $('#' + index + '_LastReadyChargePriceTime');
                if (elemLastReadyChargePriceTime) {
                    elemLastReadyChargePriceTime.addClass('easyui-datebox');
                }
                $.parser.parse('#tr_' + index);
                elemCalculateMonthType.combobox({
                    onSelect: function () {
                        that.set_list_value();
                    }
                })
                elemCalculateType.combobox({
                    onSelect: function () {
                        that.set_list_value();
                    }
                })
                elemFirstReadyChargePriceTime.datebox({
                    onSelect: function () {
                        that.set_list_value();
                    }
                })
                elemLastReadyChargePriceTime.datebox({
                    onSelect: function () {
                        that.set_list_value();
                    }
                })
            },
            reset_easyui: function (alllist) {
                var that = this;
                that.set_box_value();
                if (alllist) {
                    setTimeout(function () {
                        for (var i = 0; i < that.list.length; i++) {
                            var index = that.list[i].count;
                            that.reset_easyui_box(index);
                        }
                    }, 200);
                    return;
                }
                setTimeout(function () {
                    var index = that.count;
                    that.reset_easyui_box(index);
                }, 200);
            },
            set_box_value: function () {
                var that = this;
                setTimeout(function () {
                    $.each(that.list, function (index, item) {
                        $('#' + item.count + '_CalculateType').combobox('setValue', item.CalculateType);
                        $('#' + item.count + '_CalculateMonthType').combobox('setValue', item.CalculateMonthType);
                        $('#' + item.count + '_FirstReadyChargePriceTime').datebox('setValue', item.FirstReadyChargePriceTime);
                        $('#' + item.count + '_LastReadyChargePriceTime').datebox('setValue', item.LastReadyChargePriceTime);
                    });
                    that.set_list_value();
                }, 500);
            },
            add_line: function () {
                var that = this;
                that.count++;
                var item = { ID: 0, CalculateType: 'percent', CalcualtePriceMonth: '', FirstReadyChargePriceTime: '', LastReadyChargePriceTime: '', CalculateValue: '', count: that.count, valueunit: '%', CalculateMonthType: 1 };
                that.list.push(item);
                that.reset_easyui();
            },
            set_list_value: function () {
                var that = this;
                $.each(that.list, function (index, item) {
                    item.CalculateType = $('#' + item.count + '_CalculateType').combobox('getValue');
                    item.CalculateMonthType = $('#' + item.count + '_CalculateMonthType').combobox('getValue');
                    item.FirstReadyChargePriceTime = $('#' + item.count + '_FirstReadyChargePriceTime').datebox('getValue');
                    item.LastReadyChargePriceTime = $('#' + item.count + '_LastReadyChargePriceTime').datebox('getValue');
                    if (item.CalculateType == 'amount') {
                        item.valueunit = '元';
                    } else {
                        item.valueunit = '%';
                    }
                });
            },
            remove_line: function (item) {
                var that = this;
                if (item.ID == 0) {
                    $.each(that.list, function (index, item2) {
                        if (item.count == item2.count) {
                            that.list.splice(index, 1);
                            return false;
                        }
                    });
                    that.set_box_value();
                    return;
                }
                top.$.messager.confirm('提示', '确认删除?', function (r) {
                    if (r) {
                        var options = { visit: 'removecontractfreetime', ID: item.ID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/ContractHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    $.each(that.list, function (index, item2) {
                                        if (item.count == item2.count) {
                                            that.list.splice(index, 1);
                                            return false;
                                        }
                                    });
                                    that.set_box_value();
                                    return;
                                }
                                show_message('系统错误', 'error');
                            }
                        });
                    }
                })
            }
        }
    });
    content.getdata();
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
                    textField: 'Name'
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
                            $('.AutoChangePrice').show();
                            $('#pricetable').show();
                            $('#calculateBox').show();
                            $('#btnTempPrice').show();
                            getCalculateTypeChangeStatus();
                            loadTT();
                        } else {
                            $('.AutoChangePrice').hide();
                            $('#pricetable').hide();
                            $('#btnTempPrice').hide();
                            $('#calculateBox').hide();
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
    var FirstStartTime = $('#tdFirstStartTime').datebox('getValue');
    var options = { visit: 'savecontractcharge', RoomIDs: JSON.stringify(RoomIDs), ChargeIDList: JSON.stringify(ChargeIDList), guid: guid, ContractID: ContractID, RoomName: RoomName, RoomUnitPrice: RoomUnitPrice, canedit: canedit, FirstReadyChargeTime: FirstReadyChargeTime, canrent: canrent, FirstStartTime: FirstStartTime };
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
            { field: 'CalcualteTotalCost', editor: 'textbox', title: '金额', width: 100 },
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
    if (parseFloat(row.CalcualteTotalCost) <= 0) {
        row.CalcualteTotalCost = 0;
    }
    return row.CalcualteTotalCost;
}
function SearchTT() {
    tt_CanLoad = true;
    var ChargeID = $('#tdChargeID').combobox("getValue");
    $("#tt_table").datagrid("load", {
        "visit": "loadcontractemppricegrid",
        "guid": guid,
        "ChargeID": ChargeID,
        "ContractID": ContractID
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
    var FirstStartTime = $('#tdFirstStartTime').datebox('getValue');
    var FirstReadyChargeDay = $('#tdFirstReadyChargeDay').textbox('getValue');
    var RoomUnitPrice = $('#tdRoomUnitPrice').textbox('getValue');
    var CalculateMonth = 0;
    calculateTypeList = [];
    if (FeeType == 1) {
        CalculateMonth = $('#tdCalculateMonth').textbox('getValue');
        if (CalculateMonth == '' && CategoryID != 4 && FeeType != 4) {
            show_message('请填写收费周期', 'info');
            return;
        }
        var isTrue = checkCalculateTypeStatus();
        if (!isTrue) {
            return;
        }
    }
    else if (RowList.length == 0) {
        saveDataProcess();
        return;
    }
    var ChargeID = $('#tdChargeID').combobox("getValue");
    var RoomIDs = $('#tdRoomID').combobox("getValues");
    var options = { visit: 'addcontracttemppricelistnew', TempList: JSON.stringify(RowList), RoomUnitPrice: RoomUnitPrice, CalculateMonth: CalculateMonth, StartTime: StartTime, EndTime: EndTime, guid: guid, CategoryID: CategoryID, CalculateTypeList: JSON.stringify(calculateTypeList), FeeType: FeeType, ChargeID: ChargeID, RoomIDList: JSON.stringify(RoomIDs), canrent: canrent, RentToTime: RentToTime, FirstReadyChargeTime: FirstReadyChargeTime, FirstStartTime: FirstStartTime, FirstReadyChargeDay: FirstReadyChargeDay };
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                if (data.error) {
                    show_message(data.error, 'warning');
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
function checkCalculateTypeStatus() {
    calculateTypeList = [];
    if (content.list.length == 0) {
        return true;
    }
    var isTrue = true;
    $.each(content.list, function (index, item) {
        if (item.CalcualtePriceMonth == '') {
            show_message('请填写调调价周期', 'warning');
            isTrue = false;
            return false;
        }
        if (item.FirstReadyChargePriceTime == '') {
            show_message('请填写调价开始日期', 'warning');
            isTrue = false;
            return false;
        }
        if (item.LastReadyChargePriceTime == '') {
            show_message('请填写调价结束日期', 'warning');
            isTrue = false;
            return false;
        }
        if (item.CalculateValue == '') {
            show_message('调价比例/金额', 'warning');
            isTrue = false;
            return false;
        }
        var startTime = stringToDate(item.FirstReadyChargePriceTime);
        var endTime = stringToDate(item.LastReadyChargePriceTime);
        if (startTime > endTime) {
            show_message('请填写调价开始日期不能大于请填写调价结束日期', 'warning');
            isTrue = false;
            return false;
        }
        $.each(content.list, function (index2, item2) {
            if (item2.FirstReadyChargePriceTime == '') {
                return true;
            }
            if (item2.LastReadyChargePriceTime == '') {
                return true;
            }
            var startTime2 = stringToDate(item2.FirstReadyChargePriceTime);
            var endTime2 = stringToDate(item2.LastReadyChargePriceTime);
            if (endTime >= startTime2 && endTime <= endTime2 && index != index2) {
                show_message('请填写调价开始与结束日期冲突', 'warning');
                isTrue = false;
                return false;
            }
        })
        if (!isTrue) {
            return false;
        }
        calculateTypeList.push(item);
    })
    return isTrue;
}

