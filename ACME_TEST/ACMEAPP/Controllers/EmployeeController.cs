using ACMEAPP.Models;
using ACMEAPP.Repository;
using ACMEAPP.Utilities;
using System.Linq;
using System.Web.Mvc;

namespace ACMEAPP.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        // GET: Employee
        public ActionResult Index()
        {            
            return View(_employeeRepo.GetAllEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
           return View(_employeeRepo.GetEmployee(id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            try
            {
                _employeeRepo.CreateEmployee(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_employeeRepo.GetEmployee(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeModel employee)
        {
            try
            {
                _employeeRepo.UpdateEmployee(employee); 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_employeeRepo.GetEmployee(id));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(EmployeeModel employee)
        {
            try
            {
                _employeeRepo.DeleteEmployee(employee);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
