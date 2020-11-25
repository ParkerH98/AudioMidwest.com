<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountModification.aspx.cs" Inherits="AudioMidwest.com.accountModification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">

    <title>Modify Account</title>

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

                    <h1>Modify Account</h1>

                </div>
            </div>

            <hr />



            <%-- first name row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
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


                <div class="col-sm-4 pt-2">
                </div>

            </div>



            <%-- last name row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
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

                <div class="col-sm-4 pt-2">
                </div>

            </div>



            <%-- email row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
                    <label class="col-form-label">Email</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxEmail" class="form-control" runat="server" ReadOnly="True"></asp:TextBox>

                    <small>

                        <%-- regex format email validator --%>
                        <asp:RegularExpressionValidator ID="regexEmail" runat="server"
                            ErrorMessage="Please enter a valid email." ControlToValidate="tboxEmail"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"
                            ForeColor="Red">
                        </asp:RegularExpressionValidator>
                    </small>

                </div>

                <div class="col-sm-4 pt-2">
                </div>

            </div>



            <%-- password row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
                    <label class="col-form-label">Password</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxPassword" TextMode="Password" class="form-control" runat="server">
                    </asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                            ErrorMessage="Please enter a password." ControlToValidate="tboxPassword" ForeColor="Red"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="regexPassword" runat="server"
                            ErrorMessage="Please enter a password containing 8 to 25 characters."
                            ValidationExpression="^[a-zA-Z0-9]{8,25}$" ControlToValidate="tboxPassword"
                            Display="Dynamic" ForeColor="Red">
                        </asp:RegularExpressionValidator>
                    </small>

                </div>

                <div class="col-sm-4">
                </div>

            </div>



            <%-- password confirmation row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
                    <label class="col-form-label">Confirm Password</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxPasswordConf" TextMode="Password" class="form-control" runat="server">
                    </asp:TextBox>


                    <small>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="Please enter the password you entered above."
                            ControlToValidate="tboxPasswordConf" ForeColor="Red" Display="Dynamic">
                        </asp:RequiredFieldValidator>

                        <asp:CompareValidator ID="CompareValidator1" runat="server"
                            ErrorMessage="Password doesn't match the one above. Please enter the password you entered above."
                            ControlToValidate="tboxPasswordConf" ControlToCompare="tboxPassword" Display="Dynamic"
                            ForeColor="Red">
                        </asp:CompareValidator>
                    </small>

                </div>


                <div class="col-sm-4">
                </div>

            </div>



            <%-- phone number row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
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


                <div class="col-sm-4">
                </div>

            </div>



            <%-- primary address row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
                    <label class="col-form-label">Address</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxPrimaryAddress" class="form-control" runat="server"></asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Please enter an address." ControlToValidate="tboxPrimaryAddress"
                            ForeColor="Red" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </small>

                </div>

                <div class="col-sm-4">
                </div>

            </div>



            <%-- secondary address row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
                    <label class="col-form-label">Secondary Address (optional)</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">
                    <asp:TextBox ID="tboxSecondaryAddress" class="form-control" runat="server"></asp:TextBox>
                </div>

            </div>



            <%-- city row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
                    <label class="col-form-label">City</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxCity" class="form-control" runat="server"></asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Please enter a city." ControlToValidate="tboxCity" ForeColor="Red"
                            Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </small>

                </div>

                <%-- validation column --%>
                <div class="col-sm-4">
                </div>

            </div>


            <%-- state row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
                    <label class="col-form-label">State</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:DropDownList ID="ddlStates" runat="server" DataSourceID="sdsStates" DataTextField="StateName"
                        DataValueField="StateID">
                    </asp:DropDownList>

                    <asp:SqlDataSource ID="sdsStates" runat="server"
                        ConnectionString="<%$ ConnectionStrings:F20_ksphagueConnectionString %>"
                        SelectCommand="spSelectAllStates" SelectCommandType="StoredProcedure"></asp:SqlDataSource>

                    <small>
                        <asp:RequiredFieldValidator ID="rfvStates" runat="server" ErrorMessage="Please select a state."
                            ControlToValidate="ddlStates" ForeColor="Red" InitialValue="0" Display="Dynamic">
                        </asp:RequiredFieldValidator>
                    </small>

                </div>

                <%-- validation column --%>
                <div class="col-sm-4">
                </div>

            </div>

            <%-- zip code row --%>
            <div class="row mb-2">

                <%-- label column --%>
                <div class="col-sm-4 text-right">
                    <label class="col-form-label">Zip Code</label>
                </div>

                <%-- user input column --%>
                <div class="col-sm-4">

                    <asp:TextBox ID="tboxZip" class="form-control" runat="server" ControlToValidate="tboxZip">
                    </asp:TextBox>

                    <small>
                        <asp:RequiredFieldValidator ID="rfvZip" runat="server" ErrorMessage="Please enter a zip code."
                            ControlToValidate="tboxZip" ForeColor="Red" Display="Dynamic">
                        </asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="regexZip" runat="server"
                            ErrorMessage="Please enter a valid US zip code." Display="Dynamic" ForeColor="Red"
                            ControlToValidate="tboxZip" ValidationExpression="\d{5}(-\d{4})?">
                        </asp:RegularExpressionValidator>
                    </small>

                </div>

                <%-- validation column --%>
                <div class="col-sm-4 pt-2">
                </div>

            </div>

            <div class="row mb-5 mt-3">

                <div class="col-sm-4 offset-sm-6">
                    <asp:Button ID="btnUpdateAcct" runat="server" Text="Update Account" class="btn btn-dark"
                        OnClick="btnUpdateAcct_Click" />
                </div>

            </div>

            <div class="row mb-5 mt-3">

                <div class="col-sm-12 text-center text-muted font-weight-bold">
                    <asp:Label ID="lblMessage" runat="server" Text="Your Account has been successfully updated.">
                    </asp:Label>
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