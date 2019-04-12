<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="DeviceRepairCheckView.aspx.cs" Inherits="Web.Device.DeviceRepairCheckView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var TaskType, DeviceID;
        $(function () {
            DeviceID = "<%=this.DeviceID%>";
            TaskType = "<%=this.TaskType%>";
        })
    </script>
    <script src="../js/Page/Device/DeviceRepairCheckView.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="form1">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north',border:false" style="height: 30px; font-size: 12px; padding: 40px 10px 5px 5px;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
            </div>
        </div>
    </form>
</asp:Content>
