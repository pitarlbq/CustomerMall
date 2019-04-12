<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditGongTanFee.aspx.cs" Inherits="Web.SetupFee.EditGongTanFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ChargeTypeList = [];
        var CategoryList = [];
        var EndNumberList = []
        $(function () {
            getChargeTypeList();
            getCategoryList();
            getEndNumberList();
            $("#<%=this.tdChargeType.ClientID%>").combobox({
                data: ChargeTypeList,
                valueField: 'ID',
                textField: 'Name'
            });
            $("#<%=this.tdChargeType.ClientID%>").combobox('setValue', $("#<%=this.hdChargeType.ClientID%>").val());
            $("#<%=this.tdCategory.ClientID%>").combobox({
                data: CategoryList,
                valueField: 'ID',
                textField: 'Name'
            });
            $("#<%=this.tdCategory.ClientID%>").combobox('setValue', $("#<%=this.hdCategory.ClientID%>").val());
            $("#<%=this.tdEndNumber.ClientID%>").combobox({
                data: EndNumberList,
                valueField: 'ID',
                textField: 'Name'
            });
            $("#<%=this.tdEndNumber.ClientID%>").combobox('setValue', $("#<%=this.hdEndNumber.ClientID%>").val());
        })

        function getChargeTypeList() {
            ChargeTypeList.push({ ID: 1, Name: "单价*计费面积(月度)" });
            ChargeTypeList.push({ ID: 2, Name: "定额(月度)" });
        }
        function getCategoryList() {
            CategoryList.push({ ID: 1, Name: "收入" });
            CategoryList.push({ ID: 2, Name: "代收" });
            CategoryList.push({ ID: 3, Name: "押金" });
            CategoryList.push({ ID: 4, Name: "预收" });
        }
        function getEndNumberList() {
            EndNumberList.push({ ID: 1, Name: "整数" });
            EndNumberList.push({ ID: 2, Name: "凑整" });
            EndNumberList.push({ ID: 3, Name: "四舍五入" });
        }
        function addfee() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            var id = "<%=Request.QueryString["ID"]%>";
            var name = $("#<%=this.tdName.ClientID%>").textbox("getValue");
            var chargetype = $("#<%=this.tdChargeType.ClientID%>").combobox("getValue");
            var endnumber = $("#<%=this.tdEndNumber.ClientID%>").combobox("getValue");
            var category = $("#<%=this.tdCategory.ClientID%>").combobox("getValue");
            var summaryunitprice = $("#<%=this.tdSummaryUnitPrice.ClientID%>").numberbox("getValue");
            var sortorder = $("#<%=this.tdOrderBy.ClientID%>").numberbox("getValue");
            var options = { visit: 'savesummaryfee', id: id, name: name, chargetype: chargetype, endnumber: endnumber, category: category, summaryunitprice: summaryunitprice, coefficient: 1, unit: "", sortorder: sortorder, CompanyID: "<%=Web.WebUtil.GetCompanyID(this.Context)%>", FeeType: 3, IsReading: $("#<%=this.tdIsReading.ClientID%>").combobox("getValue") };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
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
    <form id="ff" runat="server" method="post">
        <table class="add">
            <tr>
                <td>收费项目
                </td>
                <td>
                    <input id="tdName" class="easyui-textbox" runat="server" type="text" data-options="required:true" />
                </td>
                <td>计费方式
                </td>
                <td>
                    <input class="easyui-combobox" id="tdChargeType" runat="server"
                        data-options="required:true" />
                    <asp:HiddenField runat="server" ID="hdChargeType" />
                </td>
            </tr>
            <tr>
                <td>尾数
                </td>
                <td>
                    <input class="easyui-combobox" id="tdEndNumber" runat="server"
                        data-options="required:true" />
                    <asp:HiddenField runat="server" ID="hdEndNumber" />
                </td>
                <td>科目类别
                </td>
                <td>
                    <input class="easyui-combobox" id="tdCategory" runat="server"
                        data-options="required:true" />
                    <asp:HiddenField runat="server" ID="hdCategory" />
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td>单价
                </td>
                <td>
                    <input id="tdSummaryUnitPrice" class="easyui-numberbox" runat="server" type="text" data-options="required:true,precision:4" />
                </td>
                <td>序号
                </td>
                <td>
                    <input id="tdOrderBy" class="easyui-numberbox" runat="server" type="text" />
                </td>
            </tr>
            <tr>
                <td>是否抄表
                </td>
                <td colspan="3">
                    <select id="tdIsReading" runat="server" class="easyui-combobox" style="width: 200px;">
                        <option value="0">否</option>
                        <option value="1">是</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a id="btn" href="javascript:void(0)" class="savebutton" onclick="addfee()" data-options="iconCls:'icon-add'"></a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
