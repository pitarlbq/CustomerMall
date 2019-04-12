var idList = "";
$(document).ready(function () {
    loadProjectTree();
    //init();
});
var IDMark_A = "_a";
var setting = {
    async: {
        enable: true,
        url: getUrl
    },
    view: {
        showIcon: false
    },
    data: {
        simpleData: {
            enable: true
        },
        keep: {
            parent: true
        }
    },
    check: {
        enable: true,
        radioType: "all",
        chkStyle: 'radio'
    },
    callback: {
        beforeExpand: beforeExpand,
        beforeCollapse: beforeCollapse,
        onAsyncSuccess: onAsyncSuccess,
        onAsyncError: onAsyncError,
    }
};
function beforeCollapse(treeId, treeNode) {
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    treeObj.removeChildNodes(treeNode);
}
function beforeExpand(treeId, treeNode) {
    if (!treeNode.isAjaxing) {
        treeNode.times = 1;
        ajaxGetNodes(treeNode, "refresh");
        return true;
    } else {
        alert("zTree 正在下载数据中，请稍后展开节点。。。");
        return false;
    }
}
function onAsyncSuccess(event, treeId, treeNode, msg) {
    if (!msg || msg.length == 0) {
        return;
    }
    var zTree = $.fn.zTree.getZTreeObj("tt");
    treeNode.icon = "";
    zTree.updateNode(treeNode);
    zTree.selectNode(treeNode.children[0]);
}
function onAsyncError(event, treeId, treeNode, XMLHttpRequest, textStatus, errorThrown) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    alert("异步获取数据出现异常。");
    treeNode.icon = "";
}
function ajaxGetNodes(treeNode, reloadType) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    if (reloadType == "refresh") {
        treeNode.icon = "../js/ztree/zTreeStyle/img/loading.gif";
        zTree.updateNode(treeNode);
    }
    zTree.reAsyncChildNodes(treeNode, reloadType, true);
}
function getUrl(treeId, treeNode) {
    var param = "visit=getprojectinfo&ID=" + treeNode.id;
    return "../Handler/ProjectHandler.ashx?" + param;
}
function loadProjectTree() {
    //var keywords = $("#searchbox").searchbox("getValue");
    MaskUtil.mask('#tt');
    var options = { visit: 'getprojectinfo', Keywords: '', ID: ParentID, IncludeMyself: true };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/ProjectHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            $.fn.zTree.init($("#tt"), setting, data);
        }
    });
}
//获取选中的结点
function getSelectedIDList() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    var list = [];
    $.each(nodes, function (index, node) {
        list.push(node.id);
    })
    return list;
}
function getSelectedNames() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    var names = '';
    $.each(nodes, function (index, node) {
        if (index > 0) {
            names += ',';
        }
        names += node.name;
    })
    return names;
}
/*****保存权限*****/
function do_choose() {
    var IDList = getSelectedIDList();
    var Name = getSelectedNames();
    if (IDList.length == 0) {
        show_message('请选择资源', 'warning');
        return;
    }
    parent.isupdate = true;
    parent.hdRoomID.val(JSON.stringify(IDList));
    parent.tdRoomID.textbox('setValue', Name);
    do_close();
}
function do_close() {
    parent.do_close_dialog();
}