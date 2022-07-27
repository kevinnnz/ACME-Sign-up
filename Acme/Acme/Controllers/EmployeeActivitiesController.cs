using Acme.DAL;
using Acme.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Acme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeActivitiesController : ControllerBase
    {
        private readonly AcmeDbContext _context;

        public EmployeeActivitiesController(AcmeDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeActivities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeActivityViewModel>>> GetEmployeesActivitiesByActivityAsync(int activityId)
        {
            var employeeActivitiesList = await _context.EmployeesActivities.Where(ea => ea.ActivityId == activityId).ToListAsync();
            var response = new List<EmployeeActivityViewModel>();
            
            foreach (var employeeActivity in employeeActivitiesList)
            {
                var ea = new EmployeeActivityViewModel();
                ea.Comment = employeeActivity.Comment;

                var emp = await _context.Employees.Where(e => e.Id == employeeActivity.EmployeeId).Select(e => e).ToListAsync();
                foreach(var e in emp)
                {
                    ea.Employee = new EmployeeViewModel();
                    ea.Employee.Id = e.Id;
                    ea.Employee.FirstName = e.FirstName;
                    ea.Employee.LastName = e.LastName;
                    ea.Employee.Email = e.Email;
                }

                var act = await _context.Activities.Where(a => a.Id == employeeActivity.ActivityId).Select(a => a).ToListAsync();
                foreach(var a in act)
                {
                    ea.Activity = new ActivityViewModel();
                    ea.Activity.Id = a.Id;
                    ea.Activity.ActivityName= a.ActivityName;
                }

                response.Add(ea);
            } 

            return response;
        }


        // POST: api/EmployeeActivities
        [HttpPost]
        public async Task<ActionResult<EmployeeActivity>> PostEmployeeActivity(EmployeeActivity employeeActivity)
        {
          if (_context.EmployeesActivities == null)
          {
              return Problem("Entity set 'AcmeDbContext.EmployeesActivities' is null.");
          }
            _context.EmployeesActivities.Add(employeeActivity);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeActivityExists(employeeActivity.EmployeeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeesActivitiesByActivityAsync", new { id = employeeActivity.EmployeeId }, employeeActivity);
        }

        private bool EmployeeActivityExists(int id)
        {
            return (_context.EmployeesActivities?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
