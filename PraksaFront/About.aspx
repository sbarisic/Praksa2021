<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PraksaFront.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <title>O Nama</title>
    </head>
    <head>
        <link rel="stylesheet" href="content/css/about.css" />
    </head>
    <body>
        <h3>Gdje se nalazimo?</h3>
        <div id="map"></div>
        <script
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOeCxm3eXhda8M0-c9GrPn1QWL3h5h45I&callback=initMap&libraries=&v=weekly"
        async
        ></script>
        <script src="content/js/about.js"></script>
    </body>
</asp:Content>
