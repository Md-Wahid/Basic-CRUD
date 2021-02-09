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
    public class ApplicationTypeController : Controller
    {
        private readonly AppDbContext _db;

        public ApplicationTypeController(AppDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> AptObj = this._db.ApplicationType;
            return View(AptObj);
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
        public IActionResult Create(ApplicationType AptObj)
        {
            this._db.Add(AptObj);
            this._db.SaveChanges();
            return RedirectToAction("Index");
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
            var AptObj = this._db.ApplicationType.Find(id);
            if (AptObj == null)
            {
                return NotFound();
            }
            return View(AptObj);
        }
        /// <summary>
        /// GET - Update(modelObject)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(ApplicationType AptObj)
        {
            if (ModelState.IsValid)
            {
                this._db.ApplicationType.Update(AptObj);
                this._db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(AptObj);
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
            var AptObj = this._db.ApplicationType.Find(id);
            if (AptObj == null)
            {
                return NotFound();
            }
            return View(AptObj);
        }
        /// <summary>
        /// GET - Update(modelObject)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RemoveSuccessfully(int? id)
        {
            var AptObj = this._db.ApplicationType.Find(id);
            if (id == null || id == 0)
            {
                return NotFound();
            }
            this._db.ApplicationType.Remove(AptObj);
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
