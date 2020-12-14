using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        // Inject IEmployeeRepository using Constructor Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("/")]
        [Route("")]
        [Route("Index")]
        // Retrieve employee name and return
        public ViewResult Index()
        {
            // retrieve all the employees
            var model = _employeeRepository.GetAllEmployees();
            // Pass the list of employees to the view
            return View(model);
        }

        // The ? makes id route parameter optional. To make it required remove ?
        [Route("Details/{id?}")]
        // ? makes id method parameter nullable
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new()
            {
                // If "id" is null use 1, else use the value passed from the route
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
