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
        { field: 'MsgTitle', title: '标题', width: 100 },
        { field: 'IsShowDesc', title: '是否显示', width: 100 },
        { field: 'PublishTime', formatter: formatDateTime, title: '发布日期', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
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
        "msgtype": "huodong",
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs)
    });
}
function addRow() {
    var iframe = "../Wechat/EditMsg.aspx?MsgType=huodong";
    do_open_dialog('新增活动', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个通知进行此操作", "info");
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
    var iframe = "../Wechat/EditMsg.aspx?ID=" + row.ID + "&MsgType=huodong";
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