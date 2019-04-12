<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditSource.aspx.cs" Inherits="Web.Setup.EditSource" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/PinYin.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        $(function () {
            loadCommobox();
            $("#<%=this.tdCount.ClientID%>").numberbox({
                onChange: onCountChange
            });
            $("#<%=this.tdStartTime.ClientID%>").datebox({
                onChange: onStartChange
            });
            $("#<%=this.tdEndTime.ClientID%>").datebox({
                onChange: onEndChange
            });
        })
        function saveResource() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            var ID = "<%=Request.QueryString["ID"]%>";
            var OrderNumber = $("#<%=this.tdOrderNumber.ClientID%>").textbox("getValue");
            var InventoryInfoID = $("#<%=this.tdInventoryInfo.ClientID%>").combobox("getValue");
            var BusinessID = $("#<%=this.tdBusiness.ClientID%>").combobox("getValue");
            var ProductID = $("#<%=this.tdProduct.ClientID%>").combobox("getValue");
            var Count = $("#<%=this.tdCount.ClientID%>").numberbox("getValue");
            var CarrierID = $("#<%=this.tdCarrier.ClientID%>").combobox("getValue");
            var SpecID = $("#<%=this.tdSpec.ClientID%>").combobox("getValue");
            var StartTime = $("#<%=this.tdStartTime.ClientID%>").datebox("getValue");
            var EndTime = $("#<%=this.tdEndTime.ClientID%>").datebox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            var MoveCost = $("#<%=this.tdMoveCost.ClientID%>").numberbox("getValue");
            var ColdCost = $("#<%=this.tdColdCost.ClientID%>").numberbox("getValue");
            var options = { visit: 'saveresource', ID: ID, OrderNumber: OrderNumber, InventoryInfoID: InventoryInfoID, BusinessID: BusinessID, ProductID: ProductID, Count: Count, CarrierID: CarrierID, SpecID: SpecID, StartTime: StartTime, EndTime: EndTime, Remark: Remark, AddMan: AddMan, MoveCost: MoveCost, ColdCost: ColdCost };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/CommHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        show_message('保存成功', 'success', function () {
                            closeWin();
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
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
                        editable: true,
                        data: message.inventorylist,
                        valueField: 'ID',
                        textField: 'InventoryName'
                    });
                    $('#<%=this.tdBusiness.ClientID%>').combobox({
                        editable: true,
                        data: message.businesslist,
                        valueField: 'ID',
                        textField: 'ContactName',
                        filter: function (q, row) {
                            var opts = $(this).combobox('options');
                            return __pinyin.getFirstLetter(row[opts.textField]).indexOf(q.toLowerCase()) != -1 || row[opts.textField].indexOf(q) != -1;
                        }
                    });
                    $('#<%=this.tdProduct.ClientID%>').combobox({
                        editable: true,
                        data: message.productlist,
                        valueField: 'ID',
                        textField: 'ProductName'
                    });
                    $('#<%=this.tdCarrier.ClientID%>').combobox({
                        editable: true,
                        data: message.carrierlist,
                        valueField: 'ID',
                        textField: 'CarrierName'
                    });
                    $('#<%=this.tdSpec.ClientID%>').combobox({
                        editable: true,
                        data: message.speclist,
                        valueField: 'ID',
                        textField: 'SpecName',
                        onSelect: function (rec) {
                            var coldprice = rec.ColdPrice;
                            if (Number(coldprice) < 0) {
                                coldprice = "价格另定";
                            }
                            if (Number(rec.MovePrice) <= 0) {
                                rec.MovePrice = 0;
                            }
                            $("#<%=this.tdColdPrice.ClientID%>").textbox("setValue", coldprice);
                            $("#<%=this.tdMovePrice.ClientID%>").textbox("setValue", rec.MovePrice);
                            $("#<%=this.hdMovePrice.ClientID%>").val(rec.MovePrice);
                            calculateMoveCost(0);
                            calculateColdCost(0, "", "");
                        }
                    });
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
        function onCountChange(newvalue, oldvalue) {
            calculateMoveCost(newvalue);
            calculateColdCost(newvalue, "", "");
        }
        function onStartChange(newvalue, oldvalue) {
            calculateColdCost(0, newvalue, "");
            calculateEndTime(newvalue)
        }
        function onEndChange(newvalue, oldvalue) {
            calculateColdCost(0, "", newvalue);
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
            $("#<%=this.tdMoveCost.ClientID%>").numberbox("setValue", moveprice);
        }
        function calculateColdCost(count, startime, endtime) {
            var coldprice = Number($("#<%=this.tdColdPrice.ClientID%>").textbox("getValue"));
            if (Number(coldprice) < 0) {
                coldprice = 0;
            }
            if (count == 0) {
                count = $("#<%=this.tdCount.ClientID%>").numberbox("getValue");
            }
            if (startime == "") {
                startime = $("#<%=this.tdStartTime.ClientID%>").datebox("getValue");
            }
            if (endtime == "") {
                endtime = $("#<%=this.tdEndTime.ClientID%>").datebox("getValue");
            }
            if (startime == "" || endtime == "") {
                return 0;
            }
            startime = startime.replace(/-/g, "/");
            endtime = endtime.replace(/-/g, "/");
            var startdate = new Date(startime);
            var enddate = new Date(endtime);
            var date3 = enddate.getTime() - startdate.getTime()  //时间差的毫秒数
            var days = Math.floor(date3 / (24 * 3600 * 1000))
            if (Number(coldprice) > 0 && Number(count) > 0) {
                coldprice = Number(coldprice) * Number(count);
            }
            $("#<%=this.tdColdCost.ClientID%>").numberbox("setValue", coldprice.toFixed(2));
        }
        function calculateEndTime(startime) {
            if (startime == "") {
                startime = $("#<%=this.tdStartTime.ClientID%>").datebox("getValue")
            }
            startime = startime.replace(/-/g, "/");
            var startdate = new Date(startime);
            startdate.setDate(startdate.getDate() + 30);
            var y = startdate.getFullYear();
            var m = (startdate.getMonth() + 1) < 10 ? "0" + (startdate.getMonth() + 1) : (startdate.getMonth() + 1);//获取当前月份的日期，不足10补0
            var d = startdate.getDate() < 10 ? "0" + startdate.getDate() : startdate.getDate(); //获取当前几号，不足10补0
            var endtime = y + "-" + m + "-" + d;
            $("#<%=this.tdEndTime.ClientID%>").datebox("setValue", endtime);
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
                    <input class="easyui-combobox" id="tdInventoryInfo" runat="server" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>商户
                </td>
                <td>
                    <input class="easyui-combobox" id="tdBusiness" runat="server" data-options="required:true" />
                </td>
                <td>货品
                </td>
                <td>
                    <input class="easyui-combobox" id="tdProduct" runat="server" data-options="required:true" />
                </td>
            </tr>
            <tr>
                <td>开始时间
                </td>
                <td>
                    <input class="easyui-datebox" id="tdStartTime" runat="server" />
                </td>
                <td>结束时间
                </td>
                <td>
                    <input id="tdEndTime" class="easyui-datebox" runat="server" data-options="disabled:true" />
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
                    <input id="tdColdPrice" class="easyui-textbox" runat="server" type="text" data-options="disabled:true" />
                </td>
            </tr>
            <tr>
                <td>搬运费单价
                </td>
                <td>
                    <asp:HiddenField ID="hdMovePrice" runat="server" />
                    <input id="tdMovePrice" class="easyui-textbox" runat="server" type="text" data-options="disabled:true" />
                </td>
                <td>搬运费
                </td>
                <td>
                    <input id="tdMoveCost" class="easyui-numberbox" data-options="min:0,precision:2" runat="server" type="text" />
                </td>
            </tr>
            <tr>
                <td>冷藏费
                </td>
                <td colspan="3">
                    <input id="tdColdCost" class="easyui-numberbox" data-options="min:0,precision:2" runat="server" type="text" />
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
                    <a id="tdSave" runat="server" href="javascript:void(0)" class="easyui-linkbutton" onclick="saveResource()" data-options="iconCls:'icon-add'">保存</a>
                    <a href="javascript:void(0)" class="easyui-linkbutton" onclick="closeWin()" data-options="iconCls:'icon-cancel'">关闭</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
