$(function () {
    doSearch();
});
function GetSelected() {
    var idarry = [];
    //var r = document.getElementsByTagName('input[type=radio]');
    var r = $("input[type=radio]");
    for (var i = 0; i < r.length; i++) {
        if (r[i].checked) {
            var checkid = $(r[i]).attr("id");
            idarry.push(Number(checkid));
        }
    }
    return idarry;
}
function GetSelectedByType(type) {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    //var r = document.getElementsByTagName('input[type=radio]');
    var r = $("input[type=radio]");
    for (var i = 0; i < r.length; i++) {
        if (r[i].checked) {
            var checkid = $(r[i]).attr("id");
            var nodes = treeObj.getNodesByParam("id", checkid, null);
            $.each(nodes, function (index, node) {
                if (node.type == type && !node.isParent) {
                    idarry.push(Number(node.ID));
                }
            })
        }
    }
    return idarry;
}
function GetSelectedTitleByType(type, pId) {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getSelectedNodes();
    $.each(nodes, function (index, node) {
        if (node.type == type && Number(node.pId) == pId) {
            idarry.push(Number(node.ID));
        }
    });
    return idarry;
}
var IDMark_A = "_a";
var setting = {
    async: {
        enable: true,
        url: getUrl
    },
    view: {
        addDiyDom: addDiyDom,
        dblClickExpand: true,
        selectedMulti: true
    },
    data: {
        simpleData: {
            enable: true
        }
    },
    check: {
        enable: true
    },
    callback: {
        onClick: onClick

    }
};
function getUrl(treeId, treeNode) {

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

function onClick(event, treeId, treeNode, clickFlag) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    //zTree.expandNode(treeNode, null, false, true, true, true);
    var btn = $("#" + treeNode.id);
    btn.click();
}
function addDiyDom(treeId, treeNode) {
    var aObj = $("#" + treeNode.tId + IDMark_A);
    if (!treeNode.isParent) {
        var editStr = "<input type='radio' name='checkbox_" + treeNode.pId + "' class='checkboxBtn' id='" + treeNode.id + "' onfocus='this.blur();'></input>";
        aObj.before(editStr);
        var btn = $("#" + treeNode.id);
        if (btn) {
            btn.bind("click", function () {

            });
        }
    }
}
function doSearch() {
    var keywords = $("#searchbox").searchbox("getValue");
    var options = { visit: 'loadtree', Keywords: keywords };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/CommHandler.ashx',
        data: options,
        success: function (data) {
            $.fn.zTree.init($("#tt"), setting, data);
        }
    });
}