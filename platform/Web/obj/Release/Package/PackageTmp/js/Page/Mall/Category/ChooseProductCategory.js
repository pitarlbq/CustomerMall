
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
function do_choose() {
    var list = [];
    var rows = $('#tt_table').treegrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择分类', 'info');
        return;
    }
    var names = '';
    $.each(rows, function (index, row) {
        list.push(row.id);
        if (index > 0) {
            names += ",";
        }
        names += row.name;
    })
    parent.hdProductCategorys.val(JSON.stringify(list));
    parent.tdCategorys.textbox('setValue', names);
    parent.$("#winchoose").window('close');
    do_close();
}
function do_close() {
    parent.do_close_dialog();
}