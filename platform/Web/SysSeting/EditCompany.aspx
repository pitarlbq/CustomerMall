<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditCompany.aspx.cs" Inherits="Web.SysSeting.EditCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var CompanyID = 0;
        $(function () {
            CompanyID = "<%=Request.QueryString["CompanyID"]%>" || 0;
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var CompanyName = $("#<%=this.tdRealName.ClientID%>").textbox("getValue");
            var PhoneNumber = $("#<%=this.tdPhoneNumber.ClientID%>").textbox("getValue");
            var Description = $("#<%=this.tdDesc.ClientID%>").textbox("getValue");
            var Address = $("#<%=this.tdAddress.ClientID%>").textbox("getValue");
            var ChargeMan = $("#<%=this.tdChargeMan.ClientID%>").textbox("getValue");
            var IsActive = $("#<%=this.tdIsActive.ClientID%>").combobox("getValue");
            var IsPay = $("#<%=this.tdIsPay.ClientID%>").combobox("getValue");
            var Distributor = $("#<%=this.tdDistributor.ClientID%>").textbox("getValue");
            var UserCount = $("#<%=this.tdUserCount.ClientID%>").textbox("getValue");
            var StartTime = $("#<%=this.tdStartTime.ClientID%>").datetimebox("getValue");
            var EndtTime = $("#<%=this.tdEndTime.ClientID%>").datetimebox("getValue");
            var ProjectCount = $("#<%=this.tdProjectCount.ClientID%>").textbox("getValue");
            var VersionCode = $("#<%=this.tdVersionCode.ClientID%>").textbox("getValue");
            var IsHideLogin_LogImg = 1;
            if ($('#<%=this.btnShowLogin_LogImg.ClientID%>').prop('checked')) {
                IsHideLogin_LogImg = 0;
            }
            var IsHideLogin_BodyImg = 1;
            if ($('#<%=this.btnShowLogin_BodyImg.ClientID%>').prop('checked')) {
                IsHideLogin_BodyImg = 0;
            }
            var IsHideHome_LogoImg = 1;
            if ($('#<%=this.btnShowHome_LogoImg.ClientID%>').prop('checked')) {
                IsHideHome_LogoImg = 0;
            }
            var IsHideCopyRightText = 1;
            if ($('#<%=this.btnShowCopyRightText.ClientID%>').prop('checked')) {
                IsHideCopyRightText = 0;
            }
            var CopyRightText = $("#<%=this.tdCopyRightText.ClientID%>").textbox("getValue");
            var AlowRemoteUpdate = $('#<%=this.tdAlowRemoteUpdate.ClientID%>').combobox('getValue');
            var IsWechatOn = $('#<%=this.tdIsWechatOn.ClientID%>').combobox('getValue');
            var ExpiringDay = $('#<%=this.tdExpiringDay.ClientID%>').textbox('getValue');
            var ExpiringShow = 0;
            if ($('#<%=this.btnExpiringShow.ClientID%>').prop('checked')) {
                ExpiringShow = 1;
            }
            var ExpiringMsg = $('#<%=this.tdExpiringMsg.ClientID%>').textbox('getValue');
            MaskUtil.mask('body', '提交中');
            var options = {};
            $('#ff').form('submit', {
                url: '../Handler/UserHandler.ashx',
                onSubmit: function (options) {
                    options.visit = "savecompanyinfo";
                    options.CompanyID = CompanyID;
                    options.CompanyName = CompanyName;
                    options.PhoneNumber = PhoneNumber;
                    options.Description = Description;
                    options.Address = Address;
                    options.ChargeMan = ChargeMan;
                    options.IsActive = IsActive;
                    options.IsPay = IsPay;
                    options.Distributor = Distributor;
                    options.UserCount = UserCount;
                    options.StartTime = StartTime;
                    options.EndtTime = EndtTime;
                    options.ProjectCount = ProjectCount;
                    options.IsHideLogin_LogImg = IsHideLogin_LogImg;
                    options.IsHideLogin_BodyImg = IsHideLogin_BodyImg;
                    options.IsHideHome_LogoImg = IsHideHome_LogoImg;
                    options.IsHideCopyRightText = IsHideCopyRightText;
                    options.CopyRightText = CopyRightText;
                    options.AlowRemoteUpdate = AlowRemoteUpdate;
                    options.IsWechatOn = IsWechatOn;
                    options.VersionCode = VersionCode;
                    options.ExpiringDay = ExpiringDay;
                    options.ExpiringShow = ExpiringShow;
                    options.ExpiringMsg = ExpiringMsg;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var message = eval("(" + data + ")");
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });

        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        function removeLogo(index) {
            var options = {};
            options.visit = "removecompanylogo";
            options.CompanyID = CompanyID;
            options.index = index;
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/UserHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('删除成功', 'success', function () {
                            window.location.reload();
                        });
                    }
                    else if (message.msg) {
                        show_message(message.msg, 'info');
                    }
                    else {
                        show_message('系统异常', 'error');
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .inputcheckbox {
            width: 18px;
            height: 15px;
            vertical-align: middle;
            margin: 0;
        }

        .checkboxlabel {
            vertical-align: middle;
            margin: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>公司名称
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdRealName" runat="server" data-options="required:true" />
                    </td>
                    <td>公司地址
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdAddress" runat="server" />

                    </td>
                </tr>
                <tr>
                    <td>联系人
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdChargeMan" runat="server" />

                    </td>
                    <td>联系电话
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdPhoneNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>经销商
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdDistributor" runat="server" />

                    </td>
                    <td>授权用户数
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdUserCount" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>状态
                    </td>
                    <td>
                        <select id="tdIsActive" runat="server" class="easyui-combobox" style="width: 100px;">
                            <option value="1">启用</option>
                            <option value="0">禁用</option>
                        </select>
                    </td>
                    <td>是否付费
                    </td>
                    <td>
                        <select id="tdIsPay" runat="server" class="easyui-combobox" style="width: 100px;">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select></td>
                </tr>
                <tr>
                    <td>付费服务开始时间
                    </td>
                    <td>
                        <input class="easyui-datetimebox" id="tdStartTime" runat="server" data-options="required:true" />

                    </td>
                    <td>付费服务结束时间
                    </td>
                    <td>
                        <input class="easyui-datetimebox" id="tdEndTime" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>到期提醒</td>
                    <td>提前<input class="easyui-textbox" id="tdExpiringDay" runat="server" style="width: 80px" />天
                         <input type="checkbox" id="btnExpiringShow" runat="server" class="inputcheckbox" /><label class="checkboxlabel">显示</label>
                    </td>
                    <td>提醒信息
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdExpiringMsg" runat="server" data-options="multiline:true" style="height: 50px;" />
                    </td>
                </tr>
                <tr>
                    <td>授权项目数
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdProjectCount" runat="server" />

                    </td>
                    <td>版权信息
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdCopyRightText" runat="server" />
                        <input type="checkbox" id="btnShowCopyRightText" runat="server" class="inputcheckbox" /><label class="checkboxlabel">显示</label>
                    </td>
                </tr>
                <tr>
                    <td>添加登录Logo<br />
                        (尺寸:135 x 50)</td>
                    <td>
                        <%if (!string.IsNullOrEmpty(this.LogoPath))
                          { %>
                        <img src="<%=base.GetContextPath()+this.LogoPath %>" style="width: 100px; height: 100px;" />
                        <a href="javascript:void(0)" onclick="removeLogo(0)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <input id="tdLogoPath" runat="server" class="easyui-filebox" type="text" name="LogoPath" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
                        <input class="inputcheckbox" type="checkbox" id="btnShowLogin_LogImg" runat="server" /><label class="checkboxlabel">显示</label>
                    </td>
                    <td>添加图片<br />
                        (尺寸:490 x 490)</td>
                    <td>
                        <%if (!string.IsNullOrEmpty(this.LogoBodyPath))
                          { %>
                        <img src="<%=base.GetContextPath()+this.LogoBodyPath %>" style="width: 100px; height: 100px;" />
                        <a href="javascript:void(0)" onclick="removeLogo(1)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <input id="tdLogoPathBody" runat="server" class="easyui-filebox" type="text" name="LogoBodyPath" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
                        <input class="inputcheckbox" type="checkbox" id="btnShowLogin_BodyImg" runat="server" /><label class="checkboxlabel">显示</label>
                    </td>
                </tr>
                <tr>
                    <td>添加首页Logo<br />
                        (尺寸:135 x 50)</td>
                    <td>
                        <%if (!string.IsNullOrEmpty(this.HomeLogoPath))
                          { %>
                        <img src="<%=base.GetContextPath()+this.HomeLogoPath %>" style="width: 100px; height: 100px;" />
                        <a href="javascript:void(0)" onclick="removeLogo(3)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <input id="tdHomeLogoPath" runat="server" class="easyui-filebox" type="text" name="HomeLogoPath" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
                        <input type="checkbox" id="btnShowHome_LogoImg" runat="server" class="inputcheckbox" /><label class="checkboxlabel">显示</label>
                    </td>
                    <td>是否允许远程更新
                    </td>
                    <td>
                        <select id="tdAlowRemoteUpdate" runat="server" class="easyui-combobox" style="width: 100px;">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>开通微信
                    </td>
                    <td>
                        <select id="tdIsWechatOn" runat="server" class="easyui-combobox" style="width: 100px;">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                    <td>版本号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdVersionCode" />
                    </td>
                </tr>
                <tr>
                    <td>公司简介
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdDesc" runat="server" data-options="multiline:true" style="height: 100px; width: 85%;" />
                    </td>
                </tr>
                <tr>
                    <td>签名
                    </td>
                    <td>
                        <label runat="server" id="tdSignature"></label>
                    </td>
                    <td>令牌
                    </td>
                    <td>
                        <label runat="server" id="tdToken"></label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
