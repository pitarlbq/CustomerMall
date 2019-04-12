<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditContractHistory.aspx.cs" Inherits="Web.Contract.EditContractHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Contract/ContractHistoryEdit.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <table id="tt_table">
    </table>
</asp:Content>
