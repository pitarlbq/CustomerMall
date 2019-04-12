<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddContractRoom.aspx.cs" Inherits="Web.Contract.AddContractRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script type="text/javascript">
        var UserID, CompanyID, ContractID, guid, canedit;
        $(function () {
            guid = "<%=this.guid%>";
            ContractID = "<%=this.ContractID%>";
            UserID = "<%=Web.WebUtil.GetUser(this.Context).UserID%>";
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            canedit = "<%=Request.QueryString["canedit"]%>" || '';
            doSearch();
            $('#tdsearch').tooltip({
                content: $('<div class="showContent"></div>'),
                showEvent: 'click',
                hideEvent: 'none',
                onUpdate: function (content) {
                    content.panel({
                        width: 200,
                        border: false,
                        title: '显示设置',
                        content: '<input type="text" id="tdLevel" runat="server" class="easyui-textbox" style="width: 60px" /><a href="javascript:savelevel()" class="easyui-linkbutton">保存</a>'
                    });
                },
                onShow: function () {
                    var t = $(this);
                    $(document).bind("click", function (e) {
                        var target = $(e.target);
                        if (target.closest(".tooltip").length == 0) {
                            t.tooltip('hide');
                        }
                    })
                },
                onHide: function () {
                    var t = $(this);
                    $(document).unbind("click")
                }
            });
        });
        var ProjectNames = '';
        var ProjectName_Index = '';
        function GetSelectedProjects() {
            var namearry = [];
            var idarry = [];
            var pidarray = [];
            var treeObj = $.fn.zTree.getZTreeObj("tt");
            var nodes = treeObj.getCheckedNodes(true);
            $.each(nodes, function (index, node) {
                if (node.isParent) {
                    namearry.push(node.FullName);
                    idarry.push(node.id);
                    if (node.pId && $.inArray(node.pId, pidarray) == -1) {
                        pidarray.push(node.pId);
                    }
                }
            });
            var temp = [];
            var temparray = [];
            for (var i = 0; i < pidarray.length; i++) {
                temp[pidarray[i]] = true;
            };
            for (var i = 0; i < idarry.length; i++) {
                if (!temp[idarry[i]]) {
                    temparray.push(idarry[i]);
                    if (ProjectName_Index > 0) {
                        ProjectNames += ',';
                    }
                    ProjectNames += namearry[i];
                    ProjectName_Index++;
                };
            };
            return temparray;
        }
        var RoomNames = '';
        var Room_Index = 0;
        function GetSelectedRooms() {
            RoomNames = '';
            Room_Index = 0;
            var list = [];
            var treeObj = $.fn.zTree.getZTreeObj("tt");
            var nodes = treeObj.getCheckedNodes(true);
            $.each(nodes, function (index, node) {
                if (!node.isParent) {
                    if (Room_Index > 0) {
                        RoomNames += ',';
                    }
                    RoomNames += node.FullName + "-" + node.name;
                    list.push(node.id);
                    Room_Index++;
                }
            })
            return list;
        }
        var IDMark_A = "_a";
        var setting = {
            async: {
                enable: true,
                url: getUrl
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
                enable: true,
                chkboxType: { "Y": "s", "N": "s" }
            },
            callback: {
                beforeExpand: beforeExpand,
                onAsyncSuccess: onAsyncSuccess,
                onAsyncError: onAsyncError,
                onCheck: zTreeOnCheck
            }
        };
        function getUrl(treeId, treeNode) {
            var param = "visit=getprojectinfo&ID=" + treeNode.id + "&CompanyID=" + CompanyID + "&UserID=" + UserID;
            return "../Handler/ProjectHandler.ashx?" + param;
        }
        function zTreeOnCheck(event, treeId, treeNode) {
            if (!treeNode.isParent) {
                try {
                    loadRoomInfo(treeNode.id, treeNode.checked);
                } catch (e) {

                }
            }
        };
        function beforeExpand(treeId, treeNode) {
            if (!treeNode.isAjaxing) {
                treeNode.times = 1;
                ajaxGetNodes(treeNode, "refresh");
                return true;
            } else {
                alert("zTree 正在下载数据中，请稍后展开节点。。。");
                return false;
            }
        }
        function onAsyncSuccess(event, treeId, treeNode, msg) {
            if (!msg || msg.length == 0) {
                return;
            }
            var zTree = $.fn.zTree.getZTreeObj("tt");
            treeNode.icon = "";
            zTree.updateNode(treeNode);
            zTree.selectNode(treeNode.children[0]);
        }
        function onAsyncError(event, treeId, treeNode, XMLHttpRequest, textStatus, errorThrown) {
            var zTree = $.fn.zTree.getZTreeObj("tt");
            alert("异步获取数据出现异常。");
            treeNode.icon = "";
        }
        function ajaxGetNodes(treeNode, reloadType) {
            var zTree = $.fn.zTree.getZTreeObj("tt");
            if (reloadType == "refresh") {
                treeNode.icon = "../js/ztree/zTreeStyle/img/loading.gif";
                zTree.updateNode(treeNode);
            }
            zTree.reAsyncChildNodes(treeNode, reloadType, true);
        }
        function doSearch() {
            var keywords = $("#searchbox").searchbox("getValue");
            var options = { visit: 'getprojectinfo', Keywords: keywords, CompanyID: CompanyID, UserID: UserID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (data) {
                    $.fn.zTree.init($("#tt"), setting, data);
                }
            });
        }
        function reset() {
            $("#searchbox").searchbox("setValue", "");
            doSearch();
        }
        function savelevel() {
            var LevelID = $("#<%=this.tdLevel.ClientID%>").textbox("getValue");
            if (LevelID == "") {
                show_message("显示级别不能为空", "warning");
                return;
            }
            var options = { visit: 'saveshowlevel', LevelID: LevelID, CompanyID: "<%=Web.WebUtil.GetCompanyID(this.Context)%>" };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/RoomResourceHandler.ashx',
                data: options,
                success: function (data) {
                    doSearch();
                }
            });
        }
        function closeWin() {
            parent.do_close_dialog(function () {
                parent.$("#tt_room").datagrid("reload");
            });
        }
        function saveData() {
            var ProjectIDList = [];
            var RoomIDList = [];
            try {
                ProjectIDList = GetSelectedProjects();
                RoomIDList = GetSelectedRooms();
            } catch (e) {
            }
            if (ProjectIDList.length == 0 && RoomIDList.length == 0) {
                show_message("请选择资源", "warning");
                return;
            }
            if (ContractID <= 0 && guid == '') {
                try {
                    if (RoomIDList.length > 0) {
                        parent.hdRoomType.val(1);
                        parent.tdProjectNames.textbox('setValue', RoomNames);
                        parent.hdProjectIDs.val(JSON.stringify(RoomIDList));
                    } else if (ProjectIDList.length > 0) {
                        parent.hdRoomType.val(0);
                        parent.tdProjectNames.textbox('setValue', ProjectNames);
                        parent.hdProjectIDs.val(JSON.stringify(ProjectIDList));
                    }
                } catch (e) {
                }
                closeWin();
                return;
            }
            var options = { visit: 'savecontractroom', ProjectIDList: JSON.stringify(ProjectIDList), RoomIDList: JSON.stringify(RoomIDList), guid: guid, ContractID: ContractID, canedit: canedit };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('添加成功', 'success', function () {
                            closeWin();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    </script>
    <style>
        .l-btn-plain {
            display: inline;
        }

        .ztree li {
            padding: 5px 0 0 0;
            /*background:url("../js/ztree/zTreeStyle/img/line_conn.gif") repeat-y scroll 0 0*/
        }

            .ztree li > input {
                margin: 0;
            }

        .searchlabel a#tdsearch {
            display: none;
        }
    </style>
    <link href="../styles/treecss.css?v=1.0" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container" style="height: 100%;">
        <div class="easyui-panel searchlabel" style="max-height: 10%;">
            <a id="tdsearch" href="javascript:void(0)">显示设置:</a>
            <input id="searchbox" class="easyui-searchbox" data-options="prompt:'',searcher:doSearch" style="height: 30px; width: 150px;" />
            <a href="#" onclick="reset()">刷新</a>
        </div>
        <div class="easyui-panel" style="height: 90%;">
            <ul id="tt" class="ztree"></ul>
        </div>
    </div>
</asp:Content>
