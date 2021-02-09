using LP01.Data;
using LP01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LP01.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> CatObj = this._db.Category;
            return View(CatObj);
        }

        /// <summary>
        /// GET - Create()
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// POST - Create(modelObject)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category CatObj)
        {
            if (ModelState.IsValid)
            {
                this._db.Category.Add(CatObj);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CatObj);
        }

        /// <summary>
        /// GET - Update(id)
        /// </summary>
        /// <returns></returns>
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CatObj = this._db.Category.Find(id);
            if (CatObj == null)
            {
                return NotFound();
            }
            return View(CatObj);
        }
        /// <summary>
        /// GET - Update(modelObject)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(Category CatObj)
        {
            if (ModelState.IsValid)
            {
                this._db.Category.Update(CatObj);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CatObj);
        }

        /// <summary>
        /// GET - Remove(id)
        /// </summary>
        /// <returns></returns>
        public IActionResult Remove(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var CatObj = this._db.Category.Find(id);
            if (CatObj == null)
            {
                return NotFound();
            }
            return View(CatObj);
        }
        /// <summary>
        /// GET - Update(modelObject)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RemoveSuccessfully(int? id)
        {
            var CatObj = this._db.Category.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            this._db.Category.Remove(CatObj);
            this._db.SaveChanges();
            return RedirectToAction("Index");
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
