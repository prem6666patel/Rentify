using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rentify
{
    public partial class providers_details : System.Web.UI.Page
    {
        int p_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            LoadProvidersData();
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
            string qryProvider = "SELECT * FROM tbl_admin WHERE email = @Email AND password = @Password";

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



                                lblemail.Text = providerRow["email"]?.ToString();
                                lblpass.Text = providerRow["password"]?.ToString();


                                LoadProviderItems(conn);
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

        private void LoadProviderItems(SqlConnection conn)
        {
            string qryItems = "SELECT * from tbl_providers";

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
                lblData.Text = "Error loading items: " + ex.Message;
            }
        }

        protected void btnEditDetails_Click(object sender, EventArgs e)
        {
            Session["email"] = Session["email"];
            Session["password"] = Session["password"];

            Response.Redirect("admin_edit_details.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("homePage.aspx");
        }

        protected void pro_items_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin_dashboard.aspx");
        }

        protected void btnseeRented_Click(object sender, EventArgs e)
        {
            Session["email"] = Session["email"];
            Session["password"] = Session["password"];
            Response.Redirect("seekers_Rented_items.aspx");
        }

        protected void btnSeekersDetails_Click(object sender, EventArgs e)
        {
            Session["email"] = Session["email"];
            Session["password"] = Session["password"];
            Response.Redirect("seekers_details.aspx");

        }

        protected void btnProvidersDetails_Click(object sender, EventArgs e)
        {

            Session["email"] = Session["email"];
            Session["password"] = Session["password"];
            Response.Redirect("providers_details.aspx");
        }

        protected void btnFeedBack_Click(object sender, EventArgs e)
        {
            Session["email"] = Session["email"];
            Session["password"] = Session["password"];
            Response.Redirect("feedback_details.aspx");
        }
    }
}