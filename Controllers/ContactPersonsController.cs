using ContactsMVCApp.Models;
using ContactsMVCApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ContactsMVCApp.Controllers
{
    public class ContactPersonsController : Controller
    {


        // GET: ContactPersons
        public ActionResult Index()
        {
            DataManager dm = new DataManager();
            ModelState.Clear();
            return View(dm.GetAllPersons());
        }

        // GET: ContactPersons/Details/5
        public ActionResult Details(int id)
        {
            DataManager dm = new DataManager();

            return View(dm.GetAllPersons().Find(p=>p.Id ==id));
        }

        // GET: ContactPersons/Create
        public ActionResult Create()
        {
            var vm = CreateEmpty(new CreateContactPersonViewModel());

            return View(vm);
        }

        // POST: ContactPersons/Create
        [HttpPost]
        public ActionResult Create(CreateContactPersonViewModel vm)
        {
            DataManager dm = new DataManager();

            try
            {
                if (ModelState.IsValid)
                {
                    dm.AddContactPerson(vm);
                }



                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactPersons/Edit/5
        public ActionResult Edit(int id)
        {
            DataManager dm = new DataManager();
            return View(dm.GetAllPersons().Find(p=>p.Id == id));
        }

        // POST: ContactPersons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UpdateContactPersonViewModel vm)
        {
            DataManager dm = new DataManager();
            try
            {
                dm.UpdateContactPerson(vm);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactPersons/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ContactPersons/Delete/5

        public ActionResult Delete(int id)
        {
            DataManager dm = new DataManager();
            try
            {
                if (dm.DeleteContactPerson(id))
                {
                    ViewBag.AlertMsg = "Contact Person Deleted Successfully!";
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //Load Company list to the create contact person form dropdown!
        public CreateContactPersonViewModel CreateEmpty(CreateContactPersonViewModel ViewModel)
        {
            DataManager dm = new DataManager();

            var companies = dm.GetAllCompanies();

            ViewModel.Companies = companies.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CompanyName,



            }).ToList();

            return ViewModel;
        }
    }
}
