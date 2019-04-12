<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="BatchEditCount.aspx.cs" Inherits="Web.GongTan.BatchEditCount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var rows = null;
        $(function () {
            GetAllRooms();
        })
        function Format_Count(value) {
            if (Number(value) < 0) {
                return 0;
            }
            return value;
        }
        function GetAllRooms() {
            rows = parent.$('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请至少选中一个导入记录", "warning");
                return;
            }
            $.each(rows, function (index, row) {
                setTimeout(function () {
                    var $html = '';
                    $html += '<tr id="tr_' + index + '"><td>';
                    $html += row.Name;
                    $html += '</td>';
                    $html += '<td>';
                    $html += row.ImportBiaoName;
                    $html += '</td>';
                    $html += '<td>';
                    $html += row.ImportBiaoCategory;
                    $html += '</td>';
                    $html += '<td>';
                    $html += '<input type="text" class="easyui-textbox" style="width:100px" id="StartPoint_' + row.ID + '" value="' + Format_Count(row.StartPoint) + '" />';
                    $html += '</td>';
                    $html += '<td>';
                    $html += '<input type="text" class="easyui-textbox" style="width:100px" id="EndPoint_' + row.ID + '" value="' + Format_Count(row.EndPoint) + '" />';
                    $html += '</td></tr>';
                    $($html).appendTo("#tt_table");
                    $.parser.parse("#tr_" + index);
                }, 100 * index);
            })
        }
        function do_save() {
            if (rows == null || rows.leng == 0) {
                rows = parent.$('#tt_table').datagrid("getSelections");
            }
            var list = [];
            $.each(rows, function (index, row) {
                var obj = {};
                obj.ID = row.ID;
                var StartPoint = $("#StartPoint_" + row.ID).textbox("getValue");
                StartPoint = (StartPoint == "" ? 0 : Number(StartPoint));
                obj.StartPoint = StartPoint;
                var EndPoint = $("#EndPoint_" + row.ID).textbox("getValue");
                EndPoint = (EndPoint == "" ? 0 : Number(EndPoint));
                obj.EndPoint = EndPoint;
                list.push(obj);
            })
            var options = { visit: 'batchsavecount', list: JSON.stringify(list) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportFeeHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            do_close()
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
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.add {
            width: 96%;
            margin: 0 auto;
            border-collapse: collapse;
            border-spacing: 0;
            border: solid 1px #ccc;
            background: #fff;
        }

            table.add td {
                border: solid 1px #ccc;
                text-align: left;
                padding: 5px 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <table class="add" id="tt_table">
            <tr>
                <td>房间编号</td>
                <td>表名称</td>
                <td>表种类</td>
                <td>上次读数</td>
                <td>本次读数</td>
            </tr>
        </table>
    </div>
</asp:Content>
