using Property_cls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Property
{
    public partial class Sellerpage : System.Web.UI.Page
    {
        cls_Property clsobj = new cls_Property();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Municipality"] = Request.QueryString["Municipality"];
            DataTable dt = clsobj.GetUserInfo();


            DataTable dt1 = clsobj.GetSiteSettings();
            if (dt1.Rows.Count > 0)
            {
                siteTitle.Text = Convert.ToString(dt1.Rows[0]["Title"]);
                // lblemail.Text = Convert.ToString(dt.Rows[0]["Email"]);
            }
            string path = HttpContext.Current.Request.RawUrl;
            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string UserEmailId = ConfigurationManager.AppSettings["RegFromMailAddress"].ToString();
                string ToEmailId = ConfigurationManager.AppSettings["ToEmailID"].ToString();
                SendMailToAdmin(UserEmailId);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Success", "alert('Thanks for Submitting! Someone from our team will contact you shortly');", true);
                clear();
            }
            catch (Exception ex)
            {
            }
            finally
            { }
        }
        public void SendMailToAdmin(string UserEmailId)
        {
            MailMessage mail = new MailMessage();
            string ToEmailID = ConfigurationManager.AppSettings["ToEmailID"].ToString(); //From Email & To Email are same for admin
            //string ToEmailPassword = ConfigurationManager.AppSettings["ToEmailPassword"].ToString();
            string FromEmailID = ConfigurationManager.AppSettings["RegFromMailAddress"].ToString();
            string FromEmailPassword = ConfigurationManager.AppSettings["RegPassword"].ToString();
            string _Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();
            int _Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
            Boolean _UseDefaultCredentials = false;
            Boolean _EnableSsl = true;
            mail.To.Add(ToEmailID);
            mail.From = new MailAddress(FromEmailID);
            mail.Subject = "Sellers - Contact";
            string body = "";
            body = "<p>First Name : " + Name.Text + "</p>";
            body = body + "<p>Last Name : " + txtlastname.Text + "</p>";
            body = body + "<p>Email ID : " + Email.Text + "</p>";
            body = body + "<p>Phone Number : " + PhoneNumber.Text + "</p>";
           
            mail.Body = body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = _Host;
            smtp.Port = _Port;
            smtp.UseDefaultCredentials = _UseDefaultCredentials;
            smtp.Credentials = new System.Net.NetworkCredential
            (FromEmailID, FromEmailPassword);// Enter senders User name and password
            smtp.EnableSsl = _EnableSsl;
            smtp.Send(mail);
        }
        public void SendMailToUser(string UserEmailId)
        {
            // Send mail.
            MailMessage mail = new MailMessage();

            string ToEmailID = Email.Text; //From Email & To Email are same for admin
            string FromEmailID = ConfigurationManager.AppSettings["RegFromMailAddress"].ToString();
            string FromEmailPassword = ConfigurationManager.AppSettings["RegPassword"].ToString();

            string _Host = ConfigurationManager.AppSettings["SmtpServer"].ToString();
            int _Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"].ToString());
            Boolean _UseDefaultCredentials = false;
            Boolean _EnableSsl = true;

            mail.To.Add(ToEmailID);
            mail.From = new MailAddress(FromEmailID);
            mail.Subject = "Aggarwal Realty";
            string body = "";
            body = "<p>Thanks for contacting us.</p>";
            mail.Body = body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = _Host;
            smtp.Port = _Port;
            smtp.UseDefaultCredentials = _UseDefaultCredentials;
            smtp.Credentials = new System.Net.NetworkCredential
            (FromEmailID, FromEmailPassword);// Enter senders User name and password
            smtp.EnableSsl = _EnableSsl;
            smtp.Send(mail);
        }
        public void clear()
        {
            txtlastname.Text = "";
            Name.Text = "";
            Email.Text = "";
            PhoneNumber.Text = "";

        }
    }
}