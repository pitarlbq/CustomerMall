
var tt_CanLoad = false;
$(function () {
    loadtt();
});
function loadtt() {
    $('#tt_table').treegrid({
        url: '../Handler/MallHandler.ashx',
        loadMsg: '正在加载',
        rownumbers: true,
        animate: true,
        collapsible: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        idField: 'id',
        treeField: 'name',
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
        toolbar: '#tt_mm',
        onLoadSuccess: function (data) {
            init();
        }
    });
    SearchTT();
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").treegrid("load", {
        "visit": "loadmallcategorygrid",
        "keywords": $("#tdKeyword").searchbox("getValue"),
        "type": type
    });
}
function formatCoverImage(value, row) {
    var result = '';
    if (row.PicturePath != '' && null != row.PicturePath) {
        result = '<img class="cover_image" style="width:50px; height:50px;border-radius:50%;" src="' + row.PicturePath + '" />';
    }
    return result;
}
function onDblClickRowTT(index, row) {
    do_edit_byid(row.id)
}
function do_add() {
    var ParentID = 0;
    var row = $("#tt_table").treegrid("getSelected");
    if (row != null) {
        ParentID = row.id;
        if (row.ParentID > 0) {
            show_message('不能为二级分类添加子集分类', 'info');
            return;
        }
    }
    var iframe = "../Mall/CategoryEdit.aspx?ParentID=" + ParentID + "&type=" + type;
    do_open_dialog('新增分类', iframe);
}
function do_edit() {
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    do_edit_byid(row.id);
}
function do_edit_byid(ID) {
    var iframe = "../Mall/CategoryEdit.aspx?ID=" + ID + "&type=" + type;
    do_open_dialog('修改分类', iframe);
}
function do_remove() {
    var rows = $("#tt_table").treegrid("getSelections");
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
    top.$.messager.confirm("提示", "确认删除选中的分类?", function (r) {
        if (r) {
            var options = { visit: 'removemallcategory', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        $.each(IDList, function (index, ID) {
                            $("#tt_table").treegrid("remove", ID);
                        })
                        show_message('操作成功', 'success', function () {
                            SearchTT();
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