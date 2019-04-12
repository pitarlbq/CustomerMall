<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Web.GongTan.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var FeeType, CompanyID, FeeStatus, StartWriteDate, EndWriteDate, ChargeSummaryList, hdProjectID, hdRoomIDs, tdKeyword, hdIDs, hdPriceRangeList;
        $(function () {
            FeeType = $("#<%=this.tbFeeType.ClientID%>");
            FeeStatus = $("#<%=this.tbFeeStatus.ClientID%>");
            StartWriteDate = $("#<%=this.tdStartWriteDate.ClientID%>");
            EndWriteDate = $("#<%=this.tdEndWriteDate.ClientID%>");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            hdProjectID = $("#<%=this.hdProjectID.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            tdKeyword = $("#<%=this.tdKeyword.ClientID%>");
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
            hdPriceRangeList = $("#<%=this.hdPriceRangeList.ClientID%>");
        });
    </script>
    <script src="../js/toast/jquery.toast.js"></script>
    <link href="../js/toast/jquery.toast.css" rel="stylesheet" />
    <script src="../js/Page/GongTan/GongTanSetup.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <input type="hidden" runat="server" id="hdPriceRangeList" />
        <div class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 60px; padding: 5px;">
                <div class="tdsearch">
                    <label>
                        关键字:                
                        <input class="easyui-searchbox" id="tdKeyword" runat="server" type="text" data-options="prompt:'关键字搜索          ',searcher:SearchTT" style="width: 200px" />
                    </label>
                    <label>
                        收费项目:                          
                        <input class="easyui-combobox" runat="server" id="tbFeeType" style="width: 150px; height: 25px;" />
                    </label>
                    <label>
                        收费状态:                
                        <select class="easyui-combobox" data-options="editable:false" runat="server" id="tbFeeStatus" style="width: 100px; height: 25px;">
                            <option value="">全部</option>
                            <option value="2">草稿</option>
                            <option value="0">未收</option>
                            <option value="1">已收</option>
                        </select>
                    </label>
                    <label>
                        账单日期:
               <input class="easyui-datebox" runat="server" id="tdStartWriteDate" style="width: 100px; height: 25px;" />
                        -
                    <input class="easyui-datebox" runat="server" id="tdEndWriteDate" style="width: 100px; height: 25px;" />
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <%if (base.CheckAuthByModuleCode("1191519"))
                      {%>
                    <a href="javascript:void(0)" onclick="createFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">账单生成</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191520"))
                      {%>
                    <a href="javascript:void(0)" onclick="editFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191521"))
                      {%>
                    <a href="javascript:void(0)" onclick="removeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191522"))
                      {%>
                    <a href="javascript:void(0)" onclick="doCancelRoomFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-zuofei'">作废</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191523"))
                      {%>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdProjectID" runat="server" />
                    <asp:HiddenField ID="hdRoomIDs" runat="server" />
                    <asp:HiddenField ID="hdIDs" runat="server" />
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191524"))
                      {%>
                    <a href="javascript:void(0)" onclick="openImport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191525"))
                      {%>
                    <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191526"))
                      {%>
                    <a href="javascript:void(0)" onclick="activeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-qiyong'">账单生效</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191527"))
                      {%>
                    <a href="javascript:void(0)" onclick="batchEditTime()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">批处理</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191528"))
                      {%>
                    <a href="javascript:void(0)" onclick="addTool()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-gongtan'">公摊工具</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191529"))
                      {%>
                    <a href="javascript:void(0)" onclick="batchEditPoint()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chaobiao'">抄表登记</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191530"))
                      {%>
                    <a href="javascript:void(0)" onclick="transferQiChu()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shoufei'">收款登记</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191531"))
                      {%>
                    <a href="javascript:void(0)" onclick="viewTaiZhang()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-sanbiao'">三表台帐</a>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
