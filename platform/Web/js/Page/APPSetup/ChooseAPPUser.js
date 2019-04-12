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
        { field: 'NickName', title: '昵称', width: 100 },
        { field: 'PhoneNumber', title: '电话', width: 100 },
        { field: 'Gender', title: '性别', width: 100 },
        { field: 'LoginName', title: '登录名', width: 100 },
        { field: 'IsLockedDesc', title: '是否有效', width: 100 },
        { field: 'UserRoomTypeDesc', title: '用户类型', width: 100 },
        { field: 'UserRoomDesc', formatter: formatUserRoomDesc, title: '用户小区', width: 500 }
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
    var UserRoomType = $("#tdUserRoomType").combobox("getValue");
    tt_CanLoad = true;
    var roomids = [];
    var projectids = [];
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
    } catch (e) {

    }
    $("#tt_table").datagrid("load", {
        "visit": "loaduserlist",
        "keywords": keywords,
        "UserRoomType": UserRoomType,
        "IsAPPCustomerAndUser": true,
        "RoomIDs":JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
    });
}
function do_choose() {
    var UserIDs = '';
    var NickNames = '';
    if (singleselect == 1) {
        var row = $('#tt_table').datagrid('getSelected');
        if (row == null) {
            show_message('请选择用户', 'warning');
            return;
        }
        UserIDs = row.UserID;
        NickNames = row.NickName;
        if (row.NickName == '') {
            NickNames = row.PhoneNumber;
        }
    }
    else {
        var rows = $('#tt_table').datagrid('getSelections');
        if (rows.length == 0) {
            show_message('请选择用户', 'warning');
            return;
        }
        var list = [];
        $.each(rows, function (index, row) {
            list.push(row.UserID);
            if (index > 0) {
                NickNames += ",";
            }
            NickNames += row.NickName;
            if (row.NickName == '') {
                NickNames += row.PhoneNumber;
            }
        })
        UserIDs = JSON.stringify(list);
    }
    parent.hdUserID.val(UserIDs);
    parent.tdNickName.textbox('setValue', NickNames);
    do_close();
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
    return '<img src="' + row.HeadImg + '" style="width:60px; height:60px;border-radius: 50%;" />';
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
function do_close() {
    parent.do_close_dialog()
}

