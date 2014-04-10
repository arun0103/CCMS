<%@ Page Title="Add Class" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewBatch.aspx.cs" Inherits="CCMS.AddNewBatch" %>

<asp:Content runat="server" ID="pageContent" ContentPlaceHolderID="pageContent">
    <div class="content-wrapper">
        <fieldset>
            <legend><b>Add Class</b></legend>
            <table class="add_new_class">
                <tr>
                    <td class="tdLegend">Batch
                    </td>
                    <td class="inputColumn">
                        <asp:TextBox ID="batchName" runat="server" Width="150px" Font-Size="14px" Text=""
                            Height="24px" BorderColor="#3366ff"></asp:TextBox>
                    </td>

                    <td class="tdLegend">Year
                    </td>
                    <td class="inputColumn">
                        <asp:TextBox ID="year" runat="server" Width="150px" Font-Size="14px" Text=""
                            Height="24px" BorderColor="#3366ff"></asp:TextBox>
                    </td>
                    </tr>
                <tr>

                    <td class="tdLegend">Semester</td>
                    <td class="inputColumn">
                    <asp:DropDownList ID="ddl_semester" runat="server" Width="155px" BorderColor="#3366FF" Height="24px">
                        <asp:ListItem>I</asp:ListItem>
                        <asp:ListItem>II</asp:ListItem>
                        <asp:ListItem>III</asp:ListItem>
                        <asp:ListItem>IV</asp:ListItem>
                        <asp:ListItem>V</asp:ListItem>
                        <asp:ListItem>VI</asp:ListItem>
                        <asp:ListItem>VII</asp:ListItem>
                        <asp:ListItem>VIII</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td class="tdLegend">Section</td>
                    <td class="inputColumn">
                    <asp:DropDownList ID="ddl_section" runat="server" Width="155px" BorderColor="#3366FF" Height="24px" > 
                        <asp:ListItem>A</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    
                    <td class="tdLegend">Start Date
                    </td>
                    <td class="inputColumn">
                        <asp:TextBox ID="startDate" runat="server" Width="150px" Font-Size="14px"
                            Height="24px" BorderColor="#3366ff"></asp:TextBox>
                        &nbsp;&nbsp;
                    <asp:ImageButton ID="startDateCalendar_Button" runat="server"
                        ImageUrl="~/Images/button-calendar.gif" OnClick="startDateCalendar_Button_Click" />
                    </td>

                    <td class="tdLegend">End Date
                    </td>
                    <td class="inputColumn">
                        <asp:TextBox ID="endDate" runat="server" Width="150px" Font-Size="14px"
                            Height="24px" BorderColor="#3366ff"></asp:TextBox>
                        &nbsp;&nbsp;
                    <asp:ImageButton ID="endDateCalendar_Button" runat="server"
                        ImageUrl="~/Images/button-calendar.gif" OnClick="endDateCalendar_Button_Click" />
                    </td>
                    </tr>
                <tr>
                    <td class="tdLegend">Active
                    </td>
                    <td>
                        <asp:CheckBox ID="activeCB" runat="server" />
                    </td>
                    
                </tr>
                <tr>
              
                    <td class="inputColumn" colspan="2">
                        <div style="position:absolute; margin-left:50px;">
                        <asp:Calendar ID="startDateCalendar" runat="server"
                            BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#003399" Height="200px" VisibleDate="2013-05-20" Width="220px"
                            OnSelectionChanged="startDateCalendar_SelectionChanged1"
                            Visible="False">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px"
                                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" BorderColor="Black" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                        </div>
                    </td>
                    
                    <td class="inputColumn" colspan="2">
                        <div style="position:absolute; margin-left:50px;">
                        <asp:Calendar ID="endDateCalendar" runat="server"
                            BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1"
                            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt"
                            ForeColor="#003399" Height="200px" Width="220px"
                            OnSelectionChanged="endDateCalendar_SelectionChanged2"
                            Visible="False">
                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px"
                                Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                            <TodayDayStyle BackColor="#99CCCC" BorderColor="Black" ForeColor="White" />
                            <WeekendDayStyle BackColor="#CCCCFF" />
                        </asp:Calendar>
                            </div>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="addBtn" runat="server" Text="Add" Width="76px" CssClass="allbutton"
                            OnClientClick="return confirm('Are you sure, you want to ADD Data?')"
                            Font-Size="14px" Height="34px" OnClick="addBtn_Click" />
                        &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="clearBtn" runat="server" Text="Clear" Width="76px" CssClass="allbutton"
                        Font-Size="14px" Height="34px" OnClick="clearBtn_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
