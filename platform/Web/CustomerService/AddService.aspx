<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent6.Master" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="Web.CustomerService.AddService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken()%>"></script>
    <script>
        var ID, ProjectID, tdFullNameObj, tdAddCustomerNameObj, tdAddCallPhoneObj, tdProjectNameObj, tdServiceNumberObj, hdOrderNumberIDObj, tdServiceAreaObj, ffObj, AddMan, tdAcceptManObj, hdAcceptManObj, tdServiceTypeObj, hdServiceTypeNameObj, guid, tdHandelFeeObj, tdTotalFeeObj, tdIsRequireCost, tdIsRequireProduct, tdIsSendAPP, WechatServiceID, tdTaskType, tdAcceptManInput, tdBelongTeamName, hdDepartmentID;
        $(function () {
            ID = 0;
            ProjectID = Number("<%=this.ProjectID%>");
            tdFullNameObj = $("#<%=this.tdFullName.ClientID%>");
            tdAddCustomerNameObj = $("#<%=this.tdAddCustomerName.ClientID%>");
            tdAddCallPhoneObj = $("#<%=this.tdAddCallPhone.ClientID%>");
            tdProjectNameObj = $("#<%=this.tdProjectName.ClientID%>");
            tdServiceNumberObj = $("#<%=this.tdServiceNumber.ClientID%>");
            hdOrderNumberIDObj = $("#<%=this.hdOrderNumberID.ClientID%>");
            tdServiceAreaObj = $("#<%=this.tdServiceArea.ClientID%>");
            ffObj = $("#<%=this.ff.ClientID%>");
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            tdAcceptManObj = $("#<%=this.tdAcceptMan.ClientID%>");
            hdAcceptManObj = $("#<%=this.hdAcceptMan.ClientID%>");
            tdServiceTypeObj = $("#<%=this.tdServiceType.ClientID%>");
            hdServiceTypeNameObj = $("#<%=this.hdServiceTypeName.ClientID%>");
            tdHandelFeeObj = $("#<%=this.tdHandelFee.ClientID%>");
            tdTotalFeeObj = $("#<%=this.tdTotalFee.ClientID%>");
            tdIsRequireCost = $("#<%=this.tdIsRequireCost.ClientID%>");
            tdIsRequireProduct = $("#<%=this.tdIsRequireProduct.ClientID%>");
            tdIsSendAPP = $("#<%=this.tdIsSendAPP.ClientID%>");
            guid = "<%=this.guid%>";
            WechatServiceID = "<%=this.WechatServiceID%>";
            tdTaskType = $("#<%=this.tdTaskType.ClientID%>");
            tdAcceptManInput = $("#<%=this.tdAcceptManInput.ClientID%>");
            tdBelongTeamName = $("#<%=this.tdBelongTeamName.ClientID%>");
            hdDepartmentID = $("#<%=this.hdDepartmentID.ClientID%>");
            tdFullNameObj.textbox('setValue', ' ');
            $.extend($.fn.validatebox.defaults.rules, {
                ProjectNotEmpty: {
                    validator: function (value, param) {
                        return $.trim(value).length > 0;
                    },
                    message: '请选择资源位置'
                }
            });
        });
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/Page/CustomerService/ServiceAdd.js?t=<%=base.getToken()%>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
    <%--<script>
        $(function () {
            var width = $(window).width();
            var leftwidth = $('.layout-panel-west').width();
            $('table.info').css('width', (width - leftwidth - 20) + 'px');
        })
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="savedata(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-banjie'">办结</a>
            <a href="javascript:void(0)" onclick="savedata(0)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="sendjpushapp()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-banjie'">推送至APP</a>
            <a href="javascript:void(0)" onclick="doprint()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">派单打印</a>
            <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">客服登记单</td>
                </tr>
                <tr>
                    <td>资源位置</td>
                    <td colspan="3">
                        <input type="text" runat="server" data-options="validType:'ProjectNotEmpty',required:true" name="FullName" class="easyui-validatebox easyui-textbox" id="tdFullName" style="width: 80%" /></td>
                </tr>
                <tr>
                    <td>项目名称</td>
                    <td>
                        <input type="text" runat="server" data-options="required:true" name="ProjectName" class="easyui-textbox" id="tdProjectName" /></td>
                    <td>任务标签</td>
                    <td>
                        <input type="text" runat="server" data-options="required:false" name="ProjectName" class="easyui-combobox" id="tdTaskType" style="width: 50%;" />
                        <label><a href="javascript:void(0)" onclick="addTask()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a></label>
                    </td>
                </tr>
                <tr>
                    <td>服务类别</td>
                    <td colspan="3">
                        <input type="text" runat="server" data-options="required:false" name="ServiceType" class="easyui-combobox" id="tdServiceType" style="width: 70px;" />
                        <input type="hidden" runat="server" id="hdServiceTypeName" />
                        <label style="padding: 0 20px;">
                            <input type="checkbox" id="tdIsRequireCost" runat="server" />有偿
                        </label>
                        <label>
                            <input type="checkbox" id="tdIsRequireProduct" runat="server" />领料
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>登记信息</td>
                    <td colspan="3">当前登记人: <span id="sAddUserName" runat="server"></span>&nbsp;&nbsp;&nbsp;&nbsp;登记时间: <span id="sStartTime" runat="server"></span></td>
                </tr>
                <tr style="display: none;">
                    <td>登记人</td>
                    <td>
                        <input type="text" runat="server" name="AddMan" class="easyui-textbox" id="tdAddUserName" /></td>
                    <td>登记时间</td>
                    <td>
                        <input type="text" runat="server" name="StartTime" class="easyui-datetimebox" id="tdStartTime" /></td>
                </tr>
                <tr>
                    <td>服务区域</td>
                    <td>
                        <select type="text" runat="server" data-options="required:true" name="ServiceArea" class="easyui-combobox" id="tdServiceArea">
                            <option value="个人区域">个人区域</option>
                            <option value="公共区域">公共区域</option>
                        </select></td>
                    <td>客服单号</td>
                    <td>
                        <input type="text" runat="server" name="ServiceNumber" class="easyui-textbox" id="tdServiceNumber" />
                        <input type="hidden" runat="server" id="hdOrderNumberID" />
                    </td>
                </tr>
                <tr>
                    <td>客户姓名</td>
                    <td>
                        <input type="text" runat="server" name="AddCustomer" class="easyui-textbox" id="tdAddCustomerName" /></td>
                    <td>联系电话</td>
                    <td>
                        <input type="text" runat="server" name="CallPhone" class="easyui-textbox" id="tdAddCallPhone" /></td>
                </tr>
                <tr>
                    <td>内容描述</td>
                    <td colspan="3" style="width: 75%;">
                        <input type="text" runat="server" name="ServiceContent" class="easyui-textbox" id="tdServiceContent" data-options="multiline:true" style="width: 80%; height: 60px;" /></td>
                </tr>
                <tr>
                    <td>负责部门
                    </td>
                    <td>
                        <input type="text" class="easyui-combobox" id="tdBelongTeamName" runat="server" data-options="editable:false" style="width: 50%;" />
                        <asp:HiddenField runat="server" ID="hdDepartmentID" />
                        <a href="javascript:void(0)" onclick="addDepartment()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-add'">选择</a>
                    </td>
                    <td>接单人</td>
                    <td>
                        <label id="label_accpetman_combobox">
                            <input type="text" runat="server" name="AcceptMan" class="easyui-combobox" id="tdAcceptMan" style="width: 150px;" /><input type="hidden" runat="server" id="hdAcceptMan" />
                        </label>
                        <label id="label_accpetman_textbox">
                            <input type="text" runat="server" name="AcceptMan" class="easyui-textbox" id="tdAcceptManInput" style="width: 150px;" />
                        </label>
                        <label style="padding: 0 20px;">
                            <input type="checkbox" id="tdIsSendAPP" runat="server" />发送APP工单
                        </label>
                    </td>
                </tr>
                <tr id="trRequireCost">
                    <td>维修工费</td>
                    <td>
                        <input type="text" runat="server" name="HandelFee" class="easyui-textbox" id="tdHandelFee" /></td>
                    <td>收费金额</td>
                    <td>
                        <input type="text" runat="server" name="TotalFee" class="easyui-textbox" id="tdTotalFee" /></td>
                </tr>
                <tr>
                    <td>预约时间</td>
                    <td colspan="3">
                        <input type="text" runat="server" name="AppointTime" class="easyui-datetimebox" id="tdAppointTime" /></td>
                </tr>
                <tr>
                    <td>附件</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
            <div class="easyui-panel" id="divProductPanel" style="height: 350px;">
                <table id="tt_table">
                </table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="addRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">新增</a>
                    <a href="javascript:void(0)" onclick="removeRow()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </div>
            </div>
            <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
            <div id="wincomplete" class="easyui-window" title="补充信息" style="width: 400px; height: 300px"
                data-options="iconCls:'icon-save',modal:true">
                <table class="info">
                    <tr>
                        <td>办结时间:</td>
                        <td colspan="3">
                            <input type="text" class="easyui-datebox" id="tdCompleteTime" /></td>
                    </tr>
                    <tr>
                        <td colspan="4" style="width: 100%; text-align: center;">
                            <a href="javascript:void(0)" onclick="savedata(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-banjie'">办结</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</asp:Content>
