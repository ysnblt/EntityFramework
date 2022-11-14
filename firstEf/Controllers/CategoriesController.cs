using firstEf.Context;
using firstEf.Data;
using firstEf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace firstEf.Controllers
{
    public class CategoriesController : BaseController
    {
        CategoryModel _model;
        //List<Categories> _categories;
        public CategoriesController(PerContext _db, CategoryModel model) : base(_db)
        {
            _model = model;

        }
        public List<Categories> CreateList()
        {
            return _db.Set<Categories>().Where(x => x.Deleted == false).ToList();
        }
        public IActionResult List()
        {
            var clist = CreateList();
            return View(clist);
        }

        public IActionResult Create()
        {
            _model.Categories = new Categories();
            _model.Head = "New Entry";
            _model.Txt = "Save";
            _model.Cls = "btn btn-primary";
            //var x=CreateList().Max(x=>x.Id);
            _model.Categories.Id = CreateList().Max(x => x.Id);

            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            _db.Set<Categories>().Add(model.Categories);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Edit(int Id)
        {
            _model.Categories = _db.Set<Categories>().Find(Id);
            _model.Head = "Update";
            _model.Txt = "Save";
            _model.Cls = "btn btn-success";

            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel model)
        {
            _db.Set<Categories>().Update(model.Categories);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            _model.Categories = _db.Set<Categories>().Where(x => x.Id == Id).Include(x=> x.Products).FirstOrDefault();
            _model.Head = "Delete";
            _model.Txt = "Delete";
            _model.Cls = "btn btn-danger";
            _model.IncProducts = true;
            _model.IncMessage = "Dikkat Bu Kategoriye ait ürün var";
            if(_model.Categories.Products.Count == 0)
            {
                _model.IncProducts = false;
                _model.IncMessage = "";
            }
            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Delete(CategoryModel model)
        {
            model.Categories.Deleted = true;
            _db.Set<Categories>().Update(model.Categories);
            _db.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Detail(int Id)
        {
            var cat = _db.Set<Categories>().Where(x=> x.Id == Id).Include(x => x.Products).FirstOrDefault();

            return View(cat);
        }
    }
}
