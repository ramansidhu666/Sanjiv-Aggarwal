﻿<%@ Page Title="" Language="C#" AutoEventWireup="true"   EnableViewState="false" CodeBehind="Home.aspx.cs" 
    ClientIDMode="Static" Inherits="Property.Home" %>
<%@ OutputCache Duration="60" VaryByParam="*" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<%@ Register TagName="FeaturedProperties" TagPrefix="uc" Src="~/Controls/FeaturedProperties.ascx" %>
<%@ Register TagName="Logo" TagPrefix="uc" Src="~/Controls/logo.ascx" %>
<%@ Register Src="~/Controls/SearchBar.ascx" TagPrefix="uc" TagName="SearchBar" %>
<%@ Register TagName="ContactInfo" TagPrefix="uc" Src="~/Controls/ContactInfo.ascx" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="favicon" runat="server" rel="shortcut icon" type="image/x-icon" />
       <title>Trusted Realtors in Brampton; Houses, Properties For Sale</title>
<meta name="description"  content="Find your house for sale in Mississauga, Brampton with the help of Homelife Miracle top Realtors. Contact Aggarwal Realty for buying or selling a property." />

<meta name="keywords" content="Top Realtors in Brampton, Top realtor in Brampton, House for sale in Brampton Ontario, Homes for sale in Mississauga Ontario, new homes for sale Mississauga, new homes for sale in Mississauga" />

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, minimum-scale=1, maximum-scale=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="Page-Enter" content="blendTrans(Duration=0)" />
    <meta http-equiv="Page-Exit" content="blendTrans(Duration=0)" />
    <meta name="google-site-verification" content="tMsBcUAcnkjpOzJPaZvZXaMH5OQBV8Fj3tribryazUI" />
    <!-- Global site tag (gtag.js) - Google Analytics -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=UA-126948734-1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'UA-126948734-1');
    </script>
    <script type='application/ld+json'> 
{
"@context": "http://www.schema.org",
"@type": "RealEstateAgent",
"name": "Aggarwal Realty",
"url": "https://aggarwalrealty.ca",
"image": "https://aggarwalrealty.ca/admin/uploadfiles/img-4.jpg",
"description": "With a combined professional experience of over 40 years in Sales & Customer Service, and Contract Negotiations exceeding $2B, Meena and Sanjiv, offer one-stop real estate experience to you.",
"address": {
"@type": "PostalAddress",
"streetAddress": "20-470 Chrysler Drive",
"addressLocality": "Brampton",
"addressRegion": "Ontario",
"postalCode": "L6S 0C1",
"addressCountry": "Canada"
},
"openingHours": "Mo, Tu, We, Th, Fr, Sa, Su 09:00-21:00",
"contactPoint": {
"@type": "ContactPoint",
"telephone":"4168445725"
}
}
    </script>

   
  
 <%--   <script type="text/javascript" src="js/jquery_009.js"></script>--%>
    <link  href="css/bootstrap.css" rel="stylesheet" />

    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <link href="css/font.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link href="css/styleBackup.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/nivo-slider.css" rel="stylesheet" />
    <link href="css/shortcodes.css" rel="stylesheet" />
    <link href="css/jquery.bxslider.css" rel="stylesheet" />
    <link href="slider/css/media-queries.css" rel="stylesheet" />
    <link href="css/media-queries.css" rel="stylesheet" />

   

    <style type="text/css">
        .contact_number {
            float: left;
            height: 100px;
            padding: 20px;
            position: absolute;
            top: 512px;
            z-index: 99999;
        }

            .contact_number span {
                color: white;
                font-size: 24px;
            }

        #Homebanner {
            float: left;
            margin-bottom: 0px;
            width: 100%;
        }

        #map {
            border: 2px solid #3f6f55;
            height: 229px;
            width: 90%;
        }
    </style>
    <style type="text/css">
        blockquote {
            clear: both;
            font-style: italic;
            margin-left: 10px;
            margin-right: 10px;
            padding: 10px 10px 0 50px;
            quotes: none;
            background: url(https://dl.dropbox.com/u/96099766/RotatingTestimonial/open-quote.png) 0 0 no-repeat;
            border: 0px;
            font-size: 120%;
            line-height: 200%;
        }
    </style>
</head>
<body>
    <!--header start-->
    <form id="Form2" runat="server">

        <asp:ScriptManager ID="scrmngr" EnablePageMethods="true" runat="server"  >
            
        </asp:ScriptManager>


        <div class="header_bg">
            <div class="container">
                <div class="col-md-4 col-sm-4">
                    <div class="header_detail">
                        <h2>
                            <asp:Label ID="lblBrkrOneName" CssClass="gjfdhg" runat="server"></asp:Label></h2>
                        <%--<p>Sales Representative</p>--%>
						<img src="../images/client_logo.png" class="client_logo"/>
                        <h5>
                            <span>Call: 416-409-9090</span></h5>
							
                    </div>
                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="header_logo">
                        <a href="#">
                            <img src="images/header_logo.png" alt="" /></a>
                    </div>

                </div>
                <div class="col-md-4 col-sm-4">
                    <div class="header_detail1_lang">
                        <div id="google_translate_element"></div>
                        <script type="text/javascript">
                            function googleTranslateElementInit() {
                                new google.translate.TranslateElement({ pageLanguage: 'en', layout: google.translate.TranslateElement.InlineLayout.HORIZONTAL }, 'google_translate_element');
                            }
                        </script>
                        <script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
                    </div>
                    <div class="header_detail_right">
                        <%-- <a href="#"><img src="images/MORTGAGE_BTN.png" alt="Mortgage Services" title="" /></a> --%>
                        <i class="fa fa-envelope ftr_hdng2"></i>
                        <asp:Label ID="lblemailid" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="top_menu_bg">
            <div class="container">
                <div class="row frnt_line_cls">
                    <div class="col-md-12 col-sm-12">
                        <div class="menu_section">
                            <asp:Literal ID="dynamicmenus" runat="server"></asp:Literal>
                        </div>
                      <%--  <script type="text/javascript" src="../js/script.js"></script>--%>
                    </div>
                </div>
            </div>
        </div>
        <div id="Homebanner" runat="server">
            <div class="banner_section"  >
                <img src="../admin/uploadfiles/img-1.jpg" />
               <%-- <div class="slider-wrapper theme-default">
                    <div id="slider"  class="nivoSlider">
                        <asp:Literal ID="ltrImgsf" runat="server"></asp:Literal>
                    </div>
                </div>--%>
            </div>
          <%--  <script type="text/javascript">
                $(window).load(function () {
                    $('#slider').nivoSlider();
                });
            </script>--%>
        </div>

        <!--banner end-->


      

        <div class="latst_srch">
            <div class="container">
                <div class="row frnt_line_cls">
                    <div class="col-md-12 col-sm-12">
                        <div class="ltst_srch_sct">
                            <h2>Find your Dream Home</h2>
                            <div class="input_srch_new">
                                <div class="In_bg_new">
                                    <uc:SearchBar runat="server" ID="SearchBar" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <div class="top_middle_bg">
            <div class="container">
                <div class="col-md-12 col-sm-12">
                    <div class="top_middle_content">
                        <h2>Welcome to our Website</h2>
                        <h5>Professionalism | Collaboration | Results</h5>
                        <p>With a combined professional experience of over 40 years in Sales & Customer Service, and Contract Negotiations exceeding $2B, Meena and Sanjiv, offer one-stop real estate experience to you.  We facilitate and guide you through every aspect of your real estate journey: buying or selling a property; arranging a mortgage; conducting home inspection or staging; and arranging legal services.</p>
                    </div>
                </div>
            </div>
        </div>

        <div class="main_sct_bg">
            <div class="container">
                <div class="main_sction">
                    <div class="row frnt_line_cls">
                        <div class="col-md-4 col-sm-4">
                            <div class="box_sct_bg">
                                <a href="InboxListingsPage.aspx">
                                    <div class="box_shadow">
                                        <img src="images/commleasing.jpg" alt="House for sale in Brampton Ontario" title="" />
                                    </div>
                                </a>
                            </div>

                        </div>

                        <div class="col-md-4 col-sm-4">
                            <div class="box_sct_bg">
                                <a href="NeighbourhoodPage.aspx">
                                    <div class="box_shadow">
                                        <img src="images/feature.jpg" alt="Condos for investors in Toronto" title="" />
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <div class="box_sct_bg">
                                <a href="HomeWorthPage.aspx">
                                    <div class="box_shadow">
                                        <img src="images/free.jpg" alt="Free Home Evaluation" title="" />
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div>
                    </div>

                </div>
            </div>
        </div>
        <div class="frnt_brdr">
            <img src="images/brder_frnt.jpg" alt="Border Line" title="" />
        </div>
        <div class="home_wrth_bg">
            <div class="container">
                <div class="main_sction">
                    <div class="row frnt_line_cls">
                        <div class="col-md-6 col-sm-6">
                            <div class="seller_box">
                                <a href="BuyerPage.aspx">
                                    <h2>First-time Buyers</h2>
                                </a>
                                <p>We cover up to $1500 in closing costs*</p>
                            </div>

                        </div>
                        <div class="col-md-6 col-sm-6">
                            <div class="seller_box">
                                <a href="Sellerpage.aspx">
                                    <h2>Seller</h2>
                                </a>
                                <p>Get up to $5000 in cash-back*</p>
                            </div>

                        </div>

                    </div>
                    <div>
                    </div>

                </div>
                <div class="conditions_sect">
                    <p>* Conditions Apply</p>
                </div>

            </div>
        </div>
        <div class="frnt_brdr2">
            <img src="images/brder_frnt2.jpg" alt="Border Lines" title="" />
        </div>

        <div class="circle_heading_bg">
            <div class="container">
                <div class="col-md-12 col-sm-12">
                    <div class="circle_heading">
                        <h2>Start your Home Search</h2>
                    </div>
                </div>
            </div>
        </div>

        <div class="main_sct_bg">
            <div class="container">
                <div class="main_sction">
                    <div class="row frnt_line_cls">
                        <div class="col-md-3 col-sm-3">
                            <div class="box_sct_bg">
                                <a href="/Search.aspx?Municipality=toronto%20&PropertyType=Residential">
                                    <div class="box_shadow">
                                        <img src="images/circle_1.png" alt="House for sale in Toronto" title="" />
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <div class="box_sct_bg">
                                <a href="/Search.aspx?Municipality=mississauga%20&PropertyType=Residential">
                                    <div class="box_shadow">
                                        <img src="images/circle_2.png" alt="Homes for Sale in Mississauga" title="" />
                                    </div>
                                </a>
                            </div>

                        </div>
                        <div class="col-md-3 col-sm-3">
                            <div class="box_sct_bg">
                                <a href="/Search.aspx?Municipality=north%20york%20&PropertyType=Residential">
                                    <div class="box_shadow">
                                        <img src="images/circle_3.png" alt="Houses for Sale in North York" title="" />
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <div class="box_sct_bg">
                                <a href="/Search.aspx?Municipality=richmond%20hill%20&PropertyType=Residential">
                                    <div class="box_shadow">
                                        <img src="images/circle_4.png" alt="Homes for Sale in Richmond Hill" title="" />
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="main_sct_bg">
            <div class="container">
                <div class="main_sction">
                    <div class="row frnt_line_cls">
                        <div class="col-md-3 col-sm-3">
                            <div class="box_sct_bg">
                                <a href="/Search.aspx?Municipality=brampton%20&PropertyType=Residential">
                                    <div class="box_shadow">
                                        <img src="images/circle_5.png" alt="House for Sale in Brampton Ontario" title="" />
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <div class="box_sct_bg">
                                <a href="/Search.aspx?Municipality=vaughan%20&PropertyType=Residential">
                                    <div class="box_shadow">
                                        <img src="images/circle_6.png" alt="Homes for Sale in Vaughan" title="" />
                                    </div>
                                </a>
                            </div>

                        </div>
                        <div class="col-md-3 col-sm-3">
                            <div class="box_sct_bg">
                                <a href="/Search.aspx?Municipality=kitchener%20&PropertyType=Residential">
                                    <div class="box_shadow">
                                        <img src="images/circle_7.png" alt="House for Sale in Kitchener" title="" />
                                    </div>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <div class="box_sct_bg">
                                <a href="/Search.aspx?Municipality=cambridge%20&PropertyType=Residential">
                                    <div class="box_shadow">
                                        <img src="images/circle_8.png" alt="House for Sale in Cambridge" title="" />
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="featured_bg">
            <div class="container">
                <div class="row frnt_line_cls">
                    <div class="col-md-12 col-sm-12">
                        <div class="featurd_heading">
                            <h2>Featured Listings</h2>
                        </div>
                    </div>
                </div>
                <div class="row frnt_line_cls">
                    <div class="featured_sction">
                        <asp:Repeater runat="server" ID="rptFeaturedProperties">
                            <ItemTemplate>
                                <div class="col-md-3 col-sm-3">
                                    <div class="box_section">
                                        <div class="frnt_section_box checkLogin">
                                            <div class="ftrd_property_img">
                                                <asp:HyperLink ID="hypImage" NavigateUrl=' <%# "PropertyDetails.aspx?MLSID=" + Eval("MLS") + "&PropertyType=IDXImagesResidential"%>' runat="server">
                                                            <img src='<%# Eval("pImage")%>' alt='<%# Eval("Style")%> in <%# Eval("Area")%>' width="180px" height="134"/>
                                                </asp:HyperLink>
                                            </div>
                                            <div class="featured_box_cntnt">
                                                <asp:HyperLink ID="hypAddress" NavigateUrl=' <%# "PropertyDetails.aspx?MLSID=" + Eval("MLS") + "&PropertyType=IDXImagesResidential"%>' runat="server"><%# Eval("Address") %>, <%# Eval("Municipality") %>, <%# Eval("PostalCode")%>, <%# Eval("province") %></asp:HyperLink>
                                                <p>
                                                    <asp:Label ID="lblremark" runat="server" Text='<%# Eval("ListPrice")%>'></asp:Label>
                                                </p>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <h5><a href='Featured_Properties.aspx' class="checkLogin">See All Featured Listings  >></a></h5>
                    </div>
                </div>
            </div>
        </div>
        <div class="latst_srch_bg">
            <div class="container">
                <div class="main_sction">
                    <div class="">
                        <div class="col-md-12 col-sm-12">
                            <div class="featurd_heading">
                                <h2>Pre-Constructions</h2>
                            </div>
                        </div>
                    </div>
                    <div class="">
                        <div class="featured_sction">


                            <ul id="flexiselDemo3">
                                <asp:Repeater ID="rptImages" runat="server">
                                    <ItemTemplate>
                                        <li><a href="DreamHouseDetail.aspx?ID=<%#Eval("Id")  %>">
                                            <img src='/Thumbnails_Pre_Construction/<%#Eval("ImageUrl")  %>' /></a>
                                            <h3><%#Eval("Title")  %></h3>
                                        </li>

                                    </ItemTemplate>
                                </asp:Repeater>


                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="fuutr_menu_bg">
            <div class="container">
                <div class="col-md-12 col-sm-12">
                    <div class="futer_mennu">
                        <ul>
                             <li><a href="../About.aspx">About us</a></li>
                            <li><a href="../VirtualTour.aspx">Virtual Tour</a></li>
                            <li><a href="../View_Testimonials.aspx">Testimonials</a></li>
                            <li><a href="../RealEstateNews.aspx">Real Estate News</a></li>
                            <li><a href="../ContactUs.aspx">Contact Us</a></li>
                            <li><a href="../admin/adminlogin.aspx">Admin Login</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="fuuter_bg" id="one-footer">
            <div class="container">
                <div class="col-md-5 col-sm-5">
                    <figure class="logo">
                        <uc:Logo ID="logo" runat="server" />
                        <%--<img src="images/futer_img_sect.jpg" alt="Homelife Mircale Realty Ltd" title="" />--%>
                    </figure>
                </div>
                <%--<div class="col-md-3 col-sm-3">
                <div class="fuuter_name">
                        <h5>Address</h5>
                    </div>
                <div class="fuuter_map">
                 <h5>144 Simcoe Street <br/>
                    Toronto, Ontario, Canada M5H 4E9</h5>
                </div>
            </div>--%>

                <div class="col-md-4 col-sm-4">
                    <div class="fuuter_name">
                        <h5>Follow Me</h5>
                    </div>
                    <ul class="scoico_icns_frnt">
                        <li><a href="https://www.facebook.com/AggarwalRealty" target="_blank">
                            <img alt="Facebook Icon" src="images/fb_icn_new.png" /></a></li>
                        <li><a href="https://twitter.com/aggarwalrealty" target="_blank">
                            <img alt="Twitter Icon" src="images/twiter_icn_new.png" /></a></li>
                        <li><a href="https://www.instagram.com/aggarwalrealty" target="_blank">
                            <img alt="Instagram Icon" src="images/insta_new_icn.png" /></a></li>
							 <li><a href="https://www.pinterest.ca/aggarwalrealty" target="_blank">
                            <img alt="Instagram Icon" src="images/pintrest_icon_new.png" /></a></li>
                    </ul>

                </div>
                <div class="col-md-3 col-sm-3">
                    <div class="fuuter_name">
                        <h5>Contact Info</h5>
                    </div>
                    <div class="fuuter_map">
                        <h5>Email:<a href="mailto:info@aggarwalrealty.ca"><asp:Label ID="lblemail" runat="server"></asp:Label></a></h5>
                        <h5>Cell: <a href="tel:416-409-9090">
                            <asp:Label ID="lblmobile2" runat="server"></asp:Label></a></h5>
                    </div>
                </div>
                <div class="col-md-12 col-sm-12">
                    <div class="Design_and_developed">

                        <p>
                            Designed & Developed by <a href="http://only4agents.com/">Only4Agents</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <div class="fuutr_phne_bg">
            <div class="futer_mail_bg">
                <div class="futer_mail">
                    <ul>
                        <li><a href="mailto:info@aggarwalrealty.ca">
                            <img alt="Mail Icon" src="images/mail_icnnn.png" /></a></li>
                        <li><a href="tel:416-409-9090">
                            <img alt="Mobile Phone Icon" src="images/mbl_icnnn.png" /></a></li>
                        <li><a href="sms:416-409-9090">
                            <img alt="SMS" src="images/sms.png" /></a></li>
                    </ul>
                </div>
            </div>

        </div>
    </form>
</body>


</html>
 <script type="text/javascript"  src="js/jquery-1.11.1.min.js" ></script>
    <script type="text/javascript" src="js/jquery.flexisel.js" defer></script>
    <script type="text/javascript" src="js/jquery.nivo.slider.js" defer></script>
    <script  src="js/jquery.bxslider.min.js" defer></script>
  <script type="text/javascript" src="../js/script.js" defer></script>
<script type="text/javascript">

    $(window).load(function () {
        $("#flexiselDemo1").flexisel();
        $("#flexiselDemo2").flexisel({
            enableResponsiveBreakpoints: true,
            responsiveBreakpoints: {
                portrait: {
                    changePoint: 480,
                    visibleItems: 1
                },
                landscape: {
                    changePoint: 640,
                    visibleItems: 2
                },
                tablet: {
                    changePoint: 768,
                    visibleItems: 3
                }
            }
        });

        $("#flexiselDemo3").flexisel({
            visibleItems: 5,
            animationSpeed: 800,
            autoPlay: true,
            autoPlaySpeed: 4000,
            pauseOnHover: true,
            enableResponsiveBreakpoints: true,
            responsiveBreakpoints: {
                portrait: {
                    changePoint: 480,
                    visibleItems: 1
                },
                landscape: {
                    changePoint: 640,
                    visibleItems: 2
                },
                tablet: {
                    changePoint: 768,
                    visibleItems: 3
                }
            }
        });

        $("#flexiselDemo4").flexisel({
            clone: false
        });

    });
</script>
  <script type="text/javascript">
                $(window).load(function () {
                    $('#slider').nivoSlider();
                });
            </script>