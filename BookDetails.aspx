<%@ Page Title="" Language="C#" MasterPageFile="~/Library.master" AutoEventWireup="true" CodeFile="BookDetails.aspx.cs" Inherits="Book" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Bookcss">
        <h2>Book Details</h2>
        <div id="divAdd" visible="false" runat="server">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblBookName" runat="server" Text="Book Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBookName" runat="server" AutoComplete="off" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookName" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblBookCategory" runat="server" Text="Book Category"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpBookCategory" runat="server" AutoComplete="off" MaxLength="50"></asp:DropDownList>
                        <asp:RequiredFieldValidator ValidationGroup="save" ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpBookCategory" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAuthor" runat="server" Text="Author"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpAuthor" runat="server" AutoComplete="off"></asp:DropDownList>
                        <asp:RequiredFieldValidator ValidationGroup="save" ID="RequiredFieldValidator2" runat="server" ControlToValidate="drpAuthor" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPublisher" runat="server" Text="Publisher"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="drpPublisher" runat="server" AutoComplete="off" MaxLength="50"></asp:DropDownList>
                        <asp:RequiredFieldValidator ValidationGroup="save" ID="RequiredFieldValidator3" runat="server" ControlToValidate="drpPublisher" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblbookCountDesc" runat="server" Text="Book Count"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtbookCount" runat="server" TextMode="Number" AutoComplete="off" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="save" ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtbookCount" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" Text="Save" ValidationGroup="save" runat="server" OnClick="btnSave_Click" />
                        <asp:HiddenField ID="hdnBookID" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divList" runat="server">
            <asp:Repeater ID="rptBook" runat="server" OnItemCommand="rptBook_ItemCommand" OnItemDataBound="rptBook_ItemDataBound">
                <HeaderTemplate>
                    <table cellspacing="0" rules="all" border="1">
                        <tr>
                            <th scope="col" style="width: 100px">Book ID
                            </th>
                            <th scope="col" style="width: 120px">Book Name
                            </th>
                            <th scope="col" style="width: 120px">Category
                            </th>
                            <th scope="col" style="width: 120px">Author
                            </th>
                            <th scope="col" style="width: 120px">Publisher
                            </th>
                            <th scope="col" style="width: 120px">Book Count
                            </th>
                            <th scope="col" style="width: 70px">Action
                            </th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblBookID" runat="server" Text='<%# Eval("fBookID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblBookName" runat="server" Text='<%# Eval("fBookName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblBookCategoryDesc" runat="server" Text='<%# Eval("fBookCategoryDesc") %>' />
                            <asp:Label ID="lblBookCategoryID" Visible="false" runat="server" Text='<%# Eval("fBookCategoryID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblAuthorName" runat="server" Text='<%# Eval("fAuthorName") %>' />
                             <asp:Label ID="lblAuthorID" Visible="false" runat="server" Text='<%# Eval("fAuthorID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblPublisherName" runat="server" Text='<%# Eval("fPublisherName") %>' />
                             <asp:Label ID="lblPublisherID" Visible="false" runat="server" Text='<%# Eval("fPublisherID") %>' />
                        </td>
                        <td>
                            <asp:Label ID="lblBookCount" runat="server" Text='<%# Eval("fBookCount") %>' />
                        </td>
                        <td>
                            <asp:ImageButton ID="lnkEdit" Visible="false" Height="20px" runat="server" ImageUrl="~/asset/img/ico-edit.svg" ToolTip="Edit"
                                CommandName="EditData" CommandArgument='<%#Eval("SYS_ID")%>'></asp:ImageButton>
                            <asp:ImageButton ID="lnkDelete" Visible="false" Height="20px" runat="server" ImageUrl="~/asset/img/ico-delete.svg" ToolTip="Delete"
                                CommandName="DeleteData" CommandArgument='<%#Eval("SYS_ID")%>'></asp:ImageButton>
                             <asp:Button ID="btnLend"  Height="20px" runat="server"   ToolTip="Delete" Text="Lend"
                                CommandName="LendBook" CommandArgument='<%#Eval("fBookID")%>'></asp:Button>
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

