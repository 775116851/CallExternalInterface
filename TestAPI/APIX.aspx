<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APIX.aspx.cs" Inherits="TestAPI.APIX" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        商户号：<asp:TextBox ID="txtSH" runat="server"></asp:TextBox>
        设备SN：<asp:TextBox ID="txtSN" runat="server" Width="516px"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="同步" />
        <asp:Button ID="btnCX" runat="server" Text="查询" OnClick="btnCX_Click" /><br />
        <asp:TextBox ID="txtResult" runat="server" ReadOnly="True" TextMode="MultiLine" Height="81px" Width="791px"></asp:TextBox>
        <br />
    </div>
    </form>
</body>
</html>
