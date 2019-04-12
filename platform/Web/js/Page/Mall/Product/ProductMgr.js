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
        { field: 'ProductImage', formatter: formatCoverImage, title: '商品图片', width: 100 },
        { field: 'ProductName', title: '商品名称', width: 150 },
        { field: 'CategoryName', title: '所属分类', width: 150 },
        { field: 'TagNames', title: '所属标签', width: 150 },
        { field: 'IsZiYingDesc', title: '是否自营', width: 100 },
        { field: 'ProductSaleDesc', title: '商品类型', width: 100 },
        { field: 'BusinessName', title: '所属商家', width: 150 },
        { field: 'StatusDesc', title: '状态', width: 80 },
        { field: 'ProductTypeDesc', title: '商品类型', width: 80 },
        { field: 'AdminNormalPriceDesc', title: '商品单价', width: 100 },
        { field: 'AdminPinTuanPriceDesc', title: '团购单价', width: 100 },
        { field: 'AdminXianShiPriceDesc', title: '限时购单价', width: 100 },
        { field: 'PointPriceDesc', title: '积分购买单价', width: 150 },
        { field: 'VIPPointPriceDesc', title: '合伙人购买单价', width: 150 },
        { field: 'ModelNumber', title: '商品型号', width: 100 },
        { field: 'Inventory', title: '当前库存', width: 100 },
        { field: 'SaleCount', title: '当前销量', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var IsAllowProductBuy = ($('#tdIsAllowProductBuy').prop('checked') ? 1 : 0);
    var IsAllowPointBuy = ($('#tdIsAllowPointBuy').prop('checked') ? 1 : 0);
    var IsAllowVIPBuy = ($('#tdIsAllowVIPBuy').prop('checked') ? 1 : 0);
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallproductgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "SortOrder": $('#tdSortOrder').combobox('getValue'),
        "status": status,
        "type": type,
        "IsZiYing": $('#tdIsZiYing').combobox('getValue'),
        "IsAllowProductBuy": IsAllowProductBuy,
        "IsAllowPointBuy": IsAllowPointBuy,
        "IsAllowVIPBuy": IsAllowVIPBuy,
    });
}
function formatCoverImage(value, row) {
    var result = '';
    if (row.CoverImage != '' && null != row.CoverImage) {
        result = '<img class="cover_image" style="width:50px; height:50px;border-radius:50%;" src="' + row.CoverImage + '">';
    }
    return result;
}
function do_add() {
    var iframe = "../Mall/ProductEdit.aspx?type=" + type;
    do_open_dialog('新增商品', iframe);
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
    var iframe = "../Mall/ProductEdit.aspx?ID=" + ID + "&type=" + type;
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
        IDList.push(row.ID);
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
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "确认下架选中的商品?", function (r) {
        if (r) {
            var options = { visit: 'offlinemallproduct', IDList: JSON.stringify(IDList) };
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
function do_approve() {
    var ID = 0;
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    ID = row.ID;
    var iframe = "../Mall/ProductApprove.aspx?ID=" + ID;
    do_open_dialog('商品审核', iframe);
}
function do_view() {
    var ID = 0;
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    ID = row.ID;
    var iframe = "../Mall/ProductApprove.aspx?ID=" + ID + "&op=view";
    do_open_dialog('商品详情', iframe);
}
function do_view_pintuan() {
    var ID = 0;
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    ID = row.ID;
    var iframe = "../Mall/ProductViewPinDetail.aspx?ID=" + ID;
    do_open_dialog('查看拼团', iframe);
}
function do_change_tag() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var iframe = "../Mall/ProductsChangeTag.aspx";
    do_open_dialog('批量标签', iframe);
}
function do_change_youxuan_sort() {
    var iframe = "../Mall/ProductsSortOrder.aspx?type=1";
    do_open_dialog('福顺优选排序', iframe);
}
function do_change_pintuan_sort() {
    var iframe = "../Mall/ProductsSortOrder.aspx?type=2";
    do_open_dialog('拼团抢购排序', iframe);
}