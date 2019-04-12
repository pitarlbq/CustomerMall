<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditSysManualyCategory.aspx.cs" Inherits="Web.SysSeting.EditSysManualyCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var CategoryID;
        $(function () {
            CategoryID = "<%=this.CategoryID%>";
        });
        function savedata() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/SysSettingHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savesysmanualcategory';
                    param.CategoryID = CategoryID;
                },
                success: function (data) {
                    MaskUtil.unmask();
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
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div style="padding: 10px 0;">
            <table class="info">
                <tr>
                    <td>模块名称
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdCategoryName" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr class="detail">
                    <td>排序
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdSortBy" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>是否发布
                    </td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdStatus" runat="server">
                            <option value="1">发布</option>
                            <option value="0">不发布</option>
                        </select>
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
