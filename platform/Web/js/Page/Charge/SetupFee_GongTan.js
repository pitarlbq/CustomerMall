var tt_CanLoad = false;
$(function () {
    //加载
    $('#tt_table').datagrid({
        url: '../Handler/FeeCenterHandler.ashx',
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
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        //onClickCell: onClickCell,
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
        toolbar: '#tb'
    });
    SearchTT();
});
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadlfeesummarylist",
        "FeeType": 3
    });
}
function formatPrice(value, row) {
    if (value < 0) {
        return 0;
    }
    return value;
}
function addFee() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Charge/EditGongTanFee.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
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
            $('#tt_table').datagrid("reload");
        }
    });
}
function editFee() {
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Charge/EditGongTanFee.aspx?ID=" + rows[0].ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
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
            $('#tt_table').datagrid("reload");
        }
    });
}
function deleteFee() {
    var list = [];
    var rows = $('#tt_table').datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请选择一个收费标准", "info");
        return;
    }
    $.each(rows, function (index, row) {
        list.push(row.ID);
    });
    top.$.messager.confirm("提示", "确认删除选中的收费标准?", function (r) {
        if (r) {
            var options = { visit: 'deletesummaryfee', list: JSON.stringify(list) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success');
                        $('#tt_table').datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    });

}