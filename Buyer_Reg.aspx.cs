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
public partial class Buyer_Reg : System.Web.UI.Page
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
        using (SqlCommand cmd = new SqlCommand("select * from Bidder_master where Bemail=@email", conn))
        {
            cmd.Parameters.AddWithValue("@email", Request.Form["email"]);
            using(SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    Response.Write("<script>alert('Email Already IN USE')</script>");
                }
                else
                {
                    using (SqlCommand cmd1 = new SqlCommand("insert into Bidder_master (Bname,Bemail,Bphone,Bpassword,Baddress) values(@name,@email,@phone,@password,@address)", conn))
                    {
                        cmd1.Parameters.AddWithValue("@name", Request.Form["name"]);
                        cmd1.Parameters.AddWithValue("@email", Request.Form["email"]);
                        cmd1.Parameters.AddWithValue("@phone", Request.Form["Phone"]);
                        cmd1.Parameters.AddWithValue("@password", Request.Form["password"]);
                        cmd1.Parameters.AddWithValue("@address", Request.Form["Address"]);
                        conn.Open();
                        cmd1.ExecuteNonQuery();
                        conn.Close();
                        Response.Write("<script>alert('Registered Successfully')</script>");

                    }
                }
            }
        }

    }
}