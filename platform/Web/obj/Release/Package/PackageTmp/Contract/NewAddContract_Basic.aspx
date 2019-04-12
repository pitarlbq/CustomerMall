<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="NewAddContract_Basic.aspx.cs" Inherits="Web.Contract.NewAddContract_Basic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>合同登记</title>
    <script>
        var ffObj, guid, ContractID, TopContractID, RentStartTimeObj, RentEndTimeObj, tdTimeLimit, tdFreeDays, tdRentToTime, tdContractDeposit, canAdd = 0, canEdit = 0, canSaveLog = 0, canPrint = 0, canRent = 0, canView = 0, canNewRent = 0, tdIsContractDivideOn, tdContractType, tdRelationProperty, hdOldRelationProperty, canChangeRent = 0;
        $(function () {
            ffObj = $("#<%=this.ff.ClientID%>");
            guid = parent.guid;
            ContractID = "<%=this.ContractID%>";
            TopContractID = parent.TopContractID;
            RentStartTimeObj = $("#<%=this.tdRentStartTime.ClientID%>");
            RentEndTimeObj = $("#<%=this.tdRentEndTime.ClientID%>");
            tdTimeLimit = $("#<%=this.tdTimeLimit.ClientID%>");
            tdRentToTime = $("#<%=this.tdRentToTime.ClientID%>");
            tdIsContractDivideOn = $("#<%=this.tdIsContractDivideOn.ClientID%>");
            tdContractType = $("#<%=this.tdContractType.ClientID%>");
            tdRelationProperty = $("#<%=this.tdRelationProperty.ClientID%>");
            hdOldRelationProperty = $("#<%=this.hdOldRelationProperty.ClientID%>");
            canAdd = parent.canAdd;
            canEdit = parent.canEdit;
            canSaveLog = parent.canSaveLog;
            canPrint = parent.canPrint;
            canRent = parent.canRent;
            canView = parent.canView;
            canNewRent = parent.canNewRent;
            canChangeRent = parent.canChangeRent;
            tdContractType.combobox({
                onSelect: function (ret) {
                    checkCustomerTypeStatus();
                }
            })
            checkCustomerTypeStatus();
            tdRelationProperty.combobox({
                onSelect: function (ret) {
                    checkRelationProperty();
                }
            })
            checkRelationProperty();
            if (canChangeRent == 1) {
                $('.oldCustomerBox').show();
                checkOldRelationProperty();
            } else {
                $('.oldCustomerBox').hide();
            }
        })
        function checkCustomerTypeStatus() {
            var contractType = tdContractType.combobox('getValue');
            if (contractType == 3) {
                parent.showCustomerTab();
                //$('.customerBox').hide();
            } else {
                parent.hideCustomerTab();
                //$('.customerBox').show();
            }
        }
        function checkRelationProperty() {
            var relationProperty = tdRelationProperty.combobox('getValue');
            if (relationProperty == 'geren') {
                //$('.customerBox').show();
                $('.companyBox').hide();
            } else {
                //$('.customerBox').hide();
                $('.companyBox').show();
            }
        }
        function checkOldRelationProperty() {
            if (hdOldRelationProperty.val() == 'geren') {
                $('.oldCompanyBox').hide();
            } else {
                $('.oldCompanyBox').show();
            }
        }
    </script>
    <script src="../js/Page/Contract/NewAddContract_Basic.js?t=<%=getToken()%>"></script>
    <script src="../js/Page/Contract/NewAddContract_RoomAssign.js?t=<%=getToken()%>"></script>
    <style>
        .panel-body {
            background: #f0f0f0;
        }

        table.info td:nth-child(2n) {
            padding: 10px 0;
            width: 20%;
        }

        table.info td:nth-child(2n-1) {
            width: 13%;
        }

        table.info td input[type=text], table.info td select, table.info td input[type=password] {
            width: 15%;
        }

        table.info td label.radioLabel {
            display: inline-block;
            position: relative;
            padding-left: 16px;
            line-height: 28px;
        }

        table.info td input[type=checkbox] {
            position: absolute;
            left: 0;
            top: 50%;
            margin: -7px 0 0 0;
            height: 15px;
            width: 15px;
        }

        .table_box {
            margin: 0 2%;
        }

        table.field {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
            margin: 0 auto;
            background: #fff;
        }

            table.field td {
                border: solid 1px #ccc;
                padding: 5px;
            }

            table.field input[type=text] {
                width: 200px;
            }

        table.info td span.red {
            color: red;
            font-size: 20px;
            vertical-align: middle;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td>合同编号<span class="red">*</span></td>
                <td>
                    <input type="text" runat="server" name="ContractNo" class="easyui-textbox" id="tdContractNo" data-options="required:true" />
                    <asp:HiddenField runat="server" ID="hdOrderNumberID" />
                </td>
                <td>合同类型<span class="red">*</span></td>
                <td>
                    <select runat="server" class="easyui-combobox" id="tdContractType" data-options="required:true,editable:false">
                        <option value="1">租赁合同</option>
                        <option value="2">物业合同</option>
                        <option value="3">多方合同</option>
                    </select></td>
                <td>合同名称<span class="red">*</span></td>
                <td>
                    <input type="text" runat="server" data-name="rent_content" name="ContractName" class="easyui-textbox" id="tdContractName" data-options="required:true" /></td>
            </tr>
            <tr>
                <td>租户类型<span class="red">*</span></td>
                <td>
                    <select runat="server" class="easyui-combobox" id="tdRelationProperty" data-options="required:true,editable:false">
                        <option value="geren">个人</option>
                        <option value="gongsi">公司</option>
                    </select></td>
            </tr>

            <tr>
                <td>租户名称<span class="red">*</span></td>
                <td>
                    <input type="text" runat="server" name="RentName" class="easyui-textbox" id="tdRentName" data-options="required:true" />
                </td>
                <td class="companyBox">联系人</td>
                <td class="companyBox">
                    <input type="text" runat="server" data-name="rent_content" class="easyui-textbox" id="tdCustomerName" /></td>
                <td>联系电话</td>
                <td>
                    <input type="text" runat="server" name="ContractPhone" class="easyui-textbox" id="tdContractPhone" /></td>
            </tr>
            <tr>
                <td>证件类别</td>
                <td>
                    <select class="easyui-combobox" id="tdIDCardType" runat="server" data-options="editable:false">
                        <option value="1">身份证</option>
                        <option value="2">护照</option>
                        <option value="3">军人证</option>
                        <option value="4">驾驶证</option>
                        <option value="5">其他</option>
                    </select></td>
                <td>证件号码</td>
                <td>
                    <input type="text" runat="server" name="IDCardNo" class="easyui-textbox" id="tdIDCardNo" /></td>
                <td>身份证地址</td>
                <td>
                    <input type="text" runat="server" name="IDCardAddress" class="easyui-textbox" id="tdIDCardAddress" /></td>
            </tr>
            <tr class="companyBox">
                <td>法人代表</td>
                <td>
                    <input type="text" runat="server" name="InChargeMan" class="easyui-textbox" id="tdInChargeMan" /></td>
                <td>营业执照</td>
                <td>
                    <input type="text" runat="server" name="BusinessLicense" class="easyui-textbox" id="tdBusinessLicense" /></td>
                <td>经营品类</td>
                <td>
                    <input type="text" runat="server" name="SellerProduct" class="easyui-textbox" id="tdSellerProduct" /></td>
            </tr>
            <tr>
                <td>开始日期<span class="red">*</span></td>
                <td>
                    <input type="text" runat="server" name="RentStartTime" class="easyui-datebox" id="tdRentStartTime" data-options="required:true" /></td>
                <td>结束日期<span class="red">*</span></td>
                <td>
                    <input type="text" runat="server" name="RentEndTime" class="easyui-datebox" id="tdRentEndTime" data-options="required:true" /></td>

                <td>合同期限</td>
                <td>
                    <input type="text" runat="server" data-options="readonly:true" name="TimeLimit" class="easyui-textbox" id="tdTimeLimit" />(月)
                </td>
            </tr>
            <%--<tr>
                <td>合同状态</td>
                <td>
                    <input type="text" runat="server" value="合同预定" data-options="required:true,readonly:true" name="ContractStatus" class="easyui-textbox" id="tdContractStatus" /></td>
                <td>预警日期</td>
                <td>
                    <input type="text" runat="server" name="WarningTime" class="easyui-datebox" id="tdWarningTime" /></td>
            </tr>--%>
            <tr id="trExistFiles" style="display: none;">
            </tr>
            <tr>
                <td>附件</td>
                <td colspan="5" id="tdFile"></td>
            </tr>
            <tr class="trRent">
                <td>续租至</td>
                <td>
                    <input type="text" runat="server" name="RentToTime" class="easyui-datebox" id="tdRentToTime" /></td>
            </tr>
            <tr>
                <td>联营分成
                </td>
                <td>
                    <label class="radioLabel">
                        <input type="checkbox" name="tabletype" value="1" runat="server" id="tdIsContractDivideOn" />启用
                    </label>
                </td>
                <td class="divideInfo">分成比例
                </td>
                <td class="divideInfo">
                    <input type="text" runat="server" name="TimeLimit" class="easyui-textbox" id="tdContractDevicePercent" />%
                </td>
                <td class="divideInfo">保底租金
                </td>
                <td class="divideInfo">
                    <input type="text" runat="server" name="TimeLimit" class="easyui-textbox" id="tdContractBasicRentCost" />
                </td>
            </tr>
        </table>
        <div class="table_title oldCustomerBox">原租户信息</div>
        <table class="info oldCustomerBox">
            <tr>
                <td>租户类型</td>
                <td>
                    <label runat="server" id="oldRelationProperty"></label>
                    <asp:HiddenField runat="server" ID="hdOldRelationProperty" />
                </td>
            </tr>
            <tr>
                <td>租户名称<span class="red">*</span></td>
                <td>
                    <label runat="server" id="oldRentName"></label>
                </td>
                <td class="oldCompanyBox">联系人</td>
                <td class="oldCompanyBox">
                    <label runat="server" id="oldCustomerName"></label>
                </td>
                <td>联系电话</td>
                <td>
                    <label runat="server" id="oldContractPhone"></label>
                </td>
            </tr>
            <tr>
                <td>证件类别</td>
                <td>
                    <label runat="server" id="oldIDCardType"></label>
                </td>
                <td>证件号码</td>
                <td>
                    <label runat="server" id="oldIDCardNo"></label>
                </td>
                <td>身份证地址</td>
                <td>
                    <label runat="server" id="oldIDCardAddress"></label>
                </td>
            </tr>
            <tr class="oldCompanyBox">
                <td>法人代表</td>
                <td>
                    <label runat="server" id="oldInChargeMan"></label>
                </td>
                <td>营业执照</td>
                <td>
                    <label runat="server" id="oldBusinessLicense"></label>
                </td>
                <td>经营品类</td>
                <td>
                    <label runat="server" id="oldSellerProduct"></label>
                </td>
            </tr>
        </table>
        <div class="table_title">租赁资源</div>
        <div class="table_box">
            <table id="tt_room"></table>
            <div id="tb">
                <%if (this.canEdit)
                    { %>
                <a href="javascript:void(0)" onclick="AddRoom()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-add'">新增</a>
                <a href="javascript:void(0)" onclick="RemoveRoom()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-remove'">删除</a>
                <%} %>
            </div>
        </div>
    </form>
</asp:Content>
