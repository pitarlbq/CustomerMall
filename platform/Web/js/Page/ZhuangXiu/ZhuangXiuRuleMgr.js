var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    tt_CanLoad = false;
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/ZhuangXiuHandler.ashx',
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
        { field: 'CategoryName', title: '项目类别', width: 100 },
        { field: 'RuleName', title: '巡检项目', width: 100 },
        { field: 'RuleRequire', title: '整改要求', width: 200 },
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
        "visit": "loadzhuangxiurulegrid",
        "Keywords": $("#tdKeywords").searchbox("getValue")
    });
}
function OpenWin(iframe, title) {
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: title,
        width: ($(parent.window).width() - 450),
        height: $(parent.window).height(),
        top: 0,
        left: 250,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function addRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/AddRule.aspx' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '新增违规项目',
        width: ($(parent.window).width() - 200),
        height: $(parent.window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个违规项目", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个违规项目", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../ZhuangXiu/AddRule.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '修改违规项目',
        width: ($(parent.window).width() - 200),
        height: $(parent.window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请先选择一个违规项目", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "确认删除选中的记录?", function (r) {
        if (r) {
            var options = { visit: 'removezhuangxiufule', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ZhuangXiuHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
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
