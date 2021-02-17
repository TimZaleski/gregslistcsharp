using System;
using System.Collections.Generic;
using gregslistcsharp.db;
using gregslistcsharp.Models;

namespace gregslistcsharp.Services
{
  public class JobsService
  {
    // GetAll
    public IEnumerable<Job> Get()
    {
      return FAKEDB.Jobs;
    }

    // GetById
    public Job Get(string id)
    {
      Job job = FAKEDB.Jobs.Find(j => j.Id == id);
      if (job == null)
      {
        throw new Exception("invalid Id");
      }
      return job;
    }

    // Create
    public Job Create(Job newJob)
    {
      FAKEDB.Jobs.Add(newJob);
      return newJob;
    }

    // Edit
    public Job Edit(Job updated)
    {
      Job job = FAKEDB.Jobs.Find(j => j.Id == updated.Id);
      if (job == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Jobs.Remove(job);
      FAKEDB.Jobs.Add(updated);
      return updated;
    }

    public string Delete(string id)
    {
      Job job = FAKEDB.Jobs.Find(j => j.Id == id);
      if (job == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Jobs.Remove(job);
      return "Deleted";
    }
  }

}