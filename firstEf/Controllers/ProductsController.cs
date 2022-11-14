using firstEf.Context;
using firstEf.Data;
using firstEf.DTO;
using firstEf.Models;
using Microsoft.AspNetCore.Mvc;

namespace firstEf.Controllers
{
    public class ProductsController : BaseController
    {
        ProductsModel _model;
        public ProductsController(PerContext _db , ProductsModel model) : base(_db)
        {
            _model = model;
        }
        public List<Categories> GetCategories()
        {
            return _db.Set<Categories>().ToList(); 
        }
        public int GetLastId()
        {
            return _db.Products.ToList().Max(x => x.Id)+1;
        }
        public IActionResult Liste()
        {
            var plist = _db.Set<Products>().Where(x=> x.Deleted == false).Select(x => new ProductsDTO
            {
                Id = x.Id,
                UrunAd = x.ProductName,
                Fiyat = x.Price,
                KategoriAd = x.Categories.CategoryName,
            }).ToList();
            return View(plist);
        }
        public IActionResult Create()
        {
            _model.Categories = GetCategories();
            _model.Products = new Products();
            _model.Head = "New Entry";
            _model.Cls = "btn btn-primary";
            _model.Txt = "Create";
            _model.Products.Id = GetLastId();
            return View("Crud",_model);
        }
        [HttpPost]
        public IActionResult Create(ProductsModel model)
        {
            _db.Set<Products>().Add(model.Products);
            _db.SaveChanges();
            return RedirectToAction("Liste");
        }
        public IActionResult Edit(int Id)
        {
            _model.Categories = GetCategories();
            _model.Products = _db.Set<Products>().Find(Id);
            _model.Head = "Update";
            _model.Txt = "Update";
            _model.Cls = "btn btn-success";

            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Edit(ProductsModel model)
        {
            _db.Set<Products>().Update(model.Products);
            _db.SaveChanges();
            return RedirectToAction("Liste");
        }
        public IActionResult Delete(int Id)
        {
            _model.Categories = GetCategories();
            _model.Products = _db.Set<Products>().Find(Id);
            _model.Head = "Delete";
            _model.Txt = "Delete";
            _model.Cls = "btn btn-danger";

            return View("Crud", _model);
        }

        [HttpPost]
        public IActionResult Delete(ProductsModel model)
        {
            model.Products.Deleted = true;
            _db.Set<Products>().Update(model.Products);
            _db.SaveChanges();
            return RedirectToAction("Liste");
        }

    }
}
