using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslistcsharp.db;
using gregslistcsharp.Models;
using gregslistcsharp.Services;

namespace gregslistcsharp.Controllers
{
  [ApiController]
  [Route("api/cars")]
  public class CarsController : ControllerBase
  {

    private readonly CarsService _ds;
    public CarsController(CarsService ds)
    {
      _ds = ds;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
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
    public ActionResult<Car> GetCarById(string id)
    {
      try
      {
        Car car = _ds.Get(id);
        return Ok(car);
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
        Car car = _ds.Create(newCar);
        return Ok(car);
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
        _ds.Delete(carId);
        return Ok("Deleted");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{carId}")]  
    public ActionResult<string> UpdateCar([FromBody] Car updated, string id) {  
      try
      { 
        updated.Id = id;
        Car car = _ds.Edit(updated);
        return Ok(car);
      }
      catch (System.Exception err)
      {  
          return BadRequest(err.Message);
      }
      
    }  
  }
}