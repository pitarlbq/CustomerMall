<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ToCuiKuanDetails.aspx.cs" Inherits="Web.Analysis.ToCuiKuanDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var CompanyID, hdIDs, AddMan, tdStartTime, tdEndTime, tdChargeMan, tdChargeSummary, tdChargeType, tdCategory, tdChargeStatus, hdRoomIDs, hdProjectIDs, hdChargeMan, hdChargeSummary, hdChargeType, hdCategory, hdChargeStatus;
        $(function () {
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
            AddMan = "<%=Web.WebUtil.GetUser(this.Context).RealName%>";
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
            tdChargeMan = $("#<%=this.tdChargeMan.ClientID%>");
            hdChargeMan = $("#<%=this.hdChargeMan.ClientID%>");
            tdChargeSummary = $("#<%=this.tdChargeSummary.ClientID%>");
            hdChargeSummary = $("#<%=this.hdChargeSummary.ClientID%>");
            tdChargeType = $("#<%=this.tdChargeType.ClientID%>");
            hdChargeType = $("#<%=this.hdChargeType.ClientID%>");
            tdCategory = $("#<%=this.tdCategory.ClientID%>");
            hdCategory = $("#<%=this.hdCategory.ClientID%>");
            tdChargeStatus = $("#<%=this.tdChargeStatus.ClientID%>");
            hdChargeStatus = $("#<%=this.hdChargeStatus.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
        })
    </script>
    <style>
        .sfdd {
            width: 51px;
            height: 32px;
            background: url("../styles/images/buttons/print.png") no-repeat center center;
            display: block;
        }

        .lsff {
            width: 51px;
            height: 32px;
            background: url("../styles/images/buttons/tempfee.png") no-repeat center center;
            display: block;
        }

        .roomtable, .operationtable {
            width: 100%;
        }

            .roomtable, .operationtable td {
                text-align: center;
            }
    </style>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script>
        var pageWidth, pageHeight;
        function doPrint() {
            var rows = $('#his_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message('请选择一条数据，操作取消', 'warning');
                return;
            }
            var isCancel = false;
            var RoomFeeIDList = [];
            var PrintIDList = [];
            $.each(rows, function (index, row) {
                if (row.ChargeState == 2) {
                    isCancel = true;
                    return false;
                }
                RoomFeeIDList.push(row.HistoryID);
                PrintIDList.push(row.PrintID);
            });
            if (isCancel) {
                show_message('不能打印已作废的单据，操作取消', 'warning');
                return;
            }
            MaskUtil.mask('body', '打印中');
            pageWidth = 210;
            pageHeight = 99;
            var iframe = document.getElementById("myframe");
            var url = "../PrintPage/printchargefeeview.aspx?PrintID=" + PrintIDList[0] + "&PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
            iframe.src = url;
            if (iframe.attachEvent) {
                iframe.attachEvent("onload", function () {
                    MaskUtil.unmask();
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml);
                    }, 1000);
                });
            } else {
                iframe.onload = function () {
                    MaskUtil.unmask();
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml);
                    }, 1000);
                };
            }
        }
        var LODOP = null;
        function LODOPPrint(strHtml) {
            try {
                LODOP = getLodop();
                if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
                    LODOP.PRINT_INIT("打印单据_催收单");
                    LODOP.SET_PRINT_PAGESIZE(1, pageWidth + 'mm', 0, '')
                    LODOP.ADD_PRINT_TABLE(0, '3%', '94%', '100%', strHtml);
                    LODOP.PREVIEW();
                }
                else {
                    alert("Error:该浏览器不支持打印插件!");
                }
            } catch (err) {
                alert("Error:本机未安装或需要升级!");
            }
        }
    </script>
    <script src="../js/Page/Analysis/ToCuiKuanDetails.js?t=<%=base.getToken() %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:true,hideCollapsedContent:false," title="" style="height: 90px; padding: 5px 10px;">
                <label>
                    收款时间:               
                    <input class="easyui-datebox" id="tdStartTime" runat="server" />
                    -
                <input class="easyui-datebox" id="tdEndTime" runat="server" />
                </label>
                <label>
                    收款人:
                <input class="easyui-combobox" id="tdChargeMan" runat="server" style="width: 150px;" />
                    <asp:HiddenField runat="server" ID="hdChargeMan" />
                </label>
                <label>
                    收费项目:               
                    <input class="easyui-combobox" id="tdChargeSummary" runat="server" style="width: 150px;" />
                    <asp:HiddenField runat="server" ID="hdChargeSummary" />
                </label>
                <label>
                    收款方式:
                <input class="easyui-combobox" id="tdChargeType" runat="server" style="width: 150px;" />
                    <asp:HiddenField runat="server" ID="hdChargeType" />
                </label>
                <label>
                    费项分类:               
                    <input class="easyui-combobox" id="tdCategory" runat="server" style="width: 150px;" />
                    <asp:HiddenField runat="server" ID="hdCategory" />
                </label>
                <label>
                    收费状态:               
                    <select class="easyui-combobox" id="tdChargeStatus" runat="server" style="width: 150px;">
                        <option value="5">催收中</option>
                        <option value="1">已收费</option>
                        <option value="2">已作废</option>
                    </select>
                    <asp:HiddenField runat="server" ID="hdChargeStatus" />
                </label>
                <label>
                    所属部门:
                    <input class="easyui-textbox" id="tdRelationBelongTeam" style="width: 100px; height: 28px;" />
                </label>
                <label class="searchlabel" style="margin-left: 10px;">
                    <a href="#" onclick="SearchHis()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="his_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdRoomIDs" runat="server" />
                    <asp:HiddenField ID="hdProjectIDs" runat="server" />
                    <asp:HiddenField ID="hdIDs" runat="server" />
                    <a href="#" onclick="openTableSetUp()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-setting'">配置</a>
                    <a href="#" onclick="doChargeRoomFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shoufei'">收款确认</a>
                    <a href="#" onclick="doCancelRoomFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-zuofei'">作废单据</a>
                    <a href="#" onclick="doPrint()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">批量打印</a>
                    <%if (base.CheckAuthByModuleCode("1191143"))
                      { %>
                    <a href="#" onclick="ReChargeRoomFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-shoufei'">重新收费</a>
                    <%} %>
                    <a href="#" onclick="do_export_daikou()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">代扣单导出</a>
                </div>
            </div>
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
