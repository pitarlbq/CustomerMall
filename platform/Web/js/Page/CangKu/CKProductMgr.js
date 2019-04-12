var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CKHandler.ashx',
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
        onDblClickRow: onDblClickRowTT,
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
        { field: 'ProductCategoryName', title: '物品类别', width: 80 },
        { field: 'ProductNumber', title: '物品编号', width: 100 },
        { field: 'ProductName', title: '物品名称', width: 100 },
        { field: 'Unit', title: '计量单位', width: 100 },
        { field: 'ModelNumber', title: '规格型号', width: 100 },
        { field: 'ProductUnitPrice', formatter: formatProductUnitPrice, title: '默认单价', width: 100 },
        { field: 'InventoryMin', formatter: formatCount, title: '库存下限', width: 150 },
        { field: 'InventoryMax', formatter: formatCount, title: '库存上限', width: 150 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var TreeID = [];
    try {
        TreeID = GetSelectedID();
    } catch (e) {
    }
    var options= {
        "visit": "loadproductgrid",
        "TreeID": JSON.stringify(TreeID),
        "keywords": keywords
    };
    return;
}
function formatCount(value, row) {
    if (parseFloat(value) > 0) {
        return value;
    }
    return 0;
}
function formatProductUnitPrice(value, row) {
    if (parseFloat(value) > 0) {
        return value;
    }
    return 0;
}
function SearchTTByTree(type, ID) {

}
function onDblClickRowTT(index, row) {
    editByRow(row.ID)
}
function addRow() {
    var CategoryID = 0;
    var CategoryIDList = GetSelectedID();
    if (CategoryIDList.length > 0) {
        CategoryID = CategoryIDList[0];
    }
    var iframe = "../CangKu/EditProduct.aspx?CategoryID=" + CategoryID;
    do_open_dialog('新增物品', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个物品进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    editByRow(rows[0].ID);
}
function editByRow(ID) {
    var iframe = "../CangKu/EditProduct.aspx?ID=" + ID;
    do_open_dialog('修改物品', iframe);
}
function removeRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个物品进行此操作", "warning");
        return;
    }
    var IDList = [];
    var isBalance = false;
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的物品", function (r) {
        if (r) {
            var options = { visit: 'removeproduct', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
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
function openImport() {
    var iframe = "../CangKu/ImportProduct.aspx";
    do_open_dialog('导入物品信息', iframe);
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
        url: '../Handler/CKHandler.ashx',
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

