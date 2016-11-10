<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="优方电子券接口测试.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            
        </div>
        <table>
            <tr>
                <td colspan="2"><asp:Button ID="btnQuery" runat="server" Text="加  密" OnClick="btnQuery_Click" /></td>
                <td colspan="2"><asp:Button ID="btnDeQuery" runat="server" Text="解  密" OnClick="btnDeQuery_Click" style="height: 21px" /></td>
            </tr>
            <tr>
                <td style="text-align:right;">K1:</td>
                <td><asp:TextBox ID="txtK1" runat="server" Width="233px" Text="23Ro3U9x"></asp:TextBox></td>
                <td style="text-align:right;">K1:</td>
                <td><asp:TextBox ID="txtDeK1" runat="server" Width="233px" Text="23Ro3U9x"></asp:TextBox></td>
            </tr>
            <tr>
                <td>报文正文:</td>
                <td><asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Height="137px" Width="348px"></asp:TextBox></td>
                <td>密文报文:</td>
                <td><asp:TextBox ID="txtDeContent" runat="server" TextMode="MultiLine" Height="137px" Width="348px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>K2:</td>
                <td><asp:TextBox ID="txtK2" runat="server" Width="234px" Text="23Ro3U9x"></asp:TextBox></td>
                <td>K2:</td>
                <td><asp:TextBox ID="txtDeK2" runat="server" Width="234px" Text="23Ro3U9x"></asp:TextBox></td>
            </tr>
            <tr>
                <td>S2:</td>
                <td><asp:TextBox ID="txtS2" runat="server" TextMode="MultiLine" Height="74px" Width="345px"></asp:TextBox></td>
                <td>S2:</td>
                <td><asp:TextBox ID="txtDeS2" runat="server" TextMode="MultiLine" Height="74px" Width="345px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>S3:</td>
                <td><asp:TextBox ID="txtS3" runat="server" TextMode="MultiLine" Height="65px" Width="347px"></asp:TextBox></td>
                <td>M1:</td>
                <td><asp:TextBox ID="txtDeM1" runat="server" TextMode="MultiLine" Height="65px" Width="347px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>MD5(S3):</td>
                <td><asp:TextBox ID="txtMd5S3" runat="server" TextMode="MultiLine" Height="67px" Width="343px"></asp:TextBox></td>
                <td>S3:</td>
                <td><asp:TextBox ID="txtDeS3" runat="server" TextMode="MultiLine" Height="67px" Width="343px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>M1:</td>
                <td><asp:TextBox ID="txtM1" runat="server" TextMode="MultiLine" Height="67px" Width="343px"></asp:TextBox></td>
                <td>M2:</td>
                <td><asp:TextBox ID="txtDeM2" runat="server" TextMode="MultiLine" Height="67px" Width="343px"></asp:TextBox><asp:Label ID="lblDeEquest" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>R:</td>
                <td><asp:TextBox ID="txtR" runat="server" TextMode="MultiLine" Height="121px" Width="340px"></asp:TextBox></td>
                <td>R:</td>
                <td><asp:TextBox ID="txtDeR" runat="server" TextMode="MultiLine" Height="121px" Width="340px"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
