<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditPropertyHistory.aspx.cs" Inherits="Web.CangKu.EditPropertyHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdKeyword, tdStartTime, tdEndTime, PropertyID;
        $(function () {
            tdKeyword = $('#<%=this.tdKeyword.ClientID%>');
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            PropertyID = "<%=this.PropertyID%>";
        })
    </script>
    <script src="../js/Page/CangKu/EditPropertyHistory.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="myform">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
                <label>
                    关键字:
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" runat="server" />
                    <asp:HiddenField runat="server" ID="hdTreeID" />
                </label>
                <label>
                    变更日期
                    <input class="easyui-datebox" runat="server" id="tdStartTime" />
                    -
                    <input class="easyui-datebox" runat="server" id="tdEndTime" />
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
            </div>
        </div>
    </form>
</asp:Content>
