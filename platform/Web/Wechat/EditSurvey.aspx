<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditSurvey.aspx.cs" Inherits="Web.Wechat.EditSurvey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var SurveyID, type, SurveyType, hdProjectIDs, tdProjects, tdIsAllowRepeatVoteYes;
        $(function () {
            SurveyID = "<%=this.SurveyID%>";
            type = "<%=this.type%>";
            SurveyType = "<%=this.SurveyType%>";
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
            tdProjects = $("#<%=this.tdProjects.ClientID%>");
            tdIsAllowRepeatVoteYes = $("#<%=this.tdIsAllowRepeatVoteYes.ClientID%>");
            tdIsAllowRepeatVoteYes.bind('click', function () {
                check_status();
            })
            check_status();
        });
        function check_status() {
            if (tdIsAllowRepeatVoteYes.prop('checked')) {
                $('.tr_allowrepeatvote').show();
            } else {
                $('.tr_allowrepeatvote').hide();
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
            if ($('#<%=this.tdIsWechatSend.ClientID%>').prop('checked')) {
                IsWechatSend = 1;
            }
            if ($('#<%=this.tdIsCustomerAPPSend.ClientID%>').prop('checked')) {
                IsCustomerAPPSend = 1;
            }
            if ($('#<%=this.tdIsUserAPPSend.ClientID%>').prop('checked')) {
                IsUserAPPSend = 1;
            }
            if (IsWechatSend == 0 && IsCustomerAPPSend == 0 && IsUserAPPSend == 0) {
                show_message('请至少选择一项发布对象');
                return;
            }
            var IsAllowRepeatVoteYes = 0;
            if (tdIsAllowRepeatVoteYes.prop('checked')) {
                IsAllowRepeatVoteYes = 1;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechatsurvey';
                    param.SurveyID = SurveyID;
                    param.type = type;
                    param.SurveyType = SurveyType;
                    param.IsWechatSend = IsWechatSend;
                    param.IsCustomerAPPSend = IsCustomerAPPSend;
                    param.IsUserAPPSend = IsUserAPPSend;
                    param.ProjectIDList = hdProjectIDs.val();
                    param.IsAllowRepeatVoteYes = IsAllowRepeatVoteYes;
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
        function chooseproject() {
            var iframe = "../Wechat/ConnectMsgRoom.aspx";
            do_open_dialog('选择发布范围', iframe);
        }
        function ConnectMsgRoom_Done() {
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.doSearchTree();
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
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
                    <td>
                        <label runat="server" id="tdLabel"></label>
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdDescription" runat="server" data-options="multiline:true" style="height: 60px; width: 70%;" />
                    </td>
                </tr>
                <tr>
                    <td>是否发布
                    </td>
                    <td>
                        <select type="text" style="width: 100px;" class="easyui-combobox" id="tdStatus" runat="server" data-options="editable:false">
                            <option value="1">发布</option>
                            <option value="0">不发布</option>
                        </select>
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
                    <td>发布对象</td>
                    <td colspan="3" class="sendtype">
                        <label>微信端<input type="checkbox" runat="server" id="tdIsWechatSend" /></label>
                        <label>业主APP端<input type="checkbox" runat="server" id="tdIsCustomerAPPSend" /></label>
                        <label>员工APP端<input type="checkbox" runat="server" id="tdIsUserAPPSend" /></label>
                    </td>
                </tr>
                <tr>
                    <td>发布范围</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdProjects" runat="server" data-options="multiline:true,readonly:true" style="height: 50px; width: 80%;" />
                        <asp:HiddenField runat="server" ID="hdProjectIDs" />
                        <label>
                            <a href="javascript:void(0)" onclick="chooseproject()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>允许重复点赞(投票)
                    </td>
                    <td colspan="3" class="sendtype">
                        <label>
                            <input type="checkbox" runat="server" id="tdIsAllowRepeatVoteYes" />是</label>
                    </td>
                </tr>
                <tr class="tr_allowrepeatvote">
                    <td>每天点赞(投票)次数
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdDayVoteLimitCount" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>封面图片</td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.CoverImg))
                          { %>
                        <a href="<%=this.CoverImg %>" target="_blank">
                            <img src="<%=this.CoverImg %>" style="width: 100px;" /></a>
                        <br />
                        <%} %>
                        <input type="text" class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 80%" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
