using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace Rentify
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text; 
            string email = txtEmail.Text;
            string message = txtMessage.Text; 

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
            {
                lblFeedback.Text = "Please fill in all fields.";
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True";

            string query = "INSERT INTO tbl_feedback (name, email, message) VALUES (@name, @email, @message)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@message", message);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('feddback uploaded successfully!');</script>");
                            
                        }
                        else
                        {
                            Response.Write("<script>alert('feddback not  uploaded successfully!');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblFeedback.Text = "An error occurred while submitting your feedback. Please try again later.";
                
            }
        }
    }
}
