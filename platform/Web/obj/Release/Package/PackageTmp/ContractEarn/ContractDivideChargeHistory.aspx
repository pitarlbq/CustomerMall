<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractDivideChargeHistory.aspx.cs" Inherits="Web.ContractEarn.ContractDivideChargeHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var DivideID;
        $(function () {
            DivideID = "<%=Request.QueryString["ID"]%>";
        })
    </script>
    <script src="../js/Page/Comm/ChargeFeeComm.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <script src="../js/Page/ContractEarn/ContractDivideChargeHistory.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'center'">
            <table id="his_table">
            </table>
        </div>
    </div>
</asp:Content>
