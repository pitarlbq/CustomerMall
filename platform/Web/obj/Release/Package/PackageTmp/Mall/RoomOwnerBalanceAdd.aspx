<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RoomOwnerBalanceAdd.aspx.cs" Inherits="Web.Mall.RoomOwnerBalanceAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var RoomID, tdUserName, hdUserID, hdRelationID, labelFullName, tdBalanceRuleID, tdTotalCost, tdBalanceAmount, hdMemberLevelName, labelMemberLevel, hdProjectID, tdTotalCost, TotalRestCost = 0, labelTotalCost;
        $(function () {
            tdUserName = $('#<%=this.tdUserName.ClientID%>');
            hdUserID = $('#<%=this.hdUserID.ClientID%>');
            hdRelationID = $('#<%=this.hdRelationID.ClientID%>');
            hdProjectID = $('#<%=this.hdProjectID.ClientID%>');
            labelFullName = $('#<%=this.labelFullName.ClientID%>');
            tdBalanceRuleID = $('#<%=this.tdBalanceRuleID.ClientID%>');
            tdTotalCost = $('#<%=this.tdTotalCost.ClientID%>');
            tdBalanceAmount = $('#<%=this.tdBalanceAmount.ClientID%>');
            hdMemberLevelName = $('#<%=this.hdMemberLevelName.ClientID%>');
            tdTotalCost = $('#<%=this.tdTotalCost.ClientID%>');
            labelTotalCost = $('#<%=this.labelTotalCost.ClientID%>');
            get_parent_data();
            get_params();
        })
        function get_parent_data() {
            var row = parent.$("#tt_table").datagrid("getSelected");
            if (row == null) {
                show_message('请选择待结算房间', "info");
                return;
            }
            RoomID = row.RoomID;
            hdProjectID.val(row.RoomID);
            labelFullName.text(row.FinalFullName);
            labelTotalCost.text(row.TotalRestCost);
            TotalRestCost = row.TotalRestCost;
            tdTotalCost.textbox('setValue', TotalRestCost);
        }
        function get_params() {
            var options = {
                visit: 'getroomownerbalanceaddparams',
            };
            MaskUtil.mask('body');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        tdBalanceRuleID.combobox({
                            data: data.rulelist,
                            valueField: "ID",
                            textField: "Title",
                            editable: false,
                            onSelect: function (res) {
                                calculate_balance(res.BackAmount, res.BackBalanceType);
                            }
                        })
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, "info");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        };
        function calculate_balance(BackAmount, BackBalanceType) {
            var balance = BackAmount;
            if (BackBalanceType == 1) {
                var TotalCost = tdTotalCost.textbox('getValue');
                balance = ((TotalCost * BackAmount) / 100).toFixed(2);
            }
            tdBalanceAmount.textbox('setValue', balance);
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var RelationID = hdRelationID.val();
            if (RelationID == '') {
                show_message('请选择业主', "info");
                return;
            }
            var FinalTotalRestCost = tdTotalCost.textbox('getValue');
            FinalTotalRestCost = parseFloat(FinalTotalRestCost, 10);
            if (FinalTotalRestCost > TotalRestCost) {
                show_message('本期待结算金额不能超过未结算金额', "info");
                return;
            }
            if (FinalTotalRestCost <= 0) {
                show_message('本期待结算金额不能小于0', "info");
                return;
            }
            var BalanceAmount = tdBalanceAmount.textbox('getValue');
            BalanceAmount = parseFloat(BalanceAmount, 10);
            if (BalanceAmount <= 0) {
                show_message('返现金额不能小于0', "info");
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallroomownerbalance';
                    param.UserID = hdUserID.val();
                    param.RelationID = hdRelationID.val();
                    param.MemberLevelName = hdMemberLevelName.val();
                    param.ProjectID = hdProjectID.val();
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
        function choose_user() {
            var title = '选择用户';
            var iframe = "../APPSetup/ChooseProjectUser.aspx?singleselect=1&ProjectID=" + RoomID;
            do_open_dialog(title, iframe);
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
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>业主
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdUserName" runat="server" data-options="multiline:true,editable:false" />
                        <asp:HiddenField runat="server" ID="hdProjectID" />
                        <asp:HiddenField runat="server" ID="hdUserID" />
                        <asp:HiddenField runat="server" ID="hdRelationID" />
                        <asp:HiddenField runat="server" ID="hdMemberLevelName" />
                        <a href="javascript:void(0)" onclick="choose_user()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                    </td>
                </tr>
                <tr>
                    <td>房源信息
                    </td>
                    <td colspan="3">
                        <label runat="server" id="labelFullName"></label>
                    </td>
                </tr>
                <tr>
                    <td>待结算总金额
                    </td>
                    <td colspan="3">
                        <label runat="server" id="labelTotalCost"></label>
                    </td>
                </tr>
                <tr>
                    <td>本期待结算金额
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdTotalCost" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>结算规则
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-combobox" id="tdBalanceRuleID" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>返现金额
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdBalanceAmount" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
