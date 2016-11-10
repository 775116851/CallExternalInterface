<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CacheInfo.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><asp:Label ID="labClient" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="labServer" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td><asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" /></td>
                <td><asp:Button ID="Button2" runat="server" Text="修改" OnClick="Button2_Click" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px"></asp:DetailsView>
                </td>
            </tr>
        </table>
        
    
    </div>
    </form>
</body>
</html>
