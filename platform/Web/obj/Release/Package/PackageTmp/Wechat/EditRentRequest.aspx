<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRentRequest.aspx.cs" Inherits="Web.Wechat.EditRentRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function do_close() {
            parent.do_close_dialog();
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
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>区域
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdAreaName" runat="server" data-options="readonly:true" />
                    </td>
                    <td>楼盘
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBuildingName" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td>申请人姓名
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContactName" runat="server" data-options="readonly:true" />
                    </td>
                    <td>申请人电话
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdContactPhone" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td>委托类型
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdRentType" runat="server" data-options="readonly:true" />
                    </td>
                    <td>委托物业形态
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" id="tdBuildingProperty" runat="server" data-options="readonly:true" />
                    </td>
                </tr>
                <tr>
                    <td>备注
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" id="tdRemark" runat="server" data-options="readonly:true,multiline:true" style="height: 80px; width: 80%;" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
