using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbooking.Models;

namespace webbooking.Controllers
{
    public class AddresseController : Controller
    {
        private static List<Addresse> _addresses = new List<Addresse>();
        // GET: Addresse
        public ActionResult Index()
        {
            return View(_addresses);
        }

        // GET: Addresse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Addresse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresse/Create
        [HttpPost]
        public ActionResult Create(Addresse addresse)
        {
            try
            {
                addresse.id = _addresses.Count;
                _addresses.Add(addresse);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Addresse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Addresse/Edit/5
        [HttpPost]
        public ActionResult Edit(Addresse addresse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_addresses.Exists(x => x.id == addresse.id))
                    {
                        _addresses[addresse.id] = addresse;

                        return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(_addresses[addresse.id]);
            }
        }
    }
}
