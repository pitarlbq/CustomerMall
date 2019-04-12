<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChargeDiscountMgr.aspx.cs" Inherits="Web.SysSeting.ChargeDiscountMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var AddMan, CompanyID;
        $(function () {
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
        })
    </script>
    <script src="../js/Page/SysSetting/ChargeDiscountMgr.js?t=<%=base.getToken() %>"></script>
    <style>
        table.info td {
            padding: 3px 5px;
            width: 35%;
            text-align: left;
        }

            table.info td:nth-child(2n-1) {
                width: 15%;
                text-align: right;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff">
        <div class="easyui-panel" style="width: 100%; height: 220px; padding: 10px; background: #fafafa; margin: 10px 0;">
            <table class="info" style="width: 100%;">
                <tr>
                    <td>方案名称
                    </td>
                    <td>
                        <input type="hidden" id="tdID" />
                        <input type="text" id="tdDiscountName" class="easyui-textbox" data-options="required:true" style="width: 200px;" /></td>
                    <td>排序
                    </td>
                    <td>
                        <input type="text" id="tdSortOrder" class="easyui-numberbox" data-options="required:true" style="width: 200px" /></td>
                </tr>
                <tr>
                    <td>减免方式</td>
                    <td>
                        <select class="easyui-combobox" id="tdDiscountType" data-options="required:true" style="width: 200px;">
                            <option value="percent">折扣</option>
                            <option value="fixedamount">固定金额</option>
                            <option value="writeamount">手动输入</option>
                            <option value="allfree">全额减免</option>
                            <option value="permonth">按月减免</option>
                        </select>
                    </td>
                    <td class="notfree">减免金额
                    </td>
                    <td class="notfree">
                        <input type="text" id="tdDiscountValue" class="easyui-numberbox" data-options="required:true,precision: 2" style="width: 200px;" />(<label id="Unit">%</label>)
                    </td>
                </tr>
                <tr>
                    <td>有效期
                    </td>
                    <td>
                        <input type="text" id="tdStartTime" class="easyui-datebox" style="width: 150px;" />
                        -
                         <input type="text" id="tdEndTime" class="easyui-datebox" style="width: 150px;" />
                    </td>
                    <td>收费项目</td>
                    <td>
                        <input type="text" id="tdChargeSummary" class="easyui-combobox" style="width: 200px;" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>备注说明</td>
                    <td colspan="3">
                        <input type="text" id="tdRemark" class="easyui-textbox" style="width: 70%; height: 60px;" data-options="multiline:true" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="savetype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="canceltype()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">撤销</a>
                    </td>
                </tr>
            </table>
        </div>
        <table id="tt_table">
            <thead>
                <tr>
                    <th data-options="field:'ck',checkbox:true"></th>
                    <th data-options="field:'DiscountName'" width="100">方案名称</th>
                    <th data-options="field:'DicountTypeDesc'" width="100">减免方式</th>
                    <th data-options="field:'DiscountValue',formatter: formatDiscountValue" width="100">减免金额</th>
                    <th data-options="field:'ValueTime',formatter: formatValidTime" width="150">有效期</th>
                    <th data-options="field:'Remark',formatter: formatRemark" width="200">备注说明</th>
                </tr>
            </thead>
        </table>
        <div id="tb">
            <a href="javascript:void(0)" onclick="edittype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
            <a href="javascript:void(0)" onclick="deletetype()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">删除</a>
        </div>
    </form>
</asp:Content>
