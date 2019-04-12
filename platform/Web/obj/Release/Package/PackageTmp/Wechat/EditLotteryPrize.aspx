<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditLotteryPrize.aspx.cs" Inherits="Web.Wechat.EditLotteryPrize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, ActivityID;
        $(function () {
            ID = "<%=this.ID%>";
            ActivityID = "<%=this.ActivityID%>";
        });
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/WechatHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savelotteryprize';
                    param.ID = ID;
                    param.ActivityID = ActivityID;
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        ID = dataObj.ID;
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
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
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
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
                    <td>奖项名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdLevelName" runat="server" data-options="required:true,prompt:'一等奖、二等奖、三等奖'" />
                    </td>
                    <td>中奖名额
                    </td>
                    <td>
                        <input type="text" class="easyui-numberbox" id="tdQuota" runat="server" data-options="required:true" />
                    </td>
                </tr>
                <tr>
                    <td>奖品名称
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdPrizeName" runat="server" data-options="required:true,prompt:'笔记本、微信红包…'" />
                    </td>
                    <td>奖品类型</td>
                    <td>
                        <select type="text" class="easyui-combobox" id="tdType" runat="server">
                            <option value="PhysicalGoods">实物奖品</option>
                            <option value="CashRed">微信红包</option>
                        </select></td>
                </tr>
                <tr>
                    <td>奖品数量</td>
                    <td>
                        <input type="text" class="easyui-numberbox" id="tdPrizeQuantity" runat="server" data-options="required:true" />
                    </td>
                    <td>计量单位</td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdPrizeUnit" runat="server" data-options="required:true,prompt:'个、盒、元'" />
                    </td>
                </tr>
                <tr>
                    <td>重复中奖次数</td>
                    <td>
                        <input type="text" class="easyui-numberbox" id="tdRepeatTime" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
