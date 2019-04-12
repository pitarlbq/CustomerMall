<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractDivideView.aspx.cs" Inherits="Web.ContractEarn.ContractDivideView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            loadIframe();
            $('#ContractTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
        })
        function loadIframe() {
            var curTab = $('#ContractTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
                var $height = $(window).height();
                curTab.find("iframe:first").css("height", ($height - 65) + "px");
            }
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 30px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
        <div data-options="region:'center',border:false" style="background: #2f80d1;">
            <div class="easyui-tabs" id="ContractTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
                <div title="基本信息" style="padding: 0px">
                    <input type="hidden" value="ContractDivideEdit.aspx?ID=<%=this.ID %>&op=<%=this.op %>" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="应收信息" style="padding: 0px">
                    <input type="hidden" value="ContractDivideChargeBill.aspx?ID=<%=this.ID %>" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="已收信息" style="padding: 0px">
                    <input type="hidden" value="ContractDivideChargeHistory.aspx?ID=<%=this.ID %>" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
