var tt_CanLoad = false, isUpdate = false, content;
$(function () {
    $('#tdallcheck').bind('click', function () {
        content.is_all_checked = $('#tdallcheck').prop('checked');
        content.do_select_all();
    })
    $('#tdhideclose').bind('click', function () {
        content.hide_close = $('#tdhideclose').prop('checked');
    })
    content = new Vue({
        el: '#fieldcontent',
        data: {
            orderlist: [],
            form: {
                pageindex: 1,
                pagesize: 100,
                totalrows: 0
            },
            is_all_checked: false,
            hide_close: false,
            can_export: false,
            ShareUserID: 0
        },
        methods: {
            getdata: function () {
                var that = this;
                var RoomIDs = [];
                var ProjectIDs = [];
                try {
                    RoomIDs = parent.GetSelectedRooms();
                    ProjectIDs = parent.GetSelectedProjects();
                } catch (e) {
                }
                var options = {
                    visit: 'getmallorderlistbyvue',
                    page: that.form.pageindex,
                    rows: that.form.pagesize,
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
                    BuyerPhoneNumber: parent.BuyerPhoneNumber,
                    HideClose: that.hide_close,
                    ProjectID: parent.ProjectID,
                    canexport: that.can_export,
                    ShareUserID: that.ShareUserID,
                    RoomIDs: JSON.stringify(RoomIDs),
                    ProjectIDs: JSON.stringify(ProjectIDs),
                };
                MaskUtil.mask('body');
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/MallHandler.ashx',
                    data: options,
                    success: function (data) {
                        MaskUtil.unmask();
                        that.can_export = false;
                        if (data.status) {
                            if (data.downloadurl) {
                                window.location.href = data.downloadurl;
                                return;
                            }
                            that.orderlist = data.orderlist;
                            that.form.totalrows = data.totalrows;
                            reset_pagination()
                            return;
                        }
                        if (data.error) {
                            show_message(data.error, "info");
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            do_select: function (item) {
                var that = this;
                item.ischecked = !item.ischecked;
            },
            do_select_all: function () {
                var that = this;
                $.each(that.orderlist, function (index, item) {
                    item.ischecked = that.is_all_checked;
                })
            },
            do_send: function (item) {
                var that = this;
                if (item.OrderStatus != 5 && item.OrderStatus != 2) {
                    show_message("请选择待发货状态订单", "info");
                    return;
                }
                var iframe = "../Mall/OrderDoShip.aspx?OrderID=" + item.OrderID;
                do_open_dialog('订单发货', iframe);
            },
            do_change_price: function (item) {
                var that = this;
                if (item.OrderStatus != 1) {
                    show_message("请选择待付款状态订单", "info");
                    return;
                }
                var iframe = "../Mall/OrderDoChangePrice.aspx?OrderID=" + item.OrderID;
                do_open_dialog('订单修改价格', iframe);
            },
            do_change_note: function (item) {
                var that = this;
                var iframe = "../Mall/OrderDoChangeNote.aspx?OrderID=" + item.OrderID;
                do_open_dialog('订单修改备注', iframe);
            },
            do_view: function (item) {
                var that = this;
                var iframe = "../Mall/OrderDetail.aspx?ID=" + item.OrderID;
                do_open_dialog('订单详情', iframe);
            },
            do_change_shiprate: function (item) {
                var that = this;
                if (item.OrderStatus != 1) {
                    show_message("请选择待付款状态订单", "info");
                    return;
                }
                var iframe = "../Mall/OrderDoChangeShipRate.aspx?OrderID=" + item.OrderID;
                do_open_dialog('订单修改运费', iframe);
            },
            do_refund: function (item) {
                var that = this;
                if (item.OrderStatus != 6) {
                    show_message("请选择退款申请状态订单", "info");
                    return;
                }
                var iframe = "../Mall/OrderDoRefund.aspx?OrderID=" + item.OrderID;
                do_open_dialog('订单退款', iframe);
            },
            do_paidan: function (item) {
                var that = this;
                if (item.OrderStatus != 5 && item.OrderStatus != 2) {
                    show_message("请选择待发货状态订单", "info");
                    return;
                }
                var iframe = "../Mall/OrderDoSendAPP.aspx?OrderID=" + item.OrderID;
                do_open_dialog('派单', iframe);
            },
            do_print: function (ID) {
                var that = this;
                MaskUtil.mask('body', '打印中');
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    url: '../Handler/MallHandler.ashx',
                    data: { visit: 'getprintidbyorderid', ID: ID },
                    success: function (data) {
                        if (data.status) {
                            var iframe = document.getElementById("myframe");
                            var url = "../PrintPage/printmallorderview.aspx?OrderID=" + ID;
                            var pageWidth = 210;
                            var pageHeight = 297;
                            if (data.PrintID > 0) {
                                url = "../PrintPage/printchargefeeview.aspx?PrintID=" + data.PrintID;
                                pageHeight = 297;
                            }
                            iframe.src = url;
                            if (iframe.attachEvent) {
                                iframe.attachEvent("onload", function () {
                                    MaskUtil.unmask();
                                    setTimeout(function () {
                                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                                        LODOPPrint(strHtml, pageWidth, pageHeight);
                                    }, 1000);
                                });
                            } else {
                                iframe.onload = function () {
                                    MaskUtil.unmask();
                                    setTimeout(function () {
                                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                                        LODOPPrint(strHtml, pageWidth, pageHeight);
                                    }, 1000);
                                };
                            }
                            return;
                        }
                        MaskUtil.unmask();
                        if (data.error) {
                            show_message(data.error, "info");
                            return;
                        }
                        show_message('系统错误', 'error');
                    }
                });
            },
            do_open_share_order: function (ShareUserID) {
                var that = this;
                if (ShareUserID <= 0) {
                    return;
                }
                var iframe = "../Mall/OrderMgr.aspx?ShareUserID=" + ShareUserID;
                do_open_dialog('分享订单', iframe);
            }
        }
    });
    content.ShareUserID = ShareUserID;
    content.getdata();
    reset_pagination();
});
function SearchTT() {
    content.getdata();
}
function reset_pagination() {
    $('#data_pagination').pagination({
        total: content.form.totalrows,
        pageSize: content.form.pagesize,
        pageNumber: content.form.pageindex,
        pageList: [100, 500],
        onSelectPage: function (pageNumber, pageSize) {
            content.form.pageindex = pageNumber;
            $(this).pagination('loading');
            content.getdata();
            $(this).pagination('loaded');
        }
    });
}
function get_selections() {
    var list = [];
    $.each(content.orderlist, function (index, item) {
        if (item.ischecked) {
            list.push(item);
        }
    })
    return list;
}
function get_selected() {
    var list = get_selections();
    if (list.length == 0) {
        return null;
    }
    return list[0];
}
function do_change_price_all() {
    var ID = 0;
    var rows = get_selections();
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var can_change = true;
    $.each(rows, function (index, row) {
        if (row.OrderStatus != 1) {
            can_change = false;
            return false;
        }
        IDList.push(row.OrderID);
    })
    if (!can_change) {
        show_message("请选择待付款状态订单", "info");
        return;
    }
    var iframe = "../Mall/OrderDoChangePrice.aspx?OrderID=" + ID;
    do_open_dialog('订单批量改价', iframe);
}
function do_send_all() {
    var ID = 0;
    var rows = get_selections();
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var can_send = true;
    $.each(rows, function (index, row) {
        if (row.OrderStatus != 5 && row.OrderStatus != 2) {
            can_send = false;
            return false;
        }
        IDList.push(row.OrderID);
    })
    if (!can_send) {
        show_message("请选择待发货状态订单", "info");
        return;
    }
    var iframe = "../Mall/OrderDoShip.aspx?OrderID=" + ID;
    do_open_dialog('订单批量发货', iframe);
}
function do_complete() {
    var rows = get_selections();
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
                            content.getdata();
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
    var rows = get_selections();
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
                            content.getdata();
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
function do_view_buyerinfo(ID) {
    var iframe = "../Mall/Order_ViewBuyerInfo.aspx?ID=" + ID;
    do_open_dialog('买家信息', iframe);
}
function do_view_productinfo(ID) {
    var iframe = "../Mall/Order_ViewProductInfo.aspx?ID=" + ID;
    do_open_dialog('商品信息', iframe);
}
function do_view_shipinfo(ID) {
    var iframe = "../Mall/Order_ViewShipInfo.aspx?ID=" + ID;
    do_open_dialog('收货信息', iframe);
}
function do_pay() {
    var rows = get_selections();
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
                            content.getdata();
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
    var rows = get_selections();
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
    top.$.messager.confirm("提示", "确认删除选中的订单?", function (r) {
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
                            content.getdata();
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
function do_change_shiprate_all() {
    var ID = 0;
    var rows = get_selections();
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var can_change = true;
    $.each(rows, function (index, row) {
        if (row.OrderStatus != 1) {
            can_change = false;
            return false;
        }
        IDList.push(row.OrderID);
    })
    if (!can_change) {
        show_message("请选择待付款状态订单", "info");
        return;
    }
    var iframe = "../Mall/OrderDoChangeShipRate.aspx?OrderID=" + ID;
    do_open_dialog('订单批量改运费', iframe);
}
function do_paidan_all() {
    var ID = 0;
    var rows = get_selections();
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    var can_send = true;
    $.each(rows, function (index, row) {
        if (row.OrderStatus != 5 && row.OrderStatus != 2) {
            can_send = false;
            return false;
        }
        IDList.push(row.OrderID);
    })
    if (!can_send) {
        show_message("请选择待发货状态订单", "info");
        return;
    }
    var iframe = "../Mall/OrderDoSendAPP.aspx?OrderID=" + ID;
    do_open_dialog('批量派单', iframe);
}

function LODOPPrint(strHtml, pageWidth, pageHeight) {
    var LODOP = null;
    try {
        LODOP = getLodop();
        if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
            LODOP.PRINT_INIT("打印订单");
            LODOP.SET_PRINT_PAGESIZE(1, pageWidth + 'mm', pageHeight + 'mm', '')
            LODOP.ADD_PRINT_TABLE(0, '3%', '94%', '100%', strHtml);
            LODOP.PREVIEW();
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
}
function do_export() {
    content.can_export = true;
    content.getdata();
}
