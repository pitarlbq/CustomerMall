<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditPriceRange.aspx.cs" Inherits="Web.SetupFee.EditPriceRange" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ChargeID, ffobj, DefaultMinValue;
        $(function () {
            ChargeID = "<%=Request.QueryString["ChargeID"]%>";
            ffobj = $("#<%=this.ff.ClientID%>");
        })
    </script>
    <script src="../js/Page/SetupFee/EditPriceRange.js?t=<%=base.getToken() %>"></script>
    <style type="text/css">
        table.info {
            width: 100%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            margin-bottom: 10px;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

            table.info input {
                width: 200px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="easyui-panel" style="width: 100%; height: 160px; padding: 10px; background: #fafafa; margin: 10px 0;">
            <table style="width: 100%;">
                <tr>
                    <td>下限
                    </td>
                    <td>
                        <input type="hidden" id="tdID" />
                        <input type="text" id="tdMinValue" class="easyui-textbox" data-options="required:true" style="width: 150px;" /></td>
                    <td>上限</td>
                    <td>
                        <input type="text" id="tdMaxValue" class="easyui-textbox" data-options="required:true" style="width: 150px;" />(没有上限请输入"无上限")</td>
                </tr>
                <tr>
                    <td>单价</td>
                    <td>
                        <input type="text" id="tdBasePrice" class="easyui-numberbox" data-options="required:true,precision:3" style="width: 150px;" /></td>
                    <td>是否生效</td>
                    <td>
                        <select class="easyui-combobox" id="tdIsActive" data-options="required:true" style="width: 150px;">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select></td>
                </tr>
                <tr>
                    <td>类型</td>
                    <td colspan="3">
                        <select class="easyui-combobox" id="tdBaseType" data-options="required:true" style="width: 150px;">
                            <option value="bcyl">按次</option>
                            <option value="qnyl">按年</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="cancelSave()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">撤销</a>
                    </td>
                </tr>
            </table>
        </div>
        <table id="tt_table">
            <thead>
                <tr>
                    <th data-options="field:'ck',checkbox:true"></th>
                    <th data-options="field:'MinValue'" width="100">下限</th>
                    <th data-options="field:'MaxValueDesc'" width="100">上限</th>
                    <th data-options="field:'BasePrice'" width="100">单价</th>
                    <th data-options="field:'IsActiveDesc'" width="100">是否生效</th>
                    <th data-options="field:'BaseTypeDesc'" width="100">类型</th>
                </tr>
            </thead>
        </table>
        <div id="tb">
            <%--<a href="javascript:void(0)" onclick="editRow()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>--%>
            <a href="javascript:void(0)" onclick="removeRows()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
        </div>
    </form>
</asp:Content>
