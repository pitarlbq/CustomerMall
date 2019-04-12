var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
});
function loadtt() {
    var singleSelect = singleselect == 1;
    $('#tt_table').datagrid({
        url: '../Handler/MallHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: singleSelect,
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
        { field: 'BusinessName', title: '门店名称', width: 150 },
        { field: 'BusinessAddress', title: '门店地址', width: 200 },
        { field: 'CategoryName', title: '经营类别', width: 100 },
        { field: 'StatusDesc', title: '状态', width: 200 },
        { field: 'ContactName', title: '联系人', width: 150 },
        { field: 'ContactPhone', title: '联系电话', width: 100 },
        { field: 'LicenseNumber', title: '营业执照号', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadmallbusinessgrid",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "Status": 1
    });
}
function do_choose() {
    var list = [];
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择店铺', 'info');
        return;
    }
    var names = '';
    $.each(rows, function (index, row) {
        list.push(row.ID);
        if (index > 0) {
            names += ",";
        }
        names += row.BusinessName;
    })
    if (from == 'RotatingImageEdit') {
        parent.isupdate = true;
        parent.hdProducts.val(JSON.stringify(list));
        parent.tdURLLinkNames.textbox('setValue', names);
    }
    if (from == 'CouponCodeEdit') {
        parent.isupdate = true;
        parent.hdStores.val(JSON.stringify(list));
        parent.tdStores.textbox('setValue', names);
    }
    do_close();
}
function do_close() {
    parent.do_close_dialog();
}