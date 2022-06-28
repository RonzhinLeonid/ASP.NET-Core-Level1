using DataLayer;
using Microsoft.Extensions.Logging;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;

namespace WebStore.Services.Services.InMemory
{
    [Obsolete("Используйте InSqlEmployeesData")]
    public class InMemoryEmployeesData : IEmployeesData
    {
        private ILogger<InMemoryEmployeesData> _logger;
        private ICollection<Employee> _employees;
        private int _lastFreeId;

        public InMemoryEmployeesData(ILogger<InMemoryEmployeesData> logger)
        {
            _employees = TestData.Employees;
            _logger = logger;

            if (_employees.Any())
            {
                _lastFreeId = _employees.Max(e => e.Id) + 1;
            }
            else
                _lastFreeId = 1;
        }

        public int GetCount() => _employees.Count;

        public IEnumerable<Employee> Get(int Skip, int Take)
        {
            IEnumerable<Employee> query = _employees;

            if (Take == 0) return Enumerable.Empty<Employee>();

            if (Skip > 0)
            {
                if (Skip > _employees.Count) return Enumerable.Empty<Employee>();

                query = query.Skip(Skip);
            }

            return query.Take(Take);
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
            var employee = _employees.SingleOrDefault(t => t.Id == id);
            return employee;
        }
    }
}
