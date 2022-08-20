using Microsoft.AspNetCore.Mvc;
using WebMarket.Web.Data;
using WebMarket.Web.Models;

namespace WebMarket.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CategoryList = _db.Categories;
            return View(CategoryList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //post
        [HttpPost]
        public IActionResult Create(Category obj)//obj is Category information, entered by client
        {
            if (obj.Name == obj.DisplayOrder.ToString())//customize error massage
            {
                ModelState.AddModelError("cus", "ترتیب نمایش نباید با نام برابر باشد");//error massage is displayed under name
            }
            if (ModelState.IsValid)
            {//check if client entered data
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");//return to the list of categories
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)//get data from client
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CategoryFromDb = _db.Categories.Find(id);//return match
            //var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);//return first match
            //var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);//return match

            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);//return the data we fetched to the client(CategoryFrom Db is the returned object)
        }

        //post
        [HttpPost]
        public IActionResult Edit(Category obj)//obj is Category information, entered by client
        {
            if (obj.Name == obj.DisplayOrder.ToString())//customize error massage
            {
                ModelState.AddModelError("cus", "ترتیب نمایش نباید با نام برابر باشد");//error massage is displayed under name
            }
            if (ModelState.IsValid)
            {//check if client entered data
                _db.Categories.Update(obj);//update is EF Core default method
                _db.SaveChanges();
                return RedirectToAction("Index");//return to the list of categories
            }
            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)//get data from client
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var CategoryFromDb = _db.Categories.Find(id);//return match
            //var CategoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);//return first match
            //var CategoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);//return match

            if (CategoryFromDb == null)
            {
                return NotFound();
            }

            return View(CategoryFromDb);//return the data we fetched to the client(CategoryFrom Db is the returned object)
        }

        //post
        [HttpPost]
        public IActionResult DeletePost(int? id)//obj is Category information, entered by client
        {
            var obj = _db.Categories.Find(id);
            _db.Categories.Remove(obj);//remove is EF Core default method
            _db.SaveChanges();
            return RedirectToAction("Index");//return to the list of categories
        }
    }
}
