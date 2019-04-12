var tt_CanLoad = false;
$(function () {
    loadPaySummary();
    setTimeout(function () {
        loadTT();
    }, 500);
});
function loadTT() {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/ServiceHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        onDblClickRow: onDblClickRowTT,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'ProjectName', title: '资源位置', width: 200 },
        { field: 'PayName', title: '项目名称', width: 100 },
        { field: 'PayMoney', title: '金额', width: 100 },
        { field: 'PayType', title: '缴费类型', width: 100 },
        { field: 'AccountType', title: '记账操作', width: 100 },
        { field: 'PayTime', formatter: formatTime, title: '支出日期', width: 100 },
        { field: 'AddMan', title: '操作人', width: 100 },
        { field: 'RoomName', title: '所属房间', width: 100 },
        { field: 'ModifyTime', formatter: formatTime, title: '修改时间', width: 100 },
        { field: 'ModifyMan', title: '修改人', width: 100 },
        { field: 'Remark', formatter: formatRemark, title: '备注', width: 100 },
        { field: 'StatusDesc', title: '状态', width: 100 },
        //{ field: 'Operation', title: '操作', formatter: formatOperation, width: 100 }
        ]],
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
    setTimeout(function () {
        SearchTT()
    }, 1000);
    return;
}
function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var roomids = [];
    var projectids = [];
    var allprojectids = [];
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
        allprojectids = projectids;
    } catch (e) {
    }
    tt_CanLoad = true;
    var options = {
        "visit": "loadpayservicegrid",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "ALLProjectIDs": JSON.stringify(allprojectids),
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "PaySummary": $("#tdPaySummary").combobox('getValue')
    };
    return options;
}
function formatRemark(value, row) {
    if (value.length > 8) {
        return value.substring(0, 8) + "...";
    }
    return value;
}
function loadPaySummary() {
    var options = { visit: 'loadpaysummary' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        data: options,
        success: function (data) {
            var list = [];
            list.push({ ID: 0, PayName: "全部" });
            $.each(data, function () {
                list.push({ ID: this.ID, PayName: this.PayName });
            })
            $('#tdPaySummary').combobox({
                editable: true,
                data: list,
                valueField: 'ID',
                textField: 'PayName',
                filter: function (q, row) {
                    var opts = $(this).combobox('options');
                    return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                }
            });
        }
    });
}
function formatOperation(value, row) {
    var $html = '<div>';
    $html += '<a onclick="editRow(' + row.ID + ')"><span style="color:red;">修改</span></a>';
    $html += '</div>';
    return $html;
}
function onDblClickRowTT(index, row) {
    editRow(row.ID);
}
function addRow() {
    var iframe = "../PayService/EditPayService.aspx";
    do_open_dialog('新增支出', iframe);
}
function do_edit() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    editRow(rows[0].ID);
}
function editRow(ID) {
    var iframe = "../PayService/EditPayService.aspx?ID=" + ID;
    do_open_dialog('修改支出', iframe);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个支出登记", "info");
        return;
    }
    var IDList = [];
    var isapprove = false;
    $.each(rows, function (index, row) {
        if (row.Status <= 0 || row.Status == 3) {
            isapprove = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (isapprove) {
        show_message("选择的支出登记已审核", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的登记信息", function (r) {
        if (r) {
            var options = { visit: 'removepayservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
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
function do_approve() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.defaults.ok = '审核通过';
    top.$.messager.defaults.cancel = '审核取消';
    top.$.messager.confirm("提示", "确认审核?", function (r) {
        top.$.messager.defaults.ok = '确定';
        top.$.messager.defaults.cancel = '取消';
        var approvestatus = 1;
        if (r) {
            approvestatus = 3;
        }
        var options = { visit: 'approvepayservice', IDList: JSON.stringify(IDList), status: approvestatus };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '../Handler/ServiceHandler.ashx',
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
    })
}
function do_export() {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.canexport = true;
    options.page = 1;
    options.rows = 10;
    MaskUtil.mask('body', '导出中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ServiceHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.downloadurl) {
                window.location.href = data.downloadurl;
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统异常', 'error');
        }
    });
}

