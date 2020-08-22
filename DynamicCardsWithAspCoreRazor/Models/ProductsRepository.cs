using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicCardsWithAspCoreRazor.Models
{
    public class ProductsRepository: IProductsRepository
    {
        public IEnumerable<Products> GetAllProducts()
        {
            List<Products> productsList = new List<Products>();

            string query = @"SELECT * FROM Products Order By ProductID";
            DataTable table = DbHelper.ExecuteQuery(query, CommandType.Text, null);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Products products = new Products();
                    products.ProductID = Convert.ToInt32(table.Rows[i]["ProductID"]);
                    products.ProductName = table.Rows[i]["ProductName"].ToString();
                    products.ProductDesc = table.Rows[i]["ProductDesc"].ToString();
                    products.ProductPrice = float.Parse(table.Rows[i]["ProductPrice"].ToString());
                    products.ProductImage = table.Rows[i]["ProductImage"].ToString();

                    productsList.Add(products);
                }
            }
            return productsList;
        }
    }
}
