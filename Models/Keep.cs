using System.ComponentModel;
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
    [Required]
    public string Img { get; set; }
    [DefaultValue(false)]
    public bool IsPrivate { get; set; }
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }
    public int Id { get; set; }
    [Required]
    public string UserId { get; set; }

  }
}