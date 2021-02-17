using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslistcsharp.db;
using gregslistcsharp.Models;
using gregslistcsharp.Services;

namespace gregslistcsharp.Controllers
{
  [ApiController]
  [Route("api/houses")]
  public class HousesController : ControllerBase
  {
    private readonly HousesService _ds;
    public HousesController(HousesService ds)
    {
      _ds = ds;
    }

    [HttpGet]
    public ActionResult<IEnumerable<House>> Get()
    {
      try
      {
        return Ok(_ds.Get());
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
        House house = _ds.Get(id);
        return Ok(house);
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
        House house = _ds.Create(newHouse);
        return Ok(house);
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
         _ds.Delete(houseId);
        return Ok("Bought");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{houseId}")]  
    public ActionResult<string> UpdateHouse([FromBody] House updated, string id) {  
      try
      { 
        updated.Id = id;
        House house = _ds.Edit(updated);
        return Ok(house);
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