using System;
using System.Collections.Generic;
using gregslistcsharp.db;
using gregslistcsharp.Models;

namespace gregslistcsharp.Services
{
  public class CarsService
  {
    // GetAll
    public IEnumerable<Car> Get()
    {
      return FAKEDB.Cars;
    }

    // GetById
    public Car Get(string id)
    {
      Car car = FAKEDB.Cars.Find(c => c.Id == id);
      if (car == null)
      {
        throw new Exception("invalid Id");
      }
      return car;
    }

    // Create
    public Car Create(Car newCar)
    {
      FAKEDB.Cars.Add(newCar);
      return newCar;
    }

    // Edit
    public Car Edit(Car updated)
    {
      Car car = FAKEDB.Cars.Find(c => c.Id == updated.Id);
      if (car == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Cars.Remove(car);
      FAKEDB.Cars.Add(updated);
      return updated;
    }

    public string Delete(string id)
    {
      Car car = FAKEDB.Cars.Find(c => c.Id == id);
      if (car == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Cars.Remove(car);
      return "Deleted";
    }
  }

}