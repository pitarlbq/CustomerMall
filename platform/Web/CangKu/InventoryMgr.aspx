<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="InventoryMgr.aspx.cs" Inherits="Web.CangKu.InventoryMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script>
        var tdKeywordObj, tdStartTimeObj, tdEndTimeObj, btnIncludDepartmentObj, hdDepartmentIDObj, hdIncludDepartmentObj, hdCategoryIDObj, tdProductCategory, btnShowInventory, hdHideInventory;
        $(function () {
            tdKeywordObj = $('#<%=this.tdKeyword.ClientID%>');
            tdStartTimeObj = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTimeObj = $('#<%=this.tdEndTime.ClientID%>');
            btnIncludDepartmentObj = $('#<%=this.btnIncludDepartment.ClientID%>');
            hdDepartmentIDObj = $('#<%=this.hdDepartmentID.ClientID%>');
            hdIncludDepartmentObj = $('#<%=this.hdIncludDepartment.ClientID%>');
            hdCategoryIDObj = $('#<%=this.hdCategoryID.ClientID%>');
            tdProductCategory = $('#<%=this.tdProductCategory.ClientID%>');
            btnShowInventory = $('#<%=this.btnShowInventory.ClientID%>');
            hdHideInventory = $('#<%=this.hdHideInventory.ClientID%>');
            doSearch();
        });
        function GetSelectedIDs(type) {
            var idarry = [];
            var treeObj = $.fn.zTree.getZTreeObj("tt");
            var nodes = treeObj.getCheckedNodes(true);
            $.each(nodes, function (index, node) {
                if (node.type == type) {
                    if (node.ID != 1) {
                        idarry.push(node.ID);
                    }
                }
            })
            return idarry;
        }
        function GetSelectedType() {
            var type = "";
            var treeObj = $.fn.zTree.getZTreeObj("tt");
            var r = $("input[type=radio]");
            for (var i = 0; i < r.length; i++) {
                if (r[i].checked) {
                    type = $(r[i]).attr("ptype");
                }
            }
            return type;
        }
        var IDMark_A = "_a";
        var setting = {
            view: {
                dblClickExpand: true,
                selectedMulti: true,
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
                onClick: onClick

            }
        };
        function onClick(event, treeId, treeNode, clickFlag) {
            var zTree = $.fn.zTree.getZTreeObj("tt");
            var type = treeNode.type;
            var ID = treeNode.ID;
            var btn = $("#" + type + "_" + ID);
            btn.click();
        }
        function doSearch() {
            var keywords = $("#searchbox").searchbox("getValue");
            var options = { visit: 'loadtree', Keywords: keywords, showdepartment: false };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
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
    </script>
    <script src="../js/Page/CangKu/CKInventoryMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" data-options="fit:true">
            <div data-options="region:'west',split:true,title:'菜单',border:false" style="width: 260px; padding: 10px; border: none;">
                <div class="easyui-panel searchlabel" style="max-height: 10%;">
                    <input id="searchbox" class="easyui-searchbox" data-options="prompt:'',searcher:doSearch" style="height: 30px; width: 150px;" />
                    <a href="#" onclick="reset()">刷新</a>
                </div>
                <div class="easyui-panel" style="" data-options="fit:true">
                    <ul id="tt" class="ztree"></ul>
                </div>
            </div>
            <div data-options="region:'center',border:false">
                <div class="easyui-layout" data-options="fit:true,border:false">
                    <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
                        <label>
                            关键字:
                <input class="easyui-searchbox" id="tdKeyword" runat="server" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                        </label>
                        <label>
                            日期:                     
                            <input class="easyui-datebox" runat="server" id="tdStartTime" type="text" style="width: 120px;" />
                            -                     
                            <input class="easyui-datebox" runat="server" id="tdEndTime" type="text" style="width: 120px;" />
                        </label>
                        <label>
                            物品类别:                    
                            <input type="text" class="easyui-combobox" id="tdProductCategory" runat="server" style="width: 100px;" />
                        </label>
                        <label>
                            <input type="checkbox" runat="server" id="btnShowInventory" />库存为0不显示
                        </label>
                        <label style="display: none;">
                            <input type="checkbox" runat="server" id="btnIncludDepartment" />按所属部门统计
                        </label>
                        <label class="searchlabel">
                            <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                        </label>
                    </div>
                    <div data-options="region:'center',border:false">
                        <table id="tt_table"></table>
                        <div id="tb">
                            <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                            <asp:HiddenField ID="hdDepartmentID" runat="server" />
                            <asp:HiddenField ID="hdIncludDepartment" runat="server" />
                            <asp:HiddenField ID="hdHideInventory" runat="server" />
                            <asp:HiddenField ID="hdCategoryID" runat="server" />
                            <asp:HiddenField ID="hdIDs" runat="server" />
                            <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
