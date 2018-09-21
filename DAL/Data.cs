using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Data
    {
        public List<Products> getProducts()
        {
            using (var db = new NorthwindEntities())
            {
                var query = from product in db.Products
                            select product;
                return query.ToList();
            }
        }

        public void addProduct(String name, String price, String stock)
        {


            using (var db = new NorthwindEntities())
            {
               // Decimal p = Decimal.Parse(price);
                //short? s = Int16.Parse(stock);
                Products product = new Products();
                product.ProductName = name;
               // product.UnitPrice = p;
                //product.UnitsInStock = s;
                db.Products.Add(product);
                db.SaveChanges();
            }
        }


        
    }
}
