using DataLayer;

namespace WebStore.Interfaces.Services
{
    public interface IEmployeesData
    {
        int GetCount();

        IEnumerable<Employee> Get(int Skip, int Take);

        IEnumerable<Employee> GetAll();

        Employee? GetById(int id);

        int Add(Employee employee);

        bool Edit(Employee employee);

        bool Delete(int id);
    }
}
