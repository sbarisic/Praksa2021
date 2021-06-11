<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AddPermitName.aspx.cs" Inherits="PraksaFront.AddPermit" %>
<head>
    <link href="content/css/home.css" rel="stylesheet" />
</head>
<body>
    <form id="f1" runat="server">

        <script type="text/javascript">
            function callParentWindowHideMethod() {
                if (window.parent.hideEditModalPopup) {
                window.parent.hideEditModalPopup();
                }
            }
        </script>
        <div>
            <table class="dataTable-table">
                <tr>
                    <th width="200px">
                        <asp:Label ID="Label1" runat="server" Text="Naziv dozvole"></asp:Label>
                    </th>

                    <td>
                        <asp:TextBox Placeholder="Dozvola..." ID="permitText" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="text-center">
                            <asp:Button Style="display: inline-block; text-align: center; margin-right: 10px;" ID="AddButton" runat="server" Text="Potvrdi" OnClick="AddButton_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
