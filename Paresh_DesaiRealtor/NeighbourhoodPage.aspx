<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PropertyNew.Master" CodeBehind="NeighbourhoodPage.aspx.cs" Inherits="Property.NeighbourhoodPage" %>

<%@ Register TagName="GoogleMap" TagPrefix="uc" Src="~/Controls/GoogleMap.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>Get Know What Your Neighbours Are Selling</title>
<meta name="description"  content="Get know what your neighbours are selling to visit at AggarwalRealty.Ca. We offer a complete information for real estate properties for sale in Toronto." />
<meta name="keywords" content="real estate property for sale in Toronto" />
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDxw4-H4Y1ig9brfwS9Qwt8wCNE96ueVhE&libraries=places,geometry"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('MainContent_txtSearch'));
            google.maps.event.addListener(places, 'place_changed', function () {
            });
        });
    </script>
   
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

                                <label id="lblHeading" class="setting_hd" runat="server">Instant update when your neighbours are Selling</label>
                              <%-- <span>Instant update when your neighbours are selling</span>--%>

                            </div>
                            
                            <div class="login_input_new_1">
                                <label for="Search">Search by Postal Code, or MLS ID:</label>
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
                                <label for="City">Type of Home :</label>
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
