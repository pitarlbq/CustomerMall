<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddNormalSummaryFee.aspx.cs" Inherits="Web.SetupFee.AddNormalSummaryFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        $(function () {
            $("#tbChargeType").combobox({
                data: getChargeTypeList(),
                valueField: 'ID',
                textField: 'Name'
            });
            $('#tbChargeType').combobox('setValue', '1');
            $("#tbEndNumber").combobox({
                data: getEndNumberList(),
                valueField: 'ID',
                textField: 'Name'
            });
            $('#tbEndNumber').combobox('setValue', '1');
        });
        function addfee() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            var Name = $("#tbSummaryName").textbox("getValue");
            var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            var TypeID = $("#tbChargeType").combobox("getValue");
            var OrderBy = $("#tbSortOrder").numberbox("getValue");
            var AllowImport = $("#tbAllowImport").combobox("getValue");
            var EndNumberCount = $("#tbEndNumberCount").numberbox("getValue");
            var FeeType = "<%=Request.QueryString["FeeType"]%>";
            var options = { visit: "addchargesummary", Name: Name, CompanyID: CompanyID, FeeType: FeeType, TypeID: TypeID, OrderBy: OrderBy, CategoryID: 1, RuleID: 1, EndNumber: 3, AllowImport: AllowImport, EndNumberCount: EndNumberCount };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: '../Handler/FeeCenterHandler.ashx',
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('添加成功', 'success', function () {
                            parent.$("#winadd").window("close");
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        table.add {
            width: 80%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
        }

            table.add td {
                padding: 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" method="post">
        <table class="add">
            <tr>
                <td>费用名称
                </td>
                <td>
                    <input id="tbSummaryName" class="easyui-textbox" type="text" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>计费方式
                </td>
                <td>
                    <input class="easyui-combobox" id="tbChargeType"
                        data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>允许导入费用
                </td>
                <td>
                    <select class="easyui-combobox" id="tbAllowImport" data-options="required:true">
                        <option value="1">是</option>
                        <option value="0">否</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>小数位数
                </td>
                <td>
                    <input class="easyui-numberbox" id="tbEndNumberCount"
                        data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>排序
                </td>
                <td>
                    <input class="easyui-numberbox" id="tbSortOrder" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <a id="btn" href="javascript:void(0)" class="savebutton" onclick="addfee()" data-options="iconCls:'icon-add'"></a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
