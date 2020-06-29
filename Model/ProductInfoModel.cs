namespace TestSparta.Modelo
{
    public class ProductInfoModel
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Date { get; set; }
        public string Group { get; set; }

        public string productInfoToString()
        {
            return Name + ";" + Price + ";" + Date + ";" + Group;
        }
    }
}
