<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditWechatBusiness.aspx.cs" Inherits="Web.Wechat.EditWechatBusiness" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var BusinessID;
        $(function () {
            BusinessID = "<%=this.BusinessID%>";
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
                    param.visit = 'savewechatbusiness';
                    param.ID = BusinessID;
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
                    <td>商家名称
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdBusinessName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>商家电话</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdPhoneNumber" runat="server" style="width: 70%;" />
                    </td>
                </tr>
                <tr>
                    <td>是否发布
                    </td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdIsPublish" runat="server">
                            <option value="1">发布</option>
                            <option value="0">不发布</option>
                        </select>
                    </td>
                </tr>
                <tr class="detail">
                    <td>商家简介
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdBusinessSummary" runat="server" data-options="multiline:true" style="height: 60px; width: 70%;" />
                    </td>
                </tr>
                <tr>
                    <td>商家图片</td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.BusinessImgPath))
                          { %>
                        <a href="<%=this.BusinessImgPath %>" target="_blank">
                            <img src="<%=this.BusinessImgPath %>" style="width: 100px;" /></a>
                        <br />
                        <%} %>
                        <input type="text" class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 80%" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
