<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true" CodeBehind="ContractDetailSummary.aspx.cs" Inherits="Web.Contract.ContractDetailSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/ueditor.all.js?v5"> </script>
    <script type="text/javascript" charset="utf-8" src="../js/ueditor/lang/zh-cn/zh-cn.js"></script>
    <script src="../js/Lodop/LodopFuncs.js?t=<%=base.getToken() %>"></script>
    <script type="text/javascript">
        $(function () {
            createEditor();
            setTimeout(function () {
                setContent();
            }, 1000);
        });
        function setContent() {
            var content = $("#<%=this.hdContent.ClientID%>").val();
            ue.setContent(content, false);
        }
        function closeWin() {
            parent.$("#winprint").window("close");
        }
        var ue;
        function setContent() {
            var content = $("#<%=this.hdContent.ClientID%>").val();
            ue.setContent(content, false);
        }
        function createEditor() {
            window.SERVERAPPLICATION = "<%=Web.WebUtil.getApplicationPath()%>";
            ue = UE.getEditor('tdContent', {
                toolbars: [["fullscreen", "source", "|", "undo", "redo", "|", "bold", "italic", "underline", "fontborder", "strikethrough", "superscript", "subscript", "removeformat", "formatmatch", "autotypeset", "blockquote", "pasteplain", "|", "forecolor", "backcolor", "insertorderedlist", "insertunorderedlist", "selectall", "cleardoc", "|", "rowspacingtop", "rowspacingbottom", "lineheight", "|", "customstyle", "paragraph", "fontfamily", "fontsize", "|", "directionalityltr", "directionalityrtl", "indent", "|", "justifyleft", "justifycenter", "justifyright", "justifyjustify", "|", "touppercase", "tolowercase", "|", "link", "unlink", "anchor", "|", "emotion", "|", "horizontal", "date", "time", "spechars", "|", "preview", 'simpleupload', "help"
                ]
                ],
                autoHeightEnabled: false,
                autoFloatEnabled: true,
                zIndex: 1
            });
        }
        function dosave() {
            var isValid = $('#<%=this.ff.ClientID%>').form('enableValidation').form('validate');
            if (!isValid) {
                return;
            }
            var ContractID = "<%=this.ContractID%>";
            var TemplateID = "<%=this.TemplateID%>";
            var HTMLContent = ue.getContent();
            MaskUtil.mask('body', '提交中');
            var options = { visit: 'savecontractprintcontent', ContractID: ContractID, TemplateID: TemplateID, HTMLContent: HTMLContent };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: window.SERVERPATH + '/Handler/ContractHandler.ashx',
                data: options,
                success: function (data) {
                    MaskUtil.unmask();
                    if (data.status) {
                        do_print(data.ID);
                        return;
                    }
                    show_message('系统错误', 'error');
                }
            });
        }
        function do_print(ID) {
            MaskUtil.mask('body', '打印中');
            var iframe = document.getElementById("myframe");
            var url = window.SERVERPATH + "/Contract/ContractDetailPrint.aspx?ID=" + ID;
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
            parent.do_close_dialog();
        }
    </script>
    <style>
        table.info {
            width: 100%;
            border: solid 1px #ccc;
            border-spacing: 0;
            border-collapse: collapse;
        }

            table.info td {
                border: solid 1px #ccc;
                padding: 10px;
                text-align: left;
                width: 35%;
            }

                table.info td:nth-child(2n-1) {
                    text-align: right;
                    width: 15%;
                }

        input[type=text] {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <form id="ff" runat="server" method="post" enctype="multipart/form-data">
        <div class="operation_box">
            <a href="javascript:void(0)" onclick="dosave()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-print'">打印</a>
            <a href="javascript:void(0)" onclick="do_close()" class="easyui-linkbutton btntoolbar" data-options="plain:true,iconCls:'icon-close'">关闭</a>
        </div>
        <div class="table_container">
            <script id="tdContent" type="text/plain" style="width: 100%; height: 80%;">
            </script>
            <asp:HiddenField runat="server" ID="hdContent" />
        </div>
    </form>
    <iframe name="myiframe" id="myframe" style="display: none;" src="" width="100%" height="100%"></iframe>
</asp:Content>
