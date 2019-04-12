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
    var options = { visit: 'getcompanytree', MsgID: MsgID };
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
function getSelectedName() {
    var names = ''
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (index > 0) {
            names += ",";
        }
        names += node.name;
    });
    return names;
}
/*****保存权限*****/
function Save() {
    var idarry = getSelected();
    if (idarry.length == 0) {
        show_message("请选择公司", 'info');
        return;
    }
    var names = getSelectedName();
    if (MsgID > 0) {
        MaskUtil.mask('body', '提交中');
        var options = { visit: 'savesysmsgcompany', IdList: JSON.stringify(idarry), MsgID: MsgID };
        $.ajax({
            type: 'POST',
            dataType: 'json',
            data: options,
            url: "../Handler/AuthMgrHandler.ashx",
            success: function (data) {
                MaskUtil.unmask();
                if (data.status) {
                    show_message("保存成功", 'success', function () {
                        parent.isupdate = true;
                        parent.hdCompanys.val(JSON.stringify(idarry));
                        parent.tdCompanyNames.textbox('setValue', names);
                        closeWin();
                    });
                    return;
                }
                if (data.error) {
                    show_message(data.error, 'info');
                    return;
                }
                show_message('服务器异常', 'error');
            }
        });
    }
    else {
        show_message("保存成功", 'success', function () {
            parent.isupdate = true;
            parent.hdCompanys.val(JSON.stringify(idarry));
            parent.tdCompanyNames.textbox('setValue', names);
            closeWin();
        });
    }
}
function closeWin() {
    parent.$("#winchoose").window('close');
}