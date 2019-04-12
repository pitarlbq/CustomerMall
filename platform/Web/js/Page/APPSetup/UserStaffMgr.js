var tt_CanLoad = false;
$(function () {
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
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'HeadImg', formatter: formatHeadImg, title: '头像', width: 100 },
        { field: 'NickName', title: '姓名', width: 100 },
        { field: 'PhoneNumber', title: '电话', width: 100 },
        { field: 'Gender', title: '性别', width: 100 },
        { field: 'LoginName', title: '登录名', width: 100 },
        { field: 'IsLockedDesc', title: '是否有效', width: 100 },
        { field: 'PositionName', title: '岗位', width: 100 },
        { field: 'DepartmentName', title: '部门', width: 100 },
        { field: 'Education', title: '学历', width: 100 },
        { field: 'FixedPoint', formatter: formatFixedPoint, title: '固定积分', width: 100 },
        { field: 'MyCoupons', formatter: formatMyCoupons, title: '我的福顺券', width: 100 },
        ]],
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
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loaduserlist",
        "keywords": keywords,
        "UserRoomType": 3,
        "IsAPPUser": true
    });
}
function onDblClickRowTT(index, row) {
    EditUserByRow(row)
}
function formatMyCoupons(value, row) {
    if (CanViewCoupon != 1) {
        return '';
    }
    return '<a href="javascript:do_view_coupon(' + row.UserID + ')">查看</a>'
}
function formatFixedPoint(value, row) {
    if (value <= 0) {
        return 0;
    }
    return value;
}
function formatHeadImg(value, row) {
    if (row.HeadImg == '') {
        return '';
    }
    return '<img src="' + row.HeadImg + '" style="width:50px; height:50px;border-radius: 50%;" />';
}
function addUser() {
    var iframe = "../APPSetup/UserEdit.aspx?type=2";
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
    var iframe = "../APPSetup/UserEdit.aspx?type=2&UserID=" + row.UserID;
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
function view_check() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一个用户进行此操作', 'warning');
        return;
    }
    if (rows.length > 1) {
        show_message('请选择单行进行此操作', 'warning');
        return;
    }
    var iframe = "../Mall/UserCheckMySelfMgr.aspx?UserID=" + rows[0].UserID;
    do_open_dialog('考评记录', iframe);
}
function do_view_coupon(UserID) {
    var iframe = "../APPSetup/UserCouponMgr.aspx?UserID=" + UserID ;
    do_open_dialog('我的福顺券', iframe);
}
