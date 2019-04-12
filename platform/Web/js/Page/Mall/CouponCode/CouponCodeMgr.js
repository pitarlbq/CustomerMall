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
        { field: 'CouponName', title: '卡券名称', width: 150 },
        { field: 'IsActiveDesc', title: '状态', width: 100 },
        { field: 'CouponTypeDesc', title: '卡券类型', width: 100 },
        { field: 'ActiveTimeRangeDesc', title: '有效期', width: 150 },
        { field: 'UseForALLDesc', title: '使用范围', width: 100 },
        { field: 'UseTypeDesc', title: '卡券规则', width: 100 },
        { field: 'UseCount', title: '使用次数', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallcouponcodegrid",
        "keywords": $('#tdKeyword').searchbox('getValue')
    });
}
function do_add() {
    var iframe = "../Mall/CouponCodeEdit.aspx";
    do_open_dialog('新增卡券', iframe);
}
function onDblClickRowTT(index, row) {
    do_edit_byid(row.id)
}
function do_edit() {
    var ID = 0;
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    do_edit_byid(row.ID);
}
function do_edit_byid(ID) {
    if (CanEdit != 1) {
        return;
    }
    var iframe = "../Mall/CouponCodeEdit.aspx?ID=" + ID;
    do_open_dialog('修改卡券', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.id);
    })
    if (IDList.length == 0) {
        return;
    }
    top.$.messager.confirm("提示", "确认删除选中的卡券?", function (r) {
        if (r) {
            var options = { visit: 'removemallcouponcode', IDList: JSON.stringify(IDList) };
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
function do_start() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.id);
    })
    if (IDList.length == 0) {
        return;
    }
    top.$.messager.confirm("提示", "确认启用选中的卡券?", function (r) {
        if (r) {
            var options = { visit: 'startmallcouponcode', IDList: JSON.stringify(IDList) };
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
function do_stopt() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.id);
    })
    if (IDList.length == 0) {
        return;
    }
    top.$.messager.confirm("提示", "确认停用选中的卡券?", function (r) {
        if (r) {
            var options = { visit: 'stopmallcouponcode', IDList: JSON.stringify(IDList) };
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
function do_send() {
    var ID = 0;
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    var iframe = "../Mall/CouponCodeSend.aspx";
    do_open_dialog('发放卡券', iframe);
}