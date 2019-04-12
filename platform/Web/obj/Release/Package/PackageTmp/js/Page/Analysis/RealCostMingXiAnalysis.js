var fee_CanLoad = false;
var columns;
$(function () {
    getdgcolumns();
    $("input[name='tabletype']").bind('click', function () {
        getRadioValue();
    })
    hdRoomType.val("Room");
})
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
function getdgcolumns() {
    var options = { visit: "getrealcostmingxicolumns", PageCode: "RealCostMingXinAnalysis" }
    $.ajax({
        type: 'POST',
        data: options,
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx',
        success: function (result) {
            if (result.status) {
                columns = eval(result.columns);
            }
            else {
                columns = [[
                {
                    field: 'FullName',
                    title: '资源位置',
                    width: 200,
                    rowspan: 2
                },
                {
                    field: 'RoomName',
                    title: '房间信息',
                    width: 100,
                    rowspan: 2
                },
                {
                    field: 'RelationName',
                    title: '客户名称',
                    width: 100,
                    rowspan: 2
                }
                ]];
            }
            loadFeedg();
        }
    });
}
function loadFeedg() {
    fee_CanLoad = false;
    $('#fee_table').datagrid({
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
        showFooter: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!fee_CanLoad) {
                $('#tt_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return fee_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: columns,
        toolbar: '#tbfee'
    });
}
function SearchFee() {
    var FeeStartTime = tdFeeStartTime.datebox("getValue");
    var FeeEndTime = tdFeeEndTime.datebox("getValue");
    if (FeeStartTime != '' && FeeEndTime != '') {
        if (stringToDate(FeeStartTime).valueOf() > stringToDate(FeeEndTime).valueOf()) {
            show_message("收费开始日期不能大于结束日期", "warning");
            return;
        }
    }
    var RoomIDs = GetSelectedRooms();
    var ProjectIDs = GetSelectedProjects();
    if (RoomIDs.length == 0 && ProjectIDs.length == 0) {
        show_message('请选择资源', 'warning');
        return;
    }
    fee_CanLoad = true;
    $("#fee_table").datagrid("load", {
        "visit": "loadrealcostmingxianalysic",
        "RoomIDs": JSON.stringify(RoomIDs),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "StartChargeTime": FeeStartTime,
        "EndChargeTime": FeeEndTime,
        "RoomType": hdRoomType.val()
    });
}
function openSetting() {
    var iframe = "../SysSeting/SummaryColumnSetup.aspx?PageCode=RealCostMingXinAnalysis&OnlyShowALL=1";
    do_open_dialog('列配置', iframe);
}
function formatCostFormat(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return toThousands(value);
}
