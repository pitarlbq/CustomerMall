var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/ServiceHandler.ashx',
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
        { field: 'PayName', title: '项目名称', width: 100 },
        { field: 'RelateFeeTypeDesc', title: '关联单据类型', width: 150 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 300 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadpaysummarygrid",
        "keywords": keywords
    });
}
function formatOperation(index, row) {
    return '<a onclick="editRow(' + row.ID + ')"><span style="color:red;">编辑</span></a>';
}
function onDblClickRowTT(index, row) {
    editRow(row.ID)
}
function addRow() {
    var iframe = "../PayService/EditPaySummary.aspx";
    do_open_dialog('新增项目', iframe);
}
function editRow(ID) {
    var iframe = "../PayService/EditPaySummary.aspx?ID=" + ID;
    do_open_dialog('修改项目', iframe);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个用户进行此操作", "info");
        return;
    }
    var IDList = [];
    var isBalance = false;
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的项目", function (r) {
        if (r) {
            var options = { visit: 'removepaysummary', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ServiceHandler.ashx',
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