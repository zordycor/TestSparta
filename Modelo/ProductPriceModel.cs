using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSparta.Modelo
{
    public class ProductPriceModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string productPriceToString()
        {
            return Name + ";" + Price;
        }
    }
}
