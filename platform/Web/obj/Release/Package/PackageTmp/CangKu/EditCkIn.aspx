<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditCkIn.aspx.cs" Inherits="Web.CangKu.EditCkIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js?t=1_<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var ID, ffOjb, AddUserNameObj, InTimeObj, OrderNumberObj, ContractObj, ContractUserNameObj, ContractPhoneNumberObj, AddMan, InCategoryObj, BelongTeamNameObj, CKCategoryID, canEdit;
        $(function () {
            ID = "<%=this.ID%>";
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            ffOjb = $("#<%=this.ff.ClientID%>");
            AddUserNameObj = $("#<%=this.tdAddUserName.ClientID%>");
            InTimeObj = $("#<%=this.tdInTime.ClientID%>");
            OrderNumberObj = $("#<%=this.tdOrderNumber.ClientID%>");
            ContractObj = $("#<%=this.tdContract.ClientID%>");
            ContractUserNameObj = $("#<%=this.tdContractUserName.ClientID%>");
            ContractPhoneNumberObj = $("#<%=this.tdContractPhoneNumber.ClientID%>");
            InCategoryObj = $("#<%=this.tdInCategory.ClientID%>");
            BelongTeamNameObj = $("#<%=this.tdBelongTeamName.ClientID%>");
            CKCategoryID = "<%=this.CKCategoryID%>";
            canEdit = "<%=this.canEdit?1:0%>";
            if (canEdit == 0) {
                AddUserNameObj.textbox({
                    "disabled": true
                });
                InTimeObj.datetimebox({
                    "disabled": true
                });
                ContractObj.combobox({
                    "disabled": true
                });
                ContractUserNameObj.textbox({
                    "disabled": true
                });
                ContractPhoneNumberObj.textbox({
                    "disabled": true
                });
            }
        })
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/CangKu/CkInEdit.js?t=<%=base.getToken() %>"></script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <%if (this.canEdit)
              { %>
            <a href="javascript:void(0)" onclick="do_save(true)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">保存并打印</a>
            <a href="javascript:void(0)" onclick="do_save(false)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td colspan="4" style="text-align: center; font-size: 15px;">入库单</td>
                </tr>
                <tr>
                    <td>所属仓库</td>
                    <td colspan="3" style="text-align: left; font-size: 15px;">
                        <label runat="server" id="CKCategoryName"></label>
                    </td>
                </tr>
                <tr>
                    <td>仓管员
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdAddUserName" runat="server" />
                    </td>
                    <td>入库时间
                    </td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdInTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>入库类别
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdInCategory" runat="server" data-options="editable:false" style="width: 50%" />
                        <%if (this.canEdit)
                          { %>
                        <a href="javascript:void(0)" onclick="addCategory()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        <%} %>
                    </td>
                    <td>所在部门
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdBelongTeamName" runat="server" data-options="editable:false" style="width: 50%" />
                        <%if (this.canEdit)
                          { %>
                        <a href="javascript:void(0)" onclick="addDepartment()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td>入库单号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdOrderNumber" runat="server" data-options="disabled:true" />
                    </td>
                    <td>供应商
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdContract" runat="server" data-options="editable:false" style="width: 50%" />
                        <%if (this.canEdit)
                          { %>
                        <a href="javascript:void(0)" onclick="addContract()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td>供应商联系人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContractUserName" runat="server" />
                    </td>
                    <td>联系电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContractPhoneNumber" runat="server" />
                    </td>
                </tr>
            </table>
            <div class="easyui-panel" style="height: 350px;">
                <table id="tt_table">
                </table>
                <%if (this.canEdit)
                  { %>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
                <%} %>
            </div>
        </div>
        <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
    </form>
</asp:Content>
