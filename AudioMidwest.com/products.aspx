<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="AudioMidwest.com.products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Products</title>

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
    <link href="Content/CSS/products_styles.css" rel="stylesheet" />

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
                                    NavigateUrl="login.aspx" />
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

                    <h1>Welcome to Audio Midwest</h1>
                    <h2>Sellers and Installers of Premium AV Equipment</h2>

                </div>
            </div>

            <hr />

            <div class="row">

                <%-- SpeakerFocal --%>
                <div class="col-sm-4">

                    <div class="card mb-3 height position-relative">
                        <img class="card-img-top d-block img-fluid mx-auto w-75 h-75" src="Content/Images/speaker_focal.jpg" alt="Card image cap" />
                        <div class="card-body position-relative">
                            <h5 class="card-title">Focal</h5>
                            <p class="card-text">This is a wider card with supporting text below as a natural lead-in to
                                additional content. This content is a little bit longer.</p>
                            <p class="card-text"><small class="text-muted">$699.99</small></p>
                        </div>

                        <%-- div @ bottom of card body --%>
                        <div class="bottom">
                            <asp:HiddenField ID="hidSpeakerFocal" Value="1" runat="server" />

                            <div class="row">
                                <div class="col-sm-12">
                                    <label class="d-block">Quantity:</label>
                                    <asp:TextBox ID="tboxSpeakerFocal" CssClass="d-block w-75" runat="server"
                                        ValidationGroup="" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnSpeakerFocal" CssClass="btn btn-primary" runat="server"
                                        Text="Add to Cart" ValidationGroup="" OnClick="btnSpeakerFocal_Click" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:RequiredFieldValidator ID="rfvSpeakerFocal" runat="server"
                                        ErrorMessage="Please enter a quantity." ControlToValidate="tboxSpeakerFocal"
                                        ValidationGroup="" Display="Dynamic" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End SpeakerFocal --%>










            </div>
            <%-- end of main container div --%>

            <%-- footer conatiner --%>
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
                                            <a href="login.aspx">Login</a>
                                        </li>
                                        <li>
                                            <a href="accountModification">Modify Account</a>
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