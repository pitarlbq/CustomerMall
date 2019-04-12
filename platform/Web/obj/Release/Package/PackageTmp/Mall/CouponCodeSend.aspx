<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CouponCodeSend.aspx.cs" Inherits="Web.Mall.CouponCodeSend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var CouponIDList = [], hdUserID, tdNickName;
        $(function () {
            tdNickName = $('#<%=this.tdNickName.ClientID%>');
            hdUserID = $('#<%=this.hdUserID.ClientID%>');
        })
        function GetCouponIDList() {
            var list = [];
            var rows = parent.$("#tt_table").datagrid("getSelections");
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            return list;
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            CouponIDList = GetCouponIDList();
            if (CouponIDList.length == 0) {
                show_message('请先选择一个卡券', 'info');
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'sendmallusercouponcode';
                    param.UserIDList = hdUserID.val();
                    param.CouponIDList = JSON.stringify(CouponIDList);
                    param.SendCount = $('#<%=this.tdSendCount.ClientID%>').textbox('getValue');
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message("发放成功", "info", function () {
                            do_close();
                        });
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function chooseuser() {
            isupdate = false;
            var iframe = "../APPSetup/ChooseAPPUser.aspx";
            do_open_dialog('选择用户', iframe);
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">发放</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>选择用户</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdNickName" runat="server" data-options="multiline:true,readonly:true" style="height: 50px; width: 300px;" />
                        <asp:HiddenField runat="server" ID="hdUserID" />
                        <label style="display: inline-block; line-height: 40px;">
                            <a href="javascript:void(0)" onclick="chooseuser()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
                        </label>
                    </td>
                </tr>
                <tr>
                    <td>发放张数</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdSendCount" runat="server" style="width: 300px;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
