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
        { field: 'Title', title: '规则名称', width: 100 },
        { field: 'AmountTypeDesc', title: '规则类型', width: 100 },
        { field: 'RuleTypeDesc', title: '赠送类型', width: 100 },
        { field: 'IsActiveDesc', title: '是否启用', width: 100 },
        { field: 'AmountRange', title: '金额区间', width: 200 },
        { field: 'BackAmountDesc', formatter: formatDecimal, title: '返还金额', width: 150 },
        { field: 'BackPointDesc', formatter: formatDecimal, title: '返还积分', width: 150 },
        { field: 'AdditionalEarnServiceDesc', title: '赠送卡券', width: 300 },
        { field: 'Remark', title: '备注', width: 200 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallmemberamountrulegrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "RuleType": $('#tdRuleType').combobox('getValue'),
        "AmountType": $('#tdAmountType').combobox('getValue')
    });
}
function formatDecimal(value, row) {
    if (parseFloat(value) <= 0) {
        return 0;
    }
    return value;
}
function do_add() {
    var iframe = "../Mall/MemberAmountRuleEdit.aspx";
    do_open_dialog('新增规则', iframe);
}
function do_edit() {
    var ID = 0;
    var row = $("#tt_table").datagrid("getSelected");
    if (row == null) {
        show_message('请先选择一行数据', 'info');
        return;
    }
    do_edit_byid(row.ID);
}
function do_edit_byid(ID) {
    var iframe = "../Mall/MemberAmountRuleEdit.aspx?ID=" + ID;
    do_open_dialog('修改规则', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一条数据进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    if (IDList.length == 0) {
        return;
    }
    top.$.messager.confirm("提示", "确认删除选中的规则?", function (r) {
        if (r) {
            var options = { visit: 'removemallamountrule', IDList: JSON.stringify(IDList) };
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