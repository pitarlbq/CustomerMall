<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditChequeIn.aspx.cs" Inherits="Web.Cheque.EditChequeIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var InSummaryID, ffOjb, tdWriteDateObj, tdWriteManObj, tdDepartmentIDObj, tdProjectIDObj, tdSellerIDObj, tdSellerTaxNumberObj, tdSellerAddressPhoneObj, tdSellerBankAccountObj, tdBuyerIDObj, tdBuyerTaxNumberObj, tdBuyerAddressPhoneObj, tdBuyerBankAccountObj, tdChequeNumberObj, tdChequeTimeObj, tdChequeCodeObj, tdChequeCategoryObj, guid;
        $(function () {
            InSummaryID = "<%=this.ID%>";
            ffOjb = $("#<%=this.ff.ClientID%>");
            tdWriteDateObj = $("#<%=this.tdWriteDate.ClientID%>");
            tdWriteManObj = $("#<%=this.tdWriteMan.ClientID%>");
            tdDepartmentIDObj = $("#<%=this.tdDepartmentID.ClientID%>");
            tdProjectIDObj = $("#<%=this.tdProjectID.ClientID%>");
            tdSellerIDObj = $("#<%=this.tdSellerID.ClientID%>");
            tdSellerTaxNumberObj = $("#<%=this.tdSellerTaxNumber.ClientID%>");
            tdSellerAddressPhoneObj = $("#<%=this.tdSellerAddressPhone.ClientID%>");
            tdSellerBankAccountObj = $("#<%=this.tdSellerBankAccount.ClientID%>");
            tdBuyerIDObj = $("#<%=this.tdBuyerID.ClientID%>");
            tdBuyerTaxNumberObj = $("#<%=this.tdBuyerTaxNumber.ClientID%>");
            tdBuyerAddressPhoneObj = $("#<%=this.tdBuyerAddressPhone.ClientID%>");
            tdBuyerBankAccountObj = $("#<%=this.tdBuyerBankAccount.ClientID%>");
            tdChequeNumberObj = $("#<%=this.tdChequeNumber.ClientID%>");
            tdChequeTimeObj = $("#<%=this.tdChequeTime.ClientID%>");
            tdChequeCodeObj = $("#<%=this.tdChequeCode.ClientID%>");
            tdChequeCategoryObj = $("#<%=this.tdChequeCategory.ClientID%>");
            guid = "<%=this.guid%>";
        })
    </script>
    <script src="../js/Page/Comm/PinYin.js"></script>
    <script src="../js/Page/Cheque/ChequeInEdit.js?t=<%=base.getToken() %>"></script>
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
            <table class="info" style="margin-bottom: 0px; border-bottom-width: 0px;">
                <tr>
                    <td>发票种类</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdChequeCategory" runat="server" /></td>
                    <td>发票代码</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdChequeCode" runat="server" /></td>
                </tr>
                <tr>
                    <td>发票编号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdChequeNumber" runat="server" data-options="required:true" />
                    </td>
                    <td>开票日期
                    </td>
                    <td>
                        <input type="text" class="easyui-datebox" id="tdChequeTime" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>登记人员
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdWriteMan" runat="server" data-options="required:true" />
                    </td>
                    <td>登记日期
                    </td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdWriteDate" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>所属直属部门
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdDepartmentID" runat="server" />
                        <a href="javascript:void(0)" onclick="addDepartment()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                    <td>项目名称
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdProjectID" runat="server" />
                        <a href="javascript:void(0)" onclick="addProject()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>图片</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
            <table class="info" style="margin-bottom: 0px; border-bottom-width: 0px;">
                <tr>
                    <td>销售单位名称
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdSellerID" runat="server" />
                        <a href="javascript:void(0)" onclick="addSeller()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                    <td>销售单位纳税人识别号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdSellerTaxNumber" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td>销售单位地址电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdSellerAddressPhone" runat="server" data-options="readonly:true" />
                    </td>
                    <td>销售单位开户行及帐号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdSellerBankAccount" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
            </table>
            <div class="easyui-panel" style="height: 350px;">
                <table id="tt_table">
                </table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">新增</a>
                    <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
            <table class="info">
                <tr>
                    <td>购货单位名称
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdBuyerID" runat="server" />
                        <a href="javascript:void(0)" onclick="addBuyer()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                    <td>购货单位纳税人识别号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBuyerTaxNumber" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td>购货单位地址电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBuyerAddressPhone" runat="server" data-options="readonly:true" />
                    </td>
                    <td>购货单位开户行及帐号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBuyerBankAccount" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
            </table>
            <div style="text-align: center; padding: 10px 0px;">
                <a href="javascript:void(0)" onclick="saveRows()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">
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
