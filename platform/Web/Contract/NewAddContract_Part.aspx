<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="NewAddContract_Part.aspx.cs" Inherits="Web.Contract.NewAddContract_Part" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>合同收款/承租方</title>
    <script>
        var ffObj, guid, ContractID, canEdit = false, canSaveLog=false;
        $(function () {
            ffObj = $("#<%=this.ff.ClientID%>");
            guid = parent.guid;
            ContractID = parent.ContractID;
            canEdit = parent.canEdit;
            canSaveLog = parent.canSaveLog;
        })
    </script>
    <script src="../js/Page/Comm/EditRow.js?t=<%=getToken()%>"></script>
    <script src="../js/Page/Contract/NewAddContract_Part.js?t=<%=getToken()%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table id="tt_table">
        </table>
        <div id="tb">
            <%if (this.canEdit)
              { %>
            <a href="javascript:void(0)" onclick="do_add_row()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <%} %>
        </div>
    </form>
</asp:Content>
