<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SendNotifyMsg.aspx.cs" Inherits="Web.SysSeting.SendNotifyMsg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table.info {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            border: solid 1px #ccc;
        }

            table.info td {
                width: 50%;
                border: solid 1px #ccc;
                text-align: left;
                padding: 10px;
            }

                table.info td:nth-child(2n+1) {
                    width: 25%;
                    text-align: right;
                }

        table.info td input[type=text] {
            height: 28px;
            line-height: 28px;
            border: solid 1px #ddd;
            border-radius: 5px !important;
            padding: 0 10px;
            width: 60px;
        }
    </style>
    <script src="../js/vue.js"></script>
    <script src="../js/Page/SysSetting/SendNotifyMsg.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="fieldcontent">
        <table class="info">
            <tr v-for="(item, index) in list">
                <td>规则{{index+1}}:
                </td>
                <td>每月
                    <input type="text" v-model="item.Value" />号发送
                </td>
                <td style="text-align: left;"><a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    <a v-if="index>0" href="javascript:void(0)" v-on:click="remove_line(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;"><a href="javascript:void(0)" v-on:click="do_save()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a></td>
            </tr>
        </table>
    </div>
</asp:Content>
