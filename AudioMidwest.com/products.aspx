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

            <div class="row mt-3">
                <div class="col-sm-12">
                    <asp:Button ID="btnGoToCart" CssClass="btn btn-secondary float-right" runat="server"
                        Text="Go to Cart" OnClick="btnGoToCart_Click" CausesValidation="False" />
                </div>
            </div>

            <%-- page heading row --%>
            <div class="row mb-4">

                <div class="col-sm-12 ml-3">

                    <h1>Premium Products</h1>
                    <h2>From Speakers to Remote Starts, We Sell It All</h2>

                </div>
            </div>

            <hr />

            <%-- Speaker Row --%>
            <div class="row">

                <%-- SpeakerFocal --%>
                <div class="col-md-4">

                    <div class="card mb-3 height position-relative">
                        <img class="card-img-top d-block img-fluid mx-auto w-75 h-75 p-3"
                            src="Content/Images/speaker_focal.jpg" alt="Card image cap" />

                        <div class="card-body middle">
                            <h5 class="card-title">Focal Performance Expert Series 6-1/2" 3-way component speaker system
                            </h5>
                            <p class="card-text">Focal Performance PS 165F3 - Focal's PS 165F3 component speaker system
                                provides rich and natural imaging for your music</p>
                            <p class="card-text"><small class="text-muted">$699.99</small></p>
                        </div>

                        <%-- div @ bottom of card body --%>
                        <div class="bottom">
                            <asp:HiddenField ID="hidSpeakerFocal" Value="1" runat="server" />

                            <div class="row ml-1">
                                <div class="col-sm-12">
                                    <label class="d-block">Quantity:</label>
                                    <asp:TextBox ID="tboxSpeakerFocal" CssClass="d-block w-75" runat="server"
                                        ValidationGroup="SpeakerFocal" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row ml-1 mb-3 mt-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnSpeakerFocal" CssClass="btn btn-primary" runat="server"
                                        Text="Add to Cart" ValidationGroup="SpeakerFocal"
                                        OnClick="btnSpeakerFocal_Click" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:RequiredFieldValidator ID="rfvSpeakerFocal" runat="server"
                                        ErrorMessage="Please enter a quantity." ControlToValidate="tboxSpeakerFocal"
                                        ValidationGroup="SpeakerFocal" Display="Dynamic" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End SpeakerFocal --%>


                <%-- SpeakerKicker --%>
                <div class="col-md-4">

                    <div class="card mb-3 height position-relative">
                        <img class="card-img-top d-block img-fluid mx-auto w-75 h-75 p-3"
                            src="Content/Images/speaker_kicker.jpg" alt="Card image cap" />
                        <div class="card-body middle">
                            <h5 class="card-title">Kicker KSS650 6.5-inch Component Speaker System</h5>
                            <p class="card-text">Experience your music as a component system with separate tweeters, or
                                as a high-end coaxial system. The woofers’ removable bullet-style phase plug is replaced
                                with a special adapter, allowing the 25 millimeter, silk-dome tweeters to rotate and
                                tilt. You get more system design options and superior off-axis performance. They work
                                best with 15 to 125 watts of recommended power.</p>
                            <p class="card-text"><small class="text-muted">$249.95</small></p>
                        </div>

                        <%-- div @ bottom of card body --%>
                        <div class="bottom">
                            <asp:HiddenField ID="hidSpeakerKicker" Value="2" runat="server" />

                            <div class="row ml-1">
                                <div class="col-sm-12">
                                    <label class="d-block">Quantity:</label>
                                    <asp:TextBox ID="tboxSpeakerKicker" CssClass="d-block width" runat="server"
                                        ValidationGroup="SpeakerKicker" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row ml-1 mb-3 mt-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnSpeakerKicker" CssClass="btn btn-primary" runat="server"
                                        Text="Add to Cart" ValidationGroup="SpeakerKicker"
                                        OnClick="btnSpeakerKicker_Click" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:RequiredFieldValidator ID="rfvSpeakerKicker" runat="server"
                                        ErrorMessage="Please enter a quantity." ControlToValidate="tboxSpeakerKicker"
                                        ValidationGroup="SpeakerKicker" Display="Dynamic" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End SpeakerKicker --%>


                <%-- SpeakerPhoenix --%>
                <div class="col-md-4">

                    <div class="card mb-3 height position-relative">
                        <img class="card-img-top d-block img-fluid mx-auto w-75 h-75 p-5"
                            src="Content/Images/speaker_phoenix.jpg" alt="Card image cap" />
                        <div class="card-body middle">
                            <h5 class="card-title">Phoenix Gold RX 6.5" Component Speaker Set</h5>
                            <p class="card-text">The RX series of components and coaxials utilizes a high performance
                                midbass driver that is acoustically matched to a quality Mylar dome tweeter via a
                                passive crossover.</p>
                            <p class="card-text"><small class="text-muted">$134.99</small></p>
                        </div>

                        <%-- div @ bottom of card body --%>
                        <div class="bottom">
                            <asp:HiddenField ID="hidSpeakerPhoenix" Value="3" runat="server" />

                            <div class="row ml-1">
                                <div class="col-sm-12">
                                    <label class="d-block">Quantity:</label>
                                    <asp:TextBox ID="tboxSpeakerPhoenix" CssClass="d-block w-75" runat="server"
                                        ValidationGroup="SpeakerPhoenix" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row ml-1 mb-3 mt-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnSpeakerPhoenix" CssClass="btn btn-primary" runat="server"
                                        Text="Add to Cart" ValidationGroup="SpeakerPhoenix"
                                        OnClick="btnSpeakerPhoenix_Click" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:RequiredFieldValidator ID="rfvSpeakerPhoenix" runat="server"
                                        ErrorMessage="Please enter a quantity." ControlToValidate="tboxSpeakerPhoenix"
                                        ValidationGroup="SpeakerPhoenix" Display="Dynamic" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End SpeakerPhoenix --%>
            </div>
            <%-- End Speaker Row --%>


            <%-- Amplifier Row --%>
            <div class="row">

                <%-- AmpSound --%>
                <div class="col-md-4">

                    <div class="card mb-3 height position-relative">
                        <img class="card-img-top d-block img-fluid mx-auto w-75 h-75 p-3"
                            src="Content/Images/amp_sound.jpg" alt="Card image cap" />
                        <div class="card-body middle">
                            <h5 class="card-title">Sound Digital 800.1 EVO</h5>
                            <p class="card-text">The EVO X Line brings the latest technology in a compact design with
                                the highest quality components. From a pioneering technology, SounDigital brought to car
                                audio amplifiers something that had not been explored yet.</p>
                            <p class="card-text"><small class="text-muted">$399.99</small></p>
                        </div>

                        <%-- div @ bottom of card body --%>
                        <div class="bottom">
                            <asp:HiddenField ID="hidAmpSound" Value="4" runat="server" />

                            <div class="row ml-1">
                                <div class="col-sm-12">
                                    <label class="d-block">Quantity:</label>
                                    <asp:TextBox ID="tboxAmpSound" CssClass="d-block w-75" runat="server"
                                        ValidationGroup="AmpSound" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row ml-1 mb-3 mt-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnAmpSound" CssClass="btn btn-primary" runat="server"
                                        Text="Add to Cart" ValidationGroup="AmpSound" OnClick="btnAmpSound_Click" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:RequiredFieldValidator ID="rfvAmpSound" runat="server"
                                        ErrorMessage="Please enter a quantity." ControlToValidate="tboxAmpSound"
                                        ValidationGroup="AmpSound" Display="Dynamic" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End AmpSound --%>


                <%-- AmpKicker --%>
                <div class="col-md-4">

                    <div class="card mb-3 height position-relative">
                        <img class="card-img-top d-block img-fluid mx-auto w-75 h-75 p-3"
                            src="Content/Images/amp_kicker.jpg" alt="Card image cap" />
                        <div class="card-body middle">
                            <h5 class="card-title">Kicker KXA 400.4 Amplifier</h5>
                            <p class="card-text">This KX 400-watt four channel amplifier is built to easily power your
                                door speakers or be a full system solution. FIT2™ (Fail-Safe Integration Technology)
                                ensures your amp works with nearly any stock or aftermarket radio.</p>
                            <p class="card-text"><small class="text-muted">$329.95</small></p>
                        </div>

                        <%-- div @ bottom of card body --%>
                        <div class="bottom">
                            <asp:HiddenField ID="hidAmpKicker" Value="5" runat="server" />

                            <div class="row ml-1">
                                <div class="col-sm-12">
                                    <label class="d-block">Quantity:</label>
                                    <asp:TextBox ID="tboxAmpKicker" CssClass="d-block w-75" runat="server"
                                        ValidationGroup="AmpKicker" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row ml-1 mb-3 mt-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnAmpKicker" CssClass="btn btn-primary" runat="server"
                                        Text="Add to Cart" ValidationGroup="AmpKicker" OnClick="btnAmpKicker_Click" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:RequiredFieldValidator ID="rfvAmpKicker" runat="server"
                                        ErrorMessage="Please enter a quantity." ControlToValidate="tboxAmpKicker"
                                        ValidationGroup="AmpKicker" Display="Dynamic" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End AmpKicker --%>


                <%-- AmpPhoenix --%>
                <div class="col-md-4">

                    <div class="card mb-3 height position-relative">
                        <img class="card-img-top d-block img-fluid mx-auto w-75 h-75 p-3"
                            src="Content/Images/amp_phoenix.jpg" alt="Card image cap" />
                        <div class="card-body middle">
                            <h5 class="card-title">Phoenix Gold GX 1200W 6-Channel Full Range Class D Amplifier</h5>
                            <p class="card-text">Designed to cover a multitude of installation needs, GX is packed with
                                the features and power you can expect from the Phoenix Gold brand. Included in the line
                                are our proprietary PG quick connects for high current capability and reliability while
                                delivering uber clean and quick installations. The chassis has been optimized by
                                utilizing BFD (Balanced Flow Dissipation) to keep the amplifier running cool when the
                                music is hot.</p>
                            <p class="card-text"><small class="text-muted">$579.99</small></p>
                        </div>

                        <%-- div @ bottom of card body --%>
                        <div class="bottom">
                            <asp:HiddenField ID="hidAmpPhoenix" Value="6" runat="server" />

                            <div class="row ml-1">
                                <div class="col-sm-12">
                                    <label class="d-block">Quantity:</label>
                                    <asp:TextBox ID="tboxAmpPhoenix" CssClass="d-block w-75" runat="server"
                                        ValidationGroup="AmpPhoenix" TextMode="Number"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row ml-1 mb-3 mt-1">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnAmpPhoenix" CssClass="btn btn-primary" runat="server"
                                        Text="Add to Cart" ValidationGroup="AmpPhoenix" OnClick="btnAmpPhoenix_Click" />
                                </div>

                                <div class="col-sm-6">
                                    <asp:RequiredFieldValidator ID="rfvAmpPhoenix" runat="server"
                                        ErrorMessage="Please enter a quantity." ControlToValidate="tboxAmpPhoenix"
                                        ValidationGroup="AmpPhoenix" Display="Dynamic" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- End AmpPhoenix --%>
            </div>
            <%-- End Amplifier Row --%>
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