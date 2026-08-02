using SocialCharge.Models;

namespace SocialCharge.ViewModels;

public class DashboardViewModel
{
    public int TotalActivities { get; set; }

    public double AverageEnergyBefore { get; set; }

    public double AverageEnergyAfter { get; set; }

    public double AverageEnergyChange { get; set; }

    public SocialActivity? MostChargedActivity { get; set; }

    public SocialActivity? MostDrainedActivity { get; set; }

    public int ChargedCount { get; set; }

    public int SlightlyChargedCount { get; set; }

    public int NeutralCount { get; set; }

    public int SlightlyDrainedCount { get; set; }

    public int DrainedCount { get; set; }
}