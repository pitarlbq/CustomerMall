<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ChooseChargeSummary.aspx.cs" Inherits="Web.Contract.ChooseChargeSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.field td {
                border: solid 1px #ccc;
                padding: 5px;
            }
    </style>
    <script src="../js/vue.js"></script>
    <script>
        var content, source, rowIndex;
        $(function () {
            source = '<%=this.source%>';
            rowIndex = '<%=this.rowIndex%>';
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: []
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        var FeeType = 0;
                        if (source == 'freerent') {
                            FeeType = 1;
                        }
                        var options = { visit: 'getchargesummarylist', FeeType: FeeType };
                        MaskUtil.mask();
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/FeeCenterHandler.ashx',
                            data: options,
                            success: function (data) {
                                MaskUtil.unmask();
                                $.each(data, function (index, item) {
                                    var result = { Selected: false, ID: item.ID, Name: item.Name, FeeTypeDesc: item.FeeTypeDesc, CategoryDesc: item.CategoryDesc };
                                    that.list.push(result);
                                })
                                return;
                            }
                        });
                    },
                    do_choose: function (item) {
                        item.Selected = !item.Selected;
                    }
                }
            });
            content.getdata();
        });
        function do_save() {
            var nameList = [];
            var idList = [];
            $.each(content.list, function (index, item) {
                if (item.Selected) {
                    nameList.push(item.Name);
                    idList.push(item.ID);
                }
            })
            if (source == 'AddContract_Part') {
                parent.doChoooseChargeDoneContractParty(rowIndex, nameList, idList);
                do_close(false);
            }
            else {
                parent.content.choose_chargenames = nameList;
                parent.content.choose_chargeids = idList;
                do_close(true);
            }
        }
        function do_close(canReload) {
            parent.do_close_dialog(function () {
                if (canReload) {
                    parent.do_choose_charge_done();
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div id="fieldcontent">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <table class="field">
                <tr>
                    <td></td>
                    <td>收费项目</td>
                    <td>收费性质</td>
                    <td>分类</td>
                </tr>
                <tr v-for="(item,index) in list" v-on:click="do_choose(item)">
                    <td>
                        <input type="checkbox" v-model="item.Selected" />
                    </td>
                    <td>{{item.Name}}
                    </td>
                    <td>{{item.FeeTypeDesc}}
                    </td>
                    <td>{{item.CategoryDesc}}
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
