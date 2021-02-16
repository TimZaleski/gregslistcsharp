using System;
using System.ComponentModel.DataAnnotations;

namespace gregslistcsharp.Models
{
  public class House
  {

    public House(int bedrooms, int bathrooms, int levels, string imgUrl, int year, float price, string description)
    {
      Bedrooms = bedrooms;
      Bathrooms = bathrooms;
      Levels = levels;
      Year = year;
      Price = price;
      Description = description;
      ImgUrl = imgUrl;
    }

    [Required]
    public int Bedrooms { get; set; }
    [Required]
    public int Bathrooms { get; set; }
    [Required]
    public int Levels { get; set; }
    [Required]
    public int Year { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();


  }
}