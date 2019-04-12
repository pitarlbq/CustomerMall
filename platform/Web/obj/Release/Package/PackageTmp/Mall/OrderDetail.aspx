<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="Web.Mall.OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=this.OrderID%>";
        });
        function do_close() {
            parent.do_close_dialog(function () {
                parent.content.getdata();
            });
        }
    </script>
    <script src="../js/Page/Mall/Order/Order_ViewProductInfo.js?v=<%=base.getToken() %>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.info table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title">基本信息</div>
            <table class="info">
                <tr>
                    <td>订单编号</td>
                    <td>
                        <label id="tdOrderNumber" runat="server"></label>
                    </td>
                    <td>订单时间</td>
                    <td>
                        <label id="tdOrderTime" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td>订单类型</td>
                    <td>
                        <label id="tdOrderType" runat="server"></label>
                    </td>
                    <td>订单金额</td>
                    <td>
                        <label id="tdTotalCost" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td>订单状态</td>
                    <td>
                        <label id="tdOrderStatus" runat="server"></label>
                    </td>
                    <td>买家昵称</td>
                    <td>
                        <label id="tdNickName" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td>买家电话</td>
                    <td>
                        <label id="tdBuserPhone" runat="server"></label>
                    </td>
                    <td>买家留言</td>
                    <td>
                        <label id="tdUserNote" runat="server"></label>
                    </td>
                </tr>
            </table>
            <div class="table_title">商品信息</div>
            <div class="easyui-panel" style="height: 300px;">
                <table id="tt_table"></table>
            </div>
            <div class="table_title">收获地址信息</div>
            <table class="info">
                <tr>
                    <td>收货人姓名</td>
                    <td>
                        <label runat="server" id="tdAddressUserName"></label>
                    </td>
                    <td>收货人电话</td>
                    <td>
                        <label runat="server" id="tdAddressPhoneNumber"></label>
                    </td>
                </tr>
                <tr>
                    <td>收货人所在省份</td>
                    <td>
                        <label runat="server" id="tdAddressProvince"></label>
                    </td>
                    <td>收货人所在城市</td>
                    <td>
                        <label runat="server" id="tdAddressCity"></label>
                    </td>
                </tr>
                <tr>
                    <td>收货人所在区县</td>
                    <td>
                        <label runat="server" id="tdAddressDistrict"></label>
                    </td>
                    <td>收货人详细地址</td>
                    <td>
                        <label runat="server" id="tdAddressDetailInfo"></label>
                    </td>
                </tr>
            </table>
            <div class="table_title">快递信息</div>
            <table class="info">
                <tr>
                    <td>运单号</td>
                    <td>
                        <label runat="server" id="tdShipTrackNo"></label>
                    </td>
                    <td>发货公司
                    </td>
                    <td>
                        <label runat="server" id="tdShipCompany"></label>
                    </td>
                </tr>
                <tr>
                    <td>发货时间
                    </td>
                    <td>
                        <label runat="server" id="tdShipTime"></label>
                    </td>
                    <td>发货人
                    </td>
                    <td>
                        <label runat="server" id="tdShipUserName"></label>
                    </td>
                </tr>
                <tr>
                    <td>收货时间
                    </td>
                    <td>
                        <label runat="server" id="tdCompleteTime"></label>
                    </td>
                    <td>配送人
                    </td>
                    <td>
                        <label runat="server" id="tdShipDelivererName"></label>
                    </td>
                </tr>
            </table>
            <div class="table_title">抢单信息</div>
            <table class="info">
                <tr>
                    <td>抢单人</td>
                    <td>
                        <label runat="server" id="tdGrapUserName"></label>
                    </td>
                    <td>抢单时间
                    </td>
                    <td>
                        <label runat="server" id="tdGrapTime"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
