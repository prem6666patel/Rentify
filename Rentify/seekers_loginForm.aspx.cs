using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rentify
{
    public partial class seekers_loginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True"; // Replace with your database connection string

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string email = txtEmail.Text.Trim();
                    string password = txtPassword.Text.Trim();


                    string query = "SELECT COUNT(*) FROM tbl_seekers WHERE email = @Email AND password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);


                        int result = Convert.ToInt32(cmd.ExecuteScalar());


                        if (result == 0)
                        {

                            Response.Write("<script>alert('Invalid email or password.');</script>");
                        }
                        else
                        {
                            Session["email"] = txtEmail.Text;
                            Session["password"] = txtPassword.Text;

                            Response.Write("<script>alert('Login successful!');</script>");

                            Response.Redirect("seekers_dashboard.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
            }
        }
    }
}