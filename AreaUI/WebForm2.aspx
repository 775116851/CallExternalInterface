<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="AreaUI.WebForm2" %>

<%@ Register Src="~/UI/Area.ascx" TagPrefix="uc1" TagName="Area" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery-1.7.1.js"></script>
    <script src="Scripts/share.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Area runat="server" ID="ucAreaA"/>
        <uc1:Area runat="server" ID="ucAreaB" AreaLevelSysNo="3" />
    </div>
    </form>
</body>
</html>
