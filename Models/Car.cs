using System;
using System.ComponentModel.DataAnnotations;

namespace gregslistcsharp.Models
{
  public class Car
  {

    public Car(string make, string model, int year, float price, string description, string imgUrl)
    {
      Make = make;
      Model = model;
      Year = year;
      Price = price;
      Description = description;
      ImgUrl = imgUrl;
    }

    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public int Year { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();


  }
}