using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIIT
{
    public partial class Contact_Us : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    FillCapctha();
                }
                catch (Exception ex)
                {
                }
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
                Session["captcha"] = captcha.ToString();
                Captcha.Text = captcha.ToString();
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_enter_captcha.Text == Session["captcha"].ToString())
                {
                    send_contact_data();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please entre valid captcha code')", true);
                }
            }
            catch (Exception exc)
            {
                My.submit_exception(Convert.ToString(My.conn));
            }
        }

        private void send_contact_data()
        {
            try
            {
                if (ddl_subject.Text == "Subject")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Subject')", true);
                    return;
                }

                if (txt_name.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please entre your name')", true);
                    return;

                }

                if (txt_mobileno.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please entre Mobile No.')", true);
                    return;

                }

                if (txt_message.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please entre Message')", true);
                    return;
                }


                SqlConnection con = new SqlConnection(My.conn);
                con.Open();
                SqlCommand cmd;
                string strQuery = "INSERT INTO Contact_us (Subject,Name,Mobile,Email,Message,Date,idate) values (@Subject,@Name,@Mobile,@Email,@Message,@Date,@idate)";
                cmd = new SqlCommand(strQuery);
                cmd.Parameters.AddWithValue("@Subject", ddl_subject.Text);
                cmd.Parameters.AddWithValue("@Name", txt_name.Text);
                cmd.Parameters.AddWithValue("@Mobile", txt_mobileno.Text);
                cmd.Parameters.AddWithValue("@Email", txt_emailid.Text);
                cmd.Parameters.AddWithValue("@Message", txt_message.Text);
                cmd.Parameters.AddWithValue("@Date", My.date());
                cmd.Parameters.AddWithValue("@idate", My.idate());
                if (My.InsertUpdateData(cmd))
                {
                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Thanks!! your message has been submitted successfully.')", true);
                    ddl_subject.Text = "";
                    txt_name.Text = "";
                    txt_emailid.Text = "";
                    txt_mobileno.Text = "";
                    txt_message.Text = "";
                }
            }
            catch (Exception ex)
            {
            } 
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FillCapctha();
        }


    }
}