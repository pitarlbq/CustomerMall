<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="NewAddContract_RoomCharge.aspx.cs" Inherits="Web.Contract.NewAddContract_RoomCharge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>合同登记</title>
    <script>
        var guid, ContractID, canEdit, canSaveLog, canRent, notFitRow;
        $(function () {
            guid = parent.guid;
            ContractID = "<%=this.ContractID%>";
            canEdit = parent.canEdit;
            canSaveLog = parent.canSaveLog;
            canRent = parent.canRent;
            notFitRow = true;
        })
    </script>
    <script src="../js/vue.js"></script>
    <script src="../js/Page/Comm/ChargeFeeComm.js?t=<%=getToken()%>"></script>
    <script src="../js/Page/Comm/EditRow.js?t=<%=getToken()%>"></script>
    <script src="../js/Page/Contract/NewAddContract_FreeRent.js?t=<%=getToken()%>"></script>
    <script src="../js/Page/Contract/NewAddContract_RoomCharge.js?t=<%=getToken()%>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        .table_box {
            margin: 0 2%;
        }

        table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            margin: 0 auto;
            background: #fff;
        }

            table.field td {
                border: solid 1px #ccc;
                padding: 5px;
            }

            table.field input[type=text] {
                width: 200px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="table_title">免租期</div>
    <div class="table_box">
        <div id="fieldcontent">
            <table class="field">
                <%if (this.canEdit)
                    { %>
                <tr>
                    <td colspan="7">
                        <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td>免租开始日期
                    </td>
                    <td>免租结束日期
                    </td>
                    <td>免租天数
                    </td>
                    <td>免租方式
                    </td>
                    <td>免租资源
                    </td>
                    <td>免租收费项目
                    </td>
                    <td></td>
                </tr>
                <tr v-for="(item, index) in list" v-bind:id="'tr_'+item.count">
                    <td>
                        <input type="text" v-bind:id="item.count+'_starttime'" style="height: 28px; width: 120px;" v-model="item.StartTime" />
                    </td>
                    <td>
                        <input type="text" v-bind:id="item.count+'_endtime'" style="height: 28px; width: 120px;" v-model="item.EndTime" />
                    </td>
                    <td>
                        <input type="text" v-bind:id="item.count+'_freecount'" style="height: 28px; width: 120px;" v-model="item.FreeCount" />
                    </td>
                    <td>
                        <select v-model="item.FreeType" v-bind:id="item.count+'_freetype'" style="height: 28px; width: 100px;" data-options="editable:false">
                            <option value="1">扣减应收</option>
                            <option value="2">减免金额</option>
                        </select>
                    </td>
                    <td>
                        <select v-bind:id="item.count+'_roomid'" style="height: 28px; width: 100px;">
                        </select>
                    </td>
                    <td style="width: 40%;">
                        <textarea readonly="readonly" v-model="item.FreeChargeNames" v-on:click="do_choose_charge(item)" style="height: 40px; width: 80%; border-radius: 5px !important; border: solid 1px #ddd;">
                        </textarea>
                    </td>
                    <td>
                        <%if (this.canEdit)
                            { %>
                        <a href="javascript:void(0)" v-on:click="remove_line(item)">删除</a>
                        <%} %>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="table_title">收费标准</div>
    <div class="table_box">
        <table id="tt_chargesummary"></table>
        <div id="tb_summary">
            <%if (this.canEdit)
                { %>
            <a href="javascript:void(0)" onclick="AddCharge()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
            <a href="javascript:void(0)" onclick="EditCharge()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
            <a href="javascript:void(0)" onclick="RemoveCharge()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
            <%} %>
        </div>
    </div>
</asp:Content>
