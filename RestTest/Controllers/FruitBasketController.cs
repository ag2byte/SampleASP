using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using RestTest.Service;
using Newtonsoft.Json;
namespace RestTest.Controllers;

[ApiController]
[Route("[controller]")]
public class FruitBAsketController : ControllerBase
{

    
    private IFruitService fruitservice;
   

    public FruitBAsketController()
    {
        fruitservice = new FruitService();

    }

    [HttpGet(Name = "GetAllFruit")]
    public IActionResult GetAllFruits(string fruitname="", bool sorted= false)
    {
       
         List<Fruit> fruitList = fruitservice.GetFruits(fruitname, sorted);
        
        if (fruitList.Count == 0 || fruitList == null)
            return BadRequest("Found nothing");
        var metadata = new
        {
            TotalCount = fruitList.Count,
            TotalPrice = fruitList.Sum(item => item.price)

        };
        HttpContext.Response.Headers.Add("metadata", JsonConvert.SerializeObject(metadata));
        return Ok(fruitList);
        
    }


}



