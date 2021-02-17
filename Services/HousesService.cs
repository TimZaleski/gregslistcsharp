using System;
using System.Collections.Generic;
using gregslistcsharp.db;
using gregslistcsharp.Models;

namespace gregslistcsharp.Services
{
  public class HousesService
  {
    // GetAll
    public IEnumerable<House> Get()
    {
      return FAKEDB.Houses;
    }

    // GetById
    public House Get(string id)
    {
      House house = FAKEDB.Houses.Find(h => h.Id == id);
      if (house == null)
      {
        throw new Exception("invalid Id");
      }
      return house;
    }

    // Create
    public House Create(House newHouse)
    {
      FAKEDB.Houses.Add(newHouse);
      return newHouse;
    }

    // Edit
    public House Edit(House updated)
    {
      House house = FAKEDB.Houses.Find(h => h.Id == updated.Id);
      if (house == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Houses.Remove(house);
      FAKEDB.Houses.Add(updated);
      return updated;
    }

    public string Delete(string id)
    {
      House house = FAKEDB.Houses.Find(h => h.Id == id);
      if (house == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Houses.Remove(house);
      return "Deleted";
    }
  }

}