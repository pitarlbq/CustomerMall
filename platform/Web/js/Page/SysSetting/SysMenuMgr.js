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
        },
        callback: {
            onClick: onClick,
        }
    };
}
function onClick(event, treeId, treeNode, clickFlag) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    if (treeNode.ID == 0) {
        return;
    }
    get_menu(treeNode.ID);
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
function get_menu(ID) {
    MaskUtil.mask('.info');
    var options = { visit: 'getmenubyid', ID: ID };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/SysSettingHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                set_data(data.menu);
            }
        }
    });
}
function set_data(data) {
    $('#hdID').val(data.ID);
    $('#hdGroupName').val(data.GroupName);
    $('#tdName').textbox('setValue', data.Name);
    $('#tdParentName').textbox('setValue', data.ParentName);
    $('#hdParentID').val(data.ParentID);
    $('#tdMenuType').combobox('setValue', data.MenuType);
    $('#tdUrl').textbox('setValue', data.URL);
    if (data.IconPath != '') {
        $('#existicon').show();
        var html = '<img src="' + data.IconPath + '" style="width:100px;" />&nbsp;&nbsp;<a href="javascript:delete_img(' + data.ID + ',1)">删除</a>';
        $('#existicon').html(html);
    }
    else {
        $('#existicon').hide();
    }
    $('#tdSortOrder').textbox('setValue', data.SortOrder);
    $('#tdUsingImgURL').combobox('setValue', data.UsingImgURL);
    if (data.ImgUrl != '') {
        $('#existimage').show();
        var html = '<img src="' + data.ImgUrl + '" style="width:100px;" />&nbsp;&nbsp;<a href="javascript:delete_img(' + data.ID + ',2)">删除</a>';
        $('#existimage').html(html);
    }
    else {
        $('#existimage').hide();
    }
    $('#tdDescription').textbox('setValue', data.Description);
    $('#label_ModuleCode').text(data.ModuleCode);
}
function do_save() {
    var isValid = $("#ff").form('enableValidation').form('validate');
    if (!isValid) {
        return;
    }
    var ID = $('#hdID').val();
    var GroupName = $('#hdGroupName').val();
    var Name = $('#tdName').textbox('getValue');
    var ParentID = $('#hdParentID').val();
    var MenuType = $('#tdMenuType').combobox('getValue');
    var URL = $('#tdUrl').textbox('getValue');
    var SortOrder = $('#tdSortOrder').textbox('getValue');
    var UsingImgURL = $('#tdUsingImgURL').combobox('getValue');
    var Description = $('#tdDescription').textbox('getValue');
    MaskUtil.mask('body', '提交中');
    $('#ff').form('submit', {
        url: '../Handler/SysSettingHandler.ashx',
        onSubmit: function (options) {
            options.visit = "savesysmenu";
            options.ID = ID;
            options.Name = Name;
            options.ParentID = ParentID;
            options.MenuType = MenuType;
            options.URL = URL;
            options.SortOrder = SortOrder;
            options.UsingImgURL = UsingImgURL;
            options.Description = Description;
            options.GroupName = GroupName;
        },
        success: function (data) {
            MaskUtil.unmask();
            var message = eval("(" + data + ")");
            if (message.status) {
                $('#hdID').val(message.ID);
                show_message('保存成功', 'success');
                //doSearch();
                get_menu(message.ID);
            }
            else {
                show_message('系统错误', 'error');
            }
        }
    });
}
function delete_img(ID, type) {
    var options = { visit: 'deletesysmenuimg', ID: ID, type: type };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/SysSettingHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            if (data.status) {
                get_menu(ID);
            }
        }
    });
}
function do_choose() {
    var ID = $('#hdID').val();;
    var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/ChooseParentMenu.aspx?ID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
    $("<div id='winadd'></div>").appendTo("body").window({
        title: '选择上级菜单',
        width: ($(window).width() - 400),
        height: $(window).height(),
        top: 0,
        left: 200,
        modal: true,
        minimizable: false,
        maximizable: false,
        collapsible: false,
        content: iframe,
        onClose: function () {
            $("#winadd").remove();
        }
    });
}
function reset_data(ParentName, GroupName, ParentID) {
    $('#hdID').val("0");
    $('#hdGroupName').val(GroupName);
    $('#tdName').textbox('setValue', '');
    $('#tdParentName').textbox('setValue', ParentName);
    $('#hdParentID').val(ParentID);
    $('#tdMenuType').combobox('setValue', 1);
    $('#tdUrl').textbox('setValue', '');
    $('#existicon').hide();
    $('#tdSortOrder').textbox('setValue', '');
    $('#tdUsingImgURL').combobox('setValue', 0);
    $('#existimage').hide();
    $('#tdDescription').textbox('setValue', '');
    $('#tdIconPath').filebox('setValue', '');
    $('#tdImgUrl').filebox('setValue', '');
    $('#label_ModuleCode').text('');
}
function do_add() {
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getSelectedNodes();
    if (nodes.length == 0) {
        show_message('请选择菜单', 'info');
        return;
    }
    var node = nodes[0];
    if (node.ID == 0) {
        reset_data(node.name, node.id, 0);
        return;
    }
    reset_data(node.name, "", node.ID);
}
function do_remove() {
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getSelectedNodes();
    var ids = [];
    $.each(nodes, function (index, node) {
        if (node.ID == 0) {
            return true;
        }
        ids.push(node.ID);
    })
    if (ids.length == 0) {
        show_message('请选择菜单', 'info');
        return;
    }
    top.$.messager.confirm('提示', '确认删除?', function (r) {
        if (r) {
            var options = { visit: 'deletesysmenus', ids: JSON.stringify(ids) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('删除成功', 'success');
                        doSearch();
                        reset_data("", "", 0);
                        return;
                    }
                    show_message('系统异常', 'info');
                }
            });
        }
    })
}
