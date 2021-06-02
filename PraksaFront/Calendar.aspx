<%@ Page Title="Kalendar" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="PraksaFront.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE html>
    <head>
        <title>Kalendar</title>
    </head>
    <body>
        <form id="form1" runat="server">

            <asp:Calendar id="calendar1" runat="server">

                <OtherMonthDayStyle ForeColor="LightGray">
                </OtherMonthDayStyle>

                <TitleStyle BackColor="Blue"
                     ForeColor="White">
                </TitleStyle>

                <DayStyle BackColor="gray">
                </DayStyle>

                <SelectedDayStyle BackColor="LightGray"
                             Font-Bold="True">
                </SelectedDayStyle>

            </asp:Calendar>
        </form>
    </body>
    </html>
</asp:Content>
