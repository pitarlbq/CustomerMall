var tt_CanLoad = false, columnlist = [], finalcolumns = [];
$(function () {
    columnlist = [
        { field: 'ck', checkbox: true },
        { field: 'HeadImg', formatter: formatHeadImg, title: '头像', width: 100 },
        { field: 'NickName', title: '昵称', width: 100 },
        { field: 'PhoneNumber', title: '电话', width: 100 },
        { field: 'Gender', title: '性别', width: 100 },
        { field: 'LoginName', title: '登录名', width: 100 },
        { field: 'IsLockedDesc', title: '是否有效', width: 100 },
        { field: 'UserRoomTypeDesc', title: '用户类型', width: 100 },
        { field: 'UserRoomDesc', formatter: formatUserRoomDesc, title: '用户小区', width: 300 }
    ];
    if (IsFuShunJu == 1) {
        columnlist.push({ field: 'MyCoupons', formatter: formatMyCoupons, title: '我的福顺券', width: 100 });
        columnlist.push({ field: 'AmountBanalce', title: '账户余额', width: 100 });
        columnlist.push({ field: 'PointBalance', title: '积分余额', width: 100 });
    }
    finalcolumns.push(columnlist);
    loadtt();
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/UserHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
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
        columns: finalcolumns,
        toolbar: '#tt_mm',
        onLoadSuccess: function () {
            $('#tt_table').datagrid('fixRowHeight')
        }
    });
    SearchTT();
}
function onClick() {
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var UserRoomType = $("#tdUserRoomType").combobox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loaduserlist",
        "keywords": keywords,
        "UserRoomType": UserRoomType,
        "IsAPPCustomer": true
    });
}
function onDblClickRowTT(index, row) {
    EditUserByRow(row)
}
function formatMyCoupons(value, row) {
    return '<a href="javascript:do_view_coupon(' + row.UserID + ')">查看</a>'
}
function formatUserRoomDesc(value, row) {
    if (row.UserRoomDesc != null && row.UserRoomDesc.length > 0) {
        var result = "";
        $.each(row.UserRoomDesc, function (index, item) {
            if (index > 0) {
                result += "<br/>";
            }
            result += item;
        })
        return result;
    }
    return '';
}
function formatHeadImg(value, row) {
    if (row.HeadImg == '') {
        return '';
    }
    return '<img src="' + row.HeadImg + '" style="width:50px; height:50px;border-radius: 50%;" />';
}
function formatActiveTime(value, row) {
    if (row.IsLocked) {
        return "--";
    }
    if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 16).split("T")[0];
}
function formatLockTime(value, row) {
    if (!row.IsLocked) {
        return "--";
    }
    if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 16).split("T")[0];
}
function addUser() {
    var iframe = "../APPSetup/UserEdit.aspx";
    do_open_dialog('新增用户', iframe);
}
function editUser() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个用户进行此操作', 'warning');
        return;
    }
    if (rows.length > 1) {
        show_message('请选择单行进行此操作', 'warning');
        return;
    }
    EditUserByRow(rows[0]);
}
function EditUserByRow(row) {
    if (CanEdit != 1) {
        return;
    }
    var iframe = "../APPSetup/UserEdit.aspx?UserID=" + row.UserID;
    do_open_dialog('修改用户', iframe);
}
function removeUser() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个用户进行此操作', 'warning');
        return;
    }
    var IDList = [];
    var isValid = false;
    $.each(rows, function (index, row) {
        if (row.IsLocked == 0) {
            isValid = true;
            return false;
        }
        IDList.push(row.UserID);
    })
    if (isValid) {
        show_message('只能删除失效账户', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的用户", function (r) {
        if (r) {
            var options = { visit: 'removeuser', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
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
function view_family() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个用户进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../APPSetup/UserFamilyMgr.aspx?UserID=" + rows[0].UserID;
    do_open_dialog('家庭成员', iframe);
}
function do_view_coupon(UserID) {
    var iframe = "../APPSetup/UserCouponMgr.aspx?UserID=" + UserID;
    do_open_dialog('我的福顺券', iframe);
}
function do_export() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var UserRoomType = $("#tdUserRoomType").combobox("getValue");
    var options = { visit: 'loaduserlist', keywords: keywords, UserRoomType: UserRoomType, IsAPPCustomer: true, can_export: true };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/UserHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                window.location.href = message.downloadurl;
                return;
            }
            if (message.error) {
                show_message(message.error, "error");
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
