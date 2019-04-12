$(function () {
    loadchargesummarytype();
    RealMoneyCost1.bind('input propertychange', function () {
        calculateByRealMoneyCost1();
    });
    RealMoneyCost2.bind('input propertychange', function () {
        calculateByRealMoneyCost2();
    });
})
function calculateByRealMoneyCost1() {
    var realmoneycost = RealMoneyCost1.val();
    var balance = parseFloat(RealCost) - parseFloat(realmoneycost);
    RealMoneyCost2.val(balance.toFixed(2));
}
function calculateByRealMoneyCost2() {
    var realmoneycost = RealMoneyCost2.val();
    var balance = parseFloat(RealCost) - parseFloat(realmoneycost);
    RealMoneyCost1.val(balance.toFixed(2));
}
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
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'saveprintfee', PrintID: PrintID, PrintNumber: PrintNumber.val(), RealCost: RealCost, PreChargeMoney: PreChargeMoney.val(), ChargeBackMoney: ChargeBackMoney.val(), ChargeMan: ChargeMan.val(), ChargeTime: ChargeTime.datetimebox("getValue"), RealMoneyCost1: RealMoneyCost1.val(), ChargeMoneyType1: ChargeMoneyType1.combobox("getValue"), RealMoneyCost2: RealMoneyCost2.val(), ChargeMoneyType2: ChargeMoneyType2.combobox("getValue"), DiscountMoney: DiscountMoney.val(), Remark: Remark.val(), AddMan: AddMan, TempHistoryIDs: TempHistoryIDs, money: money, MoneyDaXie: MoneyDaXie, OrderNumberID: hdOrderNumberID.val(), RoomFullName: RoomFullName.val(), RoomOwnerName: RoomOwnerName.val(), WeiShuBalance: tdWeiShu.text(), doprint: printinvoice, TotalCost: TotalCost, PrintTitle: tdFirstTitle.val(), PrintSubTitle: tdSubTitle.text(), printcheque: printcheque, RelationID: RelationID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                save_count++;
                change_input_status();
                PrintID = message.PrintID;
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