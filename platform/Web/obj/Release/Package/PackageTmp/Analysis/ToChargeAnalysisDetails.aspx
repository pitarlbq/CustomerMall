<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ToChargeAnalysisDetails.aspx.cs" Inherits="Web.Analysis.ToChargeAnalysisDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        var CompanyID, hdIDs, tdStartTime, tdEndTime;
        $(function () {
            //$("#layout").layout("collapse", "north");
            CompanyID = "<%=Web.WebUtil.GetCompanyID(this.Context)%>";
            hdIDs = $("#<%=this.hdIDs.ClientID%>");
            tdStartTime = $("#<%=this.tdStartTime.ClientID%>");
            tdEndTime = $("#<%=this.tdEndTime.ClientID%>");
        })
    </script>
    <script src="../js/Page/Analysis/ToChargeAnalysisDetails.js?t=<%=base.getToken() %>"></script>
    <style>
        .operationtable {
            width: 100%;
        }

            .operationtable td {
                text-align: center;
            }

        .sfdd {
            width: 100%;
            height: 32px;
            background: url("../styles/images/buttons/print.png") no-repeat center center;
            display: block;
        }
    </style>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script>
        function printChargeFee() {
            var rows = $('#tt_table').datagrid("getSelections");
            if (rows.length == 0) {
                show_message('请选择一条数据，操作取消', 'warning');
                return;
            }
            MaskUtil.mask('body', '打印中');
            var RoomFeeIDList = [];
            $.each(rows, function (index, row) {
                RoomFeeIDList.push(row.ID);
            });
            var pageWidth = 210;
            var pageHeight = 99;
            var iframe = document.getElementById("myframe");
            $('#ids').val(JSON.stringify(RoomFeeIDList));
            var url = "../PrintPage/printcuifeiview.aspx?PageWidth=" + pageWidth + "&PageHeight=" + pageHeight;
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
                    LODOP.PRINT_INIT("打印单据_催收单");
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form runat="server">
        <div id="layout" class="easyui-layout" fit="true">
            <div data-options="region:'north',split:false,hideCollapsedContent:false," title="" style="height: 60px; padding: 5px 10px;">
                <label>
                    时间:
                <input class="easyui-datebox" id="tdStartTime" runat="server" />
                    -
                <input class="easyui-datebox" id="tdEndTime" runat="server" />
                </label>
                <label>
                    收费项目:
                    <input class="easyui-combobox" id="tdChargeSummaryName" style="width: 150px;" />
                </label>
                <label>
                    房间状态:
                    <input class="easyui-combobox" id="tdRoomState" style="width: 150px;" />
                </label>
                <label>
                    房源属性:
                    <input class="easyui-combobox" id="tdRoomProperty" style="width: 150px;" />
                </label>
                <label class="searchlabel" style="margin-left: 10px;">
                    <a href="#" onclick="SearchTT()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-search'">搜索</a>
                </label>
            </div>
            <div data-options="region:'center'" title="">
                <table id="tt_table">
                </table>
                <div id="tb">
                    <a href="#" onclick="do_export()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-export'">导出</a>
                    <asp:HiddenField ID="hdIDs" runat="server" />
                    <a href="#" onclick="printChargeFee()" class="easyui-linkbutton btnlinkbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
                </div>
            </div>
        </div>
    </form>
    <input type="text" style="display: none" id="ids" />
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
    <style id="style1" type="text/css">
        table.innertable {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            border: none;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }

        table.sfxm tr.haveborder td table.innertable td {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            border-top: none;
            border-bottom: none;
            font-family: 'Microsoft YaHei';
        }

        #innerTable {
            margin: 0;
            padding: 0;
        }

        input {
            border: none;
            border-bottom: solid 1px #ccc;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
        }

        table.sfxm {
            margin-top: 5px;
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            font-size: 12px;
            font-family: 'Microsoft YaHei';
            font-weight: normal;
        }

            table.sfxm thead, table.sfxm tbody, table.sfxm tfoot {
                padding: 0;
            }


            table.sfxm tr.haveborder td, table.sfxm tr.haveborder th {
                text-align: center;
                border: solid #cccccc;
                border-width: 1px;
                padding: 0;
                font-weight: normal;
            }

            , table.sfxm tr.haveborder th {
                text-align: center;
                border: solid #cccccc;
                border-width: 1px 1px 0px 1px;
                padding: 0;
            }

            table.sfxm tfoot tr.haveborder th.lefttd {
                text-align: left;
            }



        .skdh {
            margin: 20px 0 0 0;
            text-align: right;
            font-weight: normal;
        }

            .skdh input {
                border: none;
                border-bottom: solid 1px #cccccc;
                width: 120px;
            }

        .systitle {
            font-size: 20px;
            text-align: center;
            font-weight: normal;
        }

        .sksj {
            font-size: 14px;
            text-align: center;
            font-weight: normal;
        }

        .fjdz {
            text-align: left;
            font-weight: normal;
            font-size: 12px;
        }

            .fjdz input {
                border: none;
                border-bottom: solid 1px #cccccc;
                width: 80%;
            }

        .khxm {
            text-align: right;
            font-weight: normal;
            font-size: 12px;
        }

            .khxm input {
                border: none;
                border-bottom: solid 1px #cccccc;
                width: 50%;
            }

        .clear {
            clear: both;
        }



        .shoudao {
            width: 50px;
            border: none;
            border-bottom: solid 1px #ccc;
        }

        table.skxx {
            width: 100%;
            border-collapse: collapse;
            border-spacing: 0;
            font-size: 12px;
        }

        table.heji {
            border-collapse: collapse;
            border-spacing: 0;
            width: 100%;
        }

            table.heji td {
                text-align: left;
                padding: 5px 0;
                border: solid 1px #ccc;
            }

        table.skxx td {
            text-align: left;
            font-weight: normal;
        }

            table.skxx td.skr {
                width: 10%;
            }

            table.skxx td.skfs, table.skxx td.zhekou {
                width: 5%;
            }

        .skr input, .skrq input, .skfs input, .zhekou input {
            width: 100%;
        }

        .shuoming {
            width: 100%;
            text-align: left;
            font-weight: normal;
        }

            .shuoming input {
                width: 95%;
            }

        .opeation {
            text-align: right;
            margin-top: 50px;
        }
    </style>
</asp:Content>
