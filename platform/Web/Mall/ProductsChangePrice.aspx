<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProductsChangePrice.aspx.cs" Inherits="Web.Mall.ProductsChangePrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var IDList = [];
        $(function () {
            var rows = parent.$("#tt_table").datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请至少选择一条数据进行此操作", "info");
                return;
            }
            var IDList = [];
            $.each(rows, function (index, row) {
                IDList.push(row.ID);
            })
            var options = { visit: 'getmallproductpricelist', IDList: JSON.stringify(IDList) };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    if (!data.status) {
                        show_message('系统错误', 'error');
                        return;
                    }
                    var $html = '';
                    $.each(data.list, function (index, row) {
                        $html += '<tr>';
                        $html += '<td>';
                        $html += row.VariantName;
                        $html += '</td>';
                        $html += '<td>';
                        $html += row.VariantPrice;
                        $html += '</td>';
                        $html += '<td>';
                        $html += '<input type="text" class="product_newprice final_price" data-id="' + row.ProductID + '" data-variantid="' + row.VariantID + '" data-price="' + row.VariantPrice + '" />';
                        $html += '</td>';
                        $html += '</tr>';
                    })
                    $('#table_product').append($html);
                    $('#tdChangeMethod').change(function () {
                        do_calculate_price();
                    })
                }
            });
        })
        function do_save() {
            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var list = [];
            $.each($('.final_price'), function (index) {
                var ProductID = parseFloat($(this).attr('data-id'));
                var VariantID = parseFloat($(this).attr('data-variantid'));
                var SalePrice = $(this).attr('data-price');
                var NewSalePrice = $(this).val();
                SalePrice = (SalePrice == "" ? 0 : parseFloat(SalePrice));
                NewSalePrice = (NewSalePrice == "" ? 0 : parseFloat(NewSalePrice));
                var item = { ProductID: ProductID, VariantID: VariantID, SalePrice: SalePrice, NewSalePrice: NewSalePrice };
                list.push(item);
            })
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallproductprices';
                    param.List = JSON.stringify(list);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var dataObj = eval("(" + data + ")");
                    if (dataObj.status) {
                        show_message('保存成功', 'success', function () {
                            do_close();
                        });
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
        function do_calculate_price() {
            if ($('#radio_btn1').prop('checked')) {
                var basic_price = $('#new_final_price1').val();
                basic_price = (basic_price == "" ? 0 : basic_price);
                $('.final_price').val(basic_price);
            }
            else if ($('#radio_btn2').prop('checked')) {
                var basic_price = $('#new_final_price2').val();
                basic_price = (basic_price == "" ? 0 : basic_price);
                var method = $('#tdChangeMethod').val();
                $.each($(".final_price"), function (index) {
                    var current_price = $(this).attr('data-price');
                    current_price = (current_price == "" ? 0 : current_price);
                    if (method == 1) {
                        current_price = parseFloat(current_price) + parseFloat(basic_price);
                        current_price = (current_price < 0 ? 0 : current_price);
                        $(this).val(current_price.toFixed(2));
                        return true;
                    }
                    if (method == 2) {
                        current_price = parseFloat(current_price) - parseFloat(basic_price);
                        current_price = (current_price < 0 ? 0 : current_price);
                        $(this).val(current_price.toFixed(2));
                        return true;
                    }
                    if (method == 3) {
                        current_price = parseFloat(current_price) * parseFloat(basic_price);
                        current_price = (current_price < 0 ? 0 : current_price);
                        $(this).val(current_price.toFixed(2));
                        return true;
                    }
                    if (method == 4) {
                        if (parseFloat(basic_price) == 0) {
                            return false;
                        }
                        current_price = parseFloat(current_price) / parseFloat(basic_price);
                        current_price = (current_price < 0 ? 0 : current_price);
                        $(this).val(current_price.toFixed(2));
                        return true;
                    }
                })
            }
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_table').datagrid('reload');
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        input.product_newprice {
            width: 50px;
            border: solid 1px #ccc;
            border-radius: 3px;
            line-height: 25px;
            height: 25px;
        }

        table.add {
            width: 96%;
            margin: 0 auto;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            background: #fff;
        }

            table.add td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: center;
                width: 33%;
            }

        .radio_box {
            width: 20px;
            height: 20px;
            display: inline-block;
            vertical-align: top;
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
            <table id="table_product" class="add">
                <tr>
                    <td>商品名称</td>
                    <td>原价</td>
                    <td>修改后价格</td>
                </tr>
            </table>
            <table class="add" style="margin-top: 10px;">
                <tr>
                    <td colspan="3" style="text-align: center;">
                        <input type="radio" name="change_type" id="radio_btn1" class="radio_box" value="0" />直接修改价格: 设置成统一价格
                    <input type="text" id="new_final_price1" class="product_newprice" onchange="do_calculate_price()" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center;">
                        <input type="radio" name="change_type" id="radio_btn2" class="radio_box" value="1" />运用统一公式修改价格：原价
                    <select id="tdChangeMethod">
                        <option value="1">加</option>
                        <option value="2">减</option>
                        <option value="3">乘</option>
                        <option value="4">除</option>
                    </select>
                        <input type="text" class="product_newprice" id="new_final_price2" onchange="do_calculate_price()" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
