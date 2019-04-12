var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/CKHandler.ashx',
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
        { field: 'ContractNumber', title: '供应商编号', width: 100 },
        { field: 'ContractName', title: '供应商简称', width: 100 },
        { field: 'ContactMan', title: '联系人', width: 100 },
        { field: 'PhoneNumber', title: '联系电话', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 150, align: 'center' }
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadcontractgrid",
        "keywords": keywords
    });
}
function onDblClickRowTT(index, row) {
    editByRow(row.ID)
}
function formatOperation(value, row) {
    var $html = '';
    $html += '<a onclick="editByRow(' + row.ID + ')"><span style="color:red;">修改</span></a>';
    return $html;
}
function addRow() {
    var iframe = "../CangKu/EditContract.aspx";
    do_open_dialog('新增供应商', iframe);
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个供应商进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    editByRow(rows[0].ID);
}
function editByRow(ID) {
    var iframe = "../CangKu/EditContract.aspx?ID=" + ID;
    do_open_dialog('修改供应商', iframe);
}
function removeRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个进行此操作", "warning");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的供应商", function (r) {
        if (r) {
            var options = { visit: 'removecontract', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $("#tt_table").datagrid("reload");
                            doSearch();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function chooseRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个供应商进行此操作", "warning");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "warning");
        return;
    }
    try {
        parent.ChosenContractID = rows[0].ID;
        parent.ContractName = rows[0].ContractName;
        parent.ContractPhoneNumber = rows[0].PhoneNumber;
        parent.ContractContactMan = rows[0].ContactMan;
    } catch (e) {

    }
    do_close();
}
