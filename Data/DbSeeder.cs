using Microsoft.EntityFrameworkCore;
using SocialCharge.Models;

namespace SocialCharge.Data;

public static class DbSeeder
{
    public static async Task SeedCategoriesAsync(ApplicationDbContext context)
    {
        if (await context.Categories.AnyAsync())
        {
            return;
        }

        var categories = new List<Category>
        {
            new() { Name = "Study" },
            new() { Name = "Work" },
            new() { Name = "Friends" },
            new() { Name = "Family" },
            new() { Name = "Exercise" },
            new() { Name = "Party" },
            new() { Name = "Alone Time" },
            new() { Name = "Other" }
        };

        context.Categories.AddRange(categories);
        await context.SaveChangesAsync();
    }
}