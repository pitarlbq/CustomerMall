<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomSourceFee.aspx.cs" Inherits="Web.SetupFee.EditRoomSourceFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ChargeNameObj, HDChargeNameObj, UnitPriceObj, ChargeTypeObj, hdChargeTypeObj, StartTimeObj, EndTimeObj, RemarkObj, ID, op, CompanyID, NewEndTimeObj;
        $(function () {
            ChargeNameObj = $("#<%=this.tdChargeName.ClientID%>");
            HDChargeNameObj = $("#<%=this.hdChargeName.ClientID%>");
            UnitPriceObj = $("#<%=this.tdUnitPrice.ClientID%>");
            ChargeTypeObj = $("#<%=this.tdChargeType.ClientID%>");
            hdChargeTypeObj = $("#<%=this.hdChargeType.ClientID%>");
            StartTimeObj = $("#<%=this.tdStartTime.ClientID%>");
            EndTimeObj = $("#<%=this.tdEndTime.ClientID%>");
            NewEndTimeObj = $("#<%=this.tdNewEndTime.ClientID%>");
            RemarkObj = $("#<%=this.tdRemark.ClientID%>");
            ID = "<%=Request.QueryString["ID"]%>";
            op = "<%=Request.QueryString["op"]%>";
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            EndTimeObj.datebox("setValue", $("#<%=this.hdEndTime.ClientID%>").val());
            NewEndTimeObj.datebox("setValue", $("#<%=this.hdNewEndTime.ClientID%>").val());
            setTimeout(function () {
                StartTimeObj.datebox({
                    onChange: function (res) {
                        getEndTime(res);
                    }
                })
            }, 1000);
        })
        function getEndTime(StartTime) {
            var options = { visit: "getendtime", StartTime: StartTime, ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.EndTime != "") {
                        EndTimeObj.datebox('setValue', data.EndTime);
                    }
                }
            });
        }
    </script>
    <script src="../js/Page/Comm/GetTypeList.js?token=<%=base.getToken() %>"></script>
    <script src="../js/Page/SetupFee/EditRoomSourceFee.js?token=<%=base.getToken() %>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="form1" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>资源位置</td>
                    <td colspan="3">
                        <input type="text" style="width: 80%;" class="easyui-textbox" runat="server" id="tdFullName" data-options="disabled:true" /></td>
                </tr>
                <tr>
                    <td>房号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdName" data-options="disabled:true" /></td>
                    <td>收费项目</td>
                    <td>
                        <input type="text" class="easyui-combobox" runat="server" id="tdChargeName" />
                        <asp:HiddenField ID="hdChargeName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>单价(月度)</td>
                    <td>
                        <input type="text" id="tdUnitPrice" class="easyui-numberbox" runat="server" data-options="min:0,precision:3" />
                    </td>

                    <td>计费规则</td>
                    <td>
                        <input type="text" class="easyui-combobox" runat="server" id="tdChargeType" data-options="disabled:true" />
                        <asp:HiddenField ID="hdChargeType" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>计费开始日期</td>
                    <td>
                        <input class="easyui-datebox" id="tdStartTime" runat="server" />
                        <asp:HiddenField runat="server" ID="hdStartTime" />
                    </td>
                    <td>计费结束日期</td>
                    <td>
                        <input class="easyui-datebox" id="tdEndTime"  runat="server"/>
                        <asp:HiddenField runat="server" ID="hdEndTime" />
                    </td>
                </tr>
                <tr>
                    <td>计费停用日期</td>
                    <td colspan="3">
                        <input class="easyui-datebox" id="tdNewEndTime"  runat="server"/>
                        <asp:HiddenField runat="server" ID="hdNewEndTime" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" runat="server" id="tdRemark" style="height: 60px; width: 80%;" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
