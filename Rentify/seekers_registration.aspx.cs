using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Rentify
{
    public partial class seekers_registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        string strcon = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;


        protected void btnRegister_Click(object sender, EventArgs e)
        {


            try
            {
                using (SqlConnection conn = new SqlConnection(strcon))
                {
                    conn.Open();

                    // SQL query to insert a new seeker into the database
                    string query = "INSERT INTO tbl_seekers (fullname, email, contact, password, reg_date) VALUES (@FullName, @Email, @Contact, @Password, @RegDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Assign parameter values from input fields
                        cmd.Parameters.Add("@FullName", SqlDbType.VarChar).Value = txtFullName.Text.Trim();
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = TxtEmail.Text.Trim();
                        cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = txtPassword.Text.Trim();
                        cmd.Parameters.Add("@RegDate", SqlDbType.Date).Value = DateTime.Now;

                        // Execute the query
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            // Registration successful
                            Response.Write("<script>alert('Registration successful!');</script>");
                            Response.Redirect("seekers_loginForm.aspx"); // Redirect to login form
                        }
                        else
                        {
                            // Registration failed
                            Response.Write("<script>alert('Registration failed. Please try again.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}
