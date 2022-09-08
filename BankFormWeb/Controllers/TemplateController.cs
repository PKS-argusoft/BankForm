using BankFormWeb.Data;
using BankFormWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankFormWeb.Controllers;

public class TemplateController : Controller
{
    private readonly ApplicationDbContext _db;

    public TemplateController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        var objTemplateList = _db.Templates.ToList();

        return View(objTemplateList);
    }

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Template obj)
    {
        if(ModelState.IsValid)
        {
            obj.CreatedAt = System.DateTime.Now;
            _db.Templates.Add(obj);
            _db.SaveChanges();
            TempData["Success"] = obj.TemplateName + "is added successfully .";
            return RedirectToAction("Index");
        }
        return View(obj);
    }


}
