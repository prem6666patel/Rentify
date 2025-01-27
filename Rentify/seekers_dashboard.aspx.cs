using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rentify
{
    public partial class seekers_dashboard : System.Web.UI.Page
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

                            LoadProviderItems(conn);
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

        private void LoadProviderItems(SqlConnection conn)
        {
            string qryItems = "SELECT * FROM tbl_item";

            try
            {
                using (SqlCommand cmdItems = new SqlCommand(qryItems, conn))
                {
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
                
                lblData.Text = "Error loading items: Please try again later.";
            }
        }

        private void searchItem(SqlConnection conn)
        {   
            string cat = txtSearchCategory.Text;

            string qryItems = "SELECT * FROM tbl_item WHERE discription LIKE '%' + @cat + '%' OR category_name LIKE '%' + @cat + '%'";

            try
            {
                using (SqlCommand cmdItems = new SqlCommand(qryItems, conn))
                {
                    cmdItems.Parameters.AddWithValue("cat", cat);

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
            if (e.CommandName == "Rented")
            {
                
                int itemId = Convert.ToInt32(e.CommandArgument);

               
                int seekerId = ViewState["s_id"] != null ? Convert.ToInt32(ViewState["s_id"]) : (Session["s_id"] != null ? Convert.ToInt32(Session["s_id"]) : 0);

                if (seekerId == 0)
                {
                    
                    lblData.Text = "Session expired or invalid user data. Please log in again.";
                    return;
                }

                
                Session["item_id"] = itemId;
                Session["s_id"] = seekerId;

                
                Response.Redirect("transaction.aspx");
            }
        }

        protected void btnAddItems_Click(object sender, EventArgs e)
        {
            Session["email"] = Session["email"];
            Session["password"] = Session["password"];
            Response.Redirect("renting_items.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\PREM\\Documents\\prem_vs\\Rentify\\Rentify\\App_Data\\Db_Rentify.mdf;Integrated Security=True";
            
            SqlConnection conn = new SqlConnection(connectionString);

            searchItem(conn);
        }
    }
}
