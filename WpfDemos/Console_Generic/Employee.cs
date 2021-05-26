namespace Console_Generic
{
    public interface IEmployee
    {
        void CalculateSalary();
    }

    public interface IPerson
    {
        void Name();
        void CalculateSalary();
    }


    public class Employee : IEmployee
    {
        public void CalculateSalary()
        {
            throw new System.NotImplementedException();
        }
    }


    public class Person : IPerson
    {
        public void Name()
        {
            throw new System.NotImplementedException();
        }

        public void CalculateSalary()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ContractEmployee
    {
        private readonly IEmployee _employee;
        private readonly IPerson _person;

        public ContractEmployee(IEmployee employee, IPerson person)
        {
            _employee = employee;
            _person = person;
        }
        public void EmployeeCalculateSalary()
        {
            _employee.CalculateSalary();
        }

        public void Name()
        {
            throw new System.NotImplementedException();
        }

        public void PersonCalculateSalary()
        {
            _person.CalculateSalary();
        }
    }

    public class PermantEmployee : IEmployee
    {
        public void Test()
        {
            var contactEmp1 = new ContractEmployee(new Employee(), new Person());
            contactEmp1.PersonCalculateSalary();
        }


        public void CalculateSalary()
        {
            throw new System.NotImplementedException();
        }
    }


    public class PermantEmployeeTests
    {
        
    }
}