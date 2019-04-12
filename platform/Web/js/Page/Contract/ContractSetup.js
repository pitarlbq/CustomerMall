var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'ContractNo', title: '合同编号', formatter: formatContractNo, width: 100 },
        { field: 'ContractName', title: '合同名称', width: 100 },
        { field: 'RentName', title: '租户姓名', width: 100 },
        { field: 'FreeDays', formatter: formatFreeDays, title: '免租期', width: 100 },
        { field: 'TimeLimit', title: '合同期限', width: 100 },
        { field: 'RentStartTime', formatter: formatTime, title: '开始日期', width: 100 },
        { field: 'RentEndTime', formatter: formatTime, title: '结束日期', width: 100 },
        { field: 'ContractStatusDesc', title: '合同状态', width: 150 },
        { field: 'RestDays', formatter: formatRestDays, title: '剩余天数', width: 150 }
        ]],
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
function formatContractNo(value, row) {
    if (value == '') {
        value = '未设置';
    }
    return '<a href="javascript:viewData(' + row.ID + ')">' + value + '</a>'
}
function formatFreeDays(value, row) {
    if (Number(value) > 0) {
        return value + '天';
    }
    return "--";
}
function formatRestDays(value, row) {
    if (value == 0) {
        return value;
    }
    if (row.ContractStatus != "tongguo") {
        return value;
    }
    if (Number(row.ContractWarningDayCount) < Number(value)) {
        return value;
    }
    return '<span style="color:red;">' + value + '</span>';
}
function SearchTT() {
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message("签约开始日期不能大于结束日期", "info");
            return;
        }
    }
    var RentStartTime = $("#tdRentStartTime").datebox("getValue");
    var RentEndTime = $("#tdRentEndTime").datebox("getValue");
    if (RentStartTime != '' && RentEndTime != '') {
        if (stringToDate(RentStartTime).valueOf() > stringToDate(RentEndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var roomids = [];
    var projectids = []
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
    } catch (e) {

    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadcontractgrid",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "ContractStatus": $("#tdContractStatus").combobox("getValue"),
        "RentStartTime": RentStartTime,
        "RentEndTime": RentEndTime
    });
}
function approveData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个合同", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个合同", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Contract/ApproveContract.aspx?ID=" + ID;
    do_open_dialog('审核生效', iframe);
}
function cancelData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Contract/CancelContract.aspx?ID=" + ID;
    do_open_dialog('终止合同', iframe);
}
function editData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个合同", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个合同", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Contract/" + editContractPath + "?ID=" + ID + "&op=edit";
    do_open_dialog('合同变更', iframe, true);
}
function doReRent() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个合同", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个合同", "info");
        return;
    }
    if (rows[0].ContractStatus != 'tongguo') {
        show_message("请选择正在履行的合同进行续租操作", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Contract/" + editContractPath + "?ID=" + ID + "&op=newrent";
    do_open_dialog('合同续租', iframe, true);
}
function viewData(ID) {
    if (!ID) {
        var rows = $("#tt_table").datagrid("getSelections");
        if (rows.length == 0) {
            show_message("请先选择一个合同", "info");
            return;
        }
        if (rows.length > 1) {
            show_message("只能选择一个合同", "info");
            return;
        }
        ID = rows[0].ID;
    }
    var iframe = "../Contract/" + editContractPath + "?ID=" + ID + "&op=view";
    do_open_dialog('合同查看', iframe, true);
}
function addRow() {
    var iframe = "../Contract/" + addContractPath + "?op=add";
    do_open_dialog('合同登记', iframe, true);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个合同", "info");
        return;
    }
    var IDList = [];
    var hasApprove = false;
    var hasStop = false;
    $.each(rows, function (index, row) {
        if (row.ContractStatus == 'tongguo') {
            hasApprove = true;
            return false;
        }
        if (row.ContractStatus == 'zhongzhi') {
            hasStop = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (hasApprove) {
        show_message("选中的合同中包含正在履行的合同，删除取消", "info");
        return;
    }
    if (hasStop) {
        show_message("选中的合同中包含已中止的合同，删除取消", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的合同?", function (r) {
        if (r) {
            var options = { visit: 'removecontract', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function createFee() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个合同", "info");
        return;
    }
    var IDList = [];
    var hasApprove = false;
    $.each(rows, function (index, row) {
        if (row.ContractStatus != 'tongguo') {
            hasApprove = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (hasApprove) {
        show_message("选中的合同中包含未履行的合同，禁止生成", "info");
        return;
    }
    top.$.messager.confirm("提示", "确认生成账单?", function (r) {
        if (r) {
            var options = { visit: 'createcontractfee', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("生成成功", "success", function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function zuofeiRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个合同", "info");
        return;
    }
    var IDList = [];
    var haszuofei = false;
    var candelete = true;
    $.each(rows, function (index, row) {
        if (row.ContractStatus == 'deleted') {
            haszuofei = true;
            return false;
        }
        if (row.ContractStatus != 'zhongzhi') {
            candelete = false;
            return false;
        }
        IDList.push(row.ID);
    })
    if (haszuofei) {
        show_message("不能重复作废合同", "info");
        return;
    }
    if (!candelete) {
        show_message("只能作废已终止的合同", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否作废选中的合同?", function (r) {
        if (r) {
            var options = { visit: 'zuofeicontract', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("作废成功", "success", function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function doChangeRent() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个合同", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个合同", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Contract/" + editContractPath + "?ID=" + ID + "&op=changerent";
    do_open_dialog('合同转租', iframe, true);
}