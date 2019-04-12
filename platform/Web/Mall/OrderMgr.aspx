<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="OrderMgr.aspx.cs" Inherits="Web.Mall.OrderMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var status = 0, ShareUserID;
        $(function () {
            status = "<%=this.status%>";
            ShareUserID = Number("<%=this.ShareUserID%>");
            if (ShareUserID > 0) {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 75;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
        })
        function do_close_win() {
            parent.do_close_dialog();
        }
    </script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script src="../js/vue.js"></script>
    <script src="../js/Page/Mall/Order/OrderMgr.js?v=<%=base.getToken()%>"></script>
    <style>
        table.order_content {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            text-align: center;
            margin-bottom: 60px;
        }

            table.order_content thead {
                position: static;
            }

            table.order_content td {
                padding: 5px;
                border: solid 1px #ccc;
            }

            table.order_content tbody td {
                vertical-align: top;
            }

            table.order_content thead td {
                background-color: #F0F0F0;
            }

        .menubox {
            background-color: #fff;
            text-align: left;
        }

            .menubox label, .menubox a {
                margin: 0 5px 0 0;
            }

                .menubox a.btn_opt {
                    border: solid 1px #ffc107;
                    padding: 0 5px;
                    border-radius: 3px;
                    cursor: pointer;
                    background-color: #ffc107;
                    color: #fff;
                    text-align: center;
                }

                    .menubox a.btn_opt:hover {
                        text-decoration: none;
                    }

        table.order_content td.order_head {
            text-align: left;
            background-color: #e8f9ff;
            padding: 10px 0;
        }

            table.order_content td.order_head label {
                margin-right: 20px;
            }

        .imagebox {
            width: 55px;
            height: 55px;
            display: inline-block;
            position: absolute;
            top: 50%;
            margin-top: -25px;
            bottom: 0;
        }

            .imagebox img {
                width: 100%;
                width: 50px;
                height: 50px;
                border-radius: 50%;
            }

        .product_info {
            display: block;
            margin-left: 60px;
            vertical-align: middle;
        }

        .pagination {
            margin: 0;
        }

        table.head_table {
            border-spacing: 0;
            border-collapse: collapse;
            width: 100%;
            background-color: #fff;
            border: none;
        }

            table.head_table td {
                text-align: right;
                background-color: #fff;
                padding: 0;
                border: none;
            }

                table.head_table td:nth-child(2n-1) {
                    text-align: left;
                }

        [v-cloak] {
            display: none;
        }

        label.btn_opt {
            border: solid 1px #ffc107;
            padding: 0 5px;
            border-radius: 3px;
            cursor: pointer;
            background-color: #ffc107;
            color: #fff;
            text-align: center;
        }

            label.btn_opt:hover {
                text-decoration: none;
            }

        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="main_form_layout" class="easyui-layout" data-options="fit:true,border:false">
        <div data-options="region:'north',border:false">
            <div class="operation_box" style="display: none;">
                <a href="javascript:void(0)" onclick="do_close_win()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
            </div>
            <table class="head_table">
                <tr>
                    <td>
                        <div class="menubox">
                            <label>
                                <input id="tdallcheck" type="checkbox" onclick="do_select_all()" />
                                全选
                            </label>
                            <%if (base.CheckAuthByModuleCode("1101438"))
                              { %>
                            <a class="btn_opt" href="javascript:do_pay()">付款</a>
                            <%} %>
                            <%if (base.CheckAuthByModuleCode("1101439"))
                              { %>
                            <a class="btn_opt" href="javascript:do_send_all()">批量发货</a>
                            <%} %>
                            <%if (base.CheckAuthByModuleCode("1101440"))
                              { %>
                            <a class="btn_opt" href="javascript:do_paidan_all()">批量派单</a>
                            <%} %>
                            <%if (base.CheckAuthByModuleCode("1101441"))
                              { %>
                            <a class="btn_opt" href="javascript:do_change_price_all()">批量改价</a>
                            <%} %>
                            <%if (base.CheckAuthByModuleCode("1101442"))
                              { %>
                            <a class="btn_opt" href="javascript:do_change_shiprate_all()">批量改运费</a>
                            <%} %>
                            <%if (base.CheckAuthByModuleCode("1101443"))
                              { %>
                            <a class="btn_opt" href="javascript:do_complete()">完成</a>
                            <%} %>
                            <%if (base.CheckAuthByModuleCode("1101444"))
                              { %>
                            <a class="btn_opt" href="javascript:do_close()">关闭</a>
                            <%} %>
                            <a class="btn_opt" href="javascript:do_remove()">删除</a>
                            <a class="btn_opt" href="javascript:do_export()">导出</a>
                            <label>
                                <input id="tdhideclose" type="checkbox" />
                                不显示已关闭的订单
                            </label>
                        </div>
                    </td>
                    <td>
                        <div class="easyui-pagination" id="data_pagination">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div data-options="region:'center',border:false">
            <div id="fieldcontent" v-cloak>
                <table class="order_content">
                    <thead>
                        <tr>
                            <td>商品</td>
                            <td>单价</td>
                            <td>数量</td>
                            <td>商品总金额</td>
                            <td>买家</td>
                            <td>交易状态</td>
                            <td>订单类型</td>
                            <td>运费</td>
                            <td>抵扣福顺券</td>
                            <td>订单总金额</td>
                            <td>订单总积分</td>
                            <td>发货</td>
                            <td>付款方式</td>
                            <td>买家备注</td>
                            <td>卖家备注</td>
                        </tr>
                    </thead>
                    <tbody v-for="item in orderlist">
                        <tr>
                            <td colspan="15" class="order_head" v-on:click="do_select(item)">
                                <label>
                                    <input type="checkbox" v-bind:checked="item.ischecked" />
                                </label>
                                <label>
                                    订单编号：{{item.OrderNumber}}
                                </label>
                                <label>
                                    成交时间：{{item.AddTime}}
                                </label>
                                <label>
                                    所属商户：{{item.BusinessName}}
                                </label>
                                <label v-if="item.ShareUserID>0" v-on:click="do_open_share_order(item.ShareUserID)" style="cursor: pointer;">
                                    分享人：{{item.ShareUserName}}
                                </label>
                                <label>
                                    <%if (base.CheckAuthByModuleCode("1101450"))
                                      { %>
                                    <label class="btn_opt" v-on:click="do_print(item.ID)">打印配送单</label>
                                    <%} %>
                                </label>
                            </td>
                        </tr>
                        <tr v-for="(item2,index2) in item.itemlist">
                            <td style="text-align: left; max-width: 260px; vertical-align: middle; position: relative; min-height: 55px;">
                                <div class="imagebox">
                                    <img v-bind:src="item2.imageurl" />
                                </div>
                                <div class="product_info">
                                    <div>{{item2.ProductTitle}}</div>
                                    <div style="font-size: 11px;">{{item2.ProductSubTitle}}</div>
                                </div>
                            </td>
                            <td>{{item2.Price}}
                            </td>
                            <td>{{item2.Quantity}}
                            </td>
                            <td>{{item2.TotalPrice}}
                            </td>
                            <td style="text-align: left; width: 150px;" v-if="index2==0" v-bind:rowspan="item.itemlist.length">
                                <div>{{item.BuyerName}}</div>
                                <div>{{item.BuyerPhone}}</div>
                                <div>{{item.FullAddressInfo}}</div>
                            </td>
                            <td v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.OrderStatusDesc}}
                                 <div>
                                     <%if (base.CheckAuthByModuleCode("1101445"))
                                       { %>
                                     <a class="btn_opt" href="#" v-on:click="do_view(item)">订单详情
                                     </a>
                                     <br />
                                     <%} %>
                                     <%if (base.CheckAuthByModuleCode("1101470"))
                                       { %>
                                     <a class="btn_opt" v-if="item.OrderStatus==6" href="#" v-on:click="do_refund(item)">退款处理
                                     </a>
                                     <%} %>
                                 </div>
                            </td>
                            <td v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.ProductTypeDesc}}
                            </td>
                            <td v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.ShipRateAmount}}
                                 <%if (base.CheckAuthByModuleCode("1101446"))
                                   { %>
                                <div v-if="item.OrderStatus == 1&&!item.IsClosed">
                                    <a class="btn_opt" href="#" v-on:click="do_change_shiprate(item)">修改运费
                                    </a>
                                </div>
                                <%} %>
                            </td>
                            <td v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.CouponAmount>0?item.CouponAmount:0}}
                            </td>
                            <td v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.TotalCost}}
                                <%if (base.CheckAuthByModuleCode("1101447"))
                                  { %>
                                <div v-if="item.OrderStatus == 1&&!item.IsClosed">
                                    <a class="btn_opt" href="#" v-on:click="do_change_price(item)">修改价格
                                    </a>
                                </div>
                                <%} %>
                            </td>
                            <td v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.TotalPoint}}
                            </td>
                            <td v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.ShipCompanyName}}
                                 <%if (base.CheckAuthByModuleCode("1101449"))
                                   { %>
                                <div v-if="item.OrderStatus == 5">
                                    <a class="btn_opt" href="#" v-on:click="do_send(item)">发货
                                    </a>
                                </div>
                                <%} %>
                                <div v-if="item.OrderStatus == 5">
                                    <a class="btn_opt" href="#" v-on:click="do_paidan(item)">派单
                                    </a>
                                </div>
                            </td>
                            <td v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.PaymentMethodDesc}}
                            </td>
                            <td style="max-width: 100px; text-align: left;" v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.UserNote}}
                            </td>
                            <td style="max-width: 100px; text-align: left;" v-if="index2==0" v-bind:rowspan="item.itemlist.length">{{item.SellerNote}}
                                 <%if (base.CheckAuthByModuleCode("1101448"))
                                   { %>
                                <div style="text-align: center;">
                                    <a class="btn_opt" href="#" v-on:click="do_change_note(item)">修改
                                    </a>
                                </div>
                                <%} %>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
