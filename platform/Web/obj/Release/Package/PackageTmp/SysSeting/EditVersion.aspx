<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditVersion.aspx.cs" Inherits="Web.SysSeting.EditVersion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var VersionID = 0;
        $(function () {
            VersionID = Number("<%=this.VersionID%>");
            $('#<%=this.tdVersionType.ClientID%>').combobox({
                onSelect: function (ret) {
                    VersionTypeChange();
                }
            })
            VersionTypeChange();
        })
        function VersionTypeChange() {
            var value = $('#<%=this.tdVersionType.ClientID%>').combobox('getValue');
            if (value == 'platform') {
                $('#trplatform').show();
            }
            else {
                $('#trplatform').hide();
            }
        }
        function saveResource() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var VersionCode = $("#<%=this.tdVersionCode.ClientID%>").numberbox("getValue");
            var VersionDesc = $("#<%=this.tdVersionDesc.ClientID%>").textbox("getValue");
            var VersionType = $("#<%=this.tdVersionType.ClientID%>").combobox("getValue");
            MaskUtil.mask('body', '提交中');
            var options = {};
            $('#ff').form('submit', {
                url: '../Handler/SysSettingHandler.ashx',
                onSubmit: function (options) {
                    options.visit = "savesiteversion";
                    options.VersionID = VersionID;
                    options.VersionCode = VersionCode;
                    options.VersionDesc = VersionDesc;
                    options.VersionType = VersionType;
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
                    <td>版本号
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-numberbox" id="tdVersionCode" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>类型</td>
                    <td>
                        <select class="easyui-combobox" id="tdVersionType" runat="server">
                            <option value="platform">后台</option>
                            <option value="android">APP(Android)</option>
                            <option value="ios">APP(IOS)</option>
                            <option value="weixin">微信</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>文件地址(.zip)
                    </td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.FilePath))
                          { %>
                        <a href="<%=base.GetContextPath()+this.FilePath %>" target="_blank">下载</a>
                        <a href="javascript:void(0)" onclick="removeFile(1)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <input id="tdFilePath" runat="server" class="easyui-filebox" type="text" name="FilePath" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
                    </td>
                </tr>
                <tr id="trplatform">
                    <td>脚本地址(.sql)
                    </td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.SqlPath))
                          { %>
                        <a href="<%=base.GetContextPath()+this.SqlPath %>" target="_blank">下载</a>
                        <a href="javascript:void(0)" onclick="removeFile(2)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                        <input id="Text1" runat="server" class="easyui-filebox" type="text" name="FilePath" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" />
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
