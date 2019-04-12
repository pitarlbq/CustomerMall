<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditRelateFamily.aspx.cs" Inherits="Web.RoomResource.EditRelateFamily" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var can_edit_name, tdRelationProperty, tdRelatePhone, tdRelationProperty, tdCompanyName;
        $(function () {
            tdRelateName = $("#<%=this.tdRelateName.ClientID%>");
            tdRelatePhone = $("#<%=this.tdRelatePhone.ClientID%>");
            tdRelationProperty = $("#<%=this.tdRelationProperty.ClientID%>");
            tdCompanyName = $("#<%=this.tdCompanyName.ClientID%>");
            can_edit_name = Number('<%=this.canEditName?1:0%>');
            if (can_edit_name == 0) {
                tdRelateName.textbox("disable", true);
                tdRelatePhone.textbox("disable", true);
            }
            else {
                tdRelateName.textbox("enable", true);
                tdRelatePhone.textbox("enable", true);
            }
            tdRelationProperty.combobox({
                onSelect: function (ret) {
                    reset_textbox();
                }
            })
            reset_textbox();
        })
        function reset_textbox() {
            var relation_property = tdRelationProperty.textbox('getValue');
            if (relation_property == 'geren') {
                tdCompanyName.textbox("disable", true);
                $('.checkinfo').hide();
            } else {
                tdCompanyName.textbox("enable", true);
                $('.checkinfo').show();
            }
        }
        function do_save() {
            var ID = "<%=Request.QueryString["ID"]%>";
            var RoomID = "<%=Request.QueryString["RoomID"]%>";
            var name = $("#<%=this.tdRelateName.ClientID%>").textbox("getValue");
            var phone = $("#<%=this.tdRelatePhone.ClientID%>").textbox("getValue");
            var RelateIDCard = $("#<%=this.tdRelateIDCard.ClientID%>").textbox("getValue");
            var IsDefaultCheck = document.getElementById("<%=this.tdIsDefault.ClientID%>");
            var IsDefault = IsDefaultCheck.checked ? 1 : 0;
            var IsChargeManCheck = document.getElementById("<%=this.tdIsChargeMan.ClientID%>");
            var IsChargeMan = IsChargeManCheck.checked ? 1 : 0;
            var IsChargeFeeCheck = document.getElementById("<%=this.tdIsChargeFee.ClientID%>");
            var IsChargeFee = IsChargeFeeCheck.checked ? 1 : 0;
            var RelationType = $("#<%=this.tdRelationType.ClientID%>").combobox("getValue");;
            var RelationProperty = tdRelationProperty.combobox("getValue");
            var IDCardType = $("#<%=this.tdIDCardType.ClientID%>").combobox("getValue");
            var Birthday = $("#<%=this.tdBirthday.ClientID%>").datebox("getValue");
            var EmailAddress = $("#<%=this.tdEmailAddress.ClientID%>").textbox("getValue");
            var HomeAddress = $("#<%=this.tdHomeAddress.ClientID%>").textbox("getValue");
            var OfficeAddress = $("#<%=this.tdOfficeAddress.ClientID%>").textbox("getValue");
            var BankName = $("#<%=this.tdBankName.ClientID%>").textbox("getValue");
            var BankAccountName = $("#<%=this.tdBankAccountName.ClientID%>").textbox("getValue");
            var BankNo = $("#<%=this.tdBankNo.ClientID%>").textbox("getValue");
            var CustomOne = $("#<%=this.tdCustomOne.ClientID%>").textbox("getValue");
            var CustomTwo = $("#<%=this.tdCustomTwo.ClientID%>").textbox("getValue");
            var CustomThree = $("#<%=this.tdCustomThree.ClientID%>").textbox("getValue");
            var CustomFour = $("#<%=this.tdCustomFour.ClientID%>").textbox("getValue");
            var Remark = $("#<%=this.tdRemark.ClientID%>").textbox("getValue");
            var ContractStartTime = $("#<%=this.tdContractStartTime.ClientID%>").datebox("getValue");
            var ContractEndTime = $("#<%=this.tdContractEndTime.ClientID%>").datebox("getValue");
            var BrandInfo = $("#<%=this.tdBrandNote.ClientID%>").textbox("getValue");
            var ContractNote = $("#<%=this.tdContractNote.ClientID%>").textbox("getValue");
            var Interesting = $("#<%=this.tdInteresting.ClientID%>").textbox("getValue");
            var ConsumeMore = $("#<%=this.tdConsumeMore.ClientID%>").textbox("getValue");
            var BelongTeam = $("#<%=this.tdBelongTeam.ClientID%>").textbox("getValue");
            var OneCardNumber = $("#<%=this.tdOneCardNumber.ClientID%>").textbox("getValue");
            var ChargeForMan = $("#<%=this.tdChargeForMan.ClientID%>").textbox("getValue");
            var CompanyName = tdCompanyName.textbox("getValue");
            var TaxpayerNumber = $("#<%=this.tdTaxpayerNumber.ClientID%>").textbox("getValue");
            var options = { visit: "savefamily", ID: ID, RoomID: RoomID, name: name, phone: phone, RelateIDCard: RelateIDCard, IsDefault: IsDefault, RelationType: RelationType, IDCardType: IDCardType, Birthday: Birthday, EmailAddress: EmailAddress, HomeAddress: HomeAddress, OfficeAddress: OfficeAddress, BankName: BankName, BankAccountName: BankAccountName, BankNo: BankNo, CustomOne: CustomOne, CustomTwo: CustomTwo, CustomThree: CustomThree, CustomFour: CustomFour, Remark: Remark, ContractStartTime: ContractStartTime, ContractEndTime: ContractEndTime, BrandInfo: BrandInfo, ContractNote: ContractNote, IsChargeFee: IsChargeFee, RelationProperty: RelationProperty, Interesting: Interesting, ConsumeMore: ConsumeMore, BelongTeam: BelongTeam, OneCardNumber: OneCardNumber, ChargeForMan: ChargeForMan, IsChargeMan: IsChargeMan, CompanyName: CompanyName, TaxpayerNumber: TaxpayerNumber };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: '../Handler/RoomResourceHandler.ashx',
                data: options,
                success: function (message) {
                    if (message.status) {
                        $('#ff').form('submit', {
                            url: '../Handler/RoomResourceHandler.ashx',
                            onSubmit: function (param) {
                                param.visit = 'savefamilyphoto';
                                param.ID = message.ID;
                            },
                            success: function (data) {
                                show_message('保存成功', 'success', function () {
                                    do_close();
                                });
                            }
                        });
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            })
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$("#home_table").datagrid("reload");
            });
        }
        function showPreImg(file) {
            var objUrl = getObjectURL(file.files[0]);
            if (objUrl) {
                $("#PreImg").attr("src", objUrl);
                var imgPath = "../styles/images/edit.jpg";
                $(".fileInputContainer").css("background-image", "url(" + imgPath + ")");
            }
        }
        function getObjectURL(file) {
            var url = null;
            if (window.createObjectURL != undefined) { // basic
                url = window.createObjectURL(file);
            } else if (window.URL != undefined) { // mozilla(firefox)
                url = window.URL.createObjectURL(file);
            } else if (window.webkitURL != undefined) { // webkit or chrome
                url = window.webkitURL.createObjectURL(file);
            }
            return url;
        }
        $(function () {
            var tdIsChargeManObj = $("#<%=this.tdIsChargeMan.ClientID%>");
            var tdIsChargeFeeObj = $("#<%=this.tdIsChargeFee.ClientID%>");
            tdIsChargeManObj.bind('click', function () {
                if (!tdIsChargeManObj.prop('checked')) {
                    tdIsChargeFeeObj.prop('checked', false);
                }
            })
            tdIsChargeFeeObj.bind('click', function () {
                if (!tdIsChargeManObj.prop('checked')) {
                    tdIsChargeFeeObj.prop('checked', false);
                }
            })
        })
    </script>
    <style type="text/css">
        .panel-body {
            background: #f0f0f0;
        }

        table.add {
            width: 100%;
            margin: 0 auto;
            margin-top: 10px;
            border-collapse: collapse;
            border-spacing: 0px;
        }

            table.add td {
                padding: 10px;
                width: 35%;
            }

                table.add td:nth-child(2n-1) {
                    width: 15%;
                }

        .fileInputContainer {
            height: 60px;
            background: url("../styles/images/addimage.jpg") no-repeat;
            width: 60px;
            position: relative;
            margin-left: 130px;
            margin-top: 20px;
            background-size: cover;
        }

        .fileInput {
            height: 60px;
            width: 60px;
            position: absolute;
            right: 0;
            top: 0;
            opacity: 0;
            filter: alpha(opacity=0);
            cursor: pointer;
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
            <div class="table_title">
                主要信息
            </div>
            <table class="info">
                <tr>
                    <td>住户类别</td>
                    <td>
                        <select type="text" class="easyui-combobox" runat="server" id="tdRelationProperty" data-options="editable:false">
                            <option value="geren">个人</option>
                            <option value="gongsi">公司</option>
                        </select></td>
                    <td>住户标签</td>
                    <td>
                        <select type="text" class="easyui-combobox" runat="server" id="tdRelationType" data-options="editable:false">
                            <option value="homefamily">业主</option>
                            <option value="rentfamily">租户</option>
                        </select></td>
                </tr>
                <tr>
                    <td>公司名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCompanyName" /></td>
                    <td>住户姓名</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdRelateName" /></td>
                </tr>
                <tr>
                    <td>联系方式</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdRelatePhone" data-options="require:true" /></td>
                    <td style="text-align: left" colspan="2">默认联系人               
                        <input type="checkbox" runat="server" id="tdIsDefault" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        缴费对象               
                        <input type="checkbox" runat="server" id="tdIsChargeMan" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        缴费人员               
                        <input type="checkbox" runat="server" id="tdIsChargeFee" />
                    </td>
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
                        <input type="text" class="easyui-textbox" runat="server" id="tdRelateIDCard" /></td>
                </tr>
            </table>
            <div class="table_title checkinfo">开票信息</div>
            <table class="info checkinfo">
                <tr>
                    <td>纳税人识别号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdTaxpayerNumber" /></td>
                    <td>银行账号</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBankNo" /></td>
                </tr>
                <tr>
                    <td>开户银行</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBankName" /></td>
                    <td>开户名称</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdBankAccountName" /></td>
                </tr>
                <tr>
                    <td>电子信箱</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdEmailAddress" /></td>
                </tr>
            </table>
            <div class="table_title">其他信息</div>
            <table class="info">
                <tr>
                    <td>联系地址</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdHomeAddress" /></td>
                    <td>工作单位</td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdOfficeAddress" /></td>
                </tr>
                <tr>
                    <td>出生日期
                    </td>
                    <td>
                        <input class="easyui-datebox" id="tdBirthday" runat="server" />
                    </td>
                    <td><%=base.GetExistColumns(this.TableName, "CustomOne")%></td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCustomOne" /></td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName, "CustomTwo")%></td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCustomTwo" /></td>
                    <td><%=base.GetExistColumns(this.TableName, "CustomThree")%></td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCustomThree" /></td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName, "CustomFour")%></td>
                    <td>
                        <input type="text" class="easyui-textbox" runat="server" id="tdCustomFour" /></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td>合同开始日期
                    </td>
                    <td>
                        <input class="easyui-datebox" id="tdContractStartTime" runat="server" />
                    </td>
                    <td>合同结束日期
                    </td>
                    <td>
                        <input class="easyui-datebox" id="tdContractEndTime" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName, "Interesting")%>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdInteresting" runat="server" />
                    </td>
                    <td><%=base.GetExistColumns(this.TableName, "ConsumeMore")%>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdConsumeMore" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>品牌信息
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdBrandNote" runat="server" />
                    </td>
                    <td>所属部门
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdBelongTeam" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td><%=base.GetExistColumns(this.TableName, "OneCardNumber")%>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdOneCardNumber" runat="server" />
                    </td>
                    <td><%=base.GetExistColumns(this.TableName,"ChargeForMan") %>
                    </td>
                    <td>
                        <input class="easyui-textbox" id="tdChargeForMan" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>合同说明
                    </td>
                    <td colspan="3">
                        <input class="easyui-textbox" data-options="multiline:true" id="tdContractNote" style="width: 80%; height: 60px;" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>备注</td>
                    <td colspan="3">
                        <input type="text" class="easyui-textbox" runat="server" id="tdRemark" data-options="multiline:true" style="height: 60px; width: 80%;" /></td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
