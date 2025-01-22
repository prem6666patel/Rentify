using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Rentify
{
    public partial class admin_edit_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDetails();
            }
        }

        protected void LoadDetails()
        {
            try
            {
                string email = Session["email"]?.ToString();
                string pass = Session["password"]?.ToString();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass))
                {
                    lblMessage.Text = "Session expired. Please log in again.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\Users\PREM\Documents\prem_vs\Rentify\Rentify\App_Data\Db_Rentify.mdf;
                                            Integrated Security=True";

                string query = "SELECT * FROM tbl_admin WHERE email = @Email AND password = @Pass";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Pass", pass);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtEmail.Text = reader["email"].ToString();
                                txtPassword.Text = reader["password"].ToString();

                                int adminId = Convert.ToInt32(reader["a_id"]);
                                ViewState["adminId"] = adminId; // Save adminId in ViewState
                            }
                            else
                            {
                                lblMessage.Text = "Admin details not found.";
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
                if (ViewState["adminId"] == null)
                {
                    lblMessage.Text = "Session expired. Please reload the page.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                int adminId = (int)ViewState["adminId"];
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                            AttachDbFilename=C:\Users\PREM\Documents\prem_vs\Rentify\Rentify\App_Data\Db_Rentify.mdf;
                                            Integrated Security=True";

                string query = "UPDATE tbl_admin SET email = @Email, password = @Password WHERE a_id = @AdminId";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@AdminId", adminId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                             Session["email"] = txtEmail.Text; 
                             Session["password"] = txtPassword.Text;
                            Response.Redirect("admin_dashboard.aspx");
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
