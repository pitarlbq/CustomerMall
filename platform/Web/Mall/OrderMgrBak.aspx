<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderMgrBak.aspx.cs" Inherits="Web.Mall.OrderMgrBak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var status = 0;
        $(function () {
            status = "<%=this.status%>";
        })
    </script>
    <script src="../js/Page/Mall/Order/OrderMgrBak.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_view()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">查看</a>
                <%if (this.status == 1 || this.status == 0)
                  { %>
                <a href="javascript:void(0)" onclick="do_pay()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-balance'">付款</a>
                <%} %>
                <%if (this.status == 5 || this.status == 0)
                  { %>
                <a href="javascript:void(0)" onclick="do_send()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-fahuo'">发货</a>
                <%} %>
                <%if (this.status == 2 || this.status == 5 || this.status == 0)
                  { %>
                <a href="javascript:void(0)" onclick="do_complete()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-wancheng'">完成</a>
                <%} %>
                <%if (this.status == 1 || this.status == 0 || this.status == 7)
                  { %>
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-guanbi_2'">关闭</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
