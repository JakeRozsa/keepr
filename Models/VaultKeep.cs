using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class VaultKeep
  {

    [Required]
    [Range(1, int.MaxValue)]
    public int VaultId { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int KeepId { get; set; }
    public int Id { get; set; }

  }
}