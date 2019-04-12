var tt_CanLoad = false;
$(function () {
    loadTT();
});
function get_columns() {
    var columns = [];
    columns.push({ field: 'ck', checkbox: true });
    columns.push({ field: 'RoomName', title: '房号', width: 100 });
    columns.push({ field: 'ApplicationMan', title: '申请人', width: 100 });
    columns.push({ field: 'PhoneNumber', title: '联系电话', width: 100 });
    if (Status == 'shenqing') {
        columns.push({ field: 'AddTime', formatter: formatTime, title: '申请时间', width: 150 });
    }
    if (Status == 'shenpiyes' || Status == 'shenpino') {
        columns.push({ field: 'ApproveTime', formatter: formatTime, title: '审批时间', width: 150 });
    }
    if (Status == 'zhuangxiu') {
        columns.push({ field: 'ConfirmZXTime', formatter: formatTime, title: '装修时间', width: 150 });
    }
    if (Status == 'yanshou') {
        columns.push({ field: 'YanShouTime', formatter: formatTime, title: '验收时间', width: 150 });
    }
    columns.push({ field: 'StatusDesc', title: '状态', width: 100 });
    columns.push({ field: 'XunJianCount', formatter: formatXunJianCount, title: '巡检', width: 100 });
    var finalcolumns = [];
    finalcolumns.push(columns);
    return finalcolumns;
}
function loadTT() {
    tt_CanLoad = false;
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/ZhuangXiuHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: get_columns(),
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
        toolbar: '#tb'
    });
    SearchTT();
}

function SearchTT() {
    var StartTime = $("#tdStartTime").datetimebox("getValue");
    var EndTime = $("#tdEndTime").datetimebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
             show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var roomids = [];
    var projectids = []
    try {
        roomids = parent.GetSelectedRooms();
        projectids = parent.GetSelectedProjects();
    } catch (e) {

    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadzhuangxiugrid",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "Status": Status
    });
}
function formatXunJianCount(value, row) {
    if (Number(value) > 0) {
        return '<a href="javascript:viewXunJianDetail(' + row.ID + ')">' + value + '</a>';
    }
    return 0;
}
function viewXunJianDetail(ID) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/ViewXunJianDetail.aspx?ID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    OpenWin(iframe, '巡检记录');
}
function OpenWin(iframe, title) {
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: title,
        width: ($(parent.window).width() - 450),
        height: $(parent.window).height(),
        top: 0,
        left: 250,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function addRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/AddZhuangXiu.aspx?' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '装修申请',
        width: ($(parent.window).width() - 200),
        height: $(parent.window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个装修记录", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个装修记录", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/EditZhuangXiu.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    OpenWin(iframe, '修改');
}
function approveData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个装修记录", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个装修记录", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/ApproveZhuangXiu.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    OpenWin(iframe, '审批');
}
function confirmZX() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个装修记录", "info");
        return;
    }
    var IDList = [];
    var canContinue = true;
    $.each(rows, function (index, row) {
        if (row.Status != "shenpiyes") {
            canContinue = false;
            return false;
        }
        IDList.push(row.ID);
    })
    if (!canContinue) {
        show_message("请选择审批通过的记录", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/ConfirmZhuangXiu.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '确认装修',
        width: ($(window).width() - 200),
        height: $(window).height(),
        top: 0,
        left: 0,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function xunJian() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一条记录", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一条记录", "info");
        return;
    }
    if (rows[0].Status != "zhuangxiu") {
        show_message("请选择装修中的记录", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/AddXunJian.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    OpenWin(iframe, '巡检');
}
function yanShou() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一条记录", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一条记录", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/AddYanShou.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    OpenWin(iframe, '验收');
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个装修记录", "info");
        return;
    }
    var IDList = [];
    var canContinue = true;
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "确认删除选中的记录?", function (r) {
        if (r) {
            var options = { visit: 'deletezhuangxiu', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ZhuangXiuHandler.ashx',
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
function do_view() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个装修记录", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个装修记录", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/ZhuangXiuView.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    OpenWin(iframe, '详情');
}
