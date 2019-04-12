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
        { field: 'UserName', title: '发帖人', width: 100 },
        { field: 'CategoryName', title: '所属分类', width: 100 },
        { field: 'CommentCount', formatter: formatComment, title: '回复用户数', width: 100 },
        { field: 'AddTime', formatter: formatDateTime, title: '发帖时间', width: 100 },
        { field: 'operation', formatter: formatOperation, title: '操作', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var Keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmallthreadgrid",
        "keywords": Keywords,
        "Type": Type
    });
}
function formatComment(value, row) {
    if (CanViewComment != 1) {
        return '';
    }
    var result = row.CommentCount + '&nbsp;&nbsp;';
    if (row.CommentCount > 0) {
        result += '<a target="_blank" href="javascript:do_view_comment(' + row.ID + ')">查看评论</a>';
    }
    return result;
}
function formatOperation(value, row) {
    var result = '';
    if (CanViewThread == 1) {
        result += '<a target="_blank" href="javascript:do_view(' + row.ID + ')">查看</a>&nbsp;&nbsp;&nbsp;';
    }
    if (CanStopComment == 1) {
        if (!row.IsStopComment) {
            result += ' <a target="_blank" href="javascript:do_stop(' + row.ID + ',1)">禁止评论</a>';
        }
        else {
            result += ' <a target="_blank" href="javascript:do_stop(' + row.ID + ',0)">恢复评论</a>';
        }
    }
    return result;
}
function do_view_comment(ID) {
    var iframe = "../APPSetup/ThreadCommentMgr.aspx?ID=" + ID;
    do_open_dialog('查看评论', iframe);
}
function do_view(ID) {
    if (!ID) {
        var row = $("#tt_table").datagrid("getSelected");
        if (row == null) {
            show_message('请先选择一行数据', 'warning');
            return;
        }
        ID = row.ID;
    }
    var iframe = "../APPSetup/ThreadView.aspx?ID=" + ID;
    do_open_dialog('查看帖子', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm('提示', '确认删除选中的帖子?', function (r) {
        if (r) {
            var options = { visit: 'removemallthread', IDList: JSON.stringify(IDList) };
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
function do_stop(ID, type) {
    var IDList = [];
    IDList.push(ID);
    var msg = '确认禁止评论?';
    if (type == 0) {
        msg = '确认恢复评论?';
    }
    top.$.messager.confirm('提示', msg, function (r) {
        if (r) {
            var options = { visit: 'stopmallthread', IDList: JSON.stringify(IDList), type: type };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success');
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

