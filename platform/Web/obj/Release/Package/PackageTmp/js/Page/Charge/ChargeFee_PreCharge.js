$(function () {
    loadprechargeList();
    SearchPre();
})
function get_options() {
    var idarry = parent.GetRoomIDList();
    if (idarry.length == 0) {
        //show_message("请选择一个房间", "warning");
        return;
    }
    if (idarry.length > 1) {
        //show_message("请选择单个房间进行操作", "warning");
        return;
    }
    var url = '../Handler/FeeCenterHandler.ashx?currentcount=0';
    $("#tt_table").datagrid("options").url = url;
    var options = {
        "visit": "loadroomfeelist",
        "RoomID": JSON.stringify(idarry),
        "CategoryID": 0,
        "PreChargeID": ChargeID
    };
    return options;
}
function chargechongdiroomfee() {
    dochargechongdiroomfee(ChargeID, 2);
}
function chargechongdiroomfee_done() {
    $('#tt_table').datagrid("reload");
    parent.GetBalance(ChargeID);
}
function chargebackprefee() {
    var idarry = parent.GetRoomIDList();
    if (idarry.length == 0) {
        show_message("请选择一个房间", "warning");
        return;
    }
    var roomids = JSON.stringify(idarry);
    var iframe = "../PrintPage/printchargebackprefee.aspx?RoomIDs=" + roomids + "&ChargeID=" + ChargeID;
    do_open_dialog('退预收款', iframe);
}
