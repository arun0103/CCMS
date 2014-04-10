<%@ Page Language="C#" Title="Add User" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="MyCCMS.addUser" MasterPageFile="~/Site.Master" %>

<asp:Content ContentPlaceHolderID="pageContent" ID="cntAddUser" runat="server">
    <div class="content-wrapper">
        <fieldset>
        <legend><b>Add User</b></legend>
        <table class="add_user_table">
            <tr>
                <td class="auto-style2">Email</td>
                <td class="tdInput">
                    <asp:TextBox ID="txtEmail" runat="server" BackColor="White"
                        BorderColor="#3366FF" MaxLength="50" Width="200px" Height="27px">
                    </asp:TextBox>
                </td>
                <td class="tdValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="You must enter Email" ForeColor="Red" ControlToValidate="txtEmail" EnableClientScript="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">First Name </td>
                <td class="tdInput">
                    <asp:TextBox ID="txtFirstname" runat="server" BackColor="White"
                        BorderColor="#3366FF" MaxLength="50" Width="200px" Height="27px"></asp:TextBox>
                </td>
                <td class="tdValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="You must enter First Name" ForeColor="Red" ControlToValidate="txtFirstname" EnableClientScript="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Last Name</td>
                <td class="tdInput">
                    <asp:TextBox ID="txtLastname" runat="server" BackColor="White"
                        BorderColor="#3366FF" MaxLength="50" Width="200px" Height="27px"></asp:TextBox>
                </td>
                <td class="tdValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="You must enter Last Name" ForeColor="Red" ControlToValidate="txtLastname" EnableClientScript="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Contact
                </td>
                <td>
                    <asp:TextBox ID="txtContact" runat="server" Width="200px" Font-Size="14px"
                        Height="24px" BorderColor="#3366ff"></asp:TextBox>
                </td>
                <td class="tdValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="You must enter Contact No." ForeColor="Red" ControlToValidate="txtContact" EnableClientScript="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Role</td>
                <td class="tdInput">
                    <asp:DropDownList ID="DropDownRole" runat="server" BorderColor="#3366FF" Width="100px" OnTextChanged="DropDownRole_TextChanged">
                        <asp:ListItem>--- Select ---</asp:ListItem>
                        <asp:ListItem>Admin</asp:ListItem>
                        <asp:ListItem>User</asp:ListItem>
                        <asp:ListItem>Faculty</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="tdValidator">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="You must enter role " ForeColor="Red" ControlToValidate="DropDownRole" EnableClientScript="False" InitialValue="--- Select ---"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style2">Active</td>
                <td class="tdInput">
                    <asp:CheckBox ID="chkActive" runat="server" Text="" />
                </td>

            </tr>

            <tr>
                <td></td>
                <td>
                    <table border="0" style="width: 100%">
                        <tr>
                            <td style="width: 10%">
                                <asp:Button ID="btnAdd" runat="server" Text="Add" BackColor="#CCCCFF" Height="33px" Width="57px" OnClick="Button1_Click" />
                                <%--<asp:Button ID="btnAdd" runat="server" OnClick="Button1_Click" Text="Add" Width="54px" ControlToValidate ="btnAdd"/>--%>
                            </td>
                            <td style="width: 40%;">
                                <asp:Button ID="btnReset" runat="server" Text="Reset" Height="33px" Width="57px" BackColor="#CCCCFF" OnClick="btnReset_Click" />
                            </td>
                        </tr>
                    </table>

                </td>
                <td></td>

            </tr>
        </table>
    </fieldset>
    </div>
</asp:Content>

<asp:Content ID="ViewFaculty" ContentPlaceHolderID="pageContent2" runat="server" Visible="false">
<div class="content-wrapper">
        <%--<asp:GridView ID="FacultyGridView" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField HeaderText="F_Id" />
                <asp:BoundField HeaderText="First Name" />
                <asp:BoundField HeaderText="Last Name" />
                <asp:BoundField HeaderText="Email" />
                <asp:BoundField HeaderText="User_Id" />
                <asp:BoundField HeaderText="Contact" />
                <asp:CheckBoxField HeaderText="Active" />
            </Columns>
        </asp:GridView>--%>

        <asp:GridView ID="FacultyGridView" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </asp:Content>