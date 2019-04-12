<%@ Page Title="" Language="C#" MasterPageFile="~/Master/NavContent4.Master" AutoEventWireup="true" CodeBehind="ContractFeeSummary.aspx.cs" Inherits="Web.Contract.ContractFeeSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        var tdKeywords, tdStartTime, tdEndTime, hdProjectIDs, hdRoomIDs, tdChargeSummary, hdChargeSummary, tdFeeStatus;
        $(function () {
            tdKeywords = $("#<%=this.tdKeywords.ClientID%>");
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
            hdProjectIDs = $("#<%=this.hdProjectIDs.ClientID%>");
            hdRoomIDs = $("#<%=this.hdRoomIDs.ClientID%>");
            tdChargeSummary = $("#<%=this.tdChargeSummary.ClientID%>");
            hdChargeSummary = $("#<%=this.hdChargeSummary.ClientID%>");
            tdFeeStatus = $("#<%=this.tdFeeStatus.ClientID%>");
            var op = "<%=this.op%>";
            if (op == 'view') {
                setTimeout(function () {
                    $("#main_form_layout").layout('panel', 'north').panel("options").height = 80;
                    $("#main_form_layout").layout("resize");
                    $('.operation_box').show();
                }, 100);
            }
        })
        function do_close() {
            parent.do_close_dialog()
        }
    </script>
    <script src="../js/Page/Contract/ContractFeeSummary.js?v=<%=base.getToken()%>" type="text/javascript"></script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script>
        function printChargeFee() {
            var rows = $('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message("请选择一个合同费项", "warning");
                return;
            }
            MaskUtil.mask('body', '打印中');
            var ContractFeeIDList = [];
            $.each(rows, function (index, row) {
                ContractFeeIDList.push(row.ID);
            });
            var pageWidth = 210;
            var pageHeight = 99;
            var iframe = document.getElementById("myframe");
            $('#ids').val(JSON.stringify(ContractFeeIDList));
            var url = "../PrintPage/printcontractcuifeiview.aspx?PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
            iframe.src = url;
            if (iframe.attachEvent) {
                iframe.attachEvent("onload", function () {
                    MaskUtil.unmask();
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml, pageWidth, pageHeight);
                    }, 1000);
                });
            } else {
                iframe.onload = function () {
                    MaskUtil.unmask();
                    setTimeout(function () {
                        var strHtml = iframe.contentWindow.document.documentElement.innerHTML;
                        LODOPPrint(strHtml, pageWidth, pageHeight);
                    }, 1000);
                };
            }
        }
        function LODOPPrint(strHtml, pageWidth, pageHeight) {
            try {
                LODOP = getLodop();
                if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
                    LODOP.PRINT_INIT("打印单据_合同催收单");
                    LODOP.SET_PRINT_PAGESIZE(1, '210mm', 0, '')
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
    <style>
        .tdsearch label {
            margin-right: 10px;
        }

        .operation_box {
            position: relative;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="main_form_layout" class="easyui-layout" fit="true">
            <div data-options="region:'north'" style="height: 50px; padding: 5px;">
                <div class="operation_box" style="display: none;">
                    <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
                </div>
                <div class="tdsearch">
                    <label>
                        模糊搜索:
                        <input type="text" class="easyui-searchbox" id="tdKeywords" style="width: 150px;" data-options="prompt:'模糊搜索',searcher:SearchTT" runat="server" />
                    </label>
                    <label>
                        收费项目:
                        <input class="easyui-combobox" runat="server" id="tdChargeSummary" style="width: 150px;" />
                        <asp:HiddenField runat="server" ID="hdChargeSummary" />
                    </label>
                    <label>
                        收费日期:
                        <input class="easyui-datebox" id="tdStartTime" style="width: 100px; height: 25px;" runat="server" />
                        -
                    <input class="easyui-datebox" id="tdEndTime" style="width: 100px; height: 25px;" runat="server" />
                    </label>
                    <label>
                        <select runat="server" id="tdFeeStatus" class="easyui-combobox" style="width: 100px; height: 25px;">
                            <option value="">全部</option>
                            <option value="1">只显示应收</option>
                            <option value="2">只显示已收</option>
                        </select>
                    </label>
                    <label>
                        <a href="javascript:void(0)" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                    </label>
                    <label style="margin-right: 10px; line-height: 25px;">
                        <input type="radio" name="tabletype" value="Contract" checked="checked" />明细
                    </label>
                    <label style="margin-right: 10px;">
                        <input type="radio" name="tabletype" value="Project" />汇总
                    </label>
                </div>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tt_mm">
                    <a href="javascript:void(0)" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <a href="#" onclick="printChargeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                    <asp:HiddenField runat="server" ID="hdProjectIDs" />
                    <asp:HiddenField runat="server" ID="hdRoomIDs" />
                </div>
            </div>
        </div>
        <input type="text" style="display: none" id="ids" />
        <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
    </form>
</asp:Content>
