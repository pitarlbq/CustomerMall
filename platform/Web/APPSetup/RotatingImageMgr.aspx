<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="RotatingImageMgr.aspx.cs" Inherits="Web.APPSetup.RotatingImageMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            var hdTypeValue = $("#<%=this.hdTypeValue.ClientID%>");
            var list = eval("(" + hdTypeValue.val() + ")");
            $('#tdType').combobox({
                editable: false,
                data: list,
                valueField: 'id',
                textField: 'name'
            });
        })
    </script>
    <script src="../js/Page/APPSetup/RotatingImageMgr.js?v=<%=base.getToken() %>"></script>
    <style>
        .searcharea label {
            padding: 0px 5px;
        }

        .datagrid-td-rownumber {
            height: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div class="searcharea" data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px 0px 0px 10px;">
                <label>
                    类型:               
                    <input class="easyui-combobox" id="tdType" data-options="editable:false" style="width: 200px;" />
                    <asp:HiddenField runat="server" ID="hdTypeValue" />
                </label>
                <label class="searchlabel">
                    <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center',border:false">
                <table id="tt_table"></table>
                <div id="tt_mm">
                    <%if (base.CheckAuthByModuleCode("1101329"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_add()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101330"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_edit()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <%} %>
                    <%if (base.CheckAuthByModuleCode("1101331"))
                      { %>
                    <a href="javascript:void(0)" onclick="do_remove()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                    <%} %>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
