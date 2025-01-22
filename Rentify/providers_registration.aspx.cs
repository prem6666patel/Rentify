using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rentify
{
    public partial class providers_registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            
            string strcon = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            try
            {
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    
                    string query = "INSERT INTO tbl_providers (fullname, email, contact, password, reg_date) VALUES (@FullName, @Email, @Contact, @Password, @RegDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        
                        cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = txtFullName.Text.Trim();
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text.Trim();
                        cmd.Parameters.Add("@RegDate", SqlDbType.Date).Value = DateTime.Now;

                        
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            
                            Response.Write("<script>alert('Registration successful!');</script>");
                            Response.Redirect("providers_loginForm.aspx"); 
                        }
                        else
                        {
                           
                            Response.Write("<script>alert('Registration failed. Please try again.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}