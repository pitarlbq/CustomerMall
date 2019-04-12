<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent6.Master" AutoEventWireup="true" CodeBehind="PrintFormatMgr.aspx.cs" Inherits="Web.SysSeting.PrintFormatMgr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var ProjectID;
        $(function () {
            $('#<%=this.tdDefinePrintSizeYes.ClientID%>').bind('click', function () {
                checksizestatus();
            })
            $('#<%=this.tdDefinePrintSizeNo.ClientID%>').bind('click', function () {
                checksizestatus();
            })
        })
        function pageLoad(ID) {
            ProjectID = ID;
            if (ProjectID == 1) {
                return;
            }
            MaskUtil.mask();
            var options = { visit: 'getprojectprintinfo', ProjectID: ProjectID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/ProjectHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        var data = message.item;
                        $("#<%=this.tdPrintNote.ClientID%>").textbox("setValue", data.PrintNote);
                        $("#<%=this.tdCuiFeiNote.ClientID%>").textbox("setValue", data.CuiFeiNote);
                        $("#<%=this.tdPrintCancelNote.ClientID%>").textbox("setValue", data.PrintCancelNote);
                        $("#<%=this.tdPrintTitle.ClientID%>").textbox("setValue", data.PrintTitle);
                        $("#<%=this.tdPrintFont.ClientID%>").textbox("setValue", data.PrintFont);
                        $("#<%=this.tdPrintSubTitle.ClientID%>").textbox("setValue", data.PrintSubTitle);
                        $("#<%=this.tdPayPrintTitle.ClientID%>").textbox("setValue", data.PayPrintTitle);
                        $("#<%=this.tdPayPrintSubTitle.ClientID%>").textbox("setValue", data.PayPrintSubTitle);
                        $("#<%=this.tdPrintWidth.ClientID%>").textbox("setValue", data.PrintWidth);
                        $("#<%=this.tdPrintHeight.ClientID%>").textbox("setValue", data.PrintHeight);
                        $("#<%=this.tdCuiShouPrintTitle.ClientID%>").textbox("setValue", data.CuiShouPrintTitle);
                        $("#<%=this.tdCuiShouPrintSubTitle.ClientID%>").textbox("setValue", data.CuiShouPrintSubTitle);
                        $("#<%=this.tdPrintType.ClientID%>").combobox("setValue", data.PrintType);

                        $("#<%=this.tdPrintNoteNo.ClientID%>").prop("checked", !data.IsPrintNote);
                        $("#<%=this.tdPrintNoteYes.ClientID%>").prop("checked", data.IsPrintNote);

                        $("#<%=this.tdPrintCountNo.ClientID%>").prop("checked", !data.IsPrintCount);
                        $("#<%=this.tdPrintCountYes.ClientID%>").prop("checked", data.IsPrintCount);

                        $("#<%=this.tdPrintCostNo.ClientID%>").prop("checked", !data.IsPrintCost);
                        $("#<%=this.tdPrintCostYes.ClientID%>").prop("checked", data.IsPrintCost);

                        $("#<%=this.tdPrintDiscountNo.ClientID%>").prop("checked", !data.IsPrintDiscount);
                        $("#<%=this.tdPrintDiscountYes.ClientID%>").prop("checked", data.IsPrintDiscount);

                        $("#<%=this.tdPrintRoomNoNo.ClientID%>").prop("checked", !data.IsPrintRoomNo);
                        $("#<%=this.tdPrintRoomNoYes.ClientID%>").prop("checked", data.IsPrintRoomNo);

                        $("#<%=this.tdPrintTotalRealCostNo.ClientID%>").prop("checked", !data.IsPrintTotalRealCost);
                        $("#<%=this.tdPrintTotalRealCostYes.ClientID%>").prop("checked", data.IsPrintTotalRealCost);

                        $("#<%=this.tdPrintRealCostNo.ClientID%>").prop("checked", !data.IsPrintRealCost);
                        $("#<%=this.tdPrintRealCostYes.ClientID%>").prop("checked", data.IsPrintRealCost);

                        $("#<%=this.tdDefinePrintSizeNo.ClientID%>").prop("checked", !data.IsDefinePrintSize);
                        $("#<%=this.tdDefinePrintSizeYes.ClientID%>").prop("checked", data.IsDefinePrintSize);

                        $("#<%=this.tdPrintMonthCountNo.ClientID%>").prop("checked", !data.IsPrintMonthCount);
                        $("#<%=this.tdPrintMonthCountYes.ClientID%>").prop("checked", data.IsPrintMonthCount);

                        $("#<%=this.tdPrintUnitPriceNo.ClientID%>").prop("checked", !data.IsPrintUnitPrice);
                        $("#<%=this.tdPrintUnitPriceYes.ClientID%>").prop("checked", data.IsPrintUnitPrice);

                        $("#<%=this.tdPrintTopMargin.ClientID%>").textbox("setValue", data.PrintTopMargin);
                        $("#<%=this.tdPrintBottomMargin.ClientID%>").textbox("setValue", data.PrintBottomMargin);
                        $("#<%=this.tdPrintTotalLines.ClientID%>").textbox("setValue", data.PrintTotalLines);
                        $("#<%=this.tdLogoWidth.ClientID%>").textbox("setValue", data.LogoWidth);
                        $("#<%=this.tdLogoHeight.ClientID%>").textbox("setValue", data.LogoHeight);
                        $("#<%=this.tdPrintChargeTypeCount.ClientID%>").combobox("setValue", data.PrintChargeTypeCount);
                        
                        if (data.LogoPath != '') {
                            $('#labelLogo').show();
                            $('#myLogoPath').attr('src', data.LogoPath);
                        }
                        else {
                            $('#labelLogo').hide();
                        }
                        checksizestatus();
                    }
                }
            });
        }
        function checksizestatus() {
            if ($("#<%=this.tdDefinePrintSizeYes.ClientID%>").prop("checked")) {
                $('.fixed_model').hide();
                $('#define_size').show();
            }
            if ($("#<%=this.tdDefinePrintSizeNo.ClientID%>").prop("checked")) {
                $('.fixed_model').show();
                $('#define_size').hide();
            }
        }
        function removeLogo() {
            top.$.messager.confirm("提示", "是否删除Logo?", function (r) {
                if (r) {
                    var options = { visit: 'removeprojectlogo', ProjectID: ProjectID };
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        url: '../Handler/ProjectHandler.ashx',
                        data: options,
                        success: function (message) {
                            if (message.status) {
                                pageLoad(ProjectID)
                                return;
                            }
                            show_message('系统错误', 'error');
                        }
                    });
                }
            })
        }
        function do_save() {
            if (ProjectID <= 1) {
                show_message('请选择项目', 'info');
                return;
            }
            var PrintNote = $("#<%=this.tdPrintNote.ClientID%>").textbox("getValue");
            var CuiFeiNote = $("#<%=this.tdCuiFeiNote.ClientID%>").textbox("getValue");
            var PrintCancelNote = $("#<%=this.tdPrintCancelNote.ClientID%>").textbox("getValue");
            var PrintTitle = $("#<%=this.tdPrintTitle.ClientID%>").textbox("getValue");
            var PrintFont = $("#<%=this.tdPrintFont.ClientID%>").textbox("getValue");
            var PrintSubTitle = $("#<%=this.tdPrintSubTitle.ClientID%>").textbox("getValue");
            var PayPrintTitle = $("#<%=this.tdPayPrintTitle.ClientID%>").textbox("getValue");
            var PayPrintSubTitle = $("#<%=this.tdPayPrintSubTitle.ClientID%>").textbox("getValue");
            var PrintWidth = $("#<%=this.tdPrintWidth.ClientID%>").textbox("getValue");
            var PrintHeight = $("#<%=this.tdPrintHeight.ClientID%>").textbox("getValue");
            var CuiShouPrintTitle = $("#<%=this.tdCuiShouPrintTitle.ClientID%>").textbox("getValue");
            var CuiShouPrintSubTitle = $("#<%=this.tdCuiShouPrintSubTitle.ClientID%>").textbox("getValue");
            var PrintType = $("#<%=this.tdPrintType.ClientID%>").combobox("getValue");
            var IsPrintNote = 1;
            if ($("#<%=this.tdPrintNoteNo.ClientID%>").prop("checked")) {
                IsPrintNote = 0;
            }
            var IsPrintCount = 1;
            if ($("#<%=this.tdPrintCountNo.ClientID%>").prop("checked")) {
                IsPrintCount = 0;
            }
            var IsPrintCost = 1;
            if ($("#<%=this.tdPrintCostNo.ClientID%>").prop("checked")) {
                IsPrintCost = 0;
            }
            var IsPrintDiscount = 1;
            if ($("#<%=this.tdPrintDiscountNo.ClientID%>").prop("checked")) {
                IsPrintDiscount = 0;
            }
            var IsPrintRoomNo = 1;
            if ($("#<%=this.tdPrintRoomNoNo.ClientID%>").prop("checked")) {
                IsPrintRoomNo = 0;
            }
            var IsPrintTotalRealCost = 1;
            if ($("#<%=this.tdPrintTotalRealCostNo.ClientID%>").prop("checked")) {
                IsPrintTotalRealCost = 0;
            }
            var IsPrintRealCost = 1;
            if ($("#<%=this.tdPrintRealCostNo.ClientID%>").prop("checked")) {
                IsPrintRealCost = 0;
            }
            var IsPrintMonthCount = 1;
            if ($("#<%=this.tdPrintMonthCountNo.ClientID%>").prop("checked")) {
                IsPrintMonthCount = 0;
            }
            var IsDefinePrintSize = 1;
            if ($("#<%=this.tdDefinePrintSizeNo.ClientID%>").prop("checked")) {
                IsDefinePrintSize = 0;
            }
            var IsPrintUnitPrice = 1;
            if ($("#<%=this.tdPrintUnitPriceNo.ClientID%>").prop("checked")) {
                IsPrintUnitPrice = 0;
            }
            var PrintTopMargin = $("#<%=this.tdPrintTopMargin.ClientID%>").textbox("getValue");
            var PrintBottomMargin = $("#<%=this.tdPrintBottomMargin.ClientID%>").textbox("getValue");
            var PrintTotalLines = $("#<%=this.tdPrintTotalLines.ClientID%>").textbox("getValue");
            var LogoWidth = $("#<%=this.tdLogoWidth.ClientID%>").textbox("getValue");
            var LogoHeight = $("#<%=this.tdLogoHeight.ClientID%>").textbox("getValue");
            var PrintChargeTypeCount = $("#<%=this.tdPrintChargeTypeCount.ClientID%>").combobox("getValue");

            var isValid = $("#<%=this.ff.ClientID%>").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/ProjectHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'saveprojectprintinfo';
                    param.ProjectID = ProjectID;
                    param.PrintNote = PrintNote;
                    param.CuiFeiNote = CuiFeiNote;
                    param.PrintCancelNote = PrintCancelNote;
                    param.PrintTitle = PrintTitle;
                    param.PrintFont = PrintFont;
                    param.IsPrintNote = IsPrintNote;
                    param.IsPrintCount = IsPrintCount;
                    param.PrintWidth = PrintWidth;
                    param.PrintHeight = PrintHeight;
                    param.PrintSubTitle = PrintSubTitle;
                    param.IsPrintCost = IsPrintCost;
                    param.IsPrintDiscount = IsPrintDiscount;
                    param.CuiShouPrintTitle = CuiShouPrintTitle;
                    param.CuiShouPrintSubTitle = CuiShouPrintSubTitle;
                    param.IsPrintRoomNo = IsPrintRoomNo;
                    param.IsPrintTotalRealCost = IsPrintTotalRealCost;
                    param.IsPrintRealCost = IsPrintRealCost;
                    param.PrintType = PrintType;
                    param.IsDefinePrintSize = IsDefinePrintSize;
                    param.PrintTopMargin = PrintTopMargin;
                    param.PrintBottomMargin = PrintBottomMargin;
                    param.PrintTotalLines = PrintTotalLines;
                    param.IsPrintMonthCount = IsPrintMonthCount;
                    param.PayPrintTitle = PayPrintTitle;
                    param.LogoWidth = LogoWidth;
                    param.LogoHeight = LogoHeight;
                    param.IsPrintUnitPrice = IsPrintUnitPrice;
                    param.PrintChargeTypeCount = PrintChargeTypeCount;
                },
                success: function (message) {
                    MaskUtil.unmask();
                    var data = eval('(' + message + ')');
                    if (data.status) {
                        show_message("保存成功", "success", function () {
                            pageLoad(ProjectID)
                        });
                        return;
                    }
                    show_message("保存失败", "error");
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server" id="ff" method="post" enctype="multipart/form-data">
        <div class="easyui-layout" data-options="fit:true,border:false">
            <div data-options="region:'north',border:false" style="height: 30px; font-size: 12px; padding: 0px;">
                <div class="operation_box">
                    <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                </div>
            </div>
            <div data-options="region:'center',border:false">
                <div style="margin-top: 15px;">
                    <table class="info">
                        <tr>
                            <td class="first">收款单名称</td>
                            <td class="second">
                                <input id="tdPrintTitle" runat="server" class="easyui-textbox" type="text" name="PrintTitle" />
                            </td>
                            <td class="first">收款单副标题</td>
                            <td class="second">
                                <input id="tdPrintSubTitle" runat="server" class="easyui-textbox" type="text" name="PrintSubTitle" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">通知单名称</td>
                            <td class="second">
                                <input id="tdCuiShouPrintTitle" runat="server" class="easyui-textbox" type="text" name="CuiShouPrintTitle" />
                            </td>
                            <td class="first">通知单副标题</td>
                            <td class="second">
                                <input id="tdCuiShouPrintSubTitle" runat="server" class="easyui-textbox" type="text" name="CuiShouPrintSubTitle" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">付款单名称</td>
                            <td class="second">
                                <input id="tdPayPrintTitle" runat="server" class="easyui-textbox" type="text" name="PayPrintTitle" />
                            </td>
                            <td class="first">付款单副标题</td>
                            <td class="second">
                                <input id="tdPayPrintSubTitle" runat="server" class="easyui-textbox" type="text" name="PayPrintSubTitle" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">添加Logo</td>
                            <td class="second" colspan="3" style="width: 75%">
                                <label id="labelLogo" style="display: none;">
                                    <img id="myLogoPath" src="" style="width: 100px; height: 100px;" /><br />
                                    <a href="javascript:void(0)" onclick="removeLogo()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                                </label>
                                <br />
                                <input id="tdLogoPath" runat="server" class="easyui-filebox" type="text" name="LogoPath" style="width: 70%;" data-options="prompt:'请选择文件',buttonText: '选择文件'" /></td>
                        </tr>
                        <tr>
                            <td class="first">Logo宽度</td>
                            <td class="second">
                                <input id="tdLogoWidth" runat="server" class="easyui-textbox" type="text" name="LogoWidth" />
                            </td>
                            <td class="first">Logo高度</td>
                            <td class="second">
                                <input id="tdLogoHeight" runat="server" class="easyui-textbox" type="text" name="LogoHeight" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">是否打印应收</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintCostYes" GroupName="IsPrintCost" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintCostNo" GroupName="IsPrintCost" Text="否" />
                            </td>
                            <td class="first">是否打印减免</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintDiscountYes" GroupName="IsPrintDiscount" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintDiscountNo" GroupName="IsPrintDiscount" Text="否" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">是否打印备注</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintNoteYes" GroupName="IsPrintNote" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintNoteNo" GroupName="IsPrintNote" Text="否" />
                            </td>
                            <td class="first">是否打印读数</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintCountYes" GroupName="IsPrintCount" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintCountNo" GroupName="IsPrintCount" Text="否" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">是否打印资源编号</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintRoomNoYes" GroupName="IsPrintRoomNo" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintRoomNoNo" GroupName="IsPrintRoomNo" Text="否" />
                            </td>
                            <td class="first">单据字体</td>
                            <td class="second">
                                <input id="tdPrintFont" runat="server" class="easyui-textbox" type="text" name="PrintFont" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">自定义尺寸</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdDefinePrintSizeYes" GroupName="IsDefinePrintSize" Text="是" />
                                <asp:RadioButton runat="server" ID="tdDefinePrintSizeNo" GroupName="IsDefinePrintSize" Text="否" />
                            </td>
                            <td class="first fixed_model">纸张规格</td>
                            <td class="second fixed_model">
                                <select id="tdPrintType" runat="server" class="easyui-combobox" type="text" name="PrintType" data-options="editable:false">
                                    <option value="A4Three">A4三等分</option>
                                    <option value="A4Two">A4二等分</option>
                                </select>
                            </td>
                        </tr>
                        <tr style="display: none;" id="define_size">
                            <td class="first">单据宽度</td>
                            <td class="second">
                                <input id="tdPrintWidth" runat="server" class="easyui-textbox" type="text" name="PrintWidth" />(mm)
                            </td>
                            <td class="first">单据高度</td>
                            <td class="second">
                                <input id="tdPrintHeight" runat="server" class="easyui-textbox" type="text" name="PrintHeight" />(mm)
                            </td>
                        </tr>
                        <tr>
                            <td class="first">是否打印已收</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintTotalRealCostYes" GroupName="IsPrintTotalRealCost" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintTotalRealCostNo" GroupName="IsPrintTotalRealCost" Text="否" />
                            </td>
                            <td class="first">是否打印实收</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintRealCostYes" GroupName="IsPrintRealCost" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintRealCostNo" GroupName="IsPrintRealCost" Text="否" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">是否打印月数</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintMonthCountYes" GroupName="IsPrintMonthCount" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintMonthCountNo" GroupName="IsPrintMonthCount" Text="否" />
                            </td>
                            <td class="first">是否打印单价</td>
                            <td class="second">
                                <asp:RadioButton runat="server" ID="tdPrintUnitPriceYes" GroupName="IsPrintUnitPrice" Text="是" />
                                <asp:RadioButton runat="server" ID="tdPrintUnitPriceNo" GroupName="IsPrintUnitPrice" Text="否" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">打印下移</td>
                            <td class="second">
                                <input id="tdPrintBottomMargin" runat="server" class="easyui-textbox" type="text" name="PrintBottomMargin" />(mm)
                            </td>
                            <td class="first">打印上移</td>
                            <td class="second">
                                <input id="tdPrintTopMargin" runat="server" class="easyui-textbox" type="text" name="PrintTopMargin" />(mm)
                            </td>
                        </tr>
                        <tr>
                            <td class="first">单据行数</td>
                            <td class="second">
                                <input id="tdPrintTotalLines" runat="server" class="easyui-textbox" type="text" name="PrintTotalLines" />(行)
                            </td>
                            <td class="first">收款方式</td>
                            <td class="second">
                                <select id="tdPrintChargeTypeCount" runat="server" class="easyui-combobox" type="text" data-options="editable:false">
                                    <option value="2">显示2个</option>
                                    <option value="1">显示1个</option>
                                </select>
                            </td>
                        </tr>
                        <tr>
                            <td class="first">收费打印说明</td>
                            <td class="second" colspan="3" style="width: 75%">
                                <input id="tdPrintNote" runat="server" data-options="multiline:true" class="easyui-textbox" type="text" name="name" style="width: 70%; height: 60px;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">催收打印说明</td>
                            <td class="second" colspan="3" style="width: 75%">
                                <input id="tdCuiFeiNote" runat="server" data-options="multiline:true" class="easyui-textbox" type="text" name="name" style="width: 70%; height: 60px;" />
                            </td>
                        </tr>
                        <tr>
                            <td class="first">退款打印说明</td>
                            <td class="second" colspan="3" style="width: 75%">
                                <input id="tdPrintCancelNote" runat="server" data-options="multiline:true" class="easyui-textbox" type="text" name="name" style="width: 70%; height: 60px;" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
