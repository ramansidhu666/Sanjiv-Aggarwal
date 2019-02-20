using Newtonsoft.Json;
using Property.Models;
using Property_cls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Property
{
    public partial class Home : System.Web.UI.Page
    {
        #region Global
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        cls_Property clsobj = new cls_Property();

        #endregion Global
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["FirstName"] = null;
                BindMenusList();
                SiteSetting();
               // bindBnanners();
                GetImages();
                GetFeaturedProperties();
                //GetTestimonials();
            }
        }
        void GetFeaturedProperties()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = clsobj.GetTopNFeturedProperties("4");

                //for (int i = 0; i <= dt.Rows.Count - 1; i++)
                //{
                //    dt.Rows[i][1] = dt.Rows[i][1].ToString().Replace("http://webservices.only4agents.com", " retsimages");
                //}
                rptFeaturedProperties.DataSource = dt;

                rptFeaturedProperties.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {

            }
        }

        private void BindMenusList()
        {
            StringBuilder StrMenu = new StringBuilder();
            DataTable dt = new DataTable();
            DataTable dtSubmenu = new DataTable();
            dt = clsobj.GetMenuList();



            if (dt.Rows.Count > 0)
            {
                string PageName = dt.Rows[0]["PageName"].ToString();
                StrMenu.Append("<a class='toggleMenu' href='#'></a>");
                StrMenu.Append("<ul class='nav'>");
                StrMenu.Append("<li class='test'><a href='../Home.aspx' title='Home' class='active'>Home</a></li>");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsobj.PageID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    dtSubmenu = clsobj.GetSubMenuBy_PageID();
                    //check if it has submenu 
                    if (dtSubmenu.Rows.Count > 0)
                    {
                        StrMenu.Append("<li><a href=#>" + dt.Rows[i]["PageName"] + "</a>");//</li>
                        StrMenu.Append("<ul>");
                        for (int j = 0; j < dtSubmenu.Rows.Count; j++)
                        {
                            StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dtSubmenu.Rows[j]["id"] + "' title='" + dtSubmenu.Rows[j]["PageName"] + "'>" + dtSubmenu.Rows[j]["PageName"] + "</a> </li>");
                        }
                        StrMenu.Append("</ul>");
                        StrMenu.Append("</li>");
                    }
                    else
                    {
                        StrMenu.Append("<li><a href='../StaticPages.aspx?PageID=" + dt.Rows[i]["id"] + "' title='" + dt.Rows[i]["PageName"] + "'>" + dt.Rows[i]["PageName"] + "</a>");//</li>
                    }
                }

                //StrMenu.Append("<li class='test' style='background:none;'><a href='Admin/Adminlogin.aspx' title='Login'>Login</a></li>");
                StrMenu.Append("<li style='background:none;'><a href='HomeWorthPage.aspx' title='Home Evaluation'>Free Home Evaluation</a></li>");
                StrMenu.Append("<li>");
                StrMenu.Append("<a href='InboxListingsPage.aspx' title='Find your Dream Home'>Find your Dream Home</a>");
                StrMenu.Append("</li>");

                //StrMenu.Append("<li>");
                //StrMenu.Append("<a href='../RealEstateNews.aspx' title='Real Estate News'>Real Estate News</a>");
                //StrMenu.Append("</li>");

                StrMenu.Append("<li style='background:none;'><a href='Calculators.aspx' title='Calculators'>Calculators</a></li>");
                StrMenu.Append("<li class='test' style='background:none;'><a href='ContactUs.aspx' title='Contact Us'>Contact Us</a></li>");
                //StrMenu.Append("<li class='test' style='background:none;'><a href='admin/adminlogin.aspx' title='Login'>Login</a></li>");
                StrMenu.Append("</ul>"); ;


            }


            dynamicmenus.Text = StrMenu.ToString();

        }
        public void GetImages()
        {
            Property1.MLSDataWebServiceSoapClient mlsClient = new Property1.MLSDataWebServiceSoapClient();
            //DataTable dt = mlsClient.GetImageByMLSID(Convert.ToString(Request.QueryString["MLSID"]));

            DataTable dt = clsobj.GetDreamHouseList();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    var hghg = row["ImageUrl"].ToString();
                    string[] a = hghg.Split('.');
                    row["ImageUrl"] = a[0] + "_thumb." + a[1];
                }
                rptImages.DataSource = dt;
                rptImages.DataBind();
                //sliderDiv.Visible = true;
                //sliderImageEmpty.Visible = false;
            }
            else
            {
                //sliderDiv.Visible = false;
                //sliderImageEmpty.Visible = true;
            }

            mlsClient = null;
        }
        protected void SiteSetting()
        {
            try
            {
                DataTable dt = clsobj.GetSiteSettings();
                DataTable dt1 = clsobj.GetUserInfo();
                if (dt.Rows.Count > 0)
                {
                    lblemailid.Text = Convert.ToString(dt.Rows[0]["Email"]);

                    lblemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    lblmobile2.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    //lblmobile.Text = Convert.ToString(dt.Rows[0]["Mobile"]);
                    //lblfax.Text = Convert.ToString(dt.Rows[0]["Fax"]);
                    //lblemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
                    if (dt1.Rows.Count > 0)
                    {
                        lblBrkrOneName.Text = Convert.ToString(dt1.Rows[0]["FirstName"]) + " " + Convert.ToString(dt1.Rows[0]["LastName"]);
                    }

                    byte[] favimage = (byte[])dt.Rows[0]["Favicon.ico"];
                    if (favimage.Length > 0)
                    {
                        Session["MyFavicon"] = favimage;
                        favicon.Visible = true;
                        favicon.Href = "~/ShowFavicon.aspx";
                    }
                    else
                    {
                        favicon.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void bindBnanners()
        {
            StringBuilder html = new StringBuilder();
            DataTable dt = clsobj.GetAllBanner();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string Images;
                Images = "/admin/uploadfiles/" + dt.Rows[i]["FileName"].ToString();
                if (Images != "")
                {
                    html.AppendLine("<img src='" + Images + "'  data-thumb='" + Images + "'  alt='banner" + i + "' />");
                }
                break;
            }
           // ltrImgsf.Text = html.ToString();
        }
       // protected void Page_Load(object sender, EventArgs e)
       // {
            //TrackUsers();
       // }
        public void TrackUsers()
        {

            var locationService = new GoogleLocationService();
            var ip = Request.ServerVariables["REMOTE_ADDR"]; ;
            IpInfo ipinfo = GetUserCountryByIp(ip);
            if (ipinfo.Loc != null)
            {

                string[] latlong = ipinfo.Loc.Split(',');
                ipinfo.Loc = clsobj.GetAddressFromLatLong(Convert.ToDouble(latlong[0]), Convert.ToDouble(latlong[1]));

            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_InsertTrackRecord";
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@Ip", ipinfo.Ip == null ? "" : ipinfo.Ip);
            cmd.Parameters.AddWithValue("@Hostname", ipinfo.Hostname == null ? "" : ipinfo.Hostname);
            cmd.Parameters.AddWithValue("@City", ipinfo.City == null ? "" : ipinfo.City);
            cmd.Parameters.AddWithValue("@Region", ipinfo.Region == null ? "" : ipinfo.Region);
            cmd.Parameters.AddWithValue("@Country", ipinfo.Country == null ? "" : ipinfo.Country);
            cmd.Parameters.AddWithValue("@Loc", ipinfo.Loc == null ? "" : ipinfo.Loc);
            cmd.Parameters.AddWithValue("@Org", ipinfo.Org == null ? "" : ipinfo.Org);
            cmd.Parameters.AddWithValue("@Postal", ipinfo.Postal == null ? "" : ipinfo.Postal);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            cmd.ExecuteNonQuery();
        }
        public static IpInfo GetUserCountryByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }

            return ipInfo;
        }
    }
}