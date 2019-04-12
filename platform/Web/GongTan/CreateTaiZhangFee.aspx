<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CreateTaiZhangFee.aspx.cs" Inherits="Web.GongTan.CreateTaiZhangFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('#tdCoefficient').textbox('setValue', 1);
        });
        function do_save() {
            var rows = parent.$('#tt_table').datagrid('getSelections');
            if (rows.length == 0) {
                show_message("请选择需要生成的账单", "warning");
                return;
            }
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            var StartTime = $("#tdStartTime").datebox("getValue");
            var EndTime = $("#tdEndTime").datebox("getValue");
            top.$.messager.confirm("提示", "确认生成？", function (r) {
                if (r) {
                    var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
                    var options = { visit: 'createnewimporttaizhangfee', IDList: JSON.stringify(IDList), StartTime: StartTime, EndTime: EndTime };
                    MaskUtil.mask('body', '提交中');
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/ImportFeeHandler.ashx',
                        data: options,
                        success: function (message) {
                            MaskUtil.unmask();
                            if (message.status == 1) {
                                show_message("生成成功", "success", function () {
                                    do_close();
                                })
                            }
                            else {
                                show_message('系统错误', 'error');
                            }
                        }
                    });
                }
            })
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
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">生成</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info">
            <tr>
                <td>计费开始日期：
                </td>
                <td>
                    <input id="tdStartTime" type="text" class="easyui-datebox" />
                </td>
                <td>计费结束日期：
                </td>
                <td>
                    <input id="tdEndTime" type="text" class="easyui-datebox" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
