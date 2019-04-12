<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderNumberMgr.aspx.cs" Inherits="Web.SysSeting.OrderNumberMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
    </script>
    <script src="../js/Page/SysSetting/OrderNumberMgr.js?t=<%=base.getToken() %>"></script>
    <style>
        table.info td {
            padding: 5px;
            text-align: left;
        }

            table.info td.left {
                width: 10%;
                text-align: right;
            }

            table.info td.right {
                width: 20%;
                text-align: left;
            }

        input[type='text'] {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff">
        <%if (base.CheckAuthByModuleCode("1191098"))
          { %>
        <div class="easyui-panel" style="width: 100%; height: 50%; padding: 10px; background: #fafafa; margin: 10px 0;">
            <table class="info" style="width: 80%; margin: 0 auto;">
                <tr>
                    <td class="left">单据名称
                    </td>
                    <td class="right">
                        <input type="hidden" id="tdID" />
                        <select class="easyui-combobox" id="tdOrderTypeName" data-options="required:true,editable:false" style="width: 150px;">
                            <option value="chargefee">收款单</option>
                            <option value="offseefee">冲抵单</option>
                            <option value="chargebackfee">付款单</option>
                            <option value="customerservice">客服登记单</option>
                            <option value="roomfeeorder">交款单</option>
                            <option value="contractnumber">合同编号</option>
                            <option value="productinnumber">物品入库单</option>
                            <option value="productoutnumber">物品出库单</option>
                        </select>
                    </td>
                    <td class="left">单号位数</td>
                    <td class="right">
                        <input type="text" id="tdOrderNumberCount" class="easyui-numberbox" data-options="required:true" style="width: 150px;" /></td>
                    <td class="left">单号前缀</td>
                    <td class="right">
                        <input type="text" id="tdPrefix" class="easyui-textbox" style="width: 150px;" /></td>
                </tr>
                <tr>
                    <td class="left">引用年份
                    </td>
                    <td class="right">
                        <select class="easyui-combobox" id="tdUseYear" data-options="required:true,editable:false" style="width: 150px;">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                    <td class="left">引用月份</td>
                    <td class="right">
                        <select class="easyui-combobox" id="tdUseMonth" data-options="required:true,editable:false" style="width: 150px;">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select></td>
                    <td class="left">引用日份
                    </td>
                    <td class="right">
                        <select class="easyui-combobox" id="tdUseDay" data-options="required:true,editable:false" style="width: 150px;">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="left">按年重置
                    </td>
                    <td class="right">
                        <select class="easyui-combobox" id="tdIsYearReset" data-options="required:true,editable:false" style="width: 150px;">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                    <td class="left">按月重置</td>
                    <td class="right">
                        <select class="easyui-combobox" id="tdIsMonthReset" data-options="required:true,editable:false" style="width: 150px;">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select></td>
                    <td class="left">按日重置
                    </td>
                    <td class="right">
                        <select class="easyui-combobox" id="tdIsDayReset" data-options="required:true,editable:false" style="width: 150px;">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td class="left tr_chargetype">单据模板</td>
                    <td class="right tr_chargetype">
                        <select id="tdChargeType" class="easyui-combobox" style="width: 150px;" data-options="editable:false">
                            <option value="1">默认模板</option>
                            <option value="2">大写合计模板</option>
                        </select>
                    </td>
                    <td class="left">单号预览
                    </td>
                    <td class="right">
                        <input type="text" id="tdOrderPreview" class="easyui-textbox" data-options="readonly:true" style="width: 150px;" />
                    </td>
                </tr>
                <tr>
                    <td class="left">备注</td>
                    <td class="right" colspan="5">
                        <input type="text" id="tdRemark" class="easyui-textbox" data-options="multiline:true" style="width: 200px; height: 45px;" /></td>
                </tr>
                <tr>
                    <td colspan="6" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="savetype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="canceltype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">撤销</a>
                    </td>
                </tr>
            </table>
        </div>
        <%} %>
        <table id="tt_table">
            <thead>
                <tr>
                    <th data-options="field:'ck',checkbox:true"></th>
                    <th data-options="field:'OrderTypeNameDesc'" width="260">单号名称</th>
                    <th data-options="field:'ChargeTypeDesc'" width="260">单据模板</th>
                    <th data-options="field:'OrderPreview'" width="260">单号预览</th>
                    <th data-options="field:'Operation',formatter: formatOper" width="260">分配项目</th>
                </tr>
            </thead>
        </table>
        <div id="tb">
            <%if (base.CheckAuthByModuleCode("1191099"))
              { %>
            <a href="javascript:void(0)" onclick="edittype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
            <%} %>
            <%if (base.CheckAuthByModuleCode("1191100"))
              { %>
             <a href="javascript:void(0)" onclick="deletetype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            <%} %>
        </div>
    </form>
</asp:Content>
