<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControl.ascx.cs" Inherits="LoginControl" %>



<div align="center">
    <table  >
        <tr>
            <td>
                <asp:Label ID="lblUserName" runat="server" Text="UserName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" AutoComplete="off" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" AutoComplete="off" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  colspan="2">
                <asp:Label ID="lblAlertMessage" ForeColor="Red" runat="server" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click" />
            </td>
        </tr>
    </table> 
    
</div>
