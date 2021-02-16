using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslistcsharp.db;
using gregslistcsharp.Models;

namespace gregslistcsharp.Controllers
{
  [ApiController]
  [Route("api/jobs")]
  public class JobsController : ControllerBase
  {

    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(FAKEDB.Jobs);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<House> GetJobById(string id)
    {
      try
      {
        Job jobToReturn = FAKEDB.Jobs.Find(j => j.Id == id);
        return Ok(jobToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //frombody will create a new blank object with the properties set to null or their defaults
    //move data from the object sent to create your new class as long as it passes data sanitization.
    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        FAKEDB.Jobs.Add(newJob);
        return Ok(newJob);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpDelete("{jobId}")]
    public ActionResult<string> DeleteJob(string jobId)
    {
      try
      {
        Job jobToRemove = FAKEDB.Jobs.Find(j => j.Id == jobId);
        if (FAKEDB.Jobs.Remove(jobToRemove))
        {
          return Ok("Job Purchased");
        };
        throw new System.Exception("Job does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{jobId}")]  
    public ActionResult<string> UpdateJobRate(Job job, string jobId) {  
      try
      { 
        Job jobToMod = FAKEDB.Jobs.Find(j => j.Id == jobId);
        jobToMod.Rate = job.Rate;
        return Ok("Job rate modified");
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