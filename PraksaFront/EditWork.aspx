﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="EditWork.aspx.cs" Inherits="PraksaFront.EditWork" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<head runat="server" />
    <title></title>
    <link rel="stylesheet" href="content/css/home.css" />
    <script type="text/javascript">
        function checkDate(sender, args) {
            if (sender._selectedDate < new Date()) {
                alert("Ne možete odabrati dan u prošlosti.");
                sender._selectedDate = new Date();
                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
            }
    }
    function callParentWindowHideMethod() {
        if (window.parent.hideEditModalPopup) {
            window.parent.hideEditModalPopup();
        }
    }
    </script>
</head>
<body style="background-color: white;">
    <form id="f1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
        <div>
            <div class="card-body">
                <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                    <div class="dataTable-container">
                        <table class="dataTable-table">
                            <tr>
                                <th width="200px">
                                    <asp:Label ID="Label1" runat="server" Text="Radna akcija"></asp:Label>
                                </th>

                                <td>
                                    <asp:TextBox Width="300px" Placeholder="Radna akcija..." ID="workText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label2" runat="server" Text="Opis"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" TextMode="MultiLine" Placeholder="Opis..." ID="descriptionText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label3" runat="server" Text="Datum"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" Placeholder="Datum..." ID="dateText" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dateText"
                                        OnClientDateSelectionChanged="checkDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label4" runat="server" Text="Vrijeme"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" TextMode="Time" Placeholder="Vrijeme..." ID="timeText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label5" runat="server" Text="Lokacija"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" Placeholder="Lokacija..." ID="locationText" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label6" runat="server" Text="Obveznost"></asp:Label>
                                </th>
                                <td>
                                    <asp:RadioButtonList ID="obligationButton" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
                                        <asp:ListItem Value="1">Obavezno</asp:ListItem>
                                        <asp:ListItem Value="0">Nije obavezno</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div class="text-center">
                                        <asp:Button OnCommand="Submit_Command" Style="display: inline-block; text-align: center; margin-right: 10px;" ID="AddWorkButton" runat="server" Text="Potvrdi" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>

</body>
