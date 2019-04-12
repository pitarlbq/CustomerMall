<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ShipRateEdit.aspx.cs" Inherits="Web.Mall.ShipRateEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdRateType;
        $(function () {
            ID = "<%=this.RateID%>";
            tdRateType = $('#<%=this.tdRateType.ClientID%>');
            tdRateType.combobox({
                editable: false,
                onSelect: function (ret) {
                    status_change();
                }
            })
            status_change();
        });
        function status_change() {
            var RateType = tdRateType.combobox('getValue');
            if (RateType == 1) {
                $('.ship_fee_setup').show();
            }
            else if (RateType == 2) {
                $('.ship_fee_setup').hide();
            }
        }
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallshiprate';
                    param.ID = ID;
                    param.ratedetails = JSON.stringify(content.list);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        if (dataObj.ID > 0) {
                            ID = dataObj.ID;
                            show_message('保存成功', 'success', function () {
                                do_close();
                            });
                            return;
                        }
                        show_message('数据不存在或已删除', 'warning');
                        return;
                    }
                    if (dataObj.error) {
                        show_message(dataObj.error, 'warning');
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <script src="../js/vue.js"></script>
    <script>
        var content;
        $(function () {
            content_reset();
        })
        function content_reset() {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                    count: 0
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        if (ID <= 0) {
                            return;
                        }
                        var options = { visit: 'getmallshipratedetails', ID: ID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/MallHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    that.list = data.list;
                                    that.count = that.list.length;
                                }
                                that.reset_combobox(true);
                            }
                        });
                    },
                    reset_combobox: function (alllist) {
                        var that = this;
                        that.set_combobox_value();
                        if (alllist) {
                            setTimeout(function () {
                                for (var i = 0; i < that.list.length; i++) {
                                    var index = that.list[i].count;
                                    var elem_id = 'Provice_' + index;
                                    var elem = $('#' + elem_id);
                                    if (elem) {
                                        elem.addClass('easyui-combobox');
                                        $.parser.parse('#tr_' + index);
                                        that.get_provice(elem_id, index);
                                    }
                                }
                            }, 200);
                            return;
                        }
                        setTimeout(function () {
                            var index = that.count;
                            var elem_id = 'Provice_' + index;
                            var elem = $('#' + elem_id);
                            if (elem) {
                                elem.addClass('easyui-combobox');
                                $.parser.parse('#tr_' + index);
                                that.get_provice(elem_id, index);
                            }
                        }, 200);
                    },
                    set_combobox_value: function () {
                        var that = this;
                        setTimeout(function () {
                            $.each(that.list, function (index, item) {
                                $('#Provice_' + item.count).combobox('setValues', item.ProvinceIDList);
                            });
                        }, 500);
                    },
                    get_provice: function (elem_id, count) {
                        var that = this;
                        $.ajax({
                            type: 'GET',
                            dataType: 'json',
                            url: '../js/json/province.txt',
                            success: function (data) {
                                $('#' + elem_id).combobox({
                                    multiple: true,
                                    editable: false,
                                    valueField: 'provinceID',
                                    textField: 'provinceName',
                                    data: data,
                                    onSelect: function () {
                                        var values = $('#' + elem_id).combobox('getValues');
                                        var ProvinceIDList = [];
                                        $.each(values, function (index, item) {
                                            var ProvinceID = parseInt(item);
                                            if (ProvinceID > 0) {
                                                ProvinceIDList.push(ProvinceID);
                                            }
                                        })
                                        $.each(that.list, function (index, item2) {
                                            if (count == item2.count) {
                                                item2.ProvinceIDList = ProvinceIDList;
                                                return false;
                                            }
                                        });
                                    },
                                    onUnselect: function () {
                                        var values = $('#' + elem_id).combobox('getValues');
                                        var ProvinceIDList = [];
                                        $.each(values, function (index, item) {
                                            var ProvinceID = parseInt(item);
                                            if (ProvinceID > 0) {
                                                ProvinceIDList.push(ProvinceID);
                                            }
                                        })
                                        $.each(that.list, function (index, item2) {
                                            if (count == item2.count) {
                                                item2.ProvinceIDList = ProvinceIDList;
                                                return false;
                                            }
                                        });
                                    }
                                })
                            }
                        });
                    },
                    add_line: function () {
                        var that = this;
                        that.count++;
                        var item = { ID: 0, RateID: 0, DefaultQuantity: '', DefaultAmount: '', AdditionalQuantity: '', AdditionalAmount: '', count: that.count, ProvinceIDList: [] };
                        that.list.push(item);
                        that.reset_combobox(0);
                    },
                    remove_line: function (item) {
                        var that = this;
                        if (item.ID == 0) {
                            $.each(that.list, function (index, item2) {
                                if (item.count == item2.count) {
                                    that.list.splice(index, 1);
                                    return false;
                                }
                            });
                            that.set_combobox_value();
                            return;
                        }
                        top.$.messager.confirm('提示', '确认删除?', function (r) {
                            if (r) {
                                var options = { visit: 'removemallshipratedetail', ID: item.ID };
                                $.ajax({
                                    type: 'POST',
                                    dataType: 'json',
                                    url: '../Handler/MallHandler.ashx',
                                    data: options,
                                    success: function (data) {
                                        if (data.status) {
                                            that.getdata();
                                            return;
                                        }
                                        show_message('系统错误', 'error');
                                    }
                                });
                            }
                        })
                    }
                }
            });
            content.getdata();
        }
    </script>
    <style>
        .image_box {
            min-width: 100px;
            display: inline-block;
            margin: 10px;
            text-align: center;
        }

            .image_box img {
                width: 100px;
            }


        .panel-body {
            background: #f0f0f0;
        }

        table.info table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info table.field td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 25%;
            }

            table.info table.field input[type=text] {
                padding: 2px 8px;
                border: solid 1px #ddd;
                border-radius: 5px !important;
                width: 80px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <div class="table_title"><span id="tdProductType" runat="server"></span>默认(除指定地区外)运费</div>
            <table class="info">
                <tr>
                    <td>配送名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdRateTitle" data-options="required:true" /></td>
                    <td>配送方式</td>
                    <td>
                        <select class="easyui-combobox" runat="server" id="tdRateType" data-options="editable:false">
                            <option value="1">快递</option>
                            <option value="2">自提</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>是否默认</td>
                    <td colspan="3">
                        <select class="easyui-combobox" runat="server" id="tdIsDefault" data-options="editable:false">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>配送说明
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="height: 60px; width: 85%;" runat="server" id="tdRateSummary" /></td>
                </tr>
                <tr class="ship_fee_setup">
                    <td>运费设置</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdDefaultQuantity" style="width: 80px; text-align: center;" />件内<input type="text" class="easyui-textbox" runat="server" id="tdDefaultAmount" style="width: 80px; text-align: center;" />元.
                    每增加<input type="text" class="easyui-textbox" runat="server" id="tdAdditionalQuantity" style="width: 80px; text-align: center;" />件, 运费增加<input type="text" class="easyui-textbox" runat="server" id="tdAdditionalAmount" style="width: 80px; text-align: center;" />元
                    </td>
                </tr>
            </table>
            <div class="table_title">指定地区运费</div>
            <table class="info">
                <tr>
                    <td colspan="4" style="padding: 0;">
                        <div id="fieldcontent">
                            <table class="field">
                                <tr>
                                    <td colspan="3">
                                        <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%;">选择地区
                                    </td>
                                    <td style="width: 60%;">运费设置
                                    </td>
                                    <td></td>
                                </tr>
                                <tr v-for="(item, index) in list" v-bind:id="'tr_'+item.count">
                                    <td>
                                        <input type="text" style="width: 200px;" class="easyui_combobox" v-model="item.ProvinceIDList" v-bind:id="'Provice_'+item.count" />
                                    </td>
                                    <td>
                                        <input type="text" v-model="item.DefaultQuantity" />件内<input type="text" v-model="item.DefaultAmount" />元.
                                    每增加<input type="text" v-model="item.AdditionalQuantity" />件, 运费增加<input type="text" v-model="item.AdditionalAmount" />元
                                    </td>
                                    <td>
                                        <a class="easyui_linkbutton" href="javascript:void(0)" v-on:click="remove_line(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
