<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseBiao.aspx.cs" Inherits="Web.SetupFee.ChooseBiao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ChargeID, ffobj;
        $(function () {
            ChargeID = "<%=Request.QueryString["ChargeID"]%>";
            ffobj = $("#<%=this.ff.ClientID%>");
        })
    </script>
    <script src="../js/Page/SetupFee/ChooseBiao.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="easyui-layout" data-options="fit:true">
            <table id="tt_table">
                <thead>
                    <tr>
                        <th data-options="field:'ck',checkbox:true"></th>
                        <th data-options="field:'BiaoCategory'" width="100">表种类</th>
                    </tr>
                </thead>
            </table>
            <div id="tb">
                <a href="javascript:void(0)" onclick="chooseRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <a href="javascript:void(0)" onclick="saveRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            </div>
        </div>
    </form>
</asp:Content>
