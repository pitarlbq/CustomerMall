var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/ServiceHandler.ashx',
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
        { field: 'ServiceFullName', title: '资源位置', width: 100 },
        { field: 'AddCustomerName', title: '反映人', width: 100 },
        { field: 'AddTime', formatter: formatDateTime, title: '添加时间', width: 100 },
        { field: 'ServiceContent', title: '反应内容', width: 300 },
        ]],
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        showFooter: true,
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
    setTimeout(function () {
        SearchTT()
    }, 100);
}
function SearchTT() {
    tt_CanLoad = true;
    var options = {
        "visit": "loadservicelist",
        "Keywords": $("#tdKeywords").searchbox("getValue"),
        "ServiceType": 2
    };
    $("#tt_table").datagrid("load", options);
}

function do_view() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个任务", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "../CustomerService/ServiceSuggestionEdit.aspx?op=view&ID=" + ID;
    do_open_dialog('投诉建议详情', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个任务", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的数据？", function (r) {
        if (r) {
            var options = { visit: 'removeservice', IDList: JSON.stringify(IDList) };
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