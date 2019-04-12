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
        { field: 'AreaName', title: '区域', width: 100 },
        { field: 'BuildingName', title: '楼盘', width: 100 },
        { field: 'ContactName', title: '申请人姓名', width: 100 },
        { field: 'ContactPhone', title: '申请人电话', width: 100 },
        { field: 'RentTypeDesc', title: '委托类型', width: 150 },
        { field: 'BuildingPropertyDesc', title: '委托物业形态', width: 150 },
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
        "visit": "getrentrequestgrid",
        "keywords": keywords,
        "AreaIDList": JSON.stringify(AreaIDList),
        "BuildingIDList": JSON.stringify(BuildingIDList)
    });
}
function viewRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个申请", "info");
        return;
    }
    var iframe = "../Wechat/EditRentRequest.aspx?ID=" + rows[0].ID;
    do_open_dialog('查看详情', iframe);
}
function viewWechatPage() {
    var pageurl = '/WeiXin/RentRequestRedirect.aspx';
    var iframe = "../Wechat/ViewQrCodeByURL.aspx?pageurl=" + pageurl;
    do_open_dialog('微信二维码', iframe);
}
