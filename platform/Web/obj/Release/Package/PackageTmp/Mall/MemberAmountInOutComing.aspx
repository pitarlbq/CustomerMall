<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MemberAmountInOutComing.aspx.cs" Inherits="Web.Mall.MemberAmountInOutComing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var BalanceType = 1, tdUserName, hdUserID, hdRelationID;
        $(function () {
            BalanceType = "<%=this.BalanceType%>";
            tdUserName = $('#<%=this.tdUserName.ClientID%>');
            hdUserID = $('#<%=this.hdUserID.ClientID%>');
            hdRelationID = $('#<%=this.hdRelationID.ClientID%>');
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallmemberamount';
                    param.BalanceType = BalanceType;
                    param.UserID = hdUserID.val();
                    param.RelationID = hdRelationID.val();
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('操作成功', 'success', function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function choose_user() {
            var title = '选择用户';
            var iframe = "../APPSetup/ChooseProjectUser.aspx?singleselect=1&ProjectID=0";
            do_open_dialog(title, iframe);

        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        [v-cloak] {
            display: none;
        }

        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">
                <span runat="server" id="label_Title2"></span>
            </a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>业主
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdUserName" runat="server" data-options="multiline:true,editable:false" />
                        <asp:HiddenField runat="server" ID="hdUserID" />
                        <asp:HiddenField runat="server" ID="hdRelationID" />
                        <a href="javascript:void(0)" onclick="choose_user()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label runat="server" id="label_Title1"></label>
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdBalanceValue" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdRemark" data-options="multiline:true" style="width: 85%; height: 80px;" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
