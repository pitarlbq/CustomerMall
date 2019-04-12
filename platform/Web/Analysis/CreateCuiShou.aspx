<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CreateCuiShou.aspx.cs" Inherits="Web.Analysis.CreateCuiShou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            loadChargeType();
        });
        function loadChargeType() {
            var options = { visit: 'loadcreatecuishouparas' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    $("#tdChargeType").combobox({
                        editable: false,
                        data: data.typelist,
                        valueField: 'ChargeTypeID',
                        textField: 'ChargeTypeName',
                    });
                    $("#tdChargeType").combobox("setValue", data.typelist[0].ChargeTypeID);
                    $("#tdChargeMan").combobox({
                        editable: false,
                        data: data.userlist,
                        valueField: 'UserID',
                        textField: 'RealName',
                    });
                    $("#tdChargeMan").combobox("setValue", data.userlist[0].UserID);
                }
            });
        }
        function do_save() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message('请选择一条单据，操作取消', 'warning');
                return;
            }
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            top.$.messager.confirm("提示", "确认生成催收单", function (r) {
                if (r) {
                    var RoomFeeIDList = [];
                    $.each(rows, function (index, row) {
                        RoomFeeIDList.push(row.ID);
                    });
                    var CompanyName = "<%=Web.WebUtil.GetCompany(this.Context).CompanyName%>";
                    var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
                    var ChargeMan = $("#tdChargeMan").combobox('getText');
                    var ChargeType = $("#tdChargeType").combobox('getValue');
                    var ChargeTime = $("#tdChargeTime").datetimebox('getValue');
                    var Remark = $("#tdRemark").textbox('getValue');
                    var StartTime = parent.tdStartTime.datebox('getValue');
                    var EndTime = parent.tdEndTime.datebox('getValue');
                    MaskUtil.mask('body', '提交中');
                    var options = { visit: "createcuishou", IDs: JSON.stringify(RoomFeeIDList), CompanyName: CompanyName, AddMan: AddMan, ChargeMan: ChargeMan, ChargeType: ChargeType, ChargeTime: ChargeTime, Remark: Remark, EndTime: EndTime };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/PrintHandler.ashx',
                        data: options,
                        success: function (data) {
                            MaskUtil.unmask();
                            if (data.status) {
                                show_message('操作成功', 'success');
                                do_close();
                                return;
                            }
                            if (data.msg) {
                                show_message(data.msg, 'warning');
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid('reload');
            });
        }
    </script>
    <style>
        table.info {
            margin: 0 auto;
            width: 90%;
            border-collapse: collapse;
            border-spacing: 0;
            border: solid 1px #ccc;
        }

            table.info td {
                padding: 5px 10px;
                text-align: left;
                vertical-align: middle;
                border: solid 1px #ccc;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

            table.info input, table.info select {
                width: 200px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="#" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">生成</a>
            <a href="#" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>收款人：
                    </td>
                    <td>
                        <input id="tdChargeMan" type="text" class="easyui-combobox" data-options="required:true" />
                    </td>
                    <td>收款方式：
                    </td>
                    <td>
                        <input id="tdChargeType" type="text" class="easyui-combobox" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>收款日期：
                    </td>
                    <td colspan="3">
                        <input id="tdChargeTime" type="text" class="easyui-datetimebox" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>备注：
                    </td>
                    <td colspan="3">
                        <input id="tdRemark" type="text" data-options="multiline:true" style="height: 60px;" class="easyui-textbox" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;"></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
