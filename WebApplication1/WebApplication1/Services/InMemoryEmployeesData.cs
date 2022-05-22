using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private ILogger<InMemoryEmployeesData> _logger;
        private ICollection<Employee> _employees;
        private int _lastFreeId;

        public InMemoryEmployeesData(ILogger<InMemoryEmployeesData> logger)
        {
            _logger = logger;
            _employees = TestData.Employees;

            if (_employees.Any())
            {
                _lastFreeId = _employees.Max(e => e.Id) + 1;
            }
            else
                _lastFreeId = 1;
        }

        public int Add(Employee employee)
        {
            if (_employees is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            if (_employees.Contains(employee))
            {
                return employee.Id;
            }

            employee.Id = _lastFreeId;
            _lastFreeId++;

            _employees.Add(employee);

            _logger.LogInformation("Сотрудник {0} добавлен", employee);

            return employee.Id;
        }

        public bool Delete(int id)
        {
            var employee = GetById(id);
            if (employee is null)
            {
                _logger.LogWarning("При попытке удаления сотрудника с id:{0} - запись не найдена", id);

                return false;
            }
            _employees.Remove(employee);

            _logger.LogInformation("Сотрудник {0} удален", employee);

            return true;
        }

        public bool Edit(Employee employee)
        {
            if (_employees is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            if (_employees.Contains(employee))
            {
                return true;
            }

            var db_employee = GetById(employee.Id);
            if (db_employee is null)
            {
                _logger.LogWarning("При попытке редактирования сотрудника с id:{0} - запись не найдена", employee.Id);

                return false;
            }
            db_employee.Id = employee.Id;
            db_employee.LastName = employee.LastName;
            db_employee.FirstName = employee.FirstName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.Age = employee.Age;

            _logger.LogInformation("Сотрудник {0} отредактирован", employee);

            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return employee;
        }
    }
}
