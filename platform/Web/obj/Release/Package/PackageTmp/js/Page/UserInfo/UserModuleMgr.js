var idList = "", CurrentTab = 1;//0-用户 1-角色;
$(function () {
    get_user_role_tree();
    setTimeout(function () {
        get_user_tree();
    }, 500);
    setTimeout(function () {
        loadoperationTree();
    }, 1000);
    $('#CommTab').tabs({
        onSelect: function (title, index) {
            if (title == '用户角色') {
                CurrentTab = 1;
            } else {
                CurrentTab = 0;
            }
        }
    });
})
function get_user_tree() {
    //加载用户列表
    $('#userTree').tree({
        url: "../Handler/AuthMgrHandler.ashx?visit=loadusertree",
        lines: true,
        checkbox: false,
        fit: true,
        fitColumns: false,
        onClick: onClickUser,
        animate: true,
        cascadeCheck: true,
        onLoadSuccess: function (node, data) {
            if (data.status == false) {
                show_message("该用户权限不足", 'info');
            }
            init();
        }
    });
};
function get_user_role_tree() {
    //加载用户角色列表
    $('#userRoleTree').tree({
        url: "../Handler/AuthMgrHandler.ashx?visit=loaduserroletree",
        lines: true,
        checkbox: false,
        fit: true,
        fitColumns: false,
        onClick: onClickRole,
        animate: true,
        cascadeCheck: true,
        onLoadSuccess: function (node, data) {
            if (data.status == false) {
                show_message("该用户权限不足", 'info');
            }
            init();
        }
    });
};
function show(checkid) {
    var s = '#check_' + checkid;
    /*选子节点*/
    var nodes = $("#operationTree").treegrid("getChildren", checkid);
    for (i = 0; i < nodes.length; i++) {
        $(('#check_' + nodes[i].id))[0].checked = $(s)[0].checked;

    }
    //选上级节点
    if (!$(s)[0].checked) {
        var parent_node = $("#operationTree").treegrid("getParent", checkid);
        var flag = true;
        var sons = [];
        if (parent_node && parent_node.sondata) {
            sons = parent_node.sondata.split(',');
        }
        for (j = 0; j < sons.length; j++) {
            if (!$(('#check_' + sons[j]))[0].checked) {
                flag = true;
                break;
            }
        }
        if (flag) {
            if (parent_node) {
                $(('#check_' + parent_node.id))[0].checked = true;
            }
        }
        while (flag) {
            if (parent_node) {
                parent_node = $("#operationTree").treegrid("getParent", parent_node.id);
                if (parent_node && parent_node.sondata) {
                    sons = parent_node.sondata.split(',');
                    for (j = 0; j < sons.length; j++) {
                        if (!$(('#check_' + sons[j]))[0].checked) {
                            flag = true;
                            break;
                        }
                    }
                    if (flag) {
                        $(('#check_' + parent_node.id))[0].checked = true;
                    }
                } else {
                    flag = false;
                }
            } else {
                flag = false;
            }
        }
    }
}
//加载权限列表
function loadoperationTree() {
    var url = "../Handler/AuthMgrHandler.ashx?visit=operationTree";
    $('#operationTree').treegrid({
        url: url,
        rownumbers: false,
        idField: 'id',
        treeField: 'name',
        onClickRow: onOperationClick,
        onLoadSuccess: function (node, data) {
            init();
        }
    });
}
function formatcheckbox(val, row) {
    return "<input type='checkbox' name='procheck' onclick=show('" + row.id + "') id='check_" + row.id + "' " + (row.checked ? 'checked' : '') + "/>" + row.name;
}
function init() {
    //去掉结点前面的文件及文件夹小图标
    $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
    $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
}
//获取选中的结点
function getSelected() {
    idList = "";
    $("input:checked").each(function () {
        var id = $(this).attr("id");

        if (id.indexOf('check_type') == -1 && id.indexOf("check_") > -1)
            idList += id.replace("check_", '') + ',';

    })
}
//设置选中节点
function setSelected(Id) {
    var CheckId = "check_" + Id;
    $("#" + CheckId).prop("checked", 'true');
}
/*****保存权限*****/
function do_save() {
    var UserID = 0;
    var RoleID = 0;
    if (CurrentTab == 0) {
        var node = $('#userTree').tree('getSelected');
        if (node == null || node == undefined || node == '') {
            show_message("请选择用户", 'info');
            return;
        }
        UserID = node.id;
        if (UserID == 0) {
            show_message("请选择用户", 'info');
            return;
        }
    } else {
        var node = $('#userRoleTree').tree('getSelected');
        if (node == null || node == undefined || node == '') {
            show_message("请选择角色", 'info');
            return;
        }
        RoleID = node.id;
        if (RoleID == 0) {
            show_message("请选择角色", 'info');
            return;
        }
    }
    do_save_operation(UserID, RoleID);
}
function do_save_operation(UserID, RoleID) {
    getSelected();
    MaskUtil.mask('body', '提交中');
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx",
        data: { visit: "saveoperation", IdList: idList, UserID: UserID, RoleID: RoleID },
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                show_message("保存成功", 'success');
            } else if (data.error == 0) {
                show_message(data.error, 'info');
            } else {
                show_message("保存失败", 'error');
            }
        }
    });
}
//加载权限
function loadOperation(roleId, UserID) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx",
        data: { visit: 'loadoperation', RoleId: roleId, UserID: UserID },
        success: function (data) {
            $("input[name='procheck']").prop("checked", false);
            for (var i = 0; i < data.length; i++) {
                setSelected(data[i].ModuleId);
            }
        }
    });
}
/********单击用户操作***********/
function onClickRole() {
    var nodes = $('#userRoleTree').tree('getSelected');
    var Id = nodes.id;
    loadOperation(Id, 0);
}
function onClickUser() {
    var nodes = $('#userTree').tree('getSelected');
    var Id = nodes.id;
    loadOperation(0, Id);
}
function onOperationClick() {

}