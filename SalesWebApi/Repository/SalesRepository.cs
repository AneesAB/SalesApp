using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebApi.Models;

namespace SalesWebApi.Repository
{
    public class SalesRepository : ISalesRepository
    {
        SMSContext db;
        public SalesRepository(SMSContext _db)
        {
            db = _db;
        }

        //Crud opertion begins here

        //get all employee details
        #region Get all employee
        public async Task<List<EmployeeRegistration>> GetAllEmployee()
        {
            if (db != null)
            {
                return await db.EmployeeRegistration.ToListAsync();

            }
            return null;
        }

        #endregion

        //register or add a employee
        #region Add a employee

        public async Task<int> AddEmployee(EmployeeRegistration emp)
        {
            if (db != null)
            {
                await db.EmployeeRegistration.AddAsync(emp);
                await db.SaveChangesAsync(); //Commit the transaction
                return emp.EmpId;
            }

            return 0;
        }

        #endregion


        //delete a employee and cancel the registraiton
        #region delete employee

        public async Task<int> DelEmp(int id)
        {
            if (db != null)
            {
                var employee = db.EmployeeRegistration.FirstOrDefault(em => em.EmpId == id);
                var login = db.Login.FirstOrDefault(log => log.LId == employee.LId);
                db.Remove(employee);
                db.Remove(login);

                await db.SaveChangesAsync();
                return id;
            }
            return 0;
        }

        #endregion

        //add a login to the employee
        #region Add a employee

        public async Task<int> AddLogin(Login login)
        {
            {
                if (db != null)
                {
                    await db.Login.AddAsync(login);
                    await db.SaveChangesAsync(); //Commit the transaction
                    return login.LId;
                }

                return 0;
            }
        }

        #endregion

        //get al visit
        #region get all visit
        public async Task<List<VisitTable>> GetAllVisit()
        {
            {
                if (db != null)
                {
                    return await db.VisitTable.ToListAsync();

                }
                return null;
            }
        }
        #endregion
        //
        #region add visit 

        public async Task<int> AddVisit(VisitTable visit)
        {
            if (db != null)
            {
                await db.VisitTable.AddAsync(visit);
                await db.SaveChangesAsync(); //Commit the transaction
                return visit.VisitId;
            }

            return 0;
        }

        #endregion

        //delete visit
        #region delete visit

        public async Task<int> DelVisit(int id)
        {
            if (db != null)
            {
                var visit = db.VisitTable.FirstOrDefault(vis => vis.VisitId == id);
                db.Remove(visit);
                await db.SaveChangesAsync();
                return id;
            }
            return 0;
        }

        #endregion

        #region put a visit
        public async Task<List<VisitTable>> PutVisit(VisitTable visit)
        {
            if (db != null)
            {
                var coll = db.VisitTable.FirstOrDefault(vis => vis.VisitId == visit.VisitId);
                //await db.ExpenseType.AddAsync(type);
                coll.CustName = visit.CustName;
                coll.ContactPerson = visit.ContactPerson;
                coll.ContactNo = visit.ContactNo;
                coll.InterestProduct = visit.InterestProduct;
                coll.VisitSubject = visit.VisitSubject;
                coll.Description = visit.Description;
                coll.VisitDatetime = visit.VisitDatetime;
                coll.IsDisabled = visit.IsDisabled;
                coll.IsDeleted = visit.IsDeleted;
                coll.EmpId = visit.EmpId;
                await db.SaveChangesAsync();
                return await db.VisitTable.ToListAsync();
            }
            return null;
        }
        #endregion
    }
}
