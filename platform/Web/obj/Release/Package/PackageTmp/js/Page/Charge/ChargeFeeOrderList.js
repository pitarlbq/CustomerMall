var tt_CanLoad = false;
$(function () {
    loadProject();
    setTimeout(function () {
        loadtt();
    }, 500);
});

function loadProject() {
    var options = { visit: 'loadcreateorderparams' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AnalysisHandler.ashx',
        data: options,
        success: function (data) {
            $("#tdAddMan").combobox({
                editable: false,
                multiple: true,
                data: data.UList,
                valueField: 'UserID',
                textField: 'RealName',
            });
            $("#tdApproveMan").combobox({
                editable: false,
                multiple: true,
                data: data.UList,
                valueField: 'UserID',
                textField: 'RealName',
            });
        }
    });
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/AnalysisHandler.ashx',
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
        onDblClickRow: onDblClickRowTT,
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
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'OrderNumber', title: '交款编号', width: 200 },
        { field: 'OrderTime', formatter: formatTime, title: '交款日期', width: 100 },
        { field: 'OrderUserMan', title: '交款人', width: 100 },
        { field: 'ShouTotalCost', title: '收款金额', width: 100 },
        { field: 'FuTotalCost', title: '付款金额', width: 100 },
        { field: 'OrderCost', title: '交款金额', width: 100 },
        { field: 'ApproveStatusDesc', title: '审核状态', width: 100 },
        { field: 'ApproveMan', title: '审核人', width: 100 },
        { field: 'ApproveTime', formatter: formatTime, title: '审核日期', width: 100 },
        { field: 'Oper', formatter: formatOper, title: '操作', width: 100 }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var AddManList = $("#tdAddMan").combobox("getValues");
    var ApproveManList = $("#tdApproveMan").combobox("getValues");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadchargefeeorderlist",
        "StartTime": $("#tdStartTime").datetimebox("getValue"),
        "EndTime": $("#tdEndTime").datetimebox("getValue"),
        "AddMans": JSON.stringify(AddManList),
        "ApproveStatus": $("#tdApproveStatus").combobox("getValue"),
        "ApproveMans": JSON.stringify(ApproveManList)
    });
}
function onDblClickRowTT(index, row) {

}
function formatOper(value, row) {
    var $html = '<div>';
    $html += '<a onclick="printData(' + row.ID + ')"><span style="color:red;">打印</span></a>';
    $html += '</div>';
    return $html;
}
function printData(ID) {
    var options = { visit: "loadprintfeeorder", ID: ID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/PrintHandler.ashx',
        data: options,
        success: function (data) {
            LODOPPrint(data.html, data.height);
        }
    });
}
function LODOPPrint(strHtml, height) {
    try {
        var LODOP = getLodop();
        if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
            var strStyleCSS = "<link href='../styles/page/printfeeorder.css?v3' type='text/css' rel='stylesheet'>";
            var strFormHtml = strStyleCSS + "<body>" + strHtml + "</body>";
            LODOP.PRINT_INIT("打印交款单");
            LODOP.SET_PRINT_PAGESIZE(3, 2100, "", "");
            LODOP.ADD_PRINT_HTM(0, '5%', "90%", "100%", strFormHtml);
            //LODOP.ADD_PRINT_LINE(1, 1, 1, 1, 0, 1);
            LODOP.PREVIEW();
        }
        else {
            alert("Error:该浏览器不支持打印插件!");
        }
    } catch (err) {
        alert("Error:本机未安装或需要升级!");
    }
};
function ApproveData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length != 1) {
        show_message("请选择一条交款记录", "warning");
        return;
    }
    var iframe = "../Charge/ApproveFeeOrder.aspx?ID=" + rows[0].ID;
    do_open_dialog('审核', iframe);
}
function DeleteData() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条交款记录", "warning");
        return;
    }
    var IDList = [];
    var isapproved = false;
    $.each(rows, function () {
        if (this.ApproveStatus == 1) {
            isapproved = true;
            return false;
        }
        IDList.push(this.ID);
    })
    if (isapproved) {
        show_message("选中项包含已审批的交班记录,禁止删除", "warning");
        return;
    }
    top.$.messager.confirm("提示", "确认删除?", function (r) {
        if (r) {
            var options = { visit: "deleteorder", IDList: JSON.stringify(IDList) };
            $.post("../Handler/AnalysisHandler.ashx", options, function (data) {
                if (!data.status) {
                    show_message('系统错误', 'error');
                    return;
                }
                if (data.approved) {
                    show_message("选中项包含已审批的交班记录,禁止删除", "warning");
                    return;
                }
                show_message('删除成功', 'success');
                $("#tt_table").datagrid("reload");
            }, "json")
        }
    })
}
function do_cancel() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条交款记录", "warning");
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    top.$.messager.confirm("提示", "确认作废?", function (r) {
        if (r) {
            var options = { visit: "cancelfeeorder", IDList: JSON.stringify(IDList) };
            $.post("../Handler/AnalysisHandler.ashx", options, function (data) {
                if (!data.status) {
                    show_message('系统错误', 'error');
                    return;
                }
                show_message("作废成功", "success");
                $("#tt_table").datagrid("reload");
            }, "json")
        }
    })
}

