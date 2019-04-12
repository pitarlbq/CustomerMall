var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        gettablecolumn();
    }, 500);
});
function gettablecolumn() {
    var options = { visit: 'loadtablecolumn', pagecode: 'chequestampmgr' };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/RoomResourceHandler.ashx',
        data: options,
        success: function (message) {
            if (message.status) {
                var finalcolumn = [];
                finalcolumn = eval(message.columns);
                loadtt(finalcolumn);
            }
        }
    });
}
function loadtt(finalcolumn) {
    tt_CanLoad = false;
    $('#tt_table').datagrid({
        url: '../Handler/ChequeHandler.ashx',
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
        columns: finalcolumn,
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadchequestampgrid",
        "keywords": keywords
    });
}
function formatNumber(value, row) {
    return (Number(value) > 0 ? value : "");
}
function addRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ChequeStampEdit.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '印花税登记',
        width: ($(window).width() - 200),
        height: $(window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function editRow() {
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message("请选择一项进行此操作", "info");
        return;
    }
    EditDataByRow(row);
}
function EditDataByRow(row) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ChequeStampEdit.aspx?ID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '印花税修改',
        width: ($(window).width() - 200),
        height: $(window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个进项进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "确认删除选中的进项?", function (r) {
        if (r) {
            var options = { visit: 'removechequestamp', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ChequeHandler.ashx',
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
function doImport() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Cheque/ImportChequeStamp.aspx' style='width:100%;height:" + ($(window).height() - 190) + "px;'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '导入印花税',
        width: $(window).width() - 400,
        height: $(window).height() - 150,
        top: 50,
        left: 200,
        modal: false,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function openTableSetUp() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/TableSetUp.aspx?PageCode=chequestampmgr' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '印花税列表设置',
        width: $(window).width() - 400,
        height: $(window).height(),
        top: 0,
        left: 300,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            gettablecolumn();
        }
    });
}