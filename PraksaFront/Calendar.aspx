<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="PraksaFront.Calendar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>ASP.NET FullCalendar</title>
    <link href="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/themes/cupertino/jquery-ui.min.css" rel="stylesheet" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/fullcalendar.min.css" rel="stylesheet" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.css" rel="stylesheet" />

    <style type='text/css'>
        body {
            margin-top: 40px;
            text-align: center;
            font-size: 14px;
            font-family: "Lucida Grande",Helvetica,Arial,Verdana,sans-serif;
        }

        #calendar {
            width: 900px;
            margin: 0 auto;
        }
        /* css for timepicker */
        .ui-timepicker-div dl {
            text-align: left;
        }

            .ui-timepicker-div dl dt {
                height: 25px;
            }

            .ui-timepicker-div dl dd {
                margin: -25px 0 10px 65px;
            }

        .style1 {
            width: 100%;
        }

        /* table fields alignment*/
        .alignRight {
            text-align: right;
            padding-right: 10px;
            padding-bottom: 10px;
        }

        .alignLeft {
            text-align: left;
            padding-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <body>
        <form id="form1" runat="server">
            <script>
    function addWork() {
        $find("ModalPopupExtender2").show();
    }
    function testF() {
        return jQuery.parseJSON(document.getElementById('<%=jsonField.ClientID%>').innerHTML);
    }
            </script>
            <asp:Label ID="jsonField" runat="server" Text='' Style="display: none"></asp:Label>
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>

            <asp:HiddenField ID="hdnField" runat="server" />
            <cc1:ModalPopupExtender BehaviorID="ModalPopupExtender2" ID="ModalPopupExtender2" runat="server" PopupControlID="Panl2" TargetControlID="hdnField" CancelControlID="ButtonClose" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
            <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe src="AddWork.aspx" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
                <br />
                <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" />
            </asp:Panel>

            <div id="calendar">
            </div>
            <div id="updatedialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px; display: none;"
                title="Update or Delete Event">
                <table class="style1">
                    <tr>
                        <td class="alignRight">Radna akcija::</td>
                        <td class="alignLeft">
                            <input id="eventName" type="text" size="33" /><br />
                        </td>
                    </tr>
                    <tr>
                        <td class="alignRight">Opis:</td>
                        <td class="alignLeft">
                            <textarea id="eventDesc" cols="30" rows="3"></textarea></td>
                    </tr>
                    <tr>
                        <td class="alignRight">Datum:</td>
                        <td class="alignLeft">
                            <textarea id="eventLoc" cols="30" rows="3"></textarea></td>
                    </tr>
                    <tr>
                        <td class="alignRight">Vrijeme:</td>
                        <td class="alignLeft">
                            <textarea id="eventTime" cols="30" rows="3"></textarea></td>
                    </tr>
                    <tr>
                        <td class="alignRight">Lokacija:</td>
                        <td class="alignLeft">
                            <textarea id="eventReq" cols="30" rows="3"></textarea></td>
                    </tr>
                    <tr>
                        <td class="alignRight">Obveznost:</td>
                        <td class="alignLeft">
                            <span id="eventStart"></span></td>
                    </tr>
                    <tr>
                        <td class="alignRight">End: </td>
                        <td class="alignLeft">
                            <span id="eventEnd"></span>
                            <input type="hidden" id="eventId" /></td>
                    </tr>
                </table>
            </div>

            <div id="addDialog" style="font: 70% 'Trebuchet MS', sans-serif; margin: 50px;" title="Add Event">
                <table class="style1">
                    <tr>
                        <td class="alignRight">Radna akcija:</td>
                        <td class="alignLeft">
                            <asp:TextBox ID="addEventName" runat="server"></asp:TextBox>
                    </tr>
                    <tr>
                        <td class="alignRight">Opis:</td>
                        <td class="alignLeft">
                            <asp:TextBox ID="addEventDesc" runat="server"></asp:TextBox>
                    </tr>
                    <tr>
                        <td class="alignRight">Lokacija:</td>
                        <td class="alignLeft">
                            <asp:TextBox ID="addEventLoc" runat="server"></asp:TextBox>
                    </tr>
                    <tr>
                        <td class="alignRight">Vrijeme:</td>
                        <td class="alignLeft">
                            <asp:TextBox TextMode="Time" ID="addEventTime" runat="server"></asp:TextBox>
                    </tr>
                    <tr>

                        <td class="alignRight">Obveznost:</td>
                        <td>
                            <asp:RadioButtonList ID="addEventObligation" runat="server" RepeatLayout="Flow" RepeatDirection="Vertical">
                                <asp:ListItem Value="1">Obavezno</asp:ListItem>
                                <asp:ListItem Value="0">Nije obavezno</asp:ListItem>
                            </asp:RadioButtonList></td>

                    </tr>
                </table>

            </div>
            <div runat="server" id="jsonDiv" />
            <input type="hidden" id="hdClient" runat="server" />
        </form>

        <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.17.1/moment.min.js"></script>
        <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
        <script src="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
        <script src="//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.js"></script>
        <script src="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/fullcalendar.min.js"></script>
        <script src="scripts/calendarscript.js" type="text/javascript"></script>
    </body>
</asp:Content>
