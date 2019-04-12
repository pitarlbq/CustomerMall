var tt_CanLoad = false;
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
        { field: 'NickName', title: '昵称', width: 100 },
        { field: 'PhoneNumber', title: '电话', width: 100 },
        { field: 'AddTime', formatter: formatDateTime, title: '发放时间', width: 150 },
        { field: 'CouponName', title: '卡券名称', width: 100 },
        { field: 'IsUsedDesc', title: '使用状态', width: 100 },
        { field: 'IsActiveDesc', title: '卡券状态', width: 100 },
        { field: 'CouponTypeDesc', title: '卡券类型', width: 100 },
        { field: 'ActiveTimeRangeDesc', title: '有效期', width: 150 },
        { field: 'UseForALLDesc', title: '使用范围', width: 100 },
        { field: 'UseTypeDesc', title: '卡券规则', width: 100 },
        ]],
        toolbar: '#tt_mm',
        onLoadSuccess: function () {
            $('#tt_table').datagrid('fixRowHeight')
        }
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var CouponType = $("#tdCouponType").combobox("getValue");
    var IsUsed = $("#tdIsUsed").combobox("getValue");
    var IsActive = $("#tdIsActive").combobox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadusercoupongrid",
        "keywords": keywords,
        "CouponType": CouponType,
        "IsUsed": IsUsed,
        "IsActive": IsActive,
        "UserID": UserID
    });
}
function onDblClickRowTT(index, row) {
    EditDataByRow(row)
}
function do_edit() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据进行此操作', 'warning');
        return;
    }
    if (rows.length > 1) {
        show_message('请选择单行进行此操作', 'warning');
        return;
    }
    EditDataByRow(rows[0]);
}
function EditDataByRow(row) {
    var iframe = "../APPSetup/UserCouponEdit.aspx?ID=" + row.ID;
    do_open_dialog('修改用户福顺券', iframe);
}
function do_remove() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据进行此操作', 'warning');
        return;
    }
    var IDList = [];
    var IsTaken = false;
    $.each(rows, function (index, row) {
        if (row.IsTaken) {
            IsTaken = true;
            return false;
        }
        IDList.push(row.ID);
    })
    if (IsTaken) {
        show_message('选择的数据包含已经领用的福顺券，禁止删除', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的数据", function (r) {
        if (r) {
            var options = { visit: 'removeusercoupon', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
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
function do_active(status) {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据进行此操作', 'warning');
        return;
    }
    var IDList = [];
    var can_continue = true;
    $.each(rows, function (index, row) {
        if (!row.IsActive) {
            can_continue = false;
            return false;
        }
        IDList.push(row.ID);
    })
    if (!can_continue) {
        show_message('选中的数据已失效', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "是否失效选中的数据", function (r) {
        if (r) {
            var options = { visit: 'activeusercoupon', IDList: JSON.stringify(IDList), status: status };
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
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function do_all_edit() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据进行此操作', 'warning');
        return;
    }
    var iframe = "../APPSetup/UserCouponEditALL.aspx";
    do_open_dialog('批量修改', iframe);
}
function get_selected_rows() {
    return $("#tt_table").datagrid("getSelections");
}
function do_close() {
    parent.do_close_dialog()
}
