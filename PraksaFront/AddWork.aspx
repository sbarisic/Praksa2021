<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AddWork.aspx.cs" Inherits="PraksaFront.AddWork" %>

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
        <div class="card-header" style="border:1px solid rgba(0,0,0,0.1)">
            <h3><asp:Label ID="lblHeader" runat="server" Text=""></asp:Label></h3>
        </div>

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
                                    <div Visible="false" id="errorName" runat="server" class="alert alert-danger" style="width:300px; display:inline; padding:8px;">
                                        <strong>Greška!</strong> Naziv akcije ne može biti prazan.
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label2" runat="server" Text="Opis"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" TextMode="MultiLine" Placeholder="Opis..." ID="descriptionText" runat="server"></asp:TextBox>
                                    <div Visible="false" id="errorDescription" runat="server" class="alert alert-danger" style="width:300px; display:inline; padding:8px;">
                                        <strong>Greška!</strong> Opis ne može biti prazan.
                                    </div>
                                </td>
                            </tr>
                            <tr ID="dateRow" runat="server">
                                <th>
                                    <asp:Label ID="Label3" runat="server" Text="Datum"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" Placeholder="Datum..." ID="dateText" runat="server"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="dateText"
                                        OnClientDateSelectionChanged="checkDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                    <div Visible="false" id="errorDate" runat="server" class="alert alert-danger" style="width:300px; display:inline; padding:8px;">
                                        <strong>Greška!</strong> Datum ne može biti prazan.
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label4" runat="server" Text="Vrijeme"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" TextMode="Time" Placeholder="Vrijeme..." ID="timeText" runat="server"></asp:TextBox>
                                    <div Visible="false" id="errorTime" runat="server" class="alert alert-danger" style="width:300px; display:inline; padding:8px;">
                                        <strong>Greška!</strong> Vrijeme ne može biti prazno.
                                    </div>
                                    </asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <asp:Label ID="Label5" runat="server" Text="Grad"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" Placeholder="Grad..." ID="cityText" runat="server"></asp:TextBox>
                                    <div Visible="false" id="errorCity" runat="server" class="alert alert-danger" style="width:300px; display:inline; padding:8px;">
                                        <strong>Greška!</strong> Grad ne može biti prazan.
                                    </div>
                                </td>
                            </tr>
<tr>
                                <th>
                                    <asp:Label ID="Label52" runat="server" Text="Ulica"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox Width="300px" Placeholder="Ulica..." ID="streetText" runat="server"></asp:TextBox>
                                    <div Visible="false" id="errorStreet" runat="server" class="alert alert-danger" style="width:300px; display:inline; padding:8px;">
                                        <strong>Greška!</strong> Ulica ne može biti prazna.
                                    </div>
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
                                    <div Visible="false" id="errorObligation" runat="server" class="alert alert-danger" style="left:185px; width:300px; display:inline; padding:8px;">
                                        <strong>Greška!</strong> Morate odabrati obveznost.
                                    </div>
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
