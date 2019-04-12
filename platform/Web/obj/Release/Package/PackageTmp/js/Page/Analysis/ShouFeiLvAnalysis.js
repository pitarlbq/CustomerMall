var fee_CanLoad = false;
var columns = [[
        { field: 'FullName', title: '资源位置', width: 200 },
        { field: 'RoomName', title: '房间信息', width: 100 },
        { field: 'Name', title: '收费项目', width: 100 },
        { field: 'FormatShouFuZhiBenQiYingShou', title: '本期应收', width: 100 },
        { field: 'FormatShouFuZhiLeiJiYingShou', title: '累计应收', width: 100 },
        { field: 'FormatShouFuZhiBenQiJianMian', title: '本期减免', width: 100 },
        { field: 'FormatShouFuZhiBenQiShiShou', title: '本期实收', width: 100 },
        { field: 'FormatShouFuZhiLiShiJianMian', title: '累计减免', width: 100 },
        { field: 'FormatShouFuZhiLeiJiShiShou', title: '累计实收', width: 100 },
        { field: 'FormatShouFuZhiBenQiQianFei', title: '本期欠费', width: 100 },
        { field: 'FormatShouFuZhiLiShiQianFei', title: '累计欠费', width: 100 },
        { field: 'ShouFuZhiBenQiShouFeiLv', title: '本期收费率', width: 100 },
        { field: 'ShouFuZhiLeiJiShouFeiLv', title: '累计收费率', width: 100 }
]];
$(function () {
    loadFeeType();
    $("input[name='tabletype']").bind('click', function () {
        getRadioValue();
    })
    hdRoomType.val("Project");
})
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
function loadFeeType() {
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
            tbChargeSummary.combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
                multiple: true,
                onSelect: function (rec) {
                    var values = tdChargeSummary.combobox('getValues');
                    hdChargeSummary.val(JSON.stringify(values));
                },
                onUnselect: function (rec) {
                    var values = tdChargeSummary.combobox('getValues');
                    hdChargeSummary.val(JSON.stringify(values));
                }
            });
            loadFeedg();
        }
    });
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
    hdRoomType.val(checkValue);
    return checkValue;
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
        showFooter: true,
        striped: true,
        idField: 'id',
        treeField: 'Name',
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
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
            $("#fee_table").treegrid("options").url = '../Handler/AnalysisHandler.ashx?visit=loadshoufeilvquanzebycharge&RoomID=' + row.RoomID + "&RoomType=" + RoomType;
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
            var url = '../Handler/AnalysisHandler.ashx?visit=';
            var visit = "";
            var RoomType = getRadioValue();
            var visit = "loadshoufeilvquanzebyproject";
            if (RoomType == "Project") {
                visit = "loadshoufeilvquanzebyproject";
            }
            else if (RoomType == "Room") {
                visit = "loadshoufeilvquanzebyroom";
            }
            else {
                visit = "loadshoufeilvquanzebycharge";
            }
            $("#fee_table").treegrid("options").url = url + visit;
        },
        columns: columns,
        toolbar: '#tbfee'
    });
}
function SearchFee() {
    var options = get_options(false);
    if (options == null) {
        return;
    }
    fee_CanLoad = true;
    $("#fee_table").treegrid("load", options);
}
function get_options(hasvisit) {
    var StartTime = tdStartTime.datebox("getValue");
    var EndTime = tdEndTime.datebox("getValue");
    if (StartTime == "" || EndTime == "") {
        return null;
    }
    var RoomIDs = [];
    var ProjectIDs = [];
    try {
        RoomIDs = GetSelectedRooms();
        ProjectIDs = GetSelectedProjects();
    } catch (e) {
    }
    if (RoomIDs.length == 0 && ProjectIDs.length == 0) {
        show_message('请选择资源', 'warning');
        return null;
    }
    var ChargeIDs = tbChargeSummary.combobox('getValues');
    var RoomType = getRadioValue();
    var visit = "loadshoufeilvquanzebyproject";
    if (RoomType == "Project") {
        visit = "loadshoufeilvquanzebyproject";
    }
    else if (RoomType == "Room") {
        visit = "loadshoufeilvquanzebyroom";
    }
    else {
        visit = "loadshoufeilvquanzebycharge";
    }
    var options = {
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartChargeTime": StartTime,
        "EndChargeTime": EndTime,
        "CompanyID": CompanyID,
        "ChargeIDs": JSON.stringify(ChargeIDs),
        "IsQuanZe": false,
        "ShowType": tdShowType.combobox('getValue'),
        "canexport": false
    };
    if (hasvisit) {
        options.visit = visit;
    }
    else {
        $("#fee_table").treegrid("options").url = '../Handler/AnalysisHandler.ashx?visit=' + visit;
    }
    return options;
}
function do_export() {
    var options = get_options(true);
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
