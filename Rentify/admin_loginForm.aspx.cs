using System;
using System.Data.SqlClient;

namespace Rentify
{
    public partial class admin_loginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Initialize database connection
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True"; // Replace with your database connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    
                    string adminEmail = txtEmail.Text.Trim();
                    string adminPassword = txtPassword.Text.Trim();

                    
                    string query = "SELECT COUNT(*) FROM tbl_admin WHERE email = @Email AND password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", adminEmail);
                        cmd.Parameters.AddWithValue("@Password", adminPassword);

                       
                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        
                        if (result == 0)
                        {
                            
                            Response.Write("<script>alert('Invalid email or password.');</script>");
                        }
                        else
                        {
                           
                            Response.Write("<script>alert('Login successful!');</script>");

                            Session["email"] = adminEmail;
                            Session["password"] = adminPassword;

                           Response.Redirect("admin_dashboard.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
        }
    }
}
