<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditContractCharge.aspx.cs" Inherits="Web.Contract.EditContractCharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, ContractID, canedit;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
            ContractID = "<%=this.ContractID%>";
            canedit = "<%=this.Request.QueryString["canedit"]%>" || 0;
            getAllParams();
        });
        function getAllParams() {
            var options = { visit: 'getaddcontractchargeparam', guid: "", ContractID: ContractID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        $('#<%=this.tdChargeID.ClientID%>').combobox({
                            editable: true,
                            data: data.chargelist,
                            valueField: 'ID',
                            textField: 'Name',
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_save() {
            var UnitPrice = $("#<%=this.tdUnitPrice.ClientID%>").textbox('getValue');
            var StartTime = $("#<%=this.tdStartTime.ClientID%>").datebox('getValue');
            var EndTime = $("#<%=this.tdEndTime.ClientID%>").datebox('getValue');
            var NewEndTime = $("#<%=this.tdNewEndTime.ClientID%>").datebox('getValue');
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox('getValue');
            var RoomCost = $("#<%=this.tdTotalCost.ClientID%>").textbox('getValue');
            var RoomUseCount = $("#<%=this.tdRoomUseCount.ClientID%>").textbox('getValue');
            var ReadyChargeTime = $("#<%=this.tdReadyChargeTime.ClientID%>").datetimebox('getValue');
            var options = { visit: 'editcontractcharge', ID: ID, UnitPrice: UnitPrice, StartTime: StartTime, EndTime: EndTime, NewEndTime: NewEndTime, Remark: Remark, RoomCost: RoomCost, RoomUseCount: RoomUseCount, canedit: canedit, ReadyChargeTime: ReadyChargeTime };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        createFee();
                        return;
                    }
                    else if (message.msg) {
                        show_message(message.msg, "warning");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function createFee() {
            var IDList = [];
            IDList.push(ContractID);
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'createcontractfee', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_chargesummary').datagrid("reload");
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
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info">
            <tr>
                <td>房源位置</td>
                <td>
                    <input type="text" runat="server" class="easyui-textbox" data-options="disabled:true" id="tdFullName" /></td>
                <td>房号</td>
                <td>
                    <input type="text" runat="server" class="easyui-textbox" data-options="disabled:true" id="tdRoomName" /></td>
            </tr>
            <tr>
                <td>收费标准</td>
                <td>
                    <input type="text" runat="server" class="easyui-combobox" data-options="disabled:true" id="tdChargeID" /></td>
                <td>单价</td>
                <td>
                    <input type="text" runat="server" class="easyui-textbox" id="tdUnitPrice" /></td>
            </tr>
            <tr>
                <td>计费开始日期</td>
                <td>
                    <input type="text" runat="server" class="easyui-datebox" id="tdStartTime" /></td>
                <td>计费结束日期</td>
                <td>
                    <input type="text" runat="server" class="easyui-datebox" id="tdEndTime" /></td>
            </tr>
            <tr>
                <td>计费停用日期</td>
                <td>
                    <input type="text" runat="server" class="easyui-datebox" id="tdNewEndTime" /></td>
                <td>收费日期</td>
                <td>
                    <input type="text" runat="server" class="easyui-datebox" id="tdReadyChargeTime" /></td>

            </tr>
            <tr>
                <td>合同金额</td>
                <td>
                    <input type="text" runat="server" class="easyui-textbox" id="tdTotalCost" />(为空时自动计算金额)</td>
                <td>合同面积</td>
                <td>
                    <input type="text" runat="server" class="easyui-textbox" id="tdRoomUseCount" /></td>
            </tr>
            <tr>
                <td>备注</td>
                <td colspan="3">
                    <input style="width: 80%; height: 50px;" data-options="multiline:true" type="text" runat="server" class="easyui-textbox" id="tdRemark" /></td>
            </tr>
        </table>
    </div>
</asp:Content>
