using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeesData _employees;
        private readonly IMapper _mapper;
        public EmployeesController(IEmployeesData employees, IMapper mapper)
        {
            _employees = employees;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var employees = _employees.GetAll();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _employees.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }
        public IActionResult Create()
        {
            return View("Edit", new EmployeeViewModel());
        }
        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new EmployeeViewModel());

            var employee = _employees.GetById((int)id);
            if (employee is null)
                return NotFound();

            var view_model = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(view_model);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            var employee = _mapper.Map<EmployeeViewModel, Employee>(model);
            if (model.Id == 0)
            {
                var employeeNew = _employees.Add(employee);
                return RedirectToAction(nameof(Details), new { Id = employeeNew });
            }
            _employees.Edit(employee);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var employee = _employees.GetById((int)id);
            if (employee is null)
                return NotFound();

            var view_model = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(view_model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_employees.Delete(id))
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
