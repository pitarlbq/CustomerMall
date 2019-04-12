var tt_CanLoad = false, isUpdate = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
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
        { field: 'ServiceTypeDesc', title: '服务类型', width: 100 },
        { field: 'FullName', formatter: formatFullName, title: '资源位置', width: 200 },
        { field: 'ServiceFromDesc', title: '任务来源', width: 100 },
        { field: 'PhoneNumber', title: '电话', width: 100 },
        { field: 'ServiceContent', formatter: formatServiceContent, title: '服务内容', width: 100 },
        { field: 'ServiceAddTime', formatter: formatDateTime, title: '预约时间', width: 100 },
        { field: 'NickName', title: '微信昵称', width: 150 },
        { field: 'AddTime', formatter: formatDateTime, title: '提交时间', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var servicetype = $("#tdServiceType").combobox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getservicelist",
        "keywords": keywords,
        "servicetype": servicetype
    });
}
function formatFullName(value, row) {
    var FullName = "";
    if (row.FullName == '') {
        row.FullName = row.RoomFullName;
    }
    if (row.FullName != null && row.FullName != "") {
        FullName = row.FullName;
    }
    var RoomName = "";
    if (row.RoomName != null && row.RoomName != "") {
        RoomName = row.RoomName;
    }
    if (FullName != "" && RoomName != "") {
        return FullName + "-" + RoomName;
    }
    return FullName + RoomName;
}
function formatServiceContent(value, row) {
    return value.length > 10 ? value.substring(0, 9) : value;
}
function formatOperation(value, row) {
    var $html = '<div>';
    $html += '<a onclick="viewRow(' + row.ID + ')" style="margin-right:10px;">详情</a>';
    $html += '<a onclick="goCustomerService(' + row.ID + ')">转客服总台</a>';
    $html += '</div>';
    return $html;
}
function goCustomerService(id) {
    var iframe = "../CustomerService/AddService.aspx?WechatID=" + id;
    do_open_dialog('转客服总台', iframe);
}
function viewRow(id) {
    var iframe = "../Wechat/ViewService.aspx?ID=" + id;
    do_open_dialog('反馈详情', iframe);
}
function deleteRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择需要删除的数据', 'info');
        return;
    }
    var IDList = [];
    $.each(rows, function () {
        IDList.push(this.ID);
    })
    top.$.messager.confirm('提示', '确认要删除选中的数据?', function (r) {
        if (r) {
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'deleteservice', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('删除成功', 'success');
                        $("#tt_table").datagrid("reload");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    })
}
function addRow() {
    var iframe = "../Wechat/ViewService.aspx";
    do_open_dialog('新增请求', iframe);
}
