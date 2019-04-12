<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AssignWebSite.aspx.cs" Inherits="Web.SysSeting.AssignWebSite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/util.js"></script>
    <script>
        var SiteURLExist = 0;
        var canEdit = 1;
        $(function () {
            SiteURLExist = Number("<%=this.SiteURLExist%>");
            canEdit = Number("<%=this.canEdit%>");
            if (canEdit == 1) {
                $('#trsave').show();
            }
            else {
                $('#trsave').hide();
            }
            if (SiteURLExist == 0) {
                $('#trdefaultuser').show();
            }
            else {
                $('#trdefaultuser').hide();
            }
            doChangeServerLocation();
            $('#<%=this.tdServerLocation.ClientID%>').combobox({
                onSelect: function (ret) {
                    doChangeServerLocation();
                }
            })
        })
        function doChangeServerLocation() {
            var ServerLocation = $('#<%=this.tdServerLocation.ClientID%>').combobox('getValue');
            if (ServerLocation == "0") {
                $('#localurl').show();
                $('#tdport').html('(例如:saas)');
                if (SiteURLExist == 0) {
                    $('#savelabel').html('生成网站');
                }
                else {
                    $('#savelabel').html('保存');
                }
            }
            else {
                $('#localurl').hide();
                $("#<%=this.tdSiteURL.ClientID%>").textbox('readonly', false);
                $('#tdport').html('(例如:http://abc.com)');
                $('#savelabel').html('保存');
                $('#doSave').show();
                $('#tdport').show();
            }
        }
        function do_save() {
            var options = {};
            options.action = "savesite";
            options.sitename = $("#<%=this.tdSiteURL.ClientID%>").val();
            options.CompanyID = "<%=Request.QueryString["CompanyID"]%>";
            options.ServerLocation = $('#<%=this.tdServerLocation.ClientID%>').combobox('getValue');
            if (options.sitename == "") {
                show_message("网站名称不能为空", "info");
                return;
            }
            MaskUtil.mask('body', '提交中');
            Util.get(options, function (succeed, data, err) {
                MaskUtil.unmask();
                if (succeed) {
                    show_message(data, "info", function () {
                        do_close();
                    });
                } else if (err) {
                    show_message(err, "info");
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">创建</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info">
            <tr>
                <td style="width: 30%;">服务器地址:</td>
                <td colspan="3" style="width: 70%; text-align: left;">
                    <select id="tdServerLocation" class="easyui-combobox" runat="server" data-options="editable:false">
                        <option value="0">本地服务器</option>
                        <option value="1">客户服务器</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td>网站名称:</td>
                <td colspan="3" style="width: 70%; text-align: left;">
                    <label id="localurl">http://te-cool.com:99/</label>
                    <input type="text" runat="server" data-options="required:true" class="easyui-textbox" id="tdSiteURL" /><label id="tdport">(比如:saas)</label></td>
            </tr>
            <tr id="trdefaultuser">
                <td>默认用户名/密码</td>
                <td colspan="3" style="width: 70%; text-align: left;">admin/123456</td>
            </tr>
        </table>
    </div>
</asp:Content>
