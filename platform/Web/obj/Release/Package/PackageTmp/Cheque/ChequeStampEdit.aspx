<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChequeStampEdit.aspx.cs" Inherits="Web.Cheque.ChequeStampEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ID, guid, tdContractNumberObj, tdDepartmentIDObj, tdContractCategoryIDObj, tdTaxRateIDObj, tdContractNameObj, tdUnitPriceObj, tdTotalCountObj, tdTotalCostObj, tdTotalTaxCostObj, tdAddManObj, tdAddTimeObj, ffObj, tdTaxRateValueObj;
        $(function () {
            ID = "<%=this.ID%>";
            guid = "<%=this.guid%>";
            tdContractNumberObj = $("#<%=this.tdContractNumber.ClientID%>");
            tdDepartmentIDObj = $("#<%=this.tdDepartmentID.ClientID%>");
            tdContractCategoryIDObj = $("#<%=this.tdContractCategoryID.ClientID%>");
            tdTaxRateIDObj = $("#<%=this.tdTaxRateID.ClientID%>");
            tdContractNameObj = $("#<%=this.tdContractName.ClientID%>");
            tdUnitPriceObj = $("#<%=this.tdUnitPrice.ClientID%>");
            tdTotalCountObj = $("#<%=this.tdTotalCount.ClientID%>");
            tdTotalCostObj = $("#<%=this.tdTotalCost.ClientID%>");
            tdTotalTaxCostObj = $("#<%=this.tdTotalTaxCost.ClientID%>");
            tdAddManObj = $("#<%=this.tdAddMan.ClientID%>");
            tdAddTimeObj = $("#<%=this.tdAddTime.ClientID%>");
            ffObj = $("#<%=this.ff.ClientID%>");
            tdTaxRateValueObj = $("#<%=this.tdTaxRateValue.ClientID%>");
        });

    </script>
    <script src="../js/Page/Comm/PinYin.js"></script>
    <script src="../js/Page/Cheque/ChequeStampEdit.js?t=<%=getToken() %>"></script>
    <style type="text/css">
        table.info {
            width: 100%;
            margin: 0 auto;
            border: solid 2px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            margin-bottom: 10px;
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

            table.info input {
                width: 200px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div style="padding: 10px 0; width: 90%; margin: 0 auto;">
            <table class="info">
                <tr>
                    <td>合同编号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContractNumber" runat="server" data-options="required:true" />
                    </td>
                    <td>部门名称
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdDepartmentID" runat="server" />
                        <a href="javascript:void(0)" onclick="addDepartment()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                </tr>
                <tr>
                    <td>合同分类
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdContractCategoryID" runat="server" />
                        <a href="javascript:void(0)" onclick="addContractCategory()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                    <td>印花税税目税率表
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdTaxRateID" runat="server" />
                        <a href="javascript:void(0)" onclick="addTaxRate()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                </tr>
                <tr>
                    <td>合同名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContractName" runat="server" />
                    </td>
                    <td>单价
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdUnitPrice" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>数量
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTotalCount" runat="server" />
                    </td>
                    <td>金额
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTotalCost" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td>印花税税率</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTaxRateValue" runat="server" data-options="readonly:true" />
                    </td>
                    <td>税额</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTotalTaxCost" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td>登记人</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdAddMan" runat="server" data-options="readlyonly:true" />
                    </td>
                    <td>登记日期</td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdAddTime" runat="server" data-options="readlyonly:true" />
                    </td>
                </tr>
            </table>
            <div style="text-align: center; padding: 10px 0px;">
                <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">
                    <%if (this.ID > 0)
                      { %>
                    保存
                    <%}
                      else
                      { %>
                    确认登记
                    <%} %>
                </a>
                <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
    </form>
</asp:Content>
