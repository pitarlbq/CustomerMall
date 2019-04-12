var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
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
        singleSelect: true,
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
        { field: 'FullName', title: '房源位置', width: 200 },
        { field: 'RoomName', title: '房间编号', width: 100 },
        { field: 'TotalCost', title: '订单总金额', width: 150 },
        { field: 'TotalRestCost', title: '待结算总金额', width: 150 },
        { field: 'TotalBalanceAmount', title: '已返现总金额', width: 150 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    var FinalBalance = BalanceStatus;
    try {
        var tdBalanceStatus = $('#tdBalanceStatus').combobox('getValue');
        if (tdBalanceStatus != '') {
            FinalBalance = tdBalanceStatus;
        }
    } catch (e) {
    }
    var RoomIDs = [];
    var ProjectIDs = [];
    try {
        RoomIDs = parent.GetSelectedRooms();
        ProjectIDs = parent.GetSelectedProjects();

    } catch (e) {
    }
    $("#tt_table").datagrid("load", {
        "visit": "loadmallroomownerbalanceapplicationgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue')
    });
}
function formatOperation(value, row) {
    return '<a href="javascript:view_detail(' + row.RoomID + ')">查看</a>';
}
function do_application() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../Mall/RoomOwnerBalanceAdd.aspx?RoomID=" + rows[0].RoomID;
    do_open_dialog('结算申请', iframe);
}
function view_detail(RoomID) {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../Mall/RoomOwnerBalanceDetail.aspx?RoomID=" + rows[0].RoomID;
    do_open_dialog('查看详情', iframe);
}
function do_applicationbak() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    if (IDList.length == 0) {
        return;
    }
    top.$.messager.confirm("提示", "确认申请结算?", function (r) {
        if (r) {
            var options = { visit: 'savemallroomownerbalancestatus', IDList: JSON.stringify(IDList), BalanceStatus: 1 };
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