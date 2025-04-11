using System;
using System.ComponentModel;

public class Product
{
    protected string Name;
    protected double Price;
    protected string Brand;

    public Product(string name, double price, string brand)
    {
        this.Name = name;
        this.Price = price;
        this.Brand = brand;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Nazwa: {this.Name}");
        Console.WriteLine($"Cena: {this.Price}");
        Console.WriteLine($"Firma: {this.Brand}");
    }

    public void ApplyDiscount(double percentage)
    {
        this.Price *= percentage;
    }
}



//Ubrania
public class ClothingProduct : Product
{
    protected string Size;
    protected string Material;
    
    public ClothingProduct(string name, double price, string brand, string size, string material): 
                            base(name, price, brand)
    {   
        this.Size = size;
        this.Material = material;
    }

    public bool IsWashableAtHighTemperature() 
    {
        if(this.Material == "Bawełna")
        {
            Console.WriteLine("Mozna prać w wysokich temperaturach");
            return true;
        }
        else
        {
            Console.WriteLine("Nie mozna prać w wysokich temperaturach");
            return false;
        }
    }
}

public class Shirt : ClothingProduct
{
    protected bool HasLongSleeves;
    protected string FitType;
    
    public Shirt(string name, double price, string brand, string size, string material, bool hasLongSleeves, string fitType): 
                    base(name, price, brand, size, material)
    {   
        this.HasLongSleeves = hasLongSleeves;
        this.FitType = fitType;
    }

    public bool IsFormalWear() 
    {
        if(FitType == "regular" && HasLongSleeves && Material == "Bawełna")
        {
            Console.WriteLine("To jest formalny ubiór");
            return true;
        }
        else
        {
            Console.WriteLine("To nie jest formalny ubiór");
            return false;
        }
    }
}

public class Jeans : ClothingProduct
{
    protected bool IsMaterialElastic;
    protected string CutStyle;
    
    public Jeans(string name, double price, string brand, string size, string material, bool isMaterialElastic, string cutStyle): 
                    base(name, price, brand, size, material)
    {   
        this.IsMaterialElastic = isMaterialElastic;
        this.CutStyle = cutStyle;
    }
//
}

public class Jacket : ClothingProduct
{
    protected bool IsWaterproof;
    protected string InsulationType;
    
    public Jacket(string name, double price, string brand, string size, string material, bool isWaterproof, string insulationType): 
                    base(name, price, brand, size, material)
    {   
        this.IsWaterproof = isWaterproof;
        this.InsulationType = insulationType;
    }
//
}


//Jedzenie
public class FoodProduct : Product
{
    protected string ExpirationDate;
    protected bool IsOrganic;
    
    public FoodProduct(string name, double price, string brand, string expirationDate, bool isOrganic): 
                            base(name, price, brand)
    {   
        this.ExpirationDate = expirationDate;
        this.IsOrganic = isOrganic;
    }

    public bool IsExpired() 
    {
        DateTime date = DateTime.Today;
        string data = date.ToString("yyyy-MM-dd");

        int dataRokTeraz = int.Parse(data.Substring(0,4));
        int dataMiesiacTeraz = int.Parse(data.Substring(5,2));
        int dataDzienTeraz = int.Parse(data.Substring(8,2));

        int dataRokProdukt = int.Parse(ExpirationDate.Substring(0,4));
        int dataMiesiacProdukt = int.Parse(ExpirationDate.Substring(5,2));
        int dataDzienProdukt = int.Parse(ExpirationDate.Substring(8,2));
        

        if((dataRokTeraz > dataRokProdukt) || 
            (dataRokTeraz == dataRokProdukt && dataMiesiacTeraz > dataMiesiacProdukt) || 
            (dataRokTeraz == dataRokProdukt && dataMiesiacTeraz == dataMiesiacProdukt && dataDzienTeraz > dataDzienProdukt))
        {  
            Console.WriteLine("Produkt jest przeterminowany");
            return true;
        }
        else
        {
            Console.WriteLine("Produkt nie jest przeterminowany");
            return false;
        }
    }
}

public class Beverage : FoodProduct
{
    protected bool IsCarbonated;
    protected int SugarContent;
    
    public Beverage(string name, double price, string brand, string expirationDate, bool isOrganic, bool isCarbonated, int sugarContent): 
                            base(name, price, brand, expirationDate, isOrganic)
    {   
        this.IsCarbonated = isCarbonated;
        this.SugarContent = sugarContent;
    }

    public bool IsEnergyDrink()
    {
        if(Brand == "Monster")
        {
            Console.WriteLine("To jest Energetyk");
            return true;
        }
        else
        {
            Console.WriteLine("To nie jest Energetyk");
            return false;
        }
    }

    public string GetServingTemperature()
    {
        string temperatura = "22";
        return temperatura;
    }
}

public class DiaryProduct : FoodProduct
{
    protected bool ContainsLactose;
    protected int FatContent;
    
    public DiaryProduct(string name, double price, string brand, string expirationDate, bool isOrganic, bool containsLactose, int fatContent): 
                            base(name, price, brand, expirationDate, isOrganic)
    {   
        this.ContainsLactose = containsLactose;
        this.FatContent = fatContent;
    }

    public int HowManyDaysUntilExpirationDate()
    {
        DateTime aktualnaData = DateTime.Today;
        DateTime dataProdukt = DateTime.Parse(ExpirationDate);
        
        TimeSpan pozostaleDni = dataProdukt - aktualnaData;
        
        return pozostaleDni.Days;
    }
}

public class Snack : FoodProduct
{
    protected bool IsGlutenFree;
    protected bool ForVegan;
    protected int CaloriesForProtion;
    
    public Snack(string name, double price, string brand, string expirationDate, bool isOrganic, bool isGlutenFree, bool forVegan, int caloriesForProtion): 
                            base(name, price, brand, expirationDate, isOrganic)
    {   
        this.IsGlutenFree = isGlutenFree;
        this.ForVegan= forVegan;
        this.CaloriesForProtion = caloriesForProtion;
    }
//
}


//Elektronika
public class EletronicProduct : Product
{
    protected int WarrantyYears;
    protected int PowerConsumption;

    public EletronicProduct(string name, double price, string brand, int warrantyYears, int powerConsumption):
                                base(name, price, brand)
    {
        this.WarrantyYears = warrantyYears;
        this.PowerConsumption = powerConsumption;
    }
}

public class Smartphone : EletronicProduct
{
    protected int BatteryCapacity;

    public Smartphone(string name, double price, string brand, int warrantyYears, int powerConsumption, int batteryCapacity):
                                base(name, price, brand, warrantyYears, powerConsumption)
    {
        this.BatteryCapacity = batteryCapacity;
    }

    public bool IsFlagshipModel()
    {
        if(Brand == "Iphone")
        {
            Console.WriteLine("Jest to flagowy produkt");
            return true;
        }
        else
        {
            Console.WriteLine("Nie jest to flagowy produkt");
            return false;
        }
    }
}

public class Laptop : EletronicProduct
{
    protected bool HasDedicatedGPU;

    public Laptop(string name, double price, string brand, int warrantyYears, int powerConsumption, bool hasDedicatedGPU):
                                base(name, price, brand, warrantyYears, powerConsumption)
    {
        this.HasDedicatedGPU = hasDedicatedGPU;
    }

    public int GetPerformanceRating()
    {
        int performanceRating = 89;
        return performanceRating;
    }
}

public class TV : EletronicProduct
{
    protected bool HasSmartFeatures;
    protected int RefreshRate;

    public TV(string name, double price, string brand, int warrantyYears, int powerConsumption, bool hasSmartFeatures, int refreshRate):
                                base(name, price, brand, warrantyYears, powerConsumption)
    {
        this.HasSmartFeatures = hasSmartFeatures;
        this.RefreshRate = refreshRate;
    }
}



//Main
class Program
{
    public static void Main()
    {
        Shirt myShirt = new Shirt("Koszulka Polo", 79.99, "Nike", "L", "Bawełna", false, "Slim");
        Beverage myDrink = new Beverage("Cola Zero", 5.99, "Coca-Cola", "2026-06-30", false, true, 0);

        myShirt.DisplayInfo();
        myShirt.IsFormalWear();
        myShirt.IsWashableAtHighTemperature();
        
        Console.WriteLine("\n----------------------------------");
        myDrink.IsExpired();
        myDrink.IsEnergyDrink();
        myDrink.ApplyDiscount(0.88);
        myDrink.DisplayInfo();

        Console.WriteLine("\n----------------------------------");
        FoodProduct myFoodProduct = new FoodProduct("Ser cheddar", 10.59, "Mlekovita", "2025-04-02", true);
        myFoodProduct.IsExpired();
        myDrink.DisplayInfo();

        Console.WriteLine("\n----------------------------------");
        ClothingProduct myClothingProduct = new ClothingProduct("Jeans", 179.99, "H%M", "XL", "Poliester");
        myClothingProduct.IsWashableAtHighTemperature();
        myClothingProduct.DisplayInfo();

        Console.WriteLine("\n----------------------------------");
        Product myProduct = new Product("Rower górski", 1899, "Kross");
        myProduct.ApplyDiscount(0.7);
        myProduct.DisplayInfo();

        Console.WriteLine("\n----------------------------------");
        DiaryProduct myDiary = new DiaryProduct("Mleko 3,2%", 3.49, "Mlekovita", "2026-02-15", true, true, 3);
        Console.WriteLine($"Pozostało dni wazności: {myDiary.HowManyDaysUntilExpirationDate()}");
        myDiary.DisplayInfo();
    }
}