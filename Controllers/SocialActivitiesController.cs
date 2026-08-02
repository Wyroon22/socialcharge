using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SocialCharge.Data;
using SocialCharge.Models;

namespace SocialCharge.Controllers;

[Authorize]
public class SocialActivitiesController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public SocialActivitiesController(
        ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);

        var activities = await _context.SocialActivities
            .Include(a => a.Category)
            .Where(a => a.UserId == userId)
            .OrderByDescending(a => a.ActivityDate)
            .ToListAsync();

        return View(activities);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var userId = _userManager.GetUserId(User);

        var activity = await _context.SocialActivities
            .Include(a => a.Category)
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (activity == null)
        {
            return NotFound();
        }

        return View(activity);
    }

    [HttpGet]
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var userId = _userManager.GetUserId(User);

    var activity = await _context.SocialActivities
        .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

    if (activity == null)
    {
        return NotFound();
    }

    await PopulateCategoriesDropDownListAsync(activity.CategoryId);

    return View(activity);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(
    int id,
    [Bind("Id,CategoryId,Title,ActivityDate,EnergyBefore,EnergyAfter,EnjoymentScore,PeopleCount,Note")]
    SocialActivity formActivity)
{
    if (id != formActivity.Id)
    {
        return NotFound();
    }

    var userId = _userManager.GetUserId(User);

    if (userId == null)
    {
        return Challenge();
    }

    var activity = await _context.SocialActivities
        .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

    if (activity == null)
    {
        return NotFound();
    }

    ModelState.Remove(nameof(SocialActivity.UserId));

    if (ModelState.IsValid)
    {
        activity.CategoryId = formActivity.CategoryId;
        activity.Title = formActivity.Title;
        activity.ActivityDate = formActivity.ActivityDate;
        activity.EnergyBefore = formActivity.EnergyBefore;
        activity.EnergyAfter = formActivity.EnergyAfter;
        activity.EnjoymentScore = formActivity.EnjoymentScore;
        activity.PeopleCount = formActivity.PeopleCount;
        activity.Note = formActivity.Note;
        activity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
    }

        await PopulateCategoriesDropDownListAsync(formActivity.CategoryId);

        return View(formActivity);
    }

    [HttpGet]
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var userId = _userManager.GetUserId(User);

    var activity = await _context.SocialActivities
        .Include(a => a.Category)
        .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

    if (activity == null)
    {
        return NotFound();
    }

    return View(activity);
        }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        var activity = await _context.SocialActivities
            .FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (activity == null)
        {
            return NotFound();
        }

        _context.SocialActivities.Remove(activity);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateCategoriesDropDownListAsync();

        var activity = new SocialActivity
        {
            ActivityDate = DateTime.Now,
            EnergyBefore = 5,
            EnergyAfter = 5,
            EnjoymentScore = 5,
            PeopleCount = 0
        };

        return View(activity);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("CategoryId,Title,ActivityDate,EnergyBefore,EnergyAfter,EnjoymentScore,PeopleCount,Note")]
        SocialActivity socialActivity)
    {
        var userId = _userManager.GetUserId(User);

        if (userId == null)
        {
            return Challenge();
        }

        socialActivity.UserId = userId;
        socialActivity.CreatedAt = DateTime.UtcNow;

        ModelState.Remove(nameof(SocialActivity.UserId));

        if (ModelState.IsValid)
        {
            _context.SocialActivities.Add(socialActivity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        await PopulateCategoriesDropDownListAsync(socialActivity.CategoryId);

        return View(socialActivity);
    }

    private async Task PopulateCategoriesDropDownListAsync(object? selectedCategory = null)
    {
        var categories = await _context.Categories
            .OrderBy(c => c.Name)
            .ToListAsync();

        ViewData["CategoryId"] = new SelectList(
            categories,
            "Id",
            "Name",
            selectedCategory
        );
    }
}