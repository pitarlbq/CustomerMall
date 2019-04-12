<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ConfirmZhuangXiu.aspx.cs" Inherits="Web.ZhuangXiu.ConfirmZhuangXiu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>装修确认</title>
    <script>
        function closeWin() {
            parent.$("#winadd").window("close");
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var rows = parent.$("#tt_table").datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请先选择一个装修记录", "info");
                return;
            }
            var IDList = [];
            var canContinue = true;
            $.each(rows, function (index, row) {
                if (row.Status != "shenpiyes") {
                    canContinue = false;
                    return false;
                }
                IDList.push(row.ID);
            })
            if (!canContinue) {
                show_message("请选择审批通过的记录", "info");
                return;
            }
            top.$.messager.confirm("提示", "确认装修选中的记录?", function (r) {
                if (r) {
                    var options = { visit: 'confirmzhuangxiu', IDList: JSON.stringify(IDList), ZhuangXiuTime: $('#<%=this.tdZhuangXiuTime.ClientID%>').datebox('getValue') };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/ZhuangXiuHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('操作成功', 'success', function () {
                                    closeWin();
                                });
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
    </script>
    <style>
        table.info {
            width: 100%;
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

        input[type=text] {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">确认装修</td>
            </tr>
            <tr>
                <td>装修时间</td>
                <td colspan="3">
                    <input type="text" runat="server" data-options="required:true" name="ZhuangXiuTime" class="easyui-datebox" id="tdZhuangXiuTime" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
