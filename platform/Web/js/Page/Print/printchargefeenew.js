function savedata() {
    saveprocess(1);
}
function printpage() {
    saveprocess(2);
}
function change_input_status() {
    ChargeMan.textbox({
        readonly: true
    });
    ChargeTime.datetimebox({
        readonly: true
    });
    ChargeMoneyType1.combobox({
        readonly: true
    });
    ChargeMoneyType2.combobox({
        readonly: true
    });
    RealMoneyCost1.prop('readonly', 'readonly');
    RealMoneyCost2.prop('readonly', 'readonly');
    DiscountMoney.prop('readonly', 'readonly');
}
var save_count = 0;
function saveprocess(type) {//1-保存 2-打印收据 3-打印发票
    var pop_msg = "保存成功";
    if (save_count > 0) {
        if (type == 1) {
            show_message("单据已保存", "info");
            return;
        }
        if (type == 2) {
            startPrint();
        }
        if (type == 3) {
            show_message("电子发票已创建", "info");
            return;
        }
        return;
    }
    var printinvoice = (type == 2);
    var printcheque = (type == 3);
    var postList = [];
    if (PrintIDList.length == 0) {
        $.each(dataList, function (index, data) {
            var PrintNumber = $('#' + index + '_tdPrintNumber').val();
            var ChargeMan = '';
            if ($('#' + index + '_tdChargeMan')) {
                ChargeMan = $('#' + index + '_tdChargeMan').val();
            }
            ChargeMan = ChargeMan || data.ChargeMan;
            var ChargeTime = '';
            if ($('#' + index + '_tdChargeTime')) {
                ChargeTime = $('#' + index + '_tdChargeTime').datetimebox('getValue');
            }
            ChargeTime = ChargeTime || data.ChargeTime;
            var RealMoneyCost1 = $('#' + index + '_tdRealMoneyCost1').val();
            var ChargeMoneyType1 = $('#' + index + '_tdChargeMoneyType1').combobox('getValue');
            var RealMoneyCost2 = 0;
            if ($('#' + index + '_tdRealMoneyCost2')) {
                RealMoneyCost2 = $('#' + index + '_tdRealMoneyCost2').val();
            }
            var ChargeMoneyType2 = 0;
            if ($('#' + index + '_tdChargeMoneyType2')) {
                ChargeMoneyType2 = $('#' + index + '_tdChargeMoneyType2').combobox('getValue');
            }
            var Remark = $('#' + index + '_tdRemark').val();
            var RoomFullName = $('#' + index + '_tdRoomFullName').val();
            var RoomOwnerName = $('#' + index + '_tdRoomOwnerName').val();
            var PrintTitle = $('#' + index + 'tdFirstTitle').val();
            var dataItem = { PrintID: 0, PrintNumber: PrintNumber, RealCost: data.RealCost, PreChargeMoney: 0, ChargeBackMoney: 0, ChargeMan: ChargeMan, ChargeTime: ChargeTime, RealMoneyCost1: RealMoneyCost1, ChargeMoneyType1: ChargeMoneyType1, RealMoneyCost2: RealMoneyCost2, ChargeMoneyType2: ChargeMoneyType2, DiscountMoney: 0, Remark: Remark, TempHistoryIDs: data.TempHistoryIDs, money: data.money, MoneyDaXie: data.MoneyDaXie, OrderNumberID: data.OrderNumberID, RoomFullName: RoomFullName, RoomOwnerName: RoomOwnerName, WeiShuBalance: data.totalbalance, doprint: printinvoice, TotalCost: data.TotalCost, PrintTitle: PrintTitle, PrintSubTitle: data.SubTitle, printcheque: printcheque, RelationID: 0 };
            postList.push(dataItem);
        })
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'saveprintfeenew', PrintIDList: JSON.stringify(PrintIDList), dataList: JSON.stringify(postList), TempHistoryIDs: TempHistoryIDs };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                save_count++;
                PrintIDList = message.PrintIDList;
                if (type == 1) {
                    show_message('保存成功', 'success');
                }
                if (type == 2) {
                    startPrint();
                }
                if (type == 3) {
                    show_message('电子发票创建成功', 'success');
                }
            }
            else if (message.error) {
                show_message(message.error, 'warning');
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function cancelFee() {
    var options = { visit: 'cancelprintfee', TempHistoryIDs: TempHistoryIDs };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            parent.do_close_dialog(function () {
                parent.do_close_printchargefee();
            }, true);
        }
    });
}
function loadchargesummarytype() {
    var options = { visit: 'loadchargesummarytype' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            ChargeMoneyType1.combobox({
                editable: false,
                data: data.list,
                valueField: 'ChargeTypeID',
                textField: 'ChargeTypeName',
            });
            ChargeMoneyType1.combobox("setValue", 0);
            ChargeMoneyType2.combobox({
                editable: false,
                data: data.list,
                valueField: 'ChargeTypeID',
                textField: 'ChargeTypeName',
            });
            ChargeMoneyType2.combobox("setValue", 0);
        }
    });
}
function closeWin() {
    parent.$("#winprint").window("close");
}
function printcheque() {
    var iframe = "../PrintPage/PrintChequeView.aspx?RoomID=" + RoomID + "&DefaultRelationID=" + DefaultRelationID + "&ContractID=" + ContractID;
    do_open_dialog('打印发票预览', iframe);
}
var RelationID = 0;
function do_print_cheque_process() {
    saveprocess(3);
}