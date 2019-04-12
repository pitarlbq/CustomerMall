<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ViewXunJianDetailInfo.aspx.cs" Inherits="Web.ZhuangXiu.ViewXunJianDetailInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table.info {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            margin-top: 5px;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

        input[type=text] {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <asp:Repeater ID="rptXunJian" runat="server" OnItemDataBound="rptXunJian_ItemDataBound">
        <ItemTemplate>
            <table class="info">
                <tr>
                    <td>巡检日期</td>
                    <td>
                        <%#((DateTime)Eval("XunJianTime")) == DateTime.MinValue ? "" : Eval("XunJianTime", "{0:yyyy-MM-dd}") %>
                    </td>
                    <td>巡检人</td>
                    <td>
                        <%#Eval("XunJianMan") %>
                    </td>
                </tr>
                <asp:PlaceHolder runat="server" Visible='<%#Eval("XunJianStatus").ToString().Equals("WeiGui") %>'>
                    <tr class="trNoField">
                        <td>违规项目</td>
                        <td colspan="3">
                            <%#Eval("WeiGuiProject") %>
                        </td>
                    </tr>
                    <tr class="trNoField">
                        <td>违规罚款</td>
                        <td colspan="3">
                            <%#Eval("WeiGuiCost") %>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <%#Eval("Remark") %></td>
                </tr>
                <asp:Repeater ID="FileRepeater" runat="server" OnItemDataBound="FileRepeater_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td>附件</td>
                            <td colspan="3">
                                <%# DataBinder.Eval(Container.DataItem, "FileOriName") %>
                                <a target="_blank" href="<%# DataBinder.Eval(Container.DataItem, "AttachedFilePath") %>">下载</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Panel runat="server" ID="panContent">无巡检记录</asp:Panel>
</asp:Content>
