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
        { field: 'ProductName', title: '商品标题', width: 200 },
        { field: 'CategoryName', title: '所属分类', width: 150 },
        { field: 'BusinessName', title: '所属商家', width: 150 },
        { field: 'ProductTypeDesc', title: '商品类型', width: 100 },
        { field: 'SalePrice', title: '商品价格', width: 100 },
        { field: 'ModelNumber', title: '商品型号', width: 100 },
        { field: 'Inventory', title: '当前库存', width: 100 },
        { field: 'SaleCount', title: '当前销量', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallproductgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "SortOrder": $('#tdSortOrder').combobox('getValue'),
    });
}
function do_add() {
    var iframe = "../Mall/ProductEdit.aspx";
    do_open_dialog('新增商品', iframe);
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
    var iframe = "../Mall/ProductEdit.aspx?ID=" + ID;
    do_open_dialog('修改商品', iframe);
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
    top.$.messager.confirm("提示", "确认删除选中的商品?", function (r) {
        if (r) {
            var options = { visit: 'removemallproduct', IDList: JSON.stringify(IDList) };
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
function do_change_category() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../Mall/ProductsChangeCategory.aspx";
    do_open_dialog('批量分类', iframe);
}
function do_change_price() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../Mall/ProductsChangePrice.aspx";
    do_open_dialog('批量改价', iframe);
}
function do_offline() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    top.$.messager.confirm("提示", "确认下架选中的商品?", function (r) {
        if (r) {
            var options = { visit: 'removemallproduct', IDList: JSON.stringify(IDList) };
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