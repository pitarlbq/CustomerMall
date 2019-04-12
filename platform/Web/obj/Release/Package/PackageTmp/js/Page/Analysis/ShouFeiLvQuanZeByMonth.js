var fee_CanLoad = false;
var type_CanLoad = false;
var visitvalue;
var columns1 = [];
var columns2 = [];
var columns = [[
        //{ field: 'FullName', title: '资源位置', width: 200 },
        //{ field: 'FormatMonthBenqiChongXiao', title: '冲销', width: 100, rowspan: 2 },
        //{ field: 'FormatMonthBenqiDiscount', title: '减免', width: 100, rowspan: 2 },
        //{ field: 'FormatBenQiQianFei', title: '本期欠费', width: 100, rowspan: 2 },
], [
]];
$(function () {
    visitvalue = "Project";
    loadFeeType();
    getColumns();
    $("input[name='tabletype']").bind('click', function () {
        getColumns();
    })
})
function getColumns() {
    columns = [];
    columns1 = [];
    columns2 = [];
    var RoomType = getRadioValue();
    columns1.push({ field: 'RoomName', title: '资源信息', width: 100, rowspan: 2 });
    if (RoomType != 'ChargeType') {
        columns1.push({ field: 'Name', title: '收费项目', width: 100, rowspan: 2 });
        columns1.push({ field: 'FormatMonthBenQiYingShou', title: '本期应收', width: 100, rowspan: 2, formatter: formatMonthBenQiYingShou });
    }
    if (RoomType == 'ChargeType') {
        columns1.push({ field: 'Name', title: '收款方式', width: 100, rowspan: 2 });
    }
    columns1.push({ title: '本期已收', colspan: 3 });
    columns1.push({ field: 'FormatMonthZhiHouShouBenqi', title: '之后收本期', width: 100, rowspan: 2, formatter: formatMonthZhiHouShouBenqi });
    columns1.push({ field: 'FormatMonthLishiShouBenqi', title: '之前收本期', width: 100, rowspan: 2, formatter: formatMonthLishiShouBenqi });
    if (RoomType != 'ChargeType') {
        columns1.push({ field: 'BenQiShouFeiLv', title: '本期收费率', width: 100, rowspan: 2 });
        columns1.push({ field: 'ShiShiShouFeiLv', title: '累计收费率', width: 100, rowspan: 2 });
    }
    columns2.push({ field: 'FormatMonthBenqiShouBenqi', title: '本期收本期', width: 100, formatter: formatMonthBenqiShouBenqi });
    columns2.push({ field: 'FormatMonthBenqiShouLishi', title: '本期收历史', width: 100, formatter: formatMonthBenqiShouLishi });
    columns2.push({ field: 'FormatMonthBenqiYuShou', title: '本期收以后', width: 100, formatter: formatMonthBenqiYuShou });
    columns.push(columns1)
    columns.push(columns2)
    loadFeedg();
}
function getRadioValue() {
    var checkValue = "";
    var chkRadio = document.getElementsByName("tabletype");
    $.each(chkRadio, function (index, item) {
        if ($(item).prop('checked')) {
            checkValue = $(item).val();
            return false;
        }
    })
    return checkValue;
}
function formatMonthBenQiYingShou(value, row) {
    return value;
}
function formatMonthZhiHouShouBenqi(value, row) {
    return '<a style="color:#000;text-decoration:none;" href="#" title="' + row.MonthZhiHouShouBenqi_Title + '" class="easyui-tooltip">' + value + '</a>';
}
function formatMonthLishiShouBenqi(value, row) {
    return '<a style="color:#000;text-decoration:none;" href="#" title="' + row.MonthLishiShouBenqi_Title + '" class="easyui-tooltip">' + value + '</a>';
}
function formatMonthBenqiShouBenqi(value, row) {
    return '<a style="color:#000;text-decoration:none;" href="#" title="' + row.MonthBenqiShouBenqi_Title + '" class="easyui-tooltip">' + value + '</a>';
}
function formatMonthBenqiShouLishi(value, row) {
    return '<a style="color:#000;text-decoration:none;" href="#" title="' + row.MonthBenqiShouLishi_Title + '" class="easyui-tooltip">' + value + '</a>';
}
function formatMonthBenqiYuShou(value, row) {
    return '<a style="color:#000;text-decoration:none;" href="#" title="' + row.MonthBenqiYuShou_Title + '" class="easyui-tooltip">' + value + '</a>';
}
function loadFeeType() {
    var options = { visit: "getchargesummarylist", CompanyID: 0, FeeType: 0 }
    $.ajax({
        type: 'POST',
        dataType: 'json',
        data: options,
        url: '../Handler/FeeCenterHandler.ashx',
        success: function (data) {
            var list = [];
            list.push({ ID: 0, Name: "全部" });
            $.each(data, function (index, item) {
                list.push({ ID: parseInt(item.ID), Name: item.Name });
            })
            tdChargeSummary.combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
                onSelect: function () {
                    var values = tdChargeSummary.combobox('getValues');
                    hdChargeSummary.val(JSON.stringify(values));
                },
                onUnselect: function () {
                    var values = tdChargeSummary.combobox('getValues');
                    hdChargeSummary.val(JSON.stringify(values));
                }
            });
        }
    });
}
function loadFeedg() {
    fee_CanLoad = false;
    $('#fee_table').treegrid({
        url: '../Handler/AnalysisHandler.ashx',
        loadMsg: '正在加载',
        border: false,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        idField: 'id',
        treeField: 'Name',
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        columns: columns,
        onBeforeLoad: function (data) {
            if (!fee_CanLoad) {
                $('#fee_table').treegrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return fee_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#fee_table').treegrid("loadData", {
                total: 0,
                rows: []
            });
        },
        onBeforeExpand: function (row) {
            //动态设置展开查询的url  
            var RoomType = getRadioValue();
            if (RoomType != "ChargeType") {
                visit = "loadshoufeilvquanzebycharge";
            }
            else if (RoomType == "ChargeType") {
                visit = "loadshoufeilvquanzebychargemoneytype";
            }
            $("#fee_table").treegrid("options").url = '../Handler/AnalysisHandler.ashx?visit=' + visit + '&RoomID=' + row.RoomID;
            return true;
        },
        onExpand: function (row) {
            var children = $("#fee_table").treegrid('getChildren', row.id);
            if (children.length <= 0) {
                $("#fee_table").treegrid('refresh', row.id);
            }
        },
        onLoadSuccess: function (node, data) {
            init();
            var url = '../Handler/AnalysisHandler.ashx?RoomID=0&NewRoomType=';
            $("#fee_table").treegrid("options").url = url;
        },
        toolbar: '#tbfee'
    });
}
function SearchFee() {
    AutoSearchFee(true)
}
function AutoSearchFee(isclick) {
    var options = get_options(isclick);
    if (options == null) {
        return;
    }
    fee_CanLoad = true;
    $("#fee_table").treegrid("options").url = options.url;
    $("#fee_table").treegrid("load", options);
}
function get_options(isclick) {
    var StartChargeTime = tdStartTime.datebox("getValue");
    var EndChargeTime = tdEndTime.datebox("getValue");
    if (StartChargeTime == "" || EndChargeTime == "") {
        if (isclick) {
            show_message('日期不能为空', 'warning');
        }
        return null;
    }
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
            show_message('开始日期不能大于结束日期', 'warning');
            return null;
        }
    }
    var RoomType = getRadioValue();
    var visit = "loadshoufeilvquanzebyproject";
    if (RoomType == "Project") {
        visit = "loadshoufeilvquanzebyproject";
    }
    else if (RoomType == "Room") {
        visit = "loadshoufeilvquanzebyroom";
    }
    var url = '../Handler/AnalysisHandler.ashx?visit=' + visit;
    var ChargeIDs = hdChargeSummary.val();
    var RoomIDs = [];
    var ProjectIDs = [];
    try {
        RoomIDs = GetSelectedRooms();
        ProjectIDs = GetSelectedProjects();
    } catch (e) {
    }
    hdRoomIDs.val(JSON.stringify(RoomIDs));
    hdProjectIDs.val(JSON.stringify(ProjectIDs));
    var options = {
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID,
        "ChargeIDs": ChargeIDs,
        "source": 'ShouFeiLvQuanZeByMonth',
        "RoomType": RoomType
    };
    options.url = url;
    return options;
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
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
        url: options.url,
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