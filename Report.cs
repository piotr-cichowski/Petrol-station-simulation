using System.Net.Sockets;

namespace PetrolStation;
using  System.Collections.Generic;

public class Report
{
   private List<Receipt> _receiptList = new List<Receipt>();
   public void Add(Receipt toAdd)
   {
       _receiptList.Add(toAdd);
   }
   
   public void Remove(Receipt toRemove)
   {
       _receiptList.Remove(toRemove);
   }
   
   public void GenerateReport()
   {
       var dict = GetAllProducts();
       var sum = 0f;
       foreach (var receipt in _receiptList)
       {
           foreach (var product in receipt.GetList())
           {
               var tmpName = product.Key.GetName().ToLower().Replace(" ", "");
               if (!dict.ContainsKey(tmpName)) continue;
               dict[tmpName]["count"] += product.Value;
               sum += product.Key.GetPrice() * product.Value;
               dict[tmpName]["sum"] += product.Key.GetPrice() * product.Value;
           }
       }
       Console.WriteLine("\n DAILY REPORT\n");
       foreach (var prd in dict)
       {
           Console.WriteLine($"Income from {prd.Key}: {prd.Value["sum"]} pln and it was sold {prd.Value["count"]} times");
       }
       Console.WriteLine($"Total daily income: {sum} pln");
       Console.WriteLine($"\nPlates of all customers \n");
       foreach (var receipt in _receiptList)
       {
           Console.WriteLine($"Plate: {receipt.GetPlate()}");
       }
   }
   
   public Dictionary<string, Dictionary<string, float>> GetAllProducts()
   {
       AppDomain currentDomain = AppDomain.CurrentDomain;
       var assemblies = currentDomain.GetAssemblies();
       var products = new Dictionary<string, Dictionary<string, float>>();
       foreach (var assembly in assemblies)
       {
           foreach (var type in assembly.GetTypes())
           {
               if (type.IsSubclassOf(typeof(Product)))
               {
                   var tempDict = new Dictionary<string, float>();
                   tempDict.Add("count", 0f);
                   tempDict.Add("sum", 0f);
                   products.Add(type.Name.ToString().ToLower().Replace(" ",""), tempDict);
               }
           }
       }
       
       return products;
   }
}
