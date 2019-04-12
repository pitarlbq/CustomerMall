<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent6.Master" AutoEventWireup="true" CodeBehind="SysManager.aspx.cs" Inherits="Web.SysSeting.SysManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ProjectID, tdCouZheng, tdContractWarning, tdWeixinChargeMan, tdHideCuiShouCustomerName, tdWechatFeeNotify, tdWechatFeeNotifyTime;
        $(function () {
            tdCouZheng = $("#<%=this.tdCouZheng.ClientID%>");
            tdContractWarning = $("#<%=this.tdContractWarning.ClientID%>");
            tdWeixinChargeMan = $("#<%=this.tdWeixinChargeMan.ClientID%>");
            tdHideCuiShouCustomerName = $("#<%=this.tdHideCuiShouCustomerName.ClientID%>");
            tdWechatFeeNotify = $("#<%=this.tdWechatFeeNotify.ClientID%>");
            tdWechatFeeNotifyTime = $("#<%=this.tdWechatFeeNotifyTime.ClientID%>");
            $('#c_lodop').tooltip({
                position: 'right',
                hideEvent: 'none',
                content: function () {
                    return $('#c_lodop_toolbar');
                },
                onShow: function () {
                    var t = $(this);
                    t.tooltip('tip').focus().unbind().bind('blur', function () {
                        t.tooltip('hide');
                    });
                }
            })
            $('#z_lodop').tooltip({
                position: 'right',
                hideEvent: 'none',
                content: function () {
                    return $('#z_lodop_toolbar');
                },
                onShow: function () {
                    var t = $(this);
                    t.tooltip('tip').focus().unbind().bind('blur', function () {
                        t.tooltip('hide');
                    });
                }
            })
            $('#lodop_32').tooltip({
                position: 'right',
                hideEvent: 'none',
                content: function () {
                    return $('#lodop_toolbar_32');
                },
                onShow: function () {
                    var t = $(this);
                    t.tooltip('tip').focus().unbind().bind('blur', function () {
                        t.tooltip('hide');
                    });
                }
            })
            $('#lodop_64').tooltip({
                position: 'right',
                hideEvent: 'none',
                content: function () {
                    return $('#lodop_toolbar_64');
                },
                onShow: function () {
                    var t = $(this);
                    t.tooltip('tip').focus().unbind().bind('blur', function () {
                        t.tooltip('hide');
                    });
                }
            })
        })
        function pageLoad(ID) {
            ProjectID = ID;
            MaskUtil.mask();
            var options = { visit: 'getsysconfiglist', ProjectID: ProjectID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        tdCouZheng.combobox("setValue", data.CouZheng);
                        tdContractWarning.textbox("setValue", data.ContractWarning);
                        tdWeixinChargeMan.textbox("setValue", data.WeixinChargeMan);
                        tdHideCuiShouCustomerName.combobox("setValue", data.HideCuiShouCustomerName);
                        tdWechatFeeNotify.textbox("setValue", data.WechatFeeNotify);
                        tdWechatFeeNotifyTime.combobox("setValue", data.WechatFeeNotifyTime);
                    }
                }
            });
        }
        function saveConfig() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }

            var options = {};
            options.visit = "savesysconfig";
            options.ProjectID = ProjectID;
            options.CouZheng = tdCouZheng.combobox("getValue");
            options.ContractWarning = tdContractWarning.textbox("getValue");
            options.WeixinChargeMan = tdWeixinChargeMan.textbox("getValue");
            options.HideCuiShouCustomerName = tdHideCuiShouCustomerName.combobox("getValue");
            options.WechatFeeNotify = tdWechatFeeNotify.textbox("getValue");
            options.WechatFeeNotifyTime = tdWechatFeeNotifyTime.textbox("getValue");
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success');
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.info {
            width: 96%;
            margin: 0 auto;
            border-spacing: 0;
            border-collapse: collapse;
            background: #fff;
        }

            table.info td {
                padding: 10px;
                text-align: left;
                width: 70%;
                vertical-align: middle;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 30%;
                }

        select {
            width: 200px;
        }

        .operation_box {
            position: relative;
            line-height: 35px;
        }

        .table_container {
            padding-top: 10px;
        }

        .btnlinkbar .l-btn-text {
            line-height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="saveConfig()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="table_container">
            <table class="info">
                <tr>
                    <td>启用尾数凑整</td>
                    <td>
                        <select runat="server" class="easyui-combobox" id="tdCouZheng" data-options="editable:false">
                            <option value="1">启用</option>
                            <option value="0">停用</option>
                        </select></td>
                </tr>
                <tr>
                    <td>合同提前预警</td>
                    <td>
                        <input class="easyui-textbox" type="text" id="tdContractWarning" runat="server" /></td>
                </tr>
                <tr>
                    <td>微信默认收款人</td>
                    <td>
                        <input class="easyui-textbox" type="text" id="tdWeixinChargeMan" runat="server" /></td>
                </tr>
                <tr>
                    <td>催收通知单客户名称隐藏</td>
                    <td>
                        <select class="easyui-combobox" type="text" id="tdHideCuiShouCustomerName" runat="server" data-options="editable:false">
                            <option value="1">隐藏</option>
                            <option value="0">显示</option>
                        </select></td>
                </tr>
                <tr>
                    <td>欠费提醒</td>
                    <td>
                        <select style="width: 150px;" class="easyui-combobox" type="text" id="tdWechatFeeNotifyTime" runat="server" data-options="editable:false">
                            <option value="1">计费开始时间前</option>
                            <option value="2">计费开始时间后</option>
                            <option value="3">计费结束时间前</option>
                            <option value="4">计费结束时间后</option>
                        </select>
                        <input style="width: 100px;" class="easyui-textbox" type="text" id="tdWechatFeeNotify" runat="server" />
                        天进行欠费提醒
                    </td>
                </tr>
                <tr>
                    <td>打印插件下载</td>
                    <td>
                        <p>
                            <a style="font-weight: bold; color: #ff6a00;" id="c_lodop" class="easyui-tooltip" href="http://demo.saasyy.com/download/CLodop_Setup_for_Win32NT_https_3.028Extend.zip" target="_blank" data-options="">云打印C-Lodop扩展版(推荐)</a>
                        </p>
                        <p>
                            <a id="z_lodop" class="easyui-tooltip" href="http://demo.saasyy.com/download/CLodop_Setup_for_Win32NT.zip" target="_blank" data-options="">Lodop综合版</a>
                        </p>
                        <p>
                            <a id="lodop_32" class="easyui-tooltip" href="http://demo.saasyy.com/download/install_lodop32.zip" target="_blank">下载（32位）</a>
                        </p>
                        <p>
                            <a id="lodop_64" class="easyui-tooltip" href="http://demo.saasyy.com/download/install_lodop64.zip" target="_blank">下载（64位）</a>
                        </p>
                    </td>
                </tr>
            </table>
            <div style="display: none">
                <div id="c_lodop_toolbar">
                    特点：<br />
                    兼顾局域网和广域网打印<br />
                    支持https协议
                    <br />
                    同时支持32位和64位系统
                    <br />
                    支持AO打印机
                    <br />
                    支持所有浏览器<br />
                </div>
                <div id="z_lodop_toolbar">
                    特点：<br />
                    支持所有浏览器
                    <br />
                    兼顾插件和云打印优势 
                    <br />
                </div>
                <div id="lodop_toolbar_32">
                    32位浏览器使用<br />
                    （注意：不是操作系统版本）
                </div>
                <div id="lodop_toolbar_64">
                    64位浏览器使用<br />
                    （注意：不是操作系统版本）
                </div>
            </div>
        </div>
    </form>
</asp:Content>
