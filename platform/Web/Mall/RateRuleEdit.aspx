<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RateRuleEdit.aspx.cs" Inherits="Web.Mall.RateRuleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdUseForALL, hdProducts, tdProducts;
        $(function () {
            ID = "<%=this.RuleID%>";
            tdUseForALL = $("#<%=this.tdUseForALL.ClientID%>");
            hdProducts = $("#<%=this.hdProducts.ClientID%>");
            tdProducts = $("#<%=this.tdProducts.ClientID%>");
            tdUseForALL.combobox({
                onSelect: function () {
                    choose_status();
                }
            })
            choose_status();
        });
        function choose_status() {
            var UseForALL = tdUseForALL.combobox('getValue');
            if (UseForALL == '1') {
                $('.choose_product').hide();
            }
            else {
                $('.choose_product').show();
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
                    param.visit = 'savemallpointrule';
                    param.ID = ID;
                    param.ProductIDList = hdProducts.val();
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message('数据不存在或已删除', 'warning');
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
        var isupdate = false;
        function chooseproduct() {
            isupdate = false;
            var title = "选择商品";
            var iframe = "../Mall/ChooseProduct.aspx?from=RateRuleEdit";
            do_open_dialog(title, iframe);
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
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
                        <input type="text" class="easyui-textbox" runat="server" id="tdRuleName" data-options="required:true" /></td>
                    <td>状态</td>
                    <td>
                        <select runat="server" id="tdRuleStatus" class="easyui-combobox" data-options="editable:false,required:true">
                            <option value="1">有效</option>
                            <option value="0">失效</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>规则简介
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 85%; height: 60px;" runat="server" id="tdSummary" /></td>
                </tr>
                <tr>
                    <td>有效时间
                    </td>
                    <td colspan="3">
                        <input type="text" runat="server" id="tdStartTime" class="easyui-datetimebox" />
                        -
                    <input type="text" runat="server" id="tdEndTime" class="easyui-datetimebox" />
                    </td>
                </tr>
                <tr>
                    <td>规则类型
                    </td>
                    <td colspan="3">
                        <select runat="server" id="tdRuleType" class="easyui-combobox" data-options="editable:false,required:true">
                            <option value="1">购买商品返还</option>
                        </select></td>
                </tr>
                <tr>
                    <td>使用范围
                    </td>
                    <td>
                        <select runat="server" id="tdUseForALL" class="easyui-combobox" data-options="editable:false,required:true">
                            <option value="1">所有商品</option>
                            <option value="0">限制商品</option>
                        </select></td>
                    <td class="choose_product">选择商品</td>
                    <td class="choose_product">
                        <input type="text" class="easyui-textbox" id="tdProducts" runat="server" data-options="multiline:true,readonly:true" style="height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdProducts" />
                        <label>
                            <a href="javascript:void(0)" onclick="chooseproduct()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>使用规则
                    </td>
                    <td colspan="3">
                        <label>
                            购买满1元返回
                        <input type="text" runat="server" id="tdReturnPoint" class="easyui-textbox" data-options="required:true" />
                            个积分
                        </label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
