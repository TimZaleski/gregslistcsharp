using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslistcsharp.db;
using gregslistcsharp.Models;

namespace gregslistcsharp.Controllers
{
  [ApiController]
  [Route("api/cars")]
  public class CarsController : ControllerBase
  {

    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try
      {
        return Ok(FAKEDB.Cars);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(string id)
    {
      try
      {
        Car carToReturn = FAKEDB.Cars.Find(c => c.Id == id);
        return Ok(carToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //frombody will create a new blank object with the properties set to null or their defaults
    //move data from the object sent to create your new class as long as it passes data sanitization.
    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        FAKEDB.Cars.Add(newCar);
        return Ok(newCar);

      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{carId}")]
    public ActionResult<string> BuyCar(string carId)
    {
      try
      {
        Car carToRemove = FAKEDB.Cars.Find(c => c.Id == carId);
        if (FAKEDB.Cars.Remove(carToRemove))
        {
          return Ok("Car Purchased");
        };
        throw new System.Exception("Car does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{carId}")]  
    public ActionResult<string> UpdateCarPrice(Car car, string carId) {  
      try
      { 
        Car carToMod = FAKEDB.Cars.Find(c => c.Id == carId);
        carToMod.Price = car.Price;
        return Ok("Car price modified");
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