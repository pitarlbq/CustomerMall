<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="MonthFeeAnalysisColumnSetup.aspx.cs" Inherits="Web.SysSeting.MonthFeeAnalysisColumnSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var PageCode;
        $(function () {
            AllClickListener();
            PageCode = "<%=Request.QueryString["PageCode"]%>" || '';
            getTableFields();
        });
        function getTableFields() {
            var options = { visit: 'getmonthfeeanalysisfield', PageCode: PageCode };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        var html = '';
                        $.each(message.list, function (index, item) {
                            html += '<tr>';
                            html += '<td>';
                            html += '<input type="text" style="width:80px" id="SortOrder_' + item.FieldID + '_' + item.ID + '" value="' + item.SortOrder + '">';
                            html += '</td>';
                            html += '</td>';
                            html += '<td>';
                            html += item.ColumnName;
                            html += '</td>';
                            html += '<td>';
                            if (item.IsShown) {
                                html += '<input checked="checked" onclick="summaryClick(this,' + item.ID + ')" name="FieldCheck" type="checkbox" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="summary" />';
                            }
                            else {
                                html += '<input type="checkbox" onclick="summaryClick(this,' + item.ID + ')" name="FieldCheck" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="summary" />';
                            }
                            html += '</td>';
                            html += '<td>';
                            if (item.IsShowTotal) {
                                html += '<input checked="checked" name="FieldCheck" type="checkbox" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="total" />';
                            }
                            else {
                                html += '<input type="checkbox" name="FieldCheck" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="total" />';
                            }
                            html += '</td>';
                            html += '<td>';
                            if (item.IsShowReal) {
                                html += '<input checked="checked" name="FieldCheck" type="checkbox" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="real" />';
                            }
                            else {
                                html += '<input type="checkbox" name="FieldCheck" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="real" />';
                            }
                            html += '</td>';
                            html += '<td>';
                            if (item.IsShowChargeFee) {
                                html += '<input checked="checked" name="FieldCheck" type="checkbox" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="chargefee" />';
                            }
                            else {
                                html += '<input type="checkbox" name="FieldCheck" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="chargefee" />';
                            }
                            html += '</td>';
                            html += '<td>';
                            if (item.IsShowRest) {
                                html += '<input checked="checked" name="FieldCheck" type="checkbox" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="rest" />';
                            }
                            else {
                                html += '<input type="checkbox" name="FieldCheck" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="rest" />';
                            }
                            html += '</td>';
                            html += '<td>';
                            if (item.IsShowDiscount) {
                                html += '<input checked="checked" name="FieldCheck" type="checkbox" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="discount" />';
                            }
                            else {
                                html += '<input type="checkbox" name="FieldCheck" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="discount" />';
                            }
                            html += '</td>';
                            html += '</tr>';
                        })
                        $("#tablefiled").append(html);
                    }
                    else {
                        show_message("获取列表失败", "info");
                    }
                }
            });
        }
        function summaryClick(that, id) {
            if (that.checked) {
                $("[name='FieldCheck']").each(function () {
                    var ID = $(this).val();
                    var fieldtype = $(this).attr('data-fieldtype');
                    if (ID == id && fieldtype != 'summary') {
                        if (!this.checked) {
                            $(this).prop('checked', true);
                        }
                    }
                });
            }
            else {
                $("[name='FieldCheck']").each(function () {
                    var ID = $(this).val();
                    var fieldtype = $(this).attr('data-fieldtype');
                    if (ID == id && fieldtype != 'summary') {
                        if (this.checked) {
                            $(this).prop('checked', false);
                        }
                    }
                });
            }
        }
        function do_save() {
            var List = [];
            var SortOrderList = [];
            $("[name='FieldCheck']").each(function () {
                if (this.checked) {
                    var ID = $(this).val();
                    var data_fieldid = $(this).attr('data-fieldid')
                    var data_fieldtype = $(this).attr('data-fieldtype')
                    var sortorder = $("#SortOrder_" + data_fieldid + "_" + ID).val();
                    if (sortorder == "" || sortorder == null) {
                        sortorder = 0;
                    }
                    List.push({ ID: ID, FieldID: data_fieldid, FieldType: data_fieldtype, SortOrder: sortorder });
                }
            });
            var options = { visit: 'savemonthfeeanalysistablefield', List: JSON.stringify(List), PageCode: PageCode };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
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
        function closeWin() {
            parent.$("#winadd").window("close");
        }
        function AllClickListener() {
            $('#all').bind('click', function () {
                if ($('#all').prop('checked')) {
                    $("[name='FieldCheck']").each(function () {
                        if (!this.checked) {
                            $(this).prop('checked', true);
                        }
                    });
                }
                else {
                    $("[name='FieldCheck']").each(function () {
                        if (this.checked) {
                            $(this).prop('checked', false);
                        }
                    });
                }
            })
        }
        function do_close() {
            try {
                parent.do_close_dialog(function () {
                    parent.loadtt();
                });
            } catch (e) {
            }
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        .add, .exist {
            width: 96%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 0px #ccc;
            background: #fff;
        }

        table.add td {
            padding: 3px 5px;
            text-align: left;
            border: solid 1px #ccc;
        }

        input {
            width: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <input type="checkbox" id="btnAll" style="height: 15px; vertical-align: middle; margin: 0;" /><label style="vertical-align: middle; margin: 0;">全选</label>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="add" id="tablefiled">
                <tr>
                    <td style="width: 15%">排序
                    </td>
                    <td style="width: 15%">名称
                    </td>
                    <td style="width: 15%">显示月份
                    </td>
                    <td style="width: 15%">显示应收
                    </td>
                    <td style="width: 10%">显示实收
                    </td>
                    <td style="width: 10%">显示冲抵
                    </td>
                    <td style="width: 10%">显示减免
                    </td>
                    <td style="width: 10%">显示未收
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
