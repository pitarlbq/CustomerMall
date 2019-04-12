<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditLotteryActivity.aspx.cs" Inherits="Web.Wechat.EditLotteryActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID;
        $(function () {
            ID = "<%=this.ID%>";
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
                    param.visit = 'savelotteryactivity';
                    param.ID = ID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        ID = dataObj.ID;
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
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
                    <td>活动名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdActivityName" runat="server" data-options="required:true" />
                    </td>
                    <td>商户名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdMerchantName" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>活动类型
                    </td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdType" runat="server">
                            <option value="Turntable">转盘</option>
                            <option value="Goldenegg">砸金蛋</option>
                            <option value="Shave">刮一刮</option>
                            <option value="Shake">摇一摇</option>
                        </select>
                    </td>
                    <td>参与方式</td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdRepeat" runat="server">
                            <option value="Everyday">每天</option>
                            <option value="Everyweek">每周</option>
                            <option value="Everymonth">每月</option>
                            <option value="Wholeactive">活动期间</option>
                        </select></td>
                </tr>
                <tr>
                    <td>重复参与次数</td>
                    <td>
                        <input type="text" class="easyui-numberbox" id="tdRepeatTime" runat="server" />
                    </td>
                    <td>预估参与人次</td>
                    <td>
                        <input type="text" class="easyui-numberbox" id="tdParticipantNumber" runat="server" />
                        （达到该数值时奖品会被抽完）
                    </td>
                </tr>
                <tr>
                    <td>限制参与人员</td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdUserLimit" runat="server">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select></td>
                    <td>限制参与提示语</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdNoLimitMsg" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>开始时间</td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdStartTime" runat="server" data-options="required:true" />
                    </td>
                    <td>结束时间</td>
                    <td>
                        <input type="text" class="easyui-datetimebox" id="tdEndTime" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>封面图片</td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.CoverImgPath))
                          { %>
                        <a href="<%=this.CoverImgPath %>" target="_blank">
                            <img src="<%=this.CoverImgPath %>" style="width: 100px;" /></a>
                        <br />
                        <%} %>
                        <input type="text" class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 80%" />
                    </td>
                </tr>
                <tr>
                    <td>活动规则</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 80%; height: 50px;" id="tdRuleDescription" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>活动描述</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 80%; height: 50px;" id="tdDescription" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
