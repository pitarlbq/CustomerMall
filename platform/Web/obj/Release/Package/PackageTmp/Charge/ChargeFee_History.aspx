<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeFee_History.aspx.cs" Inherits="Web.Charge.ChargeFee_History" %>

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
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/Comm/ChargeFeeComm.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <script src="../js/Page/Charge/ChargeFee_History.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
            <table id="his_table">
            </table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1101048"))
                  {%>
                <a href="javascript:void(0)" onclick="printHistoryChargeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">补打单据</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101049"))
                  {%>
                <a href="javascript:void(0)" onclick="cancelHistoryChargeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-zuofei'">作废单据</a>
                <%} %>
            </div>
        </div>
    </div>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
