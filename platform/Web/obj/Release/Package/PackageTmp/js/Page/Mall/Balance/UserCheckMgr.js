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
        onDblClickRow: onDblClickRowTT,
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
        { field: 'RequestTypeDesc', title: '积分类型', width: 100 },
        { field: 'CheckUserInfo', title: '考核人员', width: 200 },
        { field: 'CheckCategoryName', title: '考核项目', width: 100 },
        { field: 'CheckUserPosition', title: '考核岗位', width: 100 },
        { field: 'CheckRule', title: '考核标准', width: 200 },
        { field: 'UserEarnPoint', title: '奖励员工积分', width: 100 },
        { field: 'UserReducePoint', title: '扣除员工积分', width: 100 },
        { field: 'ApproveTime', formatter: formatTime, title: '审核日期', width: 100 },
        { field: 'ApproveMan', title: '审核人', width: 100 },
        { field: 'ApproveStatusDesc', title: '审核状态', width: 100 },
        { field: 'ConfirmStatusDesc', title: '申诉状态', width: 100 },
        { field: 'ProcessStatusDesc', title: '处理状态', width: 100 },
        { field: 'IsJieXiaoPointSentDesc', title: '发放状态', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallusercheckgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "CheckType": $('#tdCheckType').combobox('getValue'),
        "approvestatus": approvestatus,
        "confirmstatus": confirmstatus,
        "processstatus": processstatus,
        "RequestType": $('#tdRequestType').combobox('getValue'),
    });
}
function onDblClickRowTT(index, row) {
    EditDataByRow(row)
}
function do_add() {
    var iframe = "../Mall/UserCheckAdd.aspx";
    do_open_dialog('新增岗位考核', iframe);
}
function do_edit() {
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
function EditDataByRow(row) {
    var iframe = "../Mall/UserCheckAdd.aspx?ID=" + row.ID;
    do_open_dialog('修改岗位考核', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的数据", function (r) {
        if (r) {
            var options = { visit: 'removemallusercheck', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
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
function do_application() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var can_do = true;
    $.each(rows, function (index, row) {
        if (row.ApproveStatus != 0 && row.ApproveStatus != 2) {
            can_do = false;
            return false;
        }
        IDList.push(row.ID);
    })
    if (!can_do) {
        show_message("请选择待申请或者审批未通过的数据", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否申请考核选中的数据", function (r) {
        if (r) {
            var options = { visit: 'domallusercheckapplication', IDList: JSON.stringify(IDList) };
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
    var IDList = [];
    var can_do = true;
    $.each(rows, function (index, row) {
        if (row.ApproveStatus != 3) {
            can_do = false;
            return false;
        }
        IDList.push(row.ID);
    })
    if (!can_do) {
        show_message("请选择待审批状态数据", "info");
        return;
    }
    var iframe = "../Mall/UserCheckApprove.aspx";
    do_open_dialog('审核岗位考核', iframe);
}
function do_process() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var can_do = true;
    $.each(rows, function (index, row) {
        if (row.ProcessStatus > 0 || row.ConfirmStatus != 2) {
            can_do = false;
            return false;
        }
        IDList.push(row.ID);
    })
    if (!can_do) {
        show_message("请选择申诉未处理状态数据", "info");
        return;
    }
    var ID = 0;
    if (IDList.length == 1) {
        ID = IDList[0];
    }
    var iframe = "../Mall/UserCheckRejectProcess.aspx?ID=" + ID;
    do_open_dialog('员工申诉', iframe);
}