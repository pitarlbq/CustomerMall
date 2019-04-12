<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeFee_Bill.aspx.cs" Inherits="Web.Charge.ChargeFee_Bill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var companyID, AddMan, hdPriceRangeList, hdChargeDiscount, canEditUnitPrice, canEditUseCount, canChargeView;
        $(function () {
            companyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            hdPriceRangeList = $("#<%=this.hdPriceRangeList.ClientID%>");
            hdChargeDiscount = $("#<%=this.hdChargeDiscount.ClientID%>");
            canEditUnitPrice = "<%=base.CheckAuthByModuleCode("1101148")?1:0%>";
            canEditUseCount = "<%=base.CheckAuthByModuleCode("1101149")?1:0%>";
            canChargeView = "<%=base.CheckAuthByModuleCode("1101150")?1:0%>";
        })
    </script>
    <script src="../js/Page/Comm/ChargeFeeComm.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <script src="../js/Page/Charge/ChargeFee_Bill.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .operationtable {
            width: 100%;
        }

            .operationtable td {
                text-align: center;
            }

        .sfdd {
            width: 51px;
            height: 32px;
            background: url("../styles/images/buttons/print.png") no-repeat center center;
            display: block;
        }

        .lsff {
            width: 51px;
            height: 32px;
            background: url("../styles/images/buttons/tempfee.png") no-repeat center center;
            display: block;
        }

        .jbbb {
            width: 51px;
            height: 32px;
            background: url("../styles/images/buttons/jiaoban.png") no-repeat center center;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <input type="hidden" runat="server" id="hdPriceRangeList" />
    <input type="hidden" runat="server" id="hdChargeDiscount" />
    <div class="easyui-layout" fit="true">
        <div data-options="region:'center'" title="">
            <table id="tt_table">
            </table>
            <div id="tt_mm">
                <%if (base.CheckAuthByModuleCode("1101045"))
                  {%>
                <a href="javascript:void(0)" onclick="chargeviewroomfee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">收款打印</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101046"))
                  {%>
                <a href="javascript:void(0)" onclick="addTempFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shoufei'">临时收费</a>
                <%} %>
                <%if (base.CheckAuthByModuleCode("1101047"))
                  {%>
                <a href="javascript:void(0)" onclick="top.addTab('交班报表', '<%=base.GetContextPath() %>/main/subpage.aspx?ID=13', 'jbbb')" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-jiaoban'">交班报表</a>
                <%} %>
                <a href="javascript:void(0)" onclick="doChangeChargeMan()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-guazhang'">账单转移</a>
            </div>
        </div>
    </div>
</asp:Content>
