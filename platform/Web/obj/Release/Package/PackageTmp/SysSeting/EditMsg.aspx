<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditMsg.aspx.cs" Inherits="Web.SysSeting.EditMsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v5"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        var ID, MsgType, hdCompanys, tdCompanyNames, tdDisableNotify, tdIsNotifyALL;
        $(function () {
            ID = "<%=this.ID%>";
            hdCompanys = $('#<%=this.hdCompanys.ClientID%>');
            tdCompanyNames = $('#<%=this.tdCompanyNames.ClientID%>');
            tdDisableNotify = $('#<%=this.tdDisableNotify.ClientID%>');
            tdIsNotifyALL = $('#<%=this.tdIsNotifyALL.ClientID%>');
            createEditor();
            setTimeout(function () {
                setContent();
            }, 1000);
            do_change_status();
            tdDisableNotify.combobox({
                editable: false,
                onSelect: function (ret) {
                    do_change_status();
                }
            })
            tdIsNotifyALL.combobox({
                editable: false,
                onSelect: function (ret) {
                    do_change_status();
                }
            })
        });
        function do_change_status() {
            var DisableNotify = tdDisableNotify.combobox('getValue');
            var IsNotifyALL = tdIsNotifyALL.combobox('getValue');
            if (IsNotifyALL == '1' || DisableNotify == '1') {
                $('#tr_company_box').hide();
            } else {
                $('#tr_company_box').show();
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/SettingHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savesystemmsg';
                    param.ID = ID;
                    param.HTMLContent = ue.getContent();
                    param.CompanyIDs = hdCompanys.val();
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message("任务记录不存在", "info");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }

        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#tt_table").datagrid("reload");
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
                ]
                ],
                autoHeightEnabled: true,
                autoFloatEnabled: true
            });
        }
        var isupdate = false;
        function chooseproject() {
            isupdate = false;
            var iframe = "<iframe id='myFrame' scrolling='auto' frameborder='0' src='../SysSeting/ConnectSystemMsgCompany.aspx?MsgID=" + ID + "' style='width:100%;height:" + ($(window).height() - 40) + "px'></iframe>";
            $("<div id='winchoose'></div>").appendTo("body").window({
                title: '选择通知范围',
                width: ($(window).width() - 200),
                height: $(window).height(),
                top: 0,
                left: 100,
                modal: true,
                minimizable: false,
                maximizable: false,
                collapsible: false,
                content: iframe,
                onClose: function () {
                    $("#winchoose").remove();
                }
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
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdTitle" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>是否置顶</td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdIsTopShow" runat="server" style="width: 100px">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select></td>
                    <td>排序</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdSortOrder" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>是否通知客户
                    </td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdDisableNotify" runat="server" style="width: 100px">
                            <option value="0">是</option>
                            <option value="1">否</option>
                        </select>
                    </td>
                    <td>通知全部
                    </td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdIsNotifyALL" runat="server" style="width: 100px">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr id="tr_company_box">
                    <td>发布范围</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdCompanyNames" data-options="multiline:true,readonly:true" style="height: 50px; width: 80%;" runat="server" />
                        <asp:HiddenField runat="server" ID="hdCompanys" />
                        <label>
                            <a href="javascript:void(0)" onclick="chooseproject()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                    </td>
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
