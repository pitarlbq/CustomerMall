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
        { field: 'RealName', title: '姓名', width: 100 },
        { field: 'LoginName', title: '登录名', width: 100 },
        { field: 'Wechat_NickName', title: '微信昵称', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getuserlisthasopenid",
        "keywords": keywords
    });
}
function chooseUser() {
    var rows = $("#tt_table").datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请勾选用户", 'info');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        if (row.OpenID) {
            IDList.push(row.UserID);
        }
    })
    if (IDList.length == 0) {
        show_message("请勾选用户", 'info');
        return;
    }
    MaskUtil.mask('body', '提交中');
    top.$.messager.confirm("提示", "确认选择?", function (r) {
        if (r) {
            var options = { visit: 'savelotterychecker', IDList: JSON.stringify(IDList), ActivityID: ActivityID };
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
    parent.$('#winchoose').window('close');
}

