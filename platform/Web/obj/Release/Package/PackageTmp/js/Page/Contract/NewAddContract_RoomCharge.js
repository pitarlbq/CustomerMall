var summary_CanLoad, summary_other_CanLoad, partyList = [], finalcolumn = [], canInsert = false, dgId = '';
$(function () {
    dgId = '#tt_chargesummary';
    partyList = parent.getPartyNames();
    loadColumns();
    top.disableEditRow = canEdit == 0;
});
function loadColumns() {
    finalcolumn = [[
        { field: 'ck', checkbox: true },
        { field: 'FullName', formatter: formatFullName, title: '房源位置', width: 200 },
        { field: 'Name', title: '房号', width: 80 },
        { field: 'ChargePartyName', formatter: formatPartyName, title: '收费主体', width: 100 },
        { field: 'ChargeName', title: '收费项目', width: 80 },
        { field: 'CalculateUnitPrice', editor: 'textbox', title: '单价', width: 80 },
        { field: 'CalculateUseCount', editor: 'textbox', title: '面积', width: 80 },
        { field: 'CalculateStartTime', editor: { type: 'datebox' }, formatter: formatTime, title: '计费开始日期', width: 100 },
        { field: 'CalculateEndTime', editor: { type: 'datebox' }, formatter: formatTime, title: '计费结束日期', width: 100 },
        { field: 'CalculateNewEndTime', editor: { type: 'datebox' }, formatter: formatTime, title: '计费停用日期', width: 100 },
        { field: 'ReadyChargeTime', editor: { type: 'datebox' }, formatter: formatTime, title: '收费日期', width: 100 },
        { field: 'CalcualteTotalCost', title: '应收金额', width: 80 },
        { field: 'CalcualtePayCost', title: '已收金额', width: 80 },
        { field: 'CalcualteRestCost', title: '未收金额', width: 80 },
        { field: 'CalcualteDiscount', title: '减免金额', width: 80 },
        { field: 'ChargeTypeDesc', title: '计费规则', width: 80 },
        { field: 'Remark', title: '备注', width: 80 }
    ]]
    getFieldList();
    loadsuammryTT();
}
function loadsuammryTT() {
    summary_CanLoad = false;
    $('#tt_chargesummary').datagrid({
        url: '../Handler/ContractHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: false,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: finalcolumn,
        onBeforeLoad: function (data) {
            if (!summary_CanLoad) {
                $('#tt_chargesummary').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return summary_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_chargesummary').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        onLoadSuccess: function (data) {
            totalIndex = -1;
            if (data.rows.length) {
                totalIndex = data.rows.length - 1;
                currentSelectIndex = data.rows.length - 1;
            }
        },
        onSelect: function (index, row) {
            endTTEditing();
            currentSelectIndex = index;
        },
        onClickCell: onClickCell,
        toolbar: '#tb_summary'
    });
    SearchSummaryTT();
}
function SearchSummaryTT() {
    getContractID();
    var StartTime = parent.getStartTime();
    var EndTime = parent.getEndTime();
    summary_CanLoad = true;
    $("#tt_chargesummary").datagrid("load", {
        "visit": "loadcontractchargelist",
        "guid": guid,
        "ContractID": ContractID,
        "StartTime": StartTime,
        "EndTime": EndTime,
        "canrent": canRent
    });
}
function getContractID() {
    if (parent.ContractID > 0 && ContractID <= 0) {
        ContractID = parent.ContractID;
    }
}
function formatPartyName(value, row) {
    if (partyList.length == 0) {
        return value;
    }
    var desc = '';
    var nameList = [];
    $.each(partyList, function (index, item) {
        if (item.id == row.ChargeID) {
            if ($.inArray(item.name, nameList) == -1) {
                nameList.push(item.name);
            }
        }
    })
    for (var i = 0; i < nameList.length; i++) {
        if (i > 0) {
            desc += ',';
        }
        desc += nameList[i];
    }
    return desc;
}
function AddCharge() {
    var roomRows = parent.getRooms();
    if (roomRows.length == 0) {
        show_message("请选择租赁资源", "info");
        return;
    }
    var StartTime = parent.getStartTime();
    var EndTime = parent.getEndTime();
    if (StartTime == "" || EndTime == "") {
        show_message("请填写合同开始结束日期", "info");
        return;
    }
    var startstamp = timeToStamp(StartTime);
    var endstamp = timeToStamp(EndTime);
    var renttostamp = ''
    if (canRent == 1) {
        var RentToTime = parent.getRentToTime();
        if (RentToTime == '') {
            show_message("请填写续租日期", "info");
            return;
        }
        if ((stringToDate(EndTime).valueOf() + (1000 * 60 * 60 * 24)) > stringToDate(RentToTime).valueOf()) {
            show_message("结束日期不能大于续租日期", "info");
            return;
        }
        renttostamp = timeToStamp(RentToTime);
    }
    getContractID();
    var iframe = "../Contract/NewAddContractCharge.aspx?guid=" + guid + "&ContractID=" + ContractID + "&startstamp=" + startstamp + "&endstamp=" + endstamp + "&canedit=" + canSaveLog + "&renttostamp=" + renttostamp + "&canrent=" + canRent;
    do_open_dialog('添加收费标准', iframe);
}
function AddCharge_Done() {
    var options = { visit: 'removecontracttemppricebyguid', guid: guid };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (message) {
        }
    });
    SearchSummaryTT();
}
function RemoveCharge() {
    var rows = $("#tt_chargesummary").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的收费标准", function (r) {
        if (r) {
            var options = { visit: 'removecontractcharge', IDList: JSON.stringify(IDList), canedit: canSaveLog };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            SearchSummaryTT();
                        });
                        return;
                    }
                    else if (message.msg) {
                        show_message(message.msg, "warning");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function formatFullName(value, row) {
    if (row.FullName == '') {
        row.FullName = '所有房间';
    }
    return row.FullName;
}
function EditCharge() {
    var rows = $('#tt_chargesummary').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("只能选择一个收费标准进行修改", "info");
        return;
    }
    var Name = rows[0].Name;
    var iframe = "../Contract/EditContractCharge.aspx?ID=" + rows[0].ID + "&canedit=" + canSaveLog;
    do_open_dialog('修改' + Name + "费项标准", iframe);
}
function calculateEditRowCost(currentSelectIndex, fieldName, row) {
    if (fieldName == 'CalculateUnitPrice' || fieldName == 'CalculateUseCount' || fieldName == 'CalculateStartTime' || fieldName == 'CalculateEndTime') {
        var totalcost = calculateTrueCostByTime(row, row.CalculateUseCount, row.CalculateUnitPrice, '', '');
        row.CalculateReduceCost = parseFloat(row.CalculateReduceCost, 10) > 0 ? row.CalculateReduceCost : 0;
        totalcost = totalcost - row.CalculateReduceCost;
        row.CalcualtePayCost = parseFloat(row.CalcualtePayCost, 10) > 0 ? row.CalcualtePayCost : 0;
        row.CalcualteDiscount = parseFloat(row.CalcualteDiscount, 10) > 0 ? row.CalcualteDiscount : 0;
        var restcost = totalcost - row.CalcualtePayCost - row.CalcualteDiscount;
        restcost = restcost > 0 ? restcost : 0;
        $(dgId).datagrid('updateRow', {
            index: currentSelectIndex,
            row: {
                CalcualteTotalCost: totalcost,
                CalcualteRestCost: restcost,
            }
        });
    }
}
function do_save_row() {
    var rows = $('#tt_chargesummary').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择一条数据，操作取消', 'warning');
        return;
    }
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'savecontractchargebyrows', rows: JSON.stringify(rows), canedit: canSaveLog };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ContractHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                show_message('操作成功', 'success');
                $('#tt_chargesummary').datagrid('reload');
                return;
            }
            if (data.error) {
                show_message(data.error, 'warning');
                return;
            }
            show_message('系统异常', 'error');
        }
    });
}