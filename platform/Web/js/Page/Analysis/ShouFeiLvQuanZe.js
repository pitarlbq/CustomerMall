var fee_CanLoad = false;
var type_CanLoad = false;
var visitvalue;
var columns = [[
        //{ field: 'FullName', title: '资源位置', width: 200 },
        { field: 'RoomName', title: '资源信息', width: 100 },
        { field: 'Name', title: '收费项目', width: 100 },
        { field: 'FormatLishiShouBenqi', title: '之前收本期', width: 100 },
        { field: 'FormatBenqiShouLishi', title: '本期收历史', width: 100 },
        { field: 'FormatBenqiShouBenqi', title: '本期收本期', width: 100 },
        { field: 'FormatBenqiYuShou', title: '本期预收以后', width: 100 },
        { field: 'FormatBenqiChongXiao', title: '本期冲销预收', width: 100 },
        { field: 'FormatZhiHouShouBenqi', title: '之后收本期', width: 100 }
]];
$(function () {
    visitvalue = "Project";
    loadFeeType();
})
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
            $('#tbChargeSummary').combobox({
                editable: false,
                data: list,
                valueField: 'ID',
                textField: 'Name',
                multiple: true
            });
            loadFeedg();
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
            $("#fee_table").treegrid("options").url = '../Handler/AnalysisHandler.ashx?visit=loadshoufeilvquanzebycharge&RoomID=' + row.RoomID;
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
            var visit = "loadshoufeilvquanzebyproject";
            $("#fee_table").treegrid("options").url = url + visit;
        },
        columns: columns
    });
    SearchFee();
}
function SearchFee() {
    var StartChargeTime = $("#tdStartTime").datebox("getValue");
    var EndChargeTime = $("#tdEndTime").datebox("getValue");
    if (StartChargeTime == "" || EndChargeTime == "") {
        return;
    }
    if (StartChargeTime != '' && EndChargeTime != '') {
        if (stringToDate(StartChargeTime).valueOf() > stringToDate(EndChargeTime).valueOf()) {
             show_message('开始日期不能大于结束日期', 'warning');
            return;
        }
    }
    var visit = "loadshoufeilvquanzebyproject";
    $("#fee_table").treegrid("options").url = '../Handler/AnalysisHandler.ashx?visit=' + visit;
    var ChargeIDs = $('#tbChargeSummary').combobox('getValues');
    var idarry = GetSelectedRooms();
    var ProjectID = GetSelectedProjects();

    fee_CanLoad = true;
    $("#fee_table").treegrid("load", {
        "RoomIDs": JSON.stringify(idarry),
        "ProjectIDs": JSON.stringify(ProjectID),
        "StartChargeTime": StartChargeTime,
        "EndChargeTime": EndChargeTime,
        "CompanyID": CompanyID,
        "ChargeIDs": JSON.stringify(ChargeIDs)
    });
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}