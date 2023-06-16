

using System;
using Microsoft.AspNetCore.Routing;

namespace RestTest.Service;

public class FruitService : IFruitService
{
    private static readonly string[] Fruitnames = new[]
    {
        "Apple", "Banana", "Mango", "Pineapple", "Litchi"
    };
    private static readonly int[] PriceList = new[]
    {
        20,32,26,43,54,65,33
    };
    private static readonly bool[] importList = new[]
    {
        true,false
    };
    private static List<Fruit> fruitList = Enumerable.Range(1, 15).Select(index => new Fruit
    {
        name = Fruitnames[Random.Shared.Next(Fruitnames.Length)],
        price = PriceList[Random.Shared.Next(PriceList.Length)],
        sorted = importList[Random.Shared.Next(importList.Length)]
    }
            ).ToList();

    public List<Fruit> GetFruits(string fruitname, bool sorted)
    {
        var responseResult = (IEnumerable<Fruit>)fruitList;
        if(fruitname.Length > 0)
        {
            responseResult = responseResult.Where(x => fruitname.Equals(x.name, StringComparison.OrdinalIgnoreCase));
        }
        if(sorted)
        {
            responseResult = responseResult.Where(x=> x.sorted==sorted);

        }
        return responseResult.ToList();
    }


}


