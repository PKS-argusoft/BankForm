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

    //get
    public IActionResult Edit(int? id )
    {
        if(id == null || id==0)
        {
            return NotFound();
        }
        var templateFromDb = _db.Templates.Find(id);

        if(templateFromDb == null)
        {
            return NotFound();
        }

        TempData["old_name_store"] = templateFromDb.TemplateName;

        return View(templateFromDb);
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Template obj)
    {
        if (ModelState.IsValid)
        {
            obj.CreatedAt = obj.CreatedAt;
            obj.UpdatedAt = System.DateTime.Now;

            _db.Templates.Update(obj);
            _db.SaveChanges();
            TempData["Success"] = TempData["old_name_store"] + " has been edited to " + obj.TemplateName + " successfully . ";
            return RedirectToAction("Index");

        }
        return View(obj);
    }



    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var TemplateFromDb = _db.Templates.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

        if (TemplateFromDb == null)
        {
            return NotFound();
        }

        return View(TemplateFromDb);
    }

    //POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var obj = _db.Templates.Find(id);
        if (obj == null)
        {
            return NotFound();
        }

        _db.Templates.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Template deleted successfully";
        return RedirectToAction("Index");

    }



}
