<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="APPVersionEdit.aspx.cs" Inherits="Web.SysSeting.APPVersionEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var VersionID = 0, tdVersionType;
        $(function () {
            VersionID = Number("<%=this.VersionID%>");
            tdVersionType = $('#<%=this.tdVersionType.ClientID%>');
            tdVersionType.combobox({
                onSelect: function () {
                    do_change_status();
                }
            })
            do_change_status();
        })
        function do_change_status() {
            var value = tdVersionType.combobox('getValue');
            if (value == "android") {
                $('#td_FilePath_Android').show();
                $('#td_FilePath_IOS').hide();
            }
            else {
                $('#td_FilePath_Android').hide();
                $('#td_FilePath_IOS').show();
            }
        }
        function saveResource() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var APPVersionCode = $("#<%=this.tdAPPVersionCode.ClientID%>").numberbox("getValue");
            var APPVersionDesc = $("#<%=this.tdAPPVersionDesc.ClientID%>").numberbox("getValue");
            var VersionDesc = $("#<%=this.tdVersionDesc.ClientID%>").textbox("getValue");
            var VersionType = $("#<%=this.tdVersionType.ClientID%>").combobox("getValue");
            var APPType = $("#<%=this.tdAPPType.ClientID%>").combobox("getValue");
            var IOS_FilePath = $("#<%=this.tdIOS_FilePath.ClientID%>").textbox("getValue");
            var DisableUpdate = $("#<%=this.tdDisableUpdate.ClientID%>").combobox("getValue");
            var IsForceUpdate = $("#<%=this.tdIsForceUpdate.ClientID%>").combobox("getValue");
            MaskUtil.mask('body', '提交中');
            var options = {};
            $('#ff').form('submit', {
                url: '../Handler/SysSettingHandler.ashx',
                onSubmit: function (options) {
                    options.visit = "savesiteversion";
                    options.VersionID = VersionID;
                    options.APPVersionCode = APPVersionCode;
                    options.APPVersionDesc = APPVersionDesc;
                    options.VersionDesc = VersionDesc;
                    options.VersionType = VersionType;
                    options.APPType = APPType;
                    options.IOS_FilePath = IOS_FilePath;
                    options.DisableUpdate = DisableUpdate;
                    options.IsForceUpdate = IsForceUpdate;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var message = eval("(" + data + ")");
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            closeWin();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
        function removeFile(index) {
            top.$.messager.confirm('提示', '确认删除?', function (r) {
                if (r) {
                    var options = {};
                    options.visit = "removeversionfile";
                    options.VersionID = VersionID;
                    options.index = index;
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/SysSettingHandler.ashx',
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
            })
        }
    </script>
    <style type="text/css">
        table.info {
            width: 90%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
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

        input {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff" method="post" enctype="multipart/form-data">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr>
                    <td>版本
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdAPPVersionDesc" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>版本号
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-numberbox" id="tdAPPVersionCode" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>安装包类型</td>
                    <td>
                        <select class="easyui-combobox" id="tdVersionType" runat="server">
                            <option value="android">APP(Android)</option>
                            <option value="ios">APP(IOS)</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>APP类型</td>
                    <td>
                        <select class="easyui-combobox" id="tdAPPType" runat="server">
                            <option value="1">业主端</option>
                            <option value="2">员工端</option>
                            <option value="3">商家端</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>允许更新</td>
                    <td>
                        <select class="easyui-combobox" id="tdDisableUpdate" runat="server">
                            <option value="0">允许</option>
                            <option value="1">不允许</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>强制更新</td>
                    <td>
                        <select class="easyui-combobox" id="tdIsForceUpdate" runat="server">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>安装包
                    </td>
                    <td id="td_FilePath_Android" colspan="3">
                        <%if (!string.IsNullOrEmpty(this.FilePath))
                          { %>
                        <a href="<%=base.GetContextPath()+this.FilePath %>" target="_blank">下载</a>
                        <a href="javascript:void(0)" onclick="removeFile(1)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <input id="tdFilePath" runat="server" class="easyui-filebox" type="text" name="FilePath" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
                    </td>
                    <td id="td_FilePath_IOS" colspan="3" style="text-align: left;">
                        <input type="text" style="width: 300px;" class="easyui-textbox" id="tdIOS_FilePath" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>版本描述
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdVersionDesc" runat="server" data-options="multiline:true" style="height: 100px; width: 100%;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="saveResource()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
