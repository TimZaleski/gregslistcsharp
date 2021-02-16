using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslistcsharp.db;
using gregslistcsharp.Models;

namespace gregslistcsharp.Controllers
{
  [ApiController]
  [Route("api/houses")]
  public class CarsController : ControllerBase
  {

    [HttpGet]
    public ActionResult<IEnumerable<House>> Get()
    {
      try
      {
        return Ok(FAKEDB.Houses);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<House> GetHouseById(string id)
    {
      try
      {
        House houseToReturn = FAKEDB.Houses.Find(h => h.Id == id);
        return Ok(houseToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //frombody will create a new blank object with the properties set to null or their defaults
    //move data from the object sent to create your new class as long as it passes data sanitization.
    [HttpPost]
    public ActionResult<House> Create([FromBody] House newHouse)
    {
      try
      {
        FAKEDB.Houses.Add(newHouse);
        return Ok(newHouse);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{houseId}")]
    public ActionResult<string> BuyHouse(string houseId)
    {
      try
      {
        House houseToRemove = FAKEDB.Houses.Find(h => h.Id == houseId);
        if (FAKEDB.Houses.Remove(houseToRemove))
        {
          return Ok("House Purchased");
        };
        throw new System.Exception("House does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{houseId}")]  
    public ActionResult<string> UpdateHousePrice(House house, string houseId) {  
      try
      { 
        House houseToMod = FAKEDB.Houses.Find(h => h.Id == houseId);
        houseToMod.Price = house.Price;
        return Ok("House price modified");
      }
      catch (System.Exception err)
      {  
          return BadRequest(err.Message);
      }
      
    }  


    //NOTE if you were needing to further specify your route, do so in the httpattribute accordingly.
    // [HttpGet("{id}/kittens")]
    // public ActionResult<IEnumerable<Cat>> GetTest()
    // {
    //   try
    //   {
    //     return Ok(FAKEDB.Cats);
    //   }
    //   catch (System.Exception err)
    //   {
    //     return BadRequest(err.Message);
    //   }
    // }
  }
}