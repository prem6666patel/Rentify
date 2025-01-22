using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices.ComTypes;

namespace Rentify
{
    public partial class renting_items : System.Web.UI.Page
    {
        int s_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProvidersData();
            }
        }

        public void LoadProvidersData()
        {
            string email = Session["email"]?.ToString();
            string password = Session["password"]?.ToString();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                lblData.Text = "Session values are missing.";
                return;
            }

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True";
            string qry = "SELECT * FROM tbl_seekers WHERE email = @Email AND password = @Password";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(qry, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            DataRow row = dt.Rows[0];
                            ViewState["s_id"] = row["s_id"];
                            s_id = Convert.ToInt32(row["s_id"]);
                            lblname.Text = row["fullname"]?.ToString();
                            lblemail.Text = row["email"]?.ToString();
                            lblcontact.Text = row["contact"]?.ToString();
                            lblpass.Text = row["password"]?.ToString();

                            LoadProviderItems(conn, s_id);
                        }
                        else
                        {
                            lblData.Text = "No seeker found with the provided credentials.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                lblData.Text = "An error occurred while loading your data. Please try again later.";
            }
        }

        private void LoadProviderItems(SqlConnection conn, int seekerId)
        {
            string qryItems = "SELECT t.start_date,t.end_date,t.returned,i.item_name,i.image,i.penalty,t.item_id FROM [transaction] t join tbl_item i on t.item_id = i.item_id WHERE seeker_id = @s_id AND returned = 'No'";

            try
            {
                using (SqlCommand cmdItems = new SqlCommand(qryItems, conn))
                {
                    
                    cmdItems.Parameters.AddWithValue("@s_id", seekerId);

                    using (SqlDataReader reader = cmdItems.ExecuteReader())
                    {
                       
                        DataTable dtItems = new DataTable();
                        dtItems.Load(reader);

                       
                        rptItems.DataSource = dtItems;
                        rptItems.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception for debugging (do not show to the user in production)
                System.Diagnostics.Debug.WriteLine($"Error loading items: {ex.Message}");

                // Set user-friendly error message
                lblData.Text = "Error loading items: Please try again later.";
            }
        }


        protected void btnEditDetails_Click(object sender, EventArgs e)
        {
            Session["s_id"] = ViewState["s_id"];
            Response.Redirect("seekers_edit_details.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("homePage.aspx");
        }

        protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Return")
            {
                
                int itemId = Convert.ToInt32(e.CommandArgument);

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PREM\Documents\prem_vs\Rentify\Rentify\App_Data\Db_Rentify.mdf;Integrated Security=True";

                string updateItemQuery_transaction = "UPDATE [transaction] SET returned = 'Yes' WHERE item_id = @ItemId";

                string updateItemQuery_tbl_item = "UPDATE tbl_item SET available = 'Yes' , rented = 'No' WHERE item_id = @ItemId";

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();


                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {

                                using (SqlCommand cmdInsert = new SqlCommand(updateItemQuery_transaction, conn, transaction))
                                {
                                   
                                    cmdInsert.Parameters.AddWithValue("@ItemId", itemId);
                                    cmdInsert.ExecuteNonQuery();
                                }


                                using (SqlCommand cmdUpdate = new SqlCommand(updateItemQuery_tbl_item, conn, transaction))
                                {
                                    cmdUpdate.Parameters.AddWithValue("@ItemId", itemId);
                                    cmdUpdate.ExecuteNonQuery();
                                }


                                transaction.Commit();

                                lblData.ForeColor = System.Drawing.Color.Green;
                                lblData.Text = "Transaction successfully recorded and item status updated.";
                                Response.Write("<script>alert('item return successfully');</script>");
                                LoadProvidersData();
                            }
                            catch (Exception ex)
                            {

                                transaction.Rollback();
                                lblData.ForeColor = System.Drawing.Color.Red;
                                lblData.Text = "Error during transaction: " + ex.Message;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblData.ForeColor = System.Drawing.Color.Red;
                    lblData.Text = "Database connection error: " + ex.Message;
                }
            }
        }
        

        protected void btnAddItems_Click(object sender, EventArgs e)
        {
            Session["email"] = Session["email"];
            Session["password"] = Session["password"];
            Response.Redirect("renting_items.aspx");
        }

        protected void btnBackDashBoard_Click(object sender, EventArgs e)
        {
            Response.Redirect("seekers_dashboard.aspx");
        }

        protected void btnEditDetails_Click1(object sender, EventArgs e)
        {
            Session["s_id"] = ViewState["s_id"];
            Response.Redirect("seekers_edit_details.aspx");
        }

        protected void btnLogout_Click1(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("homePage.aspx");
        }
    }
}