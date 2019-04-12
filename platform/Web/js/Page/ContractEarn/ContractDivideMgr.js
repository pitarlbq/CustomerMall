var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    var options = { visit: 'loadtablecolumn', pagecode: 'contractdividemgr' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
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
                    columns: finalcolumn,
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
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function formatDecimal(value, row) {
    if (parseFloat(value) < 0) {
        return 0;
    }
    return value;
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
    var StartTime = $('#tdStartTime').datebox("getValue");
    var EndTime = $('#tdEndTime').datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message("账单开始日期不能大于结束日期", "info");
            return null;
        }
    }
    var Keywords = $('#tdKeywords').searchbox("getValue");
    var roomids = [];
    var projectids = []
    try {
        roomids = parent.GetSelectedRooms();
        projectids = parent.GetSelectedProjects();
    } catch (e) {

    }
    var options = {
        "visit": "loadcontractdividegrid",
        "StartTime": StartTime,
        "EndTime": EndTime,
        "Keywords": Keywords,
        "ContractID": ContractID,
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids)
    };
    return options;
}
function getID() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个账单", "info");
        return 0;
    }
    if (rows.length > 1) {
        show_message("只能选择一个账单", "info");
        return 0;
    }
    var ID = rows[0].ID;
    return ID;
}
function do_view() {
    var ID = getID();
    if (ID <= 0) {
        return;
    }
    var iframe = "../ContractEarn/ContractDivideView.aspx?ID=" + ID + "&op=view";
    do_open_dialog('查看账单', iframe);
}
function do_edit() {
    var ID = getID();
    if (ID <= 0) {
        return;
    }
    var iframe = "../ContractEarn/ContractDivideEdit.aspx?ID=" + ID;
    do_open_dialog('修改账单', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个账单", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的账单?", function (r) {
        if (r) {
            var options = { visit: 'removecontractdivide', IDList: JSON.stringify(IDList) };
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
function do_active() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个账单", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否生效选中的账单?", function (r) {
        if (r) {
            var options = { visit: 'activecontractdivide', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
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