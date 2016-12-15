using ContactsMVCApp.Models;
using ContactsMVCApp.ViewModels;
using System.Web.Mvc;

namespace ContactsMVCApp.Controllers
{
    public class CompaniesController : Controller
    {
        // GET: Companies
        public ActionResult Index()
        {
            DataManager dm = new DataManager();
            ModelState.Clear();
            return View(dm.GetAllCompanies());
        }

        // GET: Companies/Details/5
        public ActionResult Details(int id)
        {
            DataManager dm = new DataManager();
            return View(dm.GetAllCompanies().Find(c=>c.Id==id));
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        public ActionResult Create(CreateCompanyViewModel vm)
        {
            DataManager dm =  new DataManager();
            try
            {
                if (ModelState.IsValid)
                {
                    dm.AddCompany(vm);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int id)
        {
            DataManager dm = new DataManager();
            return View(dm.GetAllCompanies().Find(c=>c.Id==id));
        }

        // POST: Companies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateCompanyViewModel vm)
        {
            DataManager dm = new DataManager();

            try
            {
                dm.UpdateCompany(vm);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Companies/Delete/5

        public ActionResult Delete(int id)
        {
            DataManager dm = new DataManager();
            try
            {
                if (dm.DeleteCompany(id))
                {
                    ViewBag.AlertMsg = "Company Deleted Successfully!";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
