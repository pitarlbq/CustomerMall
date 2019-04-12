<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditMsg.aspx.cs" Inherits="Web.Wechat.EditMsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v5"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        var ID, MsgType, hdProjectIDs, type = 1, msgtypeid = 1;
        $(function () {
            type = Number("<%=this.type%>");
            msgtypeid = Number("<%=this.msgtypeid%>");
            ID = "<%=this.ID%>";
            hdProjectIDs = $('#<%=this.hdProjectIDs.ClientID%>');
            createEditor();
            setTimeout(function () {
                setContent();
            }, 1000);
            addFile();
            loadattachs();
            getwechatprojects();
            //check_sendtype_status();
            get_msgtype();
            var hd_categories = $('#<%=this.hdCategory.ClientID%>').val();
            var category_list = eval("(" + hd_categories + ")");
            $('#<%=this.tdCategoryID.ClientID%>').combobox({
                editable: false,
                valueField: 'ID',
                textField: 'CategoryName',
                data: category_list
            })
        });
        function get_msgtype() {
            MsgType = "<%=this.MsgType%>";
            if (MsgType == "" || MsgType == null) {
                if (msgtypeid == 1) {
                    MsgType = "tongzhi";
                }
                else if (msgtypeid == 2) {
                    MsgType = "huodong";
                }
                else if (msgtypeid == 3) {
                    MsgType = "news";
                }
            }
            if (MsgType == 'news') {
                $('.news_category').show();
            }
            else {
                $('.news_category').hide();
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var IsWechatSend = 0;
            var IsUserAPPSend = 0;
            var IsCustomerAPPSend = 0;
            var IsBusinessAPPSend = 0;
            if ($('#<%=this.tdIsWechatSend.ClientID%>').prop('checked')) {
                IsWechatSend = 1;
            }
            if ($('#<%=this.tdIsCustomerAPPSend.ClientID%>').prop('checked')) {
                IsCustomerAPPSend = 1;
            }
            if ($('#<%=this.tdIsUserAPPSend.ClientID%>').prop('checked')) {
                IsUserAPPSend = 1;
            }
            if ($('#<%=this.tdIsBusinessAPPSend.ClientID%>').prop('checked')) {
                IsBusinessAPPSend = 1;
            }
            if (IsWechatSend == 0 && IsCustomerAPPSend == 0 && IsUserAPPSend == 0 && IsBusinessAPPSend == 0) {
                show_message('请至少选择一项通知对象');
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechatmsg';
                    param.ID = ID;
                    param.AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
                    param.MsgType = MsgType;
                    param.HTMLContent = ue.getContent();
                    param.MsgContent = ue.getContentTxt();
                    param.ProjectIDs = hdProjectIDs.val();
                    param.IsWechatSend = IsWechatSend;
                    param.IsCustomerAPPSend = IsCustomerAPPSend;
                    param.IsUserAPPSend = IsUserAPPSend;
                    param.IsBusinessAPPSend = IsBusinessAPPSend;
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
                        show_message("数据不存在", "info");
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
            var options = { visit: 'loadwechatmsgcover', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/WechatHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").html($html);
                    if (data.status) {
                        $("#trExistFiles").show();
                        $html += '<td>已上传封面</td>';
                        $html += '<td colspan="3">';
                        $html += '<div><img src="' + data.PicPath + '" style="width:100px;">';
                        $html += '<a href="#" onclick="deleteAttach(' + ID + ')">删除</a></div>';
                        $html += '</td>';
                    }
                    $("#trExistFiles").append($html);
                }
            });
        }
        function deleteAttach(AttachID) {
            top.$.messager.confirm("提示", "是否删除选已上传的文件?", function (r) {
                if (r) {
                    var options = { visit: 'deleteconver', ID: AttachID };
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
                toolbars: [["fullscreen", "source", "|", "undo", "redo", "|", "bold", "italic", "underline", "fontborder", "strikethrough", "superscript", "subscript", "removeformat", "formatmatch", "autotypeset", "blockquote", "pasteplain", "|", "forecolor", "backcolor", "insertorderedlist", "insertunorderedlist", "selectall", "cleardoc", "|", "rowspacingtop", "rowspacingbottom", "lineheight", "|", "customstyle", "paragraph", "fontfamily", "fontsize", "|", "directionalityltr", "directionalityrtl", "indent", "|", "justifyleft", "justifycenter", "justifyright", "justifyjustify", "|", "touppercase", "tolowercase", "|", "link", "unlink", "anchor", "|", "emotion", "|", "horizontal", "date", "time", "spechars", "|", "preview", 'simpleupload', 'insertvideo', "help"
                ]
                ],
                autoHeightEnabled: true,
                autoFloatEnabled: true
            });
        }
        var isupdate = false;
        function chooseproject() {
            isupdate = false;
            var iframe = "../Wechat/ConnectMsgRoom.aspx?MsgID=" + ID;
            do_open_dialog('选择发布范围', iframe);
        }
        function ConnectMsgRoom_Done() {
            if (isupdate) {
                getwechatprojects();
            }
        }
        function getwechatprojects() {
            MaskUtil.mask('body', '加载中');
            var options = { visit: 'getwechatprojects', ProjectIDs: hdProjectIDs.val() };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: "../Handler/WechatHandler.ashx",
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        $('#tdProjects').textbox('setValue', data.namestr);
                    } else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function check_sendtype_status() {
            $('#<%=this.tdIsWechatSend.ClientID%>').prop('disabled', false);
            $('#<%=this.tdIsCustomerAPPSend.ClientID%>').prop('disabled', false);
            $('#<%=this.tdIsUserAPPSend.ClientID%>').prop('disabled', false);
            if (type == 1) {
                $('#<%=this.tdIsWechatSend.ClientID%>').prop('disabled', false);
            }
            else if (type == 2) {
                $('#<%=this.tdIsCustomerAPPSend.ClientID%>').prop('disabled', false);
            }
            else if (type == 3) {
                $('#<%=this.tdIsUserAPPSend.ClientID%>').prop('disabled', false);
            }
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

        input, select {
            width: 200px;
        }

        .hidefield {
            display: none;
        }

        .sendtype label {
            margin-right: 10px;
            height: 25px;
            line-height: 25px;
            position: relative;
            padding-right: 25px;
        }

        .sendtype input {
            width: 20px;
            height: 20px;
            position: absolute;
            top: 50%;
            right: 0;
            margin-top: -10px;
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
                <tr class="detail">
                    <td>摘要
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdSummary" runat="server" data-options="multiline:true" style="height: 40px; width: 70%;" />
                    </td>
                </tr>
                <tr>
                    <td>发布日期
                    </td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdPublishTime" runat="server" data-options="required:true" />
                    </td>
                    <td>是否发布
                    </td>
                    <td>
                        <select class="easyui-combobox" id="tdIsShow" runat="server" data-options="editable:false">
                            <option value="1">发布</option>
                            <option value="0">不发布</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>是否置顶</td>
                    <td>
                        <select class="easyui-combobox" id="tdIsTopShow" runat="server" style="width: 200px" data-options="editable:false">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select></td>
                    <td>排序序号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdSortOrder" runat="server" style="width: 200px" />
                    </td>
                </tr>
                <tr class="news_category" style="display: none;">
                    <td>新闻类别</td>
                    <td colspan="3">
                        <input type="text" class="easyui-combobox" id="tdCategoryID" runat="server" style="width: 200px" data-options="editable:false" />
                        <asp:HiddenField runat="server" ID="hdCategory" />
                    </td>
                </tr>
                <tr>
                    <td>有效期</td>
                    <td colspan="3">
                        <input type="text" class="easyui-datetimebox" id="tdStartTime" runat="server" />
                        -
                        <input type="text" class="easyui-datetimebox" id="tdEndTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>通知对象</td>
                    <td colspan="3" class="sendtype">
                        <label>微信通知<input type="checkbox" runat="server" id="tdIsWechatSend" /></label>
                        <%if (this.IsMallOn)
                          { %>
                        <label>业主APP通知<input type="checkbox" runat="server" id="tdIsCustomerAPPSend" /></label>
                        <%} %>
                        <%if (this.IsMallInHouseUserOn)
                          { %>
                        <label>员工APP通知<input type="checkbox" runat="server" id="tdIsUserAPPSend" /></label>
                        <%} %>
                        <%if (this.IsMallBusinessOn)
                          { %>
                        <label>商户APP通知<input type="checkbox" runat="server" id="tdIsBusinessAPPSend" /></label>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td>发布范围</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdProjects" data-options="multiline:true,readonly:true" style="height: 50px; width: 80%;" />
                        <asp:HiddenField runat="server" ID="hdProjectIDs" />
                        <label>
                            <a href="javascript:void(0)" onclick="chooseproject()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>封面图片</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center;">正文</td>
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
