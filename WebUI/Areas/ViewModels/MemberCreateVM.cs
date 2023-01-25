using System.ComponentModel.DataAnnotations;

namespace WebUI.Areas.ViewModels;

public class MemberCreateVM
{

    [Required, MaxLength(100)]
    public string? Name { get; set; }
    [Required]
    public IFormFile? Image { get; set; }
    [Required, MaxLength(100)]
    public string? Position { get; set; }
}
