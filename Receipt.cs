using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Reflection;

namespace PetrolStation;

public class Receipt : Car
{
    private Dictionary<Product, float> _products  = new Dictionary<Product, float>();

    public Receipt(string? p) : base(p) {}

    public void AddProduct(Product toAdd, float count)
    {
        if (_products.ContainsKey(toAdd))
            _products[toAdd] += count;
        else
            _products.Add(toAdd, count);
    }

    public void Remove(Product toRemove, float count) 
    {
        foreach (var key in _products.Keys)
        {
            if (key.GetName() == toRemove.GetName())
            {
                if (count > 0 && count <= _products[key])
                {
                       _products[key] -= count;
                       if (_products[key] == 0)
                           _products.Remove(key);
                       Console.WriteLine($"{count} of {key.GetName()} removed from basket");
                       return;
                }
                else
                {
                    Console.WriteLine("Value is higher than count in the basket");
                    return;
                }
            }
        }
        Console.WriteLine($"You don't have {toRemove.GetName()} in the basket, please add it first");
    }

    public Dictionary<Product, float> GetList()
    {
        return _products;
    }

    public void PrintList()
    {
        var i = 0;
        foreach (var product in _products)
        {
            Console.WriteLine($"{i+1}. {product.Key.GetName()}; count: {product.Value}");
            i++;
        }
    }

    public float GetCost()
    {
        var sum = 0f;
        foreach (var product in _products)
        {
            sum += product.Key.GetPrice() * product.Value;
        }
        return sum;
    }

    public string GetPlate()
    {
        return base.GetPlate();
    }
}
