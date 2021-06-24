<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PraksaFront.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>O Nama</title>
    <link href="content/css/about.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Staatliches&display=swap" rel="stylesheet">
    <style>
        body {
            padding: 0px;
            margin: 0px;
            font-family: "Trebuchet MS", "Lucida Grande", "Lucida Sans Unicode", "Lucida Sans", Tahoma, sans-serif;
            font-size: 24px;
            font-style: normal;
            font-weight: 400;
            line-height: 26.4px;
        }

        @import url('https://fonts.googleapis.com/css2?family=Dancing+Script&display=swap');

        header {
            font-family: "Trebuchet MS", "Lucida Grande", "Lucida Sans Unicode", "Lucida Sans", Tahoma, sans-serif;
            font-size: 24px;
            font-style: normal;
            font-weight: 400;
            line-height: 26.4px;
            background: url("content/Img/bjelovarBlur.jpg");
            text-align: center;
            width: 100%;
            height: 400px;
            margin-bottom: 20px;
            background-size: cover;
            background-attachment: fixed;
            position: relative;
            overflow: hidden;
            border-radius: 0 0 85% 85% / 30%;
        }

            header .overlay {
                font-family: 'Staatliches', cursive;
                width: 100%;
                height: 100%;
                padding: 50px;
                color: #FFF;
            }

        .bjLista ul {
            list-style: none; /* Remove default bullets */
        }

            .bjLista ul li::before {
                content: "\2022"; /* Add content: \2022 is the CSS Code/unicode for a bullet */
                color: #448d4e; /* Change the color */
                font-size: 25px;
                font-weight: bold; /* If you want it to be bold */
                display: inline-block; /* Needed to add space between the bullet and the text */
                width: 1em; /* Also needed for space (tweak if needed) */
                margin-left: -1em; /* Also needed for space (tweak if needed) */
            }

        .naslov {
            position: absolute;
            top: 50%;
            right: 50%;
            transform: translate(50%,-50%);
            text-transform: uppercase;
            font-family: verdana;
            font-size: 60px;
            font-weight: 700;
            color: #2c6333;
            text-shadow: 1px 1px 1px #2c6333, 1px 2px 1px #2c6333, 1px 3px 1px #2c6333, 1px 4px 1px #2c6333, 1px 5px 1px #2c6333, 1px 6px 1px #2c6333, 1px 7px 1px #2c6333, 1px 8px 1px #2c6333, 1px 18px 6px rgba(16,16,16,0.4), 1px 22px 10px rgba(16,16,16,0.2), 1px 25px 35px rgba(16,16,16,0.2), 1px 30px 60px rgba(16,16,16,0.4);
        }
    </style>
</asp:Content>

<asp:Content CssClass="bgColor" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <header>
            <div class="overlay">
                <div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center">
                    <div class="p-lg-5 mx-auto my-5">
                        <div>
                            <h1 class="naslov" style="font-size: 75px; color: #6acc6a; margin-top: -50px;">Bjelovarska<br /> Udruga</h1>
                            <hr style="border-top:5px solid white; opacity:1; margin-top:-40px;" />
                        </div>
                        <br />
                    </div>
                    <div class="product-device box-shadow d-none d-md-block"></div>
                    <div class="product-device product-device-2 box-shadow d-none d-md-block"></div>
                </div>
            </div>
        </header>
        <div class="container bjLista" id="about">
            <div class="card-deck mb-3 text-left">
                <div class="card mb-4 box-shadow">
                    <div class="card-header" style="background: #448d4e!important">
                        <h4 class="my-0 font-weight-normal text-center" style="color: white;">O Nama</h4>
                    </div>
                    <div class="card-body">
                        <p class="lead">
                            Bjelovarska udruga  osnovana je u lipnju 2010. godine.  Okuplja mlade ljude od 18 do 105 godina starosti s područja Bjelovara.<br />
                            <br />
                            U svoje aktivnosti uključuju i druge mlade s područja  županije kroz volonterski angažman.
U rad udruge kao potpora uključuju se i lokalni mještani kako bi zajedničkim snagama i znanjem doprinijeli razvoju lokalne zajednice i unaprijedili kvalitetu življenja.
                        </p>
                        <br />
                        <h5 style="font-size: 30px" class="display-6 font-weight-normal">Cilj Udruge, sukladno statutu:</h5>
                        <p class="lead">Cilj osnivanja Udruge je osnažiti zajednicu da postane aktivnim sudionikom održivog razvitka.</p>
                        <hr style="color: #448d4e; opacity: 1;" />
                        <h5 style="font-size: 35px" class="display-6 font-weight-normal">Djelokrug, svrha i područje djelovanja udruge:</h5>
                        <br />
                        <h5 style="font-size: 30px" class="display-6">Svrha:</h5>
                        <ul class="mt-3 mb-4">
                            <li class="lead">uspostavljanje i unapređenje kvalitete življenja mladih i starih, te cjelokupne lokalne zajednice</li>
                            <li class="lead">osnažiti zajednicu da postane aktivnim sudionikom održivog razvitka</li>
                            <li class="lead">promicati suradnju i partnerstvo kao preduvjete sigurnije i prosperitetnije budućnosti</li>
                            <li class="lead">promicanje boljeg načina života mladih i djece kroz druženje, društvenu odgovornost i aktivnosti</li>
                        </ul>
                        <h5 style="font-size: 30px" class="display-6">Djelatnosti:</h5>
                        <ul class="mt-3 mb-4">
                            <li class="lead">poticati, organizirati i educirati članove zajednice da aktivno sudjeluju u rješavanju problema od interesa za zajednicu</li>
                            <li class="lead">priređivati radionice za članove udruge u svrhu potpunijeg ostvarivanja zadaća i ciljeva udruge</li>
                            <li class="lead">organizacija raznih oblika druženja (natjecanja, izleta i sl.)</li>
                            <li class="lead">obavljanje i drugih poslova u skladu sa zakonom</li>
                        </ul>
                        <h5 style="font-size: 30px" class="display-6">Područje djelovanja udruge:</h5>
                        <ul class="mt-3 mb-4">
                            <li class="lead">Kroz aktivno djelovanje Udruge žele se poboljšati uvjeti i životni standard svih osoba.</li>
                            <li class="lead">Potiče ih se na aktivno djelovanje u lokalnoj zajednici kroz razne informativne, edukativne, sportske, kulturne, humanitarne i zabavne sadržaje.</li>
                            <li class="lead">Organiziranje i educiranje članova zajednice da aktivno sudjeluju u rješavanju problema od interesa za zajednicu.</li>
                            <li class="lead">Priređuju se radionice za članove udruge u svrhu potpunijeg ostvarivanja zadaća i ciljeva udruge.</li>
                            <li class="lead">Također se povezuju mladi ljudi na našem području i kroz organizaciju druženja za sve (natjecanja, izleta i sl.)</li>
                        </ul>
                        <br />
                        <hr style="color: #448d4e; opacity: 1;" />
                        <h5 style="font-size: 30px" class="display-6">Upravna tijela Udruge:</h5>
                        <ul class="mt-3 mb-4">
                            <li class="lead">Skupština</li>
                            <li class="lead">Upravni odbor</li>
                            <li class="lead">Nadzorni odbor</li>
                            <li class="lead">Disciplinska komisija</li>
                            <li class="lead">Inventarna komisija</li>
                        </ul>
                        <p class="lead">Upravni odbor čine predsjednik, tajnik, blagajnik, predsjednik nadzornong odbora, ostali izabrani članovi.</p>
                        <hr style="color: #448d4e; opacity: 1;" />
                        <h5 style="font-size: 30px" class="display-6">Gdje se nalazimo?</h5>
                        <div id="map">
                            <script
                                src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCOeCxm3eXhda8M0-c9GrPn1QWL3h5h45I&callback=initMap&libraries=&v=weekly"
                                async></script>
                            <script src="content/js/about.js"></script>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
