var tt_CanLoad = false;
$(function () {
    loadtt();
});
function loadtt() {
    var singleSelect = singleselect == 1;
    $('#tt_table').datagrid({
        url: '../Handler/UserHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        fit: true,
        fitColumns: true,
        singleSelect: singleSelect,
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
        "UserRoomType": 3
    });
}
function formatFixedPoint(value, row) {
    if (value <= 0) {
        return 0;
    }
    return value;
}
function do_choose() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择用户', 'info');
        return;
    }
    var Names = '';
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.UserID);
        if (index > 0) {
            Names += ',';
        }
        Names += row.FinalRealName;
    })
    if (from == 'UserCheckAdd') {
        parent.hdUserIDs.val(JSON.stringify(IDList));
        parent.tdUserName.textbox('setValue', Names);
    }
    do_close();
}
function do_close() {
    parent.do_close_dialog();
}
function formatHeadImg(value, row) {
    if (row.HeadImg == '') {
        return '';
    }
    return '<img src="' + row.HeadImg + '" style="width:60px; height:60px;border-radius: 50%;" />';
}


