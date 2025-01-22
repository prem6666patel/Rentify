using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Caching;

namespace Rentify
{
    public partial class upload_item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["p_id"] != null)
            {
                int providerId = Convert.ToInt32(Session["p_id"]);
               
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (Session["p_id"] == null)
                {

                    Response.Write("<script>alert('Session expired. Please log in again.');</script>");
                    Response.Redirect("homePage.aspx");
                    return;
                }

                int providerId = Convert.ToInt32(Session["p_id"]);

                // Retrieve form inputs
                string category = ddlCategory.SelectedItem.Value.ToString();
                string itemName = txtItemName.Text;
                string description = txtDescription.Text;
                if (!int.TryParse(txtPrice.Text, out int price) ||
                    !int.TryParse(txtDeposit.Text, out int deposit) ||
                    !int.TryParse(txtPenalty.Text, out int penalty))
                {
                    Response.Write("<script>alert('Invalid numeric input for price, deposit, or penalty.');</script>");
                    return;
                }

                string rented = "No";
                string available = "Yes";
                string filename = Path.GetFileName(item_image.PostedFile.FileName);

                item_image.SaveAs(Server.MapPath("~/photos/" + filename));



                // Database Connection String
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True";

                // SQL Query
                string query = "INSERT INTO tbl_item (category_name, item_name, discription, price, deposit_amount, penalty, rented, available,image, provider_id) " +
                               "VALUES (@CategoryName, @ItemName, @Description, @Price, @DepositAmount, @Penalty, @Rented, @Available,@image, @ProviderId)";

                // Execute Query
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", category);
                        cmd.Parameters.AddWithValue("@ItemName", itemName);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@DepositAmount", deposit);
                        cmd.Parameters.AddWithValue("@Penalty", penalty);
                        cmd.Parameters.AddWithValue("@Rented", rented);
                        cmd.Parameters.AddWithValue("@Available", available);
                        cmd.Parameters.AddWithValue("@ProviderId", providerId);
                        cmd.Parameters.AddWithValue("@image","photos/" + filename);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Item uploaded successfully!');</script>");
                            Response.Redirect("providers_dashboard.aspx");
                        }
                        else
                        {
                            Response.Write("<script>alert('No rows affected. Check the query or data.');</script>");
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Response.Write("<script>alert('SQL Error: " + sqlEx.Message.Replace("'", "\\'") + "');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message.Replace("'", "\\'") + "');</script>");
            }
        }
    }
}

