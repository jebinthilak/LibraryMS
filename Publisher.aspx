﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Library.master" AutoEventWireup="true" CodeFile="Publisher.aspx.cs" Inherits="Publisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="publishercss">
        <h2>Publisher Details</h2>
        <div id="divAdd" visible="false" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblPublisherName" runat="server" Text="Publisher Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPublisherName" runat="server" AutoComplete="off" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPublisherName" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" Text="Save" ValidationGroup="save" runat="server" OnClick="btnSave_Click" />
                        <asp:HiddenField ID="hdnPublisherID" runat="server" /> 
                    </td>
                </tr>

            </table>
        </div>
        <div id="divList" runat="server">
            <asp:Repeater ID="rptPublisher" runat="server" OnItemCommand="rptPublisher_ItemCommand" OnItemDataBound="rptPublisher_ItemDataBound" > 
                <HeaderTemplate>
                    <table cellspacing="0" rules="all" border="1">
                        <tr>
                            <th scope="col" style="width: 100px">Publisher ID
                            </th>
                            <th scope="col" style="width: 120px">Publisher Name
                            </th> 
                             <th scope="col" style="width: 70px">Action
                            </th> 
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblPublisherID" runat="server" Text='<%# Eval("fPublisherID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblPublisherName" runat="server" Text='<%# Eval("fPublisherName") %>' />
                        </td>
                        <td>
                            <asp:ImageButton ID="lnkEdit" Visible="false" Height="20px" runat="server" ImageUrl="~/asset/img/ico-edit.svg" ToolTip="Edit"
                                CommandName="EditData" CommandArgument='<%#Eval("SYS_ID")%>'></asp:ImageButton>
                            <asp:ImageButton ID="lnkDelete" Visible="false" Height="20px" runat="server" ImageUrl="~/asset/img/ico-delete.svg" ToolTip="Delete"
                                CommandName="DeleteData" CommandArgument='<%#Eval("SYS_ID")%>'></asp:ImageButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>

    <script>
        function ErrorSwal(msg) {
            Swal.fire({
                position: 'center',
                type: 'warning',
                title: msg,
                showConfirmButton: true
            })
        }

        function SuccessSwal(msg) {
            //  alert('ouote success');
            Swal.fire({
                position: 'center',
                type: 'success',
                title: msg,
                showConfirmButton: true
            })
        }
                </script>
</asp:Content>

