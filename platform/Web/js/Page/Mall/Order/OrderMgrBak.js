var tt_CanLoad = false, isUpdate = false;
function MergeCells(tableID, fldList) {
    var Arr = fldList.split(",");
    var dg = $('#' + tableID);
    var fldName;
    var RowCount = dg.datagrid("getRows").length;
    var span;
    var PerValue = "";
    var CurValue = "";
    var length = Arr.length - 1;
    var list = [];
    for (i = 0; i <= length; i++) {
        fldName = Arr[i];
        PerValue = "";
        span = 1;
        for (row = 0; row <= RowCount; row++) {
            if (row == RowCount) {
                CurValue = "";
            }
            else {
                CurValue = dg.datagrid("getRows")[row]["OrderID"];
            }
            if (PerValue == CurValue) {
                span += 1;
            }
            else {
                var index = row - span;
                list.push({ index: index, fldName: fldName, span: span });
                span = 1;
                PerValue = CurValue;
            }
        }
    }
    if (merge_timeout != null) {
        clearTimeout(merge_timeout);
    }
    do_merge(dg, list, 0);
}
var merge_timeout = null;
function do_merge(dg, list, i) {
    if (i == list.length) {
        return;
    }
    dg.datagrid('mergeCells', {
        index: list[i].index,
        field: list[i].fldName,
        rowspan: list[i].span,
        colspan: null
    });
    merge_timeout = setTimeout(function () {
        do_merge(dg, list, i + 1)
    }, 10);
}
$(function () {
    loadtt();
});
function get_columns() {
    var columns = [];
    var column = [];
    column.push({ field: 'ck', checkbox: true });
    column.push({ field: 'OrderNumber', title: '订单编号', width: 200 });
    column.push({ field: 'ProductTypeDesc', title: '订单类型', width: 100 });
    column.push({ field: 'OrderAddTime', formatter: formatDateTime, title: '订单日期', width: 150 });
    column.push({ field: 'OrderStatusDesc', title: '订单状态', width: 100 });
    column.push({ field: 'TotalCost', title: '订单金额', width: 100 });
    column.push({ field: 'BusinessName', title: '商家名称', width: 100 });
    column.push({ field: 'UserName', title: '买家电话', width: 100 });
    column.push({ field: 'ProductInfo', formatter: formatProductInfo, title: '商品详情', width: 100 });
    column.push({ field: 'ProductName', title: '商品名称', width: 100 });
    column.push({ field: 'VariantName', title: '规格型号', width: 100 });
    column.push({ field: 'CategoryName', title: '分类名称', width: 100 });
    column.push({ field: 'Quantity', title: '购买数量', width: 100 });
    column.push({ field: 'Price', title: '购买单价', width: 100 });
    column.push({ field: 'TotalPrice', title: '购买总价', width: 100 });
    column.push({ field: 'FullAddressInfo', title: '收货地址', width: 260 });
    if (status == 5 || status == 2 || status == 3 || status == 0) {
        column.push({ field: 'PayTime', formatter: formatDateTime, title: '付款时间', width: 120 });
        column.push({ field: 'PaymentMethodDesc', title: '付款方式', width: 100 });
    }
    if (status == 2 || status == 3 || status == 0) {
        column.push({ field: 'ShipTime', formatter: formatDateTime, title: '发货时间', width: 120 });
        column.push({ field: 'ShipTrackNo', title: '运单号', width: 100 });
        column.push({ field: 'ShipCompanyName', title: '货运公司', width: 100 });
    }
    if (status == 3 || status == 0) {
        column.push({ field: 'CompleteTime', formatter: formatDateTime, title: '完成时间', width: 120 });
    }
    if (status == 4 || status == 0) {
        column.push({ field: 'CloseTime', formatter: formatDateTime, title: '关闭时间', width: 120 });
    }
    if (status == 7 || status == 0) {
        column.push({ field: 'RefundTime', formatter: formatDateTime, title: '退款时间', width: 120 });
        column.push({ field: 'RefundReason', title: '退款原因', width: 120 });
    }
    columns.push(column);
    return columns;
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/MallHandler.ashx',
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
        striped: true,
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
        columns: get_columns(),
        toolbar: '#tt_mm',
        onCheck: onCheck,
        onUncheck: onUncheck,
        onLoadSuccess: onLoadSuccess
    });
    SearchTT();
}
function onLoadSuccess(data) {
    MergeCells("tt_table", "ck,OrderNumber,ProductTypeDesc,OrderAddTime,OrderStatusDesc,TotalCost,BusinessName,UserName,ProductInfo,ShipInfo,PayTime,PaymentMethodDesc,ShipTime,ShipTrackNo,ShipCompanyName,CompleteTime,CloseTime,RefundTime,RefundReason");
}
var checked_id = 0;
var unchecked_id = 0;
function onCheck(index, data) {
    if (checked_id > 0) {
        return;
    }
    checked_id = data.ID;
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            checked_id = 0;
        }
        if (row.OrderID == data.OrderID) {
            if (!isChecked(row)) {
                var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#tt_table').datagrid('selectRow', rowIndex);
                }
            }
        }
    })
}
function isChecked(row) {
    var allRows = $("#tt_table").datagrid('getChecked');
    for (var i = 0; i < allRows.length; i++) {
        if (row.ID == allRows[i].ID) {
            return true;
        }
    }
    return false;
}
function onUncheck(index, data) {
    if (unchecked_id > 0) {
        return;
    }
    unchecked_id = data.ID;
    var rows = $("#tt_table").datagrid("getRows");
    $.each(rows, function (i, row) {
        if (i == rows.length - 1) {
            unchecked_id = 0;
        }
        if (row.OrderID == data.OrderID) {
            if (isChecked(row)) {
                var rowIndex = $('#tt_table').datagrid('getRowIndex', row);
                if (rowIndex != index) {
                    $('#tt_table').datagrid('unselectRow', rowIndex);
                }
            }
        }
    })
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        visit: "loadmallordergrid",
        status: status,
        ProductName: parent.ProductName,
        PayStartTime: parent.PayStartTime,
        PayEndTime: parent.PayEndTime,
        BuyerNickName: parent.BuyerNickName,
        OrderStatus: parent.OrderStatus,
        RateStatus: parent.RateStatus,
        OrderNumber: parent.OrderNumber,
        ShipCompany: parent.ShipCompany,
        OrderType: parent.OrderType,
        BusinessName: parent.BusinessName,
        BuyerPhoneNumber: parent.BuyerPhoneNumber
    });
}
function formatBuyerInfo(value, row) {
    return row.UserName + '<br/><a href="javascript:do_view_buyerinfo(' + row.OrderID + ')">查看详情</a>';
}
function formatProductInfo(value, row) {
    return '<a href="javascript:do_view_productinfo(' + row.OrderID + ')">查看详情</a>';
}
function formatShipInfo(value, row) {
    return row.AddressDetailInfo + '<br/><a href="javascript:do_view_shipinfo(' + row.OrderID + ')">查看详情</a>';
}
function do_send() {
    var ID = 0;
    var row = $('#tt_table').datagrid('getSelected');
    if (row == null) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    if (row.OrderStatus != 5 && row.OrderStatus != 2) {
        show_message("请选择待发货状态订单", "info");
        return;
    }
    ID = row.OrderID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Mall/OrderDoShip.aspx?OrderID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '订单发货',
        width: ($(parent.window).width() - 200),
        height: $(parent.window).height(),
        top: 0,
        left: 100,
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
function do_complete() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var is_complete = false;
    var is_close = false;
    $.each(rows, function (index, row) {
        if (row.OrderStatus == 3) {
            is_complete = true;
            return false;
        }
        if (row.IsClosed) {
            is_close = true;
            return false;
        }
        IDList.push(row.OrderID);
    })
    if (is_complete) {
        show_message("选中的订单已完成", "info");
        return;
    }
    if (is_close) {
        show_message("选中的订单已关闭", "info");
        return;
    }
    top.$.messager.confirm("提示", "确认完成选中的订单?", function (r) {
        if (r) {
            var options = { visit: 'completemallorder', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
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
function do_close() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var is_close = false;
    var is_readypay = true;
    $.each(rows, function (index, row) {
        if (row.IsClosed == 4) {
            is_close = true;
            return false;
        }
        if (row.OrderStatus != 1) {
            is_readypay = false;
            return false;
        }
        IDList.push(row.OrderID);
    })
    if (is_close) {
        show_message("选中的订单已关闭", "info");
        return;
    }
    if (!is_readypay) {
        show_message("请选择待付款的订单", "info");
        return;
    }
    top.$.messager.confirm("提示", "确认关闭选中的订单?", function (r) {
        if (r) {
            var options = { visit: 'closemallorder', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
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
function do_view() {
    var ID = 0;
    var row = $('#tt_table').datagrid('getSelected');
    if (row == null) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    ID = row.OrderID;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Mall/OrderDetail.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '订单查看',
        width: ($(parent.window).width() - 200),
        height: $(parent.window).height(),
        top: 0,
        left: 100,
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
function do_view_buyerinfo(ID) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Mall/Order_ViewBuyerInfo.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '买家信息',
        width: ($(parent.window).width() - 400),
        height: $(parent.window).height(),
        top: 0,
        left: 200,
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
function do_view_productinfo(ID) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Mall/Order_ViewProductInfo.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '商品信息',
        width: ($(parent.window).width() - 200),
        height: $(parent.window).height(),
        top: 0,
        left: 100,
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
function do_view_shipinfo(ID) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Mall/Order_ViewShipInfo.aspx?ID=" + ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '收货信息',
        width: ($(parent.window).width() - 400),
        height: $(parent.window).height(),
        top: 0,
        left: 200,
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
function do_pay() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var is_pay = false;
    var is_close = false;
    var IDList = [];
    $.each(rows, function (index, row) {
        if (row.OrderStatus == 2 || row.OrderStatus == 3 || row.OrderStatus == 5) {
            is_pay = true;
            return false;
        }
        if (row.IsClosed) {
            is_close = true;
            return false;
        }
        IDList.push(row.OrderID);
    })
    if (is_pay) {
        show_message("选中的订单已付款", "info");
        return;
    }
    if (is_close) {
        show_message("选中的订单已关闭", "info");
        return;
    }
    top.$.messager.confirm('提示', '确认付款?', function (r) {
        if (r) {
            MaskUtil.mask("body", '提交中');
            var options = { visit: 'dopaymallorder', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
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
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var is_close = true;
    $.each(rows, function (index, row) {
        if (!row.IsClosed) {
            is_close = false;
            return false;
        }
        IDList.push(row.OrderID);
    })
    if (!is_close) {
        show_message("请选择已关闭的订单", "info");
        return;
    }
    top.$.messager.confirm("提示", "确认关闭选中的订单?", function (r) {
        if (r) {
            var options = { visit: 'removemallorder', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('操作成功', 'success', function () {
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

