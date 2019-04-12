var idList = "";
$(document).ready(function () {
    //加载用户列表
    doSearchUser();
    //加载权限列表
    loadoperationTree();
    //init();
});
function doSearchUser() {
    var keywords = $('#tdkeywords').searchbox('getValue');
    $('#userTree').tree({
        url: "../Handler/AuthMgrHandler.ashx?visit=companytree&keywords=" + keywords,
        lines: true,
        checkbox: false,
        fit: true,
        fitColumns: false,
        onClick: onClick,
        animate: true,
        cascadeCheck: true,
        onLoadSuccess: function (node, data) {
            if (data.status == false) {
                show_message("该用户权限不足", 'info');
            }
            init();
        }
    });
}
function show(checkid) {
    var s = '#check_' + checkid;
    //alert( $(s).attr("id"));
    // alert($(s)[0].checked);
    /*选子节点*/
    var nodes = $("#operationTree").treegrid("getChildren", checkid);
    for (i = 0; i < nodes.length; i++) {
        $(('#check_' + nodes[i].id))[0].checked = $(s)[0].checked;

    }
    //选上级节点
    if (!$(s)[0].checked) {
        var parent = $("#operationTree").treegrid("getParent", checkid);
        //$(('#check_' + parent.id))[0].checked = false;
        while (parent) {
            parent = $("#operationTree").treegrid("getParent", parent.id);
            //$(('#check_' + parent.id))[0].checked = false;
        }
    } else {
        var parent = $("#operationTree").treegrid("getParent", checkid);
        var flag = true;
        var sons = parent.sondata.split(',');
        for (j = 0; j < sons.length; j++) {
            if (!$(('#check_' + sons[j]))[0].checked) {
                flag = true;
                break;
            }
        }
        if (flag)
            $(('#check_' + parent.id))[0].checked = true;
        while (flag) {
            parent = $("#operationTree").treegrid("getParent", parent.id);
            if (parent) {
                sons = parent.sondata.split(',');
                for (j = 0; j < sons.length; j++) {
                    if (!$(('#check_' + sons[j]))[0].checked) {
                        flag = true;
                        break;
                    }
                }
            }
            if (flag)
                $(('#check_' + parent.id))[0].checked = true;
        }
    }
}
//加载权限列表
function loadoperationTree() {
    var url = "../Handler/AuthMgrHandler.ashx?visit=operationcompanytree";
    $('#operationTree').treegrid({
        url: url,
        rownumbers: false,
        idField: 'id',
        treeField: 'name',
        onClickRow: onOperationClick
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
function Save() {
    var nodes = $('#userTree').tree('getSelected');
    if (nodes == null || nodes == undefined || nodes == '') {
        show_message("请选择公司", 'info');
        return;
    }
    var Id = nodes.id;
    if (Id == 0) {
        show_message("请选择公司", 'info');
        return;
    }
    getSelected();

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx?visit=savecompanymodule&IdList=" + idList + "&CompanyID=" + Id,
        success: function (data) {
            if (data.status == 2) {
                show_message("保存成功", 'success');
            } else if (data.status == 0) {
                show_message("请选择公司", 'info');
            } else if (data.status == 1) {
                show_message("请选择权限", 'info');
            } else {
                show_message("保存失败", 'error');
            }
        }
    });
}
//加载权限
function loadOperation(CompanyID) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: "../Handler/AuthMgrHandler.ashx?visit=loadcompanyoperation&CompanyID=" + CompanyID,
        success: function (data) {
            $("input[name='procheck']").prop("checked", false);
            for (var i = 0; i < data.length; i++) {
                setSelected(data[i].ModuleId);
            }
        }
    });
}
/********单击用户操作***********/
function onClick() {
    var nodes = $('#userTree').tree('getSelected');
    var Id = nodes.id;
    loadOperation(Id);
}
function onOperationClick() {

}