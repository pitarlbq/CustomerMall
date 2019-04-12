<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditVoteItem.aspx.cs" Inherits="Web.Wechat.EditVoteItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v5"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        var SurveyID, QuestionID, content;
        $(function () {
            SurveyID = "<%=this.SurveyID%>";
            QuestionID = "<%=this.QuestionID%>";
            createEditor();
            setTimeout(function () {
                setContent();
            }, 1000);
            addFile();
            loadattachs();
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechatsurveyquestion';
                    param.QuestionID = QuestionID;
                    param.SurveyID = SurveyID;
                    param.HTMLContent = ue.getContent();
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
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
        var filecount = 0;
        function addFile() {
            $("#tdFile").find("a.fileadd").hide();
            $("#tdFile").find("a.fileremove").show();
            filecount++;
            var $html = "<div id=\"tdFile_" + filecount + "\">";
            $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择文件',buttonText: '选择文件'\" style=\"width: 60%\" />";
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function loadattachs() {
            var options = { visit: 'loadvoteitemcoverimg', ID: QuestionID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").hide();
                    $("#trExistFiles").html($html);
                    if (data.status) {
                        $("#trExistFiles").show();
                        $html += '<td>已上传封面</td>';
                        $html += '<td colspan="3">';
                        $html += '<div style="text-align:center;width:100px;"><img src="' + data.CoverImg + '" style="width:100%;"><br/>';
                        $html += '<a href="#" onclick="deleteAttach()">删除</a></div>';
                        $html += '</td>';
                    }
                    $("#trExistFiles").append($html);
                }
            });
        }
        function deleteAttach() {
            top.$.messager.confirm("提示", "是否删除选已上传的封面?", function (r) {
                if (r) {
                    var options = { visit: 'deletevoteitemcoverimg', ID: QuestionID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/WechatHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('删除成功', 'success', function () {
                                    loadattachs();
                                });
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
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
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>标题
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdQuestionContent" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>简介
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%; height: 60px;" class="easyui-textbox" id="tdQuestionSummary" runat="server" data-options="required:true,multiline:true" />
                    </td>
                </tr>
                <tr>
                    <td>排序
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdSortOrder" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>封面图片</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">详细说明</td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: left;">
                        <script id="tdContent" type="text/plain" style="width: 100%; height: 300px;">
                        </script>
                        <asp:HiddenField runat="server" ID="hdContent" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
