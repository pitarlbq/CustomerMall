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
        { field: 'TotalInventory', title: '库存总数量', width: 100 },
        { field: 'ProductUnitPrice', formatter: formatProductUnitPrice, title: '默认单价', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    var TreeID = [];
    try {
        TreeID = GetSelectedID();
    } catch (e) {
    }
    $("#tt_table").datagrid("load", {
        "visit": "loadproductgrid",
        "TreeID": JSON.stringify(TreeID),
        "keywords": keywords,
        "ShowTotalInventory": true,
        "CKCategoryID": CKCategoryID
    });
}
function formatProductUnitPrice(value, row) {
    if (parseFloat(value) > 0) {
        return value;
    }
    return 0;
}
function chooseRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请至少选择一个商品", 'warning');
        return;
    }
    var list = [];
    $.each(rows, function (index, row) {
        var ProductUnitPrice = (parseFloat(row.ProductUnitPrice) > 0 ? row.ProductUnitPrice : 0);
        list.push({ ProductID: row.ID, ProductName: row.ProductName, Unit: row.Unit, ModelNumber: row.ModelNumber, TotalInventory: row.TotalInventory, UnitPrice: ProductUnitPrice });
    })
    parent.SelectedList = list;
    do_close();
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
function do_close() {
    parent.do_close_dialog(function () {
        parent.choose_product_done();
    });
}