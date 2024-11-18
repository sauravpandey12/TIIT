using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIIT
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string T = txt_username.Text;
            try
            {
                //Not Allowing Numbers, Underscore or Hash
                char[] UnallowedCharacters = { '-', '#', '\'', '/', '\\', '*', '!', ';', ':', '(', ')', '{', '}', '[', ']', '+', '|', '&', '%', '@', '=' };
                if (textContainsUnallowedCharacter(T, UnallowedCharacters))
                {
                    lblmessage22.Text = "User Name or Password is incorrect.";
                }
                else
                {
                    SqlConnection scon = new SqlConnection(My.conn);
                    SqlDataAdapter ad = new SqlDataAdapter("select * from Admin_login where user_id='" + txt_username.Text + "' ", scon);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "Admin_login");
                    DataTable dt = ds.Tables[0];
                    int rowcount = dt.Rows.Count;
                    if (rowcount == 0)
                    {
                        lblmessage22.Text = "Wrong Entry";
                    }

                    else
                    {
                        string pwd = dt.Rows[0][2].ToString();
                        if (pwd == txt_password.Text)
                        {
                            lblmessage22.Text = "";
                            Session["user_admin"] = dt.Rows[0][1].ToString();
                            Response.Redirect("MasterAdmin/Dashboard.aspx");
                        }
                        else
                        {
                            lblmessage22.Text = "User Name or Password is incorrect.";
                        }
                    }
                }
            }

            catch (Exception)
            {
                lblmessage22.Text = "User Name or Password is incorrect.";
            }
        }

        private bool textContainsUnallowedCharacter(string T, char[] UnallowedCharacters)
        {
            for (int i = 0; i < UnallowedCharacters.Length; i++)

                if (T.Contains(UnallowedCharacters[i]))

                    return true;
            return false;
        }

    }
}