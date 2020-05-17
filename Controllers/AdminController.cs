using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using v3x.Models;
using v3x.Data;
using System.Collections.Generic;
using System.Diagnostics;


namespace v3x.Controllers
{
    public class AdminController : Controller
    {
        const string veryrole = "ADMIN";
        private readonly ILogger<AdminController> _logger;
        private readonly v3xContext _context;



        public AdminController(ILogger<AdminController> logger, v3xContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();

            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendance([FromBody] List<Attendance> attendance)
        {
            var result = attendance.Count();

            foreach (var a in attendance)
            {
                _context.Add(a);
                await _context.SaveChangesAsync();
            }

            return Json(result);
        }

        public async Task<IActionResult> ManageSalary(int ? id)
        {
            var job = await _context.Job.FirstOrDefaultAsync(j => j.PeopleId == id);
            var emp = await _context.People.FirstOrDefaultAsync(e => e.Id == id);

            ViewData["JobId"] = job.JobId;
            ViewData["EmpName"] = emp.Name;

            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost, ActionName("ManageSalary")]
        public async Task<IActionResult> ModifySalary([Bind("Date,Bonus,TotalRate,AdvancePay,EPFId,SocsoId,JobId")]SalaryModification salary)
        {
            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                _context.Add(salary);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(EmployeeTable));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        public async Task<IActionResult> AttendanceList()
        {
            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                return View(await _context.Attendance.ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        public IActionResult Attendance()
        {
            var emp = _context.People.Where(e => e.Role == "Employee");
            ViewData["Employee"] = emp.ToList();

            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult EmployeeTable()
        {
            var emp = _context.People.Where(e => e.Role == "Employee");
            ViewData["Employee"] = emp.ToList();

            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> UpdateEmployee(int? id)
        {

            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var people = await _context.People.FindAsync(id);

                if (people == null)
                {
                    return NotFound();
                }

                ViewData["EmpId"] = people.Id;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id)
        {
            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var empToUpdate = await _context.People.FirstOrDefaultAsync(e => e.Id == id);
                if (await TryUpdateModelAsync<People>(
                    empToUpdate,
                    "",
                    e => e.Tel, e => e.Email, e => e.Nationality, e => e.Address, e => e.DateOfBirth))
                {
                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(EmployeeTable));
                    }
                    catch (DbUpdateException /* ex */)
                    {
                        //Log the error (uncomment ex variable name and write a log.)
                        ModelState.AddModelError("", "Unable to save changes. " +
                            "Try again, and if the problem persists, " +
                            "see your system administrator.");
                    }
                }
                return View("UpdateEmployee", empToUpdate);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> EmployeeDetails(int? id)
        {
            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                var emp = await _context.People.FirstOrDefaultAsync(e => e.Id == id && e.Role == "employee");
                var job = await _context.Job.FirstOrDefaultAsync(j => j.PeopleId == id);

                ViewData["BasePay"] = job.BasePay.ToString();
                ViewData["Position"] = job.Position.ToString();
                return View(emp);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AddEmp()
        {
            if (HttpContext.Session.GetString("Session_Role") == veryrole)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> DeleteEmp(int id)
        {
            var people = await _context.People.FindAsync(id);
            _context.People.Remove(people);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EmployeeTable));

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_Emp(string position, double basePay, string status, [Bind("Name,Password,Role,Tel,Email,Nationality,DateOfBirth,Address")] People people)
        {
                Debug.WriteLine($"Value : {position} {basePay} {status} {people.Name}");

                if (CheckExist(people.Name))
                {
                    Debug.WriteLine("This run");
                    return RedirectToAction(nameof(EmployeeTable));
                }



                _context.Add(people);
                await _context.SaveChangesAsync();

                var emp = await _context.People.FirstOrDefaultAsync(e => e.Name == people.Name);

                Debug.WriteLine($"Emp Id: {emp.Id}");
                var job = new Job
                {

                    Position = position,
                    BasePay = basePay,
                    Status = status,
                    PeopleId = emp.Id
                };
                _context.Add(job);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(EmployeeTable));
        }

        private bool CheckExist(string Name)
        {
            var emp = _context.People.FirstOrDefault(e => e.Name == Name);

            

            if (emp != null)
            {
                
                return true;
            }

            return false;
        }
    }
}