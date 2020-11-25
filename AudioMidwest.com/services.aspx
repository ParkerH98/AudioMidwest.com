<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="services.aspx.cs" Inherits="AudioMidwest.com.services" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Services</title>

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

                    <h1>Services</h1>
                    <h2>We Offer a Wide Variety of Professional Installations</h2>

                </div>
            </div>

            <hr />

            <%-- car audio container --%>
            <div class="container">

                <div class="row mb-3">

                    <div class="col-sm-12 text-center">
                        <h2>Car Audio</h2>
                    </div>
                </div>

                <div class="row">

                    <div class="col-sm-4">
                        <img src="Content/Images/car_1.jpg" />
                    </div>

                    <div class="col-sm-4">
                        <img src="Content/Images/car_2.jpg" />
                    </div>

                    <div class="col-sm-4">
                        <img src="Content/Images/car_3.jpg" />
                    </div>
                </div>

                <div class="row mt-3 mb-5">

                    <div class="col-sm-12 justify squeeze">
                        <p>Premium car audio is one of the best ways to get enjoyment out of your favorite music. We
                            have a large variety of car audio products we can professionally install including head
                            units, door speakers, subwoofers, amplifiers, DSPs, and LOCs. We use professional tools like
                            RTAs and oscilloscopes to ensure the highest fidelity sound from the installation.
                        </p>
                    </div>
                </div>
            </div>
            <%-- end car audio container --%>


            <hr />


            <%-- home audio container --%>
            <div class="container">

                <div class="row mb-3">

                    <div class="col-sm-12 text-center">
                        <h2>Home Audio</h2>
                    </div>
                </div>

                <div class="row">

                    <div class="col-sm-4">
                        <img src="Content/Images/home_1.jpg" />
                    </div>

                    <div class="col-sm-4">
                        <img src="Content/Images/home_2.jpg" />
                    </div>

                    <div class="col-sm-4">
                        <img src="Content/Images/home_3.jpg" />
                    </div>
                </div>

                <div class="row mt-3 mb-5">

                    <div class="col-sm-12 justify squeeze">
                        <p>Want to take your home get togethers to the next level? Upgrading your home audio system can
                            provide the music for the party or supply the sound on movie night. We offer thr latest
                            receivers and home speakers
                            to provide you with the best experience. Let us enhance your home audio setup with a Dolby
                            7.1.2 surround sound system. It'll be your best purchase yet.
                        </p>
                    </div>
                </div>
            </div>
            <%-- end home audio container --%>

            <hr />


            <%-- tv container --%>
            <div class="container">

                <div class="row mb-3">

                    <div class="col-sm-12 text-center">
                        <h2>Televisions</h2>
                    </div>
                </div>

                <div class="row">

                    <div class="col-sm-4">
                        <img src="Content/Images/tv_1.jpg" />
                    </div>

                    <div class="col-sm-4">
                        <img src="Content/Images/tv_2.jpg" />
                    </div>

                    <div class="col-sm-4">
                        <img src="Content/Images/tv_3.jpg" />
                    </div>
                </div>

                <div class="row mt-3 mb-5">

                    <div class="col-sm-12 justify squeeze">
                        <p>Want to enjoy the latest movies without going to the movie theatre? Come get a brand new 70"
                            4K OLED TV and you can do just that. A new TV will be great for those football Sundays or
                            movie nights.
                            We offer a wide variety of brands from Sony to LG including OLED and LCD displays.
                        </p>
                    </div>
                </div>
            </div>
            <%-- end tv container --%>


            <hr />


            <%--  prewire container --%>
            <div class="container">

                <div class="row mb-3">

                    <div class="col-sm-12 text-center">
                        <h2>Construction Prewiring</h2>
                    </div>
                </div>

                <div class="row">

                    <div class="col-sm-4">
                        <img src="Content/Images/prewire_1.jpg" />
                    </div>

                    <div class="col-sm-4">
                        <img src="Content/Images/prewire_2.jpg" />
                    </div>

                    <div class="col-sm-4">
                        <img src="Content/Images/prewire_3.jpg" />
                    </div>
                </div>

                <div class="row mt-3 mb-5">

                    <div class="col-sm-12 justify squeeze">
                        <p>Prewiring is a great option if you're building a home and already know you're going to have a
                            home audio system. Prewiring allows us to run speakerwire throughout the house
                            without having to deal with hindrances like sheetrock and insulation. This option can save
                            on labor costs and allows for certain audio solutions that may not have been available
                            otherwise.
                        </p>
                    </div>
                </div>
            </div>
            <%-- end prewire container --%>
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