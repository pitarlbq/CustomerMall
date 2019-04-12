var tt_CanLoad = false, isUpdate = false;
var IDMark_A = "_a";
$(function () {
    doSearchTree();
});
var setting = {
    async: {
        enable: true,
    },
    view: {
        dblClickExpand: false,
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
function doSearchTree() {
    var keywords = $("#searchbox").searchbox("getValue");
    MaskUtil.mask('#tt');
    var options = { visit: 'getrentareatree', Keywords: keywords };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/WechatHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            $.fn.zTree.init($("#tt"), setting, data);
            loadtt();
        }
    });
}
function reset() {
    $("#searchbox").searchbox("setValue", "");
    doSearchTree();
}
function GetSelectedIDList(type) {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (Number(node.ID) > 0) {
            if (type == node.type) {
                idarry.push(node.ID);
            }
        }
    })
    return idarry;
}
function addTree() {
    var AreaIDList = GetSelectedIDList('area');
    var type, AreaID = 0, title;
    if (AreaIDList.length > 0) {
        type = 'building';
        AreaID = AreaIDList[0];
        title = '新增楼盘';
    }
    else {
        type = 'area';
        AreaID = 0;
        title = '新增区域';
    }
    var iframe = "../Wechat/EditRentArea.aspx?AreaID=" + AreaID + "&type=" + type;
    do_open_dialog('新增区域', iframe);
}
function editTree() {
    var BuildingIDList = GetSelectedIDList('building');
    var AreaIDList = GetSelectedIDList('area');
    if (AreaIDList.length == 0 && BuildingIDList.length == 0) {
        show_message("请选择一个区域或者楼盘", "info");
        return;
    }
    var type, ID = 0, title;
    if (BuildingIDList.length == 0) {
        type = 'area';
        ID = AreaIDList[0];
        title = '修改区域';
    }
    if (AreaIDList.length == 0) {
        type = 'building';
        ID = BuildingIDList[0];
        title = '修改楼盘';
    }
    var iframe = "../Wechat/EditRentArea.aspx?ID=" + ID + "&type=" + type;
    do_open_dialog('新增房间', iframe);
}
function removeTree() {
    var AreaIDList = GetSelectedIDList('area');
    var BuildingIDList = GetSelectedIDList('building');
    if (AreaIDList.length == 0 && BuildingIDList.length == 0) {
        show_message("请选择一个区域或者楼盘", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的区域?", function (r) {
        if (r) {
            var options = { visit: 'removerentarea', AreaIDList: JSON.stringify(AreaIDList), BuildingIDList: JSON.stringify(BuildingIDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            doSearchTree();
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function loadtt() {
    $('#tt_table').datagrid({
        url: '../Handler/WechatHandler.ashx',
        loadMsg: '正在加载',
        border: true,
        remoteSort: false,
        pagination: true,
        rownumbers: true,
        fit: true,
        fitColumns: true,
        singleSelect: false,
        selectOnCheck: true,
        checkOnSelect: true,
        striped: true,
        pageSize: global_variable.pageSize,
        pageList: global_variable.pageList,
        onBeforeLoad: function (data) {
            if (!tt_CanLoad) {
                $('#tt_table').datagrid("loadData", {
                    total: 0,
                    rows: []
                });
            }
            return tt_CanLoad;
        },
        onLoadError: function (data) {
            //alert("有错");
            $('#tt_table').datagrid("loadData", {
                total: 0,
                rows: []
            });
        },
        columns: [[
        { field: 'ck', checkbox: true },
        { field: 'HomeName', title: '房间名称', width: 100 },
        { field: 'HomeLocation', title: '具体地址', width: 100 },
        { field: 'PhoneNumber', title: '联系电话', width: 100 },
        { field: 'HomeTypeDesc', title: '户型', width: 150 },
        { field: 'AreaName', title: '所属区域', width: 150 },
        { field: 'BuildingName', title: '所属楼盘', width: 150 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var AreaIDList = [];
    var BuildingIDList = [];
    try {
        AreaIDList = GetSelectedIDList('area');
        BuildingIDList = GetSelectedIDList('building');
    } catch (e) {

    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getrenthomegrid",
        "keywords": keywords,
        "AreaIDList": JSON.stringify(AreaIDList),
        "BuildingIDList": JSON.stringify(BuildingIDList)
    });
}
function addRow() {
    var iframe = "../Wechat/EditRentHome.aspx";
    do_open_dialog('新增房间', iframe);
}
function editRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个房间", "info");
        return;
    }
    var iframe = "../Wechat/EditRentHome.aspx?HomeID=" + rows[0].ID;
    do_open_dialog('修改房间', iframe);
}
function removeRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个房间", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的房间?", function (r) {
        if (r) {
            var options = { visit: 'removerenthome', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            $('#tt_table').datagrid('reload')
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    })
}
function viewWechatPage() {
    var pageurl = '/WeiXin/HomeRentListRedirect.aspx';
    var iframe = "../Wechat/ViewQrCodeByURL.aspx?pageurl=" + pageurl;
    do_open_dialog('微信二维码', iframe);
}
