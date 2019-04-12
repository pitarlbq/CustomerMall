var tt_CanLoad = false;
$(function () {
    loadFeeType();
    $(document).click(function (e) {
        var target = $(e.target);
        if (target.closest(".datagrid-btable,.calendar-noborder").length == 0) {
            endTTEditing();
        }
    });
});
function loadTT(auto_search) {
    tt_CanLoad = false;
    var ChargeID = FeeType.combobox("getValue");
    var options = { visit: 'loadtablecolumn', pagecode: 'roomfeesource', ChargeID: ChargeID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                //加载
                $('#tt_table').datagrid({
                    url: '../Handler/ImportFeeHandler.ashx',
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
                    showFooter: true,
                    onClickRow: onClickTTRow,
                    onDblClickCell: onDblClickCell,
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
                if (auto_search) {
                    SearchTT();
                }
                return;
            }
            show_message('系统错误', 'error');
        }
    });
}
function loadFeeType() {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx?visit=getchargesummarylist&CompanyID=' + CompanyID + '&IsAllowImport=true',
        success: function (data) {
            var list = [];
            list.push({ ID: 0, Name: "不限" });
            $.each(data, function (index, item) {
                list.push({ ID: item.ID, Name: item.Name });
            })
            FeeType.combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
            });
            ChargeSummaryList = data;
            loadTT(false);
        }
    });
}

function SearchTT() {
    var options = get_options();
    if (options == null) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", options);
}
function get_options() {
    var StartTime = StartWriteDate.datebox("getValue");
    var EndTime = EndWriteDate.datebox("getValue");
    if (StartTime != '' && EndTime != '') {
        if (stringToDate(StartTime).valueOf() > stringToDate(EndTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var roomids = [];
    var projectids = [];
    try {
        roomids = GetSelectedRooms();
        projectids = GetSelectedProjects();
    } catch (e) {

    }
    if (roomids.length == 0 && projectids.length == 0) {
        show_message('请选择一个资源', 'warning');
        return null;
    }
    tt_CanLoad = true;
    var options = {
        "visit": "loaddaishouimport",
        "RoomIDs": JSON.stringify(roomids),
        "ProjectIDs": JSON.stringify(projectids),
        "ChargeID": FeeType.combobox("getValue"),
        "FeeStatus": FeeStatus.combobox("getValue"),
        "StartWriteDate": StartTime,
        "EndWriteDate": EndTime,
        "Keywords": tdKeyword.searchbox("getValue"),
        "ShowFooter": true
    };
    return options;
}
function do_export() {
    var options = get_options();
    if (options == null) {
        return;
    }
    options.canexport = true;
    options.page = 1;
    options.rows = 10;
    MaskUtil.mask('body', '导出中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.downloadurl) {
                window.location.href = data.downloadurl;
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

var tt_editIndex = undefined;
function endTTEditing() {
    if (tt_editIndex == undefined) {
        return true;
    }
    $('#tt_table').datagrid('endEdit', tt_editIndex);
    saveFee();
    tt_editIndex = undefined;
    return true;
}
function onDblClickCell(index, field, value) {
    //if (row.FinalChargeStatus == 1) {
    //    return;
    //}
    var rows = $('#tt_table').datagrid('getRows');
    var row = rows[index];
    if (endTTEditing()) {
        var col = $('#tt_table').datagrid('getColumnOption', field);
        if (!col.editor) {
            field = 'RealTotalPoint';
        }
        editTTRoomFee(row, index, field);
        tt_editIndex = index;
    } else {
        setTimeout(function () {
            $('#tt_table').datagrid('selectRow', tt_editIndex);
        }, 100);
    }
}
function onClickTTRow(index, row) {
    if (tt_editIndex != index) {
        endTTEditing();
        return;
    }
    setTimeout(function () {
        $('#tt_table').datagrid('selectRow', index);
    }, 100);
}
function editTTRoomFee(row, rowIndex, fieldName) {
    if (Number(row.CuiShouCount) > 0) {
        show_message('账单催收中，操作取消', 'warning');
        return;
    }
    if (Number(row.FinalChargeStatus) == 1) {
        show_message('账单已收费，操作取消', 'warning');
        return;
    }
    if (Number(row.FinalChargeStatus) == 0 && row.IsCharged) {
        show_message('账单已部分收费，操作取消', 'warning');
        return;
    }
    $('#tt_table').datagrid('selectRow', rowIndex).datagrid('beginEdit', rowIndex);
    var TotalPointObj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'RealTotalPoint' });
    if (TotalPointObj) {
        var totalpoint = row.CalcualteTotalPoint;
        if (Number(totalpoint) > 0) {
            TotalPointObj.target.numberbox('disable', true);
        }
    }
    if (Number(row.ProjectBiaoID) > 0) {
        TotalPointObj.target.numberbox('disable', true);
    }
    var TotalPriceObj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'FinalTotalPrice' });
    if (TotalPriceObj) {
        var totalprice = row.CalculateTotalPrice;
        if (Number(totalprice) > 0) {
            TotalPriceObj.target.numberbox('disable', true);
        }
    }
    var UnitPriceObj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'FinalUnitPrice' });
    if (UnitPriceObj) {
        if (Number(row.FinalUnitPrice) <= 0) {
            UnitPriceObj.target.numberbox("setValue", 0);
        }
        if (row.IsPriceRange) {
            UnitPriceObj.target.numberbox("disable", true);
        }
    }
    var ImportCoefficientObj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'FinalImportCoefficient' });
    if (row.FinalImportCoefficient <= 0 && ImportCoefficientObj) {
        var ImportCoefficient = row.FinalImportCoefficient;
        ImportCoefficientObj.target.numberbox("setValue", ImportCoefficient);
    }
    var WriteDateObj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'WriteDate' });
    if (WriteDateObj) {
        WriteDateObj.target.datebox("setValue", Format_DateTime(row.WriteDate));
    }
    var StartTimeObj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'StartTime' });
    if (StartTimeObj) {
        StartTimeObj.target.datebox("setValue", Format_DateTime(row.StartTime));
    }
    var EndTimeObj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'EndTime' });
    if (EndTimeObj) {
        EndTimeObj.target.datebox("setValue", Format_DateTime(row.EndTime));
    }
    if (row.ImportBiaoGuiGe == '总表') {
        var $FinalReducePoint = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'FinalReducePoint' });
        if ($FinalReducePoint) {
            $FinalReducePoint.target.textbox('disable', true);
        }
    }
    if (parseFloat(row.ImportRate) < 0) {
        var $ImportRate = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'ImportRate' });
        if ($ImportRate) {
            $ImportRate.target.textbox('setValue', '0');
        }
    }
    if (row.FinalChargeStatus == 1) {
        var ChargeID_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'ChargeID' });
        if (ChargeID_Obj) {
            ChargeID_Obj.target.combobox('disable', true);
        }
        var StartPoint_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'StartPoint' });
        if (StartPoint_Obj) {
            StartPoint_Obj.target.numberbox('disable', true);
        }
        var EndPoint_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'EndPoint' });
        if (EndPoint_Obj) {
            EndPoint_Obj.target.numberbox('disable', true);
        }
        var TotalPoint_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'TotalPoint' });
        if (TotalPoint_Obj) {
            TotalPoint_Obj.target.numberbox('disable', true);
        }
        var UnitPrice_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'UnitPrice' });
        if (UnitPrice_Obj) {
            UnitPrice_Obj.target.numberbox('disable', true);
        }
        var ImportCoefficient_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'ImportCoefficient' });
        if (ImportCoefficient_Obj) {
            ImportCoefficient_Obj.target.numberbox('disable', true);
        }
        var TotalPrice_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'TotalPrice' });
        if (TotalPrice_Obj) {
            TotalPrice_Obj.target.numberbox('disable', true);
        }
        var WriteDate_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'WriteDate' });
        if (WriteDate_Obj) {
            WriteDate_Obj.target.datebox('disable', true);
        }
        var ImportBiaoCategory_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'ImportBiaoCategory' });
        if (ImportBiaoCategory_Obj) {
            ImportBiaoCategory_Obj.target.textbox('disable', true);
        }
        var ImportBiaoName_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'ImportBiaoName' });
        if (ImportBiaoName_Obj) {
            ImportBiaoName_Obj.target.textbox('disable', true);
        }
        var ImportRate_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'ImportRate' });
        if (ImportRate_Obj) {
            ImportRate_Obj.target.textbox('disable', true);
        }
        var FinalReducePoint_Obj = $('#tt_table').datagrid('getEditor', { index: rowIndex, field: 'FinalReducePoint' });
        if (FinalReducePoint_Obj) {
            FinalReducePoint_Obj.target.textbox('disable', true);
        }
    }
    if (fieldName) {
        $('#tt_table').datagrid('getEditor', { index: rowIndex, field: fieldName }).target.next('span').find('input').focus();
    }
}
function Format_DateTime(datetime) {
    if (datetime == undefined || datetime == null) {
        return "";
    }
    var result = datetime.substring(0, 16).split("T")[0];
    if (result == '0001-01-01' || result == '1900-01-01' || result == '1901-01-01') {
        return "";
    }
    return result;
}
function xround(x, num) {
    if (x <= 0) {
        return x;
    }
    return Math.round(x * Math.pow(10, num)) / Math.pow(10, num);
}
function formatUnitPrice(value, row) {
    if (row.IsPriceRange) {
        return '<a>阶梯单价</a>';
    }
    return row.FinalUnitPrice;
}
function formatDecimal(value, row) {
    if (parseFloat(value) <= 0 || value == '') {
        return 0;
    }
    return value;
}
function formatImportRate(value, row) {
    if (parseFloat(row.ImportRate) <= 0 || row.ImportRate == '') {
        row.ImportRate = 1;
    }
    return row.ImportRate;
}
function openImport() {
    var iframe = "../GongTan/ImportFee.aspx";
    do_open_dialog('导入账单', iframe);
}
function editFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length != 1) {
        show_message('请选择一条数据进行操作,操作取消', 'warning');
        return;
    }
    if (rows[0].FinalChargeStatus == 1) {
        return;
    }
    var rowIndex = $('#tt_table').datagrid('getRowIndex', rows[0]);
    setTimeout(function () {
        tt_editIndex = rowIndex;
    }, 1000);
    editTTRoomFee(rows[0], rowIndex, 'RealTotalPoint');
    return;
}
function saveFeeAsync(async) {
    var ImportFeeList = [];
    var CostIsNull = false;
    var CalculateCostError = false;
    var WriteDateError = false;
    var rows = $('#tt_table').datagrid("getSelections");
    $.each(rows, function (index, row) {
        row.StartPoint = formatDecimal(row.StartPoint, row);
        row.EndPoint = formatDecimal(row.EndPoint, row);
        row.TotalPoint = formatDecimal(row.RealTotalPoint, row);
        row.TotalPrice = formatDecimal(row.FinalTotalPrice, row);
        row.UnitPrice = formatDecimal(row.FinalUnitPrice, row);
        row.ImportCoefficient = formatDecimal(row.FinalImportCoefficient, row);
        row.ImportRate = formatImportRate(row.ImportRate, row);
        row.ImportReducePoint = formatDecimal(row.FinalReducePoint, row);
        row.StartTime = formatTime(row.StartTime, row);
        row.EndTime = formatTime(row.EndTime, row);
        row.WriteDate = formatTime(row.WriteDate, row);
        if (row.TotalPrice <= 0) {
            CostIsNull = true;
        }
        if (row.StartPoint > row.EndPoint) {
            CalculateCostError = true;
        }
        if (row.StartTime == null || row.StartTime == "" || row.StartTime == "--") {
            row.StartTime = "0001-01-01";
        }
        if (row.EndTime == null || row.EndTime == "" || row.EndTime == "--") {
            row.EndTime = "0001-01-01";
        }
        if (row.WriteDate == null || row.WriteDate == "" || row.WriteDate == "--") {
            WriteDateError = true;
            return false;
        }
        ImportFeeList.push(row);
    });
    if (WriteDateError) {
        show_message('账单日期不能为空，操作取消', 'warning');
        return;
    }
    if (ImportFeeList.length == 0) {
        return;
    }
    if (async) {
        //if (CostIsNull) {
        //    top.$.messager.confirm("提示", "部分账单金额为0，是否继续保存?", function (r) {
        //        if (r) {
        //            SaveImportFee(ImportFeeList, async);
        //        }
        //    });
        //    return;
        //}
        if (CalculateCostError) {
            top.$.messager.confirm("提示", "上次读数大于本次读数,是否继续保存?", function (r) {
                if (r) {
                    SaveImportFee(ImportFeeList, async);
                }
            });
            return;
        }
    }
    SaveImportFee(ImportFeeList, async);
}
function saveFee() {
    saveFeeAsync(true);
}
function SaveImportFee(ImportFeeList, async) {
    var options = { visit: 'saveimportfee', ImportFeeList: JSON.stringify(ImportFeeList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        async: async,
        success: function (message) {
            if (async) {
                if (message.status == 1) {
                    show_message('修改成功', 'success');
                    $('#tt_table').datagrid("reload");
                }
                else {
                    show_message('系统错误', 'error');
                }
            }
        }
    });
}
function removeFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var IDList = [];
    var candel = true;
    $.each(rows, function (index, row) {
        if (row.FinalChargeStatus == 1) {
            candel = false;
            return false;
        }
        IDList.push(row.ID);
    });
    if (!candel) {
        show_message('删除行中包含已收费项目，操作取消', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "确认删除?", function (r) {
        if (r) {
            var options = { visit: 'deleteimportfee', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success');
                        $('#tt_table').datagrid("reload");
                    }
                    else if (message.error) {
                        show_message(message.error, 'error');
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    });
}
//账单生成
var chooseWriteDate, chooseChargeID;
function createFee() {
    chooseWriteDate = '';
    chooseChargeID = '';
    var iframe = "../GongTan/CreateFee.aspx";
    do_open_dialog('账单生成', iframe);
}
function create_fee_complete() {
    if (chooseWriteDate != '') {
        StartWriteDate.datebox("setValue", chooseWriteDate);
        EndWriteDate.datebox("setValue", chooseWriteDate);
    }
    if (chooseChargeID != '') {
        FeeType.combobox("setValue", chooseChargeID);
    }
    FeeStatus.combobox("setValue", 2);
    $('#tt_table').datagrid("reload");
}
//账单生效
function activeFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var IDList = [];
    var candel = true;
    var includezero = false;
    $.each(rows, function (index, row) {
        if (row.FinalChargeStatus != 2) {
            candel = false;
            return false;
        }
        var TotalPrice = row.FinalTotalPrice;
        if (TotalPrice <= 0) {
            includezero = true;
        }
        IDList.push(row.ID);
    });
    if (!candel) {
        show_message('选中账单中包含已生效的项目，操作取消', 'warning');
        return;
    }
    if (includezero) {
        top.$.messager.confirm("提示", "选中账单中包含金额为0账单账单，是否继续?", function (r) {
            if (r) {
                SaveActiveFee(IDList);
                return;
            }
        });
        return;
    }
    top.$.messager.confirm("提示", "确认生效选中的账单?", function (r) {
        if (r) {
            SaveActiveFee(IDList);
            return;
        }
    });
}
function SaveActiveFee(IDList) {
    saveFeeAsync(false);
    var options = { visit: 'activefee', IDList: JSON.stringify(IDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ImportFeeHandler.ashx',
        data: options,
        async: false,
        success: function (message) {
            if (message.status) {
                if (message.msg) {
                    show_message(message.msg, 'success');
                    return;
                }
                show_message('操作成功', 'success');
                $('#tt_table').datagrid("reload");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
//列设置
function openTableSetUp() {
    var iframe = "../SysSeting/TableSetUp.aspx?PageCode=roomfeesource";
    do_open_dialog('账单列表设置', iframe);
}
//批处理
function batchEditTime() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据，操作取消', 'warning');
        return;
    }
    var tostop = false;
    $.each(rows, function (index, row) {
        if (row.FinalChargeStatus == 1) {
            tostop = true;
            return false;
        }
    })
    if (tostop) {
        show_message('选择的数据中包含已收费的账单,操作取消', 'warning');
        return;
    }
    var iframe = "../GongTan/BatchEditTime.aspx";
    do_open_dialog('批处理', iframe);
}
//抄表登记
function batchEditPoint() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据,操作取消', 'warning');
        return;
    }
    var tostop = false;
    $.each(rows, function (index, row) {
        if (row.FinalChargeStatus == 1) {
            tostop = true;
            return false;
        }
    })
    if (tostop) {
        show_message('选择的资源中包含已收费的账单,操作取消', 'warning');
        return;
    }
    var iframe = "../GongTan/BatchEditCount.aspx";
    do_open_dialog('抄表登记', iframe);
}
//公摊处理
function addTool() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据,操作取消', 'warning');
        return;
    }
    var tostop = false;
    $.each(rows, function (index, row) {
        if (row.FinalChargeStatus == 1) {
            tostop = true;
            return false;
        }
    })
    if (tostop) {
        show_message('选择的资源中包含已收费的账单,操作取消', 'warning');
        return;
    }
    var iframe = "../GongTan/GongTanTool.aspx";
    do_open_dialog('公摊工具', iframe);
}
//期初收款
function transferQiChu() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据,操作取消', 'warning');
        return;
    }
    var iframe = "../GongTan/TransferQiChu.aspx";
    do_open_dialog('收款登记', iframe);
}
//表台帐
function viewTaiZhang() {
    var iframe = "../GongTan/TaiZhangMgr.aspx";
    do_open_dialog('三表台帐', iframe);
}
//作废单据
function doCancelRoomFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据,操作取消', 'warning');
        return;
    }
    var IDList = [];
    var is_noshoufei = false;
    var is_jiaoban = false;
    var is_cancel = false;
    $.each(rows, function (index, row) {
        if (row.HistoryID <= 0) {
            is_noshoufei = true;
            return false;
        }
        if (row.RoomFeeOrderID > 0) {
            is_jiaoban = true;
            return false;
        }
        IDList.push(row.HistoryID);
    });
    if (is_noshoufei) {
        show_message('不能作废未收费的账单,操作取消', 'warning');
        return;
    }
    if (is_jiaoban) {
        show_message('不能作废已交班的账单,操作取消', 'warning');
        return;
    }
    top.$.messager.confirm('提示', '确认作废', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'cancelhistoryfee', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('作废成功', 'success');
                        $('#tt_table').datagrid("reload");
                    }
                    else if (data.msg) {
                        show_message(data.msg, 'error');
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}

