
var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').treegrid({
        url: '../Handler/CKHandler.ashx',
        loadMsg: '正在加载',
        rownumbers: true,
        animate: true,
        collapsible: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        idField: 'id',
        treeField: 'name',
        onDblClickRow: onDblClickRowTT,
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $('#tt_table').treegrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').treegrid("loadData", {
                total: 0,
                rows: []
            });
        },
        onLoadSuccess: function (data) {
            init();
        },
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").treegrid("load", {
        "visit": "loadcategorygrid",
        "keywords": keywords
    });
}
function formatOperation(index, row) {
    if (row.id > 1) {
        return '<a href="#" onclick="editRow(' + row.id + ')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:\'icon-edit\'">编辑</a>';
    }
}
function onDblClickRowTT(index, row) {
    editRow(row.id)
}
function addRow() {
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    if (row.CategoryType == "category") {
        show_message('不能为物品类别添加子级树', 'warning');
        return;
    }
    var iframe = "../CangKu/EditCategory.aspx?ParentID=" + row.id;
    do_open_dialog('新增类别', iframe);
}
function editRow(ID) {
    var iframe = "../CangKu/EditCategory.aspx?ID=" + ID;
    do_open_dialog('修改类别', iframe);
}
function removeRows() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个类别进行此操作", "warning");
        return;
    }
    var IDList = [];
    var isBalance = false;
    $.each(rows, function (index, row) {
        if (row.id > 1) {
            IDList.push(row.id);
        }
    })
    if (IDList.length == 0) {
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的类别", function (r) {
        if (r) {
            var options = { visit: 'removecategory', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        if (message.haschild) {
                            show_message("请先删除子级树", "warning");
                            return;
                        }
                        show_message('删除成功', 'success', function () {
                            $.each(IDList, function (index, ID) {
                                $("#tt_table").treegrid("remove", ID);
                            })
                            $("#tt_table").treegrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}