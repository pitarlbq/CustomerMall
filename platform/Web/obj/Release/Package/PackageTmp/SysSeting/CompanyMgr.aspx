<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CompanyMgr.aspx.cs" Inherits="Web.SysSeting.CompanyMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/SysSetting/CompanyMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px;">
            <label>
                公司名称                 
                <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                网址分配状态
                <select id="tdSiteStatus" class="easyui-combobox">
                    <option value="">全部</option>
                    <option value="1">已分配</option>
                    <option value="2">未分配</option>
                </select>
            </label>
            <label>
                启用状态
                <select id="tdActiveStatus" class="easyui-combobox">
                    <option value="">全部</option>
                    <option value="1">已启用</option>
                    <option value="2">已禁用</option>
                </select>
            </label>
            <label>
                服务器位置
                <select id="tdServerLocation" class="easyui-combobox">
                    <option value="">全部</option>
                    <option value="0">本地服务器</option>
                    <option value="1">客户服务器</option>
                </select>
            </label>
            <label>
                微信开通
                <select id="tdIsWechatOn" class="easyui-combobox">
                    <option value="">全部</option>
                    <option value="1">开通</option>
                    <option value="2">未开通</option>
                </select>
            </label>
            <label>
                付费结束日期
                 <input class="easyui-datebox" style="width:100px" id="tdStartTime" />
                -
                 <input class="easyui-datebox" style="width:100px" id="tdEndTime" />
            </label>
            <label class="searchlabel">
                 <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="addCompany()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <a href="javascript:void(0)" onclick="editCompany()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="removeCompany()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%if (base.CheckAuthByModuleCode("1101108"))
                  { %>
                <a href="javascript:void(0)" onclick="AssignSite()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">网址分配</a>
                <a href="javascript:void(0)" onclick="UpgradeSite()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">版本升级</a>
                <a href="javascript:void(0)" onclick="SaveSqlFile()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">生成文件</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
