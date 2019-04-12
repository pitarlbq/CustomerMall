<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeFee_PreCharge.aspx.cs" Inherits="Web.Charge.ChargeFee_PreCharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var companyID, AddMan, hdPriceRangeList, hdChargeDiscount, ChargeID;
        $(function () {
            companyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            hdPriceRangeList = $("#<%=this.hdPriceRangeList.ClientID%>");
            ChargeID = "<%=this.ChargeID%>"
        })
    </script>
    <script src="../js/Page/Comm/ChargeFeeComm.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <script src="../js/Page/Charge/ChargeFeePreChargeComm.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <script src="../js/Page/Charge/ChargeFee_PreCharge.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .operationtable {
            width: 100%;
        }

            .operationtable td {
                text-align: center;
                width: 50%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <input type="hidden" runat="server" id="hdPriceRangeList" />
    <div class="easyui-layout" fit="true">
        <div data-options="region:'center'" title="">
            <table id="tt_table">
            </table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1101061"))
                  {%>
                <a href="javascript:void(0)" onclick="chargechongdiroomfee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shoufei'">开冲抵单</a>
                <%} %>
                <a href="javascript:void(0)" onclick="chargebackprefee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tuikuan'">退预收款</a>
            </div>
        </div>
    </div>
</asp:Content>
