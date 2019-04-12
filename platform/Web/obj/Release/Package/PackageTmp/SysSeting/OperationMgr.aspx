<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OperationMgr.aspx.cs" Inherits="Web.SysSeting.OperationMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/SysSetting/OperationMgr.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false" style="height: 50px; font-size: 12px; padding: 10px 0 0 5px;">
            <label>
                关键字:
                  <input class="easyui-searchbox" id="tdKeyword" type="text" data-options="prompt:'关键字搜索',searcher:SearchTT" />
            </label>
            <label>
                操作时间
                <input class="easyui-datetimebox" id="tdStartTime" style="width: 180px;" />
                -
                <input class="easyui-datetimebox" id="tdEndTime" style="width: 180px;" />
            </label>
            <label>
                <select class="easyui-combobox" id="tdOperationKey" style="width: 180px;">
                    <option value="">全部</option>
                    <option value="UserLogin">用户登录</option>
                    <option value="ChargeFeeSave">收款保存</option>
                    <option value="ChargeFeePrint">收款打印</option>
                    <option value="HistoryPrint">补打单据</option>
                    <option value="PreChargeFeeSave">预收冲销保存</option>
                    <option value="PreChargeFeePrint">预收冲销打印</option>
                    <option value="PreChargeFeeBackSave">预收退款保存</option>
                    <option value="PreChargeFeeBackPrint">预收退款打印</option>
                    <option value="GuaranteeFeeBackSave">押金退款保存</option>
                    <option value="GuaranteeFeeBackPrint">押金退款打印</option>
                    <option value="AddUser">账号新增</option>
                    <option value="RemoveUser">账号删除</option>
                    <option value="RoleModuleSave">权限修改</option>
                </select>
            </label>
            <label class="searchlabel">
                <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">查询</a>
            </label>
        </div>
        <div data-options="region:'center',border:false">
            <table id="tt_table"></table>
            <div id="tt_mm">
            </div>
        </div>
    </div>
</asp:Content>
