
namespace MauiApp5
{
    public class Product
    {
        private string name;
        private decimal price;
        private int stock;
        private decimal discount;
        private int soldValue;

        public Product(string name, decimal price, int stock, decimal discount, int soldValue)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Discount = discount;
            SoldValue = soldValue;
        }

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
                if (value <= 0) throw new ArgumentException("Cena musi byc wieksza niz 0");
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
        public decimal Discount
        {
            get => discount;
            set
            {
                if (value < 0 || value > 100) throw new ArgumentException("Rabat nie jest w przedziale 0-100");
                discount = value;
            }
        }
        public int SoldValue
        {
            get => soldValue;
            set
            {
                if (value < 0) throw new ArgumentException("Ilosc przedmiotow do sprzedana jest ujemna");
                if (value > stock) throw new ArgumentException("Nie ma tylu przedmiotow na magazynie");
                soldValue = value;
            }
        }
        public decimal DiscountPrice(decimal discount)
        {
            decimal discountedPrice = price * (discount / 100);
            return price - discountedPrice;
        }
        public bool IsAvaiable()
        {
            if(stock > 0) return true;
            else return false;
        }
        public int SellInStock(int soldValue)
        {
            return stock - soldValue;
        }
        public override string ToString() 
        {
            return $"Produkt: {name}\n Cena:{Price}\n " +
                $"Ilosc na magazynie:{stock}\n " +
                $"Cena po rabacie: {DiscountPrice(discount)}\n " +
                $"Czy dostepne: {IsAvaiable()}\n " +
                $"Ilosc po sprzedazy: {SellInStock(soldValue)}";
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
                decimal d = decimal.Parse(DiscountEntry.Text);
                int so = int.Parse(SellEntry.Text);
                var product = new Product(n, p, s, d, so);
                ResultLabel.Text = product.ToString();
            }
            catch (Exception ex)
            {
                ResultLabel.Text = ex.Message;
            }

        }
    }
}
