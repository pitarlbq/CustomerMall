<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="UserCheckPointConvertEdit.aspx.cs" Inherits="Web.Mall.UserCheckPointConvertEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdPointType, tdStartPoint, tdEndPoint;
        $(function () {
            ID = "<%=this.ID%>";
            tdStartPoint = $("#<%=this.tdStartPoint.ClientID%>");
            tdEndPoint = $("#<%=this.tdEndPoint.ClientID%>");
            tdPointType = $("#<%=this.tdPointType.ClientID%>");
            tdPointType.combobox({
                editable: false,
                onSelect: function () {
                    check_type_status();
                }
            })
        });
        function check_type_status() {
            var point_type = tdPointType.combobox('getValue');
            if (point_type == 2) {
                $('#label_amounttype').html('%');
            } else {
                $('#label_amounttype').html('元');
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var start_value = tdStartPoint.textbox('getValue');
            var end_value = tdEndPoint.textbox('getValue');
            if (parseFloat(start_value) > parseFloat(end_value)) {
                show_message('开始积分值不能大于结束积分值', 'warning');
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savecheckpointconvert';
                    param.ID = ID;
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

        table.addtional_service {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.addtional_service td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
            }

                table.addtional_service td:nth-child(2n-1) {
                    text-align: left;
                }

                table.addtional_service td input {
                    height: 25px;
                    line-height: 25px;
                    border-radius: 5px !important;
                }

        .sendtype label {
            margin-right: 10px;
            height: 25px;
            line-height: 25px;
            position: relative;
            padding-right: 25px;
        }

        .sendtype input {
            width: 15px;
            height: 15px;
            position: absolute;
            top: 50%;
            right: 0;
            margin-top: -7px;
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
                    <td>积分区间</td>
                    <td>
                        <input type="text" class="easyui-textbox" style="width: 100px;" runat="server" id="tdStartPoint" data-options="required:true" />(含)
                            -                   
                        <input type="text" class="easyui-textbox" style="width: 100px;" runat="server" id="tdEndPoint" data-options="required:true" />
                    </td>
                </tr>
                <tr class="tr_amount">
                    <td>兑换岗位积分</td>
                    <td colspan="3">
                        <select type="text" class="easyui-combobox" runat="server" id="tdPointType" data-options="required:true">
                            <option value="1">固定积分</option>
                            <option value="2">按比例</option>
                        </select>&nbsp;&nbsp;兑换                    
                        <input type="text" class="easyui-textbox" runat="server" id="tdPointValue" /><label id="label_amounttype"></label></td>
                </tr>
                <tr>
                    <td>是否生效</td>
                    <td>
                        <select type="text" class="easyui-combobox" runat="server" id="tdIsActive" data-options="required:true">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select></td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdRemark" data-options="multiline:true" style="height: 50px; width: 80%;" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
