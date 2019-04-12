var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/SettingHandler.ashx',
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
        { field: 'DepartmentCategoryNumber', title: '部门分类编码', width: 100 },
        { field: 'DepartmentCategoryName', title: '部门分类名称', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loaddepartmentcategorygrid",
        "keywords": keywords
    });
}
function onDblClickRowTT(index, row) {
    EditDataByRow(row)
}
function addRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/DepartmentCategoryEdit.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winsubadd'></div>").appendTo("body").window({
        title: '新增部门分类',
        width: ($(window).width() - 400),
        height: $(window).height(),
        top: 0,
        left: 200,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winsubadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function editRow() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请至少选择一项进行此操作", "info");
        return;
    }
    EditDataByRow(row);
}
function EditDataByRow(row) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/DepartmentCategoryEdit.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winsubadd'></div>").appendTo("body").window({
        title: '修改部门分类',
        width: ($(window).width() - 400),
        height: $(window).height(),
        top: 0,
        left: 200,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winsubadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一项进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "删除选中项?", function (r) {
        if (r) {
            var options = { visit: 'removedepartmentcategory', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SettingHandler.ashx',
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
