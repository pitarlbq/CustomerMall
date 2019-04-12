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
        fitColumns: false,
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
        { field: 'RoomOwnerName', title: '业主名称', width: 100 },
        { field: 'FinalFullName', title: '房源信息', width: 200 },
        { field: 'BalanceRuleName', title: '结算规则', width: 100 },
        { field: 'TotalCost', title: '本期待结算金额', width: 150 },
        { field: 'BalanceAmount', title: '返现金额', width: 150 },
        { field: 'ApplicationTime', formatter: formatDateTime, title: '申请日期', width: 150 },
        { field: 'ApplicationUserMan', title: '申请人', width: 100 },
        { field: 'ApproveTime', formatter: formatDateTime, title: '审核日期', width: 150 },
        { field: 'ApproveUserMan', title: '审核人', width: 100 },
        { field: 'BalanceStatusDesc', title: '结算状态', width: 100 }
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
    var RoomIDs = parent.GetSelectedRooms();
    var ProjectIDs = parent.GetSelectedProjects();
    $("#tt_table").datagrid("load", {
        "visit": "loadmallroomownerbalancegrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
        "BalanceStatus": FinalBalance,
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs)
    });
}
function do_add() {
    var iframe = "../Mall/RoomOwnerBalanceAdd.aspx";
    do_open_dialog('新增', iframe);
}
function do_edit() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../Mall/RoomOwnerBalanceAdd.aspx?ID=" + rows[0].ID;
    do_open_dialog('修改', iframe);
}
function do_application() {
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
function do_approve() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../Mall/RoomOwnerBalanceApprove.aspx";
    do_open_dialog('业主结算审核', iframe);
}