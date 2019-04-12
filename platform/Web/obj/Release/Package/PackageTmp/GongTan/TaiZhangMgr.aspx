<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="TaiZhangMgr.aspx.cs" Inherits="Web.GongTan.TaiZhangMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var hdBiaoCategory, hdIDs;
        $(function () {
            hdBiaoCategory = $("#<%=this.hdBiaoCategory.ClientID%>");
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
        });
        function do_close() {
            parent.do_close_dialog();
        }
    </script>
    <script src="../js/Page/GongTan/TaiZhangMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <input type="hidden" runat="server" id="hdPriceRangeList" />
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 80px; padding: 40px 5px 5px 5px;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <label>
                    关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索          ',searcher:SearchTT" style="width: 200px" />
                </label>
                <label>
                    表种类:   
                        <input class="easyui-combobox" id="tdBiaoCategory" style="width: 150px; height: 25px;" />
                    <asp:HiddenField runat="server" ID="hdBiaoCategory" />
                </label>
                <label>
                    作废状态:
                <select class="easyui-combobox" id="tdActiveStatus" style="width: 100px; height: 25px;">
                    <option value="">全部</option>
                    <option value="0">已作废</option>
                    <option value="1">未作废</option>
                </select>
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="activeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-qiyong'">生效</a>
                    <a href="javascript:void(0)" onclick="cancelRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-zuofei'">作废</a>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <%-- <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>--%>
                    <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdIDs" />
                    <a href="javascript:void(0)" onclick="openImport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                    <%-- <a href="javascript:void(0)" onclick="saveImportFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shengcheng'">生成账单</a>
                    <a href="javascript:void(0)" onclick="editRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chaobiao'">抄表</a>
                    <a href="javascript:void(0)" onclick="saveRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chaobiao'">登记</a>--%>
                    <a href="javascript:void(0)" onclick="batchEditTime()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">批处理</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
