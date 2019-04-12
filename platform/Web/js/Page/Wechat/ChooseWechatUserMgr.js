var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
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
        { field: 'ChooseState', title: '状态', width: 100 },
        { field: 'NickName', title: '昵称', width: 100 },
        { field: 'City', formatter: formatCity, title: '城市', width: 100 },
        { field: 'SexDesc', title: '性别', width: 100 },
        { field: 'SubscribeTime', formatter: formatDateTime, title: '关注时间', width: 150 },
        { field: 'UnSubscribeDesc', title: '关注状态', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getwechatuserlist",
        "keywords": keywords,
        "excludeproject": true,
        "Wechat_MsgID": MsgID,
        "ChooseState": $('#tdChooseState').combobox('getValue')
    });
}
function formatFullName(value, row) {
    return row.FullName.replace(/-/g, '') + row.Name;
}
function formatCity(value, row) {
    var result = '';
    if (row.Province != '') {
        result += row.Province + " ";
    }
    if (row.City != '') {
        result += row.City;
    }
    return result;
}
function chooseUser() {
    var rows = $("#tt_table").datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请勾选用户", 'info');
        return;
    }
    var List = [];
    $.each(rows, function (index, row) {
        if (row.OpenId) {
            List.push(row.OpenId);
        }
    })
    if (List.length == 0) {
        show_message("请勾选用户", 'info');
        return;
    }
    MaskUtil.mask('body', '提交中');
    top.$.messager.confirm("提示", "确认选择?", function (r) {
        if (r) {
            var options = { visit: 'savewechatmsguser', List: JSON.stringify(List), MsgID: MsgID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
                            closeWin();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function closeWin() {
    parent.$('#winadd').window('close');
}
function cancelUser() {
    var rows = $("#tt_table").datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请勾选用户", 'info');
        return;
    }
    var List = [];
    $.each(rows, function (index, row) {
        if (row.OpenId) {
            List.push(row.OpenId);
        }
    })
    if (List.length == 0) {
        show_message("请勾选用户", 'info');
        return;
    }
    MaskUtil.mask('body', '提交中');
    top.$.messager.confirm("提示", "确认取消?", function (r) {
        if (r) {
            var options = { visit: 'cancelwechatmsguser', List: JSON.stringify(List), MsgID: MsgID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
                            closeWin();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}

