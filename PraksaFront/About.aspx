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
           <p>
                Bjelovarska udruga  osnovana je u lipnju 2010. godine.  Okuplja mlade ljude od 18 do 105 godina starosti s područja Bjelovara. <br />
                U svoje aktivnosti uključuju i druge mlade s područja  županije kroz volonterski angažman. <br />
                U rad udruge kao potpora uključuju se i lokalni mještani kako bi zajedničkim snagama i znanjem doprinijeli razvoju lokalne zajednice i unaprijedili kvalitetu življenja. <br />
           </p>
            <h5>Cilj Udruge, sukladno statutu :</h5>
            <p>
                Cilj osnivanja Udruge je osnažiti zajednicu da postane aktivnim sudionikom održivog razvitka.
            </p>
            <h4>Djelokrug, svrha i područje djelovanja udruge:</h4>
            <h5>Svrha:</h5>
            <ul>
                <li>uspostavljanje i unapređenje kvalitete življenja mladih i starih, te cjelokupne lokalne zajednice</li>
                <li>osnažiti zajednicu da postane aktivnim sudionikom održivog razvitka</li>
                <li>promicati suradnju i partnerstvo kao preduvjete sigurnije i prosperitetnije budućnosti</li>
                <li>promicanje boljeg načina života mladih i djece kroz druženje, društvenu odgovornost i aktivnosti</li>
            </ul>
            <h5>Djelatnosti:</h5>
            <ul>
                <li>Poticati, organizirati i educirati članove zajednice da aktivno sudjeluju u rješavanju problema od interesa za zajednicu</li>
                <li>Priređivati radionice za članove udruge u svrhu potpunijeg ostvarivanja zadaća i ciljeva udruge</li>
                <li>Organizacija raznih oblika druženja (natjecanja, izleta i sl.)</li>
                <li>Obavljanje i drugih poslova u skladu sa zakonom</li>
            </ul>
            <h5>Područje djelovanja udruge</h5>
            <ul>
                <li>Kroz aktivno djelovanje Udruge žele se poboljšati uvjeti i životni standard svih osoba.</li>
                <li>Potiče ih se na aktivno djelovanje u lokalnoj zajednici kroz razne informativne, edukativne, sportske, kulturne, humanitarne i zabavne sadržaje.</li>
                <li>Organiziranje i educiranje članova zajednice da aktivno sudjeluju u rješavanju problema od interesa za zajednicu.</li>
                <li>Priređuju se radionice za članove udruge u svrhu potpunijeg ostvarivanja zadaća i ciljeva udruge.</li>
                <li>Također se povezuju mladi ljudi na našem području i kroz organizaciju druženja za sve (natjecanja, izleta i sl.)</li>
            </ul>
            <h4>Upravna tijela Udruge:</h4>
            <ul>
                <li>Skupština</li>
                <li>Upravni odbor</li>
                <li>Nadzorni odbor</li>
                <li>Disciplinska komisija</li>
                <li>Inventarna komisija</li>
            </ul>
            <p>
            Upravni odbor čine predsjednik, tajnik, blagajnik, predsjednik nadzornong odbora, ostali izabrani članovi
            </p>            
            <h4>Gdje se nalazimo?</h4>
            <div id="map"></div>
        </div>
        <script
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOeCxm3eXhda8M0-c9GrPn1QWL3h5h45I&callback=initMap&libraries=&v=weekly"
            async></script>
        <script src="content/js/about.js"></script>
    </body>
</asp:Content>
