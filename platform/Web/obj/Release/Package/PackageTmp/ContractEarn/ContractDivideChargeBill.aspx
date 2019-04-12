<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractDivideChargeBill.aspx.cs" Inherits="Web.ContractEarn.ContractDivideChargeBill" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var DivideID;
        $(function () {
            DivideID = "<%=Request.QueryString["ID"]%>";
        })
    </script>
    <script src="../js/Page/Comm/ChargeFeeComm.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <script src="../js/Page/ContractEarn/ContractDivideChargeBill.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'center'">
            <table id="tt_table">
            </table>
        </div>
    </div>
</asp:Content>
