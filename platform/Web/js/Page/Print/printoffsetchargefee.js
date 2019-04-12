
function savedata() {
    saveprocess(true);
}
function saveprocess(popup) {
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'saveprintfee', PrintID: PrintID, PrintNumber: PrintNumber.val(), RealCost: money, PreChargeMoney: 0, ChargeBackMoney: 0, ChargeMan: ChargeMan.val(), ChargeTime: ChargeTime.datetimebox("getValue"), RealMoneyCost1: money, ChargeMoneyType1: 3, RealMoneyCost2: 0, ChargeMoneyType2: 0, DiscountMoney: 0, Remark: Remark.val(), AddMan: AddMan, TempHistoryIDs: TempHistoryIDs, money: money, MoneyDaXie: MoneyDaXie, OrderNumberID: hdOrderNumberID.val(), RoomFullName: RoomFullName.val(), RoomOwnerName: RoomOwnerName.val(), ChargeForSummary: ChargeForSummary.combobox('getValue'), ChargeMethods: ChargeMethods.combobox('getValue'), ischongxiao: true, doprint: !popup, PrintTitle: tdFirstTitle.val(), PrintSubTitle: tdSubTitle.text(), TotalCost: Cost };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                PrintID = message.PrintID;
                if (popup) {
                    show_message('保存成功', 'success');
                }
                else {
                    startPrint();
                }
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
            do_close();
        }
    });
}
function do_close() {
    parent.do_close_dialog(function () {
        parent.chargechongdiroomfee_done();
    });
}