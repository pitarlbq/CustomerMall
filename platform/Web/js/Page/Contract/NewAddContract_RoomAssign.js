var tt_CanLoad;
$(function () {
    setTimeout(function () {
        loadTT();
    }, 500);
});
function loadTT() {
    tt_CanLoad = false;
    $('#tt_room').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        columns: [[
            { field: 'ck', checkbox: true },
            { field: 'FullName', title: '资源位置', width: 260 },
            { field: 'Name', title: '资源编号', width: 80 },
            { field: 'RoomType', title: '房间类型', width: 80 },
            { field: 'ContractArea', formatter: formatNumber, title: '合同面积', width: 80 }
        ]],
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $('#tt_room').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_room').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    getContractID();
    $("#tt_room").datagrid("load", {
        "visit": "loadcontractroomlist",
        "guid": guid,
        "ContractID": ContractID
    });
}
function getContractID() {
    if (parent.ContractID > 0 && ContractID <= 0) {
        ContractID = parent.ContractID;
    }
}
function formatNumber(value, row) {
    return (Number(value) < 0 ? 0 : value);
}
function formatFullName(value, row) {
    if (row.FullName == '') {
        row.FullName = '所有房间';
    }
    return row.FullName;
}
function AddRoom() {
    getContractID();
    var iframe = "../Contract/AddContractRoom.aspx?guid=" + guid + "&ContractID=" + ContractID + "&canedit=" + canSaveLog;
    do_open_dialog('添加房间', iframe);
}
function RemoveRoom() {
    var rows = $("#tt_room").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个房间", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的房间", function (r) {
        if (r) {
            var options = { visit: 'removecontractroom', IDList: JSON.stringify(IDList), canedit: canSaveLog };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_room").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}