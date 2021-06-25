<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceInterest.aspx.cs" Inherits="PraksaFront.AttendanceInterest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="content/css/radneAkcijeStyle.css" rel="stylesheet" />
    <link href="content/css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="card-body">
                <div class="dataTable-wrapper dataTable-loading no-footer sortable searchable fixed-columns">
                    <div class="dataTable-container">
                        <table class="dataTable-table table-striped">
                            <tr style="background-color: #6bc277;">
                                <th>
                                    <asp:Label runat="server" Text="Ime"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="Prezime"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="Interes"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label runat="server" Text="Vrijeme Odabira"></asp:Label>
                                </th>
                            </tr>

                            <asp:Repeater ID="attendanceRepeater" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hdnUser" Value='<%# Eval ("IdUser")%>' runat="server" />
                                            <asp:HiddenField ID="hdnInteres" Value='<%# Eval ("IdInteres")%>' runat="server" />
                                            <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval ("UserFirstName")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblLastName" runat="server" Text='<%# Eval ("UserLastName")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblInteres" runat="server" Text='<%# Eval ("Interes")%>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblTime" runat="server" Text='<%# Eval ("SelectionTime")%>'></asp:Label></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
