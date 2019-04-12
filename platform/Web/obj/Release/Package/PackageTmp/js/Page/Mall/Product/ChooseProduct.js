var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
});
function loadtt() {
    var singleSelect = singleselect == 1;
    $('#tt_table').datagrid({
        url: '../Handler/MallHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: singleSelect,
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
        { field: 'ProductName', title: '商品名称', width: 200 },
        { field: 'CategoryName', title: '所属分类', width: 150 },
        { field: 'IsZiYingDesc', title: '是否自营', width: 150 },
        { field: 'BusinessName', title: '所属商家', width: 150 },
        { field: 'StatusDesc', title: '状态', width: 100 },
        { field: 'ProductTypeDesc', title: '商品类型', width: 100 },
        { field: 'SalePrice', title: '商品单价', width: 100 },
        { field: 'ModelNumber', title: '商品型号', width: 100 },
        { field: 'Inventory', title: '当前库存', width: 100 },
        { field: 'SaleCount', title: '当前销量', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallproductgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "SortOrder": $('#tdSortOrder').combobox('getValue'),
        "status": status,
        "type": type
    });
}
function do_choose() {
    var list = [];
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择商品', 'info');
        return;
    }
    var names = '';
    $.each(rows, function (index, row) {
        list.push(row.ID);
        if (index > 0) {
            names += ",";
        }
        names += row.ProductName;
    })
    if (from == 'RotatingImageEdit') {
        parent.isupdate = true;
        parent.hdProducts.val(JSON.stringify(list));
        parent.tdURLLinkNames.textbox('setValue', names);
    }
    if (from == 'CouponCodeEdit' || from == 'RateRuleEdit') {
        parent.isupdate = true;
        parent.hdProducts.val(JSON.stringify(list));
        parent.tdProducts.textbox('setValue', names);
    }
    do_close();
}
function do_close() {
    parent.do_close_dialog();
}