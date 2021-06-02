<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PraksaFront.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <head>
    <link rel="stylesheet" href="content/css/about.css" />
    <title>O Nama</title>
  </head>
  <body>
    <h3>Gdje se nalazimo?</h3>
    <div id="map"></div>
    <script
      src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCQQy5Zo_TU-Hic7i2w479wKIGpIOG-hHM&callback=initMap&libraries=&v=weekly"
      async
    ></script>
    <script src="content/js/about.js"></script>
  </body
</asp:Content>
