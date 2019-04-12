var tt_CanLoad = false, isUpdate = false;
var IDMark_A = "_a";
$(function () {
    doSearchTree();
});
var setting = {
    async: {
        enable: true,
    },
    view: {
        dblClickExpand: false,
        showIcon: false
    },
    data: {
        simpleData: {
            enable: true
        }
    },
    check: {
        enable: true,
        chkboxType: { "Y": "s", "N": "s" }
    }
};
function doSearchTree() {
    var keywords = $("#searchbox").searchbox("getValue");
    MaskUtil.mask('#tt');
    var options = { visit: 'gethouseservicecategorytree', Keywords: keywords, type: type };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/WechatHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            $.fn.zTree.init($("#tt"), setting, data);
            loadtt();
        }
    });
}
function reset() {
    $("#searchbox").searchbox("setValue", "");
    doSearchTree();
}
function GetSelectedIDList() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (Number(node.ID) > 0) {
            idarry.push(node.ID);
        }
    })
    return idarry;
}
function addTree() {
    var iframe = "../Wechat/EditHouseServiceCategory.aspx?type=" + type;
    do_open_dialog('新增类别', iframe);
}
function editTree() {
    var CategoryIDList = GetSelectedIDList();
    if (CategoryIDList.length == 0) {
        show_message("请选择一个分类", "info");
        return;
    }
    var iframe = "../Wechat/EditHouseServiceCategory.aspx?ID=" + CategoryIDList[0];
    do_open_dialog('修改类别', iframe);
}
function removeTree() {
    var CategoryIDList = GetSelectedIDList();
    if (CategoryIDList.length == 0) {
        show_message("请选择一个分类", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的类别?", function (r) {
        if (r) {
            var options = { visit: 'removehouseservicecategory', CategoryIDList: JSON.stringify(CategoryIDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            doSearchTree();
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
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
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
        { field: 'Title', title: '服务名称', width: 100 },
        { field: 'CategoryName', title: '服务类别', width: 100 },
        { field: 'PublishStatus', title: '状态', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var CategoryIDList = [];
    try {
        CategoryIDList = GetSelectedIDList();
    } catch (e) {

    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "gethouseservicegrid",
        "keywords": keywords,
        "CategoryIDList": JSON.stringify(CategoryIDList),
        "type": type
    });
}
function addRow() {
    var iframe = "../Wechat/EditHouseService.aspx?type=" + type;
    do_open_dialog('新增服务', iframe);
}
function editRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个服务", "info");
        return;
    }
    var iframe = "../Wechat/EditHouseService.aspx?ID=" + rows[0].ID + "&type=" + type;
    do_open_dialog('修改服务', iframe);
}
function removeRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个服务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的服务?", function (r) {
        if (r) {
            var options = { visit: 'removehouseservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $('#tt_table').datagrid('reload')
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function viewWechatPage() {
    var pageurl = '/WeiXin/HouseServiceRedirect.aspx';
    var iframe = "../Wechat/ViewQrCodeByURL.aspx?pageurl=" + pageurl;
    do_open_dialog('微信二维码', iframe);
}
