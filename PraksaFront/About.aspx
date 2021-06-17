<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PraksaFront.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>O Nama</title>
    <link href="content/css/about.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form id="form1" runat="server">

    <div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center bg-light" style="background: url('content/img/bjelovar.jpg') no-repeat; background-size:100%;">
        <div class="p-lg-5 mx-auto my-5">
            <div style="width:100%; height:77px; background-image: linear-gradient(to right, rgba(255,255,255,0), rgba(255,255,255,1), rgba(255,255,255,0));">
            <h1 class="display-4 font-weight-normal">Bjelovarska Udruga</h1>
                
                </div>
            
            <br />
            <a style="background-color:#383c44; border:1px solid #28242c" class="btn btn-lg btn-block btn-primary" href="#about">O Nama</a>
        </div>
        <div class="product-device box-shadow d-none d-md-block"></div>
        <div class="product-device product-device-2 box-shadow d-none d-md-block"></div>
    </div>

    <div class="container" id="about">
        <div class="card-deck mb-3 text-left">
            <div class="card mb-4 box-shadow">
                <div class="card-header">
                    <h4 class="my-0 font-weight-normal text-center">O Nama</h4>
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
                    <hr />
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
                    <hr />
                    <h5 style="font-size: 30px" class="display-6">Upravna tijela Udruge:</h5>
                    <ul class="mt-3 mb-4">
                        <li class="lead">Skupština</li>
                        <li class="lead">Upravni odbor</li>
                        <li class="lead">Nadzorni odbor</li>
                        <li class="lead">Disciplinska komisija</li>
                        <li class="lead">Inventarna komisija</li>
                    </ul>
                    <p class="lead">Upravni odbor čine predsjednik, tajnik, blagajnik, predsjednik nadzornong odbora, ostali izabrani članovi.</p>
                    <hr />
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
    </form>
</asp:Content>
