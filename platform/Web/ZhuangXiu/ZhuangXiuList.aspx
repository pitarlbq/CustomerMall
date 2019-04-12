<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ZhuangXiuList.aspx.cs" Inherits="Web.ZhuangXiu.ZhuangXiuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var Status;
        $(function () {
            Status = "<%=Request.QueryString["status"]%>" || "";
        })
    </script>
    <script src="../js/Page/ZhuangXiu/ZhuangXiuSetup.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .btn.btn-link {
            padding: 4px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px 10px;">
                <div class="tdsearch">
                    <label>
                        模糊搜索：
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'房号、申请人姓名',searcher:SearchTT" />
                    </label>
                    <%--<label>
                        状态:
                        <select class="easyui-combobox" id="tdStatus">
                            <option value="">全部</option>
                            <option value="shenqing">申请中</option>
                            <option value="shenpiyes">审批通过</option>
                            <option value="shenpino">审批拒绝</option>
                            <option value="zhuangxiu">装修中</option>
                            <option value="yanshou">已验收</option>
                        </select>
                    </label>--%>
                    <label>
                        日期：
               <input class="easyui-datetimebox" id="tdStartTime" style="width: 180px; height: 25px;" />
                        -
                    <input class="easyui-datetimebox" id="tdEndTime" style="width: 180px; height: 25px;" />
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
                    <%if (base.CheckAuthByModuleCode("1101169") && this.status.Equals("shenqing"))
                      { %>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101170") && this.status.Equals("shenqing"))
                      { %>
                    <a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <%} %>
                    <%if (this.status.Equals("shenqing") || this.status.Equals("shenpino") || this.status.Equals("yanshou"))
                      {%>
                    <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101171") && (this.status.Equals("shenqing") || this.status.Equals("shenpino")))
                      { %>
                    <a href="javascript:void(0)" onclick="approveData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审批</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101172") && this.status.Equals("shenpiyes"))
                      { %>
                    <a href="javascript:void(0)" onclick="confirmZX()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-qiyong'">确认装修</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101173") && (this.status.Equals("zhuangxiu")))
                      { %>
                    <a href="javascript:void(0)" onclick="xunJian()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">巡检</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101174") && this.status.Equals("zhuangxiu"))
                      { %>
                    <a href="javascript:void(0)" onclick="yanShou()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-banjie'">验收</a>
                    <%} %>
                    <a href="javascript:void(0)" onclick="do_view()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">详情</a>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
