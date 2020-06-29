using System;
using System.Data;
using System.Timers;
using System.Windows;
using TestSparta.Logic;

namespace TestSparta
{
    public partial class MainWindow : Window
    {
        DataTable priceTable;
        DataTable infoTable;
        ProductHandling productHandling = new ProductHandling();
        private static int MONTH_COLUMNS = 6;
        private int newProductCounter = 1;
    public MainWindow()
        {
            InitializeComponent();
            InitPricesTable();
            InitInfoTable();
        }
        private void InitPricesTable()
        {
            string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            productHandling.InitPriceProducts();
            priceTable = new DataTable();
            // May skip adding columns if they are already implemented on XAML
            priceTable.Columns.Add("Name");
            foreach (var month in months)
            {
                priceTable.Columns.Add(month + " 2020");
            }
            productHandling.RetrievePriceProductsToTable(priceTable);
            grid1.DataContext = priceTable.DefaultView;
            SetTimer();
        }
        private void InitInfoTable()
        {
            string[] infoColumns = new string[] { "Name", "Date", "Group", "Price" };
            productHandling.InitInfoProducts();
            // May skip adding columns if they are already implemented on XAML
            infoTable = new DataTable();
            foreach (var column in infoColumns)
            {
                infoTable.Columns.Add(column);
            }
            productHandling.RetrieveInfoProductsToTable(infoTable);
            grid2.DataContext = infoTable.DefaultView;
        }
        private void SetTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += OnTimedEvent;
            timer.Start();
        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < priceTable.Rows.Count; i++)
            {
                for (int j = 1; j <= MONTH_COLUMNS; j++)
                {
                    priceTable.Rows[i].SetField(j, (Double)rnd.Next(-9999, 9999) / 100.00);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int productNumber = 5 + newProductCounter++;
            productHandling.AddProduct(productNumber, priceTable);
        }
    }
}
