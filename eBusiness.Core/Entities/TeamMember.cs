using System.ComponentModel.DataAnnotations;

namespace eBusiness.Core.Entities;

public class TeamMember
{
    public int Id { get; set; }
    [Required,MaxLength(100)]
    public string? Name { get; set; }
    [Required, MaxLength(100)]
    public string? Image { get; set; }
    [Required, MaxLength(100)]
    public string? Position { get; set; }
    [Required, MaxLength(100)]
    public string? Facebook { get; set; }
    [Required, MaxLength(100)]
    public string? Instagram { get; set; }
    [Required, MaxLength(100)]
    public string? Twitter { get; set; }
}
