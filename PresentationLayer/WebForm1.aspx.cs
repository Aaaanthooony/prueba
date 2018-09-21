using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Data.SqlClient;

namespace PresentationLayer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Logic logic = new Logic();

        protected void Page_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        public void prueba()
        {
            string connectionString = @"Data Source=DESKTOP-R1BFS5D\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO dbo.Products (ProductName,UnitPrice,unitsInStock) VALUES (@name,@price,@stock)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@name", (GridView1.FooterRow.FindControl("txtProductNameFooter") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@price", (GridView1.FooterRow.FindControl("txtUnitPriceFooter") as TextBox).Text.Trim());
                sqlCmd.Parameters.AddWithValue("@stock", (GridView1.FooterRow.FindControl("txtUnitsInStockFooter") as TextBox).Text.Trim());
                sqlCmd.ExecuteNonQuery();
                fillGrid();
                lblSuccessMessage.Text = "New Record Added";
                lblErrorMessage.Text = "";
            }
        }

        public void fillGrid()
        {
            GridView1.DataSource = logic.getProducts();
            GridView1.DataBind();
        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
    
            try
            {
            if (e.CommandName.Equals("AddNew"))
            {
                    prueba();
               /* String name = (GridView1.FooterRow.FindControl("txtProductName") as TextBox).Text.Trim();
                String price = (GridView1.FooterRow.FindControl("txtUnitPrice") as TextBox).Text.Trim();
                String stock = (GridView1.FooterRow.FindControl("txtUnitsInStock") as TextBox).Text.Trim();
                logic.addProduct(name, price, stock);
                fillGrid();*/
            }

            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            prueba();
            /*String name = (GridView1.FooterRow.FindControl("txtProductNameFooter") as TextBox).Text.Trim();
            String price = (GridView1.FooterRow.FindControl("txtUnitPriceFooter") as TextBox).Text.Trim();
            String stock = (GridView1.FooterRow.FindControl("txtUnitsInStockFooter") as TextBox).Text.Trim();
            logic.addProduct(name, price, stock);
            fillGrid(); */
        }
    }
}