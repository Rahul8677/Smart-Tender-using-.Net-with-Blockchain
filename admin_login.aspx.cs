﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_login : System.Web.UI.Page
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
        using(SqlCommand cmd = new SqlCommand("select * from admin where admin_name=@email and admin_pass=@pass",conn))
        {
            cmd.Parameters.AddWithValue("@email", Request.Form["email"]);
            cmd.Parameters.AddWithValue("@pass", Request.Form["password"]);
            using(SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    Session["a_id"] = dt.Rows[0]["id"].ToString();
                    string abc = Session["a_id"].ToString();

                  
                    Response.Redirect("Tender/Home.aspx");
                }
                else{
                    Response.Write("<script>alert('Invalid Login')</script>");
                }
            }
        }

    }
}
