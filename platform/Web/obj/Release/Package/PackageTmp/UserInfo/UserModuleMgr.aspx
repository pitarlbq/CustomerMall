<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserModuleMgr.aspx.cs" Inherits="Web.UserInfo.UserModuleMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/UserInfo/UserModuleMgr.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'west',border:false" style="width: 200px;">
            <div class="easyui-panel searchlabel" style="max-height: 10%;">
                <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            </div>
            <div class="easyui-panel" style="max-height: 90%;" data-options="fit:true">
                <div class="easyui-tabs" id="CommTab" style="width: 100%; height: 99%; border: none;" data-options="tabHeight:35">
                    <div title="用户角色" style="padding: 0px">
                        <ul class="easyui-tree" id="userRoleTree" style="height: 100%;">
                        </ul>
                    </div>
                    <div title="用户列表" style="padding: 0px">
                        <ul class="easyui-tree" id="userTree" style="height: 100%;">
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div data-options="region:'center',border:false">
            <div class="easyui-panel" data-options="border:false,fit:true">
                <table id="operationTree" data-options="border:false,fit:true">
                    <thead>
                        <tr>
                            <th data-options="field:'name'" width="30%" formatter="formatcheckbox">模块</th>
                            <th data-options="field:'description'" width="70%" align="left">描述</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
