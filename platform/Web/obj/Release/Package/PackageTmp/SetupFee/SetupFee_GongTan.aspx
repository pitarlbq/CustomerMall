<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SetupFee_GongTan.aspx.cs" Inherits="Web.SetupFee.SetupFee_GongTan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/main.css" rel="stylesheet" />
    <script type="text/javascript">
        var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
    </script>
    <script src="../js/Page/SetupFee/SetupFee_GongTan.js?v=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'center'" title="">
            <table id="tt_table">
                <thead>
                    <tr>
                        <th data-options="field:'Name'" width="200">收费项目</th>
                        <th data-options="field:'ChargeTypeDesc'" width="100">计费方式</th>
                        <th data-options="field:'EndNumberDesc'" width="100">尾数</th>
                        <th data-options="field:'CategoryDesc'" width="100">科目类别</th>
                        <th data-options="field:'SummaryUnitPrice',formatter: formatPrice" width="100">单价</th>
                    </tr>
                </thead>
            </table>
            <div id="tb">
                <a href="#" class="addbutton buttonmin" onclick="addFee()" data-options="iconCls:'icon-add',plain:true"></a>
                <a href="#" class="editbutton buttonmin" onclick="editFee()" data-options="iconCls:'icon-edit',plain:true"></a>
                <a href="#" class="removebutton buttonmin" onclick="deleteFee()" data-options="iconCls:'icon-remove',plain:true"></a>
            </div>
        </div>
    </div>
</asp:Content>
