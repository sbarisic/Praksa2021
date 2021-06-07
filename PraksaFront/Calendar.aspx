<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="PraksaFront.Calendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="content/css/Calendar.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            
            <asp:HiddenField ID="hdnField" runat="server" />
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panl1" TargetControlID="hdnField"
                    CancelControlID="Button2" BackgroundCssClass="Background">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                    <table class="dataTable-table">
                        <th>Radna akcija</th><th>Opis</th><th>Vrijeme</th><th>Lokacija</th><th>Obveznost</th><th>Prisutnost</th>
                        <tr>
                            <td>Kosnja trave</td><td>Kosnja trave po parku</td><td>17:20</td><td>Bjelovar</td><td>Obavezno</td><td>
                                <asp:Button ID="yesButton" CssClass="workButton" runat="server" Text="Dolazim"
                                      />
                                <asp:Button ID="noButton" CssClass="workButton" runat="server" Text="Ne dolazim"
                                      />
                                <asp:Button ID="maybeButton" CssClass="workButton" runat="server" Text="Mozda dolazim"
                                     /></td>
                        </tr>
                    </table>
                    <br />
                    <asp:Button ID="Button2" runat="server" Text="Zatvori" />
                </asp:Panel>


        <div style="width: 800px; height: 500 auto; margin-top: 80px; margin-bottom: 80px; margin-right: 80px; margin-left: 80px;">
            <asp:Calendar
                ID="Calendar1"
                runat="server"
                BackColor="White"
                BorderColor="Black"
                BorderStyle="Solid"
                CellSpacing="1"
                Font-Names="Verdana"
                OnDayRender="Calendar1_DayRender"
                OnSelectionChanged="Selection_Change"
                Font-Size="9pt"
                ForeColor="Black"
                Height="500px"
                NextPrevFormat="ShortMonth"
                Width="800px"
                ShowGridLines="true">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="black" Height="8pt" />
                <DayStyle BackColor="White" BorderColor="black" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="right" VerticalAlign="top" />
                <NextPrevStyle Font-Bold="True" Font-Size="10pt" ForeColor="White" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="black" ForeColor="White" />
                <TitleStyle BackColor="black" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                <TodayDayStyle BackColor="black" ForeColor="White" />
            </asp:Calendar>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>

</asp:Content>
