using Deneme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Deneme.Controllers
{
    public class DenemeController : Controller
    {

        private IRepository<DenemeModel> _DenemeRepository;
        public DenemeController(DenemeRepository DenemeRepository) {
            _DenemeRepository = DenemeRepository;
            System.Diagnostics.Debug.WriteLine("DenemeController oluşturuldu");
        }
        // GET: Deneme
        public ActionResult Index()
        {
            List<DenemeModel> myList = _DenemeRepository.get_entities().ToList();
            var denemes = from e in myList
                          orderby e.getID()
                          select e;
            return View(denemes);
        }

        // GET: Deneme/Details/5
        public ActionResult Details(int id)
        {
            DenemeModel item = _DenemeRepository.retrieve_entity(id);
            return Content(item.Detail);
        }

        // GET: Deneme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deneme/Create
        [HttpPost]
        public ActionResult Create(DenemeModel newitem)
        {
            try
            {
                // TODO: Add insert logic here

                _DenemeRepository.insert_entity(newitem);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return Content(ex.ToString());
            }
        }

        // GET: Deneme/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deneme/Edit/5
        [HttpPost]
        public ActionResult Edit(DenemeModel newModel, int id)
        {
            try
            {
                // TODO: Add update logic here

                newModel.ID = id;
                _DenemeRepository.update_entity(newModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Deneme/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_DenemeRepository.retrieve_entity(id));
        }

        // POST: Deneme/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                // TODO: Add delete logic here
                _DenemeRepository.delete_entity(id);

                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static List<DenemeModel> init_list()
        {
            List<DenemeModel> result = new List<DenemeModel>();

            result.Add(new DenemeModel(0, "Ali", "Black belt in keeping it real"));
            result.Add(new DenemeModel(1, "FB", "Aiight"));
            result.Add(new DenemeModel(2, "hmm", "check yourself before you wreck yourself"));

            return result;

        }

    }


    
}
