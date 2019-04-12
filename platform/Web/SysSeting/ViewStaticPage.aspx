<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewStaticPage.aspx.cs" Inherits="Web.SysSeting.ViewStaticPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <img src="<%=this.ImagePath %>" style="width: 100%;" />
</asp:Content>
