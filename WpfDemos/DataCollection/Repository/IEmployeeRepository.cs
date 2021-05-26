using System.Collections.Generic;

namespace DataCollection.Repository
{
    public interface IEmployeeRepository
    {
        void Save(List<Employee> employees);

        IEnumerable<Employee> GetAllEmployee();
    }
}