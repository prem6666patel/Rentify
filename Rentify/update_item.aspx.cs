using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace Rentify
{
    public partial class update_item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["item_id"] == null)
                {
                    Response.Redirect("providers_dashboard.aspx");
                }
                else
                {
                    LoadItemDetails();
                }
            }
        }

        private void LoadItemDetails()
        {
            int itemId = Convert.ToInt32(Session["item_id"]);
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True";
            string query = "SELECT * FROM tbl_item WHERE item_id = @ItemId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            ddlCategory.SelectedValue = reader["category_name"].ToString();
                            //  txtCategory.Text = reader["category_name"].ToString();
                            txtItemName.Text = reader["item_name"].ToString();
                            txtDescription.Text = reader["discription"].ToString();
                            txtPrice.Text = reader["price"].ToString();
                            txtDeposit.Text = reader["deposit_amount"].ToString();
                            txtPenalty.Text = reader["penalty"].ToString();

                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading item details: " + ex.Message;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int itemId = Convert.ToInt32(Session["item_id"]);
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True";

            string category = ddlCategory.SelectedItem.Value.ToString();
            string itemName = txtItemName.Text;
            string description = txtDescription.Text;
            string price = txtPrice.Text;
            string deposit = txtDeposit.Text;
            string penalty = txtPenalty.Text;


            string query = @"UPDATE tbl_item SET category_name = @CategoryName, item_name = @ItemName,  discription = @Description , price = @price , deposit_amount = @deposit , penalty = @penalty WHERE item_id = @ItemId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", category);
                        cmd.Parameters.AddWithValue("@ItemName", itemName);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@ItemId", itemId);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@deposit", deposit);
                        cmd.Parameters.AddWithValue("@penalty", penalty);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "Item updated successfully!";
                            Response.Write("<script>alert('Item updated successfully');</script>");
                            Response.Redirect("providers_dashboard.aspx");
                        }
                        else
                        {
                            lblMessage.Text = "Error updating item.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("providers_dashboard.aspx");
        }
    }
}
