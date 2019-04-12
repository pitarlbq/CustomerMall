<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ContractSummary.aspx.cs" Inherits="Web.Contract.ContractSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdKeywords, tdContractStatus, tdStartTime, tdEndTime, tdRentStartTime, tdRentEndTime, hdProjectIDs, hdRoomIDs, expired;
        $(function () {
            tdKeywords = $("#<%=this.tdKeywords.ClientID%>");
            tdContractStatus = $("#<%=this.tdContractStatus.ClientID%>");
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
            tdRentStartTime = $("#<%=this.tdRentStartTime.ClientID%>");
            tdRentEndTime = $("#<%=this.tdRentEndTime.ClientID%>");
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            expired = "<%=this.expired%>";
            var op = "<%=this.op%>";
            if (op == 'view') {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 80;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
        })
        function do_close() {
            parent.do_close_dialog()
        }
    </script>
    <script src="../js/Page/Contract/ContractSummary.js?v=<%=base.getToken()%>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="main_form_layout" class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px;">
                <div class="operation_box" style="display: none;">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <label>
                    模糊搜索:
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'模糊搜索',searcher:SearchTT" runat="server" />
                </label>
                <label>
                    合同状态:
                        <select class="easyui-combobox" id="tdContractStatus" runat="server">
                            <option value="">全部</option>
                            <option value="yuding">预定合同</option>
                            <option value="tongguo">正常履行</option>
                            <option value="zhongzhi">合同终止</option>
                            <option value="deleted">合同作废</option>
                        </select>
                </label>
                <label>
                    签约日期:
               <input class="easyui-datebox" id="tdStartTime" style="width: 100px; height: 25px;" runat="server" />
                    -
                    <input class="easyui-datebox" id="tdEndTime" style="width: 100px; height: 25px;" runat="server" />
                </label>
                <label>
                    结束日期:
               <input class="easyui-datebox" id="tdRentStartTime" style="width: 100px; height: 25px;" runat="server" />
                    -
                    <input class="easyui-datebox" id="tdRentEndTime" style="width: 100px; height: 25px;" runat="server" />
                </label>
                <label>
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                    <asp:HiddenField runat="server" ID="hdContractWarning" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
