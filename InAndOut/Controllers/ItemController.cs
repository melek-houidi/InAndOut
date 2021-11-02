using InAndOut.Data;
using InAndOut.Models;
using InAndOut.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {
        private readonly IRepository _db;

        public ItemController(IRepository db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            /*  IEnumerable<Item> objList = _db.Items;
              return View(objList);*/
            List<Item> items = _db.GetItems();
            return View(items);
        }

        // GET-Create
        public IActionResult Create()
        {
            Item  item = new Item();
            return View(item);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            /* _db.Items.Add(obj);
             _db.GetItems().CreateItem(obj);
             return RedirectToAction("Index");*/

            try
            {
                obj = _db.Create(obj);
            }
            catch
            {
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
