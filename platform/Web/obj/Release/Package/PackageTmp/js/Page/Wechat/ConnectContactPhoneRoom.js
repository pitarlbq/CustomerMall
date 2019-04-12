var idList = "";
$(document).ready(function () {
    loadProjectTree();
    //init();
});
var IDMark_A = "_a";
var setting = {
    view: {
        showIcon: false
    },
    data: {
        simpleData: {
            enable: true
        }
    },
    check: {
        enable: true,
        chkboxType: { "Y": "s", "N": "s" }
    }
};

function loadProjectTree() {
    var options = { visit: 'gettopprojecttreebywechatcontractid', CompanyID: CompanyID, ContactID: ContactID, ProjectIDs: parent.hdProjectIDs.val() };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/AuthMgrHandler.ashx',
        data: options,
        success: function (data) {
            $.fn.zTree.init($("#tt"), setting, data);
        }
    });
}
//获取选中的结点
function getSelected() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        idarry.push(node.id);
    });
    return idarry;
}
/*****保存权限*****/
function do_save() {
    var idarry = getSelected();
    if (idarry.length == 0) {
        show_message("请选择资源", 'info');
        return;
    }
    if (ContactID > 0) {
        MaskUtil.mask('body', '提交中');
        var options = { visit: 'savewechatcontactproject', IdList: JSON.stringify(idarry), ContactID: ContactID };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: options,
            url: "../Handler/AuthMgrHandler.ashx",
            success: function (data) {
                MaskUtil.unmask();
                if (data.status == 1) {
                    show_message("保存成功", 'success', function () {
                        parent.isupdate = true;
                        parent.hdProjectIDs.val(JSON.stringify(idarry));
                        do_close();
                    });
                } else if (data.status == 2) {
                    show_message("请选择资源", 'info');

                } else {
                    alert("服务器异常");
                }
            }
        });
    }
    else {
        show_message("保存成功", 'success', function () {
            parent.isupdate = true;
            parent.hdProjectIDs.val(JSON.stringify(idarry));
            do_close();
        });
    }
}
function do_close() {
    parent.do_close_dialog(function () {
        if (parent.isupdate) {
            parent.getwechatprojects();
        }
    });
}