using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rentify
{
    public partial class providers_dashboard : System.Web.UI.Page
    {
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
            string qryProvider = "SELECT * FROM tbl_providers WHERE email = @Email AND password = @Password";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmdProvider = new SqlCommand(qryProvider, conn))
                    {
                        cmdProvider.Parameters.AddWithValue("@Email", email);
                        cmdProvider.Parameters.AddWithValue("@Password", password);

                        using (SqlDataAdapter daProvider = new SqlDataAdapter(cmdProvider))
                        {
                            DataTable dtProvider = new DataTable();
                            daProvider.Fill(dtProvider);

                            if (dtProvider.Rows.Count > 0)
                            {
                                DataRow providerRow = dtProvider.Rows[0];
                                ViewState["p_id"] = providerRow["p_id"];

                                lblname.Text = providerRow["fullname"]?.ToString();
                                lblemail.Text = providerRow["email"]?.ToString();
                                lblcontact.Text = providerRow["contact"]?.ToString();
                                lblpass.Text = providerRow["password"]?.ToString();

                                LoadProviderItems(Convert.ToInt32(providerRow["p_id"]), conn);
                            }
                            else
                            {
                                lblData.Text = "Invalid email or password.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblData.Text = "Error: " + ex.Message;
            }
        }

        private void LoadProviderItems(int providerId, SqlConnection conn)
        {
            string qryItems = "SELECT * FROM tbl_item WHERE provider_id = @ProviderId";

            try
            {
                using (SqlCommand cmdItems = new SqlCommand(qryItems, conn))
                {
                    cmdItems.Parameters.AddWithValue("@ProviderId", providerId);

                    using (SqlDataAdapter daItems = new SqlDataAdapter(cmdItems))
                    {
                        DataTable dtItems = new DataTable();
                        daItems.Fill(dtItems);

                        rptItems.DataSource = dtItems;
                        rptItems.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                lblData.Text = "Error loading items: " + ex.Message;
            }
        }

        protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True";
            int itemId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Delete")
            {
                DeleteItem(itemId, connectionString);
            }
            else if (e.CommandName == "Update")
            {
                Session["item_id"] = itemId;
                Response.Redirect("update_item.aspx");
            }
        }

        private void DeleteItem(int itemId, string connectionString)
        {
            string qryDelete = "DELETE FROM tbl_item WHERE item_id = @ItemId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(qryDelete, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Item deleted successfully!');</script>");
                            LoadProvidersData();
                        }
                        else
                        {
                            lblData.Text = "Error: Unable to delete item.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblData.Text = "Error deleting item: " + ex.Message;
            }
        }

        protected void btnEditDetails_Click(object sender, EventArgs e)
        {
            if (ViewState["p_id"] != null)
            {
                Session["p_id"] = ViewState["p_id"];
                Response.Redirect("providers_edit_details.aspx");
            }
            else
            {
                lblData.Text = "Provider ID not found.";
            }
        }

        protected void btnAddItems_Click(object sender, EventArgs e)
        {
            if (ViewState["p_id"] != null)
            {
                Session["p_id"] = ViewState["p_id"];
                Response.Redirect("upload_item.aspx");
            }
            else
            {
                lblData.Text = "Provider ID not found.";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("homePage.aspx");
        }
    }
}
