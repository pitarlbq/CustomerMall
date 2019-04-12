<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="TemplateView.aspx.cs" Inherits="Web.Contract.TemplateView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table.info {
            width: 100%;
            border: 0;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                border: 0px;
                padding: 20px 10%;
                text-align: left;
                width: 50%;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'center'" title="">
                <table class="info">
                    <tr>
                        <td style="text-align: left;">合同编号: {合同编号}</td>
                        <td style="text-align: right;">合同名称: {合同名称}</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: left;"><%=data.TemplateContent %></td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
