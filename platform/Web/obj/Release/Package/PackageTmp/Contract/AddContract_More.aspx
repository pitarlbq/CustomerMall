<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddContract_More.aspx.cs" Inherits="Web.Contract.AddContract_More" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>合同登记</title>
    <script>
        var ffObj, ContractID, canEdit, cansavelog;
        $(function () {
            ffObj = $("#<%=this.ff.ClientID%>");
            ContractID = "<%=Request.QueryString["ID"]%>";
            canedit = "<%=this.canEdit?1:0%>";
            cansavelog = "<%=this.cansavelog ? 1 : 0%>";
        })
    </script>
    <script src="../js/Page/Contract/AddContract_More.js?t=<%=getToken()%>"></script>
    <style>
        table.info, table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.field td {
                border: solid 1px #ccc;
                padding: 5px;
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
        <table class="info" style="margin-top: 5px;">
            <tr>
                <td>合同状态</td>
                <td>
                    <input type="text" runat="server" value="合同预定" data-options="required:true,readonly:true" name="ContractStatus" class="easyui-textbox" id="tdContractStatus" /></td>
                <td>预警日期</td>
                <td>
                    <input type="text" runat="server" name="WarningTime" class="easyui-datebox" id="tdWarningTime" /></td>
            </tr>
            <tr>
                <td>铺位功能</td>
                <td>
                    <input type="text" runat="server" name="RoomUseFor" class="easyui-textbox" id="tdRoomUseFor" />
                </td>
                <td>铺位状态</td>
                <td>
                    <input type="text" runat="server" name="RoomStatus" class="easyui-textbox" id="tdRoomStatus" />
                </td>
            </tr>
            <tr>
                <td>租赁用途</td>
                <td>
                    <input type="text" runat="server" name="RentUseFor" class="easyui-textbox" id="tdRentUseFor" /></td>
                <td>签约日期</td>
                <td>
                    <input type="text" runat="server" name="SignTime" class="easyui-datebox" id="tdSignTime" /></td>
            </tr>

            <tr>
                <td>免租开始日期</td>
                <td>
                    <input type="text" runat="server" name="FreeStartTime" class="easyui-datebox" id="tdFreeStartTime" /></td>

                <td>免租结束日期</td>
                <td>
                    <input type="text" runat="server" name="FreeEndTime" class="easyui-datebox" id="tdFreeEndTime" /></td>
            </tr>
            <tr>
                <td>开业日期</td>
                <td>
                    <input type="text" runat="server" name="OpenTime" class="easyui-datebox" id="tdOpenTime" /></td>

                <td>进场日期</td>
                <td>
                    <input type="text" runat="server" name="InTime" class="easyui-datebox" id="tdInTime" /></td>
            </tr>
            <tr>
                <td>退场日期</td>
                <td>
                    <input type="text" runat="server" name="OutTime" class="easyui-datebox" id="tdOutTime" /></td>
            </tr>
            <tr>
                <td>计费周期</td>
                <td>
                    <input type="text" runat="server" name="RentRange" class="easyui-textbox" id="tdRentRange" />
                </td>
                <td>收费周期</td>
                <td>
                    <input type="text" runat="server" name="ChargeRange" class="easyui-textbox" id="tdChargeRange" /></td>
            </tr>
            <tr>
                <td>经营商品</td>
                <td>
                    <input type="text" runat="server" name="SellerProduct" class="easyui-textbox" id="tdSellerProduct" /></td>

                <td>每年递增</td>
                <td>
                    <input type="text" runat="server" name="EveryYearUp" class="easyui-textbox" id="tdEveryYearUp" />%</td>
            </tr>
            <tr>
                <td>业态品类/品牌</td>
                <td>
                    <input type="text" runat="server" name="BrandModel" class="easyui-textbox" id="tdBrandModel" /></td>

                <td>联系电话</td>
                <td>
                    <input type="text" runat="server" name="PhoneNumber" class="easyui-textbox" id="tdPhoneNumber" /></td>
            </tr>
            <tr>
                <td>通讯地址</td>
                <td>
                    <input type="text" runat="server" name="Address" class="easyui-textbox" id="tdAddress" /></td>

                <td>客户联系人</td>
                <td>
                    <input type="text" runat="server" name="CustomerName" class="easyui-textbox" id="tdCustomerName" /></td>
            </tr>
            <tr>
                <td>身份证号</td>
                <td>
                    <input type="text" runat="server" name="IDCardNo" class="easyui-textbox" id="tdIDCardNo" /></td>
                <td>身份证地址</td>
                <td>
                    <input type="text" runat="server" name="IDCardAddress" class="easyui-textbox" id="tdIDCardAddress" /></td>
            </tr>
            <tr>
                <td>交付时间</td>
                <td>
                    <input type="text" runat="server" name="DeliverTime" class="easyui-datetimebox" id="tdDeliverTime" /></td>
                <td>营业执照</td>
                <td>
                    <input type="text" runat="server" name="BusinessLicense" class="easyui-textbox" id="tdBusinessLicense" /></td>
            </tr>
            <tr>
                <td>法人代表</td>
                <td>
                    <input type="text" runat="server" name="InChargeMan" class="easyui-textbox" id="tdInChargeMan" /></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <%if (this.canEdit)
                      { %>
                    <a href="javascript:void(0)" onclick="saveData()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    <%if (contract == null)
                      { %>
                    <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                    <%}
                      } %>
                    <%else if (contract.ContractStatus.Equals("tongguo") && approve != null && approve.ApproveStatus.Equals("审核通过"))
                      { %>
                    已审核. 
                    <%if (approve.ApproveTime > DateTime.MinValue)
                      { %>
                    审核时间: <%=approve.ApproveTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                    <%}
                      }
                      else if (contract.ContractStatus.Equals("zhongzhi") && stop != null)
                      {%>
                    已终止. 
                    <%if (stop.StopTime > DateTime.MinValue)
                      { %>
                    终止时间: <%=stop.StopTime.ToString("yyyy-MM-dd HH:mm:ss")%>
                    <%}
                      } %>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
