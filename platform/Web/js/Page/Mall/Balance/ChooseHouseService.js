var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
})
function loadtt() {
    var singleSelect = singleselect == 1;
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
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
        { field: 'Title', title: '服务名称', width: 100 },
        { field: 'CategoryName', title: '服务类别', width: 100 },
        { field: 'PublishStatus', title: '状态', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var CategoryIDList = [];
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "gethouseservicegrid",
        "keywords": keywords,
        "CategoryIDList": JSON.stringify(CategoryIDList),
        "type": type
    });
}
function do_choose() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择服务', 'info');
        return;
    }
    var names = '';
    var idlist = [];
    $.each(rows, function (index, row) {
        if (index > 0) {
            names += ',';
        }
        names += row.Title;
        idlist.push(row.ID);
    });
    if (from == 'CouponCodeEdit') {
        parent.tdServices.textbox('setValue', names);
        parent.hdServices.val(JSON.stringify(idlist));
        parent.$('#winchoose').window('close');
    }
    if (from == 'RotatingImageEdit') {
        parent.isupdate = true;
        parent.hdProducts.val(JSON.stringify(idlist));
        parent.tdURLLinkNames.textbox('setValue', names);
    }
    do_close();
}
function do_close() {
    parent.do_close_dialog();
}

