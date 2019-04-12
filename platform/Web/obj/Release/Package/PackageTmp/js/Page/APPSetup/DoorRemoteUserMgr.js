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
        { field: 'Title', title: '名称', width: 100 },
        { field: 'ProjectName', title: '小区', width: 100 },
        { field: 'FullName', title: '房号', width: 260 },
        { field: 'NickName', title: '姓名', width: 100 },
        { field: 'PhoneNumber', title: '电话', width: 100 },
        { field: 'DeviceInfo', title: '开门设备', width: 100 },
        { field: 'IsForeverDesc', title: '是否永久', width: 100 },
        { field: 'EndTime', formatter: formatTime, title: '到期时间', width: 100 },
        { field: 'IsActiveDesc', title: '是否启用', width: 300 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmalldoorremoteusergrid",
        "keywords": keywords,
    });
}

function do_add() {
    var iframe = "../APPSetup/DoorRemoteUserEdit.aspx";
    do_open_dialog('新增远程开门', iframe);
}
function do_edit() {
    var row = $("#tt_table").treegrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var iframe = "../APPSetup/DoorRemoteUserEdit.aspx?ID=" + row.ID;
    do_open_dialog('修改远程开门', iframe);
}
function do_remove() {
    var rows = $("#tt_table").treegrid("getSelections");
    if (rows.length == 0) {
        show_message('请先选择一行数据', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm('提示', '确认删除选中的远程开门?', function (r) {
        if (r) {
            var options = { visit: 'removedoorremoteuser', IDList: JSON.stringify(IDList) };
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

