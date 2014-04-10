<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceReport.aspx.cs" Inherits="CCMS.AttendanceReport" MasterPageFile="~/Site.Master" %>


<asp:Content ID="EditPage" runat="server" ContentPlaceHolderID="pageContent">

    <div class="all-texts">
        <asp:Panel ID="panelWrapper" runat="server" Visible="True">

            <div id="left-part-user-info" style="float: left; width: 300px;">
                <table style="font-size: 14px" class="all-texts">   
                    <tr>
                        <td style="width: 154px">Faculty Name
                        </td>
                        <td style="width: 230px">
                            <asp:DropDownList ID="facultyV" runat="server" Font-Size="14px" Height="24px" CssClass="box" BorderColor="#3366FF" Width="150px" AutoPostBack="true" >  
                                                           
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 154px">Student's Name
                        </td>
                        <td style="width: 230px">
                            <asp:DropDownList ID="studentV" runat="server" Font-Size="14px" Height="24px" CssClass="box" BorderColor="#3366FF" Width="150px">
                                
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>                   
                            <td class="tdLegend" style="height: 35px">Start Date
                            </td>
                                <td class="inputColumn" style="width: 230px; height: 35px;">
                                <asp:TextBox ID="startDate" runat="server" Width="150px" Font-Size="14px"
                                    Height="24px" BorderColor="#3366ff"></asp:TextBox>
                                &nbsp;&nbsp;
                            </td>
                        <td style="height: 35px">

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


                    <asp:ImageButton ID="startDateCalendar_Button" runat="server"
                        ImageUrl="~/Images/button-calendar.gif" OnClick="startDateCalendar_Button_Click" />
                    </td>
                    </tr>
                    <tr>
                        <td class="tdLegend">&nbsp;End Date
                        </td>
                        <td class="inputColumn" style="width: 230px">
                            <asp:TextBox ID="endDate" runat="server" Width="150px" Font-Size="14px"
                                Height="24px" BorderColor="#3366ff"></asp:TextBox>
                            &nbsp;&nbsp;
                            </td>

                        <td class="inputColumn">
                                    <div style="position:absolute; margin-left:50px;">
                                        <asp:Calendar ID="endDateCalendar" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="endDateCalendar_SelectionChanged2" Visible="False" VisibleDate="2013-05-20" Width="220px">
                                            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                            <OtherMonthDayStyle ForeColor="#999999" />
                                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                            <TodayDayStyle BackColor="#99CCCC" BorderColor="Black" ForeColor="White" />
                                            <WeekendDayStyle BackColor="#CCCCFF" />
                                        </asp:Calendar>
                                    </div>
                            
                                    <asp:ImageButton ID="endDateCalendar_Button" runat="server" ImageUrl="~/Images/button-calendar.gif" OnClick="endDateCalendar_Button_Click" />
                    </tr>
                    <tr>
                    <td class="tdLegend">&nbsp;
                        </td>
                        
                         
                               <td>
                                   <asp:Button ID="showReport" runat="server" BackColor="" Font-Size="14px" Height="33px" OnClick="showReport_Click" Text="Show" Width="76px" />
                               </td>
                              
                        <td>
                    <asp:Button ID="clearBtn" runat="server" Text="Clear" Width="76px" 
                        Font-Size="14px" Height="34px" OnClick="clearBtn_Click" />
                          </td>  
                    </tr>



                </table>
               <div>
                <asp:Label ID ="lblText" runat="server" Visible ="false"/>
               </div>
                
            </div>
            
        </asp:Panel>
    </div>

</asp:Content>

