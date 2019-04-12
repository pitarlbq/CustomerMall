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
        fitColumns: true,
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
        { field: 'PublishTime', formatter: formatDateTime, title: '发布日期', width: 150 },
        { field: 'MsgTitle', title: '标题', width: 150 },
        { field: 'StartTime', formatter: formatStartTime, title: '有效期', width: 150 },
        { field: 'IsInvalidDesc', title: '是否失效', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function formatStartTime(value, row) {
    var startime = formatDateTime(row.StartTime, row);
    var endtime = formatDateTime(row.EndTime, row);
    if (startime != '--' && endtime != '--') {
        return startime + " 至 " + endtime;
    }
    if (startime != '--') {
        return startime + " 至 " + "无";
    }
    if (endtime != '--') {
        return "无" + " 至 " + endtime;
    }
    return "--";
}
function formatIsInvalid(value, row) {
    var time = formatDateTime(row.EndTime, row);
    if (time != '--') {
        var date = new Date(time.replace(/-/g, "/").replace("T", " "));
        var newDate = new Date();
        if (date < newDate) {
            return '失效';
        }
    }
    return '有效';
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var RoomIDs = [];
    var ProjectIDs = [];
    try {
        RoomIDs = GetSelectedRooms();
        ProjectIDs = GetSelectedProjects();
    } catch (e) {

    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmsglist",
        "keywords": keywords,
        "type": 0,
        "msgtypeid": msgtypeid,
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs)
    });
}
function addRow() {
    var iframe = "../Wechat/EditMsg.aspx?type=" + type + "&msgtypeid=" + msgtypeid;
    do_open_dialog('新增通知', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
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
    if (CanEdit != 1) {
        return;
    }
    var iframe = "../Wechat/EditMsg.aspx?ID=" + row.ID + "&type=" + type + "&msgtypeid=" + msgtypeid;
    do_open_dialog('修改通知', iframe);
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
    top.$.messager.confirm('提示', '确认要删除选中的数据?', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'deletemsg', IDList: JSON.stringify(IDList) };
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
function connectRoom() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个通知进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../Wechat/ConnectMsgRoom.aspx?MsgID=" + rows[0].ID;
    do_open_dialog('资源绑定', iframe);
}
function ConnectMsgRoom_Done() {
    $("#tt_table").datagrid("reload");
}
function sendNotify() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择需要发送的通知', 'info');
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    top.$.messager.confirm('提示', '确认发送?', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'sendweixinmsg', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message("发送成功", "success");
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
function chooseUser() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个通知进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../Wechat/ChooseWechatUserMgr.aspx?MsgID=" + rows[0].ID
    do_open_dialog('通知对象', iframe);
}
function do_push() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    if (rows[0].ValidStatus != 1) {
        show_message("请选择有效的数据进行此操作", "info");
        return;
    }
    top.$.messager.confirm('提示', '确认发送APP推送消息?', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'jpushappwechatmsg', ID: rows[0].ID, type: type };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message("推送成功", "success");
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
