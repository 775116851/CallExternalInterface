<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AreaUI.WebForm1" ValidateRequest="false" %>

<%@ Register src="UI/Area360.ascx" tagname="Area360" tagprefix="uc1" %>
<%@ Register Src="~/UI/Area.ascx" TagPrefix="uc1" TagName="Area" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="Scripts/jquery-1.7.1.min.js"></script>
    <script src="Scripts/jquery.autocomplete.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Area360 ID="ucArea360" DivWidth="150px" runat="server" />
    
        <asp:TextBox ID="txtY" runat="server" Height="55px" TextMode="MultiLine" Width="598px"></asp:TextBox>
        <asp:Button ID="btnZH" runat="server" OnClick="btnZH_Click" Text="转换" Width="65px" />
        <br />
        <br />
        <uc1:Area runat="server" id="Area" />
    </div>
        <asp:TextBox ID="txtM" runat="server" Height="105px" TextMode="MultiLine" Width="593px"></asp:TextBox>
    </form>
</body>
</html>
