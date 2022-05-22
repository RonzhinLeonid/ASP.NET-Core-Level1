using WebApplication1.Models;

namespace WebApplication1.Services.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> GetAll();

        Employee? GetById(int id);

        int Add(Employee employee);

        bool Edit(Employee employee);

        bool Delete(int id);
            }
}
