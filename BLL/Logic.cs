using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class Logic
    {
        Data data = new Data();

        public void addProduct(String name, String price, String stock)
        {
            data.addProduct(name, price, stock);
        }

        public DataTable getProducts()
        {
            return convertProductsListToDataTable( data.getProducts());
        }

        private DataTable convertProductsListToDataTable(List<Products> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductName");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("UnitsInStock");

            foreach (Products product in list)
            {
                dt.Rows.Add(product.ProductName, product.UnitPrice, product.UnitsInStock);
            }

            return dt;
        }
    }
}
