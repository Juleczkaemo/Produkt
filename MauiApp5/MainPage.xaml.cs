
namespace MauiApp5
{
    public class Product
    {
        private string name;
        private decimal price;
        private int stock;

        public string Name
        {
            get => name;
            set 
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Nazwa nie moze byc pusta");
                    name = value;
            }
        }

        public decimal Price
        {
            get => price;
            set 
            {
                if (value <= 0) throw new ArgumentException("Cena musi byc mniejsza niz 0");
                    price = value;
            }
        }

        public int Stock
        {
            get => stock;
            set 
            {
                if (value < 0) throw new ArgumentException("Ilosc nie moze byc ujemna");
                stock = value;
 
            }
        }

        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public override string ToString() 
        {
            return $"Produkt: {name}\n Cena:{Price}\n Ilosc na magazynie:{stock}";
        }

    }

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CreateProduct(object sender, EventArgs e)
        {
            try
            {
                string n = NameEntry.Text;
                decimal p = decimal.Parse(PriceEntry.Text);
                int s = int.Parse(StockEntry.Text);

                var product = new Product(n, p, s);

                ResultLabel.Text = product.ToString();
            }
            catch (Exception ex)
            {
                ResultLabel.Text = ex.Message;
            }

        }
    }
}
