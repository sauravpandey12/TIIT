using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TIIT.MasterAdmin
{
    public partial class Upload_video : System.Web.UI.Page
    {
        My mycod = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    mycod.bind_all_ddl_with_id(ddl_video_category, "select Category_name,Video_cat_id from Video_category order by Category_name asc");
                    mycod.bind_all_ddl_with_id_all(ddl_fnd_cat, "select t2.Category_name,t2.Video_cat_id from Videos t1 join Video_category t2 on t1.Category=t2.Video_cat_id group by t2.Category_name,t2.Video_cat_id  order by t2.Category_name asc");
                }
                catch (Exception exc)
                { 
                }
            }
        }
      
    }
}