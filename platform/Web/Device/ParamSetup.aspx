<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ParamSetup.aspx.cs" Inherits="Web.Device.ParamSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function saveData() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/DeviceHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savesetting';
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success');
                        return;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
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
                width: 65%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 35%;
                }

        input[type=text] {
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div style="margin-top: 10px;">
            <table class="info">
                <tr>
                    <td>维保任务生成时间设置</td>
                    <td>提前<input type="text" id="tdrepairtimecount" class="easyui-textbox" runat="server" />
                        <select type="text" class="easyui-combobox" runat="server" id="tdrepairtimetype" style="width: 80px">
                            <option value="day">天</option>
                            <option value="month">月</option>
                        </select>
                        生成下次维保</td>
                </tr>
                <tr>
                    <td>巡检任务生成时间设置</td>
                    <td>提前<input type="text" id="tdchecktimecount" class="easyui-textbox" runat="server" />
                        <select type="text" class="easyui-combobox" runat="server" id="tdchecktimetype" style="width: 80px">
                            <option value="day">天</option>
                            <option value="month">月</option>
                        </select>
                        生成下次巡检</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
