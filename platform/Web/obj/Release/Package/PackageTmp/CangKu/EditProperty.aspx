<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditProperty.aspx.cs" Inherits="Web.CangKu.EditProperty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var op;
        $(function () {
            op = "<%=this.op%>";
            loadComboboxParams();
            $('#<%=this.tdPropertyCount.ClientID%>').textbox({
                onChange: function () {
                    calculate_totalcost();
                }
            })
            $('#<%=this.tdPropertyUnitPrice.ClientID%>').textbox({
                onChange: function () {
                    calculate_totalcost();
                }
            })
        });
        function calculate_totalcost() {
            var cost = 0;
            var count = $('#<%=this.tdPropertyCount.ClientID%>').textbox('getValue');
            var unitprice = $('#<%=this.tdPropertyUnitPrice.ClientID%>').textbox('getValue');
            if (count != '' && unitprice != '') {
                cost = (parseFloat(count) * parseFloat(unitprice)).toFixed(2);
            }
            $('#<%=this.tdPropertyCost.ClientID%>').textbox('setValue', cost);
            $('#<%=this.tdPropertyRealCost.ClientID%>').textbox('setValue', cost);
            return cost;
        }
        function loadComboboxParams() {
            var categoryData = $("#<%=hdCategories.ClientID%>").val();
            var category_list = [];
            if (categoryData != "") {
                category_list = eval("(" + categoryData + ")");
            }
            $("#<%=this.tdPropertyCategory.ClientID%>").combobox({
                editable: false,
                data: category_list,
                valueField: 'ID',
                textField: 'PropertyCategoryName',
            });
            var changetype_list = [];
            changetype_list.push({ ID: "购入", Value: "购入" });
            changetype_list.push({ ID: "报废", Value: "报废" });
            changetype_list.push({ ID: "租赁", Value: "租赁" });
            changetype_list.push({ ID: "其他", Value: "其他" });
            $("#<%=this.tdPropertyChangeType.ClientID%>").combobox({
                editable: false,
                data: changetype_list,
                valueField: 'ID',
                textField: 'Value',
            });

            var state_list = [];
            state_list.push({ ID: "1", Value: "在用" });
            state_list.push({ ID: "2", Value: "封存" });
            state_list.push({ ID: "3", Value: "待报废" });
            state_list.push({ ID: "4", Value: "报废" });
            state_list.push({ ID: "5", Value: "租赁" });
            state_list.push({ ID: "6", Value: "出租" });
            $("#<%=this.tdPropertyState.ClientID%>").combobox({
                editable: false,
                data: state_list,
                valueField: 'ID',
                textField: 'Value',
            });

            var departmentData = $("#<%=this.hdDepartments.ClientID%>").val();
            var department_list = [];
            if (departmentData != "") {
                department_list = eval("(" + departmentData + ")");
            }
            $("#<%=this.tdPropertyDepartment.ClientID%>").combobox({
                editable: false,
                data: department_list,
                valueField: 'ID',
                textField: 'DepartmentName',
            });
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.PropertyID%>";
            var PropertyCategoryID = $("#<%=this.tdPropertyCategory.ClientID%>").combobox("getValue");
            var PropertyNo = $("#<%=this.tdPropertyNo.ClientID%>").textbox("getValue");
            var PropertyName = $("#<%=this.tdPropertyName.ClientID%>").textbox("getValue");
            var PropertyModelNo = $("#<%=this.tdPropertyModelNo.ClientID%>").textbox("getValue");
            var PropertyUnit = $("#<%=this.tdPropertyUnit.ClientID%>").textbox("getValue");
            var PropertyCount = $("#<%=this.tdPropertyCount.ClientID%>").textbox("getValue");
            var PropertyUnitPrice = $("#<%=this.tdPropertyUnitPrice.ClientID%>").textbox("getValue");
            var PropertyPurchaseDate = $("#<%=this.tdPropertyPurchaseDate.ClientID%>").datebox("getValue");
            var PropertyUseYear = $("#<%=this.tdPropertyUseYear.ClientID%>").textbox("getValue");
            var PropertyRealCost = $("#<%=this.tdPropertyRealCost.ClientID%>").textbox("getValue");
            var PropertyDiscountCost = $("#<%=this.tdPropertyDiscountCost.ClientID%>").textbox("getValue");
            var PropertyChangeType = $("#<%=this.tdPropertyChangeType.ClientID%>").combobox("getValue");
            var PropertyState = $("#<%=this.tdPropertyState.ClientID%>").combobox("getValue");
            var PropertyDepartmentID = $("#<%=this.tdPropertyDepartment.ClientID%>").combobox("getValue");
            var PropertyLocation = $("#<%=this.tdPropertyLocation.ClientID%>").textbox("getValue");
            var PropertyUseMan = $("#<%=this.tdPropertyUseMan.ClientID%>").textbox("getValue");
            var PropertyContractName = $("#<%=this.tdPropertyContractName.ClientID%>").textbox("getValue");
            var PropertyContactPhone = $("#<%=this.tdPropertyContactPhone.ClientID%>").textbox("getValue");
            var PropertyRemark = $("#<%=this.tdPropertyRemark.ClientID%>").textbox("getValue");
            var options = { visit: 'saveckproperty', ID: ID, PropertyCategoryID: PropertyCategoryID, PropertyNo: PropertyNo, PropertyName: PropertyName, PropertyModelNo: PropertyModelNo, PropertyUnit: PropertyUnit, PropertyCount: PropertyCount, PropertyUnitPrice: PropertyUnitPrice, PropertyPurchaseDate: PropertyPurchaseDate, PropertyUseYear: PropertyUseYear, PropertyRealCost: PropertyRealCost, PropertyDiscountCost: PropertyDiscountCost, PropertyChangeType: PropertyChangeType, PropertyState: PropertyState, PropertyDepartmentID: PropertyDepartmentID, PropertyLocation: PropertyLocation, PropertyUseMan: PropertyUseMan, PropertyContractName: PropertyContractName, PropertyContactPhone: PropertyContactPhone, PropertyRemark: PropertyRemark, op: op };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CKHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (message.error) {
                        show_message(message.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
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
            <%if (!this.op.Equals("view"))
              {%>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%} %>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>资产类别
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdPropertyCategory" runat="server" data-options="required:true" />
                        <asp:HiddenField runat="server" ID="hdCategories" />
                    </td>
                    <td>资产编号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdPropertyNo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>资产名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdPropertyName" runat="server" data-options="required:true" />
                    </td>
                    <td>规格型号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdPropertyModelNo" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>单位
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyUnit" runat="server" />
                    </td>
                    <td>数量
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyCount" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>单价
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyUnitPrice" runat="server" />
                    </td>
                    <td>购入金额
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" data-options="disabled:true" id="tdPropertyCost" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>购入时间
                    </td>
                    <td>
                        <input type="text" class="easyui-datebox" style="" id="tdPropertyPurchaseDate" runat="server" />
                    </td>
                    <td>预计使用年限
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyUseYear" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>净值
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyRealCost" runat="server" />
                    </td>
                    <td>折旧金额
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyDiscountCost" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>变动方式
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" style="" id="tdPropertyChangeType" runat="server" />
                    </td>
                    <td>状态
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" style="" id="tdPropertyState" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>使用部门
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" style="" id="tdPropertyDepartment" runat="server" />
                        <asp:HiddenField runat="server" ID="hdDepartments" />
                    </td>
                    <td>存放地点
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyLocation" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>使用人员
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyUseMan" runat="server" />
                    </td>
                    <td>供应商
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyContractName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>联系方式
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" style="" id="tdPropertyContactPhone" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" style="height: 60px; width: 50%;" data-options="multiline:true" id="tdPropertyRemark" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
