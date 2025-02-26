﻿<%@ Page Title="viewFaculty" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFaculty.aspx.cs" Inherits="CCMS.ViewFaculty" %>

<asp:Content runat="server" ID="pageContent" ContentPlaceHolderID="pageContent">
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