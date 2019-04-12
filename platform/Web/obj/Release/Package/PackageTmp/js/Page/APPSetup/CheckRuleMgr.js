var tt_CanLoad = false, isUpdate = false;
var IDMark_A = "_a";
$(function () {
    doSearchTree();
    setTimeout(function () {
        loadtt();
    }, 500);
});
var setting = {
    async: {
        enable: true,
    },
    view: {
        dblClickExpand: false,
        showIcon: false
    },
    data: {
        simpleData: {
            enable: true
        }
    },
    check: {
        enable: true,
        chkStyle: "radio",
        radioType: "all"
    },
    callback: {
        onClick: onClick,
    }
};
function onClick(event, treeId, treeNode, clickFlag) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    zTree.expandNode(treeNode, null, false, true, true, true);
    var treeObj = $.fn.zTree.getZTreeObj("tree");
    zTree.checkNode(treeNode, true, false);
    setTimeout(function () {
        SearchTT();
    }, 1000);
    //GetBalance();
}
function doSearchTree() {
    var keywords = $("#searchbox").searchbox("getValue");
    var type = $("#tdCategoryType").combobox("getValue");
    MaskUtil.mask('#tt');
    var options = { visit: 'getcheckcategorytree', Keywords: keywords, type: type };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/MallHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            $.fn.zTree.init($("#tt"), setting, data);
        }
    });
}
function reset() {
    $("#searchbox").searchbox("setValue", "");
    doSearchTree();
}
function GetSelectedIDList() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (Number(node.ID) > 0) {
            idarry.push(node.ID);
        }
    })
    return idarry;
}
function open_container_dialog(title, url) {
    var height = $(window).height();
    $('#main_container_form').hide();
    $('#dialog_container_form').show();
    $('#dialog_container_frame').attr("src", url);
    $('#dialog_container_frame').css('height', height + 'px');
    $('#dialog_container_frame').css('top', '0px');
    $('#dialog_container_frame').css('bottom', '0px');
}
function close_container_dialog(title, url) {
    var height = $(window).height();
    $('#main_container_form').show();
    $('#dialog_container_form').hide();
    $('#dialog_container_frame').attr("src", '');
}
function addTree() {
    var iframe = "../APPSetup/CheckCategoryEdit.aspx";
    open_container_dialog('新增考核项目', iframe);
}
function editTree() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message('请选择一个考核项目', 'warning');
        return;
    }
    var iframe = "../APPSetup/CheckCategoryEdit.aspx?ID=" + TreeIDList[0];
    open_container_dialog('修改考核项目', iframe);
}
function removeTree() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message('请选择一个考核项目', 'warning');
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的考核项目?", function (r) {
        if (r) {
            var options = { visit: 'removecheckcategory', IDList: JSON.stringify(TreeIDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            doSearchTree();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
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
        { field: 'CategoryTypeDesc', title: '项目类别', width: 100 },
        { field: 'CategoryName', title: '项目名称', width: 100 },
        { field: 'CheckName', title: '标准名称', width: 100 },
        { field: 'CheckSummary', title: '考核说明', width: 150 },
        { field: 'PointRange', title: '分值范围', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var CategoryType = $("#tdCategoryType").searchbox("getValue");
    var TreeIDList = [];
    try {
        var TreeIDList = GetSelectedIDList();
    } catch (e) {

    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getmallcheckrulegrid",
        "keywords": keywords,
        "TreeIDList": JSON.stringify(TreeIDList),
        "CategoryType": CategoryType
    });
}
function addRow() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message('请选择一个考核项目', 'warning');
        return;
    }
    var iframe = "../APPSetup/CheckRuleEdit.aspx?CategoryID=" + TreeIDList[0];
    open_container_dialog('新增考核标准', iframe);
}
function editRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择一个考核标准', 'warning');
        return;
    }
    var iframe = "../APPSetup/CheckRuleEdit.aspx?RuleID=" + rows[0].ID;
    open_container_dialog('修改考核标准', iframe);
}
function removeRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message('请选择一个考核标准', 'warning');
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的考核标准?", function (r) {
        if (r) {
            var options = { visit: 'removemallcheckrules', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $('#tt_table').datagrid('reload')
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
