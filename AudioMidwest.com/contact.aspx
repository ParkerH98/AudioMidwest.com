﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="AudioMidwest.com.contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Contact Us</title>

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
    <link href="Content/CSS/accountCreation_styles.css" rel="stylesheet" />

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

                    <h1>Questions, Comments, or Concerns?</h1>
                    <h2>Leave a Message Below and We'll Be Happy to Reply</h2>

                </div>
            </div>

            <hr />

            <%-- first name row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 lbl-right">
                    <label class="col-form-label">First Name</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxFirstName" class="form-control" runat="server"></asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server"
                            ErrorMessage="Please enter your first name." ControlToValidate="tboxFirstName"
                            ForeColor="Red" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </small>

                </div>

                <%-- validation column --%>
                <div class="col-sm-4 pt-2">
                </div>

            </div>


            <%-- last name row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 lbl-right">
                    <label class="col-form-label">Last Name</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxLastName" class="form-control" runat="server"></asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="rfvLastName" runat="server"
                            ErrorMessage="Please enter your last name." ControlToValidate="tboxLastName" ForeColor="Red"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </small>

                </div>

                <%-- validation column --%>
                <div class="col-sm-4 pt-2">
                </div>

            </div>


            <%-- email row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 lbl-right">
                    <label class="col-form-label">Email</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxEmail" class="form-control" runat="server"></asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please enter your email."
                            ControlToValidate="tboxEmail" ForeColor="Red" Display="Dynamic">
                        </asp:RequiredFieldValidator>

                        <%-- regex format email validator --%>
                        <asp:RegularExpressionValidator ID="regexEmail" runat="server"
                            ErrorMessage="Please enter a valid email." ControlToValidate="tboxEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                            ForeColor="Red">
                        </asp:RegularExpressionValidator>
                    </small>

                </div>

                <%-- validation column --%>
                <div class="col-sm-4 pt-2">
                </div>

            </div>


            <%-- phone number row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 lbl-right">
                    <label class="col-form-label">Phone Number</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxPhoneNumber" class="form-control" runat="server"></asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="Please enter a phone number." ControlToValidate="tboxPhoneNumber"
                            ForeColor="Red" Display="Dynamic">
                        </asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ErrorMessage="Please enter a valid US phone number." ControlToValidate="tboxPhoneNumber"
                            ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}" Display="Dynamic"
                            ForeColor="Red">
                        </asp:RegularExpressionValidator>
                    </small>

                </div>

                <%-- validation column --%>
                <div class="col-sm-4">
                </div>

            </div>


            <%-- paragraph row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 lbl-right">
                    <label class="col-form-label">Message</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxMessage" class="form-control" runat="server" TextMode="MultiLine">
                    </asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="rfvMessage" runat="server"
                            ErrorMessage="Please leave a message." ControlToValidate="tboxMessage" ForeColor="Red"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>

                    </small>

                </div>

                <%-- validation column --%>
                <div class="col-sm-4 pt-2">
                </div>

            </div>


            <div class="row mb-5 mt-3">

                <div class="col-sm-4 offset-sm-6">
                    <asp:Button ID="btnCreateAcct" runat="server" Text="Submit" class="btn btn-dark" OnClick="btnCreateAcct_Click" />
                </div>

            </div>

            <div class="row mb-5 mt-3">

                <div class="col-sm-12 text-center">
                    <asp:Label ID="lblEmailMsg" CssClass="text-muted font-weight-bold" runat="server" Text="Your message has been sent." Visible="False"></asp:Label>
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
<script src="Scripts/format.js"></script>

</html>