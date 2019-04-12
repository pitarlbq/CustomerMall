$(function () {
    autoCalculateRestBalance();
    loadchargesummarytype();
})
function autoCalculateRestBalance() {
    $('.realcost').change(function () {
        var index = $(this).attr("data-index");
        var realcost = parseFloat($(this).val());
        var totalbalance = parseFloat($('#totalbalance_' + index).text());
        if (realcost > totalbalance) {
            realcost = totalbalance;
            $(this).val(totalbalance);
        }
        var restbalance = totalbalance - realcost;
        $('#restbalance_' + index).text(toThousands(restbalance));
        $('#restbalance_' + index).attr('data-value', restbalance.toFixed(4));
        Cost = realcost;
        $('#TotalCost').text(toThousands(Cost));
    });
}
function getAllItems() {
    var list = [];
    var datalist = $('.realcost');
    $.each(datalist, function (index) {
        var index = $(this).attr("data-index");
        var ChargeFeeSummaryName = $.trim($('#summaryname_' + index).text());
        var ChargeFeeCurrentBalance = $.trim($('#totalbalance_' + index).text());
        var RealCost = parseFloat($(this).val());
        var TotalRestBalance = $.trim($('#restbalance_' + index).attr('data-value'));
        var Remark = $('#remark_' + index).val();
        list.push({ ChargeFeeSummaryName: ChargeFeeSummaryName, ChargeFeeCurrentBalance: parseFloat(ChargeFeeCurrentBalance), RealCost: parseFloat(RealCost), TotalRestBalance: parseFloat(TotalRestBalance), Remark: Remark });
    })
    return list;
}
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
    var options = { visit: 'cancelprefee', AddMan: AddMan, PrintID: PrintID, PrintNumber: PrintNumber.val(), ChargeMan: ChargeMan.val(), ChargeTime: ChargeTime.datetimebox("getValue"), Remark: Remark.val(), Cost: Cost, ChargeMoneyType: $("#tbChargeMoneyType").combobox("getValue"), FullName: FullName, MoneyDaXie: MoneyDaXie, OrderNumberID: hdOrderNumberID.val(), RoomFullName: RoomFullName.val(), RoomOwnerName: RoomOwnerName.val(), itemlist: JSON.stringify(list), RoomIDs: RoomIDs, ChargeID: ChargeID, doprint: !popup };
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
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
                    startPrint();
                }
            }
            else {
                show_message('系统错误', 'error');
            }
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
function cancelFee() {
    parent.do_close_dialog(function () {
        parent.$('#tt_table').datagrid('reload');
    });
}