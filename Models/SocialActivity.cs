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

    [NotMapped]
    public string EnergyBeforeText => GetEnergyText(EnergyBefore);

    [NotMapped]
    public string EnergyAfterText => GetEnergyText(EnergyAfter);

    [NotMapped]
    public string EnjoymentText => GetEnjoymentText(EnjoymentScore);

    [NotMapped]
    public string EnergyChangeText =>
        EnergyChange > 0 ? $"+{EnergyChange}" : EnergyChange.ToString();

    private static string GetEnergyText(int score)
    {
        return score switch
        {
            1 => "1 - หมดพลังมาก",
            2 => "2 - พลังต่ำมาก",
            3 => "3 - ค่อนข้างเหนื่อย",
            4 => "4 - พลังน้อย",
            5 => "5 - ปานกลาง",
            6 => "6 - พอมีพลัง",
            7 => "7 - พลังดี",
            8 => "8 - พลังดีมาก",
            9 => "9 - พลังสูง",
            10 => "10 - พลังเต็ม",
            _ => $"{score}"
        };
    }

    private static string GetEnjoymentText(int score)
    {
        return score switch
        {
            1 => "1 - ไม่สนุกเลย",
            2 => "2 - ไม่ค่อยสนุก",
            3 => "3 - เฉย ๆ ไปทางแย่",
            4 => "4 - พอรับได้",
            5 => "5 - ปานกลาง",
            6 => "6 - ค่อนข้างโอเค",
            7 => "7 - สนุก",
            8 => "8 - สนุกมาก",
            9 => "9 - ดีมาก",
            10 => "10 - ยอดเยี่ยม",
            _ => $"{score}"
        };
    }
}