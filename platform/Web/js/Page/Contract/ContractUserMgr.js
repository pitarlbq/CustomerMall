var tt_CanLoad = false, isUpdate = false;
$(function () {
    loadtt();
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/RoomResourceHandler.ashx',
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
            { field: 'ContractNo', title: '合同编号', width: 100 },
            { field: 'ContractName', title: '合同名称', width: 100 },
            { field: 'RelationPropertyDesc', title: '租户类型', width: 100 },
            { field: 'RelateName', title: '租户名称', width: 100 },
            { field: 'RelatePhoneNumber', title: '联系电话', width: 100 },
            { field: 'IDCardTypeDesc', title: '证件类别', width: 100 },
            { field: 'RelateIDCard', title: '证件号码', width: 100 },
            { field: 'ChargeForMan', title: '法人代表', width: 100 },
            { field: 'BusinessLicense', title: '营业执照', width: 100 },
            { field: 'SellerProduct', title: '经营品类', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    tt_CanLoad = true;
    var RoomIDs = GetSelectedRooms();
    var ProjectIDs = GetSelectedProjects();
    $("#tt_table").datagrid("load", {
        "visit": "loadlrelatefamily",
        "keywords": $('#tdKeyword').searchbox('getValue'),
        "ProjectIDs": JSON.stringify(ProjectIDs),
        "RoomIDs": JSON.stringify(RoomIDs),
        "IsContractUser": true
    });
}
function do_add() {
    var iframe = "../RoomResource/EditRelateFamily.aspx";
    do_open_dialog('合同用户登记', iframe, true);
}
function do_edit() {
    var row = $('#tt_table').datagrid('getSelected');
    if (row == null) {
        show_message("只能选择一个用户数据", "info");
        return;
    }
    var iframe = "../RoomResource/EditRelateFamily.aspx?ID=" + row.ID;
    do_open_dialog('合同用户修改', iframe, true);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("只能选择一个用户数据", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的用户?", function (r) {
        if (r) {
            var options = { visit: 'deletefamily', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/RoomResourceHandler.ashx',
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
    })
}