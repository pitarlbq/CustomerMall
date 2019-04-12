<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SetupFeeSummary.aspx.cs" Inherits="Web.SetupFee.SetupFeeSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/main.css" rel="stylesheet" />
    <script type="text/javascript">
        var CompanyID;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
        })
    </script>
    <script src="../js/Page/SetupFee/SetupFeeSummary.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" class="searcharea" style="height: 50px;">
                <div style="height: 50px; background-color: #fff; padding: 3px 5px; border-bottom: 1px solid #e0e2e5;">
                    <%if (base.CheckAuthByModuleCode("1191091"))
                      { %>
                    <a href="javascript:void(0)" onclick="addFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">增加</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191092"))
                      { %>
                    <a href="javascript:void(0)" onclick="editFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191093"))
                      { %>
                    <a href="javascript:void(0)" onclick="deleteFee()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <a href="javascript:void(0)" onclick="do_start()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-qiyong'">启用周期费用</a>
                    <%--<a href="javascript:void(0)" onclick="configColumns()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>--%>
                    <input type="hidden" value="<%=this.DefaultSelectedTitle %>" id="hdSelectedTitle" />
                    <input type="text" class="easyui-searchbox" id="tdKeywords" data-options="prompt:'关键字搜索',searcher:SearchTT" />
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <div id="ChargeSummaryAccording" data-options="fit:true,tabPosition:'left',headerWidth:100,tabHeight:35" class="easyui-tabs" style="width: 100%; height: 100%; margin: 0 auto;">
                    <asp:Repeater runat="server" ID="rptFee">
                        <ItemTemplate>
                            <div title="<%#Eval("Name") %>" style="overflow: auto; padding: 0px;">
                                <iframe name="feeframe" src="" id="iframe_<%#Eval("Name") %>" style="width: 100%; height: 99%; border: 0;"></iframe>
                                <input type="hidden" value="../SetupFee/SetupFeeList.aspx?CategoryID=<%#Eval("ID") %>" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
