using System;
using System.ComponentModel.DataAnnotations;

namespace gregslistcsharp.Models
{
  public class Job
  {

    public Job(string company, string jobTitle, int hours, float rate, string description)
    {
      Company = company;
      JobTitle = jobTitle;
      Hours = hours;
      Rate = rate;
      Description = description;
    }

    [Required]
    public string Company { get; set; }
    [Required]
    public string JobTitle { get; set; }
    public int Hours { get; set; }
    public float Rate { get; set; }
    public string Description { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}