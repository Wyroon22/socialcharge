using System.ComponentModel.DataAnnotations;

namespace SocialCharge.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [StringLength(20)]
    public string? Icon { get; set; }

    public ICollection<SocialActivity> SocialActivities { get; set; }
        = new List<SocialActivity>();
}