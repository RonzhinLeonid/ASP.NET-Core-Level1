using ContextDB.DAL;
using DataLayer;
using Microsoft.Extensions.Logging;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Services.InSQL
{
    public class InSQLEmployeesData : IEmployeesData
    {
        private ILogger<InSQLEmployeesData> _logger;
        private readonly WebStoreDB _context;

        public InSQLEmployeesData(WebStoreDB context, ILogger<InSQLEmployeesData> logger)
        {
            _context = context;
            _logger = logger;
        }

        public int GetCount() => _context.Employees.Count();

        public IEnumerable<Employee> Get(int Skip, int Take)
        {
            if (Take == 0) return Enumerable.Empty<Employee>();

            IQueryable<Employee> query = _context.Employees;

            if (Skip > 0)
                query = query.Skip(Skip);

            return query.Take(Take);
        }

        public int Add(Employee employee)
        {
            if (_context.Employees is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            _context.Employees.Add(employee);
            _context.SaveChanges();

            _logger.LogInformation("Сотрудник {0} добавлен", employee);

            return employee.Id;
        }

        public bool Delete(int id)
        {
            //var employee = GetById(id);
            var employee = _context.Employees.Select(e => new Employee { Id = e.Id })
                                        .FirstOrDefault(e => e.Id == id);
            if (employee is null)
            {
                _logger.LogWarning("При попытке удаления сотрудника с id:{0} - запись не найдена", id);

                return false;
            }

            _context.Remove(employee);
            _context.SaveChanges();

            _logger.LogInformation("Сотрудник {0} удален", employee);

            return true;
        }

        public bool Edit(Employee employee)
        {
            if (_context.Employees is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var db_employee = GetById(employee.Id);
            if (db_employee is null)
            {
                _logger.LogWarning("При попытке редактирования сотрудника с id:{0} - запись не найдена", employee.Id);

                return false;
            }

            db_employee.LastName = employee.LastName;
            db_employee.FirstName = employee.FirstName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.Age = employee.Age;

            _context.SaveChanges();

            _logger.LogInformation("Сотрудник {0} отредактирован", employee);

            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }

        public Employee? GetById(int id)
        {
            var employee = _context.Employees.SingleOrDefault(t => t.Id == id);
            return employee;
        }
    }
}
