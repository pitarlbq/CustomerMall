var tt_CanLoad = false;
$(function () {
    loadTT();
    loadChargeSummary();
    $("#tdDiscountType").combobox({
        onSelect: function (res) {
            if (res.value == "percent") {
                $("#Unit").html("%");
                $('.notfree').show();
                $("#tdDiscountValue").numberbox({ required: true });
            }
            else if (res.value == "allfree") {
                $('.notfree').hide();
                $("#tdDiscountValue").numberbox({ required: false });
            }
            else if (res.value == "permonth") {
                $("#Unit").html("月");
                $('.notfree').show();
                $("#tdDiscountValue").numberbox({ required: true });
            }
            else {
                $("#Unit").html("元");
                $('.notfree').show();
                $("#tdDiscountValue").numberbox({ required: true });
            }
        }
    })
})
function loadChargeSummary() {
    var options = { visit: "getchargesummarylist", CompanyID: CompanyID }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        data: options,
        url: '../Handler/FeeCenterHandler.ashx',
        success: function (data) {
            var list = [];
            list.push({ ID: 0, Name: "全部" });
            $.each(data, function (index, item) {
                list.push({ ID: item.ID, Name: item.Name });
            })
            $('#tdChargeSummary').combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
                multiple: true
            });
        }
    });
}
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
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadchargediscount"
    });
}
function formatValidTime(value, row) {
    var starttime = checktime(row.StartTime);
    var endtime = checktime(row.EndTime);
    if (starttime != "" || endtime != "") {
        return (starttime == "" ? "--" : starttime) + " 至 " + (endtime == "" ? "--" : endtime);
    }
    return "--";
}
function formatDiscountValue(value, row) {
    if (row.DiscountType == "percent") {
        return value + '%';
    }
    else {
        return value + '元';
    }
}
function formatRemark(value, row) {
    if (row.Remark.length > 10) {
        return row.Remark.substring(0, 10) + "...";
    }
    return row.Remark;
}
function checktime(time) {
    if (time == undefined || time == "" || time == null || time == '0001-01-01T00:00:00.0000000' || time == '0001-01-01T00:00:00' || time == '1900-01-01T00:00:00.0000000' || time == '1900-01-01T00:00:00') {
        return "";
    }
    return time.substring(0, 16).split("T")[0];
}
function savetype() {
    var isValid = $("#ff").form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var id = $("#tdID").val();
    var DiscountName = $("#tdDiscountName").textbox("getValue");
    var SortOrder = $("#tdSortOrder").numberbox("getValue");
    var DiscountType = $("#tdDiscountType").combobox("getValue");
    var DiscountValue = $("#tdDiscountValue").numberbox("getValue");
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    var ChargeSummaryIDs = $("#tdChargeSummary").combobox("getValues");
    var Remark = $("#tdRemark").textbox("getValue");
    var options = { visit: 'savechargediscount', id: id, DiscountName: DiscountName, SortOrder: SortOrder, DiscountType: DiscountType, DiscountValue: DiscountValue, StartTime: StartTime, EndTime: EndTime, ChargeSummaryIDs: JSON.stringify(ChargeSummaryIDs), Remark: Remark };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/SysSettingHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message('保存成功', 'success', function () {
                    $("#tt_table").datagrid("reload");
                });
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function canceltype() {
    $("#tdID").val("");
    $("#Unit").html("%");
    $("#tdDiscountName").textbox("setValue", "");
    $("#tdSortOrder").numberbox("setValue", "");
    $("#tdDiscountType").combobox("setValue", "");
    $("#tdDiscountValue").numberbox("setValue", "");
    $("#tdStartTime").datebox("setValue", "");
    $("#tdEndTime").datebox("setValue", "");
    $("#tdChargeSummary").combobox("setValues", []);
    $("#tdRemark").textbox("setValue", "");

}
function edittype() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length != 1) {
        show_message("请选择一行进行此操作", "info");
        return;
    }
    $("#tdID").val(rows[0].ID);
    $("#tdDiscountName").textbox("setValue", rows[0].DiscountName);
    $("#tdSortOrder").numberbox("setValue", rows[0].SortOrder);
    $("#tdDiscountType").combobox("setValue", rows[0].DiscountType);
    $("#tdDiscountValue").numberbox("setValue", rows[0].DiscountValue);
    $("#tdStartTime").datebox("setValue", checktime(rows[0].StartTime));
    $("#tdEndTime").datebox("setValue", checktime(rows[0].EndTime));
    $("#tdChargeSummary").combobox("setValues", (rows[0].ChargeSummaryIDs == "" ? [] : rows[0].ChargeSummaryIDs));
    $("#tdRemark").textbox("setValue", rows[0].Remark);
    if (rows[0].DiscountType == "percent") {
        $('.notfree').show();
        $("#Unit").html("%");
        $("#tdDiscountValue").numberbox({ required: true });
    }
    else if (rows[0].DiscountType == "allfree") {
        $('.notfree').hide();
        $("#tdDiscountValue").numberbox({ required: false });
    }
    else {
        $('.notfree').show();
        $("#Unit").html("元");
        $("#tdDiscountValue").numberbox({ required: true });
    }
}
function deletetype() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一行进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "确认删除?", function (r) {
        if (r) {
            var options = { visit: 'deletechargediscount', ids: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
