<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="EditMoreCustomer.aspx.cs" Inherits="Web.InsideCustomer.EditMoreCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/toast/jquery.toast.js"></script>
    <link href="../js/toast/jquery.toast.css" rel="stylesheet" />
    <script type="text/javascript">
        var IndustryNameList = [], CategoryNameList = [], InterestingList = [], GroupInvitationList = [], RegionList = [], BusinessStageList = [], DealProbablyList = [];
        $(function () {
            getDataList();
        })
        function getDataList() {
            IndustryNameList.push({ ID: "物业公司", Name: "物业公司" });
            IndustryNameList.push({ ID: "软件代理", Name: "软件代理" });
            IndustryNameList.push({ ID: "其他客户", Name: "其他客户" });

            $('#<%=this.tdIndustryName.ClientID%>').combobox({
                data: IndustryNameList,
                valueField: 'ID',
                textField: 'Name'
            })

            CategoryNameList.push({ ID: "共同资源", Name: "共同资源" });
            CategoryNameList.push({ ID: "有效客户", Name: "有效客户" });
            CategoryNameList.push({ ID: "无效客户", Name: "无效客户" });
            CategoryNameList.push({ ID: "线索客户", Name: "线索客户" });
            CategoryNameList.push({ ID: "商机客户", Name: "商机客户" });
            CategoryNameList.push({ ID: "成交客户", Name: "成交客户" });
            CategoryNameList.push({ ID: "流失客户", Name: "流失客户" });
            $('#<%=this.tdCategoryName.ClientID%>').combobox({
                data: CategoryNameList,
                valueField: 'ID',
                textField: 'Name'
            })

            InterestingList.push({ ID: "使用软件", Name: "使用软件" });
            InterestingList.push({ ID: "竞品代理", Name: "竞品代理" });
            InterestingList.push({ ID: "有意了解", Name: "有意了解" });
            InterestingList.push({ ID: "意向不明", Name: "意向不明" });
            InterestingList.push({ ID: "不愿沟通", Name: "不愿沟通" });
            $('#<%=this.tdInteresting.ClientID%>').combobox({
                data: InterestingList,
                valueField: 'ID',
                textField: 'Name'
            })

            GroupInvitationList.push({ ID: "在", Name: "在" });
            GroupInvitationList.push({ ID: "不在", Name: "不在" });
            $('#<%=this.tdQQGroupInvitation.ClientID%>').combobox({
                data: GroupInvitationList,
                valueField: 'ID',
                textField: 'Name'
            })
            $('#<%=this.tdWechaGroupInvitation.ClientID%>').combobox({
                data: GroupInvitationList,
                valueField: 'ID',
                textField: 'Name'
            })

            RegionList.push({ ID: "西南", Name: "西南" });
            RegionList.push({ ID: "中西", Name: "中西" });
            RegionList.push({ ID: "北部", Name: "北部" });
            RegionList.push({ ID: "东南", Name: "东南" });
            RegionList.push({ ID: "南部", Name: "南部" });
            $('#<%=this.tdRegion.ClientID%>').combobox({
                data: RegionList,
                valueField: 'ID',
                textField: 'Name'
            })
        }
        function saveResource() {
            var isValid = $("#ff").form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var rows = parent.$('#tt_table').datagrid('getSelections');
            if (rows.length == 0) {
                show_message('请选择客户列表', 'warning');
                return;
            }
            var IDList = [];
            $.each(rows, function (index, item) {
                IDList.push(item.ID);
            })
            var row = {};
            row.IndustryName = $('#<%=this.tdIndustryName.ClientID%>').combobox('getValue');
            row.CategoryName = $('#<%=this.tdCategoryName.ClientID%>').combobox('getValue');
            row.Interesting = $('#<%=this.tdInteresting.ClientID%>').combobox('getValue');
            row.CustomerBelonger = $('#<%=this.tdCustomerBelonger.ClientID%>').textbox('getValue');
            row.Region = $('#<%=this.tdRegion.ClientID%>').combobox('getValue');
            row.Province = $('#<%=this.tdProvince.ClientID%>').textbox('getValue');
            row.City = $('#<%=this.tdCity.ClientID%>').textbox('getValue');
            row.QQGroupInvitation = $('#<%=this.tdQQGroupInvitation.ClientID%>').combobox('getValue');
            row.WechaGroupInvitation = $('#<%=this.tdWechaGroupInvitation.ClientID%>').combobox('getValue');
            MaskUtil.mask('body', '提交中');
            $('#ff').form('submit', {
                url: '../Handler/CommHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savemoreinsidecustomer';
                    param.List = JSON.stringify(row);
                    param.IDList = JSON.stringify(IDList);
                },
                success: function (data) {
                    MaskUtil.unmask();
                    var message = eval("(" + data + ")");
                    if (message.status) {
                        show_message('修改成功', 'success');
                        return;
                    }
                    else {
                        show_message('系统错误', 'error');
                    }
                }
            });
        }
        function closeWin() {
            parent.$("#winadd").window("close");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <style type="text/css">
        table.info {
            margin: 0 auto;
            width: 90%;
            border-collapse: collapse;
            border-spacing: 0;
            border: solid 1px #ccc;
        }

            table.info td {
                padding: 5px 10px;
                text-align: left;
                vertical-align: middle;
                border: solid 1px #ccc;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }
    </style>
    <form id="ff" method="post" runat="server" enctype="multipart/form-data">
        <table class="info">
            <tr>
                <td>行业
                </td>
                <td>
                    <input id="tdIndustryName" class="easyui-combobox" runat="server" type="text" />
                </td>
                <td>分类
                </td>
                <td>
                    <input class="easyui-combobox" id="tdCategoryName" runat="server" type="text" />
                </td>
            </tr>
            <tr>

                <td>意向分析
                </td>
                <td>
                    <input class="easyui-combobox" id="tdInteresting" runat="server" type="text" />
                </td>
                <td>客户所有者
                </td>
                <td>
                    <input class="easyui-textbox" id="tdCustomerBelonger" runat="server" type="text" />
                </td>

            </tr>
            <tr>
                <td>区域
                </td>
                <td>
                    <input class="easyui-combobox" id="tdRegion" runat="server" type="text" />
                </td>
                <td>省区
                </td>
                <td>
                    <input class="easyui-textbox" id="tdProvince" runat="server" type="text" />
                </td>
            </tr>
            <tr>
                <td>城市
                </td>
                <td>
                    <input class="easyui-textbox" id="tdCity" runat="server" type="text" />
                </td>
                <td>QQ群邀约
                </td>
                <td>
                    <input class="easyui-combobox" id="tdQQGroupInvitation" runat="server" type="text" />
                </td>
            </tr>
            <tr>
                <td>微信群邀约
                </td>
                <td>
                    <input class="easyui-combobox" id="tdWechaGroupInvitation" runat="server" type="text" />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center;">
                    <a href="javascript:void(0)" onclick="saveResource()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-save'">保存</a>
                    <a href="javascript:void(0)" onclick="closeWin()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </td>
            </tr>
        </table>
    </form>
</asp:Content>
