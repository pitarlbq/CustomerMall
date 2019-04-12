$(function () {
    loadchargesummarytype();
    window.onsubmit = false;
})
function savedata() {
    saveprocess(true);
}
function saveprocess(popup) {
    if (window.onsubmit) {
        show_message("请不要重复提交", "info");
        return;
    }
    window.onsubmit = true;
    var list = getAllItems();
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'chargepayservice', AddMan: AddMan, PrintNumber: PrintNumber.val(), ChargeMan: ChargeMan.val(), ChargeTime: ChargeTime.datetimebox("getValue"), Remark: Remark.val(), Cost: Cost, ChargeMoneyType: $("#tbChargeMoneyType").combobox("getValue"), FullName: FullName, MoneyDaXie: MoneyDaXie, OrderNumberID: hdOrderNumberID.val(), RoomFullName: RoomFullName.val(), RoomOwnerName: RoomOwnerName.val(), TempHistoryID: TempHistoryID, PayServiceID: PayServiceID, PrintTitle: tdFirstTitle.text(), PrintSubTitle: tdSubTitle.text(), itemlist: JSON.stringify(list) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/PrintHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            window.onsubmit = false;
            if (data.status) {
                PrintID = data.PrintID;
                if (popup) {
                    show_message('保存成功', 'success');
                }
                else {
                    printpage();
                }
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function getAllItems() {
    var list = [];
    var datalist = $('.backremark');
    $.each(datalist, function (index) {
        var index = $(this).attr("data-index");
        var ChargeTime = $.trim($('#chargetime_' + index).text());
        var ChargeName = $.trim($('#chargename_' + index).text());
        var RealCost = $.trim($('#realcost_' + index).text());//parseFloat($(this).val());
        var Remark = $(this).val();
        var BackGuaranteeRemark = $('#backremark_' + index).val();
        var HistoryID = $.trim($(this).attr("data-id"));
        list.push({ ChargeTime: ChargeTime, ChargeName: ChargeName, RealCost: RealCost, Remark: Remark, HistoryID: HistoryID, BackGuaranteeRemark: BackGuaranteeRemark });
    })
    return list;
}
function loadchargesummarytype() {
    var options = { visit: 'loadchargesummarytype' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            $("#tbChargeMoneyType").combobox({
                editable: false,
                data: data.list,
                valueField: 'ChargeTypeID',
                textField: 'ChargeTypeName',
            });
            $("#tbChargeMoneyType").combobox("setValue", hdChargeMoneyType.val());
        }
    });
}
function closeWin() {
    parent.$('#winprint').window('close');
}