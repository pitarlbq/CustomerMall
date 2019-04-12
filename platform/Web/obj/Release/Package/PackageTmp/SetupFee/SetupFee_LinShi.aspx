<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="SetupFee_LinShi.aspx.cs" Inherits="Web.SetupFee.SetupFee_LinShi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/main.css" rel="stylesheet" />
    <script type="text/javascript">
        var CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
    </script>
    <script src="../js/Page/SetupFee/SetupFee_LinShi.js?v=<%=base.getToken() %>"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="easyui-layout" fit="true">
        <div data-options="region:'center'" title="">
            <div id="LinShiAccording" class="easyui-accordion" style="width: 90%; height: auto; margin: 0 auto;">
                <div title="收入" style="overflow: auto; padding: 10px;">
                    <table id="收入_table">
                        <thead>
                            <tr>
                                <th data-options="field:'ck',checkbox:true"></th>
                                <th data-options="field:'Name'" width="200">收费项目</th>
                                <th data-options="field:'CategoryDesc'" width="100">科目类别</th>
                                <th data-options="field:'SummaryUnitPrice',formatter: formatPrice" width="100">默认价格</th>
                            </tr>
                        </thead>
                    </table>
                    <div id="收入_tb">
                        <a href="#" class="addbutton buttonmin" onclick="addFee('收入')" data-options="iconCls:'icon-add',plain:true"></a>
                        <a href="#" class="editbutton buttonmin" onclick="editFee('收入')" data-options="iconCls:'icon-edit',plain:true"></a>
                        <a href="#" class="removebutton buttonmin" onclick="deleteFee('收入')" data-options="iconCls:'icon-remove',plain:true"></a>
                    </div>
                </div>
                <div title="预收" style="overflow: auto; padding: 10px;">
                    <table id="预收_table">
                        <thead>
                            <tr>
                                <th data-options="field:'ck',checkbox:true"></th>
                                <th data-options="field:'Name'" width="200">收费项目</th>
                                <th data-options="field:'CategoryDesc'" width="100">科目类别</th>
                                <th data-options="field:'SummaryUnitPrice',formatter: formatPrice" width="100">默认价格</th>
                            </tr>
                        </thead>
                    </table>
                    <div id="预收_tb">
                        <a href="#" class="addbutton buttonmin" onclick="addFee('预收')" data-options="iconCls:'icon-add',plain:true"></a>
                        <a href="#" class="editbutton buttonmin" onclick="editFee('预收')" data-options="iconCls:'icon-edit',plain:true"></a>
                        <a href="#" class="removebutton buttonmin" onclick="deleteFee('预收')" data-options="iconCls:'icon-remove',plain:true"></a>
                    </div>
                </div>
                <div title="押金" style="overflow: auto; padding: 10px;">
                    <table id="押金_table">
                        <thead>
                            <tr>
                                <th data-options="field:'ck',checkbox:true"></th>
                                <th data-options="field:'Name'" width="200">收费项目</th>
                                <th data-options="field:'CategoryDesc'" width="100">科目类别</th>
                                <th data-options="field:'SummaryUnitPrice',formatter: formatPrice" width="100">默认价格</th>
                            </tr>
                        </thead>
                    </table>
                    <div id="押金_tb">
                        <a href="#" class="addbutton buttonmin" onclick="addFee('押金')" data-options="iconCls:'icon-add',plain:true"></a>
                        <a href="#" class="editbutton buttonmin" onclick="editFee('押金')" data-options="iconCls:'icon-edit',plain:true"></a>
                        <a href="#" class="removebutton buttonmin" onclick="deleteFee('押金')" data-options="iconCls:'icon-remove',plain:true"></a>
                    </div>
                </div>
                <div title="代收" style="overflow: auto; padding: 10px;">
                    <table id="代收_table">
                        <thead>
                            <tr>
                                <th data-options="field:'ck',checkbox:true"></th>
                                <th data-options="field:'Name'" width="200">收费项目</th>
                                <th data-options="field:'ChargeTypeDesc'" width="100">计费方式</th>
                                <th data-options="field:'EndNumberDesc'" width="100">尾数</th>
                                <th data-options="field:'CategoryDesc'" width="100">科目类别</th>
                                <th data-options="field:'SummaryUnitPrice',formatter: formatPrice" width="100">单价</th>
                                <th data-options="field:'Coefficient'" width="100">系数</th>
                                <th data-options="field:'Unit'" width="100">计量单位</th>
                            </tr>
                        </thead>
                    </table>
                    <div id="代收_tb">
                        <a href="#" class="addbutton buttonmin" onclick="addFee('代收')" data-options="iconCls:'icon-add',plain:true"></a>
                        <a href="#" class="editbutton buttonmin" onclick="editFee('代收')" data-options="iconCls:'icon-edit',plain:true"></a>
                        <a href="#" class="removebutton buttonmin" onclick="deleteFee('代收')" data-options="iconCls:'icon-remove',plain:true"></a>
                    </div>
                </div>
                <div title="公摊" style="overflow: auto; padding: 10px;">
                    <table id="公摊_table">
                        <thead>
                            <tr>
                                <th data-options="field:'ck',checkbox:true"></th>
                                <th data-options="field:'Name'" width="200">收费项目</th>
                                <th data-options="field:'ChargeTypeDesc'" width="100">计费方式</th>
                                <th data-options="field:'EndNumberDesc'" width="100">尾数</th>
                                <th data-options="field:'CategoryDesc'" width="100">科目类别</th>
                                <th data-options="field:'SummaryUnitPrice',formatter: formatPrice" width="100">单价</th>
                            </tr>
                        </thead>
                    </table>
                    <div id="公摊_tb">
                        <a href="#" class="addbutton buttonmin" onclick="addFee('公摊')" data-options="iconCls:'icon-add',plain:true"></a>
                        <a href="#" class="editbutton buttonmin" onclick="editFee('公摊')" data-options="iconCls:'icon-edit',plain:true"></a>
                        <a href="#" class="removebutton buttonmin" onclick="deleteFee('公摊')" data-options="iconCls:'icon-remove',plain:true"></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
