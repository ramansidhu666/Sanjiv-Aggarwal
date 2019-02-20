using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Property_cls;
using System.Xml.Linq;


namespace Property
{
    public class GoogleDistanceDuration
    {
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLongitude { get; set; }
        public double EndLatitude { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public int Duration { get; set; }
        public decimal Distance { get; set; }
        public string Language { get; set; }
    }
    public partial class Search : System.Web.UI.Page
    {
        #region Global

        cls_Property clsobj = new cls_Property();

        int findex, lindex;
        public int CurrentPage
        {
            get
            {
                if (ViewState["CurrentPage"] != null)
                {
                    return Convert.ToInt32(ViewState["CurrentPage"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["CurrentPage"] = value; }
        }

        #endregion Global

        #region PageLoad

        protected void Page_Load(object sender, EventArgs e)
        {
            string page = Request.Url.Segments[Request.Url.Segments.Length - 1];
            var city = Request.QueryString["Municipality"];
            if(city!=null)
            {
            if(city.Contains("toronto"))
            {
                siteTitle.Text = "Homes For Sale in Toronto Area - Aggarwal Realty";
                //Add Keywords Meta Tag
                HtmlMeta keywords = new HtmlMeta();
                keywords.HttpEquiv = "keywords";
                keywords.Name = "keywords";
                keywords.Content = "new homes for sale Toronto, houses for sale Toronto area";
                this.Page.Header.Controls.Add(keywords);

                //Add Description Meta Tag
                HtmlMeta description = new HtmlMeta();
                description.HttpEquiv = "description";
                description.Name = "description";
                description.Content = "Start your search today to find homes for sale in Toronto. Check out our real estate listings to visit Aggarwalrealty.ca.";
                this.Page.Header.Controls.Add(description);
            }
            else if (city.Contains("richmond"))
            {
                siteTitle.Text = "Buy Your Dream House in Richmond Hill - Aggarwal Realty";
                //Add Keywords Meta Tag
                HtmlMeta keywords = new HtmlMeta();
                keywords.HttpEquiv = "keywords";
                keywords.Name = "keywords";
                keywords.Content = "buy a dream house in Richmond Hill, CA, buy a dream house in Richmond Hill";
                this.Page.Header.Controls.Add(keywords);

                //Add Description Meta Tag
                HtmlMeta description = new HtmlMeta();
                description.HttpEquiv = "description";
                description.Name = "description";
                description.Content = "AggarwalRealty.ca, the best property portal to buy a dream house in Richmond Hill, CA. Explore listings images, features, & amenities to visit our website.";
                this.Page.Header.Controls.Add(description);
            }
            else if (city.Contains("brampton"))
            {
                siteTitle.Text = "Luxury House for Sale in Brampton, Ontario - Aggarwal Realty";
                //Add Keywords Meta Tag
                HtmlMeta keywords = new HtmlMeta();
                keywords.HttpEquiv = "keywords";
                keywords.Name = "keywords";
                keywords.Content = "house for sale in brampton, ontario, house for sale in brampton";
                this.Page.Header.Controls.Add(keywords);

                //Add Description Meta Tag
                HtmlMeta description = new HtmlMeta();
                description.HttpEquiv = "description";
                description.Name = "description";
                description.Content = "Seeking to buy luxury homes in Brampton? We at AggarwalRealty.ca, can help you to buy spacious homes for sale in Brampton, Ontario. Visit us today!";
                this.Page.Header.Controls.Add(description);
            }
            else if (city.Contains("oakville"))
            {
                siteTitle.Text = "Luxury House for Sale in oakville, Ontario - Aggarwal Realty";
                //Add Keywords Meta Tag
                HtmlMeta keywords = new HtmlMeta();
                keywords.HttpEquiv = "keywords";
                keywords.Name = "keywords";
                keywords.Content = "house for sale in brampton, ontario, house for sale in brampton";
                this.Page.Header.Controls.Add(keywords);

                //Add Description Meta Tag
                HtmlMeta description = new HtmlMeta();
                description.HttpEquiv = "description";
                description.Name = "description";
                description.Content = "AggarwalRealty.ca, the best property portal to buy a dream house in Waterloo. Browse our listings images, features, & amenities to visit our website!";
                this.Page.Header.Controls.Add(description);
            }
            else if (city.Contains("Caledon"))
            {
                siteTitle.Text = "Real Estate Properties for Sale in Caledon, Ontario - Aggarwal Realty";
                
                //Add Description Meta Tag
                HtmlMeta description = new HtmlMeta();
                description.HttpEquiv = "description";
                description.Name = "description";
                description.Content = "If you are looking to buy real estate properties, AggarwalRealty must be your one stop destination. Choose from our collection of properties in Caledon.";
                this.Page.Header.Controls.Add(description);
            }
            else if (city.Contains("Vaughan"))
            {
                siteTitle.Text = "Real Estate Propertie for Sale in Vaughan, Ontario - Aggarwal Realty";
               
                //Add Description Meta Tag
                HtmlMeta description = new HtmlMeta();
                description.HttpEquiv = "description";
                description.Name = "description";
                description.Content = "Looking to buy real estate property? AggarwalRealty.ca is your one stop solution. Choose from our huge collection of properties in Cambridge.";
                this.Page.Header.Controls.Add(description);

            }


            }
        }
        #endregion PageLoad
      

      
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static String[] GetAutoCompleteData(string prefixText, int count, string contextKey)
        {
            List<String> itemNames = new List<String>();
            Property1.MLSDataWebServiceSoapClient ml = new Property1.MLSDataWebServiceSoapClient();
            DataTable dt = ml.GetAutoCompleteData(prefixText);
            foreach (DataRow dr in dt.Rows)
            {
                String item = dr["Province"].ToString();

                itemNames.Add(item);
            }
            string[] prefixTextArray = itemNames.ToArray();
            return prefixTextArray;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static String[] GetAutoCompleteData_Comm(string prefixText, int count, string contextKey)
        {
            List<String> itemNames = new List<String>();
            Property1.MLSDataWebServiceSoapClient ml = new Property1.MLSDataWebServiceSoapClient();
            DataTable dt = ml.GetAutoCompleteData_Comm(prefixText);
            foreach (DataRow dr in dt.Rows)
            {
                String item = dr["Province"].ToString();

                itemNames.Add(item);
            }
            string[] prefixTextArray = itemNames.ToArray();
            return prefixTextArray;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static String[] GetAutoCompleteData_Condo(string prefixText, int count, string contextKey)
        {
            List<String> itemNames = new List<String>();
            Property1.MLSDataWebServiceSoapClient ml = new Property1.MLSDataWebServiceSoapClient();
            DataTable dt = ml.GetAutoCompleteData_Condo(prefixText);
            foreach (DataRow dr in dt.Rows)
            {
                String item = dr["Province"].ToString();

                itemNames.Add(item);
            }
            string[] prefixTextArray = itemNames.ToArray();
            return prefixTextArray;
        }

        #region Pagination Repeater Events

        #endregion Pagination Repeater Events

        //#region Search methods
        //void SearchResidentialProperties()
        //{
        //    try
        //    {
        //        Property1.MLSDataWebServiceSoapClient mlsClient = new Property1.MLSDataWebServiceSoapClient();
        //        DataTable dt = new DataTable();
        //        if (Convert.ToString(Session["QueryString"]) == "Residential" && Session["Municipality"] == null)
        //        {
        //            dt = mlsClient.GetResidentialProperties("0", "0", "0", "0", "0", "0", "0");
        //        }
        //        else if (Session["Municipality"] != null)
        //        {
        //            dt = mlsClient.GetResidentialProperties(Session["Municipality"].ToString(), "0", "0", "0", "0", "0", "0");
        //        }
        //        else
        //        {
        //            dt = mlsClient.GetResidentialProperties(Session["SearchText"].ToString(), Session["HomeType"].ToString(), Session["MinPrice"].ToString(), Session["MaxPrice"].ToString(), Session["Beds"].ToString(), Session["Baths"].ToString(), Session["SaleLease"].ToString());
        //        }

        //        DataTable dtt = new DataTable();
        //        dtt.Columns.AddRange(new DataColumn[5] { new DataColumn("lat"), new DataColumn("long"), new DataColumn("Address"), new DataColumn("Listprice"), new DataColumn("Remarksforclients") });

        //        foreach (DataRow dCol in dt.Rows)
        //        {
        //            string address = dCol["Address"].ToString() + " " + dCol["Municipality"].ToString();
        //            string Listprice = dCol["Listprice"].ToString();
        //            string Remarksforclients = dCol["Remarksforclients"].ToString();
        //            //var url = String.Format("http://maps.google.com/maps/api/geocode/xml?address={0}&sensor=false", HttpContext.Current.Server.UrlEncode(address));

        //            //// Load the XML into an XElement object (whee, LINQ to XML!)
        //            //var results = XElement.Load(url);


        //            //var status = results.Element("status").Value;
        //            //if (status != "OK" && status != "ZERO_RESULTS")
        //            //    // Whoops, something else was wrong with the request...
        //            //    throw new ApplicationException("There was an error with Google's Geocoding Service: " + status);


        //            //if (((System.Xml.Linq.XText)(((System.Xml.Linq.XContainer)(results.Element("status"))).FirstNode)).Value == "OK")
        //            //{
        //            //    // Set the latitude and longtitude parameters based on the address being searched on
        //            //    var lat = results.Element("result").Element("geometry").Element("location").Element("lat").Value;
        //            //    var lng = results.Element("result").Element("geometry").Element("location").Element("lng").Value;
        //            //    dtt.Rows.Add(lat, lng, address, Listprice, Remarksforclients);

        //            //}
        //            GoogleDistanceDuration googleDistanceDuration = new GoogleDistanceDuration();
        //            googleDistanceDuration.StartAddress = address;
        //            googleDistanceDuration.EndAddress = address;
        //            googleDistanceDuration.Language = "en";

        //            googleDistanceDuration = GetDirectionByAddress(googleDistanceDuration);
        //            var lat = googleDistanceDuration.StartLatitude;
        //            var lng = googleDistanceDuration.StartLongitude;
        //            dtt.Rows.Add(lat, lng, address, Listprice, Remarksforclients);
        //        }

        //        if (dt.Rows.Count > 0)
        //        {
        //            //rptMarkers.DataSource = dtt;
        //            //rptMarkers.DataBind();
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {

        //    }
        //}

        //void SearchCommercialProperties()
        //{
        //    try
        //    {
        //        Property1.MLSDataWebServiceSoapClient mlsClient = new Property1.MLSDataWebServiceSoapClient();
        //        DataTable dt = new DataTable();
        //        if (Convert.ToString(Session["QueryString"]) == "Commercial" && Session["Municipality"] == null)
        //        {
        //            dt = mlsClient.GetAllCommercialProperties("0", "0", "0", "0", "0", "0");
        //        }
        //        else if (Session["Municipality"] != null)
        //        {
        //            dt = mlsClient.GetAllCommercialProperties(Session["Municipality"].ToString(), "0", "0", "0", "0", "0");
        //        }
        //        else
        //        {
        //            // Session["Beds"].ToString(),
        //            dt = mlsClient.GetAllCommercialProperties(Session["SearchText"].ToString(), Session["HomeType"].ToString(), Session["MinPrice"].ToString(), Session["MaxPrice"].ToString(), Session["Baths"].ToString(), Session["SaleLease"].ToString());
        //        }

        //        DataTable dtt = new DataTable();
        //        dtt.Columns.AddRange(new DataColumn[5] { new DataColumn("lat"), new DataColumn("long"), new DataColumn("Address"), new DataColumn("Listprice"), new DataColumn("Remarksforclients") });

        //        foreach (DataRow dCol in dt.Rows)
        //        {
        //            string address = dCol["Address"].ToString() + " " + dCol["Municipality"].ToString();
        //            string Listprice = dCol["Listprice"].ToString();
        //            string Remarksforclients = dCol["Remarksforclients"].ToString();
        //            //var url = String.Format("http://maps.google.com/maps/api/geocode/xml?address={0}&sensor=false", HttpContext.Current.Server.UrlEncode(address));

        //            //// Load the XML into an XElement object (whee, LINQ to XML!)
        //            //var results = XElement.Load(url);


        //            //var status = results.Element("status").Value;
        //            //if (status != "OK" && status != "ZERO_RESULTS")
        //            //    // Whoops, something else was wrong with the request...
        //            //    throw new ApplicationException("There was an error with Google's Geocoding Service: " + status);


        //            //if (((System.Xml.Linq.XText)(((System.Xml.Linq.XContainer)(results.Element("status"))).FirstNode)).Value == "OK")
        //            //{
        //            //    // Set the latitude and longtitude parameters based on the address being searched on
        //            //    var lat = results.Element("result").Element("geometry").Element("location").Element("lat").Value;
        //            //    var lng = results.Element("result").Element("geometry").Element("location").Element("lng").Value;
        //            //    dtt.Rows.Add(lat, lng, address, Listprice, Remarksforclients);

        //            //}
        //            GoogleDistanceDuration googleDistanceDuration = new GoogleDistanceDuration();
        //            googleDistanceDuration.StartAddress = address;
        //            googleDistanceDuration.EndAddress = address;
        //            googleDistanceDuration.Language = "en";

        //            googleDistanceDuration = GetDirectionByAddress(googleDistanceDuration);
        //            var lat = googleDistanceDuration.StartLatitude;
        //            var lng = googleDistanceDuration.StartLongitude;
        //            dtt.Rows.Add(lat, lng, address, Listprice, Remarksforclients);
        //        }

        //        if (dt.Rows.Count > 0)
        //        {
        //            //rptMarkers.DataSource = dtt;
        //            //rptMarkers.DataBind();
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {

        //    }

        //}

        //void SearchCondoProperties()
        //{
        //    try
        //    {
        //        Property1.MLSDataWebServiceSoapClient mlsClient = new Property1.MLSDataWebServiceSoapClient();
        //        DataTable dt = new DataTable();
        //        if (Convert.ToString(Session["QueryString"]) == "Condo" && Session["Municipality"] == null)
        //        {
        //            dt = mlsClient.GetProperties_Condo("0", "0", "0", "0", "0", "0", "0");
        //        }
        //        else if (Session["Municipality"] != null)
        //        {
        //            dt = mlsClient.GetProperties_Condo(Session["Municipality"].ToString(), "0", "0", "0", "0", "0", "0");
        //        }
        //        else
        //        {
        //            dt = mlsClient.GetProperties_Condo(Session["SearchText"].ToString(), Session["HomeType"].ToString(), Session["MinPrice"].ToString(), Session["MaxPrice"].ToString(), Session["Beds"].ToString(), Session["Baths"].ToString(), Session["SaleLease"].ToString());
        //        }

        //        DataTable dtt = new DataTable();
        //        dtt.Columns.AddRange(new DataColumn[5] { new DataColumn("lat"), new DataColumn("long"), new DataColumn("Address"), new DataColumn("Listprice"), new DataColumn("Remarksforclients") });

        //        foreach (DataRow dCol in dt.Rows)
        //        {
        //            string address = dCol["Address"].ToString() + " " + dCol["Municipality"].ToString();
        //            string Listprice = dCol["Listprice"].ToString();
        //            string Remarksforclients = dCol["Remarksforclients"].ToString();
        //            //var url = String.Format("http://maps.google.com/maps/api/geocode/xml?address={0}&sensor=false", HttpContext.Current.Server.UrlEncode(address));

        //            //// Load the XML into an XElement object (whee, LINQ to XML!)
        //            //var results = XElement.Load(url);


        //            //var status = results.Element("status").Value;
        //            //if (status != "OK" && status != "ZERO_RESULTS")
        //            //    // Whoops, something else was wrong with the request...
        //            //    throw new ApplicationException("There was an error with Google's Geocoding Service: " + status);


        //            //if (((System.Xml.Linq.XText)(((System.Xml.Linq.XContainer)(results.Element("status"))).FirstNode)).Value == "OK")
        //            //{
        //            //    // Set the latitude and longtitude parameters based on the address being searched on
        //            //    var lat = results.Element("result").Element("geometry").Element("location").Element("lat").Value;
        //            //    var lng = results.Element("result").Element("geometry").Element("location").Element("lng").Value;
        //            //    dtt.Rows.Add(lat, lng, address, Listprice, Remarksforclients);

        //            //}
        //            GoogleDistanceDuration googleDistanceDuration = new GoogleDistanceDuration();
        //            googleDistanceDuration.StartAddress = address;
        //            googleDistanceDuration.EndAddress = address;
        //            googleDistanceDuration.Language = "en";

        //            googleDistanceDuration = GetDirectionByAddress(googleDistanceDuration);
        //            var lat = googleDistanceDuration.StartLatitude;
        //            var lng = googleDistanceDuration.StartLongitude;
        //            dtt.Rows.Add(lat, lng, address, Listprice, Remarksforclients);
        //        }

        //        if (dt.Rows.Count > 0)
        //        {
        //            //rptMarkers.DataSource = dtt;
        //            //rptMarkers.DataBind();
        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {

        //    }
        //}

        //void SearchResidentialPropertiesListing()
        //{
        //    try
        //    {


        //        Property1.MLSDataWebServiceSoapClient mlsClient = new Property1.MLSDataWebServiceSoapClient();
        //        DataTable dt = mlsClient.GetResidentialProperties(Session["Municipality"].ToString(), "0", "0", "0", "0", "0", "0");

        //        //upSearch.Visible = true;
        //        PagedDataSource pagedData = new PagedDataSource();
        //        pagedData.DataSource = dt.DefaultView;
        //        pagedData.AllowPaging = true;
        //        pagedData.PageSize = 8;
        //        pagedData.CurrentPageIndex = CurrentPage;
        //        ViewState["totpage"] = pagedData.PageCount;

        //        //lnkPrevious.Visible = !pagedData.IsFirstPage;
        //        //lnkNext.Visible = !pagedData.IsLastPage;
        //        //lnkFirst.Visible = !pagedData.IsFirstPage;
        //        //lnkLast.Visible = !pagedData.IsLastPage;

        //        //rptSearchResults.DataSource = pagedData;
        //        //rptSearchResults.DataBind();

        //        //rptSearchResultList.DataSource = pagedData;
        //        //rptSearchResultList.DataBind();

        //        //doPaging();
        //        //RepeaterPaging.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
        //        mlsClient = null;
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {

        //    }
        //}
        //#endregion Search Methods

        //#region Other Methods

        //public string GetPropertyDetails(string propDetail)
        //{
        //    int indexof = 0;
        //    if (propDetail.LastIndexOf(" ") > 145)
        //    {
        //        indexof = propDetail.IndexOf(" ", 145);
        //        ViewState["IndexOf"] = indexof;
        //        return propDetail.Substring(0, indexof) + "...";
        //    }
        //    else
        //        return propDetail;
        //}

        //public string CheckVirtualTour(string virtualTour)
        //{
        //    if (virtualTour == "null")
        //        return "";
        //    else
        //        return "Virtual Tour Available : <a  target='_blank' href=" + virtualTour + ">Click Here</a>";
        //}

        //#endregion Other Methods 


    }

}

