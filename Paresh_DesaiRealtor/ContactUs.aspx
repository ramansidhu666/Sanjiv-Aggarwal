<%@ Page Title="" Language="C#" MasterPageFile="~/PropertyNew.Master" AutoEventWireup="true"
    CodeBehind="ContactUs.aspx.cs" Inherits="Property.ContactUs" %>

<%@ Register TagName="ContactInfo" TagPrefix="uc" Src="~/Controls/ContactInfo.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<title>Contact Us at 416-409-9090 For All Your Real Estate Queries</title>
<meta name="description"  content="Contact Homelife Miracle specialists for any query related to real estate property. Call us at 416-409-9090 or drop an email at info@aggarwalrealtor.ca." />
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="wrapper_new">
          <div class="row landing_page_p_pge">
        <div class="col-md-6 col-sm-6">
            <div class="contact_in_left">
                <uc:ContactInfo ID="ContactInfo" runat="Server"></uc:ContactInfo>
            </div>

        </div>
        <div class="col-md-6 col-sm-6">
            <div class="contact_in_right">
                <img src="images/contact-img-1.png" alt=""  />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
