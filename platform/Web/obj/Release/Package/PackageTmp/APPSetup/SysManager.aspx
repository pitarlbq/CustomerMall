<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SysManager.aspx.cs" Inherits="Web.APPSetup.SysManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function saveConfig() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var OrderCloseTime = $("#<%=this.tdOrderCloseTime.ClientID%>").textbox("getValue");
            var OrderAuoShipped = $("#<%=this.tdOrderAuoShipped.ClientID%>").textbox("getValue");
            var OrderAutoRate = $("#<%=this.tdOrderAutoRate.ClientID%>").textbox("getValue");
            var OrderRefundTime = $("#<%=this.tdOrderRefundTime.ClientID%>").textbox("getValue");
            var AllowDefineAddress = $("#<%=this.tdAllowDefineAddress.ClientID%>").combobox("getValue");
            var JPushTuanGouNotify = $("#<%=this.tdJPushTuanGouNotify.ClientID%>").textbox("getValue");
            var JPushXianShiNotify = $("#<%=this.tdJPushXianShiNotify.ClientID%>").textbox("getValue");

            var MallHomeYouXuanCount = $("#<%=this.tdMallHomeYouXuanCount.ClientID%>").textbox("getValue");
            var MallHomeBusinessCount = $("#<%=this.tdMallHomeBusinessCount.ClientID%>").textbox("getValue");
            var MallHomeHotSaleCount = $("#<%=this.tdMallHomeHotSaleCount.ClientID%>").textbox("getValue");
            var MallMallBusinessCount = $("#<%=this.tdMallMallBusinessCount.ClientID%>").textbox("getValue");
            var MallMallCategoryCount = $("#<%=this.tdMallMallCategoryCount.ClientID%>").textbox("getValue");
            var NoGrabTransfer = $("#<%=this.tdNoGrabTransfer.ClientID%>").textbox("getValue");
            var options = {};
            options.OrderCloseTime = OrderCloseTime;
            options.OrderAuoShipped = OrderAuoShipped;
            options.OrderAutoRate = OrderAutoRate;
            options.OrderRefundTime = OrderRefundTime;
            options.AllowDefineAddress = AllowDefineAddress;
            options.JPushTuanGouNotify = JPushTuanGouNotify;
            options.JPushXianShiNotify = JPushXianShiNotify;
            options.MallHomeBusinessCount = MallHomeBusinessCount;
            options.MallHomeHotSaleCount = MallHomeHotSaleCount;
            options.MallHomePinTanCount = MallHomePinTanCount;
            options.MallHomeYouXuanCount = MallHomeYouXuanCount;
            options.MallMallBusinessCount = MallMallBusinessCount;
            options.MallMallCategoryCount = MallMallCategoryCount;
            options.NoGrabTransfer = NoGrabTransfer;
            options.visit = "saveconfigparam";
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        do_upload_file();
                        show_message('保存成功', 'success');
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_upload_file() {
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveconfigparamfile';
                },
                success: function (data) {
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success');
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message('文件上传失败', 'warning');
                }
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.field {
            width: 96%;
            margin: 0 auto;
            border-spacing: 0;
            border-collapse: collapse;
            background: #fff;
            border-radius: 10px;
        }

            table.field td {
                padding: 10px;
                text-align: left;
                width: 33%;
                vertical-align: middle;
            }

                table.field td input[type=text], table.field td select {
                    width: 10%;
                    text-align: left;
                }


        .header_title {
            padding: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="saveConfig()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="table_container">
            <div class="header_title">
                订单设置
            </div>
            <table class="field">
                <tr>
                    <td>待付款订单
                        <input class="easyui-textbox" type="text" id="tdOrderCloseTime" runat="server" />
                        小时后自动关闭</td>
                    <td>已发货订单
                        <input class="easyui-textbox" type="text" id="tdOrderAuoShipped" runat="server" />
                        小时后自动收货</td>
                    <td>已收货订单
                        <input class="easyui-textbox" type="text" id="tdOrderAutoRate" runat="server" />
                        小时后自动好评</td>
                </tr>
                <tr>
                    <td>已付款订单
                        <input class="easyui-textbox" type="text" id="tdOrderRefundTime" runat="server" />
                        分钟内支持退款</td>
                    <td>已付款订单
                        <input class="easyui-textbox" type="text" id="tdNoGrabTransfer" runat="server" />
                        小时内无人抢单转人工派单</td>
                    <td>允许用户使用自定义地址
                        <select class="easyui-combobox" id="tdAllowDefineAddress" runat="server" data-options="editable:false">
                            <option value="0">不允许</option>
                            <option value="1">允许</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>限时购提前
                        <input class="easyui-textbox" type="text" id="tdJPushXianShiNotify" runat="server" />
                        小时推送通知用户</td>
                    <td>团购在开团时间前
                        <input class="easyui-textbox" type="text" id="tdJPushTuanGouNotify" runat="server" />
                        小时推送通知用户</td>
                </tr>
            </table>
            <div class="header_title">
                排版设置
            </div>
            <table class="field">
                <tr>
                    <td>APP首页优选商品显示
                        <input class="easyui-textbox" type="text" id="tdMallHomeYouXuanCount" runat="server" style="text-align: left;" />个产品
                    </td>
                    <td>APP首页拼团秒杀显示
                        <input class="easyui-textbox" type="text" id="tdMallHomePinTanCount" runat="server" style="text-align: left;" />个产品
                    </td>
                    <td>APP首页推荐商家显示
                        <input class="easyui-textbox" type="text" id="tdMallHomeBusinessCount" runat="server" style="text-align: left;" />个产品
                    </td>
                </tr>
                <tr>
                    <td>APP首页热门消费显示
                        <input class="easyui-textbox" type="text" id="tdMallHomeHotSaleCount" runat="server" style="text-align: left;" />个产品
                    </td>

                    <td>APP商圈分类显示
                        <input class="easyui-textbox" type="text" id="tdMallMallCategoryCount" runat="server" style="text-align: left;" />个分类
                    </td>
                    <td>APP商圈优选商家显示
                        <input class="easyui-textbox" type="text" id="tdMallMallBusinessCount" runat="server" style="text-align: left;" />个商家
                    </td>
                </tr>
                <tr>
                    <td>商品分类每行显示
                         <select class="easyui-combobox" data-options="editable:false" id="tdMallCategoryLineCount" runat="server" style="width: 120px; text-align: center;">
                             <option value="4">4个</option>
                             <option value="3">3个</option>
                         </select>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
