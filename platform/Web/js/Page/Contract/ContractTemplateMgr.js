var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'TemplateNo', title: '模板编号', width: 100 },
        { field: 'TemplateName', title: '模板名称', width: 100 },
        { field: 'TemplateSummary', title: '模板说明', width: 100 },
        { field: 'StatusDesc', title: '状态', width: 100 },
        ]],
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
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadcontracttemplategrid",
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "TemplateStatus": $("#tdTemplateStatus").combobox("getValue"),
    });
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个模板", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个模板", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../Contract/EditTemplate.aspx?ID=" + ID;
    do_open_dialog('修改模板', iframe);
}
function addRow() {
    var iframe = "../Contract/EditTemplate.aspx";
    do_open_dialog('新增模板', iframe);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个模板", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的模板?", function (r) {
        if (r) {
            var options = { visit: 'removecontracttemplate', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
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