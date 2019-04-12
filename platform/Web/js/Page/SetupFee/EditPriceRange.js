var tt_CanLoad = false;
$(function () {
    loadTT()
})
function loadTT() {
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/SysSettingHandler.ashx',
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
    getMaxValue();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadpricerangegrid",
        "SummaryID": ChargeID
    });
}
function saveData() {
    var isValid = ffobj.form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var id = $("#tdID").val();
    var MinValue = $("#tdMinValue").textbox("getValue");
    var MaxValue = $("#tdMaxValue").textbox("getValue");
    var BasePrice = $("#tdBasePrice").numberbox("getValue");
    var IsActive = $("#tdIsActive").combobox("getValue");
    var BaseType = $("#tdBaseType").combobox("getValue");
    if (MinValue == "无上限") {
        show_message("已添加到最大值", "info");
        return;
    }
    if (Number(MinValue) > Number(MaxValue)) {
        show_message("上限值不能小于下限值", "info");
        return;
    }
    var options = { visit: 'savepricerange', ID: id, SummaryID: ChargeID, MinValue: MinValue, MaxValue: MaxValue, BasePrice: BasePrice, IsActive: IsActive, BaseType: BaseType };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/SysSettingHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                if (!data.success) {
                    show_message("选择类型冲突，请重新选择", "info");
                    return;
                }
                show_message('保存成功', 'success', function () {
                    cancelSave();
                    $("#tt_table").datagrid("reload");
                    getMaxValue();
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function getMaxValue() {
    var options = { visit: 'getmaxpricevalue', ChargeID: ChargeID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/SysSettingHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status) {
                $('#tdMinValue').textbox('setValue', data.MaxValue);
            }
            else {
                $('#tdMinValue').textbox('setValue', "0");
            }
        }
    });
}
function cancelSave() {
    $("#tdID").val("");
    $("#tdMinValue").textbox("setValue", "");
    $("#tdMaxValue").textbox("setValue", "");
    $("#tdBasePrice").numberbox("setValue", "");
    $("#tdIsActive").combobox("setValue", 1);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length != 1) {
        show_message("请选择一行进行此操作", "info");
        return;
    }
    $("#tdID").val(rows[0].ID);
    $("#tdMinValue").textbox("setValue", rows[0].MinValue);
    $("#tdMaxValue").textbox("setValue", rows[0].MaxValue);
    $("#tdBasePrice").numberbox("setValue", rows[0].BasePrice);
    $("#tdIsActive").combobox("setValue", rows[0].IsActive ? 1 : 0);
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一行进行此操作", "info");
        return;
    }
    var allrows = $("#tt_table").datagrid("getRows");
    var IDList = [];
    var candelete = true;
    if (rows.length == 1) {
        if (rows[0].ID != allrows[0].ID && rows[0].ID != allrows[allrows.length - 1].ID) {
            candelete = false;
        }
        IDList.push(rows[0].ID);
    }
    else {
        $.each(rows, function (index, row) {
            if (rows[index].ID != allrows[index].ID) {
                candelete = false;
                return false;
            }
            IDList.push(row.ID);
        })
    }
    if (!candelete) {
        show_message("请依次选择后删除", "info");
        return;
    }
    top.$.messager.confirm("提示", "确认删除?", function (r) {
        if (r) {
            var options = { visit: 'deletepricerange', ids: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                            getMaxValue();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
