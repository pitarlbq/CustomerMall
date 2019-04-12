<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractTemplateSelect.aspx.cs" Inherits="Web.Contract.ContractTemplateSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>选择打印模板</title>
    <link href="../styles/page/initialdefault.css?t=<%=base.getToken() %>" rel="stylesheet" />
    <style>
        .ModuleBox {
            margin: 30px 50px 0px 50px;
        }

        .ModuleDesc {
            text-align: center;
            width: 150px;
            margin: 0 auto;
            margin-top: 150px;
        }

        .table_container a {
            float: left;
            border: solid 1px #ccc;
            margin: 5px;
            height: 220px;
        }

            .table_container a:hover {
                text-decoration: none;
            }
    </style>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script>
        var ID = 0, print_can_edit;
        $(function () {
            ID = Number("<%=this.ID%>");
            print_can_edit = Number("<%=this.print_can_edit%>");
        })
        function doPrint(TemplateID) {
            if (print_can_edit == 1) {
                var iframe = window.SERVERPATH + "/Contract/ContractDetailSummary.aspx?ID=" + ID + "&templateid=" + TemplateID;
                do_open_dialog('打印预览', iframe);
            }
            else {
                do_print(TemplateID);
            }
        }
        function do_print(TemplateID) {
            MaskUtil.mask('body', '打印中');
            var iframe = document.getElementById("myframe");
            var url = window.SERVERPATH + "/Contract/ContractDetailPrint.aspx?contractid=" + ID + "&templateid=" + TemplateID;
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
        function LODOPPrint(strHtml) {
            var LODOP = null;
            try {
                LODOP = getLodop();
                if ((LODOP != null) && (typeof (LODOP.VERSION) != "undefined")) {
                    LODOP.PRINT_INITA(10, 10, 754, 453, "打印合同");
                    //LODOP.SET_PRINT_PAGESIZE(0, 2100, 2970, "A4");
                    LODOP.ADD_PRINT_HTM('2%', '3%', "94%", "93%", strHtml);
                    LODOP.ADD_PRINT_LINE(414, 23, 413, 725, 0, 1);
                    LODOP.SET_PRINT_STYLEA(0, "ItemType", 1);
                    LODOP.SET_PRINT_STYLEA(0, "Horient", 3);
                    LODOP.SET_PRINT_STYLEA(0, "Vorient", 1);
                    LODOP.ADD_PRINT_TEXT(421, '46%', 165, 22, "第#页/共&页");
                    LODOP.SET_PRINT_STYLEA(0, "ItemType", 2);
                    LODOP.SET_PRINT_STYLEA(0, "Horient", 1);
                    LODOP.SET_PRINT_STYLEA(0, "Vorient", 1);
                    LODOP.PREVIEW();
                }
                else {
                    alert("Error:该浏览器不支持打印插件!");
                }
            } catch (err) {
                alert("Error:本机未安装或需要升级!");
            }
        }
        function do_close() {
            parent.do_close_dialog(function () {
                parent.$('#tt_chargesummary').datagrid("reload");
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="operation_box">
        <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
    </div>
    <div class="table_container">
        <div style="padding: 0 50px;">
            <asp:Repeater runat="server" ID="rptSummary">
                <ItemTemplate>
                    <a href="#" onclick="doPrint('<%#Eval("ID") %>')">
                        <div class="ModuleBox htgl">
                            <%#Eval("TemplateName") %>
                        </div>
                        <div class="ModuleDesc">
                            <%#Eval("TemplateSummary") %>
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>
            <div style="clear: both;"></div>
        </div>
    </div>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
