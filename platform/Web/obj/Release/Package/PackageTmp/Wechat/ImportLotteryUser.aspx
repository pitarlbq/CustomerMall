<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ImportLotteryUser.aspx.cs" Inherits="Web.Wechat.ImportLotteryUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ActivityID = 0;
        $(function () {
            ActivityID = "<%=this.ActivityID%>";
        })
        function do_save() {
            var filebox = $("#attached").filebox("getValue");
            if (filebox == "") {
                $("#<%=this.errMsg.ClientID%>").html("请选择文件");
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: "../Handler/ImportSourceHandler.ashx",
                onSubmit: function (param) {
                    param.visit = "importwechatlotteryuser";
                    param.ActivityID = ActivityID;
                },
                dataType: "html",
                success: function (data) {
                    MaskUtil.unmask();
                    data = data.replace(/&lt;/g, "<");
                    data = data.replace(/&gt;/g, ">");
                    $("#<%=this.errMsg.ClientID%>").html(data);
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
        function do_export() {
            MaskUtil.mask('body', '导出中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ImportSourceHandler.ashx',
                data: { visit: 'exportlotteryusertemplate' },
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.downloadurl) {
                        window.location.href = data.downloadurl;
                        return;
                    }
                    if (data.error) {
                        show_message(data.error, 'warning');
                        return;
                    }
                    show_message('系统异常', 'error');
                }
            });
        }
    </script>
    <style type="text/css">
        .notifyMsg {
            text-align: center;
            color: #ff0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" method="post" runat="server" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-import'">导入</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>模板</td>
                    <td>
                        <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-export'">下载</a>
                    </td>
                </tr>
                <tr>
                    <td>文件</td>
                    <td>
                        <input class="easyui-filebox" name="attachfile" id="attached" data-options="prompt:'请选择文件',buttonText: '选择文件'" style="width: 60%" />
                    </td>
                </tr>
            </table>
            <div class="notifyMsg">
                <label runat="server" id="errMsg"></label>
            </div>
        </div>
    </form>
</asp:Content>
