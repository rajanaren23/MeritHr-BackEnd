using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonDataModel.Models;
using Dawn.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dawn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManagement usermanagement;
        public UserController(IUserManagement iuserManagement)
        {
            usermanagement = iuserManagement;
        }

        [HttpGet]
        public ActionResult<List<UserRegistration>> Get() =>
            usermanagement.Get();


        [HttpPost]
        public ActionResult<UserRegistration> GetDetailsById([FromBody] string id)
        {
            var empdetails = usermanagement.Get(id);

            if (empdetails == null)
            {
                return NotFound();
            }

            return empdetails;
        }

        [HttpPost]
        public IActionResult Create(UserRegistration empdetails)
        {
            try
            {
                usermanagement.Create(empdetails);
                return CreatedAtRoute("Getempdetails", new { id = empdetails.Id.ToString() }, empdetails);
            }
            catch (Exception ex)
            {

            }
            return Ok();
        }

        [HttpPost("{id:length(24)}")]
        public IActionResult Update(string id, UserRegistration empdetailsIn)
        {
            var empdetails = usermanagement.Get(id);

            if (empdetails == null)
            {
                return NotFound();
            }

            usermanagement.Update(id, empdetailsIn);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var empdetails = usermanagement.Get(id);

            if (empdetails == null)
            {
                return NotFound();
            }

            usermanagement.Remove(empdetails.Id);

            return NoContent();
        }
    }
}