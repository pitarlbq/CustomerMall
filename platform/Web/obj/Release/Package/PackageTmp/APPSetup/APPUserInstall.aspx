<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APPUserInstall.aspx.cs" Inherits="Web.APPSetup.APPUserInstall" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>APP员工端下载</title>
    <meta name="viewport" content="maximum-scale=1.0,minimum-scale=1.0,user-scalable=0,width=device-width,initial-scale=1.0" />
    <meta name="format-detection" content="telephone=no,email=no,date=no,address=no" />
    <script src="../js/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        $(function () {
            get_data();
        })
        function check_mobile() {
            var u = navigator.userAgent;
            var isAndroid = u.indexOf('Android') > -1 || u.indexOf('Adr') > -1; //android终端
            var isiOS = !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/); //ios终端
            if (isAndroid) {
                return "android";
            }
            if (isiOS) {
                return "ios";
            }
            return "";
        }
        var filepath_android = "";
        var filepath_ios = "";
        function get_data() {
            var mobile_type = check_mobile();
            var options = { visit: 'getappversionbyapptype', APPType: 2, VersionType: mobile_type };
            $.ajax({
                type: 'POST',
                dataType: 'json',
                data: options,
                url: "../Handler/SysSettingHandler.ashx",
                success: function (data) {
                    if (data.status) {
                        $('#label_version').html(data.version);
                        $('#label_time').html(data.time);
                        $('#label_desc').html(data.desc);
                        filepath_android = data.filepath_android;
                        filepath_ios = data.filepath_ios;
                    }
                }
            });
        }
        function do_download() {
            if (filepath_android != '') {
                window.location.href = filepath_android;
            }
            else if (filepath_ios != '') {
                window.location.href = filepath_ios;
            }
        }
    </script>
    <style>
        html, body {
            width: 100%;
            height: 100%;
            margin: 0 auto;
            background-color: #E8E8E8;
        }

        .title_box {
            width: 100%;
            background-color: #505050;
            color: #fff;
            padding: 2rem 0;
            margin-bottom: 1rem;
        }

        .title {
            text-align: center;
            font-size: 1.1rem;
            margin-bottom: 1rem;
        }

        .cover {
            text-align: center;
            margin-bottom: 20px;
        }

            .cover img {
                width: 5rem;
            }

        .version {
            text-align: center;
            margin-bottom: 1rem;
            font-size: 0.8rem;
        }

        .time {
            text-align: center;
            margin-bottom: 1rem;
            font-size: 0.8rem;
        }

        .summary_box {
            margin: 1rem 10px 3rem 10px;
            background: #fff;
            border: solid 1px #E8E8E8;
            border-radius: 0.5rem;
        }

            .summary_box .summary_title {
                text-align: left;
                background: #A8A8A8;
                color: #fff;
                font-size: 0.8rem;
                height: 2rem;
                line-height: 2rem;
                padding-left: 10px;
            }

            .summary_box .summary_detail {
                padding: 10px 10px 1rem 10px;
                font-size: 0.8rem;
            }

        .download_box {
            margin-top: 3rem;
            text-align: center;
            position: fixed;
            bottom: 0.5rem;
            left: 0;
            right: 0;
        }

            .download_box input.btn_download {
                background-color: #505050;
                border: none;
                border-radius: 2rem;
                margin: 0 auto;
                width: 80%;
                height: 2.2rem;
                line-height: 2.2rem;
                color: #fff;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="title_box">
            <div class="cover">
                <img src="../styles/images/app/app_user.png" />
            </div>
            <div class="title">永友物业员工端</div>
            <div class="version">
                版本
                <label id="label_version"></label>
            </div>
            <div class="time">
                更新时间 
                <label id="label_time"></label>
            </div>
        </div>
        <div class="summary_box">
            <div class="summary_title">版本说明</div>
            <div class="summary_detail">
                <label id="label_desc"></label>
            </div>
        </div>
        <div class="download_box">
            <input class="btn_download" type="button" onclick="do_download()" value="安装" />
        </div>
    </form>
</body>
</html>
