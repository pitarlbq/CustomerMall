<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SummaryColumnSetup.aspx.cs" Inherits="Web.SysSeting.SummaryColumnSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var PageCode;
        var OnlyShowALL = 0;
        $(function () {
            AllClickListener();
            PageCode = "<%=Request.QueryString["PageCode"]%>" || '';
            OnlyShowALL = Number("<%=this.OnlyShowALL%>") || 0;
            getTableFields();
        });
        function getTableFields() {
            var options = { visit: 'getchargetablefield', PageCode: PageCode };
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
                            if (OnlyShowALL == 0) {
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
                                if (item.IsShowRest) {
                                    html += '<input checked="checked" name="FieldCheck" type="checkbox" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="rest" />';
                                }
                                else {
                                    html += '<input type="checkbox" name="FieldCheck" value="' + item.ID + '" data-fieldid="' + item.FieldID + '" data-fieldtype="rest" />';
                                }
                                html += '</td>';
                            }
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
            var options = { visit: 'savechargetablefield', List: JSON.stringify(List), PageCode: PageCode };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            parent.$("#winadd").window('close');
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
                try {
                    parent.getdgcolumns();
                } catch (e) {
                }
            });
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
    </script>
    <style type="text/css">
        table.add {
            width: 96%;
            margin: 0 auto;
            border-collapse: collapse;
            border-spacing: 0px;
            border: solid 1px #ccc;
        }

            table.add td {
                padding: 3px 5px;
                text-align: left;
                border: solid 1px #ccc;
            }

        input[type=text] {
            width: 50px;
            height: 30px;
            border-radius: 5px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <div style="position: absolute; left: 50px;">
                <input type="checkbox" id="all" />全选
            </div>
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="add" id="tablefiled">
                <tr>
                    <td style="width: 20%">排序
                    </td>
                    <td style="width: 20%">名称
                    </td>
                    <td style="width: 15%">显示费项
                    </td>
                    <%if (this.OnlyShowALL == 0)
                      { %>
                    <td style="width: 15%">显示应收
                    </td>
                    <td style="width: 15%">显示已收
                    </td>
                    <td style="width: 15%">显示未收
                    </td>
                    <%} %>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
