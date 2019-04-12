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
        { field: 'InCategoryName', title: '分类名称', width: 100 },
        { field: 'CategoryTypeDesc', title: '类型', width: 100 },
        { field: 'InCategoryDesc', title: '分类描述', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 150, align: 'center' }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadincategorygrid",
        "keywords": keywords,
        "CategoryType": CategoryType
    });
}
function onDblClickRowTT(index, row) {
    editByRow(row.ID)
}
function formatOperation(value, row) {
    var $html = '';
    $html += '<a onclick="editByRow(' + row.ID + ')"><span style="color:red;">修改</span></a>';
    return $html;
}
function addRow() {
    var iframe = "../CangKu/EditInCategory.aspx";
    do_open_dialog('新增分类', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个分类进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    editByRow(rows[0].ID);
}
function editByRow(ID) {
    var iframe = "../CangKu/EditInCategory.aspx?ID=" + ID;
    do_open_dialog('修改分类', iframe);
}
function removeRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个进行此操作", "warning");
        return;
    }
    var IDList = [];
    var is_system = false;
    $.each(rows, function (index, row) {
        if (row.IsSystemAdd == 1) {
            is_system = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (is_system) {
        show_message("系统类别，禁止删除", "warning");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的分类", function (r) {
        if (r) {
            var options = { visit: 'removeincategory', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                            doSearch();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function chooseRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个分类进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    try {
        parent.ChosenInCategoryID = rows[0].ID;
    } catch (e) {
    }
    do_close();
}

