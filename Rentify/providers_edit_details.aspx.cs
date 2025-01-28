using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rentify
{
    public partial class providers_edit_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int pid = Convert.ToInt32(Session["p_id"]);
           // lblMessage.Text = pid.ToString();

            if (!IsPostBack)
            {
                if (Session["p_id"] == null)
                {
                    // Redirect the user to the login page if the session is null
                    Response.Redirect("login.aspx");
                }
                else
                {
                    LoadDetails(); // Load seeker details on first page load
                }
            }
        }

        protected void LoadDetails()
        {
            try
            {
                // Safely retrieve the seeker ID from session
                int providerId = Convert.ToInt32(Session["p_id"]);

                //lblMessage.Text = providerId.ToString();

                // Connection string for the database
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\Users\PREM\Documents\prem_vs\Rentify\Rentify\App_Data\Db_Rentify.mdf;
                                            Integrated Security=True";

                // Query to fetch seeker details
                string query = "SELECT fullname, email, contact, password FROM tbl_providers WHERE p_id = @providerId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@providerId", providerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                               
                                txtName.Text = reader["fullname"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtContact.Text = reader["contact"].ToString();
                                txtPassword.Text = reader["password"].ToString();
                            }
                            else
                            {
                               // lblMessage.Text = "provider details not found.";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Safely retrieve the seeker ID from session
                int providerId = Convert.ToInt32(Session["p_id"]);

                // Connection string for the database
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\Users\PREM\Documents\prem_vs\Rentify\Rentify\App_Data\Db_Rentify.mdf;
                                            Integrated Security=True";

                // Query to update seeker details
                string query = "UPDATE tbl_providers SET fullname = @FullName, email = @Email, contact = @Contact, password = @Password WHERE p_id = @providerId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Pass updated values as parameters
                        cmd.Parameters.AddWithValue("@FullName", txtName.Text);
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@providerId", providerId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Session["email"] = txtEmail.Text;
                            Session["password"] = txtPassword.Text;
                            Response.Redirect("providers_dashboard.aspx");
                            lblMessage.Text = "Details updated successfully.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMessage.Text = "Error: Unable to update details.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        
    }
}