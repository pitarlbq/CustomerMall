var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    var options = { visit: 'loadtablecolumn', pagecode: 'wechatusermgr' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
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
                    columns: finalcolumn,
                    toolbar: '#tt_mm'
                });
                SearchTT();
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var RoomID = [];
    var ProjectID = [];
    try {
        RoomID = GetSelectedRooms();
        ProjectID = GetSelectedProjects();
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
        "visit": "getwechatuserlist",
        "keywords": keywords,
        "RoomID": JSON.stringify(RoomID),
        "ProjectID": JSON.stringify(ProjectID),
        "IsShowSubscribe": IsShowSubscribe,
        "IsShowUnSubscribe": IsShowUnSubscribe
    });
}
function formatFullName(value, row) {
    return row.FullName.replace(/-/g, '') + row.Name;
}
function formatOperation(value, row) {
    var $html = '<div>';
    $html += '<a onclick="doViewQrCode(' + row.ID + ')"><span style="color:red;">查看</span></a>';
    $html += '</div>';
    return $html;
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
function tongBuUser() {
    top.$.messager.confirm('提示', '确认同步微信公众号粉丝到本地数据库?', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'tongbuwechatuser' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message("同步成功", "success");
                        $("#tt_table").datagrid("reload");
                    }
                }
            });
        }
    })

}
function connectRoom(ID) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Wechat/RelateRoom.aspx?ID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    do_open_dialog('关联房间信息', iframe);
}
function RelateRoom_Done() {

}
function doViewQrCode(ID) {
    var iframe = "../Wechat/ViewQrCode.aspx?ID=" + ID;
    do_open_dialog('查看二维码', iframe);
}
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=wechatusermgr";
    do_open_dialog('粉丝列表设置', iframe);
}
function cancelSubscribe() {
    var rows = $("#tt_table").datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请勾选需要取消关注资源列表", 'info');
        return;
    }
    var List = [];
    $.each(rows, function (index, row) {
        if (row.OpenId) {
            List.push({ RoomID: row.ID, OpenID: row.OpenId });
        }
    })
    if (List.length == 0) {
        show_message("请选择已关注资源列表", 'info');
        return;
    }
    top.$.messager.confirm("提示", "确认取消关注?", function (r) {
        if (r) {
            var options = { visit: 'cancelsubscribe', List: JSON.stringify(List) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message("取消成功", "success", function () {
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

