using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Property_Cryptography;
using Property_cls;
using System.Net.Mail;
using System.IO;
using System.Web.Configuration;
using Property.Models;

namespace Property.Admin
{using System.Configuration;

    public partial class PostCard : System.Web.UI.Page
    {

        #region Global

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        Cryptography crpt = new Cryptography();

        String strSortExpression = "", strSortDirection = "";
        int intPageIndex = 0;

        public String GridViewSortDirection
        {
            get
            {
                if (ViewState["GridViewSortDirection"] == null)
                {
                    return "DESC";
                }
                else
                {
                    return ViewState["GridViewSortDirection"].ToString();
                }
            }

            set
            {
                ViewState["GridViewSortDirection"] = value;
            }

        }

        String GetSortDirection()
        {
            String GridViewSortDirectionNew;

            switch (GridViewSortDirection)
            {
                case "DESC":
                    GridViewSortDirectionNew = "ASC";
                    break;
                case "ASC":
                    GridViewSortDirectionNew = "DESC";
                    break;
                default:
                    GridViewSortDirectionNew = "DESC";
                    break;

            }
            GridViewSortDirection = GridViewSortDirectionNew;
            return GridViewSortDirectionNew;

        }

        #endregion Global
        #region Page Load
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["FirstName"] != null)
            {
                if (!IsPostBack)
                {
                    FillGridData();
                    Session["SliderType"] = "Postcard";
                    getPostcardDetails();
                }
            }
            else
            {
                Response.Redirect("~/Admin/AdminLogin.aspx", false);
            }
        }

        #endregion Page Load

        #region Grid Events & Methods

        protected void FillGridData()
       {
            DataView dv = new DataView();
            dv.Table = GetAdminClients();

            if (strSortExpression != "" && strSortDirection != "")
            {
                dv.Sort = strSortExpression + " " + strSortDirection;
            }
          if(dv.Count>0)
          {
              btnDelete.Visible = true;
              grdUsers.DataSource = dv;
              grdUsers.DataBind();
          }
          else
          {
              grdUsers.DataSource = dv;
              grdUsers.DataBind();
              alertMSG.Visible = true;
              btnDelete.Visible = false;
          }
           

            if (intPageIndex != 0)
                grdUsers.PageIndex = intPageIndex;

        }
        protected string GetHiddenValue()
        {
            string Rslt = "";
            foreach (GridViewRow gvrow in grdUsers.Rows)
            {
                CheckBox ChkBoxHeader = (CheckBox)grdUsers.HeaderRow.FindControl("chkdeleteAll");
                CheckBox chkdelete = (CheckBox)gvrow.FindControl("chkdelete");
                if (chkdelete.Checked)
                {
                    HiddenField ID = gvrow.FindControl("hdnID") as HiddenField;
                    Rslt += ID.Value + ",";
                }
            }
            Rslt = Rslt.TrimEnd(',');
            return Rslt;
        }
        

        protected DataTable GetAdminClients()
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string str = "select * from [AdminClient]";
                SqlDataAdapter adp = new SqlDataAdapter(str, conn);
                adp.Fill(dt);
                dt.TableName = "AdminClient";
            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        protected void grdUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                strSortExpression = e.SortExpression;
                strSortDirection = GetSortDirection();
                intPageIndex = grdUsers.PageIndex;
                FillGridData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdUsers.PageIndex = e.NewPageIndex;
                FillGridData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Label lblPassword = (Label)e.Row.FindControl("lblPassword");
                //lblPassword.Text = crpt.Decrypt(lblPassword.Text);
            }
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument == "delete")
            {
                foreach (GridViewRow gvrow in grdUsers.Rows)
                {
                    HiddenField ID = gvrow.FindControl("hdnID") as HiddenField;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "delete from  [dbo].[AdminClient] where user id ='" + ID + "'";
                }
            }
        }

        #endregion Grid Events & Methods
        #region Button Click

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashBoard.aspx");
        }

        protected void btnBack2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDashBoard.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PostCardModel Model = new PostCardModel();
                string SelectedIds = GetHiddenValue();
                Model.PostcardType = hdnTemplateType.Value;

                if (Model.PostcardType == "Openhouse")
                {

                    Model = Openhouse( Model);  //function for opnehouse postcard

                }
                else if (Model.PostcardType == "feature")
                {

                    Model = FeaturedPostcard(Model);  //function for featured postcard

                }
                else if (Model.PostcardType == "2ndfeature")
                {

                    Model = secndFeaturedPostcard(Model);  //function for 2nd featured postcard

                }
                else if (Model.PostcardType == "jst_sold")
                {

                    Model = jstSold_Postcard(Model);  //function for 2nd featured postcard

                }

                SendMailTo(SelectedIds, Model);

                Response.Redirect("~/Admin/postcard.aspx", false);
            }

            catch (Exception ex)
            {
                //throw ex;
            }
        }

        #endregion Button Click
        public void getPostcardDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string str = "select * from [Postcard]";
                SqlDataAdapter adp = new SqlDataAdapter(str, conn);
                adp.Fill(dt);
                dt.TableName = "Postcard";
            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
            }
            if (dt.Rows.Count > 0)
            {
                FirstContent.Text = dt.Rows[0]["col1"].ToString();
                SecondContent.Text = dt.Rows[0]["col2"].ToString();
                ThirdContent.Text = dt.Rows[0]["col3"].ToString();
                txtDesc1.Text = dt.Rows[0]["colDesc"].ToString();

                First_feature_cntnt.Text = dt.Rows[1]["col1"].ToString();
                Second_feature_cntnt.Text = dt.Rows[1]["col1"].ToString();
                Thirld_feature_cntnt.Text = dt.Rows[1]["col3"].ToString();
                Fourth_feature_cntnt.Text = dt.Rows[1]["col4"].ToString();
                txtDesc2.Text = dt.Rows[0]["colDesc"].ToString();
            

                ftr_2nd_1stcntnt.Text = dt.Rows[2]["col1"].ToString();
                ftr_2nd_2ndcntnt.Text = dt.Rows[2]["col1"].ToString();
                ftr_2nd_3rdcntnt.Text = dt.Rows[2]["col3"].ToString();
                ftr_2nd_4thcntnt.Text = dt.Rows[2]["col4"].ToString();
                txtDesc3.Text = dt.Rows[0]["colDesc"].ToString();

                jsthold_1stcntnt.Text = dt.Rows[3]["col1"].ToString();
                jsthold_2ndcntnt.Text = dt.Rows[3]["col1"].ToString();
                jsthold_3rdcntnt.Text = dt.Rows[3]["col3"].ToString();
                jsthold_4thcntnt.Text = dt.Rows[3]["col4"].ToString();
                jsthold_5thcntnt.Text = dt.Rows[3]["col5"].ToString();
                jsthold_6thcntnt.Text = dt.Rows[3]["col6"].ToString();
                jsthold_7thcntnt.Text = dt.Rows[3]["col7"].ToString();
                jsthold_8thcntnt.Text = dt.Rows[3]["col8"].ToString();
                jsthold_9thcntnt.Text = dt.Rows[3]["col9"].ToString();
                jsthold_10thcntnt.Text = dt.Rows[3]["col10"].ToString();
                jsthold_11thcntnt.Text = dt.Rows[3]["col11"].ToString();
                jsthold_12thcntnt.Text = dt.Rows[3]["col12"].ToString();
                jsthold_13thcntnt.Text = dt.Rows[3]["col13"].ToString();
                jsthold_14thcntnt.Text = dt.Rows[3]["col14"].ToString();
            }
        }

        protected void btnSavePostcard1_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString.ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Postcard SET col1 = @col1, col2 = @col2,col3=@col3,colDesc=@colDesc where postcardNo=@postcardNo";
                cmd.Parameters.AddWithValue("@col1", FirstContent.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col2", SecondContent.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col3", ThirdContent.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@colDesc", txtDesc1.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@postcardNo", 1);
                cmd.Connection = conn;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                if (openhousefile.HasFile)
                {
                    openhousefile.SaveAs(Server.MapPath("/PostCardImages//open_house_img.jpg"));

                }
                if (openhousefile2.HasFile)
                {
                    openhousefile2.SaveAs(Server.MapPath("/PostCardImages//open_house_img2.jpg"));

                }

            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


        }
        protected void btnSavePostcard2_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString.ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Postcard SET col1 = @col1, col2 = @col2,col3=@col3,col4=@col4,colDesc=@colDesc where postcardNo=@postcardNo";
                cmd.Parameters.AddWithValue("@col1", First_feature_cntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col2", Second_feature_cntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col3", Thirld_feature_cntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col4", Fourth_feature_cntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@colDesc", txtDesc2.Text);
                cmd.Parameters.AddWithValue("@postcardNo", 2);
                cmd.Connection = conn;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                if (First_feature_Image.HasFile)
                {
                    First_feature_Image.SaveAs(Server.MapPath("/PostCardImages//featurd_img1.png"));

                }
                if (secd_feature_Image.HasFile)
                {
                    secd_feature_Image.SaveAs(Server.MapPath("/PostCardImages//featrd_img1_back.png"));

                }
                if (thrld_feature_Image.HasFile)
                {
                    thrld_feature_Image.SaveAs(Server.MapPath("/PostCardImages//featrd_img2_back.jpg"));

                }
                if (forth_feature_Image.HasFile)
                {
                    forth_feature_Image.SaveAs(Server.MapPath("/PostCardImages//featrd_img3_back.jpg"));

                }
                if (fifth_feature_Image.HasFile)
                {
                    fifth_feature_Image.SaveAs(Server.MapPath("/PostCardImages//featrd_img4_back.jpg"));

                }
            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


        }
        protected void btnSavePostcard3_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString.ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Postcard SET col1 = @col1, col2 = @col2,col3=@col3,col4=@col4,colDesc=@colDesc where postcardNo=@postcardNo";
                cmd.Parameters.AddWithValue("@col1", ftr_2nd_1stcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col2", ftr_2nd_2ndcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col3", ftr_2nd_3rdcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col4", ftr_2nd_4thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@colDesc", txtDesc3.Text);
                cmd.Parameters.AddWithValue("@postcardNo", 3);
                cmd.Connection = conn;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                if (ftr_2nd_1stfile.HasFile)
                {
                    ftr_2nd_1stfile.SaveAs(Server.MapPath("/PostCardImages//featurd_img1_postcard3.png"));

                }
                if (ftr_2nd_2ndfile.HasFile)
                {
                    ftr_2nd_2ndfile.SaveAs(Server.MapPath("/PostCardImages//featrd_img1_postcard3_1.jpg"));

                }
                if (ftr_2nd_3rdfile.HasFile)
                {
                    thrld_feature_Image.SaveAs(Server.MapPath("/PostCardImages//featrd_img1_postcard3_2.jpg"));

                }
                if (ftr_2nd_4thfile.HasFile)
                {
                    ftr_2nd_4thfile.SaveAs(Server.MapPath("/PostCardImages//featrd_img1_postcard3_4.jpg"));

                }
                if (ftr_2nd_5thfile.HasFile)
                {
                    ftr_2nd_5thfile.SaveAs(Server.MapPath("/PostCardImages//featrd_img1_postcard3_5.jpg"));

                }
                if (ftr_2nd_6thfile.HasFile)
                {
                    ftr_2nd_6thfile.SaveAs(Server.MapPath("/PostCardImages//featrd_img1_postcard3_6.jpg"));

                }
                if (ftr_2nd_7thfile.HasFile)
                {
                    ftr_2nd_7thfile.SaveAs(Server.MapPath("/PostCardImages//featrd_img4_back.jpg"));

                }
            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


        }
        protected void btnSavePostcard4_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString.ToString());

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Postcard SET col1 = @col1, col2 = @col2,col3=@col3,col4 = @col4, col5 = @col5,col6=@col6,col7 = @col7, col8 = @col8,col9=@col9,col10 = @col10, col11 = @col11,col12=@col12,col13=@col13,col14=@col14 where postcardNo=@postcardNo";
                cmd.Parameters.AddWithValue("@col1", jsthold_1stcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col2", jsthold_2ndcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col3", jsthold_3rdcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col4", jsthold_4thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col5", jsthold_5thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col6", jsthold_6thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col7", jsthold_7thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col8", jsthold_8thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col9", jsthold_9thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col10", jsthold_10thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col11", jsthold_11thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col12", jsthold_12thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col13", jsthold_13thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@col14", jsthold_14thcntnt.Text.Replace("'", "`"));
                cmd.Parameters.AddWithValue("@postcardNo", 4);
                cmd.Connection = conn;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();

                if (jsthold_1stimg.HasFile)
                {
                    jsthold_1stimg.SaveAs(Server.MapPath("/PostCardImages//featurd_img1_Postcard4.png"));

                }
                if (jsthold_2ndimg.HasFile)
                {
                    jsthold_2ndimg.SaveAs(Server.MapPath("/PostCardImages//featurd_img1_Postcard4_1.jpg"));

                }
                if (jsthold_3rdimg.HasFile)
                {
                    jsthold_3rdimg.SaveAs(Server.MapPath("/PostCardImages//featurd_img1_Postcard4_2.jpg"));

                }
                if (jsthold_4thimg.HasFile)
                {
                    jsthold_4thimg.SaveAs(Server.MapPath("/PostCardImages//featurd_img1_Postcard4_3.jpg"));

                }
                if (jsthold_5thimg.HasFile)
                {
                    jsthold_5thimg.SaveAs(Server.MapPath("/PostCardImages//featurd_img1_Postcard4_4.jpg"));

                }
                if (jsthold_6thimg.HasFile)
                {
                    jsthold_6thimg.SaveAs(Server.MapPath("/PostCardImages//featurd_img1_Postcard4_5.jpg"));

                }
                if (jsthold_7thimg.HasFile)
                {
                    jsthold_7thimg.SaveAs(Server.MapPath("/PostCardImages//featurd_img1_Postcard4_6.jpg"));

                }

            }
            catch (Exception ex)
            { }
            finally
            {
                conn.Close();
                conn.Dispose();
            }


        }
        protected void btnaddusers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminClient.aspx");
        }

        protected void chkdeleteAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdUsers.Rows)
            {
                CheckBox ChkBoxHeader = (CheckBox)grdUsers.HeaderRow.FindControl("chkdeleteAll");
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkdelete");
                ChkBoxRows.Checked = ChkBoxHeader.Checked;
            }
        }

        protected void chkdelete_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdUsers.Rows)
            {
                CheckBox ChkBoxHeader = (CheckBox)grdUsers.HeaderRow.FindControl("chkdeleteAll");
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkdelete");
                if (ChkBoxRows.Checked == false)
                {
                    ChkBoxHeader.Checked = false;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string SelectedIds = GetHiddenValue();
            SqlCommand cmd = new SqlCommand("Delete from AdminClient where ID in(" + SelectedIds + ")", conn);
            // SqlCommand cmd = new SqlCommand("delete from tblContactUs where Name='';", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            FillGridData();

        }

        public string SendNewsLetter(PostCardModel model)
        {


            string Status = "";
            //string EmailId = "only4agentss@gmail.com";

            //Send mail
            MailMessage mail = new MailMessage();

            string FromEmailID = WebConfigurationManager.AppSettings["RegFromMailAddress"];
            string FromEmailPassword = WebConfigurationManager.AppSettings["RegPassword"];

            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"]);
            int _Port = Convert.ToInt32(WebConfigurationManager.AppSettings["Port"].ToString());
            Boolean _UseDefaultCredentials = Convert.ToBoolean(WebConfigurationManager.AppSettings["UseDefaultCredentials"].ToString());
            Boolean _EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["EnableSsl"].ToString());
            mail.To.Add(new MailAddress(model.Email));
            mail.From = new MailAddress(FromEmailID);
            mail.Subject = "Post Card";
            string Template = "";

            string msgbody = "";
            if (model.PostcardType == "Openhouse")
            {
                Template = "Templates/OpenHousePostCard.html";
            }
            else if (model.PostcardType == "feature")
            {
                Template = "Templates/Feature_Postcard.html";
            }
            else if (model.PostcardType == "2ndfeature")
            {
                Template = "Templates/2ndFeature_Postcard.html";
            }
            else if (model.PostcardType == "jst_sold")
            {
                Template = "Templates/Jst_sold.html";
            }

            // using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(Template)))
            using (StreamReader reader = new StreamReader(Path.Combine(HttpRuntime.AppDomainAppPath, Template)))
            {

                msgbody = reader.ReadToEnd();

                //Replace UserName and Other variables available in body Stream
               
                msgbody = msgbody.Replace("{PropertyPhoto}", model.PropertyPhoto);

                if (model.PostcardType == "Openhouse")
                {
                    msgbody = Replace_openhouse(model, msgbody);

                }
                else if (model.PostcardType == "feature")
                {
                    msgbody = Replace_first_ftr(model, msgbody);
                }
                else if (model.PostcardType == "2ndfeature")
                {
                    msgbody = Replace_second_ftr(model, msgbody);
                }
                else if (model.PostcardType == "jst_sold")
                {
                    msgbody = Replace_JustSold(model,msgbody);
                }

            }

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            System.Net.Mail.AlternateView plainView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(System.Text.RegularExpressions.Regex.Replace(msgbody, @"<(.|\n)*?>", string.Empty), null, "text/plain");
            System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(msgbody, null, "text/html");

            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);
            // mail.Body = msgbody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Host = "smtp.gmail.com"; //_Host;
            smtp.Port = _Port;
            //smtp.UseDefaultCredentials = _UseDefaultCredentials;
            smtp.Credentials = new System.Net.NetworkCredential(FromEmailID, FromEmailPassword);// Enter senders User name and password
            smtp.EnableSsl = _EnableSsl;
            smtp.Send(mail);

            return Status;
        }

        //Openhouse postcard functions
        public PostCardModel Openhouse(PostCardModel Model)
        {
           
            Model.FirstContent = FirstContent.Text.Replace("'","`");
            Model.SecondContent = SecondContent.Text.Replace("'", "`");
            Model.ThirldContent = ThirdContent.Text.Replace("'", "`");
            Model.txtDesc1 = txtDesc1.Text.Replace("'", "`");
            Model = OpenHouseUploadFile(Model);
            return Model;
        }
        public PostCardModel FeaturedPostcard(PostCardModel Model)
        {
           
            Model.First_feature_cntnt = First_feature_cntnt.Text.Replace("'", "`");
            Model.Second_feature_cntnt = Second_feature_cntnt.Text.Replace("'", "`");
            Model.Thirld_feature_cntnt = Thirld_feature_cntnt.Text.Replace("'", "`");
            Model.Fourth_feature_cntnt = Fourth_feature_cntnt.Text.Replace("'", "`");
            Model.txtDesc2 = txtDesc2.Text.Replace("'", "`");
            //go to upload files
            Model = FeaturedPostcardUploadFile(Model);

            return Model;
        }
        public PostCardModel secndFeaturedPostcard(PostCardModel Model)
        {

            Model.ftr_2nd_1stcntnt = ftr_2nd_1stcntnt.Text.Replace("'", "`");
            Model.ftr_2nd_2ndcntnt = ftr_2nd_2ndcntnt.Text.Replace("'", "`");
            Model.ftr_2nd_3rdcntnt = ftr_2nd_3rdcntnt.Text.Replace("'", "`");
            Model.ftr_2nd_4thcntnt = ftr_2nd_4thcntnt.Text.Replace("'", "`");
            Model.txtDesc3 = txtDesc3.Text.Replace("'", "`");
            //go to upload files
            Model = Secnd_FeaturedPostcardUploadFile(Model);

            return Model;
        }
        public PostCardModel jstSold_Postcard(PostCardModel Model)
        {

            Model.jsthold_1stcntnt = jsthold_1stcntnt.Text.Replace("'", "`");
            Model.jsthold_2ndcntnt = jsthold_2ndcntnt.Text.Replace("'", "`");
            Model.jsthold_3rdcntnt = jsthold_3rdcntnt.Text.Replace("'", "`");
            Model.jsthold_4thcntnt = jsthold_4thcntnt.Text.Replace("'", "`");
            Model.jsthold_5thcntnt = jsthold_5thcntnt.Text.Replace("'", "`");
            Model.jsthold_6thcntnt = jsthold_6thcntnt.Text.Replace("'", "`");
            Model.jsthold_7thcntnt = jsthold_7thcntnt.Text.Replace("'", "`");
            Model.jsthold_8thcntnt = jsthold_8thcntnt.Text.Replace("'", "`");
            Model.jsthold_9thcntnt = jsthold_9thcntnt.Text.Replace("'", "`");
            Model.jsthold_10thcntnt = jsthold_10thcntnt.Text.Replace("'", "`");
            Model.jsthold_11thcntnt = jsthold_11thcntnt.Text.Replace("'", "`");
            Model.jsthold_12thcntnt = jsthold_12thcntnt.Text.Replace("'", "`");
            Model.jsthold_13thcntnt = jsthold_13thcntnt.Text.Replace("'", "`");
            Model.jsthold_14thcntnt = jsthold_14thcntnt.Text.Replace("'", "`"); 


            //go to upload files
            Model = jstsold_PostcardUploadFile(Model);

            return Model;
        }
        //End

        //Upload file functions
        public PostCardModel OpenHouseUploadFile(PostCardModel Model)
        {

            if (openhousefile.PostedFile != null && openhousefile.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(openhousefile.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                openhousefile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.PropertyPhoto = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.PropertyPhoto = "https://aggarwalrealty.ca//PostCardImages/open_house_img.jpg";
            }
            if (openhousefile2.PostedFile != null && openhousefile2.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(openhousefile2.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                openhousefile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.PropertyPhoto2 = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.PropertyPhoto2 = "https://aggarwalrealty.ca//PostCardImages/open_house_img2.jpg";
            }
            Model.AdminPhoto = "..https://aggarwalrealty.ca//images/client_img.jpg";
            return Model;
        }
        public PostCardModel FeaturedPostcardUploadFile(PostCardModel Model)
        {
            //firstimage
            if (First_feature_Image.PostedFile != null && First_feature_Image.FileName != "")
            {

                var fileExt = Path.GetExtension(First_feature_Image.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                First_feature_Image.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.First_feature_Image = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.First_feature_Image = "https://aggarwalrealty.ca//PostCardImages/featurd_img1.png";
            }

            //Second Image
            if (secd_feature_Image.PostedFile != null && secd_feature_Image.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(First_feature_Image.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                secd_feature_Image.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.secd_feature_Image = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.secd_feature_Image = "https://aggarwalrealty.ca//PostCardImages/featrd_img1_back.jpg";
            }


            //Thirld Image
            if (thrld_feature_Image.PostedFile != null && thrld_feature_Image.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(First_feature_Image.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                thrld_feature_Image.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.thrld_feature_Image = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.thrld_feature_Image = "https://aggarwalrealty.ca//PostCardImages/featrd_img2_back.jpg";
            }



            //Fourth Image
            if (forth_feature_Image.PostedFile != null && forth_feature_Image.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(First_feature_Image.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                forth_feature_Image.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.forth_feature_Image = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.forth_feature_Image = "https://aggarwalrealty.ca//PostCardImages/featrd_img3_back.jpg";
            }

            //Fifth Image
            if (fifth_feature_Image.PostedFile != null && fifth_feature_Image.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(First_feature_Image.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                fifth_feature_Image.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.fifth_feature_Image = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.fifth_feature_Image = "https://aggarwalrealty.ca//PostCardImages/featrd_img4_back.jpg";
            }

            Model.AdminPhoto = "..https://aggarwalrealty.ca//images/client_img.jpg";
            return Model;
        }
        public PostCardModel Secnd_FeaturedPostcardUploadFile(PostCardModel Model)
        {
            //firstimage
            if (ftr_2nd_1stfile.PostedFile != null && ftr_2nd_1stfile.FileName != "")
            {

                var fileExt = Path.GetExtension(ftr_2nd_1stfile.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                ftr_2nd_1stfile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.ftr_2nd_1stimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.ftr_2nd_1stimg = "https://aggarwalrealty.ca//PostCardImages/featrd_img1_postcard3.png";
            }

            //Second Image
            if (ftr_2nd_2ndfile.PostedFile != null && ftr_2nd_2ndfile.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(ftr_2nd_2ndfile.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                ftr_2nd_2ndfile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.ftr_2nd_2ndimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.ftr_2nd_2ndimg = "https://aggarwalrealty.ca//PostCardImages/featrd_img1_postcard3_1.jpg";
            }


            //Thirld Image
            if (ftr_2nd_3rdfile.PostedFile != null && ftr_2nd_3rdfile.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(ftr_2nd_3rdfile.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                ftr_2nd_3rdfile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.ftr_2nd_3rdimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.ftr_2nd_3rdimg = "https://aggarwalrealty.ca//PostCardImages/featrd_img1_postcard3_2.jpg";
            }



            //Fourth Image
            if (ftr_2nd_4thfile.PostedFile != null && ftr_2nd_4thfile.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(ftr_2nd_4thfile.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                ftr_2nd_4thfile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.ftr_2nd_4thimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.ftr_2nd_4thimg = "https://aggarwalrealty.ca//PostCardImages/featrd_img1_postcard3_3.jpg";
            }

            //Fifth Image
            if (ftr_2nd_5thfile.PostedFile != null && ftr_2nd_5thfile.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(ftr_2nd_5thfile.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                ftr_2nd_5thfile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.ftr_2nd_5thimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.ftr_2nd_5thimg = "https://aggarwalrealty.ca//PostCardImages/featrd_img1_postcard3_4.jpg";
            }


            //sixth Image
            if (ftr_2nd_6thfile.PostedFile != null && ftr_2nd_6thfile.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(ftr_2nd_5thfile.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                ftr_2nd_6thfile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.ftr_2nd_6thimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.ftr_2nd_6thimg = "https://aggarwalrealty.ca//PostCardImages/featrd_img1_postcard3_5.jpg";
            }

            //Fifth Image
            if (ftr_2nd_7thfile.PostedFile != null && ftr_2nd_7thfile.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(ftr_2nd_7thfile.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                ftr_2nd_7thfile.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.ftr_2nd_7thimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.ftr_2nd_7thimg = "https://aggarwalrealty.ca//PostCardImages/featrd_img1_postcard3_6.jpg";
            }
            Model.AdminPhoto = "https://aggarwalrealty.ca//images/ajay_shah.jpg";
            return Model;
        }
        public PostCardModel jstsold_PostcardUploadFile(PostCardModel Model)
        {
            //firstimage
            if (jsthold_1stimg.PostedFile != null && jsthold_1stimg.FileName != "")
            {

                var fileExt = Path.GetExtension(jsthold_1stimg.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                jsthold_1stimg.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.jsthold_1stimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.jsthold_1stimg = "https://aggarwalrealty.ca//PostCardImages/featurd_img1_Postcard4.jpg";
            }

            //Second Image
            if (jsthold_2ndimg.PostedFile != null && jsthold_2ndimg.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(jsthold_2ndimg.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                jsthold_2ndimg.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.jsthold_2ndimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.jsthold_2ndimg = "https://aggarwalrealty.ca//PostCardImages/featurd_img1_Postcard4_1.jpg";
            }


            //Thirld Image
            if (jsthold_3rdimg.PostedFile != null && jsthold_3rdimg.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(jsthold_3rdimg.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                jsthold_3rdimg.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.jsthold_3rdimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.jsthold_3rdimg = "https://aggarwalrealty.ca//PostCardImages/featurd_img1_Postcard4_2.jpg";
            }



            //Fourth Image
            if (jsthold_4thimg.PostedFile != null && jsthold_4thimg.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(jsthold_4thimg.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                jsthold_4thimg.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.jsthold_4thimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.jsthold_4thimg = "https://aggarwalrealty.ca//PostCardImages/featurd_img1_Postcard4_3.jpg";
            }

            //Fifth Image
            if (jsthold_5thimg.PostedFile != null && jsthold_5thimg.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(jsthold_5thimg.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                jsthold_5thimg.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.jsthold_5thimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.jsthold_5thimg = "https://aggarwalrealty.ca//PostCardImages/featurd_img1_Postcard4_4.jpg";
            }


            //sixth Image
            if (jsthold_6thimg.PostedFile != null && jsthold_6thimg.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(jsthold_6thimg.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                jsthold_6thimg.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.jsthold_6thimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.jsthold_6thimg = "https://aggarwalrealty.ca//PostCardImages/featurd_img1_Postcard4_5.jpg";
            }

            //Fifth Image
            if (jsthold_7thimg.PostedFile != null && jsthold_7thimg.PostedFile.FileName != "")
            {

                var fileExt = Path.GetExtension(jsthold_7thimg.FileName);
                string fileName = Guid.NewGuid() + fileExt;
                var subPath = Server.MapPath("~/uploadfiles");

                //Check SubPath Exist or Not
                if (!Directory.Exists(subPath))
                {
                    Directory.CreateDirectory(subPath);
                }
                //End : Check SubPath Exist or Not

                var path = Path.Combine(subPath, fileName);
                jsthold_7thimg.SaveAs(path);
                var URL = ConfigurationManager.AppSettings["LiveURL"].ToString();
                Model.jsthold_7thimg = URL + "/uploadfiles/" + fileName;
            }
            else
            {
                Model.jsthold_7thimg = "https://aggarwalrealty.ca//PostCardImages/featurd_img1_Postcard4_6.jpg";
            }
            Model.AdminPhoto = "https://aggarwalrealty.ca//images/ajay_shah.jpg";
            return Model;
        }
        //End

        //replace template content
        public string Replace_openhouse(PostCardModel model, string msgbody)
        {
            //string msgbody = "";
            msgbody = msgbody.Replace("{FirstContent}", model.FirstContent);
            msgbody = msgbody.Replace("{SecondContent}", model.SecondContent);
            msgbody = msgbody.Replace("{ThirdContent}", model.ThirldContent);
            msgbody= msgbody.Replace("{Desc}", model.txtDesc1);
            msgbody = msgbody.Replace("{PropertyPhoto2}", model.PropertyPhoto2);
            return msgbody;
        }
        public string Replace_first_ftr(PostCardModel model, string msgbody)
        {
            // string msgbody = "";First_feature_cntnt
            msgbody = msgbody.Replace("{First_feature_Image}", model.First_feature_Image);
            msgbody = msgbody.Replace("{secd_feature_Image}", model.secd_feature_Image);
            msgbody = msgbody.Replace("{thrld_feature_Image}", model.thrld_feature_Image);
            msgbody = msgbody.Replace("{forth_feature_Image}", model.forth_feature_Image);
            msgbody = msgbody.Replace("{fifth_feature_Image}", model.fifth_feature_Image);
            msgbody = msgbody.Replace("{First_feature_cntnt}", model.First_feature_cntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{Second_feature_cntnt}", model.Second_feature_cntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{Thirld_feature_cntnt}", model.Thirld_feature_cntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{Fourth_feature_cntnt}", model.Fourth_feature_cntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{Desc}", model.txtDesc2);
            return msgbody;
        }
        public string Replace_second_ftr(PostCardModel model, string msgbody)
        {
            //string msgbody = "";
            msgbody = msgbody.Replace("{ftr_2nd_1stimg}", model.ftr_2nd_1stimg);
            msgbody = msgbody.Replace("{ftr_2nd_2ndimg}", model.ftr_2nd_2ndimg);
            msgbody = msgbody.Replace("{ftr_2nd_3rdimg}", model.ftr_2nd_3rdimg);
            msgbody = msgbody.Replace("{ftr_2nd_4thimg}", model.ftr_2nd_4thimg);
            msgbody = msgbody.Replace("{ftr_2nd_5thimg}", model.ftr_2nd_5thimg);
            msgbody = msgbody.Replace("{ftr_2nd_6thimg}", model.ftr_2nd_6thimg);
            msgbody = msgbody.Replace("{ftr_2nd_7thimg}", model.ftr_2nd_7thimg);
            msgbody = msgbody.Replace("{ftr_2nd_1stcntnt}", model.ftr_2nd_1stcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{ftr_2nd_2ndcntnt}", model.ftr_2nd_2ndcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{ftr_2nd_3rdcntnt}", model.ftr_2nd_3rdcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{ftr_2nd_4thcntnt}", model.ftr_2nd_4thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{Desc}", model.txtDesc3);
            return msgbody;
        }
        public string Replace_JustSold(PostCardModel model,string msgbody)
        {
           // string msgbody = "";
            msgbody = msgbody.Replace("{jsthold_1stimg}", model.jsthold_1stimg);
            msgbody = msgbody.Replace("{jsthold_2ndimg}", model.jsthold_2ndimg);
            msgbody = msgbody.Replace("{jsthold_3rdimg}", model.jsthold_3rdimg);
            msgbody = msgbody.Replace("{jsthold_4thimg}", model.jsthold_4thimg);
            msgbody = msgbody.Replace("{jsthold_5thimg}", model.jsthold_5thimg);
            msgbody = msgbody.Replace("{jsthold_6thimg}", model.jsthold_6thimg);
            msgbody = msgbody.Replace("{jsthold_7thimg}", model.jsthold_7thimg);
            msgbody = msgbody.Replace("{jsthold_1stcntnt}", model.jsthold_1stcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_2ndcntnt}", model.jsthold_2ndcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_3rdcntnt}", model.jsthold_3rdcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_4thcntnt}", model.jsthold_4thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_5thcntnt}", model.jsthold_5thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_6thcntnt}", model.jsthold_6thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_7thcntnt}", model.jsthold_7thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_8thcntnt}", model.jsthold_8thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_9thcntnt}", model.jsthold_9thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_10thcntnt}", model.jsthold_10thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_11thcntnt}", model.jsthold_11thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_12thcntnt}", model.jsthold_12thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_13thcntnt}", model.jsthold_13thcntnt.Replace("'", "`"));
            msgbody = msgbody.Replace("{jsthold_14thcntnt}", model.jsthold_14thcntnt.Replace("'", "`"));

            return msgbody;
        }
        //end

        //send mail to which Users functions
        public void SendMailTo(string SelectedIds, PostCardModel Model)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            DataTable dt = new DataTable();
            string str = "select EmailId from [AdminClient] where ID in(" + SelectedIds + ")";
            SqlDataAdapter adp = new SqlDataAdapter(str, conn);
            adp.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                var Email = row["EmailId"].ToString();

                Model.Email = Email;              
                SendNewsLetter(Model);
            }
        }

    }
}
