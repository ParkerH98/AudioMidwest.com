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

    <%-- google fonts --%>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@100;300;400;500;700&display=swap"
        rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@200;300;400;500;700&display=swap"
        rel="stylesheet" />

    <%-- main style sheet --%>
    <link href="Content/CSS/home_styles.css" rel="stylesheet" />

</head>

<body>
    <form id="form1" runat="server">

        <div class="container-fluid px-0">

            <%-- jumbotron --%>
            <div class="jumbotron-fluid blue">
                <img src="Content/Images/amLogo.jpg" alt="Audio Midwest Logo" class="img-fluid mx-auto d-block" />
            </div>

            <%-- navigation bar --%>
            <nav class="navbar navbar-expand-md navbar-dark bg-dark">
                <div class="navbar-collapse collapse w-100 order-1 order-md-0 dual-collapse2">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="home.aspx">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="products.aspx">Products</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="services.aspx">Services</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="aboutUs.aspx">About Us</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="contact.aspx">Contact</a>
                        </li>
                    </ul>
                </div>
                <div class="ml-auto order-0">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".dual-collapse2">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse w-100 order-3 dual-collapse2">
                    <ul class="navbar-nav ml-auto">

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdownMenuLink"
                                data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Account
                            </a>
                            <div class="dropdown-menu dropdown-menu-right" aria-labelledby="navbarDropdownMenuLink">
                                <asp:HyperLink CssClass="dropdown-item" ID="loginDD" NavigateUrl="login.aspx"
                                    runat="server">Login</asp:HyperLink>
                                <asp:HyperLink CssClass="dropdown-item" ID="CreateAcctDD"
                                    NavigateUrl="accountCreation.aspx" runat="server">Create Account</asp:HyperLink>
                                <asp:HyperLink CssClass="dropdown-item" ID="modifyAcctDD"
                                    NavigateUrl="accountModification.aspx" runat="server">Modify Account</asp:HyperLink>
                                <asp:Button ID="btnSignOut" runat="server" Text="Sign Out"
                                    CssClass="btn btn-outline-dark dropdown-item" OnClick="btnSignOut_Click"
                                    NavigateUrl="login.aspx" CausesValidation="False" />
                            </div>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
        <%-- end of jumbo/nav div --%>

        <%-- main container div --%>
        <div class="container-fluid">

            <%-- page heading row --%>
            <div class="row mt-4 mb-4">

                <div class="col-sm-12 ml-3">

                    <asp:Label ID="lblTxt" runat="server" Text=""></asp:Label>

                    <h1>Welcome to Audio Midwest</h1>
                    <h2>Sellers and Installers of Premium AV Equipment</h2>

                </div>
            </div>

            <hr />

            <%-- paragraph row --%>
            <div class="row mt-5 mb-5">

                <div class="col-sm-6 text-center">

                    <h2 class="text-center">Car Audio</h2>
                    <p class="justify squeeze">
                        Audio, Video, or Remote Start, we are your local 12-volt expert. From subwoofers to in-car
                        entertainment systems, our expert installers can customize
                        a mind-blowing system for your vehicle. Whether you want big sound or a remote start, we can
                        help.
                    </p>

                </div>

                <div class="col-sm-6 text-center">

                    <h2 class="text-center">Home Audio</h2>
                    <p class="justify squeeze">
                        4K, OLED, or Smart TVs, our home theater experts can recommend and install the best in living
                        room entertainment. We hang TVs of any size and only sell the best. If you’re looking for
                        surround sound,
                        we have the latest in discreet, in-ceiling solutions and hi-fi.
                    </p>
                </div>
            </div>

            <%-- carousel row --%>
            <div class="row mb-3">

                <div class="col-sm-4 offset-sm-4">

                    <div id="carouselIndicators" class="carousel slide" data-ride="carousel" data-interval="2500"
                        pause="hover">
                        <ol class="carousel-indicators">
                            <li data-target="#carouselIndicators" data-slide-to="0" class="active"></li>
                            <li data-target="#carouselIndicators" data-slide-to="1"></li>
                            <li data-target="#carouselIndicators" data-slide-to="2"></li>
                            <li data-target="#carouselIndicators" data-slide-to="3"></li>
                            <li data-target="#carouselIndicators" data-slide-to="4"></li>
                            <li data-target="#carouselIndicators" data-slide-to="5"></li>
                            <li data-target="#carouselIndicators" data-slide-to="6"></li>
                            <li data-target="#carouselIndicators" data-slide-to="7"></li>
                            <li data-target="#carouselIndicators" data-slide-to="8"></li>
                            <li data-target="#carouselIndicators" data-slide-to="9"></li>

                        </ol>
                        <div class="carousel-inner">
                            <div class="carousel-item active">
                                <img src="Content/Images/logo_denon.jpg" class="d-block w-100 img-fluid mx-auto rounded"
                                    alt="Denon brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_focal.jpg" class="d-block w-100 img-fluid mx-auto rounded"
                                    alt="Focal brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_kenwood.jpg"
                                    class="d-block w-100 img-fluid mx-auto rounded" alt="Kenwood brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_kicker.jpg"
                                    class="d-block w-100 img-fluid mx-auto rounded" alt="Kicker brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_lg.jpg" class="d-block w-100 img-fluid mx-auto rounded"
                                    alt="LG brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_pioneer.jpg"
                                    class="d-block w-100 img-fluid mx-auto rounded" alt="Pioneer brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_samsung.jpg"
                                    class="d-block w-100 img-fluid mx-auto rounded" alt="Samsung brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_sony.jpg" class="d-block w-100 img-fluid mx-auto rounded"
                                    alt="Sony brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_sound.jpg" class="d-block w-100 img-fluid mx-auto rounded"
                                    alt="sound Digital brand logo" />
                            </div>
                            <div class="carousel-item">
                                <img src="Content/Images/logo_yamaha.jpg"
                                    class="d-block w-100 img-fluid mx-auto rounded" alt="Yamaha brand logo" />
                            </div>

                        </div>
                        <a class="carousel-control-prev" href="#carouselIndicators" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                        </a>
                        <a class="carousel-control-next" href="#carouselIndicators" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                        </a>
                    </div>

                </div>

            </div>
        </div>
        <%-- end of main container div --%>

        <%-- footer container --%>
        <div class="container-fluid px-0">

            <footer class="bg-dark">

                <div class="row pt-3 pb-1">

                    <div class="col-sm-4">

                        <div class="row">

                            <div class="col-sm-6 text-center">

                                <h4 class="text-white text-uppercase">Stillwater</h4>
                                <p>(405) 377-6827<br />
                                    502 E Lakeview Rd<br />
                                    Stillwater, OK 74075
                                </p>

                                <h4 class="text-white text-uppercase">Edmond</h4>
                                <p>(405) 478-5432<br /> 324 W 33rd St<br /> Edmond, OK 73013</p>

                            </div>

                            <div class="col-sm-6 text-center">

                                <h4 class="text-white text-uppercase">Hours</h4>
                                <p>Mon: 10am &#8211; 6pm<br />
                                    Tue: 10am &#8211; 6pm<br />
                                    Wed: 10am &#8211; 6pm<br />
                                    Thur: 10am &#8211; 6pm<br />
                                    Fri: 10am &#8211; 6pm<br />
                                    Sat: 10am &#8211; 5pm<br />
                                    Sun: Closed
                                </p>

                            </div>
                        </div>
                    </div>

                    <div class="col-sm-4 offset-sm-4 text-center">

                        <div class="row">

                            <div class="col-sm-6">

                                <h4 class="text-white text-uppercase">Navigation</h4>
                                <ul class="list-unstyled">
                                    <li>
                                        <a href="home.aspx">Home</a>
                                    </li>
                                    <li>
                                        <a href="products.aspx">Products</a>
                                    </li>
                                    <li>
                                        <a href="services.aspx">Services</a>
                                    </li>
                                    <li>
                                        <a href="aboutUs.aspx">About Us</a>
                                    </li>
                                    <li>
                                        <a href="contact.aspx">Contact</a>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="footerLogin" runat="server" NavigateUrl="login.aspx">Login
                                        </asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="footerCreateAccount" runat="server"
                                            NavigateUrl="accountCreation.aspx">Create Account</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:HyperLink ID="footerAccountmodification" runat="server"
                                            NavigateUrl="accountModification.aspx">Modify Account</asp:HyperLink>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="footerSignout" OnClick="btnSignOut_Click"
                                            NavigateUrl="login.aspx" CausesValidation="False" runat="server">Sign Out
                                        </asp:LinkButton>
                                    </li>
                                </ul>

                            </div>

                            <div class="col-sm-6">

                                <h4 class="text-white text-uppercase">Social Media</h4>
                                <ul class="list-unstyled">
                                    <li>
                                        <a href="#!">Facebook</a>
                                    </li>
                                    <li>
                                        <a href="#!">Twitter</a>
                                    </li>
                                    <li>
                                        <a href="#!">Instagram</a>
                                    </li>
                                </ul>

                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </form>
</body>

</html>