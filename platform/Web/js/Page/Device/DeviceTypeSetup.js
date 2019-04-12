var tt_CanLoad;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    $('#tt_table').treegrid({
        url: '../Handler/DeviceHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        idField: 'ID',
        treeField: 'Code',
        pagination: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        rownumbers: false,
        fit: true,
        fitColumns: true,
        columns: [[
       { field: 'Code', title: '编码', width: 100 },
       { field: 'DeviceTypeName', title: '设备类型', width: 100 },
       { field: 'TypeLevel', formater: formatTypeLevel, title: '级别', width: 100 },
       { field: 'Description', title: '说明', width: 300 },
        ]],
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
        onLoadSuccess: function () {
            $('#tt_table').treegrid('collapseAll');
            init();
        },
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").treegrid("load", {
        "visit": "loaddevicetype",
        "Keywords": $('#tdKeywords').searchbox('getValue')
    });
}
function formatTypeLevel(value, row) {
    if (parseFloat(value) <= 0) {
        return 1;
    }
    return value;
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
function addRow() {
    var row = $("#tt_table").treegrid("getSelected");
    var ParentID = (row == null ? 0 : row.ID);
    var iframe = "../Device/EditDeviceType.aspx?ParentID=" + ParentID;
    do_open_dialog('新增类型', iframe);
}
function editRow() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个类型进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Device/EditDeviceType.aspx?ID=" + ID;
    do_open_dialog('修改类型', iframe);
}
function removeRows() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个类型进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的类型", function (r) {
        if (r) {
            var options = { visit: 'deletedevicetype', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/DeviceHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        if (!data.success) {
                            show_message("当前类型包含子类型，请先删除子类型", "info");
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