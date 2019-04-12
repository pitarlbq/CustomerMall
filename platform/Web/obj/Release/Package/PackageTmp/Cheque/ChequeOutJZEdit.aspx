<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChequeOutJZEdit.aspx.cs" Inherits="Web.Cheque.ChequeOutJZEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ID, filecount, guid, tdProjectIDObj, tdStartTimeObj, tdEndTimeObj, tdNotifyTimeObj, tdOperatorObj, tdOperationTimeObj, tdIDCardStatusObj, tdRemarkObj, ffObj, tdBelongCompanyNameObj, tdDepartmentIDObj, tdPaperNumberObj, tdOutingAddressObj, tdApproveManObj, tdTaxManNameObj, tdTaxNumberObj, tdCompanyInChargeManObj, tdIDCardTypeObj, tdIDCardNumberObj, tdProduceAddressObj, tdCompanyRegiserTypeObj, tdBusinessTypeObj, tdInChargeManObj, tdOperationCommentObj;
        $(function () {
            ID = "<%=this.ID%>";
            guid = "<%=this.guid%>";
            filecount = 0;
            tdProjectIDObj = $("#<%=this.tdProjectID.ClientID%>");
            tdStartTimeObj = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTimeObj = $("#<%=this.tdEndTime.ClientID%>");
            tdNotifyTimeObj = $("#<%=this.tdNotifyTime.ClientID%>");
            tdOperatorObj = $("#<%=this.tdOperator.ClientID%>");
            tdOperationTimeObj = $("#<%=this.tdOperationTime.ClientID%>");
            tdIDCardStatusObj = $("#<%=this.tdIDCardStatus.ClientID%>");
            tdRemarkObj = $("#<%=this.tdRemark.ClientID%>");
            ffObj = $("#<%=this.ff.ClientID%>");
            tdBelongCompanyNameObj = $("#<%=this.tdBelongCompanyName.ClientID%>");
            tdDepartmentIDObj = $("#<%=this.tdDepartmentID.ClientID%>");
            tdPaperNumberObj = $("#<%=this.tdPaperNumber.ClientID%>");
            tdOutingAddressObj = $("#<%=this.tdOutingAddress.ClientID%>");
            tdApproveManObj = $("#<%=this.tdApproveMan.ClientID%>");
            tdTaxManNameObj = $("#<%=this.tdTaxManName.ClientID%>");
            tdTaxNumberObj = $("#<%=this.tdTaxNumber.ClientID%>");
            tdCompanyInChargeManObj = $("#<%=this.tdCompanyInChargeMan.ClientID%>");
            tdIDCardTypeObj = $("#<%=this.tdIDCardType.ClientID%>");
            tdIDCardNumberObj = $("#<%=this.tdIDCardNumber.ClientID%>");
            tdProduceAddressObj = $("#<%=this.tdProduceAddress.ClientID%>");
            tdCompanyRegiserTypeObj = $("#<%=this.tdCompanyRegiserType.ClientID%>");
            tdBusinessTypeObj = $("#<%=this.tdBusinessType.ClientID%>");
            tdInChargeManObj = $("#<%=this.tdInChargeMan.ClientID%>");
            tdOperationCommentObj = $("#<%=this.tdOperationComment.ClientID%>");
        });

    </script>
    <script src="../js/Page/Comm/PinYin.js"></script>
    <script src="../js/Page/Cheque/ChequeOutJZEdit.js?t=<%=getToken() %>"></script>
    <style type="text/css">
        table.info {
            width: 100%;
            margin: 0 auto;
            border: solid 2px #ccc;
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
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div style="padding: 10px 0; width: 90%; margin: 0 auto;">
            <table class="info">
                <tr>
                    <td colspan="4" style="text-align: center;">基本信息</td>
                </tr>
                <tr>
                    <td>工程项目
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdProjectID" runat="server" />
                        <a href="javascript:void(0)" onclick="addProject()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                    <td>提醒日期
                    </td>
                    <td>
                        <input type="text" class="easyui-datebox" id="tdNotifyTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>有效期
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-datebox" id="tdStartTime" runat="server" />
                        -
                        <input type="text" class="easyui-datebox" id="tdEndTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>证件状态</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdIDCardStatus" runat="server" />
                    </td>
                    <td>所属分公司</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBelongCompanyName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>直管部门</td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdDepartmentID" runat="server" />
                        <a href="javascript:void(0)" onclick="addDepartment()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                    <td>审核人</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdApproveMan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>文书号</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdPaperNumber" runat="server" />
                    </td>
                    <td>纳税人名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTaxManName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>纳税人识别号</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdTaxNumber" runat="server" />
                    </td>
                    <td>法定代表人</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdCompanyInChargeMan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>身份证种类</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdIDCardType" runat="server" />
                    </td>
                    <td>身份证号码</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdIDCardNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>生产经营地</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdProduceAddress" runat="server" />
                    </td>
                    <td>外出经营地</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdOutingAddress" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>登记注册类型</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdCompanyRegiserType" runat="server" />
                    </td>
                    <td>经营方式</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBusinessType" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>经办人
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdOperator" runat="server" />
                    </td>
                    <td>经办时间
                    </td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdOperationTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>负责人
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdInChargeMan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>税务机关意见</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdOperationComment" runat="server" data-options="multiline:true" style="height: 50px; width: 80%;" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdRemark" runat="server" data-options="multiline:true" style="height: 50px; width: 80%;" />
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>附件</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
            <div class="easyui-panel" style="height: 350px;" title="外出经营活动情况">
                <table id="tt_table">
                </table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="addTTRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    <a href="javascript:void(0)" onclick="editTTRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="removeTTRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
            <div class="easyui-panel" style="height: 350px;">
                <table id="pp_table">
                </table>
                <div id="pp_mm">
                    <a href="javascript:void(0)" onclick="addPPRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    <a href="javascript:void(0)" onclick="editPPRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                    <a href="javascript:void(0)" onclick="removePPRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
            <div style="text-align: center; padding: 10px 0px;">
                <%if (string.IsNullOrEmpty(Request.QueryString["op"]) || !("view").Equals(Request.QueryString["op"]))
                  { %>
                <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">
                    <%if (this.ID > 0)
                      { %>
                    保存
                    <%}
                      else
                      { %>
                    确认登记
                    <%} %>
                </a>
                <%} %>
                <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>

        </div>
    </form>
</asp:Content>
