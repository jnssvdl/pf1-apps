using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.Include(e => e.Gender).Include(e => e.Department).ToListAsync();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.Genders = new SelectList(_context.Genders, "GenderId", "GenderName");
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentCode", "DepartmentName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (_context.Employees.Any(e => e.SesaId == employee.SesaId))
            {
                ViewBag.Genders = new SelectList(_context.Genders, "GenderId", "GenderName", employee.GenderId);
                ViewBag.Departments = new SelectList(_context.Departments, "DepartmentCode", "DepartmentName", employee.DepartmentCode);
                return View(employee);
            }

            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //foreach (var state in ModelState)
            //{
            //    var key = state.Key;
            //    var errors = state.Value.Errors;

            //    foreach (var error in errors)
            //    {
            //        Console.WriteLine($"ModelState Error in '{key}': {error.ErrorMessage}");
            //    }
            //}

            ViewBag.Genders = new SelectList(_context.Genders, "GenderId", "GenderName", employee.GenderId);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentCode", "DepartmentName", employee.DepartmentCode);
            return View(employee);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            ViewBag.Genders = new SelectList(_context.Genders, "GenderId", "GenderName", employee.GenderId);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentCode", "DepartmentName", employee.DepartmentCode);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Employee employee)
        {
            if (id != employee.SesaId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Employees.Any(e => e.SesaId == id))
                        return NotFound();
                    else
                        throw;
                }
            }

            ViewBag.Genders = new SelectList(_context.Genders, "GenderId", "GenderName", employee.GenderId);
            ViewBag.Departments = new SelectList(_context.Departments, "DepartmentCode", "DepartmentName", employee.DepartmentCode);
            return View(employee);
        }

        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null)
        //        return NotFound();

        //    var employee = await _context.Employees
        //        .Include(e => e.Gender)
        //        .Include(e => e.Department)
        //        .FirstOrDefaultAsync(e => e.SesaId == id);

        //    if (employee == null)
        //        return NotFound();

        //    return View(employee);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    }
}
