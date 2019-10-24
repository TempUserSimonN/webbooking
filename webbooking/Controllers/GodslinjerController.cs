using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webbooking.Models;

namespace webbooking.Controllers
{
    public class GodslinjerController : Controller
    {
        static User user = new User() {
            pallers = new List<Paller>() { new Paller() { vertion = "Pall0",id = 0}, new Paller() { vertion = "Pall1", id = 1 }, new Paller() { vertion = "Pall2", id = 2} },
            tempPlates = new List<TempPlates> { new TempPlates {
        godslinjers = new List<Godslinjer>{
            new Godslinjer{inhold = "1", id = 0, antal = 0},
            new Godslinjer{inhold = "1", id = 1, mærkeOgMr = "blah", antal = 1},
            new Godslinjer{inhold = "1", id = 2, antal = 2},
            new Godslinjer{inhold = "1", id = 3, mærkeOgMr = "blah", antal = 2},
            new Godslinjer{inhold = "1", id = 4, mærkeOgMr = "blah", antal = 3},
            new Godslinjer{inhold = "1", id = 5, mærkeOgMr = "blah", antal = 4},
            new Godslinjer{inhold = "1", id = 6, mærkeOgMr = "blah", antal = 5}
        },id = 0
        },new TempPlates {godslinjers = new List<Godslinjer>{
            new Godslinjer{inhold = "2", id = 0, antal = 0},
            new Godslinjer{inhold = "2", id = 1, mærkeOgMr = "blah", antal = 1},
            new Godslinjer{inhold = "2", id = 2, antal = 2},
            new Godslinjer{inhold = "2", id = 3, mærkeOgMr = "blah", antal = 2},
            new Godslinjer{inhold = "2", id = 4, mærkeOgMr = "blah", antal = 3},
            new Godslinjer{inhold = "2", id = 5, mærkeOgMr = "blah", antal = 4},
            new Godslinjer{inhold = "2", id = 6, mærkeOgMr = "blah", antal = 5}
        },id = 0
        }}
        };
        private static int _currentTempPlates;
        // GET: Godslinjer
        public ActionResult Index()
        {
            ViewBag.currentTempPlates = _currentTempPlates;
            return View(user);
        }

        // GET: Godslinjer/Create
        public ActionResult Create()
        {
            ViewBag.Paller = user.pallers;
            return View();
        }

        // POST: Godslinjer/Create
        [HttpPost]
        public ActionResult Create(Godslinjer godslinjer)
        {
            try
            {
                // TODO: Add insert logic here
                godslinjer.id += user.tempPlates[_currentTempPlates].godslinjers.Count;
                user.tempPlates[_currentTempPlates].godslinjers.Add(godslinjer);
                _currentTempPlates = 1;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Godslinjer/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Paller = user.pallers;
            return View(user.tempPlates[_currentTempPlates].godslinjers[id]);
        }

        // POST: Godslinjer/Edit/5
        [HttpPost]
        public ActionResult Edit(Godslinjer godslinjer)
        {
            try
            {
                //if (ModelState.IsValid)
                {
                    if (user.tempPlates[_currentTempPlates].godslinjers.Exists(x => x.id == godslinjer.id))
                    {
                        user.tempPlates[_currentTempPlates].godslinjers[godslinjer.id] = godslinjer;

                    return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(user.tempPlates[_currentTempPlates].godslinjers[godslinjer.id]);
            }
        }

        // GET: Godslinjer/Delete/5
        public ActionResult Delete(int id)
        {
            user.tempPlates[_currentTempPlates].godslinjers.Remove(user.tempPlates[_currentTempPlates].godslinjers.Find(x => x.id == id));
            //  string fullPath = Request.MapPath("~/Images/Cakes/" + photoName);
            //  if (System.IO.File.Exists(fullPath))
            //  {
            //      System.IO.File.Delete(fullPath);
            //  }
            return View("Index", user.tempPlates[_currentTempPlates].godslinjers);
        }
    }
}
