var tt_CanLoad = false, isUpdate = false;
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
        { field: 'TypeDesc', title: '类型', width: 100 },
        { field: 'ImagePath', formatter: formatImagePath, title: '图片', width: 100 },
        { field: 'URLLinkTypeDesc', title: '链接方式', width: 100 },
        { field: 'SortOrder', title: '排序', width: 100 },
        { field: 'AddTime', formatter: formatDateTime, title: '添加时间', width: 100 },
        { field: 'IsActiveDesc', title: '状态', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var Type = $('#tdType').combobox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmallrotatingimagegrid",
        "Type": Type,
    });
}
function formatImagePath(value, row) {
    var result = '';
    if (row.ImagePath != '' && null != row.ImagePath) {
        result = '<img style="width:50px; height:50px;border-radius:50%;" src="' + row.ImagePath + '" />';
    }
    return result;
}

function do_add() {
    var iframe = "../APPSetup/RotatingImageEdit.aspx";
    do_open_dialog('新增图片', iframe);
}
function do_edit() {
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var iframe = "../APPSetup/RotatingImageEdit.aspx?ID=" + row.ID;
    do_open_dialog('修改图片', iframe);
}
function do_remove() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm('提示', '确认删除选中的图片?', function (r) {
        if (r) {
            var options = { visit: 'deleteroatingimage', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success');
                        $("#tt_table").datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}

