var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
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
        onDblClickRow: onDblClickRowTT,
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
        { field: 'LevelName', formatter: formatDateTime, title: '奖项名称', width: 150 },
        { field: 'Quota', title: '中奖名额', width: 100 },
        { field: 'PrizeName', title: '奖品名称', width: 100 },
        { field: 'PrizeTypeDesc', title: '奖品类型', width: 100 },
        { field: 'PrizeQuantity', title: '奖品数量', width: 100 },
        { field: 'PrizeUnit', title: '计量单位', width: 100 },
        { field: 'RepeatTime', title: '重复中奖次数', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getlotteryprizegrid",
        "keywords": keywords,
        "ActivityID": ActivityID
    });
}
function addRow() {
    var iframe = "../Wechat/EditLotteryPrize.aspx?ActivityID=" + ActivityID;
    do_open_dialog('新增奖项', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个奖项进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    EditDataByRow(rows[0]);
}
function onDblClickRowTT(index, row) {
    EditDataByRow(row)
}
function EditDataByRow(row) {
    var iframe = "../Wechat/EditLotteryPrize.aspx?ActivityID=" + ActivityID + "&ID=" + row.ID;
    do_open_dialog('修改奖项', iframe);
}
function removeRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择需要删除的数据', 'info');
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    top.$.messager.confirm('提示', '确认要删除选中的奖项?', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'deletelotteryprize', IDList: JSON.stringify(IDList), ActivityID: ActivityID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
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
