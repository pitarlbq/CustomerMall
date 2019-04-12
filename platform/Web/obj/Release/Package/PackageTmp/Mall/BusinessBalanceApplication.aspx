<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BusinessBalanceApplication.aspx.cs" Inherits="Web.Mall.BusinessBalanceApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script src="../js/Page/Mall/Balance/BusinessBalanceApplication.js?v=<%=base.getToken() %>"></script>
    <style>
        [v-cloak] {
            display: none;
        }

        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <div id="fieldcontent" v-cloak>
            <table id="table_box" class="info" v-for="item in list" v-bind:id="'table_'+item.BusinessID">
                <tr>
                    <td>商户名称</td>
                    <td>{{item.BusinessName}}</td>
                    <td>商户联系人</td>
                    <td>{{item.BusinessContactMan}}</td>
                </tr>
                <tr>
                    <td>订单总数量</td>
                    <td>{{item.TotalCount}}</td>
                    <td>订单总金额</td>
                    <td>{{item.TotalCost}}</td>
                </tr>
                <tr>
                    <td>结算账户</td>
                    <td>
                        <input type="text" style="height: 28px;" v-bind:id="item.BusinessID+'_account'" v-model="item.BusinessBalanceAccount" /></td>
                    <td>结算规则</td>
                    <td>
                        <input type="text" style="height: 28px;" v-bind:id="item.BusinessID+'_rule'" v-model="item.BalanceRuleID" /></td>
                </tr>
                <tr>
                    <td>结算金额</td>
                    <td colspan="3">
                        <input type="text" style="height: 28px;" v-bind:id="item.BusinessID+'_balance'" v-model="item.BalanceAmount" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
