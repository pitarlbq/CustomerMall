var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/MallHandler.ashx',
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
        onDblClickRow: onDblClickRowTT,
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
        { field: 'CheckCategoryName', title: '考核项目', width: 100 },
        { field: 'CheckUserPosition', title: '考核岗位', width: 100 },
        { field: 'CheckRule', title: '考核标准', width: 200 },
        { field: 'UserEarnPoint', title: '奖励员工积分', width: 100 },
        { field: 'UserReducePoint', title: '扣除员工积分', width: 100 },
        { field: 'ApproveStatusDesc', title: '审核状态', width: 100 },
        { field: 'ConfirmStatusDesc', title: '申诉状态', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallusercheckgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "CheckType": $('#tdCheckType').combobox('getValue'),
        "approvestatus": -1,
        "confirmstatus": 0,
        "UserID": UserID
    });
}
function onDblClickRowTT(index, row) {
    EditDataByRow(row)
}
function do_view() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    EditDataByRow(rows[0]);
}
function EditDataByRow(row) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Mall/UserCheckAdd.aspx?ID=" + row.ID + "?op=view' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '查看岗位考核',
        width: ($(window).width() - 400),
        height: $(window).height(),
        top: 0,
        left: 200,
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
function do_close() {
    parent.do_close_dialog()
}