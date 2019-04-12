var tt_CanLoad = false;
$(function () {
    loadTT()
})
function loadTT() {
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/CommHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
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
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadfeecategory"
    });
}
function formatSortOrder(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
function savetype() {
    var isValid = $("#ff").form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var id = $("#tdID").val();
    var name = $("#tdName").textbox("getValue");
    var sortorder = $("#tdSortOrder").textbox("getValue");
    var options = { visit: 'savefeecategory', id: id, name: name, sortorder: sortorder };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CommHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message('保存成功', 'success', function () {
                    $("#tt_table").datagrid("reload");
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function canceltype() {
    $("#tdID").val("");
    $("#tdName").textbox("setValue", "");
    $("#tdSortOrder").textbox("setValue", "");
}
function edittype() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length != 1) {
        show_message("请选择一行进行此操作", "info");
        return;
    }
    var is_system_add = false;
    $.each(rows, function (index, row) {
        if (row.IsSystemAdd) {
            is_system_add = true;
            return false;
        }
    })
    if (is_system_add) {
        show_message("系统内置分类，禁止修改", "info");
        return;
    }
    $("#tdID").val(rows[0].ID);
    $("#tdName").textbox("setValue", rows[0].Name);
    $("#tdSortOrder").textbox("setValue", Number(rows[0].SortOrder) < 0 ? 0 : Number(rows[0].SortOrder));
}
function deletetype() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一行进行此操作", "info");
        return;
    }
    var IDList = [];
    var is_system_add = false;
    $.each(rows, function (index, row) {
        if (row.IsSystemAdd) {
            is_system_add = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (is_system_add) {
        show_message("系统内置分类，禁止删除", "info");
        return;
    }
    top.$.messager.confirm("提示", "确认删除?", function (r) {
        if (r) {
            var options = { visit: 'deletefeecategory', ids: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    else if (message.error) {
                        show_message(message.error, "error");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
