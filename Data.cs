using System.Text.RegularExpressions;

namespace PetrolStation;

public static class Data
{
    public static bool Validation(string strToCheck)
    {
        var r = new Regex(@"^[1-9]+(\,)?([0-9]{0,2})$");
        return r.IsMatch(strToCheck);
    }

    public static string Import()
    {
        var str = Console.ReadLine();
        if (Validation(strToCheck: str))
        {
            return str;
        }
        else
        {
            Console.WriteLine("Provide proper price");
            return Import();
        }
    }
}
