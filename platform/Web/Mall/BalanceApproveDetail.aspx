<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BalanceApproveDetail.aspx.cs" Inherits="Web.Mall.BalanceApproveDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=this.ID%>";
        });
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <script src="../js/Page/Mall/Balance/BalanceApproveDetail.js?v=<%=base.getToken() %>"></script>
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
                    <td colspan="4" class="header_title">基本信息</td>
                </tr>
                <tr>
                    <td>商户名称</td>
                    <td>
                        <label id="tdBusinessName" runat="server"></label>
                    </td>
                    <td>商户联系人</td>
                    <td>
                        <label id="tdBusinessContactMan" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td>商户结算账户</td>
                    <td>
                        <label id="tdBusinessAccount" runat="server"></label>
                    </td>
                    <td>结算金额</td>
                    <td>
                        <label id="tdBalanceAmount" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td>结算规则</td>
                    <td>
                        <label id="tdBalanceRuleName" runat="server"></label>
                    </td>
                    <td>结算状态</td>
                    <td>
                        <label id="BalanceStatusDesc" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td>申请日期</td>
                    <td colspan="3">
                        <label id="tdAddTime" runat="server"></label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="header_title">订单信息</td>
                </tr>
            </table>
            <div style="margin: 10px 2.5%;">
                <div class="easyui-panel" style="height: 200px;">
                    <table id="tt_table"></table>
                </div>
            </div>
            <table class="info">
                <tr>
                    <td colspan="4" class="header_title">审核信息</td>
                </tr>
                <tr>
                    <td>审核日期</td>
                    <td>
                        <label id="tdApproveTime" runat="server"></label>
                    </td>
                    <td>审核人</td>
                    <td>
                        <label runat="server" id="tdApproveMan"></label>
                    </td>
                </tr>
                <tr>
                    <td>审核状态</td>
                    <td>
                        <label runat="server" id="tdApproveStatus"></label>
                    </td>
                    <td>审核备注</td>
                    <td>
                        <label runat="server" id="tdApproveRemark"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
