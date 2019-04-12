<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="PayServiceManager.aspx.cs" Inherits="Web.PayService.PayServiceManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>支出登记</title>
    <script src="../js/Page/PayService/PayServiceManager.js?v=1.1_<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .btn.btn-link {
            padding: 4px !important;
        }
    </style>
    <script>
        var hdIDs;
        $(function () {
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <div class="tdsearch">
                    <label>
                        模糊搜索：
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 200px;" data-options="prompt:'模糊搜索',searcher:SearchTT" />
                    </label>
                    <label>
                        支出项目:
                        <input type="text" class="easyui-combobox" id="tdPaySummary" style="width: 150px;" />
                    </label>
                    <label>
                        支出时间：
               <input class="easyui-datebox" id="tdStartTime" style="width: 100px; height: 25px;" />
                        -
                    <input class="easyui-datebox" id="tdEndTime" style="width: 100px; height: 25px;" />
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <%if (base.CheckAuthByModuleCode("1191474"))
                      { %>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">支出登记</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191475"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191476"))
                      { %>
                    <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191477"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191478"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_approve()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审核</a>
                    <%} %>
                    <asp:HiddenField ID="hdIDs" runat="server" />
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
