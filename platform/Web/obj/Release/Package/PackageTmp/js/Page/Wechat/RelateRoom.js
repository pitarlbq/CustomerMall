var tt_CanLoad = false;
$(function () {
    loadTT();
});
function loadTT() {
    var options = { visit: 'loadtablecolumn', pagecode: 'roomsource' };
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
                    border: false,
                    remoteSort: false,
                    pagination: true,
                    rownumbers: true,
                    fit: true,
                    fitColumns: false,
                    singleSelect: false,
                    selectOnCheck: true,
                    checkOnSelect: true,
                    striped: true,
                    onDblClickRow: onDblClickRow,
                    columns: finalcolumn,
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
                    toolbar: '#tb'
                });
                SearchTT();
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function SearchTT() {
    var roomids = [];
    var projectids = [];
    try {
        roomids = GetSelectCheck();
        var projectid = GetSelectRadio();
        if (projectid != null && projectid != "") {
            projectids.push(projectid);
        }
    } catch (e) {

    }
    var RoomStatus = $("#tdRoomStatus").combobox('getValue');
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadroomresourcelist",
        "RoomID": JSON.stringify(roomids),
        "ProjectID": JSON.stringify(projectids),
        "ID": ID,
        "RoomStatus": RoomStatus
    });
}
function onDblClickRow(index, row) {
    editRoomSource(row.RoomID, row.Name)
}
function editRoomSource(RoomID, Name) {
    var iframe;
    iframe = "../RoomResource/EditRoomResource.aspx?RoomID=" + RoomID ;
    do_open_dialog('修改' + Name + '信息', iframe);
}
function EditRoomResource_Done(){
    if (isUpdate) {
        $("#tt_table").datagrid("reload");
        doSearch();
        isUpdate = false;
    }
}
function formatNumber(value, row) {
    if (value < 0) {
        return 0;
    }
    return value;
}
function formatMonth(value, row) {
    if (value == undefined || value == null || value == '0001-01-01T00:00:00.0000000' || value == '0001-01-01T00:00:00' || value == '1900-01-01T00:00:00.0000000' || value == '1900-01-01T00:00:00') {
        return "--";
    }
    return value.substring(0, 7);
}
function connetctRoom() {
    var roomids = GetSelectCheck();
    if (roomids.length == 0) {
        show_message('请选择房间', 'info');
        return;
    }
    var options = { visit: 'connectroom', ID: ID, RoomIDList: JSON.stringify(roomids) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/WechatHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                show_message(data.msg, 'warning');
                $('#tt_table').datagrid("reload");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function disconnetctRoom() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择房间', 'info');
        return;
    }
    var roomids = [];
    $.each(rows, function (index, item) {
        roomids.push(item.RoomID);
    })
    var options = { visit: 'disconnectroom', ID: ID, RoomIDList: JSON.stringify(roomids) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/WechatHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message("取消关联成功", "info");
                $('#tt_table').datagrid("reload");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function viewQrCode() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择房间', 'info');
        return;
    }
    if (rows.length > 1) {
        show_message('请选择单个房间', 'info');
        return;
    }
    var options = { visit: 'viewqrcode', ID: rows[0].RoomID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/WechatHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                window.open(data.PicPath);
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
