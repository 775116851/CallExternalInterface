<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T1.aspx.cs" Inherits="AJAXTest.T1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript">
        function keyAJ1() {
            $.ajax({
                type: 'POST',
                //contentType: "application/json",
                url: "AjaxHandler.aspx",
                data: { Action: "TLA" ,FF:"123"},
                //dataType: 'json',
                success: function (result) {
                    alert("成功："+result);
                },
                error: function (result) {
                    alert("失败：" + result);
                },
                complete: function (result) {
                    //alert("FK：" + result);
                }
            });
        }
        function keyAJ2() {
            $.ajax({
                type: 'POST',
                contentType: "application/json;charset=utf-8",
                url: "T1.aspx/TLBTest",
                data: "{ Action: 'TLB', FF: '123' }",
                dataType: 'json',
                success: function (result) {
                    alert("成功：" + result.d);
                },
                error: function (result) {
                    alert("失败：" + result);
                },
                complete: function (result) {
                    //alert("FK：" + result);
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="btnAJ1" type="button" value="远程" onclick="keyAJ1()" />
        <input id="btnAJ2" type="button" value="本地" onclick="keyAJ2()" />
    </div>
    </form>
</body>
</html>
