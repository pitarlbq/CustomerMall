<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="AddSourceOut.aspx.cs" Inherits="Web.Setup.AddSourceOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        $(function () {
            loadCommobox();
            $("#<%=this.tdCount.ClientID%>").numberbox({
                onChange: onCountChange
            });
        })
        function saveResource() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var Count = $("#<%=this.tdCount.ClientID%>").numberbox("getValue");
            if (Count <= 0) {
                show_message("出库数量必须大于0", "info");
                return;
            }
            var ID = "<%=Request.QueryString["ID"]%>";
            var CarrierID = $("#<%=this.tdCarrier.ClientID%>").combobox("getValue");
            var MoveCost = $("#<%=this.tdMoveCost.ClientID%>").numberbox("getValue");
            var SpecID = $("#<%=this.tdSpec.ClientID%>").combobox("getValue");
            var OutTime = $("#<%=this.tdOutTime.ClientID%>").datebox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var OrderNumber = $("#<%=this.tdOrderNumber.ClientID%>").textbox("getValue");
            var options = { visit: 'saveresourceout', ID: ID, CarrierID: CarrierID, MoveCost: MoveCost, Count: Count, OutTime: OutTime, Remark: Remark, AddMan: AddMan, SpecID: SpecID, OrderNumber: OrderNumber };
            MaskUtil.mask('body', '提交中');
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status == 1) {
                        show_message('保存成功', 'success', function () {
                            closeWin();
                        });
                        return;
                    }
                    if (message.status == 2) {
                        show_message("出库数量不能大于入库数量", "info");
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function loadCommobox() {
            var options = { visit: 'loadallcommbox' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
                data: options,
                success: function (message) {
                    if (!message.status) {
                        return;
                    }
                    $('#<%=this.tdInventoryInfo.ClientID%>').combobox({
                        editable: false,
                        data: message.inventorylist,
                        valueField: 'ID',
                        textField: 'InventoryName'
                    });
                    $('#<%=this.tdBusiness.ClientID%>').combobox({
                        editable: false,
                        data: message.businesslist,
                        valueField: 'ID',
                        textField: 'ContactName',
                        filter: function (q, row) {
                            var opts = $(this).combobox('options');
                            return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                        }
                    });
                    $('#<%=this.tdProduct.ClientID%>').combobox({
                        editable: false,
                        data: message.productlist,
                        valueField: 'ID',
                        textField: 'ProductName'
                    });
                    $('#<%=this.tdCarrier.ClientID%>').combobox({
                        editable: false,
                        data: message.carrierlist,
                        valueField: 'ID',
                        textField: 'CarrierName'
                    });
                    $('#<%=this.tdSpec.ClientID%>').combobox({
                        editable: false,
                        data: message.speclist,
                        valueField: 'ID',
                        textField: 'SpecName',
                        onSelect: function (rec) {
                            var coldprice = rec.ColdPrice;
                            if (Number(coldprice) < 0) {
                                coldprice = "价格另定";
                            }
                            $("#<%=this.tdColdPrice.ClientID%>").textbox("setValue", coldprice);
                            $("#<%=this.tdMovePrice.ClientID%>").textbox("setValue", rec.MovePrice);
                            $("#<%=this.hdMovePrice.ClientID%>").val(rec.MovePrice);
                            calculateMoveCost(0);
                        }
                    });
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
        function calculateMoveCost(count) {
            var moveprice = Number($("#<%=this.hdMovePrice.ClientID%>").val());
            if (Number(moveprice) < 0) {
                moveprice = 0;
            }
            if (count == 0) {
                count = $("#<%=this.tdCount.ClientID%>").numberbox("getValue");
            }
            if (Number(moveprice) > 0 && Number(count) > 0) {
                moveprice = Number(moveprice) * Number(count);
            }
            moveprice = 0;
            $("#<%=this.tdMoveCost.ClientID%>").numberbox("setValue", moveprice);
        }
        function onCountChange(newvalue, oldvalue) {
            calculateMoveCost(newvalue);
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

        input {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server">
        <table class="add">
            <tr>
                <td>单号
                </td>
                <td>
                    <input class="easyui-textbox" id="tdOrderNumber" runat="server" data-options="required:true" />
                </td>
                <td>库位
                </td>
                <td>
                    <input class="easyui-combobox" id="tdInventoryInfo" runat="server" data-options="required:true,disabled:true" />
                </td>
            </tr>
            <tr>
                <td>商户
                </td>
                <td>
                    <input class="easyui-combobox" id="tdBusiness" runat="server" data-options="required:true,disabled:true" />
                </td>
                <td>货品
                </td>
                <td>
                    <input class="easyui-combobox" id="tdProduct" runat="server" data-options="required:true,disabled:true" />
                </td>
            </tr>
            <tr>
                <td>数量
                </td>
                <td>
                    <input class="easyui-numberbox" id="tdCount" runat="server" data-options="required:true,min:1" />(单位:件)
                </td>
                <td>搬运工
                </td>
                <td>
                    <input class="easyui-combobox" id="tdCarrier" runat="server" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>规格
                </td>
                <td>
                    <input class="easyui-combobox" id="tdSpec" runat="server" data-options="required:true" />
                </td>
                <td>冷藏费单价
                </td>
                <td>
                    <input id="tdColdPrice" class="easyui-textbox" runat="server" type="text" data-options="disabled:true,disabled:true" />
                </td>
            </tr>
            <tr>
                <td>搬运费单价
                </td>
                <td>
                    <asp:HiddenField ID="hdMovePrice" runat="server" />
                    <input id="tdMovePrice" class="easyui-textbox" runat="server" type="text" data-options="disabled:true,disabled:true" />
                </td>
                <td>搬运费
                </td>
                <td>
                    <input id="tdMoveCost" class="easyui-numberbox" data-options="min:0,precision:2,disabled:true" runat="server" type="text" />
                </td>
            </tr>
            <tr>
                <td>出库时间
                </td>
                <td colspan="3">
                    <input id="tdOutTime" class="easyui-datebox" runat="server" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>备注
                </td>
                <td colspan="3">
                    <input class="easyui-textbox" data-options="multiline:true" id="tdRemark" style="width: 80%; height: 60px;" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" class="easyui-linkbutton" onclick="saveResource()" data-options="iconCls:'icon-add'">保存</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" onclick="closeWin()" data-options="iconCls:'icon-cancel'">关闭</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
