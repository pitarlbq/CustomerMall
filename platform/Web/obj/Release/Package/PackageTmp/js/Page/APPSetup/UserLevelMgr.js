var tt_CanLoad = false;
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
        { field: 'Name', title: '等级名称', width: 100 },
        { field: 'Remark', title: '等级描述', width: 200 },
        { field: 'ActiveAmountRange', title: '等级生效金额区间', width: 300 },
        { field: 'UserCount', title: '用户数', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmalluserlevelgrid",
        "keywords": keywords
    });
}
function onDblClickRowTT(index, row) {
    EditDataByRow(row)
}
function do_add() {
    var iframe = "../APPSetup/UserLevelEdit.aspx";
    do_open_dialog('新增用户等级', iframe);
}
function do_edit() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个用户等级进行此操作', 'warning');
        return;
    }
    if (rows.length > 1) {
        show_message('请选择单行进行此操作', 'warning');
        return;
    }
    EditDataByRow(rows[0]);
}
function EditDataByRow(row) {
    if (CanEdit != 1) {
        return;
    }
    var iframe = "../APPSetup/UserLevelEdit.aspx?LevelID=" + row.ID;
    do_open_dialog('修改用户等级', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个用户等级进行此操作', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的用户等级", function (r) {
        if (r) {
            var options = { visit: 'removeuserlevel', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
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
