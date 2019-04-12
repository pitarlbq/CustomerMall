<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DeviceMgr.aspx.cs" Inherits="Web.Device.DeviceMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../js/ztree/zTreeStyle/zTreeStyle.css?v1" rel="stylesheet" />
    <script src="../js/ztree/jquery.ztree.core.js"></script>
    <script src="../js/ztree/jquery.ztree.excheck.js"></script>
    <script src="../js/ztree/jquery.ztree.exedit.js"></script>
    <script>
        var tdKeywords, tdDeviceGroup;
        $(function () {
            tdKeywords = $('#<%=this.tdKeywords.ClientID%>');
            tdDeviceGroup = $('#<%=this.tdDeviceGroup.ClientID%>');
        })
    </script>
    <script>
        var idList = "";
        $(function () {
            loadTree();
        })
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
        function loadTree() {
            var options = { visit: 'getprojectbylevel', level: 1 };
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
        function getSelectedProjectIDs() {
            var idarry = [];
            var treeObj = $.fn.zTree.getZTreeObj("tt");
            var nodes = treeObj.getCheckedNodes(true);
            $.each(nodes, function (index, node) {
                if (node.id > 1) {
                    idarry.push(node.id);
                }
            });
            return idarry;
        }
    </script>
    <script src="../js/Page/Device/DeviceMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="form1">
        <div class="easyui-layout" data-options="fit:true">
            <div data-options="region:'west',split:true,title:'项目菜单',border:false" style="width: 260px; padding: 10px; border: none;">
                <ul id="tt" class="ztree"></ul>
            </div>
            <div data-options="region:'center',border:false">
                <div class="easyui-layout" data-options="fit:true">
                    <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                        <div class="tdsearch">
                            <label>
                                模糊搜索:
                        <input type="text" class="easyui-searchbox" id="tdKeywords" runat="server" style="width: 150px;" data-options="prompt:'设备名称,设备编码',searcher:SearchTT" />
                            </label>
                            <label>
                                设备分组:
                         <input type="text" class="easyui-combobox" id="tdDeviceGroup" runat="server" style="width: 150px;" />
                            </label>
                            <label>
                                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                                <asp:HiddenField runat="server" ID="hdProjectIDs" />
                            </label>
                        </div>
                    </div>
                    <div data-options="region:'center'" title="">
                        <table id="tt_table">
                        </table>
                        <div id="tb">
                            <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                            <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                            <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                            <a href="javascript:void(0)" onclick="doMore()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">批处理</a>
                            <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                            <a href="javascript:void(0)" onclick="doImport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                            <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
