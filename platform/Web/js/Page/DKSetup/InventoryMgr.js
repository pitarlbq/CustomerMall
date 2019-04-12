var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CommHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: false,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        onDblClickRow: onDblClickRowTT,
        striped: true,
        showFooter: true,
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
        columns: [[
        { field: 'ck', checkbox: true },
         { field: 'Count', title: '库存', formatter: formatCount, width: 60 },
        { field: 'BusinessChargeStatusDesc', title: '结算状态', width: 60 },
        { field: 'ContactName', title: '商户', width: 100 },
        { field: 'InventoryName', title: '库位', width: 60 },
        { field: 'ProductName', title: '货品', width: 100 },
        { field: 'SpecName', title: '规格', width: 150 },
        { field: 'ColdPrice', formatter: formatColdPrice, title: '单价', width: 100 },
        { field: 'ColdCost', formatter: formatColdCost, title: '冷藏费', width: 60 },
        { field: 'MoveCost', formatter: formatMoveCost, title: '搬运费', width: 100 },
        { field: 'StartTime', formatter: formatTime, title: '开始日期', width: 100 },
        { field: 'EndTime', formatter: formatTime, title: '结束日期', width: 100 },
        { field: 'OutTime', formatter: formatTime, title: '出库时间', width: 100 },
        { field: 'CarrierName', title: '搬运工', width: 100 },
        { field: 'AddMan', title: '登记人', width: 80 },
        { field: 'Remark', title: '备注', width: 80 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    //var arrys = parent.GetSelected();
    //var keywords = $("#tdkeywords").searchbox("getValue");
    var InOutType = 1;
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    var Businessidarry = parent.GetSelectedByType("Business");
    var Productidarry = parent.GetSelectedByType("Product");
    var SpecInfoidarry = parent.GetSelectedByType("SpecInfo");
    var InventoryInfoidarry = parent.GetSelectedByType("InventoryInfo");
    var Carriergroupidarry = parent.GetSelectedTitleByType("CarrierGroup", 5);
    var Carrieridarry = parent.GetSelectedByType("Carrier");
    var BusinessID = Businessidarry.length > 0 ? Businessidarry[0] : 0;
    var ProductID = Productidarry.length > 0 ? Productidarry[0] : 0;
    var SpecInfoID = SpecInfoidarry.length > 0 ? SpecInfoidarry[0] : 0;
    var InventoryInfoID = InventoryInfoidarry.length > 0 ? InventoryInfoidarry[0] : 0;
    var CarrierGroupID = Carriergroupidarry.length > 0 ? Carriergroupidarry[0] : 0;
    var CarrierID = Carrieridarry.length > 0 ? Carrieridarry[0] : 0;
    //if (BusinessID == 0 && ProductID == 0 && InventoryInfoID == 0 && CarrierGroupID == 0 && CarrierID == 0) {
    //    tt_CanLoad = false;
    //    $('#tt_table').datagrid("loadData", {
    //        total: 0,
    //        rows: []
    //    });
    //    return;
    //}
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadinoutsource",
        "BusinessChargeStatus": -1,
        "CarrierChargeStatus": -1,
        "InOutType": InOutType,
        "StartTime": StartTime,
        "EndTime": EndTime,
        "BusinessID": BusinessID,
        "ProductID": ProductID,
        "SpecInfoID": SpecInfoID,
        "InventoryInfoID": InventoryInfoID,
        "CarrierGroupID": CarrierGroupID,
        "CarrierID": CarrierID,
        "SortOrder": "order by [StartTime] desc,[ID] desc"
    });
}
function formatCount(value, row) {
    if (Number(value) <= 0) {
        return 0;
    }
    return value;
}
function formatColdPrice(value, row) {
    if (Number(row.ID) <= 0) {
        return "";
    }
    if (Number(value) <= 0) {
        return "价格另定";
    }
    return value + "元/件/月";
}
function formatColdCost(value, row) {
    if (Number(value) <= 0) {
        return 0;
    }
    return value + "元";
}
function formatMoveCost(value, row) {
    if (Number(value) <= 0) {
        return 0;
    }
    return value + "元";
}
function onDblClickRowTT(index, row) {
    var iframe = "";
    var title = "";
    if (row.InOutType == 1) {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Setup/EditSource.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
        title = "入库";
    }
    else if (row.InOutType == 2) {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Setup/EditSourceOut.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
        title = "出库";
    }
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: title,
        width: $(window).width() - 250,
        height: $(window).height(),
        top: 0,
        left: 250,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function AddIn() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Setup/EditSource.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '入库',
        width: $(window).width() - 250,
        height: $(window).height(),
        top: 0,
        left: 250,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function AddOut() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个资源进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    if (rows[0].InOutType == 2) {
        show_message("请选择入库资源进行此操作", "info");
        return;
    }
    var ID = rows[0].ID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Setup/AddSourceOut.aspx?ID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '出库',
        width: $(window).width() - 250,
        height: $(window).height(),
        top: 0,
        left: 250,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function CancelSource() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个资源进行此操作", "info");
        return;
    }
    var IDList = [];
    var InIDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
        if (row.InOutType == 1) {
            InIDList.push(row.ID);
        }
    })
    if (InIDList.length > 0) {
        var options = { visit: 'checkinstatus', InIDList: JSON.stringify(InIDList) };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '../Handler/CommHandler.ashx',
            data: options,
            success: function (message) {
                if (message.status == 2) {
                    show_message("选中的物资中有已出库的物资，禁止取消", "info");
                    return;
                }
                if (message.status == 1) {
                    ProcessCancel(IDList);
                    return;
                }
                show_message('系统错误', 'error');
            }
        });
        return;
    }
    ProcessCancel(IDList);
}
function ProcessCancel(IDList) {
    top.$.messager.confirm("提示", "是否删除选中的资源", function (r) {
        if (r) {
            var options = { visit: 'cancelsource', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function PrintTable() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("没有可打印的数据", "info");
        return;
    }
    var pageindex = $('#tt_table').datagrid('options').pageNumber;
    var pagesize = $('#tt_table').datagrid('options').pageSize;
    var InOutType = 1;
    var BusinessChargeStatus = -1;
    var CarrierChargeStatus = -1;
    var StartTime = $("#tdStartTime").datebox("getValue");
    var EndTime = $("#tdEndTime").datebox("getValue");
    var Businessidarry = parent.GetSelectedByType("Business");
    var Productidarry = parent.GetSelectedByType("Product");
    var SpecInfoidarry = parent.GetSelectedByType("SpecInfo");
    var InventoryInfoidarry = parent.GetSelectedByType("InventoryInfo");
    var Carriergroupidarry = parent.GetSelectedTitleByType("CarrierGroup", 5);
    var Carrieridarry = parent.GetSelectedByType("Carrier");
    var BusinessID = Businessidarry.length > 0 ? Businessidarry[0] : 0;
    var ProductID = Productidarry.length > 0 ? Productidarry[0] : 0;
    var SpecInfoID = SpecInfoidarry.length > 0 ? SpecInfoidarry[0] : 0;
    var InventoryInfoID = InventoryInfoidarry.length > 0 ? InventoryInfoidarry[0] : 0;
    var CarrierGroupID = Carriergroupidarry.length > 0 ? Carriergroupidarry[0] : 0;
    var CarrierID = Carrieridarry.length > 0 ? Carrieridarry[0] : 0;
    //if (BusinessID == 0 && ProductID == 0 && InventoryInfoID == 0 && CarrierGroupID == 0 && CarrierID == 0) {
    //    show_message("请至少选择一个商户、货品、规格、库存、搬运工", "info");
    //    return;
    //}
    //var param = "?BusinessChargeStatus=" + BusinessChargeStatus + "&CarrierChargeStatus=" + CarrierChargeStatus + "&InOutType=" + InOutType + "&StartTime=" + StartTime + "&EndTime=" + EndTime + "&BusinessID=" + BusinessID + "&ProductID=" + ProductID + "&SpecInfoID=" + SpecInfoID + "&InventoryInfoID=" + InventoryInfoID + "&CarrierGroupID=" + CarrierGroupID + "&CarrierID=" + CarrierID + "&page=" + pageindex + "&rows=" + pagesize;
    var idlist = [];
    $.each(rows, function (index, row) {
        idlist.push(row.ID)
    })
    var param = "?IDList=" + JSON.stringify(idlist);
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Print/PrintInventoryMgr.aspx" + param + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '打印库存列表',
        width: $(window).width(),
        height: $(window).height(),
        top: 0,
        left: 0,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}