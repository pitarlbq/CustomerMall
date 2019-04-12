var tt_CanLoad = false;
$(function () {
    loadBiao();
    setTimeout(function () {
        loadtt();
    }, 500);
});
function loadBiao() {
    var biaoData = hdBiaoCategory.val();
    var biaoarray = [];
    if (biaoData != "") {
        biaoarray = eval("(" + biaoData + ")");
    }
    var biaolist = [];
    biaolist.push({ ID: 0, Name: '全部' });
    $.each(biaoarray, function () {
        biaolist.push({ ID: this.ID, Name: this.BiaoCategory });
    })
    $("#tdBiaoCategory").combobox({
        editable: false,
        data: biaolist,
        valueField: 'ID',
        textField: 'Name'
    });
    $("#tdBiaoCategory").combobox('setValue', 0);
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/ImportFeeHandler.ashx',
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
        { field: 'FullName', formatter: formatFullName, title: '项目/房间名称', width: 300 },
        { field: 'ChargeName', title: '收费项目', width: 100 },
        { field: 'BiaoName', title: '表名称', width: 100 },
        { field: 'BiaoCategory', title: '表种类', width: 100 },
        { field: 'BiaoGuiGe', title: '表规格', width: 100 },
        { field: 'IsActiveDesc', title: '作废状态', width: 100 },
        { field: 'RelationStatusDesc', title: '关联状态', width: 100 }
        ]],
        toolbar: '#tb'
    });
    SearchTT();
}
function SearchTT() {
    var roomids = [];
    var projectids = [];
    var projectid = null;
    try {
        roomids = parent.parent.GetSelectCheck();
        projectid = parent.parent.GetSelectRadio();
    } catch (e) {

    }
    if (projectid != null && projectid != "") {
        projectids.push(projectid);
    }
    var keywords = $("#tdKeyword").searchbox("getValue");
    var BiaoCategory = $('#tdBiaoCategory').combobox('getValue');
    var ActiveStatus = $('#tdActiveStatus').combobox('getValue');
    var RelationStatus = $('#tdRelationStatus').combobox('getValue');
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "loadtaizhanggrid",
        "keywords": keywords,
        "BiaoCategory": BiaoCategory,
        "ActiveStatus": ActiveStatus,
        "RoomIDList": JSON.stringify(roomids),
        "ProjectIDList": JSON.stringify(projectids),
        "RelationStatus": RelationStatus,
        "ID": ID
    });
}
function formatFullName(value, row) {
    if (row.Name != '') {
        return value + '-' + row.Name;
    }
    return value;
}
function formatDecimal(value, row) {
    if (Number(value) < 0) {
        return 0;
    }
    return value;
}
function activeRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据进行此操作', 'warning');
        return;
    }
    var IDList = [];
    var cancontinue = true;
    var isfenbiao = true;
    $.each(rows, function () {
        if (this.RelationCount > 0) {
            cancontinue = false;
            return false;
        }
        IDList.push(this.ID);
    })
    if (!cancontinue) {
        show_message('选中行包含已关联的数据', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "确认关联选中的数据?", function (r) {
        if (r) {
            var options = { visit: 'connectprojectbiao', IDList: JSON.stringify(IDList), ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('关联成功', 'success', function () {
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
function cancelRows() {
    var rows = $("#tt_table").datagrid("getSelections");
    if (rows.length == 0) {
        show_message('请至少选择一条数据进行此操作', 'warning');
        return;
    }
    var cancontinue = true;
    var IDList = [];
    $.each(rows, function () {
        if (Number(this.RelationCount) <= 0) {
            cancontinue = false;
            return false;
        }
        IDList.push(this.ID);
    })
    if (!cancontinue) {
        show_message('选中行包含未关联的数据', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "确认取消关联选中的数据?", function (r) {
        if (r) {
            var options = { visit: 'disconnectprojectbiao', IDList: JSON.stringify(IDList), ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('取消关联成功', 'success', function () {
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
