<%@ Page Title="" Language="C#" MasterPageFile="~/PropertyNew.Master" AutoEventWireup="true"
    CodeBehind="PremiumCalculator.aspx.cs" Inherits="Property.PremiumCalculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title><asp:Literal ID="siteTitle" runat="server"></asp:Literal></title> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="free_nw_cls_bg">
        <div class="col-md-2 col-sm-2">
    </div>
       <div class="col-md-8 col-sm-8">
       <div class="chmc_calculator">
            <h2>CMHC Premium Calculator</h2>
       <div style="float:left; width:100%; margin-top:16px;">  <div class="widget" data-widget="calc-payment" data-cmhc="only" data-lang="en"></div><div style="text-align:right;">  <a href="https://www.ratehub.ca/" style="display:inline-block;width:80px;margin-top:.5em;"><img src="https://www.ratehub.ca/assets/images/widget-logo.png" style="width:100%;" alt="RateHub logo"></a></div><script type="text/javascript" src="https://www.ratehub.ca/assets/js/widget-loader.js"></script></div>
    </div>
     
    </div>
        <div class="col-md-2 col-sm-2">
    </div>
    </div>
</asp:Content>
