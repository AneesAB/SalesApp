using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesWebApi.Models;
using SalesWebApi.Repository;

namespace SalesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        ISalesRepository repository;

        public SalesController(ISalesRepository _repository)
        {
            repository = _repository;
        }

        //get all employee
        #region Get all employee
        [HttpGet]
        [Route("getallemp")]
        public async Task<ActionResult<IEnumerable<EmployeeRegistration>>> GetAllEmployee()
        {
            return await repository.GetAllEmployee();
        }

        #endregion

        //add employee
        #region Add  employee

        [HttpPost]
        [Route("Addemp")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRegistration emp)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var EmpID = await repository.AddEmployee(emp);
                    if (EmpID > 0)
                    {
                        return Ok(EmpID);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        //delete a employee
        #region Delete a employee
        [HttpDelete]
        [Route("delemp")]
        public async Task<IActionResult> DelEmp(int id)
        {
            int result = 0;
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await repository.DelEmp(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //Add a employee
        #region add a login to employyee

        [HttpPost]
        [Route("Addlogin")]
        public async Task<IActionResult> AddLogin([FromBody] Login login)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var logID = await repository.AddLogin(login);
                    if (logID > 0)
                    {
                        return Ok(logID);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        //Get all visit
        #region Get all visit
        [HttpGet]
        [Route("getallvisit")]
        public async Task<ActionResult<IEnumerable<VisitTable>>> GetAllVisit()
        {
            return await repository.GetAllVisit();
        }

        #endregion

        //add a visit
        #region Add a visit

        [HttpPost]
        [Route("Addvisit")]
        public async Task<IActionResult> AddVisit([FromBody] VisitTable visit)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var visID = await repository.AddVisit(visit);
                    if (visID > 0)
                    {
                        return Ok(visID);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        //delete a visit
        #region Delete a visit
        [HttpDelete]
        [Route("delvisit")]
        public async Task<IActionResult> Delvisit(int id)
        {
            int result = 0;
            if (id == 0)
            {
                return BadRequest();
            }

            try
            {
                result = await repository.DelVisit(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //updatea visit
        #region put visit

        [HttpPut]
        [Route("Putvisit")]
        public async Task<IActionResult> PutEmployee(VisitTable visit)
        {
            try
            {
                //search by id   returns emp in Db
                var vis = await repository.PutVisit(visit);
                if (vis == null)
                {
                    return NotFound();
                }
                return Ok(vis);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        //new fields value  used to replace emp in db
        //typ.ExName = type.ExName;

        #endregion



    }
}
