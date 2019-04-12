<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="Web.Mall.ProductEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/vue.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v5"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script type="text/javascript">
        var ue, ID, filecount = 0, tdCategoryName, tdBusinessName, tdIsZiYing, type, tdTagName, hdTagName, tdShipRateID, tdIsAllowPointBuy, content, tdIsAllowProductBuy, tdIsAllowVIPBuy, tdIsAllowStaffBuy;
        $(function () {
            type = "<%=this.type%>";
            ID = "<%=this.ProductID%>";
            tdCategoryName = $('#<%=this.tdCategoryName.ClientID%>');
            tdBusinessName = $('#<%=this.tdBusinessName.ClientID%>');
            tdIsZiYing = $('#<%=this.tdIsZiYing.ClientID%>');
            tdTagName = $('#<%=this.tdTagName.ClientID%>');
            hdTagName = $('#<%=this.hdTagName.ClientID%>');
            tdShipRateID = $('#<%=this.tdShipRateID.ClientID%>');
            tdIsAllowProductBuy = $('#<%=this.tdIsAllowProductBuy.ClientID%>');
            tdIsAllowPointBuy = $('#<%=this.tdIsAllowPointBuy.ClientID%>');
            tdIsAllowVIPBuy = $('#<%=this.tdIsAllowVIPBuy.ClientID%>');
            tdIsAllowStaffBuy = $('#<%=this.tdIsAllowStaffBuy.ClientID%>');
            createEditor();
            addFile();
            loadattachs();
            vue_process();
            get_select_category_params();
            tdIsZiYing.combobox({
                onSelect: function (ret) {
                    change_ziying_status();
                }
            })
            tdIsAllowProductBuy.combobox({
                onSelect: function (ret) {
                    change_ziying_status();
                }
            })
            tdIsAllowPointBuy.combobox({
                onSelect: function (ret) {
                    change_ziying_status();
                }
            })
            tdIsAllowVIPBuy.combobox({
                onSelect: function (ret) {
                    change_ziying_status();
                }
            })
            tdIsAllowStaffBuy.combobox({
                onSelect: function (ret) {
                    change_ziying_status();
                }
            })
            loadtagparams();
        });
        function loadtagparams() {
            var options = { visit: 'getmalltagparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        tdTagName.combobox({
                            editable: false,
                            data: data.list,
                            valueField: 'ID',
                            textField: 'Name',
                            multiple: true,
                            onSelect: function (rec) {
                                var values = tdTagName.combobox('getValues');
                                hdTagName.val(JSON.stringify(values));
                            },
                            onUnselect: function (rec) {
                                var values = tdTagName.combobox('getValues');
                                hdTagName.val(JSON.stringify(values));
                            }
                        });
                        return;
                    }
                }
            });
        }
        function change_ziying_status() {
            var ziying_value = tdIsZiYing.combobox('getValue');
            if (ziying_value == '1') {
                $('.no_ziying').hide();
            }
            else {
                $('.no_ziying').show();
            }
            if (type != 3 && type != 4) {
                $('.tr_allowpointbuy').show();
            } else {
                $('.tr_allowpointbuy').hide();
            }
            var IsAllowProductBuy = tdIsAllowProductBuy.combobox('getValue');
            if (IsAllowProductBuy == '1') {
                if (content.list.length > 0) {
                    $('.product_price').hide();
                    $('.variant_product_price').show();
                } else {
                    $('.product_price').show();
                    $('.variant_product_price').hide();
                }
                content.form.showproduct = true;
            }
            else {
                $('.variant_product_price').hide();
                $('.product_price').hide();
                content.form.showproduct = false;
            }
            var IsAllowPointBuy = tdIsAllowPointBuy.combobox('getValue');
            if (IsAllowPointBuy == '1') {
                $('.point_price').show();
                if (content.list.length > 0) {
                    $('.point_price').hide();
                    $('.variant_point_price').show();
                } else {
                    $('.point_price').show();
                    $('.variant_point_price').hide();
                }
                content.form.showpoint = true;
            }
            else {
                $('.variant_point_price').hide();
                $('.point_price').hide();
                content.form.showpoint = false;
            }
            var IsAllowVIPBuy = tdIsAllowVIPBuy.combobox('getValue');
            if (IsAllowVIPBuy == '1') {
                if (content.list.length > 0) {
                    $('.vip_price').hide();
                    $('.variant_vip_price').show();
                } else {
                    $('.vip_price').show();
                    $('.variant_vip_price').hide();
                }
                content.form.showvippoint = true;
            }
            else {
                $('.variant_vip_price').hide();
                $('.vip_price').hide();
                content.form.showvippoint = false;
            }
            var IsAllowStaffBuy = tdIsAllowStaffBuy.combobox('getValue');
            if (IsAllowStaffBuy == '1') {
                if (content.list.length > 0) {
                    $('.staff_price').hide();
                    $('.variant_staff_price').show();
                } else {
                    $('.staff_price').show();
                    $('.variant_staff_price').hide();
                }
                content.form.showstaffpoint = true;
            }
            else {
                $('.variant_staff_price').hide();
                $('.staff_price').hide();
                content.form.showstaffpoint = false;
            }
            content.form.columncount = 11;
            if (!content.form.showproduct) {
                content.form.columncount--;
            }
            if (!content.form.showpoint) {
                content.form.columncount--;
                content.form.columncount--;
            }
            if (!content.form.showvippoint) {
                content.form.columncount--;
                content.form.columncount--;
            }
            if (!content.form.showstaffpoint) {
                content.form.columncount--;
                //content.form.columncount--;
            }
        }
        function init() {
            //去掉结点前面的文件及文件夹小图标
            $(".tree-icon,.tree-file").removeClass("tree-icon tree-file");
            $(".tree-icon,.tree-folder").removeClass("tree-icon tree-folder tree-folder-open tree-folder-closed");
        }
        function get_select_category_params() {
            var options = { visit: 'getmallproducteditcategorytreeparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    tdCategoryName.combotree({
                        multiple: true,
                        editable: false,
                        valueField: 'id',
                        textField: 'text',
                        data: data
                    });
                    init();
                }
            });
            get_select_business_params();
        }
        function get_select_business_params() {
            var options = { visit: 'getmallproducteditparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    if (data.status) {
                        tdBusinessName.combobox({
                            editable: false,
                            valueField: 'ID',
                            textField: 'Name',
                            data: data.businesses
                        });
                        tdShipRateID.combobox({
                            editable: false,
                            valueField: 'ID',
                            textField: 'Name',
                            data: data.shiprates
                        });
                    }
                }
            });
        }
        function setContent() {
            var content = $("#<%=this.hdDescription.ClientID%>").val();
            ue.setContent(content, false);
        }
        function createEditor() {
            window.SERVERAPPLICATION = "<%=Web.WebUtil.getApplicationPath()%>";
            ue = UE.getEditor('tdDescription', {
                toolbars: [["fullscreen", "source", "|", "undo", "redo", "|", "bold", "italic", "underline", "fontborder", "strikethrough", "superscript", "subscript", "removeformat", "formatmatch", "autotypeset", "blockquote", "pasteplain", "|", "forecolor", "backcolor", "insertorderedlist", "insertunorderedlist", "selectall", "cleardoc", "|", "rowspacingtop", "rowspacingbottom", "lineheight", "|", "customstyle", "paragraph", "fontfamily", "fontsize", "|", "directionalityltr", "directionalityrtl", "indent", "|", "justifyleft", "justifycenter", "justifyright", "justifyjustify", "|", "touppercase", "tolowercase", "|", "link", "unlink", "anchor", "|", "emotion", "|", "horizontal", "date", "time", "spechars", "|", "preview", 'simpleupload', "help"
                ]],
                autoHeightEnabled: true,
                autoFloatEnabled: true
            });
            setTimeout(function () {
                setContent();
            }, 1000);
        }
        function addFile() {
            $("#tdFile").find("a.fileadd").hide();
            $("#tdFile").find("a.fileremove").show();
            filecount++;
            var $html = "<div id=\"tdFile_" + filecount + "\">";
            $html += "<input class=\"easyui-filebox\" name=\"attachfile\" data-options=\"prompt:'请选择图片',buttonText: '选择图片'\" style=\"width: 60%\" />";
            $html += "<a href=\"javascript:void(0)\" onclick=\"addFile()\" class=\"easyui-linkbutton btnlinkbar fileadd\" data-options=\"plain:true,iconCls:'icon-add'\">添加</a>";
            $html += "<a href=\"javascript:void(0)\" onclick=\"deleteFile(" + filecount + ")\" class=\"easyui-linkbutton btnlinkbar fileremove\" style=\"display:none;\" data-options=\"plain:true,iconCls:'icon-remove'\">删除</a>";
            $html += "</div>";
            $("#tdFile").append($html);
            $.parser.parse("#tdFile_" + filecount);
        }
        function deleteFile(id) {
            $("#tdFile_" + id).html("");
        }
        function loadattachs() {
            if (ID <= 0) {
                return;
            }
            var options = { visit: 'getmallproductpics', ID: ID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/MallHandler.ashx',
                data: options,
                success: function (data) {
                    var $html = '';
                    $("#trExistFiles").html($html);
                    if (!data.status) {
                        return;
                    }
                    if (data.list.length > 0) {
                        $("#trExistFiles").show();
                        $html += '<td>已上传相册</td>';
                        $html += '<td colspan="3">';
                        $.each(data.list, function (index, item) {
                            $html += '<div class="image_box">';
                            $html += '<a href="' + item.LargePicPath + '" target="_blank" ><image src="' + item.IconPicPath + '"></a>';
                            $html += '<br/><a href="#" onclick="deleteAttach(' + item.ID + ')">删除</a>';
                            $html += '</div>';
                        })
                        $html += '</td>';
                    }
                    $("#trExistFiles").append($html);
                    $html = '';
                    $("#cover_img").hide();
                    if (data.CoverImage != '') {
                        $html += '<a href="' + data.CoverImage + '" target="_blank" ><image src="' + data.CoverImage + '"></a>';
                        $html += '<br/><a href="#" onclick="deleteCover()">删除</a>';
                        $("#cover_img").show();
                    }
                    $("#cover_img").append($html);
                }
            });
        }
        function deleteCover() {
            top.$.messager.confirm("提示", "是否删除选已上传的封面?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallproductcover', ID: ID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/MallHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('操作成功', 'success', function () {
                                    loadattachs();
                                });
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
        function deleteAttach(AttachID) {
            top.$.messager.confirm("提示", "是否删除选已上传的相册?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallproductpic', ID: AttachID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/MallHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                show_message('操作成功', 'success', function () {
                                    loadattachs();
                                });
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
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
                    var CategoryIDList = tdCategoryName.combotree('getValues');
                    param.visit = 'savemallproduct';
                    param.ID = ID;
                    param.CategoryIDs = JSON.stringify(CategoryIDList);
                    param.BusinessID = tdBusinessName.combobox('getValue');
                    param.ProductTypeID = type;
                    param.Description = ue.getContent();
                    if (type != 3 && type != 4) {
                        param.Variants = JSON.stringify(content.list);
                    }
                    param.TagName = hdTagName.val();
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
    <script>
        function vue_process() {
            if (type != 3 && type != 4) {
                variant_reset();
            }
        }
        function variant_reset() {
            content = new Vue({
                el: '#fieldcontent',
                data: {
                    list: [],
                    count: 0,
                    form: {
                        columncount: 11,
                        pricetitle: '单价',
                        pointtitle: '积分',
                        showproduct: false,
                        showpoint: false,
                        showvippoint: false,
                        showstaffpoint: false
                    }
                },
                methods: {
                    getdata: function () {
                        var that = this;
                        if (ID <= 0) {
                            change_ziying_status();
                            return;
                        }
                        var options = { visit: 'getmallproductvariants', ProductID: ID };
                        $.ajax({
                            type: 'POST',
                            dataType: 'json',
                            url: '../Handler/MallHandler.ashx',
                            data: options,
                            success: function (data) {
                                if (data.status) {
                                    that.list = data.list;
                                    that.count = that.list.length;
                                } else {
                                    show_message('系统错误', 'error');
                                }
                                change_ziying_status();
                            }
                        });
                    },
                    add_line: function () {
                        var that = this;
                        that.count++;
                        var VariantTitle = '';
                        if (that.list.length > 0) {
                            VariantTitle = that.list[0].VariantTitle;
                        }
                        var item = { ID: 0, VariantName: '', VariantBasicPrice: 0, VariantPrice: 0, VariantPointPrice: 0, VariantPoint: 0, VariantVIPPrice: 0, VariantVIPPoint: 0, Inventory: 0, VariantTitle: VariantTitle, count: that.count };
                        that.list.push(item);
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
                            return;
                        }
                        top.$.messager.confirm('提示', '确认删除?', function (r) {
                            if (r) {
                                var options = { visit: 'removemallproductvariant', ID: item.ID };
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
        .panel-body {
            background: #f0f0f0;
        }

        .image_box {
            min-width: 100px;
            display: inline-block;
            margin: 10px;
            text-align: center;
        }

            .image_box img {
                width: 100px;
            }

        table.info table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info table.field td {
                border: solid 1px #ccc;
                padding: 10px 5px;
                text-align: left;
                width: auto;
            }

                table.info table.field td input[type=text] {
                    max-width: 150px;
                    width: 80%;
                }

            table.info table.field input[type=text] {
                padding: 2px 8px;
                border: solid 1px #ddd;
                border-radius: 5px !important;
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
            <div class="table_title"><span id="tdProductType" runat="server"></span>基本信息</div>
            <table class="info">
                <tr>
                    <td>商品名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdProductName" data-options="required:true" /></td>
                    <td>所属分类</td>
                    <td>
                        <input type="text" class="easyui-combotree" runat="server" id="tdCategoryName" data-options="required:true" /></td>
                </tr>
                <tr>
                    <td>商品简介
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="height: 60px; width: 85%;" runat="server" id="tdProductSummary" /></td>
                </tr>
                <tr>
                    <td>状态</td>
                    <td>
                        <select runat="server" id="tdStatus" class="easyui-combobox" data-options="editable:false">
                            <option value="10">出售中</option>
                            <option value="2">已下架</option>
                        </select>
                    </td>
                    <td>所属标签</td>
                    <td>
                        <input type="text" class="easyui-combobox" runat="server" id="tdTagName" />
                        <asp:HiddenField runat="server" ID="hdTagName" />
                    </td>
                </tr>
                <tr>
                    <td>计量单位</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCountUnit" data-options="required:true" /></td>
                    <td>规格型号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdModelNumber" /></td>
                </tr>
                <tr>
                    <td>福顺优选</td>
                    <td>
                        <select runat="server" id="tdIsYouXuan" class="easyui-combobox" data-options="editable:false">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                    <td>首页显示</td>
                    <td>
                        <select runat="server" id="tdIsShowOnHome" class="easyui-combobox" data-options="editable:false">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>单次购买上限</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdQuantityLimit" /></td>
                    <td>排序序号
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdSortOrder" /></td>
                </tr>
                <tr>
                    <td>推荐商家</td>
                    <td>
                        <select runat="server" id="tdIsSuggestion" class="easyui-combobox" data-options="editable:false">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                    <td>自营商品</td>
                    <td>
                        <select runat="server" id="tdIsZiYing" class="easyui-combobox" data-options="editable:false">
                            <option value="0">否</option>
                            <option value="1">是</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td style="display: none;">运费</td>
                    <td style="display: none;">
                        <input type="text" class="easyui-combobox" id="tdShipRateID" runat="server" /></td>
                    <td>库存</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdTotalCount" data-options="required:true" /></td>
                    <td class="no_ziying">所属商家</td>
                    <td class="no_ziying">
                        <input type="text" class="easyui-combobox" runat="server" id="tdBusinessName" /></td>
                </tr>
                <tr>
                    <td>成本价</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdBasicPrice" /></td>
                </tr>
                <tr class="tr_allowproductbuy">
                    <td>支持普通购买
                    </td>
                    <td colspan="3">
                        <select runat="server" id="tdIsAllowProductBuy" class="easyui-combobox" data-options="editable:false">
                            <option value="1">支持</option>
                            <option value="0">不支持</option>
                        </select>
                        <label style="margin: 0 10px;" class="product_price">
                            单价(元):
                        <input type="text" runat="server" id="tdSalePrice" class="easyui-textbox" />
                        </label>
                        <label class="variant_product_price">请在商品属性处修改价格</label>
                    </td>
                </tr>
                <tr class="tr_allowpointbuy">
                    <td>支持积分购买
                    </td>
                    <td colspan="3">
                        <select runat="server" id="tdIsAllowPointBuy" class="easyui-combobox" data-options="editable:false">
                            <option value="0">不支持</option>
                            <option value="1">支持</option>
                        </select>
                        <label style="margin: 0 10px;" class="point_price">
                            单价(元):
                        <input type="text" runat="server" id="tdVariantPointPrice" class="easyui-textbox" />
                        </label>
                        <label style="margin: 0 10px;" class="point_price">
                            积分(个):
                        <input type="text" runat="server" id="tdVariantPoint" class="easyui-textbox" />
                        </label>
                        <label class="variant_point_price">请在商品属性处修改价格</label>
                    </td>
                </tr>
                <tr class="tr_allowpointbuy">
                    <td>支持合伙人购买
                    </td>
                    <td colspan="3">
                        <select runat="server" id="tdIsAllowVIPBuy" class="easyui-combobox" data-options="editable:false">
                            <option value="0">不支持</option>
                            <option value="1">支持</option>
                        </select>
                        <label style="margin: 0 10px;" class="vip_price">
                            单价(元):
                        <input type="text" runat="server" id="tdVariantVIPPrice" class="easyui-textbox" />
                        </label>
                        <label style="margin: 0 10px;" class="vip_price">
                            积分(个):
                        <input type="text" runat="server" id="tdVariantVIPPoint" class="easyui-textbox" />
                        </label>
                        <label class="variant_vip_price">请在商品属性处修改价格</label>
                    </td>
                </tr>
                <tr class="tr_allowpointbuy">
                    <td>支持岗位积分购买
                    </td>
                    <td colspan="3">
                        <select runat="server" id="tdIsAllowStaffBuy" class="easyui-combobox" data-options="editable:false">
                            <option value="0">不支持</option>
                            <option value="1">支持</option>
                        </select>
                        <label style="margin: 0 10px; display: none;" class="staff_price1">
                            单价(元):
                        <input type="text" runat="server" id="tdVariantStaffPrice" class="easyui-textbox" />
                        </label>
                        <label style="margin: 0 10px;" class="staff_price">
                            积分(个):
                        <input type="text" runat="server" id="tdVariantStaffPoint" class="easyui-textbox" />
                        </label>
                        <label class="variant_staff_price">请在商品属性处修改价格</label>
                    </td>
                </tr>
            </table>
            <div class="table_title">商品图片</div>
            <table class="info">
                <tr>
                    <td colspan="4" class="header_title"></td>
                </tr>
                <tr>
                    <td>封面图片</td>
                    <td colspan="3">
                        <div class="image_box" id="cover_img" style="display: none;">
                        </div>
                        <br />
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择图片',buttonText: '选择图片'" style="width: 60%" />
                    </td>
                </tr>
                <tr id="trExistFiles" style="display: none;">
                </tr>
                <tr>
                    <td>商品相册</td>
                    <td colspan="3" id="tdFile"></td>
                </tr>
            </table>
            <%if (this.type != 3 && this.type != 4)
              { %>
            <div class="table_title">商品属性</div>
            <table class="info">
                <tr>
                    <td colspan="4" style="padding: 0;">
                        <div id="fieldcontent">
                            <table class="field">
                                <tr>
                                    <td v-bind:colspan="form.columncount">
                                        <a href="javascript:void(0)" v-on:click="add_line()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">添加</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>属性类别
                                    </td>
                                    <td>属性名称
                                    </td>
                                    <td>成本价(元)
                                    </td>
                                    <td v-if="form.showproduct">单价(普通购买:元)
                                    </td>
                                    <td v-if="form.showpoint">单价(积分购买:元)
                                    </td>
                                    <td v-if="form.showpoint">积分(积分购买:个)
                                    </td>
                                    <td v-if="form.showvippoint">单价(合伙人购买:元)
                                    </td>
                                    <td v-if="form.showvippoint">积分(合伙人购买:个)
                                    </td>
                                    <%--<td v-if="form.showstaffpoint">单价(岗位积分购买:元)
                                </td>--%>
                                    <td v-if="form.showstaffpoint">积分(岗位积分购买:个)
                                    </td>
                                    <td>库存
                                    </td>
                                    <td></td>
                                </tr>
                                <tr v-for="(item, index) in list">
                                    <td>
                                        <input type="text" v-model="item.VariantTitle" />
                                    </td>
                                    <td>
                                        <input type="text" v-model="item.VariantName" />
                                    </td>
                                    <td>
                                        <input type="text" v-model="item.VariantBasicPrice" />
                                    </td>
                                    <td v-if="form.showproduct">
                                        <input type="text" v-model="item.VariantPrice" />
                                    </td>
                                    <td v-if="form.showpoint">
                                        <input type="text" v-model="item.VariantPointPrice" />
                                    </td>
                                    <td v-if="form.showpoint">
                                        <input type="text" v-model="item.VariantPoint" />
                                    </td>
                                    <td v-if="form.showvippoint">
                                        <input type="text" v-model="item.VariantVIPPrice" />
                                    </td>
                                    <td v-if="form.showvippoint">
                                        <input type="text" v-model="item.VariantVIPPoint" />
                                    </td>
                                    <%--<td v-if="form.showstaffpoint">
                                    <input type="text" v-model="item.VariantStaffPrice" />
                                </td>--%>
                                    <td v-if="form.showstaffpoint">
                                        <input type="text" v-model="item.VariantStaffPoint" />
                                    </td>
                                    <td>
                                        <input type="text" v-model="item.Inventory" />
                                    </td>
                                    <td>
                                        <a href="javascript:void(0)" v-on:click="remove_line(item)" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <%} %>
            <%if (this.type == 3)
              { %>
            <div class="table_title">拼团信息</div>
            <table class="info">
                <tr>
                    <td>拼团价格
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdPinSalePrice" />(元)</td>
                    <td>拼团人数
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdPinPeopleCount" />(人)</td>
                </tr>
                <tr style="display: none;">
                    <td>拼团持续时间
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdActiveTimeRange" />(小时)(注: 从用户发起拼团时间开始计算)
                    </td>
                </tr>
                <tr>
                    <td>活动有效时间
                    </td>
                    <td colspan="3">
                        <input type="text" runat="server" id="tdPinStartTime" class="easyui-datetimebox" />
                        -
                    <input type="text" runat="server" id="tdPinEndTime" class="easyui-datetimebox" />
                        (注: 整体拼团活动的有效时间)
                    </td>
                </tr>
            </table>
            <%} %>
            <%if (this.type == 4)
              { %>
            <div class="table_title">秒杀信息</div>
            <table class="info">
                <tr>
                    <td>秒杀价格
                    </td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdXianShiSalePrice" />(元)</td>
                </tr>
                <tr>
                    <td>有效时间
                    </td>
                    <td colspan="3">
                        <input type="text" runat="server" id="tdXianShiStartTime" class="easyui-datetimebox" />
                        -
                    <input type="text" runat="server" id="tdXianShiEndTime" class="easyui-datetimebox" />
                        (注: 整体秒杀活动的有效时间)
                    </td>
                </tr>
                <%} %>
            </table>
            <div class="table_title">详细说明</div>
            <table class="info">
                <tr>
                    <td colspan="4">
                        <script id="tdDescription" type="text/plain" style="width: 100%; height: 300px;">
                        </script>
                        <asp:HiddenField runat="server" ID="hdDescription" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
