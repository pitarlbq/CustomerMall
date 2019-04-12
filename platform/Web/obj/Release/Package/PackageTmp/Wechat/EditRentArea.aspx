<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRentArea.aspx.cs" Inherits="Web.Wechat.EditRentArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var AreaID, data_id, data_type;
        $(function () {
            data_id = "<%=this.data_id%>";
            data_type = "<%=this.data_type%>";
            AreaID = "<%=this.AreaID%>";
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
                    param.visit = 'saverentarea';
                    param.ID = data_id;
                    param.Type = data_type;
                    param.AreaID = AreaID;
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
                parent.doSearchTree();
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
                    <td>
                        <label id="label_title" runat="server"></label>
                    </td>
                    <td colspan="3">
                        <input type="text" style="width: 70%;" class="easyui-textbox" id="tdAreaName" runat="server" data-options="required:true" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
