<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractEarnProcess.aspx.cs" Inherits="Web.ContractEarn.ContractEarnProcess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script>
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        function do_save() {
            var rows = parent.$("#tt_table").datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请先选择一个扣点合同", "warning");
                return;
            }
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ContractHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savecontractearn';
                    param.IDList = JSON.stringify(IDList);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
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
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-shengcheng'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>营业收入
                    </td>
                    <td>
                        <input id="tdContractDivideSellCost" runat="server" type="text" class="easyui-textbox" />
                    </td>
                    <td>分成比例
                    </td>
                    <td>
                        <input id="tdContractDevicePercent" runat="server" type="text" class="easyui-textbox" />%
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
