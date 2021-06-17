<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditRoleName.aspx.cs" Inherits="PraksaFront.EditRoleName" %>

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
                        <asp:Label ID="Label1" runat="server" Text="Naziv uloge"></asp:Label>
                    </th>

                    <td>
                        <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="text-center">
                            <asp:Button Style="display: inline-block; text-align: center; margin-right: 10px;" ID="EditBtn" runat="server" Text="Potvrdi" OnClick="EditBtn_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>

