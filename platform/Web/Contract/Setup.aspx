<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="Setup.aspx.cs" Inherits="Web.Contract.Setup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var addContractPath = "", editContractPath = "";
        $(function () {
            addContractPath = "<%=this.addContractPath%>";
            editContractPath = "<%=this.editContractPath%>";
        })
    </script>
    <script src="../js/Page/Contract/ContractSetup.js?v=<%=base.getToken() %>" type="text/javascript"></script>
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
            <asp:HiddenField runat="server" ID="hdContractWarning" />
            <div data-options="region:'north'" style="height: 80px; padding: 5px 10px;">
                <div class="tdsearch">
                    <label>
                        模糊搜索：
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'模糊搜索',searcher:SearchTT" />
                    </label>
                    <label>
                        合同状态:
                        <select class="easyui-combobox" id="tdContractStatus" data-options="editable:false">
                            <option value="">全部</option>
                            <option value="yuding">合同预定</option>
                            <option value="tongguo">正常履行</option>
                            <option value="zhongzhi">合同终止</option>
                            <option value="deleted">合同作废</option>
                        </select>
                        <asp:HiddenField runat="server" ID="hdContractStatus" />
                    </label>
                    <label>
                        签约日期：              
                        <input class="easyui-datebox" id="tdStartTime" style="width: 100px; height: 25px;" />
                        -                    
                        <input class="easyui-datebox" id="tdEndTime" style="width: 100px; height: 25px;" />
                    </label>
                    <label>
                        结束日期：              
                        <input class="easyui-datebox" id="tdRentStartTime" style="width: 100px; height: 25px;" />
                        -                    
                        <input class="easyui-datebox" id="tdRentEndTime" style="width: 100px; height: 25px;" />
                        <asp:HiddenField runat="server" ID="hdRentEndTime" />
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
                    <%if (base.CheckAuthByModuleCode("1101152"))
                      { %>
                    <a href="javascript:void(0)" onclick="viewData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-detail'">查看</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101153"))
                      { %>
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">登记</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101154"))
                      { %>
                    <a href="javascript:void(0)" onclick="approveData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shenhe'">审核</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101155"))
                      { %>
                    <a href="javascript:void(0)" onclick="editData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">变更</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1191480"))
                      { %>
                    <a href="javascript:void(0)" onclick="doReRent()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">续租</a>
                    <a href="javascript:void(0)" onclick="doChangeRent()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">转租</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101156"))
                      { %>
                    <a href="javascript:void(0)" onclick="cancelData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tingyong'">终止</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101157"))
                      { %>
                    <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("11011180"))
                      { %>
                    <a href="javascript:void(0)" onclick="zuofeiRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-tingyong'">作废</a>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
