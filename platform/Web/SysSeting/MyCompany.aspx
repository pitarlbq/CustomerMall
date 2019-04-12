<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MyCompany.aspx.cs" Inherits="Web.SysSeting.MyCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function saveResource() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var CompanyID = "<%=this.CompanyID%>";
            var CompanyName = $("#<%=this.tdRealName.ClientID%>").textbox("getValue");
            var PhoneNumber = $("#<%=this.tdPhoneNumber.ClientID%>").textbox("getValue");
            var Description = $("#<%=this.tdDesc.ClientID%>").textbox("getValue");
            var Address = $("#<%=this.tdAddress.ClientID%>").textbox("getValue");
            var ChargeMan = $("#<%=this.tdChargeMan.ClientID%>").textbox("getValue");
            var IsActive = $("#<%=this.tdIsActive.ClientID%>").combobox("getValue");
            var Distributor = $("#<%=this.tdDistributor.ClientID%>").textbox("getValue");
            var UserCount = $("#<%=this.tdUserCount.ClientID%>").textbox("getValue");
            var StartTime = $("#<%=this.tdStartTime.ClientID%>").datetimebox("getValue");
            var EndtTime = $("#<%=this.tdEndTime.ClientID%>").datetimebox("getValue");
            var options = {};
            options.visit = "savecompanyinfo";
            options.CompanyID = CompanyID;
            options.CompanyName = CompanyName;
            options.PhoneNumber = PhoneNumber;
            options.Description = Description;
            options.Address = Address;
            options.ChargeMan = ChargeMan;
            options.IsActive = IsActive;
            options.Distributor = Distributor;
            options.UserCount = UserCount;
            options.StartTime = StartTime;
            options.EndtTime = EndtTime;
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            parent.$("#winadd").window('close');
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
    </script>
    <style type="text/css">
        table.info {
            width: 90%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
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

        input {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr>
                    <td style="width: 15%;">公司名称
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-textbox" id="tdRealName" runat="server" data-options="required:true" />
                    </td>
                    <td style="width: 15%;">公司地址
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-textbox" id="tdAddress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;">联系人
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-textbox" id="tdChargeMan" runat="server" />

                    </td>
                    <td style="width: 15%;">联系电话
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-textbox" id="tdPhoneNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;">经销商
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-textbox" id="tdDistributor" runat="server" data-options="disabled:true" />

                    </td>
                    <td style="width: 15%;">授权用户数
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-textbox" id="tdUserCount" runat="server" data-options="required:true,disabled:true" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 15%;">付费服务开始时间
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-datetimebox" id="tdStartTime" runat="server" data-options="required:true,disabled:true" />

                    </td>
                    <td style="width: 15%;">付费服务结束时间
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-datetimebox" id="tdEndTime" runat="server" data-options="required:true,disabled:true" />
                    </td>
                </tr>
                <tr>
                    <td>是否付费
                    </td>
                    <td>
                        <select id="tdIsActive" runat="server" class="easyui-combobox" style="width: 50px;" data-options="disabled:true">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select></td>
                     <td style="width: 15%;">授权项目
                    </td>
                    <td style="width: 35%;">
                        <input class="easyui-textbox" id="tdProjectCount" runat="server" data-options="required:true,disabled:true" />
                    </td>
                </tr>
                <tr>
                    <td>公司简介
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdDesc" runat="server" data-options="multiline:true" style="height: 100px; width: 100%;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="saveResource()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
