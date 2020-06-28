using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestSparta.Data;
using TestSparta.Modelo;

namespace TestSparta.Logic
{
    public class ProductHandling
    {
        Product product = new Product();
        int[] productsNumber = Enumerable.Range(1, 5).ToArray();
        private const int MONTHS_NUMBER = 6;
        public void InitPriceProducts()
        {
            foreach (var n in productsNumber)
            {
                product.AddPriceProduct(ProductHandling.DefaultPriceProduct(n));
            }
        }
        public void InitInfoProducts()
        {
            Random rnd = new Random();
            foreach (var n in productsNumber)
            {
                product.AddInfoProduct(DefaultInfoProduct(n));
            }
        }
        public static ProductPriceModel DefaultPriceProduct(int productNumber)
        {
            return new ProductPriceModel()
            {
                Name = "Product " + productNumber,
                Price = 10.ToString("0.00")
                //Change Price to Random if It's possible to send default Price to BrushConverter
            };
        }
        public ProductInfoModel DefaultInfoProduct(int productNumber)
        {
            Random rnd = new Random();
            return new ProductInfoModel()
            {
                Name = "Product " + productNumber,
                Price = rnd.Next(1, 11).ToString("0.00"),
                Date = product.formatDate(DateTime.Now.AddDays(productNumber)),
                Group = "Group " + rnd.Next(1, 3).ToString()
                //Need to Group Rows by Group number
            };
        }
        public void RetrievePriceProductsToTable(DataTable table)
        {
            List<ProductPriceModel> allProducts = product.RetrievePriceProducts();
            if (allProducts.Count > productsNumber.Length)
            {
                AddRowToPriceTable(allProducts[allProducts.Count - 1], table);
            }
            else
            {
                foreach (var item in allProducts)
                {
                    AddRowToPriceTable(item, table);
                }
            }
        }
        public void RetrieveInfoProductsToTable(DataTable table)
        {
            foreach (var item in product.RetrieveInfoProducts())
            {
                List<string> values = item.productInfoToString().Split(';').ToList<string>();
                DataRow row = table.NewRow();
                row["Name"] = values[0];
                row["Price"] = values[1] + " $";
                row["Date"] = values[2];
                row["Group"] = values[3];

                table.Rows.Add(row);
            }
        }
        public void AddProduct(int productNumber, DataTable table)
        {
            ProductPriceModel model = ProductHandling.DefaultPriceProduct(productNumber);
            product.AddPriceProduct(model);
            RetrievePriceProductsToTable(table);
        }
        private void AddRowToPriceTable(ProductPriceModel model, DataTable table)
        {
            List<string> values = model.productPriceToString().Split(';').ToList<string>();
            DataRow row = table.NewRow();
            row["Name"] = values[0];
            for (int i = 1; i <= MONTHS_NUMBER; i++)
            {
                row[i] = values[1];
            }

            table.Rows.Add(row);
        }
    }
}
