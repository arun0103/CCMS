<%@ Page Language="C#" Title="Check In/Out" AutoEventWireup="true" CodeBehind="TimeEntry.aspx.cs" Inherits="CCMS.WebForm1" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="pageContent" ContentPlaceHolderID="pageContent">
    <style type="text/css">
        .controlcolumn {
            text-align: right;
            border: 1px solid green;
            width: 10%;
            height: 10%;
            font-family: 'Arial Rounded MT';
            font-size: large;
            margin-left: 18%;
            margin-right: 25%;
            margin-top: 2%;
            margin-bottom: 0%;
            padding: 5px 5px 0px 5px;
            background-color: #e2e2e2;
            -moz-border-radius: 20px;
            border-radius: 20px;
        }

        .button {
            margin: 100px;
            border: 1px solid green;
            -moz-border-radius: 8px;
            border-radius: 8px;
            font-size: large;
            width: 100px;
            height: 50px;
        }
    </style>
    <table class="controlcolumn">
        <tr style="height: 100px">
            <td></td>
            <td style="text-align: right;">
                <asp:Label ID="LblWelcome" runat="server"></asp:Label>
                <br />
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Timer ID="TimerTime" runat="server" Interval="1000">
                </asp:Timer>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="LblDate" runat="server"></asp:Label>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TimerTime" EventName="Tick" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Lblcheckin" runat="server"></asp:Label>
                <asp:Button ID="btncheckin" runat="server" Text="Check In" CssClass="button" BackColor="#1c4877" OnClick="checkIn_Click" ForeColor="White" />
            </td>
            <td>
                <asp:Label ID="Lblcheckout" runat="server"></asp:Label>
                <asp:Button ID="btncheckout" runat="server" Text="Check Out" CssClass="button" BackColor="#1c4877" OnClick="checkOut_Click" ForeColor="White" Enabled="false" />
            </td>
        </tr>
    </table>
</asp:Content>
