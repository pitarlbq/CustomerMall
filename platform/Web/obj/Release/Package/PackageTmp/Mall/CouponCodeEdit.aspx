<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="CouponCodeEdit.aspx.cs" Inherits="Web.Mall.CouponCodeEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ID, tdIsUseForALLProduct, tdUseType, tdAmountType, hdProducts, tdProducts, tdIsUseForALLService, tdIsUseForProduct, tdIsUseForService, tdServices, hdServices, tdIsUseForWY, tdCouponType, tdIsUseForALLStore, tdIsUseForALLCategory, tdStores, hdStores, tdCategorys, hdProductCategorys, hdIsUseForALLProduct, hdIsUseForALLService, hdIsUseForALLStore, hdIsUseForALLCategory,tdIsAutoShowOnProduct;
        $(function () {
            ID = "<%=this.CouponID%>";
            tdIsUseForALLProduct = $("#<%=this.tdIsUseForALLProduct.ClientID%>");
            tdIsUseForALLService = $("#<%=this.tdIsUseForALLService.ClientID%>");
            tdUseType = $("#<%=this.tdUseType.ClientID%>");
            tdAmountType = $("#<%=this.tdAmountType.ClientID%>");
            hdProducts = $("#<%=this.hdProducts.ClientID%>");
            tdProducts = $("#<%=this.tdProducts.ClientID%>");
            tdServices = $("#<%=this.tdServices.ClientID%>");
            hdServices = $("#<%=this.hdServices.ClientID%>");
            tdIsUseForProduct = $("#<%=this.tdIsUseForProduct.ClientID%>");
            tdIsUseForService = $("#<%=this.tdIsUseForService.ClientID%>");
            tdIsUseForWY = $("#<%=this.tdIsUseForWY.ClientID%>");
            tdCouponType = $("#<%=this.tdCouponType.ClientID%>");
            tdIsUseForALLStore = $("#<%=this.tdIsUseForALLStore.ClientID%>");
            tdIsUseForALLCategory = $("#<%=this.tdIsUseForALLCategory.ClientID%>");
            tdStores = $("#<%=this.tdStores.ClientID%>");
            hdStores = $("#<%=this.hdStores.ClientID%>");
            tdCategorys = $("#<%=this.tdCategorys.ClientID%>");
            hdProductCategorys = $("#<%=this.hdProductCategorys.ClientID%>");
            hdIsUseForALLProduct = $("#<%=this.hdIsUseForALLProduct.ClientID%>");
            hdIsUseForALLService = $("#<%=this.hdIsUseForALLService.ClientID%>");
            hdIsUseForALLStore = $("#<%=this.hdIsUseForALLStore.ClientID%>");
            hdIsUseForALLCategory = $("#<%=this.hdIsUseForALLCategory.ClientID%>");
            tdIsAutoShowOnProduct = $("#<%=this.tdIsAutoShowOnProduct.ClientID%>");
            tdCouponType.combobox({
                onSelect: function () {
                    var CouponType = tdCouponType.combobox('getValue');
                    if (CouponType == '6') {
                        do_change_birthday_status();
                    }
                    choose_status(1);
                }
            })
            tdIsUseForALLProduct.combobox({
                onSelect: function () {
                    choose_status();
                }
            })
            tdIsUseForALLService.combobox({
                onSelect: function () {
                    choose_status();
                }
            })
            tdUseType.combobox({
                onSelect: function () {
                    choose_status();
                }
            })
            tdAmountType.combobox({
                onSelect: function () {
                    choose_status();
                }
            })
            tdIsUseForALLStore.combobox({
                onSelect: function () {
                    choose_status();
                }
            })
            tdIsUseForALLCategory.combobox({
                onSelect: function () {
                    choose_status();
                }
            })
            tdIsUseForWY.bind('click', function () {
                choose_status(1);
            })
            tdIsUseForProduct.bind('click', function () {
                choose_status(1);
            })
            tdIsUseForService.bind('click', function () {
                choose_status(1);
            })
            do_change_birthday_status();
            choose_status(1);
            loadattachs();
        });
        function do_change_birthday_status() {
            var IsUseForALLService = (hdIsUseForALLService.val() == '' ? '1' : hdIsUseForALLService.val());
            var IsUseForALLProduct = (hdIsUseForALLProduct.val() == '' ? '1' : hdIsUseForALLProduct.val());
            var IsUseForALLStore = (hdIsUseForALLStore.val() == '' ? '1' : hdIsUseForALLStore.val());
            var IsUseForALLCategory = (hdIsUseForALLCategory.val() == '' ? '1' : hdIsUseForALLCategory.val());
            tdIsUseForALLService.combobox('setValue', IsUseForALLService);
            tdIsUseForALLProduct.combobox('setValue', IsUseForALLProduct);
            tdIsUseForALLStore.combobox('setValue', IsUseForALLStore);
            tdIsUseForALLCategory.combobox('setValue', IsUseForALLCategory);
            $('.tr_isuseforstore').show();
            $('.tr_isuseforcategory').show();
            if (ID > 0) {
                return;
            }
            tdIsUseForWY.prop('checked', true);
            tdIsUseForProduct.prop('checked', true);
            tdIsUseForService.prop('checked', true);
            $('.tr_isuseforproduct').show();
            $('.tr_isuseforservice').show();
        }
        function choose_status(istype) {
            var CouponType = tdCouponType.combobox('getValue');
            if (istype == 1) {
                var IsUseForALLService = 0;
                var IsUseForALLProduct = 0;
                var IsUseForALLStore = 0;
                var IsUseForALLCategory = 0;
                if (CouponType == '1') {
                    IsUseForALLService = (hdIsUseForALLService.val() == '' ? '0' : hdIsUseForALLService.val());
                    IsUseForALLProduct = (hdIsUseForALLProduct.val() == '' ? '0' : hdIsUseForALLProduct.val());
                    IsUseForALLStore = (hdIsUseForALLStore.val() == '' ? '0' : hdIsUseForALLStore.val());
                    IsUseForALLCategory = (hdIsUseForALLCategory.val() == '' ? '0' : hdIsUseForALLCategory.val());
                    tdIsUseForWY.prop('checked', false);
                    tdIsUseForProduct.prop('checked', true);
                    tdIsUseForService.prop('checked', true);
                    $('.tr_isuseforproduct').show();
                    $('.tr_isuseforservice').show();
                    $('.tr_isuseforstore').hide();
                    $('.tr_isuseforcategory').hide();
                }
                if (CouponType == '2') {
                    IsUseForALLService = (hdIsUseForALLService.val() == '' ? '0' : hdIsUseForALLService.val());
                    IsUseForALLProduct = (hdIsUseForALLProduct.val() == '' ? '0' : hdIsUseForALLProduct.val());
                    IsUseForALLStore = (hdIsUseForALLStore.val() == '' ? '1' : hdIsUseForALLStore.val());
                    IsUseForALLCategory = (hdIsUseForALLCategory.val() == '' ? '0' : hdIsUseForALLCategory.val());
                    tdIsUseForWY.prop('checked', false);
                    tdIsUseForProduct.prop('checked', true);
                    tdIsUseForService.prop('checked', false);
                    $('.tr_isuseforproduct').hide();
                    $('.tr_isuseforservice').hide();
                    $('.tr_isuseforstore').show();
                    $('.tr_isuseforcategory').hide();
                }
                if (CouponType == '3') {
                    IsUseForALLService = (hdIsUseForALLService.val() == '' ? '1' : hdIsUseForALLService.val());
                    IsUseForALLProduct = (hdIsUseForALLProduct.val() == '' ? '1' : hdIsUseForALLProduct.val());
                    IsUseForALLStore = (hdIsUseForALLStore.val() == '' ? '0' : hdIsUseForALLStore.val());
                    IsUseForALLCategory = (hdIsUseForALLCategory.val() == '' ? '0' : hdIsUseForALLCategory.val());
                    tdIsUseForWY.prop('checked', true);
                    tdIsUseForProduct.prop('checked', true);
                    tdIsUseForService.prop('checked', true);
                    $('.tr_isuseforproduct').hide();
                    $('.tr_isuseforservice').hide();
                    $('.tr_isuseforstore').hide();
                    $('.tr_isuseforcategory').hide();
                }
                if (CouponType == '4') {
                    IsUseForALLService = (hdIsUseForALLService.val() == '' ? '0' : hdIsUseForALLService.val());
                    IsUseForALLProduct = (hdIsUseForALLProduct.val() == '' ? '0' : hdIsUseForALLProduct.val());
                    IsUseForALLStore = (hdIsUseForALLStore.val() == '' ? '0' : hdIsUseForALLStore.val());
                    IsUseForALLCategory = (hdIsUseForALLCategory.val() == '' ? '1' : hdIsUseForALLCategory.val());
                    tdIsUseForWY.prop('checked', false);
                    tdIsUseForProduct.prop('checked', true);
                    tdIsUseForService.prop('checked', true);
                    $('.tr_isuseforproduct').hide();
                    $('.tr_isuseforservice').hide();
                    $('.tr_isuseforstore').hide();
                    $('.tr_isuseforcategory').show();
                }
                if (CouponType == '5') {
                    IsUseForALLService = (hdIsUseForALLService.val() == '' ? '0' : hdIsUseForALLService.val());
                    IsUseForALLProduct = (hdIsUseForALLProduct.val() == '' ? '0' : hdIsUseForALLProduct.val());
                    IsUseForALLStore = (hdIsUseForALLStore.val() == '' ? '0' : hdIsUseForALLStore.val());
                    IsUseForALLCategory = (hdIsUseForALLCategory.val() == '' ? '0' : hdIsUseForALLCategory.val());
                    tdIsUseForWY.prop('checked', true);
                    tdIsUseForProduct.prop('checked', false);
                    tdIsUseForService.prop('checked', false);
                    $('.tr_isuseforproduct').hide();
                    $('.tr_isuseforservice').hide();
                    $('.tr_isuseforstore').hide();
                    $('.tr_isuseforcategory').hide();
                }
                if (CouponType != 6) {
                    tdIsUseForALLService.combobox('setValue', IsUseForALLService);
                    tdIsUseForALLProduct.combobox('setValue', IsUseForALLProduct);
                    tdIsUseForALLStore.combobox('setValue', IsUseForALLStore);
                    tdIsUseForALLCategory.combobox('setValue', IsUseForALLCategory);
                }
            }
            var IsUseForALLProduct = tdIsUseForALLProduct.combobox('getValue');
            if (IsUseForALLProduct == '1') {
                $('.choose_product').hide();
            }
            else {
                $('.choose_product').show();
            }
            var IsUseForALLService = tdIsUseForALLService.combobox('getValue');
            if (IsUseForALLService == '1') {
                $('.choose_service').hide();
            }
            else {
                $('.choose_service').show();
            }
            var UseType = tdUseType.combobox('getValue');
            if (UseType == '1') {
                $('.manjian_rule').show();
                $('.discount_rule').hide();
            }
            else {
                $('.manjian_rule').hide();
                $('.discount_rule').show();
            }
            var AmountType = tdAmountType.combobox('getValue');
            if (AmountType == '1') {
                $('#spanAmountType1').text('元');
                $('#spanAmountType2').text('元');
            }
            else {
                $('#spanAmountType1').text('%');
                $('#spanAmountType2').text('%');
            }
            if (tdIsUseForProduct.prop('checked') && CouponType != 2 && CouponType != 3 && CouponType != 4) {
                $('.tr_isuseforproduct').show();
            } else {
                $('.tr_isuseforproduct').hide();
            }
            if (tdIsUseForService.prop('checked') && CouponType != 3 && CouponType != 4) {
                $('.tr_isuseforservice').show();
            } else {
                $('.tr_isuseforservice').hide();
            }
            var UseForALLStore = tdIsUseForALLStore.combobox('getValue');
            if (UseForALLStore == '1') {
                $('.choose_store').hide();
            }
            else {
                $('.choose_store').show();
            }
            var UseForALLCategory = tdIsUseForALLCategory.combobox('getValue');
            if (UseForALLCategory == '1') {
                $('.choose_category').hide();
            }
            else {
                $('.choose_category').show();
            }
        }
        function loadattachs() {
            if (ID <= 0) {
                return;
            }
            var options = { visit: 'getmallcouponcodecover', ID: ID };
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
                    $("#cover_img").hide();
                    if (data.CoverImage != '') {
                        $html += '<a href="' + data.CoverImage + '" target="_blank" ><image src="' + data.CoverImage + '"></a>';
                        $html += '<br/><a href="#" onclick="delete_cover()">删除</a>';
                        $("#cover_img").show();
                    }
                    $("#cover_img").append($html);
                }
            });
        }
        function delete_cover() {
            top.$.messager.confirm("提示", "是否删除选已上传的封面?", function (r) {
                if (r) {
                    var options = { visit: 'deletemallcouponcodecover', ID: ID };
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
            var IsUseForWY = 0;
            if (tdIsUseForWY.prop('checked')) {
                IsUseForWY = 1;
            }
            var IsUseForProduct = 0;
            if (tdIsUseForProduct.prop('checked')) {
                IsUseForProduct = 1;
            }
            var IsUseForService = 0;
            if (tdIsUseForService.prop('checked')) {
                IsUseForService = 1;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/MallHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemallcouponcode';
                    param.ID = ID;
                    param.ProductIDList = hdProducts.val();
                    param.ServiceIDList = hdServices.val();
                    param.BusinessIDList = hdStores.val();
                    param.ProductCategoryIDList = hdProductCategorys.val();
                    param.IsUseForWY = IsUseForWY;
                    param.IsUseForProduct = IsUseForProduct;
                    param.IsUseForService = IsUseForService;
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
        var isupdate = false;
        function chooseproduct() {
            isupdate = false;
            var title = '选择商品';
            var iframe = "../Mall/ChooseProduct.aspx?from=CouponCodeEdit";
            do_open_dialog(title, iframe);
        }
        function chooseservice() {
            isupdate = false;
            var title = '选择服务';
            var iframe = "../Mall/ChooseHouseService.aspx?from=CouponCodeEdit";
            do_open_dialog(title, iframe);
        }
        function choosestore() {
            isupdate = false;
            var title = '选择店铺';
            var iframe = "../Mall/ChooseBusiness.aspx?usetype=1&from=CouponCodeEdit";
            do_open_dialog(title, iframe);
        }
        function choosecategory() {
            isupdate = false;
            var title = '选择分类';
            var iframe = "../Mall/ChooseProductCategory.aspx";
            do_open_dialog(title, iframe);
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

        .image_box {
            min-width: 100px;
            display: inline-block;
            margin: 10px;
            text-align: center;
        }

            .image_box img {
                width: 100px;
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
            <table class="info">
                <tr>
                    <td>卡券名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCouponName" data-options="required:true" /></td>
                    <td>状态</td>
                    <td>
                        <select runat="server" id="tdIsActive" class="easyui-combobox" data-options="editable:false">
                            <option value="1">有效</option>
                            <option value="0">失效</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>卡券类型</td>
                    <td>
                        <select runat="server" id="tdCouponType" class="easyui-combobox" data-options="editable:false">
                            <option value="1">单品券</option>
                            <option value="2">店铺券</option>
                            <option value="3">全场通用劵</option>
                            <option value="4">品类优惠券</option>
                            <option value="5">物业缴费优惠券</option>
                            <option value="6">生日券</option>
                        </select>
                    </td>
                    <td>卡券简介
                    </td>
                    <td>
                        <input type="text" class="easyui-textbox" data-options="multiline:true" style="width: 300px; height: 60px;" runat="server" id="tdSummary" /></td>
                </tr>
                <tr>
                    <td>有效时间
                    </td>
                    <td colspan="3">
                        <input type="text" runat="server" id="tdStartTime" class="easyui-datetimebox" />
                        -
                    <input type="text" runat="server" id="tdEndTime" class="easyui-datetimebox" />
                    </td>
                </tr>
                <tr>
                    <td>展示封面</td>
                    <td colspan="3">
                        <div class="image_box" id="cover_img" style="display: none;">
                        </div>
                        <br />
                        <input class="easyui-filebox" name="attachfile" data-options="prompt:'请选择图片',buttonText: '选择图片'" style="width: 60%" />
                    </td>
                </tr>
                <tr>
                    <td>使用范围
                    </td>
                    <td>
                        <input type="checkbox" runat="server" id="tdIsUseForWY" />物业缴费&nbsp;&nbsp;
                    <input type="checkbox" runat="server" id="tdIsUseForProduct" />购买商品&nbsp;&nbsp;
                    <input type="checkbox" runat="server" id="tdIsUseForService" />购买服务
                    </td>
                    <td>商品显示
                    </td>
                    <td>
                        <select runat="server" id="tdIsAutoShowOnProduct" class="easyui-combobox" data-options="editable:false">
                            <option value="1">显示</option>
                            <option value="0">不显示</option>
                        </select>
                    </td>
                </tr>
                <tr class="tr_isuseforproduct">
                    <td>商品
                    </td>
                    <td>
                        <select runat="server" id="tdIsUseForALLProduct" class="easyui-combobox" data-options="editable:false">
                            <option value="1">所有商品</option>
                            <option value="0">指定商品</option>
                        </select>
                        <asp:HiddenField runat="server" ID="hdIsUseForALLProduct" />
                    </td>
                    <td class="choose_product">
                        <a href="javascript:void(0)" onclick="chooseproduct()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择商品</a></td>
                    <td class="choose_product">
                        <input type="text" class="easyui-textbox" id="tdProducts" runat="server" data-options="multiline:true,readonly:true" style="height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdProducts" />
                    </td>
                </tr>
                <tr class="tr_isuseforservice">
                    <td>服务
                    </td>
                    <td>
                        <select runat="server" id="tdIsUseForALLService" class="easyui-combobox" data-options="editable:false">
                            <option value="1">所有服务</option>
                            <option value="0">指定服务</option>
                        </select>
                        <asp:HiddenField runat="server" ID="hdIsUseForALLService" />
                    </td>
                    <td class="choose_service">
                        <a href="javascript:void(0)" onclick="chooseservice()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择服务</a>
                    </td>
                    <td class="choose_service">
                        <input type="text" class="easyui-textbox" id="tdServices" runat="server" data-options="multiline:true,readonly:true" style="height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdServices" />
                    </td>
                </tr>
                <tr class="tr_isuseforstore">
                    <td>店铺
                    </td>
                    <td>
                        <select runat="server" id="tdIsUseForALLStore" class="easyui-combobox" data-options="editable:false">
                            <option value="1">所有店铺</option>
                            <option value="0">指定店铺</option>
                        </select>
                        <asp:HiddenField runat="server" ID="hdIsUseForALLStore" />
                    </td>
                    <td class="choose_store"><a href="javascript:void(0)" onclick="choosestore()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择店铺</a></td>
                    <td class="choose_store">
                        <input type="text" class="easyui-textbox" id="tdStores" runat="server" data-options="multiline:true,readonly:true" style="height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdStores" />
                    </td>
                </tr>
                <tr class="tr_isuseforcategory">
                    <td>类别
                    </td>
                    <td>
                        <select runat="server" id="tdIsUseForALLCategory" class="easyui-combobox" data-options="editable:false">
                            <option value="1">所有类别</option>
                            <option value="0">指定类别</option>
                        </select>
                        <asp:HiddenField runat="server" ID="hdIsUseForALLCategory" />
                    </td>
                    <td class="choose_category"><a href="javascript:void(0)" onclick="choosecategory()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-choose'">选择类别</a></td>
                    <td class="choose_category">
                        <input type="text" class="easyui-textbox" id="tdCategorys" runat="server" data-options="multiline:true,readonly:true" style="height: 50px;" />
                        <asp:HiddenField runat="server" ID="hdProductCategorys" />
                    </td>
                </tr>
                <tr>
                    <td>卡券规则
                    </td>
                    <td>
                        <select runat="server" id="tdUseType" class="easyui-combobox" data-options="editable:false">
                            <option value="1">满减</option>
                            <option value="2">折扣</option>
                        </select></td>
                    <td>金额类型
                    </td>
                    <td>
                        <select runat="server" id="tdAmountType" class="easyui-combobox" data-options="editable:false">
                            <option value="1">固定金额</option>
                            <option value="2">百分比</option>
                        </select></td>
                </tr>
                <tr>
                    <td>使用规则
                    </td>
                    <td colspan="3">
                        <label class="manjian_rule">
                            满
                        <input type="text" runat="server" id="tdUseNeedAmount" class="easyui-textbox" />
                            减
                        <input type="text" runat="server" id="tdReduceAmount1" class="easyui-textbox" />(<span id="spanAmountType1"></span>)
                        </label>
                        <label class="discount_rule">
                            折扣
                        <input type="text" runat="server" id="tdReduceAmount2" class="easyui-textbox" />(<span id="spanAmountType2"></span>)
                        </label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
