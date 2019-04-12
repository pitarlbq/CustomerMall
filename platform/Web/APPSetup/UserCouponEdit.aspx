<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCouponEdit.aspx.cs" Inherits="Web.APPSetup.UserCouponEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID = 0;
        $(function () {
            ID = "<%=this.ID%>";
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallusercoupon';
                    param.ID = ID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
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
                    <td>用户昵称
                    </td>
                    <td>
                        <label runat="server" id="label_NickName"></label>
                    </td>
                    <td>电话号码
                    </td>
                    <td>
                        <label runat="server" id="label_PhoneNumber"></label>
                    </td>
                </tr>
                <tr>
                    <td>卡券名称</td>
                    <td>
                        <label runat="server" id="label_CouponName"></label>
                    </td>
                    <td>卡券类型</td>
                    <td>
                        <label runat="server" id="label_CouponType"></label>
                    </td>
                </tr>
                <tr>
                    <td>使用范围
                    </td>
                    <td colspan="3">
                        <label runat="server" id="label_UseFor"></label>
                    </td>
                </tr>
                <tr>
                    <td>使用规则
                    </td>
                    <td colspan="3">
                        <label runat="server" id="label_UseRule"></label>
                    </td>
                </tr>
                <tr>
                    <td>状态</td>
                    <td colspan="3">
                        <select runat="server" id="tdIsActive" class="easyui-combobox" data-options="editable:false">
                            <option value="1">有效</option>
                            <option value="0">失效</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>有效时间
                    </td>
                    <td colspan="3">
                        <input type="text" runat="server" id="tdStartTime" class="easyui-datebox" />
                        - 
                        <input type="text" runat="server" id="tdEndTime" class="easyui-datebox" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
