<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CCMS.Login" %>

<asp:Content runat="server" ID="pageContent" ContentPlaceHolderID="pageContent">
    <div class="content-wrapper">
        <table style="width: 426px; margin-left: 50%">
            <tr>
                <td style="height: 280px">
                    <p class="pageName">Login</p>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">User Name</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                <asp:TextBox ID="txtUserName" runat="server" BackColor="White"
                                    BorderColor="#3366FF" MaxLength="50" Width="200px" Height="27px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ErrorMessage="You must enter username....!!" ForeColor="Red" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="labels">Password</td>
                        </tr>
                        <tr>
                            <td class="style10">
                                <asp:TextBox ID="txtPassword" runat="server" BackColor="White"
                                    BorderColor="#3366FF" MaxLength="50" Width="200px" TextMode="Password"
                                    Height="27px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="You must enter Password....!!" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnLogin" runat="server" BackColor="#CCCCFF" Text="Login" Height="33px" Width="57px" OnClick="UserLogin" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
