﻿var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
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
        { field: 'Name', title: '部门名称', width: 100 },
        { field: 'Summary', title: '部门描述', width: 100 },
        { field: 'SortOrder', formatter: formatIntCount, title: '排序序号', width: 100 },
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
        "visit": "loadmalldepartmentgrid",
        "keywords": keywords
    });
}
function onDblClickRowTT(index, row) {
    editByRow(row.ID)
}
function formatOperation(value, row) {
    var $html = '';
    if (CanEdit != 1) {
        return $html;
    }
    $html += '<a onclick="editByRow(' + row.ID + ')"><span style="color:red;">修改</span></a>';
    return $html;
}
function addRow() {
    var iframe = "../APPSetup/DepartmentEdit.aspx";
    do_open_dialog('新增部门', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个部门进行此操作', 'warning');
        return;
    }
    if (rows.length > 1) {
        show_message('请选择单行进行此操作', 'warning');
        return;
    }
    editByRow(rows[0].ID);
}
function editByRow(ID) {
    if (CanEdit != 1) {
        return;
    }
    var iframe = "../APPSetup/DepartmentEdit.aspx?ID=" + ID;
    do_open_dialog('修改部门', iframe);
}
function removeRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个进行此操作', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的部门", function (r) {
        if (r) {
            var options = { visit: 'removemalldepartment', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
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