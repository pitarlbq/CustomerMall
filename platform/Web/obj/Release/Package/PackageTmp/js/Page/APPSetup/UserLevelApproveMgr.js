var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/MallHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
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
            $('#tt_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'RequestTime', formatter: formatDateTime, title: '申请时间', width: 100 },
        { field: 'FinalUserName', title: '申请用户', width: 100 },
        { field: 'FinalPhoneNumber', title: '电话号码', width: 100 },
        { field: 'LevelName', title: '合伙人等级', width: 200 },
        { field: 'FinalIncomingAmount', title: '充值金额', width: 100 },
        { field: 'IncomingWay', title: '充值类型', width: 100 },
        { field: 'FinalyPaymentMethod', title: '充值方式', width: 100 },
        { field: 'FinalyIncomingTime', title: '充值时间', width: 100 },
        { field: 'DealManName', title: '经办人', width: 100 },
        { field: 'ApproveStatusDesc', title: '审核状态', width: 300 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var status = $("#tdApproveStatus").combobox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmalluserlevelapprovegrid",
        "keywords": keywords,
        "status": status
    });
}
function do_approve() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个用户等级进行此操作', 'warning');
        return;
    }
    if (rows.length > 1) {
        show_message('请选择单行进行此操作', 'warning');
        return;
    }
    if (rows[0].ApproveStatus != 0) {
        show_message('请选择待审核的数据进行此操作', 'warning');
        return;
    }
    var iframe = "../APPSetup/UserLevelApprove.aspx?ID=" + rows[0].ID;
    do_open_dialog('审核合伙人', iframe);
}
function do_add() {
    var iframe = "../APPSetup/UserLevelApproveEdit.aspx";
    do_open_dialog('新增', iframe);
}
function do_edit() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个用户等级进行此操作', 'warning');
        return;
    }
    if (rows.length > 1) {
        show_message('请选择单行进行此操作', 'warning');
        return;
    }
    if (!rows[0].IsManualIncoming) {
        show_message('合伙人申请为线上申请，禁止修改', 'warning');
        return;
    }
    if (rows[0].ApproveStatus == 0) {
        show_message('合伙人申请已提交审核', 'warning');
        return;
    }
    if (rows[0].ApproveStatus == 1 || rows[0].ApproveStatus == 2) {
        show_message('合伙人申请已审核', 'warning');
        return;
    }
    var iframe = "../APPSetup/UserLevelApproveEdit.aspx?ID=" + rows[0].ID;
    do_open_dialog('修改', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请选择数据', 'warning');
        return;
    }
    var IDList = [];
    var online_request = false;
    var approve_start = false;
    var approve_done = false;
    $.each(rows, function (index, row) {
        if (!row.IsManualIncoming) {
            online_request = true;
            return false;
        }
        if (row.ApproveStatus == 0) {
            approve_start = true;
            return false;
        }
        if (row.ApproveStatus == 1) {
            approve_done = true;
            return false;
        }
        IDList.push(row.ID);
    })

    if (online_request) {
        show_message('合伙人申请为线上申请', 'warning');
        return;
    }
    if (approve_start) {
        show_message('合伙人申请已提交审核', 'warning');
        return;
    }
    if (approve_done) {
        show_message('合伙人申请已审核', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的数据", function (r) {
        if (r) {
            var options = { visit: 'removeuserlevelapprove', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_approve_request() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请选择数据', 'warning');
        return;
    }
    var IDList = [];
    var online_request = false;
    var approve_start = false;
    var approve_done = false;
    $.each(rows, function (index, row) {
        if (!row.IsManualIncoming) {
            online_request = true;
            return false;
        }
        if (row.ApproveStatus == 0) {
            approve_start = true;
            return false;
        }
        if (row.ApproveStatus == 1 || row.ApproveStatus == 2) {
            approve_done = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (online_request) {
        show_message('合伙人申请为线上申请', 'warning');
        return;
    }
    if (approve_start) {
        show_message('合伙人申请已提交审核', 'warning');
        return;
    }
    if (approve_done) {
        show_message('合伙人申请已审核', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "是否提交审核选中的数据", function (r) {
        if (r) {
            var options = { visit: 'startapproveuserlevelapprove', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}

