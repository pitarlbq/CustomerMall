<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddContract_Basic.aspx.cs" Inherits="Web.Contract.AddContract_Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>合同登记</title>
    <script>
        var ffObj, guid, ContractID, RentStartTimeObj, RentEndTimeObj, canedit, tdTimeLimit, cansavelog, tdFreeDays, canrent, tdRentToTime, tdContractDeposit, canadd, canview,TopContractID;
        $(function () {
            ffObj = $("#<%=this.ff.ClientID%>");
            guid = "<%=this.guid%>";
            ContractID = "<%=this.ContractID%>";
            TopContractID = "<%=this.TopContractID%>";
            RentStartTimeObj = $("#<%=this.tdRentStartTime.ClientID%>");
            RentEndTimeObj = $("#<%=this.tdRentEndTime.ClientID%>");
            canadd = "<%=this.canAdd ? 1 : 0%>";
            canedit = "<%=this.canEdit ? 1 : 0%>";
            cansavelog = "<%=this.cansavelog ? 1 : 0%>";
            canrent = "<%=this.canRent ? 1 : 0%>";
            canview = "<%=this.canView ? 1 : 0%>";
            tdTimeLimit = $("#<%=this.tdTimeLimit.ClientID%>");
            tdFreeDays = $("#<%=this.tdFreeDays.ClientID%>");
            tdRentToTime = $("#<%=this.tdRentToTime.ClientID%>");
            tdContractDeposit = $("#<%=this.tdContractDeposit.ClientID%>");
        })
        function doExport() {
            $('#<%=this.btnExport.ClientID%>').click();
        }
    </script>
    <script src="../js/vue.js"></script>
    <script src="../js/Page/Contract/AddContract_Basic.js?t=<%=getToken()%>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.field {
            width: 96%;
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

        input[type=text] {
            width: 200px;
        }

        .table_title {
            position: relative;
            cursor: pointer;
        }

        .add_btn {
            position: absolute;
            top: 0;
            right: 10px;
            bottom: 0;
            width: 50px;
            margin-top: 5px;
            color: #0092DC;
        }

            .add_btn img {
                width: 20px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <%if (this.canprint)
              { %>
            <a href="javascript:void(0)" onclick="doExport()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
            <asp:Button runat="server" ID="btnExport" OnClick="btnExport_Click" Style="display: none;" />
            <a href="javascript:void(0)" onclick="printData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
            <%}
              if (this.canEdit)
              { %>
            <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <%
              } %>
        </div>
        <div class="table_container">
            <div class="table_title">基本信息</div>
            <table class="info">
                <tr>
                    <td>合同编号</td>
                    <td>
                        <input type="text" runat="server" data-name="rent_content" name="ContractNo" class="easyui-textbox" id="tdContractNo" data-options="required:true" /></td>
                    <td>合同名称</td>
                    <td>
                        <input type="text" runat="server" data-name="rent_content" name="ContractName" class="easyui-textbox" id="tdContractName" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>客户名称</td>
                    <td>
                        <input type="text" runat="server" data-name="rent_content" name="RentName" class="easyui-textbox" id="tdRentName" /></td>
                    <td>联系方式</td>
                    <td>
                        <input type="text" runat="server" data-name="rent_content" name="ContractPhone" class="easyui-textbox" id="tdContractPhone" /></td>
                </tr>
                <tr>
                    <td>开始日期</td>
                    <td>
                        <input type="text" runat="server" data-name="rent_content" name="RentStartTime" class="easyui-datebox" id="tdRentStartTime" /></td>
                    <td>结束日期</td>
                    <td>
                        <input type="text" runat="server" data-name="rent_content" name="RentEndTime" class="easyui-datebox" id="tdRentEndTime" /></td>
                </tr>
                <tr>
                    <td>合同期限</td>
                    <td>
                        <input type="text" runat="server" data-name="rent_content" data-options="readonly:true" name="TimeLimit" class="easyui-textbox" id="tdTimeLimit" />(月)
                    </td>
                    <%if (this.canRent)
                      { %>
                    <td>续租至</td>
                    <td>
                        <input type="text" runat="server" name="RentToTime" class="easyui-datebox" id="tdRentToTime" /></td>
                    <%} %>
                </tr>
            </table>
            <%if (!this.canRent)
              { %>
            <div class="table_title" id="room_icon_show" data-value="1">
                <label class="add_btn">
                    <img src="../styles/icons/double_down_arrow.png" /></label>
                租赁资源
            </div>
            <div id="room_show" style="margin: 0 2%;">
                <div class="easyui-panel" style="width: 100%; height: auto;" data-options="fit:false">
                    <table id="tt_room"></table>
                    <div id="tb">
                        <%if (this.canEdit)
                          { %>
                        <a href="javascript:void(0)" onclick="AddRoom()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                        <a href="javascript:void(0)" onclick="RemoveRoom()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                    </div>
                </div>
            </div>
            <div class="table_title" id="zuqi_icon_show" data-value="1">
                <label class="add_btn">
                    <img src="../styles/icons/double_down_arrow.png" /></label>
                免租期
            </div>
            <%} %>
            <div id="fieldcontent">
                <%if (!this.canRent)
                  { %>
                <table class="field">
                    <%if (this.canEdit)
                      { %>
                    <tr>
                        <td colspan="5">
                            <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td>免租开始日期
                        </td>
                        <td>免租结束日期
                        </td>
                        <td>免租方式
                        </td>
                        <td>免租收费项目
                        </td>
                        <td></td>
                    </tr>
                    <tr v-for="(item, index) in list" v-bind:id="'tr_'+item.count">
                        <td>
                            <input type="text" v-bind:id="item.count+'_starttime'" v-model="item.StartTime" />
                        </td>
                        <td>
                            <input type="text" v-bind:id="item.count+'_endtime'" v-model="item.EndTime" />
                        </td>
                        <td>
                            <select v-model="item.FreeType" v-bind:id="item.count+'_freetype'">
                                <option value="1">扣减应收</option>
                                <option value="2">减免金额</option>
                            </select>
                        </td>
                        <td style="width: 40%;">
                            <textarea readonly="readonly" v-model="item.FreeChargeNames" v-on:click="do_choose_charge(item)" style="height: 40px; width: 100%;">
                        </textarea>
                        </td>
                        <td>
                            <a href="javascript:void(0)" v-on:click="remove_line(item)">删除</a>
                        </td>
                    </tr>
                </table>
                <%} %>
            </div>
            <div class="table_title" id="charge_icon_show" data-value="1">
                <label class="add_btn">
                    <img src="../styles/icons/double_down_arrow.png" /></label>
                收费标准
            </div>
            <div id="charge_show" style="margin: 0 2%;">
                <div class="easyui-panel" style="width: 100%; height: auto;" data-options="fit:false">
                    <table id="tt_chargesummary"></table>
                    <div id="tb_summary">
                        <%if (this.canEdit || this.canRent)
                          { %>
                        <a href="javascript:void(0)" onclick="AddCharge()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                        <a href="javascript:void(0)" onclick="EditCharge()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-edit'">修改</a>
                        <a href="javascript:void(0)" onclick="RemoveCharge()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                        <%} %>
                    </div>
                </div>
            </div>
            <%if (!this.canRent)
              { %>
            <div class="table_title" id="other_icon_show" data-value="1">
                <label class="add_btn">
                    <img src="../styles/icons/double_down_arrow.png" /></label>
                其他信息
            </div>
            <table class="info" id="table_other">
                <tr>
                    <td>合同押金</td>
                    <td>
                        <input type="text" runat="server" name="ContractDeposit" class="easyui-textbox" id="tdContractDeposit" />(元)
                    </td>
                    <td>免租天数</td>
                    <td>
                        <input type="text" runat="server" name="FreeDays" class="easyui-textbox" id="tdFreeDays" />(天)</td>
                </tr>
                <tr>
                    <td>租金价格</td>
                    <td>
                        <input type="text" runat="server" name="RentPrice" class="easyui-textbox" id="tdRentPrice" />(元)</td>
                </tr>
                <tr>
                    <td>合同描述</td>
                    <td colspan="3">
                        <input type="text" runat="server" name="ContractSummary" class="easyui-textbox" id="tdContractSummary" data-options="multiline:true" style="width: 70%; height: 60px;" /></td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>附件</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
            <%} %>
            <div style="text-align: center;">
                <% if (contract != null && contract.ContractStatus.Equals("tongguo") && approve != null && approve.ApproveStatus.Equals("审核通过"))
                   { %>
                    已审核. 
                    <%if (approve.ApproveTime > DateTime.MinValue)
                      { %>
                    审核时间: <%=approve.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                <%}
               }
                   else if (contract != null && contract.ContractStatus.Equals("zhongzhi") && stop != null)
                   {%>
                    已终止. 
                    <%if (stop.StopTime > DateTime.MinValue)
                      { %>
                    终止时间: <%=stop.StopTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                <%}
               } %>
            </div>
        </div>
    </form>
</asp:Content>
