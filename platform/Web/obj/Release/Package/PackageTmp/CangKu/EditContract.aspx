<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditContract.aspx.cs" Inherits="Web.CangKu.EditContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ID%>";
            var ContractName = $("#<%=this.tdContractName.ClientID%>").textbox("getValue");
            var ContractFullName = $("#<%=this.tdContractFullName.ClientID%>").textbox("getValue");
            var Address = $("#<%=this.tdAddress.ClientID%>").textbox("getValue");
            var ContactMan = $("#<%=this.tdContactMan.ClientID%>").textbox("getValue");
            var PhoneNumber = $("#<%=this.tdPhoneNumber.ClientID%>").textbox("getValue");
            var FaxNumber = $("#<%=this.tdFaxNumber.ClientID%>").textbox("getValue");
            var EMailAddress = $("#<%=this.tdEMailAddress.ClientID%>").textbox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var ContractNumber = "<%=this.ContractNumber%>"
            var options = { visit: 'savecontract', ID: ID, ContractName: ContractName, ContractFullName: ContractFullName, Address: Address, ContactMan: ContactMan, PhoneNumber: PhoneNumber, FaxNumber: FaxNumber, EMailAddress: EMailAddress, Remark: Remark, AddMan: AddMan, ContractNumber: ContractNumber };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
            }, true);
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>供应商简称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContractName" runat="server" data-options="required:true" />
                    </td>
                    <td>供应商全称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContractFullName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>通信地址
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdAddress" runat="server" style="width: 80%;" />
                    </td>
                </tr>
                <tr>
                    <td>联系人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdContactMan" runat="server" />
                    </td>
                    <td>联系电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPhoneNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>传真号码
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdFaxNumber" runat="server" />
                    </td>
                    <td>个人EMail
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdEMailAddress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" id="tdRemark" data-options="multiline:true" runat="server" style="height: 60px; width: 80%;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
