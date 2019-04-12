<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BalanceRuleEdit.aspx.cs" Inherits="Web.Mall.BalanceRuleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdBackBalanceType;
        $(function () {
            ID = "<%=this.RuleID%>";
            tdBackBalanceType = $('#<%=this.tdBackBalanceType.ClientID%>');
            tdBackBalanceType.combobox({
                onSelect: function () {
                    choose_status();
                }
            })
            choose_status();
        });
        function choose_status() {
            var BackBalanceType = tdBackBalanceType.combobox('getValue');
            if (BackBalanceType == '2') {
                $('#spanAmountName').text('结算金额');
                $('#spanAmountType').text('元');
            }
            else {
                $('#spanAmountName').text('结算比例');
                $('#spanAmountType').text('%');
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallbalancerule';
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
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.$('#winadd').window('close');
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>规则名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdTitle" data-options="required:true" /></td>
                    <td>状态</td>
                    <td>
                        <select runat="server" id="tdIsActive" class="easyui-combobox" data-options="editable:false">
                            <option value="1">有效</option>
                            <option value="0">失效</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>规则类型</td>
                    <td>
                        <select runat="server" id="tdRuleType" class="easyui-combobox" data-options="editable:false">
                            <option value="1">商家结算</option>
                            <option value="2">业主结算</option>
                        </select>
                    </td>
                    <td>规则简介
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 300px; height: 60px;" runat="server" id="tdRemark" /></td>
                </tr>
                <tr>
                    <td>结算类型
                    </td>
                    <td>
                        <select runat="server" id="tdBackBalanceType" class="easyui-combobox" data-options="editable:false">
                            <option value="2">固定金额</option>
                            <option value="1">百分比</option>
                        </select></td>
                    <td><span id="spanAmountName">结算金额</span>
                    </td>
                    <td>
                        <input type="text" runat="server" id="tdBackAmount" class="easyui-textbox" />(<span id="spanAmountType"></span>)
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
