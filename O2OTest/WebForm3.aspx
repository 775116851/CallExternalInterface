<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="O2OTest.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script language="javascript">
         function __doPostBack(eventTarget, eventArgument)
         {
             var theForm = document.Form1;     //指runat=server的form
             theForm.__EVENTTARGET.value = eventTarget;
             theFrom.__EVENTARGUMENT.value = eventArgument;
             theForm.submit();
         }
           </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="Button1" type="button" onclick="__doPostBack('Button1', '')" runat="server" value="button"  />
    </div>
    </form>
</body>

</html>
