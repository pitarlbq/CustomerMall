var IDMark_A, setting;
$(function () {
    tree_setting();
    doSearch();
});
function tree_setting() {
    IDMark_A = "_a";
    setting = {
        async: {
            enable: true,
        },
        view: {
            showIcon: false
        },
        data: {
            simpleData: {
                enable: true
            }
        },
        check: {
            enable: true
        }
    };
}
function doSearch() {
    MaskUtil.mask('#tt');
    var options = { visit: 'getsysmenus' };
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
function do_save() {
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getSelectedNodes();
    if (nodes.length == 0) {
        show_message('请选择菜单', 'info');
        return;
    }
    var node = nodes[0];
    if (ID == node.ID) {
        show_message('不能选择与自己相同的菜单', 'info');
        return;
    }
    if (node.ID == 0) {
        parent.$('#hdGroupName').val(node.id);
    }
    else {
        parent.$('#hdGroupName').val("");
    }
    parent.$('#hdParentID').val(node.ID);
    parent.$('#tdParentName').textbox('setValue', node.name);
    setTimeout(function () {
        parent.$('#winadd').window('close');
    }, 500);
}
