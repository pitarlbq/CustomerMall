var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/UserHandler.ashx',
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
        { field: 'CompanyID', title: 'ID', width: 100, sortable: true },
        { field: 'CompanyName', title: '公司名称', width: 100 },
        { field: 'ChargePerson', title: '联系人', width: 100 },
        { field: 'PhoneNumber', title: '联系电话', width: 100 },
        { field: 'Address', title: '公司地址', width: 100 },
        { field: 'BaseURL', formatter: formatBaseURL, title: '登陆地址', width: 150 },
        { field: 'Distributor', title: '经销商', width: 100 },
        { field: 'UserCount', formatter: formatCount, title: '授权用户数', width: 100 },
        { field: 'ServerStartTime', formatter: formatTime, title: '付费服务开始日期', width: 120 },
        { field: 'ServerEndTime', formatter: formatTime, title: '付费服务结束时间', width: 120 },
        { field: 'IsPayStatus', title: '是否付费', width: 120 },
        { field: 'IsActiveDesc', title: '启用状态', width: 120 },
        { field: 'IsWechatOnDesc', title: '微信状态', width: 120 },
        { field: 'VersionCode', formatter: formatVersionCode, sortable: true, title: '系统版本号', width: 120 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadcompanylist",
        "keywords": keywords,
        "SiteStatus": $('#tdSiteStatus').combobox('getValue'),
        "ServerLocation": $('#tdServerLocation').combobox('getValue'),
        "ActiveStatus": $('#tdActiveStatus').combobox('getValue'),
        "IsWechatOn": $('#tdIsWechatOn').combobox('getValue'),
        "StartTime": $('#tdStartTime').datebox('getValue'),
        "EndTime": $('#tdEndTime').datebox('getValue'),
    });
}
function formatBaseURL(value, row) {
    if (value == '') {
        return "--";
    }
    var result = '<a href="' + value + '" target="_blank">' + value + '</a>';
    return result;
}
function formatCount(value, row) {
    if (Number(value) < 0)
        return 0;
    return value;
}
function formatVersionCode(value, row) {
    if (Number(value) <= 0) {
        return 0;
    }
    return value;
}
function onDblClickRowTT(index, row) {
    EditCompanyByRow(row)
}
function addCompany() {
    var iframe = "../SysSeting/EditCompany.aspx";
    do_open_dialog('新增公司', iframe);
}
function editCompany() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个公司进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    EditCompanyByRow(rows[0]);
}
function EditCompanyByRow(row) {
    var iframe = "../SysSeting/EditCompany.aspx?CompanyID=" + row.CompanyID ;
    do_open_dialog('修改公司', iframe);
}
function removeCompany() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个公司进行此操作", "info");
        return;
    }
    var IDList = [];
    var is_active = false;
    $.each(rows, function (index, row) {
        if (row.IsActive) {
            return false;
            is_active = true;
        }
        IDList.push(row.CompanyID);
    })
    if (is_active) {
        show_message("选中的公司状态必须为禁用", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的公司", function (r) {
        if (r) {
            var options = { visit: 'removecompany', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
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
function AssignSite() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个公司进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    var iframe = "../SysSeting/AssignWebSite.aspx?CompanyID=" + rows[0].CompanyID;
    do_open_dialog('分配网站', iframe);
}
function UpgradeSite() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个公司进行此操作", "info");
        return;
    }
    var iframe = "../SysSeting/UpgradeWebSite.aspx";
    do_open_dialog('版本升级', iframe);
}
function SaveSqlFile() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一个公司进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.CompanyID);
    })
    MaskUtil.mask('body', '提交中');
    var options = { visit: 'savesqlfile', IDList: JSON.stringify(IDList) };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/UserHandler.ashx',
        data: options,
        success: function (message) {
            MaskUtil.unmask();
            if (message.status) {
                show_message('操作成功', 'success');
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

