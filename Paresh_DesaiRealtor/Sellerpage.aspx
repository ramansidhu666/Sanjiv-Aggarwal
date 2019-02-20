<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PropertyNew.Master" CodeBehind="Sellerpage.aspx.cs" Inherits="Property.Sellerpage" %>
<%@ Register TagName="GoogleMap" TagPrefix="uc"  Src="~/Controls/GoogleMap.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title><asp:Literal ID="siteTitle" runat="server"></asp:Literal></title> 


    <script src="js/jquery-1.11.1.min.js"></script>
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
                           
                              <label id="lblHeading" class="setting_hd" runat="server">Sellers </label>  <br />
                                 <label id="lblHeading1" runat="server"></label>  
                        
                        </div>
                                  <div class="frm_middle"> <span>Thank you for your interest in our offer.  We will be pleased to provide you a cash-back of up to $5000, if your home sells above $600,000 or more, to help you with staging or any repairs.

We are grateful for the privilege to serve you.   

Please contact us for more details.</span>
                                      </div>
                                <div class="login_input_new_1">
                                    <label for="Name">First Name :</label>
                                    <asp:TextBox ID="Name" CssClass="CTextBox" PlaceHolder="First Name"  runat="server" MaxLength="20"></asp:TextBox>
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
                                   <div class="frm_middle"><span class="seller_privacy">We respect your privacy, we will never sell or share your information with anyone.
Sanjiv Aggarwal & Meena Aggarwal, Salesperson, Homelife Miracle Realty Ltd. Brokerage
Direct: 416.409.9090 <br />
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