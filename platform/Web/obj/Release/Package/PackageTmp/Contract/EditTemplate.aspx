<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditTemplate.aspx.cs" Inherits="Web.Contract.EditTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>任务登记</title>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js?v4"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v6"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        $(function () {
            createEditor();
            setTimeout(function () {
                setContent();
            }, 1000);
        });
        function setContent() {
            var content = $("#<%=this.hdContent.ClientID%>").val();
            ue.setContent(content, false);
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
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
                ],
                ["customername", "|", "customerphone", "|", "signdate", "|", "startdate", "|", "waringdate", "|", "rentmoney", "|", "rentmoneydaxie", "|", "despoitmoney", "|", "freechargedate", "|", "renthomename", "|", "totalarea", "|", "inchargeman", "|", "address", "|", "idcardno", "|", "idcardaddress"]
                ],
                autoHeightEnabled: true,
                autoFloatEnabled: true
            });
            ue.ready(function () {
                var e = $(ue.container),
                define_menus = ["customername", "customerphone", "signdate", "startdate", "waringdate", "rentmoney", "rentmoneydaxie", "despoitmoney", "freechargedate", "renthomename", "totalarea", "inchargeman", "address", "idcardno", "idcardaddress"];
                for (var r = 0; r <= define_menus.length; r++) {
                    var a = e.find(".edui-for-" + define_menus[r]),
                    o = a.find(".edui-button-body"),
                    i = o.attr("title");
                    o.html(i).css("font-size", "12px")
                }
            })
        }
        function do_save() {
            var isValid = $('#<%=this.ff.ClientID%>').form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ID = "<%=this.ID%>";
            var TemplateNo = $('#<%=this.tdTemplateNo.ClientID%>').textbox('getValue');
            var TemplateName = $('#<%=this.tdTemplateName.ClientID%>').textbox('getValue');
            var TemplateSummary = $('#<%=this.tdTemplateSummary.ClientID%>').textbox('getValue');
            var HTMLContent = ue.getContent();
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'savecontracttemplate', ID: ID, TemplateNo: TemplateNo, TemplateName: TemplateName, TemplateSummary: TemplateSummary, HTMLContent: HTMLContent };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ContractHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
    </script>
    <style>
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
                    <td>模板编号</td>
                    <td>
                        <input type="text" runat="server" name="TemplateNo" class="easyui-textbox" id="tdTemplateNo" data-options="required:true" /></td>
                    <td>模板名称</td>
                    <td>
                        <input type="text" runat="server" name="TemplateName" class="easyui-textbox" id="tdTemplateName" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>模板说明</td>
                    <td colspan="3">
                        <input type="text" runat="server" name="TemplateSummary" class="easyui-textbox" data-options="multiline:true" id="tdTemplateSummary" style="width: 80%; height: 80px;" /></td>
                </tr>
                <tr>
                    <td>合同编号</td>
                    <td>{合同编号}</td>
                    <td>合同名称</td>
                    <td>{合同名称}</td>
                </tr>
                <tr>
                    <td>合同模板</td>
                    <td colspan="3">
                        <%if (this.ID > 0)
                          { %>
                        <div style="text-align: right;">
                            <a target="_blank" href="TemplateView.aspx?ID=<%=this.ID %>" onclick="doview()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-detail'">预览</a>
                        </div>
                        <%} %>
                        <script id="tdContent" type="text/plain" style="width: 100%; height: 300px;">
                        </script>
                        <asp:HiddenField runat="server" ID="hdContent" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
