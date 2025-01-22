using System;
using System.Data.SqlClient;

namespace Rentify
{
    public partial class transaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize or perform necessary checks here if needed
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string startDate = txtStartDate.Text.Trim();
            string endDate = txtEndDate.Text.Trim();

            // Check if Session values are null
            if (Session["item_id"] == null || Session["s_id"] == null)
            {
                lblMessage.Text = "Seeker ID or Item ID is missing.";
                return;
            }

            int seekerId;
            int itemId;

            // Validate and parse Session values
            if (!int.TryParse(Session["s_id"].ToString(), out seekerId) || !int.TryParse(Session["item_id"].ToString(), out itemId))
            {
                lblMessage.Text = "Invalid Seeker ID or Item ID.";
                return;
            }

            // Check if start date and end date are provided
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                lblMessage.Text = "Please fill in both start and end dates.";
                return;
            }

            // Define the connection string
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PREM\Documents\prem_vs\Rentify\Rentify\App_Data\Db_Rentify.mdf;Integrated Security=True";

            // SQL queries
            string insertTransactionQuery = "INSERT INTO [transaction] (seeker_id, item_id, start_date, end_date, returned) VALUES (@SeekerId, @ItemId, @StartDate, @EndDate, @Returned)";
            string updateItemQuery = "UPDATE tbl_item SET rented = 'Yes', available = 'No' WHERE item_id = @ItemId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                   
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            
                            using (SqlCommand cmdInsert = new SqlCommand(insertTransactionQuery, conn, transaction))
                            {
                                cmdInsert.Parameters.AddWithValue("@SeekerId", seekerId);
                                cmdInsert.Parameters.AddWithValue("@ItemId", itemId);
                                cmdInsert.Parameters.AddWithValue("@StartDate", startDate);
                                cmdInsert.Parameters.AddWithValue("@EndDate", endDate);
                                cmdInsert.Parameters.AddWithValue("@Returned", "No");
                                cmdInsert.ExecuteNonQuery();
                            }

                            
                            using (SqlCommand cmdUpdate = new SqlCommand(updateItemQuery, conn, transaction))
                            {
                                cmdUpdate.Parameters.AddWithValue("@ItemId", itemId);
                                cmdUpdate.ExecuteNonQuery();
                            }

                            
                            transaction.Commit();

                           // lblMessage.ForeColor = System.Drawing.Color.Green;
                           // lblMessage.Text = "Transaction successfully recorded and item status updated.";
                            Response.Write("<script>alert('Transaction successfully recorded and item status updated.!');</script>");
                            Response.Redirect("seekers_dashboard.aspx");
                        }
                        catch (Exception ex)
                        {
                            
                            transaction.Rollback();
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                            lblMessage.Text = "Error during transaction: " + ex.Message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Database connection error: " + ex.Message;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("seekers_dashboard.aspx");
        }
    }
}
