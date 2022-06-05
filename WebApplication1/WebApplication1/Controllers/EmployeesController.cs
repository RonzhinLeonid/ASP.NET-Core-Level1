using AutoMapper;
using DataLayer;
using DataLayer.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private IEmployeesData _employees;
        private readonly IMapper _mapper;
        private const int _pageSize = 15;
        public EmployeesController(IEmployeesData employees, IMapper mapper)
        {
            _employees = employees;
            _mapper = mapper;
        }

        public IActionResult Index(int? NumberPage, int PageSize = _pageSize)
        {
            IEnumerable<Employee> employees;

            if (NumberPage is { } page && PageSize > 0)
                employees = _employees.Get(page * PageSize, PageSize);
            else
                employees = _employees.GetAll().Take(PageSize);

            ViewBag.PagesCount = PageSize > 0
                ? (int?)Math.Ceiling(_employees.GetCount() / (double)PageSize)
                : null!;

            return View(employees);
        }

        [Authorize(Roles = Role.Administrators)]
        public IActionResult Details(int id)
        {
            var employee = _employees.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [Authorize(Roles = Role.Administrators)]
        public IActionResult Create()
        {
            return View("Edit", new EmployeeViewModel());
        }

        [Authorize(Roles = Role.Administrators)]
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
        [Authorize(Roles = Role.Administrators)]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model.LastName == "Qwe" && model.FirstName == "Qwe" && model.Patronymic == "Qwe")
                ModelState.AddModelError("", "Qwe - плохой выбор");

            if (model.FirstName == "Asd")
                ModelState.AddModelError("Name", "Asd - неважное имя");

            if (!ModelState.IsValid)
                return View(model);

            var employee = _mapper.Map<EmployeeViewModel, Employee>(model);
            if (model.Id == 0)
            {
                var employeeNew = _employees.Add(employee);
                return RedirectToAction(nameof(Details), new { Id = employeeNew });
            }
            _employees.Edit(employee);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = Role.Administrators)]
        public IActionResult Delete(int id)
        {
            var employee = _employees.GetById((int)id);
            if (employee is null)
                return NotFound();

            var view_model = _mapper.Map<Employee, EmployeeViewModel>(employee);

            return View(view_model);
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrators)]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_employees.Delete(id))
                return NotFound();
            return RedirectToAction(nameof(Index));
        }
    }
}
