var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onDblClickRow: onDblClickRowTT,
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
        },
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'ActivityName', formatter: formatDateTime, title: '活动名称', width: 150 },
        { field: 'MerchantName', title: '商户名称', width: 100 },
        { field: 'TypeDesc', title: '活动类型', width: 100 },
        { field: 'RepeatDesc', title: '参与方式', width: 100 },
        { field: 'RepeatTime', title: '重复参与次数', width: 100 },
        { field: 'ParticipantNumber', title: '预估参与人次', width: 100 },
        { field: 'UserLimiteDesc', title: '限制参与人员', width: 100 },
        { field: 'NoLimitMsg', title: '限制参与提示语', width: 150 },
        { field: 'StartTime', formatter: formatDateTime, title: '开始时间', width: 150 },
        { field: 'EndTime', formatter: formatDateTime, title: '结束时间', width: 150 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getlotteryactivitygrid",
        "keywords": keywords
    });
}
function addRow() {
    var iframe = "../Wechat/EditLotteryActivity.aspx";
    do_open_dialog('新增活动', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个活动进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    EditDataByRow(rows[0]);
}
function onDblClickRowTT(index, row) {
    EditDataByRow(row)
}
function EditDataByRow(row) {
    var iframe = "../Wechat/EditLotteryActivity.aspx?ID=" + row.ID;
    do_open_dialog('修改活动', iframe);
}
function removeRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择需要删除的数据', 'info');
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    top.$.messager.confirm('提示', '确认要删除选中的活动?', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'deletelotteryactivity', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('删除成功', 'success');
                        $("#tt_table").datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}
function editPrize() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个活动进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../Wechat/LotteryPrizeMgr.aspx?ActivityID=" + rows[0].ID;
    do_open_dialog('奖项管理', iframe);
}
function viewPrizeUser() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个活动进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../Wechat/LotteryPrizeRecordMgr.aspx?ActivityID=" + rows[0].ID;
    do_open_dialog('中奖查看', iframe);
}
function viewUsers() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个活动进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../Wechat/LotteryUserMgr.aspx?ActivityID=" + rows[0].ID;
    do_open_dialog('参与人员', iframe);
}
function editSendPrizeUser() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个活动进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../Wechat/LotteryCheckerMgr.aspx?ActivityID=" + rows[0].ID;
    do_open_dialog('发奖人员', iframe);
}
function viewQrCode() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个活动进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var pageurl = '/WeiXin/LotteryRedirect.aspx?ID=' + rows[0].ID;
    var iframe = "../Wechat/ViewQrCodeByURL.aspx?pageurl=" + pageurl;
    do_open_dialog('微信二维码', iframe);
}
