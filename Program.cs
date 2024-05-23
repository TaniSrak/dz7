namespace dz7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Apartment apartment = new Apartment
            {
                Area = 85.5,
                Rooms = 3,
                Address = "Фрунзе 123",
                HasBalcony = true,
                HasGas = true,
                FloorNumber = 4
            };
        }

        //RealEstatePurchase<Apartment> apartmentPurchase = new RealEstatePurchase<Apartment>
        //{
        //    BuyerName = "Иван Иванов",
        //    SellerName = "Петр Петров",
        //    Property = apartment,
        //    PurchasePrice = 5000000
        //};

        //Console.WriteLine(apartmentPurchase.GetPurchaseInfo());
        //Console.WriteLine($"Стоимость кв метра: {apartmentPurchase.CalculatePricePerSquareMeter():0.00} руб/кв.м");
    }

    public interface IRealEstate //недвижимость
    {
        static string Type { get; set; } //вид
        double Area { get; set; } // площадь
        int Rooms { get; set; } // кол-во комнат
        string Address { get; set; } // адрес
    }
    //квартира
    public struct Apartment : IRealEstate 
    {
        public static string Type { get; set; } = "Квартира"; // Вид 
        public double Area { get; set; } // площадь
        public int Rooms { get; set; } // количество комнат
        public string Address { get; set; } // адрес
        public bool HasBalcony { get; set; } // наличие балкона
        public bool HasGas { get; set; } // наличие газа
        public int FloorNumber { get; set; } // этаж 

        public override string ToString()
        {
            return $"{Type}: {Area} кв.м, {Rooms} комн., Адрес: {Address}, Балкон: {(HasBalcony ? "есть" : "нет")}, Газ: {(HasGas ? "есть" : "нет")}, Этаж: {FloorNumber}";
        }
    }
    //частный дом
    public struct House : IRealEstate
    {
        public static string Type { get; set; } = "Частный дом"; // вид
        public double Area { get; set; } // площадь
        public int Rooms { get; set; } // количество комнат
        public string Address { get; set; } // адрес
        public int NumberOfFloors { get; set; } // количество этажей
        public double PlotArea { get; set; } // площадь

        public override string ToString()
        {
            return $"{Type}: {Area} кв.м, {Rooms} комн., Адрес: {Address}, Этажей: {NumberOfFloors}, Площадь участка: {PlotArea} кв.м";
        }
    }
    //покупка
    public class RealEstatePurchase<T> where T : IRealEstate
    {
        public string BuyerName { get; set; } // фио покупателя
        public string SellerName { get; set; } // фио продавца
        public T Property { get; set; } // недвижимость
        public double PurchasePrice { get; set; } // цена

      
        public string GetPurchaseInfo()
        {
            return $"Покупатель: {BuyerName}, Продавец: {SellerName}, Недвижимость: {Property}, Стоимость покупки: {PurchasePrice} руб";
        }

        public double CalculatePricePerSquareMeter()
        {
            return PurchasePrice / Property.Area;
        }
    }
}
