using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIIT
{
    public partial class Career : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    FillCapctha();
                }
            }
            catch (Exception ex)
            {
            }

        }


        private void FillCapctha()
        {
            Random random = new Random();
            string combination = "ABCDEFGHIJKLMNPQRSTUVWXYZ";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
            {
                captcha.Append(combination[random.Next(combination.Length)]);
            }
            lbl_captcha_code.Text = captcha.ToString();
            ViewState["captcha"] = lbl_captcha_code.Text;
           
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_enter_captcha.Text == ViewState["captcha"].ToString())
                {
                    form_submit();
                }
                else
                {
                    lblmessage.Text = "Please enter valid captcha code";
                }
            }
            catch (Exception exc)
            {
                My.submit_exception(Convert.ToString(My.conn));
            }
        }

        private void form_submit()
        {
            try
            {
                if (txt_name.Text == "")
                {
                    lblmessage.Text = "Please enter your name";
                    return;
                }

                if (txt_mobileno.Text == "")
                {
                    lblmessage.Text = "Please enter 10 digit mobile no";
                    return;
                }

                if (txt_emailid.Text == "")
                {
                    lblmessage.Text = "Please enter email id";
                    return;
                }

                if (txt_aadharno.Text == "")
                {
                    lblmessage.Text = "Please enter aadhar no.";
                    return;
                }


                if (txt_address.Text == "")
                {
                    lblmessage.Text = "Please enter address";
                    return;
                }

                if (txt_message.Text == "")
                {
                    lblmessage.Text = "Please enter message";
                    return;
                }

                string filepath = "#";
                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.FileBytes.Length < 500000)
                    {
                        filepath = upload_file_path();
                        if (filepath == "")
                        {
                            lblmessage.Text = "Please choose file";
                        }
                        else
                        {
                            finsl_submit(filepath);
                        }
                    }
                    else
                    {
                        lblmessage.Text = "Please upload your document up to 500kb";
                    }

                }
                else
                {
                    lblmessage.Text = "Please choose file";
                }

            }
            catch (Exception exc)
            {
            }


        }

        private void finsl_submit(string filepath)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Career", My.conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Career");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            DataRow dr = dt.NewRow();
            dr["Name"] = txt_name.Text;
            dr["Email"] = txt_emailid.Text;
            dr["Phone"] = txt_mobileno.Text;
            dr["Aadhar"] = txt_aadharno.Text;
            dr["filepath"] = filepath;
            dr["Address"] = txt_address.Text;
            dr["Message"] = txt_message.Text;
            dr["Date"] = dtm.ToString("dd/MM/yyyy");
            dr["Idate"] = Convert.ToInt32(dtm.ToString("yyyyMMdd"));

            dt.Rows.Add(dr);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
            ad.Update(dt);
            lblmessage.Text = "Dear " + txt_name.Text + ", your message has been submitted successfully. We will contact you very soon!";

            txt_name.Text = "";
            txt_emailid.Text = "";
            txt_mobileno.Text = "";
            txt_aadharno.Text = "";
            txt_address.Text = "";
            txt_message.Text = "";
        }

        private string upload_file_path()
        {
            string dbfilePath = "";
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd_MM_yyyy");
            string time = dt.ToString("hh_mm_ss");
            String filerename = date + time;
            Boolean FileOK = false;
            Boolean FileSaved = false;
            int k = 0;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 500000)
                {
                    Session["WorkingImage"] = FileUpload1.FileName;
                    string FileExtension = Path.GetExtension(Session["WorkingImage"].ToString()).ToLower();
                    Session["renamedfile"] = filerename + "PIMG1" + FileExtension;
                    string[] allowedExtension = { ".pdf", ".PDF" };
                    for (int i = 0; i < allowedExtension.Length; i++)
                    {
                        k++;
                        if (FileExtension == allowedExtension[i])
                        {
                            FileOK = true;
                            lblmessage.Text = "";
                            break;
                        }
                    }
                }
                else
                {
                    lblmessage.Text = "Please Reduce or compress size of resume max(300kb)";
                }
            }
            else
            {
                lblmessage.Text = "Please upload file first.";
            }
            if (FileOK)
            {
                try
                {
                    string path = (Server.MapPath("/album/career/")).ToString();
                    FileUpload1.SaveAs(path + "/" + Session["renamedfile"]);
                    FileSaved = true;
                }
                catch (Exception ex)
                {
                    FileSaved = false;
                    lblmessage.Text = "File has not save.";
                }
            }
            else
            {

            }
            if (FileSaved)
            {
                //string originalPath = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.AbsolutePath, "");
                string fileName = Path.GetFileName(Session["renamedfile"].ToString());
                dbfilePath = @"/album/career/" + fileName;
            }
            return dbfilePath;
        }

        //career

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FillCapctha();
        }

    }
}