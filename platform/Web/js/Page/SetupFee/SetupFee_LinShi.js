var shouru_CanLoad = false;
var yushou_CanLoad = false;
var yajin_CanLoad = false;
var daishou_CanLoad = false;
var gongtan_CanLoad = false;
$(function () {
    $('#LinShiAccording').accordion({
        animate: true,
        fit: true,
        onSelect: function (title, index) {
            shouru_CanLoad = false;
            yushou_CanLoad = false;
            yajin_CanLoad = false;
            daishou_CanLoad = false;
            gongtan_CanLoad = false;
            loadGrid(title);
        }
    });
    loadGrid("收入");
});
function loadGrid(id) {
    var obj = $('#' + id + '_table');
    obj.datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        //onClickCell: onClickCell,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (id == "收入") {
                if (!shouru_CanLoad) {
                    obj.datagrid("loadData", {
                        total: 0,
                        rows: []
                    });
                }
                return shouru_CanLoad;
            }
            else if (id == "预收") {
                if (!yushou_CanLoad) {
                    obj.datagrid("loadData", {
                        total: 0,
                        rows: []
                    });
                }
                return yushou_CanLoad;
            }
            else if (id == "押金") {
                if (!yajin_CanLoad) {
                    obj.datagrid("loadData", {
                        total: 0,
                        rows: []
                    });
                }
                return yajin_CanLoad;
            }
            else if (id == "代收") {
                if (!daishou_CanLoad) {
                    obj.datagrid("loadData", {
                        total: 0,
                        rows: []
                    });
                }
                return daishou_CanLoad;
            }
            else if (id == "公摊") {
                if (!gongtan_CanLoad) {
                    obj.datagrid("loadData", {
                        total: 0,
                        rows: []
                    });
                }
                return gongtan_CanLoad;
            }
        },
        onLoadError: function (data) {
            //alert("有错");
            obj.datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        toolbar: '#' + id + '_tb'
    });
    SearchTT(id);
}
function SearchTT(id) {
    var CategoryID;
    var FeeType = 4;
    if (id == "收入") {
        CategoryID = 1;
        shouru_CanLoad = true;
    }
    else if (id == "预收") {
        CategoryID = 4;
        yushou_CanLoad = true;
    }
    else if (id == "押金") {
        CategoryID = 3;
        yajin_CanLoad = true;
    }
    else if (id == "代收") {
        FeeType = 2;
        CategoryID = 0;
        daishou_CanLoad = true;
    }
    else if (id == "公摊") {
        FeeType = 3;
        CategoryID = 0;
        gongtan_CanLoad = true;
    }
    $("#" + id + "_table").datagrid("load", {
        "visit": "loadlfeesummarylist",
        "FeeType": FeeType,
        "CategoryID": CategoryID
    });
}
function formatPrice(value, row) {
    if (value < 0) {
        return 0;
    }
    return value;
}
function addFee(id) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/EditLinShiFee.aspx?op=" + id + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    if (id == "代收") {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/EditChaoBiaoFee.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    }
    else if (id == "公摊") {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/EditGongTanFee.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    }
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '新增收费标准',
        width: $(window).width() - 100,
        height: $(window).height(),
        top: 0,
        left: 50,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $('#' + id + '_table').datagrid("reload");
        }
    });
}
function editFee(id) {
    var rows = $('#' + id + '_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/EditLinShiFee.aspx?op=" + id + "&ID=" + rows[0].ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    if (id == "代收") {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/EditChaoBiaoFee.aspx?ID=" + rows[0].ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    }
    else if (id == "公摊") {
        iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SetupFee/EditGongTanFee.aspx?ID=" + rows[0].ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    }
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '修改收费标准',
        width: $(window).width() - 100,
        height: $(window).height(),
        top: 0,
        left: 50,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $('#' + id + '_table').datagrid("reload");
        }
    });
}
function deleteFee(id) {
    var list = [];
    var rows = $('#' + id + '_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    $.each(rows, function (index, row) {
        list.push(row.ID);
    });
    var options = { visit: "checktempsummaryhistoryfee", ChargeIDs: JSON.stringify(list) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (data) {
            if (data.status == 3) {
                show_message("有该费项的历史账单,删除取消", "info");
                return;
            }
            if (data.status == 4) {
                show_message("有导入账单信息,删除取消", "info");
                return;
            }
            if (data.status == 2) {
                top.$.messager.confirm("提示", "有该费项的历史账单且都已作废,是否继续删除", function (r) {
                    if (r) {
                        deletesummaryfee(list);
                    }
                });
                return;
            }
            top.$.messager.confirm("提示", "确认删除选中的收费标准?", function (r) {
                if (r) {
                    deletesummaryfee(list)
                }
            });
        }
    });
}
function deletesummaryfee(list) {
    var options = { visit: 'deletesummaryfee', list: JSON.stringify(list) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/FeeCenterHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                show_message('删除成功', 'success');
                $('#' + id + '_table').datagrid("reload");
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}