using PetrolStation;

Console.WriteLine("Insert cookie price:");
var cookiePrice = Data.Import();

Console.WriteLine("Insert small coffee price:");
var scoffePrice = Data.Import();

Console.WriteLine("Insert large coffee price:");
var lCoffePrice = Data.Import();

Console.WriteLine("Insert diesel price per litre:");
var dieselPrice = Data.Import();

Console.WriteLine("Insert petrol 95  price per litre:");
var petrol95Price = Data.Import();

Console.WriteLine("Insert petrol 98 price per litre:");
var petrol98Price = Data.Import();

var cookie = new Cookie(p: float.Parse(cookiePrice), n: "Cookie");
var sCoffee = new SmallCoffee(p: float.Parse(scoffePrice), n: "Small coffee");
var lCoffee = new LargeCoffee(p: float.Parse(lCoffePrice), n: "Large coffee");
var petrol95 = new Petrol95(p: float.Parse(petrol95Price), n: "Petrol 95");
var petrol98 = new Petrol98(p: float.Parse(petrol98Price), n: "Petrol 98");
var diesel = new Diesel(p: float.Parse(dieselPrice), n: "Diesel");
var report = new Report();

bool menuLoop = true;
while (menuLoop)
{
    Console.WriteLine("1. New customer");
    Console.WriteLine("2. End of the day with generating daily income report");

    var menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            Console.WriteLine($"Insert plate of the customers car");
            var plate = Console.ReadLine();
            var customer = new Receipt(p: plate);
            bool customerMenu = true;
            while (customerMenu)
            {
                Console.WriteLine("1. Add product");
                Console.WriteLine("2. Remove product");
                Console.WriteLine("3. Proceed to payment");

                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        Console.WriteLine("Which product do you want to add");
                        Console.WriteLine("1. Large coffee");
                        Console.WriteLine("2. Small coffee");
                        Console.WriteLine("3. 95 Petrol");
                        Console.WriteLine("4. 98 Petrol");
                        Console.WriteLine("5. Diesel");
                        Console.WriteLine("6. Cookie");

                        var productToAdd = Console.ReadLine();
                        var count = "";
                        switch (productToAdd)
                        {
                            case "1":
                                Console.WriteLine("How much do you want to add:");
                                count = Console.ReadLine();
                                customer.AddProduct(lCoffee, int.Parse(count));
                                Console.WriteLine("Large coffee added to basket");
                                break;
                            
                            case "2":
                                Console.WriteLine("How much do you want to add:");
                                count = Console.ReadLine();
                                customer.AddProduct(sCoffee, int.Parse(count));
                                Console.WriteLine("Small coffee added to basket");
                                break;
                            
                            case "3":
                                Console.WriteLine("how much fuel have you filled up:");
                                count = Console.ReadLine();
                                customer.AddProduct(petrol95, float.Parse(count));
                                Console.WriteLine("Petrol 95 added to basket");
                                break;
                            
                            case "4":
                                Console.WriteLine("how much fuel have you filled up:");
                                count = Console.ReadLine();
                                customer.AddProduct(petrol98, float.Parse(count));
                                Console.WriteLine("Petrol 98 added to basket");
                                break;
                            
                            case "5":
                                Console.WriteLine("how much fuel have you filled up:");
                                count = Console.ReadLine();
                                customer.AddProduct(diesel, float.Parse(count));
                                Console.WriteLine("Diesel added to basket");
                                break;
                            
                            case "6":
                                Console.WriteLine("How much do you want to add:");
                                count = Console.ReadLine();
                                customer.AddProduct(cookie, int.Parse(count));
                                Console.WriteLine("Cookie added to basket");
                                break;
                        }
                        break;
                    
                    case "2":
                        Console.WriteLine("This is your basket:\n");
                        customer.PrintList();
                        Console.WriteLine("Which product do you want to remove:");
                        Console.WriteLine("1. Large coffee");
                        Console.WriteLine("2. Small coffee");
                        Console.WriteLine("3. 95 Petrol");
                        Console.WriteLine("4. 98 Petrol");
                        Console.WriteLine("5. Diesel");
                        Console.WriteLine("6. Cookie");
                        string productToRemove = Console.ReadLine();
                        count = "";
                        switch (productToRemove)
                        {
                            case "1":
                                Console.WriteLine("How many do you want to remove:");
                                count = Console.ReadLine();
                                customer.Remove(lCoffee, int.Parse(count));
                                break;
                            
                            case "2":
                                Console.WriteLine("How many do you want to remove:");
                                count = Console.ReadLine();
                                customer.Remove(sCoffee, int.Parse(count));
                                break;
                            
                            case "3":
                                Console.WriteLine("how much fuel do you want to remove");
                                count = Console.ReadLine();
                                customer.Remove(petrol95, float.Parse(count));
                                break;
                            
                            case "4":
                                Console.WriteLine("how much fuel do you want to remove");
                                count = Console.ReadLine();
                                customer.Remove(petrol98, float.Parse(count));
                                break;
                            
                            case "5":
                                Console.WriteLine("how much fuel do you want to remove");
                                count = Console.ReadLine();
                                customer.Remove(diesel, float.Parse(count));
                                break;
                            
                            case "6":
                                Console.WriteLine("How many do you want to remove:");
                                count = Console.ReadLine();
                                customer.Remove(cookie, int.Parse(count));
                                break;
                        }

                        break;
                    
                    case "3":
                    default:
                        Console.WriteLine($"{customer.GetCost()} pln to pay");
                        report.Add(customer);
                        customerMenu = false;
                        break;
                }
            }
            break;

        case "2":
        default:
            report.GenerateReport();
            menuLoop = false;
            break;
    }
}
