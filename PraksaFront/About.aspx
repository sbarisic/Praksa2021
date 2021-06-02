<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PraksaFront.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <head>
        <title>O Nama</title>
        <link rel="stylesheet" href="content/css/about.css" />
    </head>
    <body>
        <div id="center">
            <h3>O nama</h3>
            <h4>Gdje se nalazimo?</h4>
            <div id="map"></div>
        </div>
        <script
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOeCxm3eXhda8M0-c9GrPn1QWL3h5h45I&callback=initMap&libraries=&v=weekly"
            async></script>
        <script src="content/js/about.js"></script>
    </body>
</asp:Content>
