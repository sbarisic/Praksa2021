<%@ Page Title="Kalendar" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="PraksaFront.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <!DOCTYPE html>
    <head>
        <title>Kalendar</title>
    </head>
    <body>
        <form id="form2" runat="server">
        <div style="width:800px; height: 500 auto; margin-top: 80px; margin-bottom: 80px; margin-right: 80px; margin-left: 80px;">
        <asp:Calendar 
            ID="Calendar1"
            runat="server"
            BackColor="White"
            BorderColor="Black"
            BorderStyle="Solid"
            CellSpacing="1"
            Font-Names="Verdana"
            Font-Size="9pt"
            ForeColor="Black"
            Height="500px"
            NextPrevFormat="ShortMonth"
            Width=800px 
            ShowGridLines="true">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="black" Height="8pt" />
            <DayStyle BackColor="White" BorderColor="black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="right" VerticalAlign="top"/>
            <NextPrevStyle Font-Bold="True" Font-Size="10pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="black" ForeColor="White" />
            <TitleStyle BackColor="black" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
            <TodayDayStyle BackColor="black" ForeColor="White" />
        </asp:Calendar>
        </div>
        </form>

       
    </body>
    </html>
</asp:Content>