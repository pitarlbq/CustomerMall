<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="Order_ViewShipInfo.aspx.cs" Inherits="Web.Mall.Order_ViewShipInfo" %>

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
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>收货人姓名</td>
                    <td colspan="3">
                        <label runat="server" id="tdAddressUserName"></label>
                    </td>
                </tr>
                <tr>
                    <td>收货人电话</td>
                    <td colspan="3">
                        <label runat="server" id="tdAddressPhoneNumber"></label>
                    </td>
                </tr>
                <tr>
                    <td>收货人所在省份</td>
                    <td colspan="3">
                        <label runat="server" id="tdAddressProvince"></label>
                    </td>
                </tr>
                <tr>
                    <td>收货人所在城市</td>
                    <td colspan="3">
                        <label runat="server" id="tdAddressCity"></label>
                    </td>
                </tr>
                <tr>
                    <td>收货人所在区县</td>
                    <td colspan="3">
                        <label runat="server" id="tdAddressDistrict"></label>
                    </td>
                </tr>
                <tr>
                    <td>收货人详细地址</td>
                    <td colspan="3">
                        <label runat="server" id="tdAddressDetailInfo"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
