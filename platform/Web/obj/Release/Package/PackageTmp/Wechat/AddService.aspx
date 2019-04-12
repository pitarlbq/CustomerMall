<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="Web.Wechat.AddService" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var ID = 0;
        $(function () {
            addFile();
        })
        function savedata() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/ServiceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechatservice';
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
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
        var filecount = 0;
        function addFile() {
            $("#tdFile").find("a.fileadd").hide();
            $("#tdFile").find("a.fileremove").show();
            filecount++;
            var $html = "<div id=\"tdFile_" + filecount + "\">";
            $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%\" />";
            $html += '<a href="javascript:void(0)" onclick="addFile()" class="easyui-linkbutton btnlinkbar fileadd" data-options="plain:true,iconCls:\'icon-search\'">添加</a>';
            $html += '<a href="javascript:void(0)" onclick="deleteFile(' + filecount + ')" class="easyui-linkbutton btnlinkbar fileremove" style="display:none;" data-options="plain:true,iconCls:\'icon-search\'">删除</a>';
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function deleteFile(id) {
            $("#tdFile_" + id).html("");
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

        .hidefield {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr class="detail">
                    <td>服务地址
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdFullName" runat="server" style="width: 100%;" />
                    </td>
                </tr>
                <tr class="detail">
                    <td>反馈内容
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdServiceContent" runat="server" data-options="multiline:true" style="height: 100px; width: 100%;" />
                    </td>
                </tr>
                <tr>
                    <td>联系电话
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdPhoneNumber" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>预约时间
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-datetimebox" style="" id="tdServiceAddTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>预约人
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdServiceMan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="savedata()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                        <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
