<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRoomResource_Basic.aspx.cs" Inherits="Web.RoomResource.EditRoomResource_Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/Page/Comm/GetTypeList.js?v=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        var RoomTypeList = [];
        var RoomLayoutList = [];
        var RoomPropertyList = [];
        var RoomID, tdRemark, hdRemark;
        $(function () {
            tdRemark = $('#<%=this.tdRemark.ClientID%>');
            hdRemark = $('#<%=this.hdRemark.ClientID%>');
            tdRemark.textbox('setValue', hdRemark.val());
            RoomID = "<%=Request.QueryString["RoomID"]%>";
            getRoomLayoutList();
            var options = { visit: 'getroombasicparams' };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/RoomResourceHandler.ashx',
                data: options,
                success: function (result) {
                    if (result.status) {
                        $("#<%=this.tbRoomState.ClientID%>").combobox({
                            data: result.roomstate_list,
                            valueField: 'ID',
                            textField: 'Name'
                        });
                        $("#<%=this.tbRoomType.ClientID%>").combobox({
                            data: result.roomtype_list,
                            valueField: 'ID',
                            textField: 'Name'
                        });
                        $("#<%=this.tbRoomProperty.ClientID%>").combobox({
                            data: result.roomproperty_list,
                            valueField: 'ID',
                            textField: 'Name'
                        });
                    }
                }
            });
            $("#<%=this.tdRoomLayout.ClientID%>").combobox({
                data: RoomLayoutList,
                valueField: 'ID',
                textField: 'Name'
            });
            getFieldContent();
        })
        function getRoomLayoutList() {
            RoomLayoutList.push({ ID: "一居", Name: "一居" });
            RoomLayoutList.push({ ID: "二居", Name: "二居" });
            RoomLayoutList.push({ ID: "三居", Name: "三居" });
            RoomLayoutList.push({ ID: "四居", Name: "四居" });
        }
        function do_save() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var RoomName = $("#<%=this.tbRoomName.ClientID%>").textbox("getValue");
            var RoomStateID = $("#<%=this.tbRoomState.ClientID%>").combobox("getValue");
            var RoomState = $("#<%=this.tbRoomState.ClientID%>").combobox("getText");
            var BuildingArea = $("#<%=this.tdBuildingArea.ClientID%>").textbox("getValue");
            var ContractArea = $("#<%=this.tdContractArea.ClientID%>").textbox("getValue");
            var PaymentTime = $("#<%=this.tbPaymentTime.ClientID%>").datebox("getValue");
            var MoveInTime = $("#<%=this.tdMoveInTime.ClientID%>").datebox("getValue");
            var ZxStartTime = $("#<%=this.tdZxStartTime.ClientID%>").datebox("getValue");
            var ZxEndTime = $("#<%=this.tdZxEndTime.ClientID%>").datebox("getValue");
            var RoomTypeID = $("#<%=this.tbRoomType.ClientID%>").combobox("getValue");
            var RoomType = $("#<%=this.tbRoomType.ClientID%>").combobox("getText");
            var BuildingNumber = $("#<%=this.tbBuildingNumber.ClientID%>").textbox("getValue");
            var BuildOutArea = $("#<%=this.tdBuildOutArea.ClientID%>").textbox("getValue");
            var BuildInArea = $("#<%=this.tdBuildInArea.ClientID%>").textbox("getValue");
            var GonTanArea = $("#<%=this.tdGonTanArea.ClientID%>").textbox("getValue");
            var ChanQuanArea = $("#<%=this.tdChanQuanArea.ClientID%>").textbox("getValue");
            var UseArea = $("#<%=this.tdUseArea.ClientID%>").textbox("getValue");
            var PeiTaoArea = $("#<%=this.tdPeiTaoArea.ClientID%>").textbox("getValue");
            var FunctionCoefficient = $("#<%=this.tdFunctionCoefficient.ClientID%>").textbox("getValue");
            var FenTanCoefficient = $("#<%=this.tdFenTanCoefficient.ClientID%>").textbox("getValue");
            var ChanQuanNo = $("#<%=this.tdChanQuanNo.ClientID%>").textbox("getValue");
            var CertificateTime = $("#<%=this.tdCertificateTime.ClientID%>").datebox("getValue");
            var RoomLayout = $("#<%=this.tdRoomLayout.ClientID%>").combobox("getValue");
            var RoomPropertyID = $("#<%=this.tbRoomProperty.ClientID%>").combobox("getValue");
            var RoomProperty = $("#<%=this.tbRoomProperty.ClientID%>").combobox("getText");
            var CustomOne = $("#<%=this.tdCustomOne.ClientID%>").textbox("getValue");
            var CustomTwo = $("#<%=this.tdCustomTwo.ClientID%>").textbox("getValue");
            var CustomThree = $("#<%=this.tdCustomThree.ClientID%>").textbox("getValue");
            var CustomFour = $("#<%=this.tdCustomFour.ClientID%>").textbox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var IsLocked = $("#<%=this.tdIsLocked.ClientID%>").combobox("getValue");
            var SortOrder = $("#<%=this.tdSortOrder.ClientID%>").textbox("getValue");
            var FieldList = [];
            //自定义属性
            $('.define').each(function () {
                var FieldID = $(this).attr('data-id');
                var data_value = $(this).textbox('getValue');
                FieldList.push({ id: FieldID, value: data_value });
            })
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'saveroomresource', RoomID: RoomID, RoomName: RoomName, BuildingArea: BuildingArea, PaymentTime: PaymentTime, RoomState: RoomState, BuildingNumber: BuildingNumber, RoomType: RoomType, RoomLayout: RoomLayout, RoomProperty: RoomProperty, ContractArea: ContractArea, MoveInTime: MoveInTime, ZxStartTime: ZxStartTime, ZxEndTime: ZxEndTime, BuildOutArea: BuildOutArea, BuildInArea: BuildInArea, GonTanArea: GonTanArea, ChanQuanArea: ChanQuanArea, UseArea: UseArea, PeiTaoArea: PeiTaoArea, FunctionCoefficient: FunctionCoefficient, FenTanCoefficient: FenTanCoefficient, ChanQuanNo: ChanQuanNo, CertificateTime: CertificateTime, CustomOne: CustomOne, CustomTwo: CustomTwo, CustomThree: CustomThree, CustomFour: CustomFour, Remark: Remark, IsLocked: IsLocked, FieldList: JSON.stringify(FieldList), RoomStateID: RoomStateID, RoomTypeID: RoomTypeID, RoomPropertyID: RoomPropertyID, SortOrder: SortOrder };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/RoomResourceHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        parent.isUpdate = true;
                        show_message("修改成功", "success");
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function do_close() {
            parent.parent.do_close_dialog(function () {
                parent.parent.$("#tt_table").datagrid("reload");
            });
        }
        function getFieldContent() {
            MaskUtil.mask('body', '加载中');
            var options = { visit: 'getdefinecontent', TableName: "RoomBasic", RoomID: RoomID };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/SysSettingHandler.ashx',
                data: options,
                success: function (message) {
                    MaskUtil.unmask();
                    if (message.status) {
                        var html = '';
                        var count = 0;
                        var html = '';
                        $.each(message.list, function (index, item) {
                            if (index % 2 == 0) {
                                html += '<tr>';
                                html += '<td>';
                                html += item.FieldName;
                                html += '</td>';
                                html += '<td>';
                                html += '<input data-id="' + item.ID + '" class="easyui-textbox define" type="text" data-value="' + item.FieldContent + '" />';
                                html += '</td>';
                                count = 2;
                            }
                            else if (index % 2 == 1) {
                                html += '<td>';
                                html += item.FieldName;
                                html += '</td>';
                                html += '<td>';
                                html += '<input data-id="' + item.ID + '" class="easyui-textbox define" type="text" data-value="' + item.FieldContent + '" />';
                                html += '</td>';
                                html += '</tr>';
                                count = 4;
                            }
                            if ((index == message.list.length - 1) && count == 2) {
                                html += '<td>';
                                html += '</td>';
                                html += '<td>';
                                html += '</td>';
                                html += '</tr>';
                                count = 0;
                            }
                        })
                        $(html).appendTo("#definefield");
                        $.parser.parse('#definefield');
                        $('.define').each(function () {
                            var data_value = $(this).attr('data-value');
                            $(this).textbox('setValue', data_value);
                        })
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
    </script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="do_save()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
        </div>
        <div class="table_container">
            <div class="table_title">
                资源信息
            </div>
            <table class="info">
                <tr>
                    <td>资源编号
                    </td>
                    <td>
                        <input id="tbRoomName" class="easyui-textbox" runat="server" type="text" data-options="required:true" />
                    </td>
                    <td>房间状态
                    </td>
                    <td>
                        <input class="easyui-combobox" id="tbRoomState" runat="server" />
                        <asp:HiddenField runat="server" ID="hdRoomState" />
                    </td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName,"BuildingArea") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdBuildingArea" runat="server" />
                    </td>
                    <td><%=base.GetExistColumns(this.TableName,"ContractArea") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdContractArea" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName,"BuildOutArea") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdBuildOutArea" runat="server" />
                    </td>
                    <td>排序序号</td>
                    <td>
                        <input class="easyui-textbox" id="tdSortOrder" runat="server" />
                    </td>
                </tr>
            </table>
            <div class="table_title">
                辅助信息
            </div>
            <table class="info">
                <tr>
                    <td>房间类型
                    </td>
                    <td>
                        <input class="easyui-combobox" data-options="editable:false" id="tbRoomType" runat="server" />
                        <asp:HiddenField runat="server" ID="hdRoomType" />
                    </td>
                    <td>房源属性
                    </td>
                    <td>
                        <input class="easyui-combobox" data-options="editable:false" id="tbRoomProperty" runat="server" />
                        <asp:HiddenField runat="server" ID="hdRoomProperty" />
                    </td>
                </tr>
                <tr>
                    <td>功能系数
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdFunctionCoefficient" runat="server" />
                    </td>
                    <td>分摊系数
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdFenTanCoefficient" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>是否激活
                    </td>
                    <td>
                        <select class="easyui-combobox" id="tdIsLocked" runat="server">
                            <option value="0">是</option>
                            <option value="1">否</option>
                        </select>
                    </td>
                    <td>户型
                    </td>
                    <td>
                        <input class="easyui-combobox" data-options="editable:false" id="tdRoomLayout" runat="server" />
                        <asp:HiddenField runat="server" ID="hdRoomLayout" />
                    </td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName,"BuildInArea") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdBuildInArea" runat="server" />
                    </td>
                    <td><%=base.GetExistColumns(this.TableName,"GonTanArea") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdGonTanArea" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName,"ChanQuanArea") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdChanQuanArea" runat="server" />
                    </td>

                    <td><%=base.GetExistColumns(this.TableName,"UseArea") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdUseArea" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName,"PeiTaoArea") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdPeiTaoArea" runat="server" />
                    </td>
                    <td>期数
                    </td>
                    <td>
                        <input id="tbBuildingNumber" class="easyui-textbox" runat="server" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>产权证号
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdChanQuanNo" runat="server" />
                    </td>
                    <td>发证日期
                    </td>
                    <td>
                        <input class="easyui-datebox" id="tdCertificateTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>交房日期
                    </td>
                    <td>
                        <input class="easyui-datebox" id="tbPaymentTime" runat="server" />
                    </td>
                    <td>入住日期
                    </td>
                    <td>
                        <input class="easyui-datebox" id="tdMoveInTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>装修开始日期
                    </td>
                    <td>
                        <input class="easyui-datebox" id="tdZxStartTime" runat="server" />
                    </td>
                    <td>装修验收日期
                    </td>
                    <td>
                        <input class="easyui-datebox" id="tdZxEndTime" runat="server" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td>自定义一
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdCustomOne" runat="server" />
                    </td>
                    <td>自定义二
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdCustomTwo" runat="server" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td>自定义三
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdCustomThree" runat="server" />
                    </td>
                    <td>自定义四
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdCustomFour" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" data-options="multiline:true" id="tdRemark" style="width: 80%; height: 60px;" runat="server" />
                        <asp:HiddenField runat="server" ID="hdRemark" />
                    </td>
                </tr>
            </table>
            <div class="table_title">
                自定义信息
            </div>
            <table class="info lasttable" id="definefield">
            </table>
        </div>
    </form>
</asp:Content>
