<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddFee.aspx.cs" Inherits="Web.SetupFee.AddFee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        $(function () {
            $("#endtype").combobox({
                data: getEndTypeList(),
                valueField: 'ID',
                textField: 'Name'
            });
            $('#endtype').combobox('setValue', '1');
        });
        function addfee() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            var ChargeTypeCount = $("#tdChargeTypeCount").textbox("getValue")
            var options = { visit: "addchargeprice", ChargeID: "<%=Request.QueryString["ID"]%>", UnitPrice: $("#unitprice").val(), StartTime: $("#starttime").datebox("getValue"), EndTime: $("#endtime").datebox("getValue"), EndTypeID: $("#endtype").combobox("getValue"), Remark: $("#tbRemark").textbox("getValue"), ChargeTypeCount: ChargeTypeCount };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: '../Handler/FeeCenterHandler.ashx',
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status == 2) {
                        show_message('添加成功', 'success', function () {
                            parent.$("#winadd").window("close");
                        });
                    }
                    else if (data.status == 1) {
                        show_message("与已有标准的有效期间冲突", "info");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function getEndTime(StartTime) {
            var options = { visit: "getendtime", StartTime: StartTime, ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/FeeCenterHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status && data.EndTime != "") {
                        EndTimeObj.datebox('setValue', data.EndTime);
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        table.add {
            width: 80%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
        }

            table.add td {
                padding: 10px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" method="post">
        <table class="add">
            <tr>
                <td>单价
                </td>
                <td>
                    <input id="unitprice" class="easyui-textbox" type="text" />
                </td>
            </tr>
            <tr>
                <td>计算开始日期
                </td>
                <td>
                    <input id="starttime" type="text" class="easyui-datebox" />
                </td>
            </tr>
            <tr>
                <td>计算结束日期
                </td>
                <td>
                    <input id="endtime" type="text" class="easyui-datebox" />
                </td>
            </tr>
            <tr>
                <td>计费规则
                </td>
                <td>
                    <input class="easyui-combobox" id="endtype"
                        data-options="valueField:'id',textField:'text',required:true" />
                </td>
            </tr>
            <tr>
                <td>计费周期
                </td>
                <td>
                    <input class="easyui-textbox" id="tdChargeTypeCount" data-options="required:true" />(天/月)
                </td>
            </tr>
            <tr>
                <td>备注
                </td>
                <td>
                    <input class="easyui-textbox" id="tbRemark" style="height: 50px;" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center;">
                    <a id="btn" href="javascript:void(0)" class="savebutton" onclick="addfee()" data-options="iconCls:'icon-add'"></a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
