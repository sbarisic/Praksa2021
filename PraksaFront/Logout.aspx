<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="PraksaFront.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <title>Odjava</title>

    <style id="" media="all">
        /* latin */
        @font-face {
            font-family: 'Raleway';
            font-style: normal;
            font-weight: 700;
            src: url(/fonts.gstatic.com/s/raleway/v19/1Ptug8zYS_SKggPNyC0ITw.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }
        /* latin */
        @font-face {
            font-family: 'Passion One';
            font-style: normal;
            font-weight: 900;
            src: url(/fonts.gstatic.com/s/passionone/v11/Pby6FmL8HhTPqbjUzux3JEMS0U7vyJc.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }
    </style>

    <link type="text/css" rel="stylesheet" href="content/css/style.css" />

</head>
<body>
    <div id="notfound">
        <div class="notfound">
            <div class="notfound-404">
                <h1 style="width:170px; color:#6bc277;">:)</h1>
            </div>
            <h2>Uspješna odjava</h2>
            <p>Uspješno ste se odjavili. Preusmjeriti ćemo vas za 5 sekundi, ako ne budete automatski preusmjereni pritisnite na gumb "U redu".</p>
            <a href="About.aspx">u redu</a>
        </div>
    </div>

    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-23581568-13"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-23581568-13');
    </script>
    <script defer src="https://static.cloudflareinsights.com/beacon.min.js" data-cf-beacon='{"rayId":"663b9b444cb7fc75","token":"cd0b4b3a733644fc843ef0b185f98241","version":"2021.5.2","si":10}'></script>
</body>
</html>