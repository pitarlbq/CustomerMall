<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="MsgMgr.aspx.cs" Inherits="Web.Wechat.MsgMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var type = 1, msgtype = 1, CanEdit = 1;
        $(function () {
            type = Number(<%=this.type%>);
            msgtypeid = Number(<%=this.msgtypeid%>);
            CanEdit = Number(<%=this.CanEdit%>);
        })
    </script>
    <script src="../js/Page/Wechat/MsgMgr.js?v=<%=base.getToken()%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px;">
            <label>
                关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <%if (this.CanAdd == 1)
                  { %>
                <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                <%} %>
                <%if (this.CanEdit == 1)
                  { %>
                <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <%} %>
                <%if (this.CanRemove == 1)
                  { %>
                <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">删除</a>
                <%} %>
                <%if (this.CanSendAPP == 1)
                  { %>
                <a href="javascript:void(0)" onclick="do_push()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">APP推送</a>
                <%} %>
                <%--<a href="javascript:void(0)" onclick="connectRoom()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-bangding'">资源绑定</a>
                <a href="javascript:void(0)" onclick="sendNotify()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tongzhi'">微信通知</a>
                <a href="javascript:void(0)" onclick="chooseUser()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">通知对象</a>--%>
            </div>
        </div>
    </div>
</asp:Content>
