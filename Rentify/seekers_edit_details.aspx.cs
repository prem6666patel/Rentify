using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Rentify
{
    public partial class seekers_edit_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["s_id"] == null)
                {
                    
                    Response.Redirect("login.aspx");
                }
                else
                {
                    LoadDetails(); 
                }
            }
        }

        protected void LoadDetails()
        {
            try
            {
                
                int seekerId = Convert.ToInt32(Session["s_id"]);

               
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\Users\PREM\Documents\prem_vs\Rentify\Rentify\App_Data\Db_Rentify.mdf;
                                            Integrated Security=True";

               
                string query = "SELECT fullname, email, contact, password FROM tbl_seekers WHERE s_id = @SeekerId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@SeekerId", seekerId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate the fields with the retrieved data
                                txtName.Text = reader["fullname"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                txtContact.Text = reader["contact"].ToString();
                                txtPassword.Text = reader["password"].ToString();
                            }
                            else
                            {
                                lblMessage.Text = "Seeker details not found.";
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
               
                int seekerId = Convert.ToInt32(Session["s_id"]);

               
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\Users\PREM\Documents\prem_vs\Rentify\Rentify\App_Data\Db_Rentify.mdf;
                                            Integrated Security=True";

                
                string query = "UPDATE tbl_seekers SET fullname = @FullName, email = @Email, contact = @Contact, password = @Password WHERE s_id = @SeekerId";

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
                        cmd.Parameters.AddWithValue("@SeekerId", seekerId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Session["email"] = txtEmail.Text;
                            Session["password"] = txtPassword.Text;
                            lblMessage.Text = "Details updated successfully.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            Response.Redirect("seekers_dashboard.aspx");
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

        /*
        protected void btnGoBack_Click(object sender, EventArgs e)
        {
             Session["email"] = txtEmail.Text;
             Session["password"] = txtPassword.Text;
            Response.Redirect("seekers_dashboard.aspx");
        }

        */
    }
}
