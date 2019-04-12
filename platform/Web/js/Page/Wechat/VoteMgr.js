var tt_CanLoad = false, isUpdate = false;
var IDMark_A = "_a";
$(function () {
    doSearchTree();
    setTimeout(function () {
        loadtt();
    }, 500);
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
        chkStyle: "radio",
        radioType: "all"
    },
    callback: {
        onClick: onClick,
    }
};
function onClick(event, treeId, treeNode, clickFlag) {
    var zTree = $.fn.zTree.getZTreeObj("tt");
    zTree.expandNode(treeNode, null, false, true, true, true);
    var treeObj = $.fn.zTree.getZTreeObj("tree");
    zTree.checkNode(treeNode, true, false);
    setTimeout(function () {
        SearchTT();
    }, 1000);
    //GetBalance();
}
function doSearchTree() {
    var keywords = $("#searchbox").searchbox("getValue");
    MaskUtil.mask('#tt');
    var options = { visit: 'getsurveytree', Keywords: keywords, type: type, SurveyType: 2 };
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '../Handler/WechatHandler.ashx',
        data: options,
        success: function (data) {
            MaskUtil.unmask();
            $.fn.zTree.init($("#tt"), setting, data);
        }
    });
}
function reset() {
    $("#searchbox").searchbox("setValue", "");
    doSearchTree();
}
function GetSelectedIDList() {
    var idarry = [];
    var treeObj = $.fn.zTree.getZTreeObj("tt");
    var nodes = treeObj.getCheckedNodes(true);
    $.each(nodes, function (index, node) {
        if (Number(node.ID) > 0) {
            idarry.push(node.ID);
        }
    })
    return idarry;
}
function addTree() {
    var iframe = "../Wechat/EditSurvey.aspx?type=" + type + "&SurveyType=2";
    do_open_dialog('新增社区投票', iframe);
}
function editTree() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message("请选择一个社区投票", "info");
        return;
    }
    var iframe = "../Wechat/EditSurvey.aspx?SurveyID=" + TreeIDList[0] + "&type=" + type + "&SurveyType=2";
    do_open_dialog('修改社区投票', iframe);
}
function removeTree() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message("请选择一个社区投票", "info");
        return;
    }
    top.$.messager.confirm("提示", "是否删除选中的社区投票?", function (r) {
        if (r) {
            var options = { visit: 'removesurveys', IDList: JSON.stringify(TreeIDList) };
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
        { field: 'QuestionContent', title: '标题', width: 100 },
        { field: 'QuestionSummary', title: '简介', width: 400 },
        { field: 'SortOrder', title: '排序', width: 100 },
        ]],
        toolbar: '#tt_mm'
    });
    SearchTT();
}
function SearchTT() {
    var keywords = $("#tdKeyword").searchbox("getValue");
    var TreeIDList = [];
    try {
        var TreeIDList = GetSelectedIDList();
    } catch (e) {

    }
    if (TreeIDList.length == 0) {
        return;
    }
    tt_CanLoad = true;
    $("#tt_table").datagrid("load", {
        "visit": "getsurveyquestiongrid",
        "keywords": keywords,
        "TreeIDList": JSON.stringify(TreeIDList)
    });
}
function addRow() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message("请选择一个调查问卷", "info");
        return;
    }
    var iframe = "../Wechat/EditVoteItem.aspx?SurveyID=" + TreeIDList[0];
    do_open_dialog('新增候选人', iframe);
}
function editRow() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个调查问卷问题", "info");
        return;
    }
    var iframe = "../Wechat/EditVoteItem.aspx?QuestionID=" + rows[0].ID;
    do_open_dialog('修改候选人', iframe);
}
function removeRows() {
    var rows = $('#tt_table').datagrid('getSelections');
    if (rows.length == 0) {
        show_message("请选择一个候选人", "info");
        return;
    }
    var IDList = [];
    $.each(rows, function (index, row) {
        IDList.push(row.ID);
    })
    top.$.messager.confirm("提示", "是否删除选中的候选人?", function (r) {
        if (r) {
            var options = { visit: 'removesurveyquestion', IDList: JSON.stringify(IDList) };
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
function viewResult() {
    var TreeIDList = GetSelectedIDList();
    if (TreeIDList.length == 0) {
        show_message("请选择一个投票结果", "info");
        return;
    }
    var iframe = "../Wechat/ViewVoteResponse.aspx?SurveyID=" + TreeIDList[0];
    do_open_dialog('查看投票结果', iframe);
}
