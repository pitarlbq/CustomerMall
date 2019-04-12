<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ContractFeeSummaryAnalysis.aspx.cs" Inherits="Web.Contract.ContractFeeSummaryAnalysis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdKeywords, tdStartTime, tdEndTime, hdProjectIDs, hdRoomIDs;
        $(function () {
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            var op = "<%=this.op%>";
            if (op == 'view') {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 30;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            } else {
                $('#main_form_layout').layout('remove', 'north');
                $("#main_form_layout").layout("resize");
            }
        })
        function do_close() {
            parent.do_close_dialog()
        }
    </script>
    <script src="../js/Page/Contract/ContractFeeSummaryAnalysis.js?v=<%=base.getToken()%>" type="text/javascript"></script>
    <style>
        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="main_form_layout" class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 0px; padding: 0px;">
                <div class="operation_box" style="display: none;">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
