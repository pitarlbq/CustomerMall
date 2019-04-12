<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ToCuiKuanList.aspx.cs" Inherits="Web.Analysis.ToCuiKuanList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        var CompanyID, hdIDs, tdStartTime, tdEndTime;
        $(function () {
            //$("#layout").layout("collapse", "north");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
        })
    </script>
    <script src="../js/Page/Analysis/ToCuiKuanList.js?t=<%=base.getToken() %>"></script>
    <style>
        .operationtable {
            width: 100%;
        }

            .operationtable td {
                text-align: center;
            }

        .sfdd {
            width: 100%;
            height: 32px;
            background: url("../styles/images/buttons/print.png") no-repeat center center;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 60px; padding: 5px 10px;">
                <label>
                    时间:               
                    <input class="easyui-datebox" id="tdStartTime" runat="server" style="width: 100px; height: 28px;" />
                    -                
                    <input class="easyui-datebox" id="tdEndTime" runat="server" style="width: 100px; height: 28px;" />
                </label>
                <label>
                    收费项目:               
                    <input class="easyui-combobox" id="tdChargeSummaryName" style="width: 120px; height: 28px;" />
                </label>
                <label>
                    房间状态:
                    <input class="easyui-combobox" id="tdRoomState" style="width: 80px; height: 28px;" />
                </label>
                <label>
                    房源属性:                
                    <input class="easyui-combobox" id="tdRoomProperty" style="width: 80px; height: 28px;" />
                </label>
                 <label>
                    所属部门:
                    <input class="easyui-textbox" id="tdRelationBelongTeam" style="width: 100px; height: 28px;" />
                </label>
                <label class="searchlabel" style="margin-left: 10px;">
                    <a href="#" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <a href="javascript:void(0)" onclick="createCuiShou()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">生成催收单</a>
                    <asp:HiddenField ID="hdIDs" runat="server" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
