using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Buyer_Log : System.Web.UI.Page
{
    private string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    private SqlConnection conn;
    protected static string msg = "";
    protected static string id;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection(cs);
        using (SqlCommand cmd = new SqlCommand("select * from Bidder_master where Bemail=@email and Bpassword=@pass", conn))
        {
            cmd.Parameters.AddWithValue("@email", Request.Form["email"]);
            cmd.Parameters.AddWithValue("@pass", Request.Form["password"]);
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Session["bid"] = dt.Rows[0]["Bid"].ToString();
                    string bid = Session["bid"].ToString();
                    Response.Redirect("Bidder/Home.aspx");
                 
                }
                else
                {
                    Response.Write("<script>alert('Invalid Login')</script>");
                }
            }
        }
    }
}