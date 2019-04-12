<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ApproveZhuangXiu.aspx.cs" Inherits="Web.ZhuangXiu.ApproveZhuangXiu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>装修审批</title>
    <script>
        var ID;
        $(function () {
            ID = "<%=Request.QueryString["ID"]%>";
        });
        function saveData(status) {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            $('#ff').form('submit', {
                url: '../Handler/ZhuangXiuHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'approvezhuangxiu';
                    param.ID = ID;
                    param.AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
                    param.ApproveStatus = status;
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                closeWin();
                            });
                            return;
                        }
                        show_message("装修记录不存在", "info");
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
                <td colspan="4" style="text-align: center; font-size: 15px; padding: 5px;">装修审批</td>
            </tr>
            <tr>
                <td>装修房号</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="RoomName" class="easyui-textbox" id="tdRoomName" />
                </td>
                <td>申请人</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="ApplicationMan" class="easyui-textbox" id="tdApplicationMan" />
                </td>
            </tr>
            <tr>
                <td>应收押金</td>
                <td>
                    <input type="text" runat="server" name="DepositPrice" data-options="readonly:true" class="easyui-textbox" id="tdDepositPrice" /></td>
                <td>实收押金</td>
                <td>
                    <input type="text" runat="server" name="RealDepositPrice" data-options="readonly:true" class="easyui-textbox" id="tdRealDepositPrice" />
                </td>
            </tr>
            <tr>
                <td>备注</td>
                <td colspan="3">
                    <input type="text" runat="server" name="ApproveDesc" data-options="multiline:true" class="easyui-textbox" id="tdApproveDesc" style="width: 80%; height: 50px;" /></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <%if (approve == null || approve.ApproveStatus.Equals("不通过"))
                      { %>
                    <a href="javascript:void(0)" onclick="saveData(1)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">通过</a>
                    <a href="javascript:void(0)" onclick="saveData(0)" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">不通过</a>
                    <%} %>
                    <%else
                      { %>
                     已审批. 
                    <%if (approve.AddTime > DateTime.MinValue)
                      { %>
                    审批时间: <%=approve.AddTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                    <%}
                      } %>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
