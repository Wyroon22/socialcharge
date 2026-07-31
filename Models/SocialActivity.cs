using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialCharge.Models;

public class SocialActivity
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "กรุณากรอกชื่อกิจกรรม")]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime ActivityDate { get; set; } = DateTime.Now;

    [Range(1, 10)]
    public int EnergyBefore { get; set; }

    [Range(1, 10)]
    public int EnergyAfter { get; set; }

    [Range(1, 10)]
    public int EnjoymentScore { get; set; }

    [Range(0, 1000)]
    public int PeopleCount { get; set; }

    [StringLength(500)]
    public string? Note { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Category? Category { get; set; }

    [NotMapped]
    public int EnergyChange => EnergyAfter - EnergyBefore;

    [NotMapped]
    public string EnergyStatus => EnergyChange switch
    {
        >= 3 => "Charged",
        >= 1 => "Slightly Charged",
        0 => "Neutral",
        >= -2 => "Slightly Drained",
        _ => "Drained"
    };
}