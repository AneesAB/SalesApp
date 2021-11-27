using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebApi.Models;

namespace SalesWebApi.Repository
{
    public interface ISalesRepository
    {
        //get all employee
        Task<List<EmployeeRegistration>> GetAllEmployee();

        //register a employee
        Task<int> AddEmployee(EmployeeRegistration emp);

        //delete a employee and remove from log also
        Task<int> DelEmp(int id);

        //Add a login to employee or sales-co
        Task<int> AddLogin(Login login);

        //Get all visit
        Task<List<VisitTable>> GetAllVisit();

        //Add a visit
        Task<int> AddVisit(VisitTable visit);

        //delete a visit
        Task<int> DelVisit(int id);

        //editing a visit
        Task<List<VisitTable>> PutVisit(VisitTable visit);
    }
}
