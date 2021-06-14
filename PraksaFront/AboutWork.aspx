<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AboutWork.aspx.cs" Inherits="PraksaFront.AboutWork" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<head>
    <link href="content/css/home.css" rel="stylesheet" />
    <style>
    .Background {
      background-color: Black;
      filter: opacity(90);
      opacity: 0.8;
      }
      .Popup {
      background-color: #FFFFFF;
      border-width: 3px;
      border-style: solid;
      border-color: black;
      padding-top: 10px;
      width: 800px;
      }
    .locationButton {
    padding: 0px;
    border: none;
    background: none;
    color: blue;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:HiddenField ID="hdnField" runat="server" />
        <cc1:modalpopupextender id="ModalPopupExtender1" runat="server" popupcontrolid="Panl1" targetcontrolid="hdnField"
            cancelcontrolid="Button2" backgroundcssclass="Background"></cc1:modalpopupextender>
        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
            <iframe src="<%= url %>" width="100%" height="400px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <br />
            <asp:Button ID="Button4" runat="server" Text="Zatvori" />
        </asp:Panel>


        <div class="card-header">
            <h1>
                <asp:Label ID="lblTitle" runat="server"></asp:Label></h1>
        </div>
        <div class="card-body">
            <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                <div class="dataTable-container">
                    <table class="dataTable-table table-striped">
                        <tr>
                            <th>
                                <asp:Label ID="Label1" runat="server" Text="Radna akcija"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="workText" runat="server" Text="Testna akcija"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label2" runat="server" Text="Opis"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="descriptionText" runat="server" Text="ovo ovdje je opis testne akcije lol"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label4" runat="server" Text="Datum"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="dateText" runat="server" Text="69.420.1991."></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label6" runat="server" Text="Vrijeme"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="timeText" runat="server" Text="06:09"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label8" runat="server" Text="Lokacija"></asp:Label>
                            </th>
                            <td>
                                <asp:Button CssClass="locationButton" ID="locButton" runat="server" Text='' OnClick="locButton_Click" />
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label10" runat="server" Text="Obveznost"></asp:Label>
                            </th>
                            <td>
                                <asp:Label ID="obligationText" runat="server" Text="Obavezno"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="Label12" runat="server" Text="Prisutnost"></asp:Label>
                            </th>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="Dolazim" />
                                <asp:Button ID="Button2" runat="server" Text="Ne dolazim" />
                                <asp:Button ID="Button3" runat="server" Text="Mozda dolazim" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>

