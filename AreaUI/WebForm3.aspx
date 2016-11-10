<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="WebForm3.aspx.cs" Inherits="AreaUI.WebForm3" %>

<%@ Register Src="~/UI/VCategory.ascx" TagPrefix="uc1" TagName="VCategory" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/share.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btnA").click(function () {
                CategoryTypeChangeVCategory_ddlCategoryType(1);
            });
            $("#btnB").click(function () {
                CategoryTypeChangeVCategory_ddlCategoryType(2);
            });
            $("#btnC").click(function () {
                $("#VCategory_ddlCategoryType").val(2);
            });
        });
        function show() {
            alert("123");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:VCategory runat="server" ID="VCategory" CategoryTypeSysNo="1" onC1Change="show()" />
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 21px" Text="服务器购物" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="服务器活动" />
        <input id="btnA" type="button" value="客户端购物" />
        <input id="btnB" type="button" value="客户端活动" />
        <input id="btnC" type="button" value="XXX" />
    </form>
</body>
</html>
