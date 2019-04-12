<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="NewAddContract_More.aspx.cs" Inherits="Web.Contract.NewAddContract_More" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>合同登记</title>
    <script>
        var ffObj, ContractID, canEdit, cansavelog;
        $(function () {
            ffObj = $("#<%=this.ff.ClientID%>");
            ContractID = "<%=Request.QueryString["ID"]%>";
            canedit = "<%=this.canEdit?1:0%>";
            cansavelog = "<%=this.cansavelog ? 1 : 0%>";
        })
    </script>
    <script src="../js/Page/Contract/AddContract_More.js?t=<%=getToken()%>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.info td:nth-child(2n) {
            padding: 10px 0;
            width: 20%;
        }

        table.info td:nth-child(2n-1) {
            width: 13%;
        }

        table.info td input[type=text], table.info td select, table.info td input[type=password] {
            width: 15%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td>铺位功能</td>
                <td>
                    <input type="text" runat="server" name="RoomUseFor" class="easyui-textbox" id="tdRoomUseFor" />
                </td>
                <td>铺位状态</td>
                <td>
                    <input type="text" runat="server" name="RoomStatus" class="easyui-textbox" id="tdRoomStatus" />
                </td>
                <td>租赁用途</td>
                <td>
                    <input type="text" runat="server" name="RentUseFor" class="easyui-textbox" id="tdRentUseFor" /></td>
            </tr>
            <tr>
                <td>签约日期</td>
                <td>
                    <input type="text" runat="server" name="SignTime" class="easyui-datebox" id="tdSignTime" /></td>

                <td>免租开始日期</td>
                <td>
                    <input type="text" runat="server" name="FreeStartTime" class="easyui-datebox" id="tdFreeStartTime" /></td>

                <td>免租结束日期</td>
                <td>
                    <input type="text" runat="server" name="FreeEndTime" class="easyui-datebox" id="tdFreeEndTime" /></td>
            </tr>
            <tr>
                <td>开业日期</td>
                <td>
                    <input type="text" runat="server" name="OpenTime" class="easyui-datebox" id="tdOpenTime" /></td>

                <td>进场日期</td>
                <td>
                    <input type="text" runat="server" name="InTime" class="easyui-datebox" id="tdInTime" /></td>
                <td>退场日期</td>
                <td>
                    <input type="text" runat="server" name="OutTime" class="easyui-datebox" id="tdOutTime" /></td>
            </tr>
            <tr>
                <td>计费周期</td>
                <td>
                    <input type="text" runat="server" name="RentRange" class="easyui-textbox" id="tdRentRange" />
                </td>

                <td>收费周期</td>
                <td>
                    <input type="text" runat="server" name="ChargeRange" class="easyui-textbox" id="tdChargeRange" /></td>
                <td>经营商品</td>
                <td>
                    <input type="text" runat="server" name="SellerProduct" class="easyui-textbox" id="tdSellerProduct" /></td>
            </tr>
            <tr>
                <td>每年递增</td>
                <td>
                    <input type="text" runat="server" name="EveryYearUp" class="easyui-textbox" id="tdEveryYearUp" />%</td>
                <td>业态品类/品牌</td>
                <td>
                    <input type="text" runat="server" name="BrandModel" class="easyui-textbox" id="tdBrandModel" /></td>
                <td>联系电话</td>
                <td>
                    <input type="text" runat="server" name="PhoneNumber" class="easyui-textbox" id="tdPhoneNumber" /></td>
            </tr>
            <tr>
                <td>通讯地址</td>
                <td>
                    <input type="text" runat="server" name="Address" class="easyui-textbox" id="tdAddress" /></td>

                <td>客户联系人</td>
                <td>
                    <input type="text" runat="server" name="CustomerName" class="easyui-textbox" id="tdCustomerName" /></td>
                <td>身份证号</td>
                <td>
                    <input type="text" runat="server" name="IDCardNo" class="easyui-textbox" id="tdIDCardNo" /></td>
            </tr>
            <tr>
                <td>身份证地址</td>
                <td>
                    <input type="text" runat="server" name="IDCardAddress" class="easyui-textbox" id="tdIDCardAddress" /></td>
                <td>交付时间</td>
                <td>
                    <input type="text" runat="server" name="DeliverTime" class="easyui-datetimebox" id="tdDeliverTime" /></td>
                <td>营业执照</td>
                <td>
                    <input type="text" runat="server" name="BusinessLicense" class="easyui-textbox" id="tdBusinessLicense" /></td>
            </tr>
            <tr>
                <td>法人代表</td>
                <td>
                    <input type="text" runat="server" name="InChargeMan" class="easyui-textbox" id="tdInChargeMan" /></td>
                <td>合同押金</td>
                <td>
                    <input type="text" runat="server" name="ContractDeposit" class="easyui-textbox" id="tdContractDeposit" />(元)
                </td>
                <td>免租天数</td>
                <td>
                    <input type="text" runat="server" name="FreeDays" class="easyui-textbox" id="tdFreeDays" />(天)</td>
            </tr>
            <tr>
                <td>租金价格</td>
                <td>
                    <input type="text" runat="server" name="RentPrice" class="easyui-textbox" id="tdRentPrice" />(元)</td>
                <td>合同描述</td>
                <td colspan="3">
                    <input type="text" runat="server" name="ContractSummary" class="easyui-textbox" id="tdContractSummary" data-options="multiline:true" style="width: 70%; height: 60px;" /></td>
            </tr>
        </table>
    </form>
</asp:Content>
