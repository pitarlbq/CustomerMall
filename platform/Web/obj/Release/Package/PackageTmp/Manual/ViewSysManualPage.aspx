<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewSysManualPage.aspx.cs" Inherits="Web.Manual.ViewSysManualPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/ueditor/ueditor.parse.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div style="padding: 15px 30px;">
        <%=this.HMTLContent %>
    </div>
</asp:Content>
