using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialCharge.Models;

namespace SocialCharge.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext(options)
{
    public DbSet<Category> Categories { get; set; } = default!;

    public DbSet<SocialActivity> SocialActivities { get; set; } = default!;
}