<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="PraksaFront.Calendar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <title>Kalendar akcija</title>
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
      width: 900px;
      }
   </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <body>
      <div>
         <asp:Label ID="jsonField" runat="server" Text='' Style="display: none"></asp:Label>
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true"></asp:ScriptManager>
         <!--ADD WORK POPUP-->
         <asp:HiddenField ID="hdnField" runat="server" />
         <cc1:ModalPopupExtender BehaviorID="ModalPopupExtender2" ID="ModalPopupExtender2" runat="server" PopupControlID="Panl2" TargetControlID="hdnField" CancelControlID="ButtonClose" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
         <asp:Panel ID="Panl2" runat="server" CssClass="Popup" align="center" Style="display: none">
            <iframe ID="addFrame" src="AddWork.aspx" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <br />
            <asp:Button ID="ButtonClose" runat="server" Text="Zatvori" />
         </asp:Panel>
         <!--EDIT WORK POPUP-->
         <asp:HiddenField ID="hdnField2" runat="server" value="test"/>
         <asp:Label id="lblEditID" runat="server" Text="" style="display:none;"></asp:Label>
         <cc1:ModalPopupExtender BehaviorID="EditModalPopupExtender" ID="EditModalPopupExtender" runat="server" PopupControlID="EditPanl" TargetControlID="hdnField2" CancelControlID="ButtonClose2" BackgroundCssClass="Background"></cc1:ModalPopupExtender>
         <asp:Panel ID="EditPanl" runat="server" CssClass="Popup" align="center" Style="display: none">
            <iframe ID="editFrame" src="EditWork.aspx" width="100%" height="490px" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            <br />
            <asp:Button ID="ButtonClose2" runat="server" Text="Zatvori" />
         </asp:Panel>
         <div id="calendar">
         </div>
         <div runat="server" id="jsonDiv" />
         <input type="hidden" id="hdClient" runat="server" />
         
<asp:Button runat="server" ID="hdnBtn" ClientIDMode="Static" Text="" style="display:none;" OnClick="hdnBtn_Click" />
      </div>
      <script type="application/javascript">
         function addWork() {
             $find("ModalPopupExtender2").show();
         }
         function editWork() {
             $find("EditModalPopupExtender").show();
         }
         function testF() {
             return jQuery.parseJSON(document.getElementById('<%=jsonField.ClientID%>').innerHTML);
         }
    function setEditID(editId) {
            document.getElementById('editFrame').src = "EditWork.aspx?workId=" + editId;
    }
    function setAddDate(date) {
        document.getElementById('addFrame').src = "AddWork.aspx?date=" + date;
    }
         function hideEditModalPopup() {
                $find("ModalPopupExtender2").hide();
                $find("EditModalPopupExtender").hide();
                document.getElementById("hdnBtn").click();
                return false;
         }       
      </script>
      <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.17.1/moment.min.js"></script>
      <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
      <script src="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>
      <script src="//cdnjs.cloudflare.com/ajax/libs/qtip2/3.0.3/jquery.qtip.min.js"></script>
      <script src="//cdnjs.cloudflare.com/ajax/libs/fullcalendar/3.1.0/fullcalendar.min.js"></script>
      <script src="scripts/calendarscript.js" type="text/javascript"></script>
   </body>
</asp:Content>