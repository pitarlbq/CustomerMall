<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditHouseServiceCategory.aspx.cs" Inherits="Web.Wechat.EditHouseServiceCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var AreaID, data_id, data_type, type;
        $(function () {
            data_id = "<%=this.data_id%>";
            type = "<%=this.type%>";
        });
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
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savewechathouseservicecategory';
                    param.ID = data_id;
                    param.type = type;
                    param.IsWechatSend = IsWechatSend;
                    param.IsCustomerAPPSend = IsCustomerAPPSend;
                    param.IsUserAPPSend = IsUserAPPSend;
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
        function deleteCover(type) {
            top.$.messager.confirm("提示", "是否删除选已上传的封面?", function (r) {
                if (r) {
                    var options = { visit: 'deletehouseservicecategorycorver', ID: data_id, type: type };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/WechatHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('操作成功', 'success', function () {
                                    window.location.reload();
                                });
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.doSearchTree();
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
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

        .image_box {
            min-width: 100px;
            display: inline-block;
            margin: 10px;
            text-align: center;
        }

            .image_box img {
                width: 100px;
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
                    <td>类别名称
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdCategoryName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>排序
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdSortOrder" runat="server" data-options="required:true" />
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
                    <td>封面图片(未选中)</td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.FilePath))
                          { %>
                        <div class="image_box">
                            <a href="<%=this.FilePath%>" target="_blank">
                                <img src="<%=this.FilePath%>" />
                            </a>
                            <br />
                            <a href="#" onclick="deleteCover(1)">删除</a>
                        </div>
                        <%} %>
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 80%" />
                    </td>
                </tr>
                <tr>
                    <td>封面图片(选中)</td>
                    <td colspan="3">
                        <%if (!string.IsNullOrEmpty(this.FilePath_Active))
                          { %>
                        <div class="image_box">
                            <a href="<%=this.FilePath_Active%>" target="_blank">
                                <img src="<%=this.FilePath_Active%>" />
                            </a>
                            <br />
                            <a href="#" onclick="deleteCover(2)">删除</a>
                        </div>
                        <%} %>
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 80%" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
