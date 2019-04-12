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
        chkboxType: { "Y": "s", "N": "s" }
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
function GetALLSelectedProjects() {
    var idarry = [];
    var pidarray = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.isParent) {
            idarry.push(node.id);
        }
    });
    return idarry;
}
var NameList = [];
function GetSelectedProjectIDList() {
    var idarry = [];
    var pidarray = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.isParent) {
            idarry.push(node.id);
            NameList.push(node.name);
            if (node.pId && $.inArray(node.pId, pidarray) == -1) {
                pidarray.push(node.pId);
            }
        }
    });
    var temp = [];
    var temparray = [];
    for (var i = 0; i < pidarray.length; i++) {
        temp[pidarray[i]] = true;
    };
    for (var i = 0; i < idarry.length; i++) {
        if (!temp[idarry[i]]) {
            temparray.push(idarry[i]);
        };
    };
    return temparray;
}
function GetSelectedRoomIDList() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (!node.isParent) {
            NameList.push(node.name);
            idarry.push(node.id);
        }
    })
    return idarry;
}
function getSelectedIDList() {
    var ProjectIDList = GetSelectedProjectIDList();
    var RoomIDList = GetSelectedRoomIDList();
    var list = [];
    $.each(ProjectIDList, function (index, ID) {
        list.push(ID);
    })
    $.each(RoomIDList, function (index, ID) {
        list.push(ID);
    })
    return list;
}
function getSelectedNames() {
    var names = '';
    $.each(NameList, function (index, name) {
        if (index > 0) {
            names += ',';
        }
        names += name;
    })
    return names;
}
/*****保存权限*****/
function Save() {
    var IDList = getSelectedIDList();
    var Name = getSelectedNames();
    if (IDList.length == 0) {
        show_message('请选择资源', 'warning');
        return;
    }
    parent.hdRoomID.val(JSON.stringify(IDList));
    parent.tdRoomID.textbox('setValue', Name);
    closeWin();
}
function closeWin() {
    parent.$("#winchoose").window('close');
}