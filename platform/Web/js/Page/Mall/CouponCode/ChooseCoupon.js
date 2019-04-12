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
        { field: 'CouponName', title: '卡券名称', width: 150 },
        { field: 'IsActiveDesc', title: '状态', width: 100 },
        { field: 'CouponTypeDesc', title: '卡券类型', width: 100 },
        { field: 'ActiveTimeRangeDesc', title: '有效期', width: 150 },
        { field: 'UseForALLDesc', title: '使用范围', width: 100 },
        { field: 'UseTypeDesc', title: '卡券规则', width: 100 },
        { field: 'UseCount', title: '使用次数', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallcouponcodegrid",
        "keywords": $('#tdKeyword').searchbox('getValue')
    });
}
function do_choose() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择卡券', 'info');
        return;
    }
    var names = '';
    var idlist = [];
    $.each(rows, function (index, row) {
        if (index > 0) {
            names += ',';
        }
        names += row.CouponName;
        idlist.push(row.ID);
    });
    parent.tdCoupons.textbox('setValue', names);
    parent.hdCoupons.val(JSON.stringify(idlist));
    parent.$('#winchoose').window('close');
}