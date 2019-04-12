<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="Web.APPSetup.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v5"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        $(function () {
            createEditor();
            setTimeout(function () {
                setContent();
            }, 1000);
        });
        var filecount = 0;
        var ue;
        function setContent() {
            var content = $("#<%=this.hdContent.ClientID%>").val();
            ue.setContent(content, false);
        }
        function createEditor() {
            window.SERVERAPPLICATION = "<%=Web.WebUtil.getApplicationPath()%>";
            ue = UE.getEditor('tdContent', {
                toolbars: [["fullscreen", "source", "|", "undo", "redo", "|", "bold", "italic", "underline", "fontborder", "strikethrough", "superscript", "subscript", "removeformat", "formatmatch", "autotypeset", "blockquote", "pasteplain", "|", "forecolor", "backcolor", "insertorderedlist", "insertunorderedlist", "selectall", "cleardoc", "|", "rowspacingtop", "rowspacingbottom", "lineheight", "|", "customstyle", "paragraph", "fontfamily", "fontsize", "|", "directionalityltr", "directionalityrtl", "indent", "|", "justifyleft", "justifycenter", "justifyright", "justifyjustify", "|", "touppercase", "tolowercase", "|", "link", "unlink", "anchor", "|", "emotion", "|", "horizontal", "date", "time", "spechars", "|", "preview", 'simpleupload', "help"
                ]
                ],
                autoHeightEnabled: true,
                autoFloatEnabled: true
            });
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveaboutus';
                    param.HTMLContent = ue.getContent();
                    param.phone = $('#<%=this.tdPhoneNumber.ClientID%>').textbox('getValue');
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success');
                        closeWin();
                        return;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr>
                    <td>客户热线
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdPhoneNumber" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td>分享标题</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdShareTile" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td>分享描述</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdShareDescription" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td>Android下载地址</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdAndroidDownloadURL" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td>IOS下载地址</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdIOSDownloadURL" style="width: 300px;" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">关于我们
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left;">
                        <script id="tdContent" type="text/plain" style="width: 100%; height: 300px;">
                        </script>
                        <asp:HiddenField runat="server" ID="hdContent" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
