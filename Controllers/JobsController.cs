using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using gregslistcsharp.db;
using gregslistcsharp.Models;
using gregslistcsharp.Services;

namespace gregslistcsharp.Controllers
{
  [ApiController]
  [Route("api/jobs")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _ds;
    public JobsController(JobsService ds)
    {
      _ds = ds;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
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
    public ActionResult<House> GetJobById(string id)
    {
      try
      {
        Job job = _ds.Get(id);
        return Ok(job);
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
        Job job = _ds.Create(newJob);
        return Ok(job);
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
        _ds.Delete(jobId);
        return Ok("Deleted");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{jobId}")]  
    public ActionResult<string> UpdateJob([FromBody] Job updated, string id) {  
      try
      { 
        updated.Id = id;
        Job job = _ds.Edit(updated);
        return Ok(job);
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