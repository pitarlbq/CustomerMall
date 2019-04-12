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
    var options = { visit: 'gettopprojecttree', CompanyID: CompanyID, MsgID: MsgID, ProjectIDs: parent.hdProjectIDs.val() };
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
    var list = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.id > 1) {
            list.push(node.id);
        }
    });
    return list;
}
function getSelectedNames() {
    var list = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (node.id > 1) {
            list.push(node.name);
        }
    });
    var names = '';
    $.each(list, function (index, item) {
        if (index > 0) {
            names += ",";
        }
        names += item;
    })
    return names;
}
/*****保存权限*****/
function do_save() {
    var idarry = getSelected();
    var names = getSelectedNames();
    if (idarry.length == 0) {
        show_message("请选择资源", 'info');
        return;
    }
    if (MsgID > 0) {
        MaskUtil.mask('body', '提交中');
        var options = { visit: 'savemsgproject', IdList: JSON.stringify(idarry), MsgID: MsgID };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: options,
            url: "../Handler/AuthMgrHandler.ashx",
            success: function (data) {
                MaskUtil.unmask();
                if (data.status == 1) {
                    show_message("保存成功", 'success', function () {
                        try {
                            parent.isupdate = true;
                        } catch (e) {
                        }
                        try {
                            parent.hdProjectIDs.val(JSON.stringify(idarry));
                        } catch (e) {
                        }
                        try {
                            parent.tdProjects.textbox('setValue', names);
                        } catch (e) {
                        }
                        do_close();
                    });
                } else if (data.status == 2) {
                    show_message("请选择资源", 'info');

                } else {
                    show_message("服务器异常", 'info');
                }
            }
        });
    }
    else {
        try {
            parent.isupdate = true;
        } catch (e) {
        }
        try {
            parent.hdProjectIDs.val(JSON.stringify(idarry));
        } catch (e) {
        }
        try {
            parent.tdProjects.textbox('setValue', names);
        } catch (e) {
        }
        do_close();
    }
}
function do_close() {
    try {
        parent.$("#winchoose").window('close');
    } catch (e) {
    }
    try {
        parent.do_close_dialog(function () {
            parent.ConnectMsgRoom_Done();
        });
    } catch (e) {
    }
}