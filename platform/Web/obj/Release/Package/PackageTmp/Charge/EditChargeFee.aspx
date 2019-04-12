<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditChargeFee.aspx.cs" Inherits="Web.Charge.EditChargeFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var FeeID = "<%=Request.QueryString["FeeID"]%>";
        var StartTime = "";
        var EndTypeObj = null;
        $(function () {
            StartTime = $("#<%=this.tbStartTime.ClientID%>").datebox("getValue");
            EndTypeObj = $("#<%=this.tbEndType.ClientID%>");
        })
    </script>
    <script src="../js/Page/EditChargeFee.js?t=<%=base.getToken() %>"></script>
    <style type="text/css">
        table.changefee {
            margin: 0 auto;
            border-collapse: collapse;
            border-spacing: 0px;
        }

            table.changefee td {
                padding: 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <table class="changefee">
        <tr>
            <td>收费项目</td>
            <td>
                <input type="text" id="tbName" runat="server" class="easyui-textbox" data-options="disabled:true" /></td>
        </tr>
        <tr>
            <td>单价</td>
            <td>
                <input type="text" id="tbUnitPrice" runat="server" class="easyui-numberbox" data-options="disabled:true,min:0,precision:2" /></td>
        </tr>
        <tr>
            <td>计算开始日期</td>
            <td>
                <input type="text" id="tbStartTime" runat="server" class="easyui-datebox" data-options="disabled:true" /></td>
        </tr>
        <tr>
            <td>调整单价</td>
            <td>
                <input type="text" id="tbChangePrice" class="easyui-numberbox" data-options="min:0,precision:2" /></td>
        </tr>
        <tr>
            <td>调整时间</td>
            <td>
                <input type="text" id="tbChangeStartTime" class="easyui-datebox" /></td>
        </tr>
        <tr>
            <td>计费规则</td>
            <td>
                <select id="tbEndType" runat="server" class="easyui-combobox">
                    <option value="1">月末</option>
                    <option value="2">季末</option>
                    <option value="3">年末</option>
                </select>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center;">
                <a href="javascript:void(0)" onclick="saveCharge()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            </td>
        </tr>
    </table>
</asp:Content>
