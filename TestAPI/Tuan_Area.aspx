<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tuan_Area.aspx.cs" Inherits="TestAPI.Tuan_Area" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="360城市数据" OnClick="Button1_Click" />
    
        <asp:Button ID="Button2" runat="server" Text="360区县商圈" OnClick="Button2_Click" />
    
        <asp:Button ID="Button3" runat="server" Text="360分类数据导入" OnClick="Button3_Click" />
    
        <asp:Button ID="Button4" runat="server" Text="360区域数据整体导入" OnClick="Button4_Click" />
    
    </div>
    </form>
</body>
</html>
