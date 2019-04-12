<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteManager.aspx.cs" Inherits="Web.SiteManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="js/jquery-1.8.3.min.js"></script>
    <script src="js/easyui/jquery.easyui.min.js"></script>
    <script>
        $(function () {
            loadSites();
        })
        var count = 0;
        function loadSites() {
            $.post("CommHandler.ashx", { visit: "getsites" }, function (data) {
                var $html = '';
                $(".sitetable tr").remove();
                count = 0;
                $.each(data, function (index, item) {
                    count++;
                    $html += '<tr>';
                    $html += '<td style="width: 10%">';
                    $html += '<input type="checkbox" checked="checked" id="check_' + count + '" value="">'
                    $html += '</td>';
                    $html += '<td style="width: 5%">';
                    $html += count;
                    $html += '</td>';
                    $html += '<td style="width: 30%">';
                    $html += '<input type="text" id="name_' + count + '" value="' + item.SiteName + '">'
                    $html += '</td>';
                    $html += '<td style="width: 40%">';
                    $html += '<input type="text" id="path_' + count + '" value="' + item.SitePath + '">'
                    $html += '</td>';
                    $html += '<td style="width: 15%">';
                    $html += '<input type="text" id="time_' + count + '" value="' + item.LastUpdateTime + '">'
                    $html += '</td>';
                    $html += '</tr>';
                });
                $(".sitetable").append($html);
            }, 'json');
        }
        function addline() {
            count++;
            var $html = '';
            $html += '<tr>';
            $html += '<td style="width: 10%">';
            $html += '<input type="checkbox" checked="checked" id="check_' + count + '" value="">'
            $html += '</td>';
            $html += '<td style="width: 5%">';
            $html += count;
            $html += '</td>';
            $html += '<td style="width: 30%">';
            $html += '<input type="text" id="name_' + count + '" value="">'
            $html += '</td>';
            $html += '<td style="width: 40%">';
            $html += '<input type="text" id="path_' + count + '" value="">'
            $html += '</td>';
            $html += '<td style="width: 15%">';
            $html += '<input type="text" id="time_' + count + '" value="">'
            $html += '</td>';
            $html += '</tr>';
            $(".sitetable").append($html);
        }
        function savesite() {
            var alllist = [];
            var list = [];
            for (var i = 0; i < count; i++) {
                var allobj = {};
                var allname = $("#name_" + (i + 1)).val();
                var allpath = $("#path_" + (i + 1)).val();
                var alltime = $("#time_" + (i + 1)).val();
                allobj.SiteName = allname;
                allobj.SitePath = allpath;
                allobj.LastUpdateTime = alltime;
                alllist.push(allobj);
                if (document.getElementById("check_" + (i + 1)).checked) {
                    var obj = {};
                    var name = $("#name_" + (i + 1)).val();
                    var path = $("#path_" + (i + 1)).val();
                    var time = $("#time_" + (i + 1)).val();
                    obj.SiteName = name;
                    obj.SitePath = path;
                    obj.LastUpdateTime = time;
                    list.push(obj);
                }
            }
            $('#ff').form('submit', {
                url: 'CommHandler.ashx',
                onSubmit: function (param) {
                    param.visit = 'savesites';
                    param.content = JSON.stringify(list);
                    param.allcontent = JSON.stringify(alllist);
                },
                success: function (data) {
                    alert(data);
                    loadSites();
                }
            });
        }
        function deletesite() {
            var list = [];
            for (var i = 0; i < count; i++) {
                if (!document.getElementById("check_" + (i + 1)).checked) {
                    var obj = {};
                    var name = $("#name_" + (i + 1)).val();
                    var path = $("#path_" + (i + 1)).val();
                    var time = $("#time_" + (i + 1)).val();
                    obj.SiteName = name;
                    obj.SitePath = path;
                    obj.LastUpdateTime = time;
                    list.push(obj);
                }
            }
            if (confirm("确认删除?")) {
                $.post("CommHandler.ashx", { visit: "deletesites", content: JSON.stringify(list) }, function (data) {
                    alert(data);
                    loadSites();
                });
            }
        }
        function checkall() {
            if (document.getElementById("all").checked) {
                for (var i = 0; i < count; i++) {
                    document.getElementById("check_" + (i + 1)).checked = true;
                }
            }
            else {
                for (var i = 0; i < count; i++) {
                    document.getElementById("check_" + (i + 1)).checked = false;
                }
            }
        }
    </script>
    、
    <style>
        table.sitetitle, table.sitetable, table.fileup {
            width: 100%;
            border-spacing: 0;
            border-collapse: collapse;
            border: solid 1px #ccc;
        }

            table.sitetitle td, table.sitetable td, table.fileup td {
                border: solid 1px #ccc;
                padding: 10px;
            }

        input[type=text] {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="ff" runat="server">
        <div>
            <div style="text-align: center; margin-bottom: 10px;">
                <input type="button" onclick="addline()" value="新增" />
                <input type="button" onclick="savesite()" value="保存" />
                <input type="button" onclick="deletesite()" value="删除" />
            </div>
            <table class="sitetitle">
                <tr>
                    <td style="width: 10%">
                        <input type="checkbox" id="all" checked="checked" onclick="checkall()" value="0" />全选
                    </td>
                    <td style="width: 5%">序号
                    </td>
                    <td style="width: 30%">网站名称
                    </td>
                    <td style="width: 40%">网站路径
                    </td>
                    <td style="width: 15%">上次更新时间
                    </td>
                </tr>
            </table>
            <table class="sitetable">
            </table>
            <table class="fileup">
                <tr>
                    <td style="width: 30%">文件上传
                    </td>
                    <td style="width: 70%">
                        <asp:FileUpload ID="uploadzip" runat="server" />
                    </td>
                </tr>
            </table>
            <div style="text-align: center; margin-bottom: 10px;">
                <input type="button" onclick="addline()" value="新增" />
                <input type="button" onclick="savesite()" value="保存" />
                <input type="button" onclick="deletesite()" value="删除" />
            </div>
        </div>
    </form>
</body>
</html>
