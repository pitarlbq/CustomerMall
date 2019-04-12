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
        { field: 'FullName', title: '资源位置', width: 300 },
        { field: 'Name', title: '房间信息', width: 300 },
        { field: 'NickName', title: '业主昵称', width: 100 },
        { field: 'PhoneNumber', title: '联系电话', width: 100 },
        { field: 'QrCode', formatter: formatOperation, title: '二维码', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var RoomIDs = [];
    var ProjectIDs = [];
    try {
        RoomIDs = GetSelectedRooms();
        ProjectIDs = GetSelectedProjects();
    } catch (e) {

    }
    var IsShowSubscribe = 0;
    var IsShowUnSubscribe = 0;
    if ($('#Subscribe').prop('checked')) {
        IsShowSubscribe = 1;
    }
    if ($('#UnSubscribe').prop('checked')) {
        IsShowUnSubscribe = 1;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getbindprojectlist",
        "keywords": keywords,
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "IsShowSubscribe": IsShowSubscribe,
        "IsShowUnSubscribe": IsShowUnSubscribe
    });
}
function formatOperation(value, row) {
    var $html = '<div>';
    $html += '<a onclick="doViewQrCode(\'' + row.EncriptID + '\')" style="color:red;">查看</a>';
    $html += '</div>';
    return $html;
}
function doViewQrCode(content) {
    var iframe = "../Wechat/ViewQrCodeByURL.aspx?content=" + content;
    do_open_dialog('微信二维码', iframe);
}
function do_cancel() {
    var rows = $("#tt_table").datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请勾选需要取消关注资源列表', 'warning');
        return;
    }
    var List = [];
    $.each(rows, function (index, row) {
        if (row.UserID > 0) {
            List.push({ RoomID: row.ID, UserID: row.UserID });
        }
    })
    if (List.length == 0) {
        show_message('请选择已绑定的资源列表', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "确认取消绑定?", function (r) {
        if (r) {
            var options = { visit: 'canceluserbind', List: JSON.stringify(List) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('取消成功', 'success', function () {
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

