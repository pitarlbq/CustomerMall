<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="MaterialList.aspx.cs" Inherits="Web.CangKu.MaterialList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>物料清单</title>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .btn.btn-link {
            padding: 4px !important;
        }
    </style>
    <script>
        var tdStartTime, tdEndTime, tdPayStatus, tdBalanceStatus, tdIsTransfer, hdProjectID;
        $(function () {
            tdStartTime = $('#<%=this.tdStartTime.ClientID%>');
            tdEndTime = $('#<%=this.tdEndTime.ClientID%>');
            tdPayStatus = $('#<%=this.tdPayStatus.ClientID%>');
            tdBalanceStatus = $('#<%=this.tdBalanceStatus.ClientID%>');
            tdIsTransfer = $('#<%=this.tdIsTransfer.ClientID%>');
            hdProjectID = $('#<%=this.hdProjectID.ClientID%>');
            hdRoomIDs = $('#<%=this.hdRoomIDs.ClientID%>');
        })
    </script>
    <script src="../js/Page/CangKu/CKMaterialList.js?v=<%=base.getToken() %>" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <div class="tdsearch">
                    <label>
                        登记日期：
                        <input class="easyui-datebox" runat="server" id="tdStartTime" style="width: 120px; height: 25px;" />
                        -
                    <input class="easyui-datebox" runat="server" id="tdEndTime" style="width: 120px; height: 25px;" />
                    </label>
                    <label>
                        是否有偿：
                <select class="easyui-combobox" runat="server" id="tdPayStatus" style="width: 100px; height: 25px;">
                    <option value="">全部</option>
                    <option value="1">有偿</option>
                    <option value="0">无偿</option>
                </select>
                    </label>
                    <label>
                        结算状态：               
                        <select class="easyui-combobox" runat="server" id="tdBalanceStatus" style="width: 100px; height: 25px;">
                            <option value="">全部</option>
                            <option value="balanceyes">已结算</option>
                            <option value="complete">已销单</option>
                            <option value="balanceno">未结算</option>
                        </select>
                    </label>
                    <label>
                        是否出库：               
                        <select class="easyui-combobox" runat="server" id="tdIsTransfer" style="width: 100px; height: 25px;">
                            <option value="">全部</option>
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="doPay()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-balance'">结算</a>
                    <a href="javascript:void(0)" onclick="doComplete()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-cancelorder'">销单</a>
                    <a href="javascript:void(0)" onclick="doTransferOut()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-materialout'">转为出库单</a>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdProjectID" runat="server" />
                    <asp:HiddenField ID="hdRoomIDs" runat="server" />
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
