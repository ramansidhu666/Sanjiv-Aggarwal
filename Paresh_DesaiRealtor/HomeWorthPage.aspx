<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PropertyNew.Master" CodeBehind="HomeWorthPage.aspx.cs" Inherits="Property.HomeWorthPage" %>

<%@ Register TagName="GoogleMap" TagPrefix="uc" Src="~/Controls/GoogleMap.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Get Free Home Evaluation in GTA - Aggarwal Realty</title>
<meta name="description"  content="Get a free evaluation of your house for sale in GTA by highly qualified & professional real estate agents- Sanjiv & Meena Aggarwal." />
<meta name="keywords" content="Home Evaluation, Free Home Evaluation,  Free Home Evaluation in Toronto, What is my home worth, Toronto’s Professional real estate agents" />

  
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
     <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBG_M1SCro3nb4pQtbHp-oqcrILQIVom3s&libraries=places,geometry"></script>
     <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('MainContent_txtSearch'));
            google.maps.event.addListener(places, 'place_changed', function () {
            });
        });
    </script>

    <title></title>

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

                                <label id="lblHeading" class="setting_hd" runat="server">Free Home Evaluation</label>
                                <br />
                                <label id="lblHeading1" runat="server"></label>
                                <%-- <span>Please provide us with your address</span>--%>
                            </div>
                              <div class="login_input_new_1">
                                 <label for="Search">Search by Address:</label>
                                <asp:TextBox  id="txtSearch" class="MainContentSearchBar" runat="server" placeholder="Type address" ></asp:TextBox>
                            </div>
                            <div class="login_input_new_1">
                                <label for="Unit">Unit(if any):</label>
                                <asp:TextBox ID="txtUnit" CssClass="CTextBox" PlaceHolder="Unit" runat="server" MaxLength="20"></asp:TextBox>
                            </div>
                            <div class="login_input_new_1">
                                <label for="City">City :</label>
                                <asp:TextBox ID="txtCity" CssClass="CTextBox" PlaceHolder="City" runat="server" MaxLength="20"></asp:TextBox>
                               
                            </div>
                            <div class="login_input_new_1">
                                <label for="Province">Province:</label>
                                <asp:TextBox ID="txtProvince" CssClass="CTextBox" PlaceHolder="Province" runat="server" MaxLength="20"></asp:TextBox>
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
