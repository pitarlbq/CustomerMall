var tt_CanLoad = false;
$(function () {
    loadChargeSummary();
    loadTT();
});
function loadChargeSummary() {
    var options = { visit: 'getchargesummarylist', CompanyID: CompanyID, IsReading: true };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        data: options,
        url: '../Handler/FeeCenterHandler.ashx',
        success: function (data) {
            var list = [];
            list.push({ ID: 0, Name: "不限" });
            $.each(data, function (index, item) {
                list.push({ ID: item.ID, Name: item.Name });
            })
            tbChargeID.combobox({
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
    $('#tt_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
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
        columns: [[
       { field: 'ck', checkbox: true },
       { field: 'FullName', title: '资源位置', width: 260 },
       { field: 'Name', title: '资源编号', width: 80 },
       { field: 'ChargeName', title: '收费项目', width: 100 },
       { field: 'ChargeTime', formatter: formatDateTime, title: '收款日期', width: 120 },
       { field: 'StartPoint', formatter: formatDecimal, title: '上次读数', width: 80 },
       { field: 'EndPoint', formatter: formatDecimal, title: '本次读数', width: 80 },
       { field: 'FinalUseCount', formatter: formatTotalPoint, title: '用量', width: 80 },
       { field: 'FormatUnitPrice', formatter: formatUnitPrice, title: '单价', width: 80 },
       { field: 'FinalRealCost', title: '金额', width: 80 },
       { field: 'ChargeStatusDesc', title: '收费状态', width: 80 },
       { field: 'WriteDate', formatter: formatTime, title: '账单日期', width: 100 },
       { field: 'FinalStartTime', formatter: formatTime, title: '计费开始日期', width: 100 },
       { field: 'FinalEndTime', formatter: formatTime, title: '计费结束日期', width: 100 },
       { field: 'ImportBiaoCategory', title: '表种类', width: 80 },
       { field: 'ImportBiaoName', title: '表名称', width: 80 }
        ]],
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
    var starttime_str = StartWriteDate.datebox("getValue");
    var endtime_str = EndWriteDate.datebox("getValue");
    if (starttime_str != '' && endtime_str != '') {
        if (stringToDate(starttime_str).valueOf() > stringToDate(endtime_str).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var idarry = parent.GetSelectedRooms();
    var ProjectID = parent.GetSelectedProjects();
    var ChargeIDs = tbChargeID.combobox('getValues');
    var options = {
        "visit": "loadchaobiaoanalysislist",
        "RoomIDs": JSON.stringify(idarry),
        "ProjectIDs": JSON.stringify(ProjectID),
        "ChargeIDs": JSON.stringify(ChargeIDs),
        "StartWriteDate": starttime_str,
        "EndWriteDate": endtime_str,
        "Keywords": tdKeyword.searchbox("getValue"),
        "BiaoCategory": BiaoCategory.searchbox("getValue"),
        "ChargeStatus": tbChargeStatus.combobox('getValue'),
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
        url: '../Handler/AnalysisHandler.ashx',
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
function formatDecimal(value, row) {
    if (parseFloat(value) < 0) {
        return 0;
    }
    return value;
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
function formatTotalPoint(value, row) {
    return calculateFinalTotalPoint(row);
}
function calculateTotalPoint(row) {
    if (row.FinalUseCount > 0) {
        return row.FinalUseCount;
    }
    var count = Number(row.EndPoint) - Number(row.StartPoint);
    if (count < 0)
        return 0;
    return count;
}
function calculateFinalTotalPoint(row) {
    var totalpoint = calculateTotalPoint(row);
    if (totalpoint <= 0) {
        totalpoint = (Number(row.TotalPoint) <= 0 ? 0 : Number(row.TotalPoint));
    }
    return totalpoint.toFixed(2);
}
function formatTotalPrice(value, row) {
    var total_price = calculateFinalTotalPrice(row);
    return toThousands(total_price);
}
function formatUnitPrice(value, row) {
    var unit_price = calculateUnitPrice(row);
    return toThousands(unit_price);
}
function calculateUnitPrice(row) {
    if (Number(row.FinalUnitPrice) >= 0) {
        return row.FinalUnitPrice;
    }
    if (Number(row.UnitPrice) >= 0) {
        return row.UnitPrice;
    }
    if (Number(row.SummaryUnitPrice) >= 0) {
        return row.SummaryUnitPrice
    }
    return 0;
}
function calculateFinalTotalPrice(row) {
    if (row.FinalRealCost > 0) {
        return row.FinalRealCost;
    }
    var totalprice = calculateTotalPrice(row);
    if (totalprice > 0) {
        return totalprice;
    }
    return 0;
}
function calculateTotalPrice(row) {
    var UnitPrice = calculateUnitPrice(row);
    var ImportCoefficient = calculateCoefficient(row);
    var totalprice = 0;
    var TotalPoint = calculateFinalTotalPoint(row);
    totalprice = (TotalPoint * UnitPrice * ImportCoefficient).toFixed(2);
    if (totalprice < 0) {
        return 0;
    }
    return totalprice;
}

function formatImportCoefficient(value, row) {
    return calculateCoefficient(row)
}
function calculateCoefficient(row) {
    if (Number(row.ImportCoefficient) > 0) {
        return row.ImportCoefficient;
    }
    if (row.Coefficient > 0) {
        return row.Coefficient;
    }
    return 0;
}

