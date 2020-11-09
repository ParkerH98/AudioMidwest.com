<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="AudioMidwest.com.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Audio Midwest</title>

    <%-- Bootstrap --%>
    <script src="Scripts/jquery-3.5.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/Bootstrap/bootstrap.min.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <%-- main style sheet --%>
    <link href="Content/CSS/home_styles.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid px-0">
            <nav class="navbar navbar-expand-md navbar-dark bg-dark">
                <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="#">Left</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="//codeply.com">Codeply</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                    </ul>
                </div>
                <div class="mx-auto order-0">
                    <a class="navbar-brand mx-auto" href="#">Navbar 2</a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".dual-collapse2">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Right</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div> 
        <%-- end of nav div --%>

        <div class="container">

            <div class="row">

                <div class="col-sm-6">

                    <p class="justify">
                        Audio, Video, or Remote Start, we are your local 12-volt expert. From subwoofers to in-car entertainment systems, our expert installers can customize
                        a mind-blowing system for your vehicle. Whether you want big sound or a remote start, we can help. 
                    </p>

                </div>


                <div class="col-sm-6">

                    <p>
                        4K, OLED,  or Smart TVs, our home theater experts can recommend and install the best in living room entertainment. We hang TVs of any size and only sell the best. If you’re looking for surround sound,
                        we have the latest in discreet, in-ceiling solutions and hi-fi.
                    </p>

                </div>

            </div>

        </div>
    </form>
</body>
</html>
