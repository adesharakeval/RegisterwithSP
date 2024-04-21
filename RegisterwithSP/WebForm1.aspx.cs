using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace RegisterwithSP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@City", TextBox2.Text);
            cmd.Parameters.AddWithValue("@State", TextBox3.Text);
            cmd.Parameters.AddWithValue("@MobileNo", Convert.ToInt32(TextBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.Parameters.AddWithValue("@Id",DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
            cmd.Parameters.AddWithValue("@City", TextBox2.Text);
            cmd.Parameters.AddWithValue("@State", TextBox3.Text);
            cmd.Parameters.AddWithValue("@MobileNo", Convert.ToInt32(TextBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_Delete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            cmd.Parameters.AddWithValue("@Id", DropDownList1.SelectedItem.Text);
           
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}