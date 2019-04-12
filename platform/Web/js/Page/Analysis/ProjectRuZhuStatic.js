var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    var options = { visit: 'loadruzhustaticcolumn' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                //加载
                $('#tt_table').treegrid({
                    url: '../Handler/AnalysisHandler.ashx?ProjectID=1',
                    loadMsg: '正在加载',
                    rownumbers: true,
                    animate: true,
                    collapsible: true,
                    fit: true,
                    fitColumns: true,
                    idField: 'id',
                    treeField: '资源类别',
                    columns: finalcolumn,
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
                    onBeforeExpand: function (row) {
                        //动态设置展开查询的url  
                        var url = '../Handler/AnalysisHandler.ashx?ProjectID=' + row.id;
                        $("#tt_table").treegrid("options").url = url;
                        return true;
                    },
                    onExpand: function (row) {
                        var children = $("#tt_table").treegrid('getChildren', row.id);
                        if (children.length <= 0) {
                            $("#tt_table").treegrid('refresh', row.id);
                        }
                    },
                    onLoadSuccess: function (node, data) {
                        init();
                    }
                });
                SearchTT();
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function init() {
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").treegrid("load", {
        "visit": "loadroomruzhustaticlist"
    });
}
function formatCount(value, row) {
    if (value == "" || value == null) {
        return 0;
    }
    return value;
}
