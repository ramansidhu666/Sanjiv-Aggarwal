<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PropertyNew.Master" CodeBehind="InboxListingsPage.aspx.cs" Inherits="Property.InboxListingsPage" %>

<%@ Register TagName="GoogleMap" TagPrefix="uc" Src="~/Controls/GoogleMap.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">


<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG_M1SCro3nb4pQtbHp-oqcrILQIVom3s&libraries=places,geometry"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('MainContent_txtSearch'));
            google.maps.event.addListener(places, 'place_changed', function () {
            });
        });
    </script>

  <title>New Homes for Sale in Mississauga, Brampton, Toronto & GTA</title>
<meta name="description"  content="Find new homes for sale according to your real estate property needs. Buy a dream house in Mississauga, Greater Toronto Area, Brampton, & Toronto, Ontario." />
<meta name="keywords" content="new Homefor sale in Brampton Ontario, new homes for sale Mississauga, Homes For Sale in Greater Toronto Area, Houses for sale in Toronto Ontario" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="background_home_worth">
    
            <div class="col-md-3 col-sm-3">
            </div>
            <div class="col-md-6 col-sm-6">
                <div class="free_nw_cls_bg_new">
                    <div id="custom-form-aside">
                        <div style="display: block;">
                            <div class="landing_page_p">

                                <label id="lblHeading" class="setting_hd" runat="server">Get Listings in your Inbox Every Morning</label>
                               

                            </div>
                            
                            <div class="login_input_new_1">
                                 <label for="Search">Search by Address:</label>
                                <asp:TextBox  id="txtSearch" class="MainContentSearchBar" runat="server" placeholder="Type address" ></asp:TextBox>
                            </div>
                                  <div class="login_input_new_1">
                                    <label for="Radius">Radius:</label>
                                    <asp:DropDownList PlaceHolder="Radius" ID="Radius" runat="server">
                                        <asp:ListItem Value="200" Selected="true">200 Meters</asp:ListItem>
                                        <asp:ListItem Value="250">250 Meters</asp:ListItem>
                                        <asp:ListItem Value="300">300 Meters</asp:ListItem>
                                        <asp:ListItem Value="350">350 Meters</asp:ListItem>
                                        <asp:ListItem Value="400">400 Meters</asp:ListItem>
                                        <asp:ListItem Value="500">500 Meters</asp:ListItem>
                                        <asp:ListItem Value="600">600 Meters</asp:ListItem>
                                        <asp:ListItem Value="700">700 Meters</asp:ListItem>
                                        <asp:ListItem Value="800">800 Meters</asp:ListItem>
                                        <asp:ListItem Value="900">900 Meters</asp:ListItem>
                                        <asp:ListItem Value="1000">1000 Meters</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="login_input_new_1">
                <label>Type of Home</label>
                <%--<asp:DropDownList ID="ddlPropertyType" runat="server">
                </asp:DropDownList>--%>
                                    <asp:DropDownList ID="ddlPropertyType" runat="server">
                                       
	<asp:ListItem value="Detached" Selected="True">Detached</asp:ListItem>
	<asp:ListItem value="Att/Row/Twnhouse">Att/Row/Twnhouse</asp:ListItem>
	<asp:ListItem value="Semi-Detached">Semi-Detached</asp:ListItem>
	<asp:ListItem value="Vacant Land">Vacant Land</asp:ListItem>
	<asp:ListItem value="Link">Link</asp:ListItem>
	<asp:ListItem value="Cottage">Cottage</asp:ListItem>
	<asp:ListItem value="Farm">Farm</asp:ListItem>
	<asp:ListItem value="Duplex">Duplex</asp:ListItem>
	<asp:ListItem value="Rural Resid">Rural Resid</asp:ListItem>
	<asp:ListItem value="Multiplex">Multiplex</asp:ListItem>
	<asp:ListItem value="Store W/Apt/Offc">Store W/Apt/Offc</asp:ListItem>
	<asp:ListItem value="Triplex">Triplex</asp:ListItem>
	<asp:ListItem value="Other">Other</asp:ListItem>
	<asp:ListItem value="Lower Level">Lower Level</asp:ListItem>
	<asp:ListItem value="Fourplex">Fourplex</asp:ListItem>
	<asp:ListItem value="Mobile/Trailer">Mobile/Trailer</asp:ListItem>
	<asp:ListItem value="Upper Level">Upper Level</asp:ListItem>
	<asp:ListItem value="Room">Room</asp:ListItem>
	<asp:ListItem value=""></asp:ListItem>
     </asp:DropDownList>
            </div>
            <div class="login_input_new_1">
                <label>Beds</label>
                <asp:DropDownList ID="ddlBeds" runat="server">
                    <asp:ListItem Value="0" Selected="True">Any</asp:ListItem>
                    <asp:ListItem Value="1">1+</asp:ListItem>
                    <asp:ListItem Value="2">2+</asp:ListItem>
                    <asp:ListItem Value="3">3+</asp:ListItem>
                    <asp:ListItem Value="4">4+</asp:ListItem>
                    <asp:ListItem Value="5">5+</asp:ListItem>
                    <asp:ListItem Value="6">6+</asp:ListItem>
                    <asp:ListItem Value="7">7+</asp:ListItem>
                    <asp:ListItem Value="8">8+</asp:ListItem>
                    <asp:ListItem Value="9">9+</asp:ListItem>
                    <asp:ListItem Value="10">10+</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="login_input_new_1">
                <label>Baths</label>
                <asp:DropDownList ID="ddlBaths" runat="server">
                    <asp:ListItem Value="0" Selected="True">Any</asp:ListItem>
                    <asp:ListItem Value="1">1+</asp:ListItem>
                    <asp:ListItem Value="2">2+</asp:ListItem>
                    <asp:ListItem Value="3">3+</asp:ListItem>
                    <asp:ListItem Value="4">4+</asp:ListItem>
                    <asp:ListItem Value="5">5+</asp:ListItem>
                    <asp:ListItem Value="6">6+</asp:ListItem>
                    <asp:ListItem Value="7">7+</asp:ListItem>
                    <asp:ListItem Value="8">8+</asp:ListItem>
                    <asp:ListItem Value="9">9+</asp:ListItem>
                    <asp:ListItem Value="10">10+</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="login_input_new_1">
                <label>Min Price</label>
                <asp:DropDownList ID="ddlMinPrice" runat="server">
                    <asp:ListItem Value="">Min Price</asp:ListItem>
                    <asp:ListItem Value="100000">$100,000</asp:ListItem>
                    <asp:ListItem Value="125000">$125,000</asp:ListItem>
                    <asp:ListItem Value="150000">$150,000</asp:ListItem>
                    <asp:ListItem Value="175000">$175,000</asp:ListItem>
                    <asp:ListItem Value="200000">$200,000</asp:ListItem>
                    <asp:ListItem Value="225000">$225,000</asp:ListItem>
                    <asp:ListItem Value="250000">$250,000</asp:ListItem>
                    <asp:ListItem Value="275000">$275,000</asp:ListItem>
                    <asp:ListItem Value="300000">$300,000</asp:ListItem>
                    <asp:ListItem Value="325000">$325,000</asp:ListItem>
                    <asp:ListItem Value="350000">$350,000</asp:ListItem>
                    <asp:ListItem Value="375000">$375,000</asp:ListItem>
                    <asp:ListItem Value="400000">$400,000</asp:ListItem>
                    <asp:ListItem Value="425000">$425,000</asp:ListItem>
                    <asp:ListItem Value="450000">$450,000</asp:ListItem>
                    <asp:ListItem Value="475000">$475,000</asp:ListItem>
                    <asp:ListItem Value="500000">$500,000</asp:ListItem>
                    <asp:ListItem Value="525000">$525,000</asp:ListItem>
                    <asp:ListItem Value="550000">$550,000</asp:ListItem>
                    <asp:ListItem Value="575000">$575,000</asp:ListItem>
                    <asp:ListItem Value="600000">$600,000</asp:ListItem>
                    <asp:ListItem Value="625000">$625,000</asp:ListItem>
                    <asp:ListItem Value="650000">$650,000</asp:ListItem>
                    <asp:ListItem Value="675000">$675,000</asp:ListItem>
                    <asp:ListItem Value="700000">$700,000</asp:ListItem>
                    <asp:ListItem Value="725000">$725,000</asp:ListItem>
                    <asp:ListItem Value="750000">$750,000</asp:ListItem>
                    <asp:ListItem Value="775000">$775,000</asp:ListItem>
                    <asp:ListItem Value="800000">$800,000</asp:ListItem>
                    <asp:ListItem Value="825000">$825,000</asp:ListItem>
                    <asp:ListItem Value="850000">$850,000</asp:ListItem>
                    <asp:ListItem Value="875000">$875,000</asp:ListItem>
                    <asp:ListItem Value="900000">$900,000</asp:ListItem>
                    <asp:ListItem Value="925000">$925,000</asp:ListItem>
                    <asp:ListItem Value="950000">$950,000</asp:ListItem>
                    <asp:ListItem Value="975000">$975,000</asp:ListItem>
                    <asp:ListItem Value="1000000">$1,000,000</asp:ListItem>
                    <asp:ListItem Value="1050000">$1,050,000</asp:ListItem>
                    <asp:ListItem Value="1100000">$1,100,000</asp:ListItem>
                    <asp:ListItem Value="1150000">$1,150,000</asp:ListItem>
                    <asp:ListItem Value="1200000">$1,200,000</asp:ListItem>
                    <asp:ListItem Value="1250000">$1,250,000</asp:ListItem>
                    <asp:ListItem Value="1300000">$1,300,000</asp:ListItem>
                    <asp:ListItem Value="1350000">$1,350,000</asp:ListItem>
                    <asp:ListItem Value="1400000">$1,400,000</asp:ListItem>
                    <asp:ListItem Value="1450000">$1,450,000</asp:ListItem>
                    <asp:ListItem Value="1500000">$1,500,000</asp:ListItem>
                    <asp:ListItem Value="1550000">$1,550,000</asp:ListItem>
                    <asp:ListItem Value="1600000">$1,600,000</asp:ListItem>
                    <asp:ListItem Value="1650000">$1,650,000</asp:ListItem>
                    <asp:ListItem Value="1700000">$1,700,000</asp:ListItem>
                    <asp:ListItem Value="1750000">$1,750,000</asp:ListItem>
                    <asp:ListItem Value="1800000">$1,800,000</asp:ListItem>
                    <asp:ListItem Value="1850000">$1,850,000</asp:ListItem>
                    <asp:ListItem Value="1900000">$1,900,000</asp:ListItem>
                    <asp:ListItem Value="1950000">$1,950,000</asp:ListItem>
                    <asp:ListItem Value="2000000">$2,000,000</asp:ListItem>
                    <asp:ListItem Value="2500000">$2,500,000</asp:ListItem>
                    <asp:ListItem Value="3000000">$3,000,000</asp:ListItem>
                    <asp:ListItem Value="3500000">$3,500,000</asp:ListItem>
                    <asp:ListItem Value="4000000">$4,000,000</asp:ListItem>
                    <asp:ListItem Value="4500000">$4,500,000</asp:ListItem>
                    <asp:ListItem Value="5000000">$5,000,000</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="login_input_new_1">
                <label>Max Price</label>
                <asp:DropDownList ID="ddlMaxPrice" runat="server">
                    <asp:ListItem Value="0">Max Price</asp:ListItem>
                    <asp:ListItem Value="100000">$100,000</asp:ListItem>
                    <asp:ListItem Value="125000">$125,000</asp:ListItem>
                    <asp:ListItem Value="150000">$150,000</asp:ListItem>
                    <asp:ListItem Value="175000">$175,000</asp:ListItem>
                    <asp:ListItem Value="200000">$200,000</asp:ListItem>
                    <asp:ListItem Value="225000">$225,000</asp:ListItem>
                    <asp:ListItem Value="250000">$250,000</asp:ListItem>
                    <asp:ListItem Value="275000">$275,000</asp:ListItem>
                    <asp:ListItem Value="300000">$300,000</asp:ListItem>
                    <asp:ListItem Value="325000">$325,000</asp:ListItem>
                    <asp:ListItem Value="350000">$350,000</asp:ListItem>
                    <asp:ListItem Value="375000">$375,000</asp:ListItem>
                    <asp:ListItem Value="400000">$400,000</asp:ListItem>
                    <asp:ListItem Value="425000">$425,000</asp:ListItem>
                    <asp:ListItem Value="450000">$450,000</asp:ListItem>
                    <asp:ListItem Value="475000">$475,000</asp:ListItem>
                    <asp:ListItem Value="500000">$500,000</asp:ListItem>
                    <asp:ListItem Value="525000">$525,000</asp:ListItem>
                    <asp:ListItem Value="550000">$550,000</asp:ListItem>
                    <asp:ListItem Value="575000">$575,000</asp:ListItem>
                    <asp:ListItem Value="600000">$600,000</asp:ListItem>
                    <asp:ListItem Value="625000">$625,000</asp:ListItem>
                    <asp:ListItem Value="650000">$650,000</asp:ListItem>
                    <asp:ListItem Value="675000">$675,000</asp:ListItem>
                    <asp:ListItem Value="700000">$700,000</asp:ListItem>
                    <asp:ListItem Value="725000">$725,000</asp:ListItem>
                    <asp:ListItem Value="750000">$750,000</asp:ListItem>
                    <asp:ListItem Value="775000">$775,000</asp:ListItem>
                    <asp:ListItem Value="800000">$800,000</asp:ListItem>
                    <asp:ListItem Value="825000">$825,000</asp:ListItem>
                    <asp:ListItem Value="850000">$850,000</asp:ListItem>
                    <asp:ListItem Value="875000">$875,000</asp:ListItem>
                    <asp:ListItem Value="900000">$900,000</asp:ListItem>
                    <asp:ListItem Value="925000">$925,000</asp:ListItem>
                    <asp:ListItem Value="950000">$950,000</asp:ListItem>
                    <asp:ListItem Value="975000">$975,000</asp:ListItem>
                    <asp:ListItem Value="1000000">$1,000,000</asp:ListItem>
                    <asp:ListItem Value="1050000">$1,050,000</asp:ListItem>
                    <asp:ListItem Value="1100000">$1,100,000</asp:ListItem>
                    <asp:ListItem Value="1150000">$1,150,000</asp:ListItem>
                    <asp:ListItem Value="1200000">$1,200,000</asp:ListItem>
                    <asp:ListItem Value="1250000">$1,250,000</asp:ListItem>
                    <asp:ListItem Value="1300000">$1,300,000</asp:ListItem>
                    <asp:ListItem Value="1350000">$1,350,000</asp:ListItem>
                    <asp:ListItem Value="1400000">$1,400,000</asp:ListItem>
                    <asp:ListItem Value="1450000">$1,450,000</asp:ListItem>
                    <asp:ListItem Value="1500000">$1,500,000</asp:ListItem>
                    <asp:ListItem Value="1550000">$1,550,000</asp:ListItem>
                    <asp:ListItem Value="1600000">$1,600,000</asp:ListItem>
                    <asp:ListItem Value="1650000">$1,650,000</asp:ListItem>
                    <asp:ListItem Value="1700000">$1,700,000</asp:ListItem>
                    <asp:ListItem Value="1750000">$1,750,000</asp:ListItem>
                    <asp:ListItem Value="1800000">$1,800,000</asp:ListItem>
                    <asp:ListItem Value="1850000">$1,850,000</asp:ListItem>
                    <asp:ListItem Value="1900000">$1,900,000</asp:ListItem>
                    <asp:ListItem Value="1950000">$1,950,000</asp:ListItem>
                    <asp:ListItem Value="2000000">$2,000,000</asp:ListItem>
                    <asp:ListItem Value="2500000">$2,500,000</asp:ListItem>
                    <asp:ListItem Value="3000000">$3,000,000</asp:ListItem>
                    <asp:ListItem Value="3500000">$3,500,000</asp:ListItem>
                    <asp:ListItem Value="4000000">$4,000,000</asp:ListItem>
                    <asp:ListItem Value="4500000">$4,500,000</asp:ListItem>
                    <asp:ListItem Value="5000000">$5,000,000</asp:ListItem>
                </asp:DropDownList>
                <asp:CompareValidator runat="server" ID="cmpNumberss" CssClass="clsCompare" ControlToValidate="ddlMaxPrice"
                    ControlToCompare="ddlMinPrice" Operator="GreaterThan" Type="Integer" ErrorMessage="Price greater than minimum price  " />
            </div>
                             
                             <div class="frm_middle">
                                <p>Where should we send this information to?</p>
                               </div>
                            <div class="login_input_new_1">
                                <label for="Name">First Name :</label>
                                <asp:TextBox ID="Name" CssClass="CTextBox" PlaceHolder="First Name" runat="server" MaxLength="20"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                    ControlToValidate="Name" ErrorMessage="Only alphabets are allowed"
                                    ForeColor="Red" ValidationGroup="SaveAppointment" Display="Dynamic" ValidationExpression="^[a-zA-Z ]+$"> </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="reqName" runat="server" ErrorMessage=" Name is Required"
                                    ControlToValidate="Name" ForeColor="Red" ValidationGroup="SaveInfo"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="login_input_new_1">
                                <label for="Name">Last name:</label>
                                <asp:TextBox ID="txtlastname" CssClass="CTextBox" PlaceHolder="Last name" runat="server" MaxLength="20"></asp:TextBox>
                            </div>

                            <div class="login_input_new_1">
                                <label for="Email">E-mail:</label>
                                <asp:TextBox ID="Email" CssClass="CTextBox" PlaceHolder="E-mail" runat="server" MaxLength="30"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="E-mail Required" ControlToValidate="Email"
                                    ValidationGroup="SaveInfo" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ControlToValidate="Email" ValidationGroup="SaveInfo" ForeColor="Red" ErrorMessage="Invalid email!" Display="Dynamic">  
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="login_input_new_1">
                                <label for="PhoneNumber">Cell Phone:</label>
                                <asp:TextBox ID="PhoneNumber" CssClass="CTextBox" PlaceHolder="Cell Phone" runat="server" MaxLength="20"></asp:TextBox>
                            </div>
                            <div class="frm_middle">
                            <span>
                               We respect your privacy, we will never sell or share your information with anyone.
Sanjiv Aggarwal & Meena Aggarwal, Salesperson, Homelife Miracle Realty Ltd. Brokerage
Direct: 416.409.9090
                                <br />
                             <a href="PrivacyPolicy.aspx">Privacy Policy</a> 	 |  <a href="Terms.aspx">Terms of Use</a></span>
                                </div>
                            <div class="login_input_new_1">
                                <asp:Button ID="btnSearch" ValidationGroup="SaveInfo" runat="server" Text="Submit" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3 col-sm-3">
            </div>
       
    </div>
</asp:Content>
