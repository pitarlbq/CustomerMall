<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ServiceMgr.aspx.cs" Inherits="Web.CustomerService.ServiceMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务看板</title>
    <script>
        var Status;
        $(function () {
            Status = "<%=Request.QueryString["status"]%>" || "";
            var op = "<%=this.op%>";
            if (op == 'view') {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 100;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
        })
        function do_close() {
            parent.do_close_dialog()
        }
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/CustomerService/ServiceMgr.js?v=<%=base.getToken() %>" type="text/javascript"></script>
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="main_form_layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:true,hideCollapsedContent:false," title="" style="height: 80px; padding: 5px;">
                <div class="operation_box" style="display: none;">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <div class="tdsearch">
                    <label>
                        模糊搜索:
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'模糊搜索',searcher:SearchTT" />
                    </label>
                    <label>
                        是否有偿:               
                        <select class="easyui-combobox" id="tdPayStatus" style="width: 60px; height: 25px;">
                            <option value="">全部</option>
                            <option value="1">有偿</option>
                            <option value="0">无偿</option>
                        </select>
                    </label>
                    <label>
                        接单人:
                        <input type="text" class="easyui-combobox" id="tdAccpetMan" style="width: 80px;" />
                    </label>
                    <label>
                        任务时间:              
                        <input class="easyui-datebox" id="tdStartTime" style="width: 110px;" />
                        -                    
                        <input class="easyui-datebox" id="tdEndTime" style="width: 110px;" />
                    </label>
                    <%if (this.status == 101)
                      { %>
                    <label>
                        任务状态:
                       <select class="easyui-combobox" id="tdServiceStatus" style="width: 80px;">
                           <option value="-1">全部</option>
                           <option value="100">待处理</option>
                           <option value="0">处理中</option>
                           <option value="1">已完成</option>
                           <option value="2">已销单</option>
                       </select>
                    </label>
                    <%} %>
                    <label>
                        排序:               
                        <select class="easyui-combobox" id="tdSortOrder" data-options="editable:false" style="width: 100px; height: 25px;">
                            <option value="1">按登记日期</option>
                            <option value="2">按单号</option>
                        </select>
                    </label>
                     <label>
                        报修区域:               
                        <select class="easyui-combobox" id="tdServiceRange" data-options="editable:false" style="width: 100px; height: 25px;">
                            <option value="0">全部区域</option>
                            <option value="1">非公共区域</option>
                            <option value="2">公共区域</option>
                        </select>
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
                    <%if (base.CheckAuthByModuleCode("1101158") && (status == 100 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101159") && (status == 100 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="editData(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101165") && (status == 100 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="removeData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101160") && (status == 0 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="sendData(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">处理</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101161") && (status == 0 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="completeData(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-banjie'">办结</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101162") && (status == 1 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="callData(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-huifang'">回访</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101163") && (status == 0 || status == 1 || status == 2 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="viewData(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">详情</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101164") && (status == 100 || status == 0 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="printData(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                    <%} %>

                    <%if (base.CheckAuthByModuleCode("1101166") && (status == 0 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="cancelData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-cancelorder'">销单</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101167"))
                      { %>
                    <a href="javascript:void(0)" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101168"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <%if (base.CheckAuthByModuleCode("1101160") && (status == 1 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="viewProcessData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-chuli'">处理记录</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191178") && (status == 1 || status == 101))
                      { %>
                    <a href="javascript:void(0)" onclick="completeRemoveData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">彻底删除</a>
                    <%} %>
                    <asp:HiddenField ID="hdOrderBy" runat="server" />
                    <asp:HiddenField ID="hdIDs" runat="server" />
                    <%} %>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
