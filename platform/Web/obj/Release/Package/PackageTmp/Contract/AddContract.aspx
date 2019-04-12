<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddContract.aspx.cs" Inherits="Web.Contract.AddContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var op = '', ContractID;
        $(function () {
            op = "<%=this.op%>";
            ContractID = Number("<%=this.ContractID%>");
            loadIframe();
            $('#ContractTab').tabs({
                onSelect: function (title, index) {
                    loadIframe();
                }
            });
            if (op != 'add') {
                setTimeout(function () {
                    $('#main_form_layout').layout('remove', 'north');
                    $("#main_form_layout").layout("resize");
                }, 100);
            }
        })
        function loadIframe() {
            var curTab = $('#ContractTab').tabs('getSelected');
            if (curTab.find("iframe:first").attr("src") == "") {
                var iframesrc = curTab.find("input[type=hidden]:first").val();
                curTab.find("iframe:first").attr("src", iframesrc);
                var $height = $('body').height();
                curTab.find("iframe:first").css("height", ($height - 65) + "px");
            }
        }
        function do_close() {
            if (ContractID <= 0) {
                top.$.messager.confirm('提示', '当前合同未保存，是否关闭?', function (r) {
                    if (r) {
                        parent.do_close_dialog(function () {
                            parent.$('#tt_table').datagrid('reload');
                        });
                    }
                })
                return;
            }
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="main_form_layout" class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 30px;">
            <div class="operation_box">
                <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div class="easyui-tabs" id="ContractTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
                <div title="基本信息" style="padding: 0px;">
                    <input type="hidden" value="AddContract_Basic.aspx?ID=<%=this.ContractID%>&op=<%=this.op%>" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
                <div title="辅助信息" style="padding: 0px;">
                    <input type="hidden" value="AddContract_More.aspx?ID=<%=this.ContractID%>&op=<%=this.op%>" />
                    <iframe src="" style="width: 100%; height: 99%; border: 0"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

