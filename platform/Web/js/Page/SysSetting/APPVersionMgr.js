var tt_CanLoad = false;
$(function () {
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/SysSettingHandler.ashx',
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
        { field: 'APPVersionDesc', title: '版本', width: 100 },
        { field: 'APPVersionCode', title: '版本号', width: 100 },
        { field: 'APPTypeDesc', title: 'APP类型', width: 100 },
        { field: 'VersionTypeDesc', title: '版本类型', width: 100 },
        { field: 'IsForceUpdateDesc', title: '是否强制升级', width: 100 },
        { field: 'PublishDate', formatter: formatDateTime, title: '发布时间', width: 100 },
        { field: 'VersionDesc', title: '版本描述', width: 100 },
        { field: 'FilePath', formatter: formatFilePath, title: '安装包下载地址', width: 100 },
        { field: 'Operation', formatter: formatOperation, title: '操作', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var VersionType = $("#tdVersionType").combobox("getValue");
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadversiongrid",
        "keywords": keywords,
        "VersionType": VersionType,
        "OnlyAPP": true
    });
}
function formatOperation(value, row) {
    if (row.VersionType == '' || row.VersionType == 'platform') {
        return '';
    }
    var FilePath = "'" + row.FilePath + "'";
    return '<a href="javascript:viewQrCode(' + FilePath + ')">查看二维码</a>'
}
function viewQrCode(FilePath) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Wechat/ViewQrCodeByURL.aspx?pageurl=" + FilePath + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winaddprize'></div>").appendTo("body").window({
        title: '微信二维码',
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
            parent.$("#winaddprize").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function formatFilePath(value, row) {
    if (value == '') {
        return "--";
    }
    var result = '<a href="' + value + '" target="_blank">下载</a>';
    return result;
}
function onDblClickRowTT(index, row) {
    EditByRow(row)
}
function addRow() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/APPVersionEdit.aspx' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '新增版本',
        width: $(parent.window).width() - 400,
        height: $(parent.window).height(),
        top: 0,
        left: 200,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function editRow() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一行数据进行此操作", "info");
        return;
    }
    if (rows.length > 1) {
        show_message("请选择单行进行此操作", "info");
        return;
    }
    EditByRow(rows[0]);
}
function EditByRow(row) {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/APPVersionEdit.aspx?VersionID=" + row.ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '修改版本',
        width: $(parent.window).width() - 400,
        height: $(parent.window).height(),
        top: 0,
        left: 200,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
            $("#tt_table").datagrid("reload");
        }
    });
}
function removeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message("请至少选择一行进行此操作", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的版本", function (r) {
        if (r) {
            var options = { visit: 'removeversions', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
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
