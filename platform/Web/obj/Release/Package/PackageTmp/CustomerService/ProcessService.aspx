<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProcessService.aspx.cs" Inherits="Web.CustomerService.ProcessService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, guid, tdHandelFeeObj, tdTotalFeeObj, ffObj, tdIsRequireProduct;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
            guid = "<%=this.guid%>";
            tdHandelFeeObj = $("#<%=this.tdHandelFee.ClientID%>");
            tdTotalFeeObj = $("#<%=this.tdTotalFee.ClientID%>");
            ffObj = $("#<%=this.ff.ClientID%>");
            tdIsRequireProduct = $("#<%=this.tdIsRequireProduct.ClientID%>");
        });
    </script>
    <script src="../js/Page/CustomerService/ServiceProcess.js?t=<%=base.getToken() %>"></script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <%if ((service.ServiceStatus == 0 || service.ServiceStatus == 3 || service.ServiceStatus == 10) && !this.op.Equals("view"))
              { %>
            <table class="info">
                <tr>
                    <td>接单人</td>
                    <td>
                        <input type="text" runat="server" name="AcceptMan" data-options="disabled:true" class="easyui-textbox" id="tdAcceptMan" /></td>
                    <td>预约时间</td>
                    <td>
                        <input type="text" runat="server" name="AppointTime" data-options="disabled:true" class="easyui-datetimebox" id="tdAppointTime" /></td>
                </tr>
                <tr>
                    <td>维修工费</td>
                    <td>
                        <input type="text" runat="server" name="HandelFee" class="easyui-textbox" id="tdHandelFee" /></td>
                    <td>收费金额</td>
                    <td>
                        <input type="text" runat="server" name="TotalFee" class="easyui-textbox" id="tdTotalFee" /></td>

                </tr>
                <tr>
                    <td>处理时间</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" name="ChuLiTime" class="easyui-datetimebox" id="tdChuLiTime" /></td>
                    <td colspan="2" style="text-align: left;">
                        <label>
                            <input type="checkbox" id="tdIsRequireProduct" runat="server" />领料登记
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>处理情况</td>
                    <td colspan="3">
                        <input type="text" runat="server" name="td" class="easyui-textbox" id="tdChuLiNote" data-options="multiline:true" style="width: 100%; height: 60px;" /></td>
                </tr>
            </table>
            <div class="easyui-panel" id="divProductPanel" style="height: 350px;">
                <table id="tt_table">
                </table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
            <%}%>
            <asp:Repeater runat="server" ID="rptRecord" OnItemDataBound="rptRecord_ItemDataBound">
                <HeaderTemplate>
                    <table class="info" style="margin-top: 10px">
                        <tr>
                            <td colspan="4" style="text-align: center;">处理历史记录
                            </td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>维修工费</td>
                        <td style="width: 20%;"><%# ((decimal)Eval("HandelFee")) <=0 ? 0 : (decimal)Eval("HandelFee")%></td>
                        <td>收费金额</td>
                        <td style="width: 50%;"><%# (((decimal)Eval("OtherFee")) <=0 ? 0 : (decimal)Eval("OtherFee"))+(((decimal)Eval("HandelFee")) <=0 ? 0 : (decimal)Eval("HandelFee"))%></td>
                    </tr>
                    <tr>
                        <td>处理时间</td>
                        <td style="width: 20%;"><%# ((DateTime)Eval("ChuliDate")) == DateTime.MinValue ? "" : Eval("ChuliDate", "{0:yyyy-MM-dd HH:mm:ss}")%></td>
                        <td>处理情况</td>
                        <td style="width: 50%;"><%#Eval("ChuliNote") %></td>
                    </tr>
                    <asp:Repeater ID="FileRepeater" runat="server" OnItemDataBound="FileRepeater_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>图片</td>
                                <td colspan="3">
                                    <%# DataBinder.Eval(Container.DataItem, "FileOriName") %>
                                    <a target="_blank" href="<%# DataBinder.Eval(Container.DataItem, "AttachedFilePath") %>">下载</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>
