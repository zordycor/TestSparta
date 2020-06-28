using System;
using System.Collections.Generic;
using TestSparta.Modelo;

namespace TestSparta.Data
{
    public class Product
    {
        List<ProductPriceModel> priceList = new List<ProductPriceModel>();
        List<ProductInfoModel> infoList = new List<ProductInfoModel>();
        public void AddPriceProduct(ProductPriceModel model)
        {
            priceList.Add(model);
        }
        public void AddInfoProduct(ProductInfoModel model)
        {
            infoList.Add(model);
        }

        public List<ProductPriceModel> RetrievePriceProducts()
        {
            return priceList;
        }

        public List<ProductInfoModel> RetrieveInfoProducts()
        {
            return infoList;
        }

        public string formatDate(DateTime date)
        {
            return date.ToString("dd/MMMM/yyyy - HH:mm");
        }
    }
}
