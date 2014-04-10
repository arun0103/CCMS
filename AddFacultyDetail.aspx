<%@ Page Title="AddFacultyDetail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFacultyDetail.aspx.cs" Inherits="CCMS.AddFacultyDetails" %>

<asp:Content runat="server" ID="pageContent" ContentPlaceHolderID="pageContent">
    <fieldset style="width: 96.3%;">
        <legend><b>Add Faculty</b></legend>
        <table class="add_faculty">
            <%--<tr>
                        <td class="auto-style1">F_Id
                        </td>
                        <td>
                            <asp:TextBox ID="f_Id" runat="server" Width="200px" Font-Size="14px"
                                Height="24px" BorderColor="#3366ff"></asp:TextBox>
                        </td>
                    </tr>--%>
            <tr>
                <td class="auto-style2">First Name
                </td>
                <td>
                    <asp:TextBox ID="firstName" runat="server" Width="200px" Font-Size="14px"
                        Height="24px" BorderColor="#3366ff"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Last Name
                </td>
                <td>
                    <asp:TextBox ID="lastName" runat="server" Width="200px" Font-Size="14px"
                        Height="24px" BorderColor="#3366ff"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="200px" Font-Size="14px"
                        Height="24px" BorderColor="#3366ff"></asp:TextBox>
                </td>
                <td class="tdValidator">
                    <asp:RequiredFieldValidator ID="EmailFieldValidator" runat="server" ErrorMessage="You must enter Email" ForeColor="Red" ControlToValidate="txtEmail" EnableClientScript="False"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                        <td class="auto-style1">User_Id
                        </td>
                        <td>
                            <asp:TextBox ID="user_Id" runat="server" Width="200px" Font-Size="14px"
                                Height="24px" BorderColor="#3366ff"></asp:TextBox>
                        </td>
                    </tr>--%>
            <tr>
                <td class="auto-style2">Contact
                </td>
                <td>
                    <asp:TextBox ID="contact" runat="server" Width="200px" Font-Size="14px"
                        Height="24px" BorderColor="#3366ff"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Active
                </td>
                <td>
                    <asp:CheckBox ID="activeCB" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="addFacultyBtn" runat="server" Text="Add" Width="76px"
                        OnClientClick="return confirm('Are you sure, you want to ADD Faculty Data?')"
                        CssClass="allbutton" OnClick="addBtn_Click" />
                </td>
                <td>
                    <asp:Button ID="clearBtn" runat="server" Text="Clear" Width="76px"
                        CssClass="allbutton" OnClick="clearBtn_Click1" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="updateMsg" runat="server" Text="Record is added successfully" ForeColor="Green" Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
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
   