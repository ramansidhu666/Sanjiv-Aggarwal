using Property_cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Property
{
    public partial class Seller : System.Web.UI.Page
    {
        cls_Property clsobj = new cls_Property();
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteSetting();
            cls_Property clsobj = new cls_Property();
            DataTable dt = clsobj.GetSiteSettings();
            if (dt.Rows.Count > 0)
            {
                siteTitle.Text = Convert.ToString(dt.Rows[0]["Title"]);
                // lblemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
            }
        }
        protected void SiteSetting()
        {
            try
            {
                DataTable dt = clsobj.GetSiteSettings();
                DataTable dt1 = clsobj.GetUserInfo();
                if (dt.Rows.Count > 0)
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void addre_submit_Click(object sender, EventArgs e)
        {
            string s = search.Value;
            Response.Redirect("~/Review_home_worth.aspx?address=" + search.Value + "&Seller", false);
         }
    }
}