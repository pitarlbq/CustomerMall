var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
});
function loadtt() {
    var singleSelect = singleselect == 1;
    $('#tt_table').datagrid({
        url: '../Handler/MallHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
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
        { field: 'FullName', title: '资源位置', width: 200 },
        { field: 'RoomName', title: '资源名称', width: 150 },
        { field: 'RelationName', title: '姓名', width: 150 },
        { field: 'RelatePhoneNumber', title: '电话', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallprojectusergrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "ProjectID": ProjectID,
        "IsHuHuoRen": IsHuHuoRen
    });
}
function do_choose() {
    var list = [];
    var row = $('#tt_table').datagrid('getSelected');
    if (row == null) {
        show_message('请选择用户', 'warning');
        return;
    }
    var UserID = (row.UserID > 0 ? row.UserID : 0);
    parent.hdUserID.val(UserID);
    parent.hdRelationID.val(row.ID);
    var userName = row.RelationName + "\r\n" + row.RelatePhoneNumber + "\r\n" + row.FullName + "-" + row.RoomName;
    parent.tdUserName.textbox('setValue', userName);
    try {
        parent.hdMemberLevelName.val(row.UserLevelName);
    } catch (e) {
    }
    do_close();
}
function do_close() {
    parent.do_close_dialog()
}