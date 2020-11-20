<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%@ Register Src="~/LoginControl.ascx" TagPrefix="uc1" TagName="LoginControl" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .loginCss{
               margin-top: 14%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="loginCss">
        <uc1:LoginControl runat="server" ID="LoginControl" />
    </div>
    </form>
</body>
</html>
