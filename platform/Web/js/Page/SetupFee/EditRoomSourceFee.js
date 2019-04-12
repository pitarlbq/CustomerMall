
$(function () {
    loadChargeTypeCombox();
    loadChargeNameCombox();
    if (op == "edit") {
        ChargeNameObj.combobox({
            disabled: true
        });

    }
})
function loadChargeNameCombox() {
    var options = { visit: "loadchargesummarylist" };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                ChargeNameObj.combobox({
                    editable: false,
                    data: data.list,
                    valueField: 'ID',
                    textField: 'Name',
                });
                if (HDChargeNameObj.val() != "") {
                    ChargeNameObj.combobox("setValue", HDChargeNameObj.val());
                }
            }
        }
    });
}
function loadChargeTypeCombox() {
    ChargeTypeObj.combobox({
        editable: false,
        data: getChargeTypeList(),
        valueField: 'ID',
        textField: 'Name',
    });
    if (hdChargeTypeObj.val() != "") {
        ChargeTypeObj.combobox("setValue", hdChargeTypeObj.val());
    }
}
function do_save() {
    var ChargeSummaryID = ChargeNameObj.combobox("getValue");
    var UnitPrice = UnitPriceObj.numberbox("getValue");
    var ChargeType = ChargeTypeObj.combobox("getValue");
    var StartTime = StartTimeObj.datebox("getValue");
    var EndTime = EndTimeObj.datebox("getValue");
    var NewEndTime = NewEndTimeObj.datebox("getValue");
    var Remark = RemarkObj.textbox("getValue");
    MaskUtil.mask('body', '提交中');
    var options = { visit: "saveroomsourcefee", ChargeSummaryID: ChargeSummaryID, UnitPrice: UnitPrice, TypeID: ChargeType, StartTime: StartTime, EndTime: EndTime, Remark: Remark, ID: ID, op: op, NewEndTime: NewEndTime };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                show_message('保存成功', 'success', function () {
                    do_close();
                });
            }
            else if (data.msg) {
                show_message(data.msg, "warning");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function do_close() {
    parent.do_close_dialog(function () {
        parent.$('#tt_table').datagrid('reload');
    });
}