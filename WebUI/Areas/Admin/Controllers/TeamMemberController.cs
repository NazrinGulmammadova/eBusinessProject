using eBusiness.Core.Entities;
using eBusiness.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.ViewModels;
using WebUI.Utilities;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class TeamMemberController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;

    public TeamMemberController(AppDbContext context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public IActionResult Index()
    {
        return View(_context.TeamMembers);
    }
    public async Task<IActionResult> Detail(int id)
    {
        var model=await _context.TeamMembers.FindAsync(id);
        if (model == null) return NotFound();
        return View(model);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MemberCreateVM member)
    {
        if (!ModelState.IsValid) return BadRequest();
        if(member.Image==null)
        {
            ModelState.AddModelError("Image", "Please select the image");
            return View(member);
        }
        if(!member.Image.CheckFileSize(500))
        {
            ModelState.AddModelError("Image", "Please select correct size");
            return View(member);
        }
        if(!member.Image.CheckFileFormat("img/"))
        {
            ModelState.AddModelError("Image", "Please select correct format");
            return View(member);
        }
            var filename = string.Empty;
        try
        {
            filename = await member.Image.CopyToFileAsync(_env.WebRootPath, "assets", "img", "team");
        }
        catch (Exception)
        {
            return View(member);
        }
        TeamMember team = new()
        {
            Name=member.Name,
            Position=member.Position,
            Image=filename
        };
        await _context.AddAsync(team);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        var model = await _context.TeamMembers.FindAsync(id);
        if(model==null) return NotFound();
        return View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var model= await _context.TeamMembers.FindAsync(id);
        if (model == null) return NotFound();
        Helper.DeleteFile(_env.WebRootPath, "assets", "img", "team", model.Image);
        _context.TeamMembers.Remove(model);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
