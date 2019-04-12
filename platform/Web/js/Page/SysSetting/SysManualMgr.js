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
    MaskUtil.mask('#tt');
    var options = { visit: 'getsysmanualtree', Keywords: keywords };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/SysSettingHandler.ashx',
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
function addTree() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/EditSysManualyCategory.aspx' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '新增模块',
        width: ($(parent.window).width() - 400),
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
            doSearchTree();
        }
    });
}
function editTree() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message("请选择一个模块", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/EditSysManualyCategory.aspx?CategoryID=" + TreeIDList[0] + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '修改模块',
        width: ($(parent.window).width() - 400),
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
            doSearchTree();
        }
    });
}
function removeTree() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message("请选择一个模块", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的模块?", function (r) {
        if (r) {
            var options = { visit: 'removesysmanualcategory', IDList: JSON.stringify(TreeIDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
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
        { field: 'Title', title: '标题', width: 150 },
        { field: 'CategoryName', title: '模块', width: 150 },
        { field: 'SortBy', title: '排序', width: 150 },
        { field: 'StatusDesc', title: '发布状态', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var TreeIDList = [];
    try {
        var TreeIDList = GetSelectedIDList();
    } catch (e) {

    }
    if (TreeIDList.length == 0) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getsysmanualgrid",
        "keywords": keywords,
        "TreeIDList": JSON.stringify(TreeIDList)
    });
}
function addRow() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message("请选择一个模块", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/EditSysManual.aspx?CategoryID=" + TreeIDList[0] + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '新增内容',
        width: ($(parent.window).width() - 400),
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
            $('#tt_table').datagrid('reload')
        }
    });
}
function editRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个调查问卷问题", "info");
        return;
    }
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/EditSysManual.aspx?ManualID=" + rows[0].ID + "' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '修改内容',
        width: ($(parent.window).width() - 400),
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
            $('#tt_table').datagrid('reload')
        }
    });
}
function removeRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个调查问卷问题", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的问卷?", function (r) {
        if (r) {
            var options = { visit: 'removesysmanual', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
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
function viewResult() {
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../Manual/ViewSysManual.aspx' style='width:100%;height:" + ($(parent.window).height() - 40) + "px'></iframe>";
    parent.$("<div id='winadd'></div>").appendTo("body").window({
        title: '查看',
        width: ($(parent.window).width() - 200),
        height: $(parent.window).height(),
        top: 0,
        left: 100,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            parent.$("#winadd").remove();
        }
    })
}
