<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeFee_Guarantee.aspx.cs" Inherits="Web.Charge.ChargeFee_Guarantee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var companyID, AddMan, hdPriceRangeList, hdChargeDiscount;
        $(function () {
            companyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            hdPriceRangeList = $("#<%=this.hdPriceRangeList.ClientID%>");
        })
    </script>
    <script src="../js/Page/Comm/ChargeFeeComm.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <script src="../js/Page/Charge/ChargeFee_Guarantee.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .operationtable {
            width: 100%;
        }

            .operationtable td {
                text-align: center;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <input type="hidden" runat="server" id="hdPriceRangeList" />
    <div class="easyui-layout" fit="true">
        <div data-options="region:'center'" title="">
            <table id="gua_table">
            </table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="chargeBackGuaranteeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tuikuan'">退保证金</a>
            </div>
        </div>
    </div>
</asp:Content>
