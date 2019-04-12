<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCheckMgr.aspx.cs" Inherits="Web.Mall.UserCheckMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>岗位考核</title>
    <script>
        var approvestatus = -1, confirmstatus = -1, processstatus = -1;
        $(function () {
            approvestatus = "<%=this.approvestatus%>";
            confirmstatus = "<%=this.confirmstatus%>";
            processstatus = "<%=this.processstatus%>";
        })
    </script>
    <script src="../js/Page/Mall/Balance/UserCheckMgr.js?v=<%=base.getToken()%>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 5px 10px;">
            <label>
                关键字: 
                <input class="easyui-searchbox" style="width: 200px;" id="tdKeyword" type="text" data-options="prompt:'商品名称',searcher:SearchTT" />
            </label>
            <label>
                考核类型:
                <select class="easyui-combobox" style="width: 100px;" id="tdCheckType" data-options="editable:false">
                    <option value="0">全部</option>
                    <option value="1">奖励</option>
                    <option value="2">惩罚</option>
                </select>
            </label>
            <label>
                积分类型:
                <select class="easyui-combobox" style="width: 150px;" id="tdRequestType" data-options="editable:false">
                    <option value="0" selected="selected">全部</option>
                    <option value="1">行为考核积分</option>
                    <option value="2">固定考核积分</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
                <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%if (this.approvestatus == 0 || this.approvestatus == 2 || (this.approvestatus == -1 && this.confirmstatus == -1))
                  { %>
                <a href="javascript:void(0)" onclick="do_application()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">申请审核</a>
                <%} %>
                <%if (this.approvestatus == 3 || (this.approvestatus == -1 && this.confirmstatus == -1))
                  { %>
                <a href="javascript:void(0)" onclick="do_approve()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审核处理</a>
                <%} %>
                <%if (this.confirmstatus == 2 || (this.approvestatus == -1 && this.confirmstatus == -1))
                  { %>
                <a href="javascript:void(0)" onclick="do_process()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">申诉处理</a>
                <%} %>
            </div>
        </div>
    </div>
</asp:Content>
