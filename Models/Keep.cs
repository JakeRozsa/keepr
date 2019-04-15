using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    [Required]
    [MinLength(3, ErrorMessage = "Name must be minimum 3 characters.")]
    public string Name { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "Name must be minimum 3 characters.")]
    public string Description { get; set; }
    public string Img { get; set; }
    public int IsPrivate { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
    public int Id { get; set; }
  }
}