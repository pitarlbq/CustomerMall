<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="GongTanTool.aspx.cs" Inherits="Web.GongTan.GongTanTool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            $('#tdCategory').combobox({
                onSelect: function (rec) {
                    var value = $('#tdCategory').combobox("getValue");
                    if (value == "1") {
                        $("#trMoney").show();
                        $("#trCount").hide();
                    }
                    else if (value == "2") {
                        $("#trMoney").hide();
                        $("#trCount").show();
                    }
                }
            });
        })
        function do_save() {
            var rows = parent.$('#tt_table').datagrid("getSelections");
            var list = [];
            $.each(rows, function (index, row) {
                list.push(row.ID);
            })
            var options = { visit: 'batchgongtantool', ids: JSON.stringify(list), Category: $("#tdCategory").combobox("getValue"), Money: $("#tdMoney").textbox("getValue"), Count: $("#tdCount").textbox("getValue"), GongTanType: $("#tdGongTanType").combobox("getValue") };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
                        });;
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
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.info {
            width: 90%;
            margin: 0 auto;
            border-collapse: collapse;
            border-spacing: 0;
            border: solid 1px #ccc;
            background: #fff;
        }

            table.info td {
                border: solid 1px #ccc;
                text-align: left;
                padding: 5px 10px;
                width: 70%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 30%;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">生成</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="info" id="tt_table">
            <tr>
                <td>公摊类别</td>
                <td>
                    <select class="easyui-combobox" data-options="editable:false" id="tdCategory">
                        <option value="1">按金额</option>
                        <option value="2">按用量</option>
                    </select></td>
            </tr>
            <tr id="trMoney">
                <td>待摊金额</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdMoney" />
                </td>
            </tr>
            <tr id="trCount" style="display: none;">
                <td>待摊用量</td>
                <td>
                    <input type="text" class="easyui-textbox" id="tdCount" />
                </td>
            </tr>
            <tr>
                <td>待摊方式</td>
                <td>
                    <select class="easyui-combobox" data-options="editable:false" id="tdGongTanType">
                        <option value="1">按系数</option>
                    </select>
                </td>
            </tr>
        </table>
    </div>
    <div style="text-align: center;">
    </div>
</asp:Content>
