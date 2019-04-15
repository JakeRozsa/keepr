using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Vault
  {
    [Required]
    [MinLength(3, ErrorMessage = "Name must be minimum 3 characters.")]
    public string Name { get; set; }
    [Required]
    [MinLength(3, ErrorMessage = "Name must be minimum 3 characters.")]
    public string Description { get; set; }
    public int Id { get; set; }
    public int UserId { get; set; }

  }
}