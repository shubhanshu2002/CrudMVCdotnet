using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCrudOper.Data;
using MVCCrudOper.Models;
using MVCCrudOper.Models.Employee;

namespace MVCCrudOper.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly MvcDemoDbContext mvcDemoDbContext;


        public EmployeeController(MvcDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> index()
        {
            var data = await mvcDemoDbContext.Employees.ToListAsync();

            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }







        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel addEmployeeViewModel)
        {
            var employee = new Employee()
            {
                Name = addEmployeeViewModel.Name,
                Email = addEmployeeViewModel.Email,
                Salary = addEmployeeViewModel.Salary,
                DataOfBirth = addEmployeeViewModel.DataOfBirth,
                DepartMent = addEmployeeViewModel.DepartMent,
            };

            await mvcDemoDbContext.Employees.AddAsync(employee);
            await mvcDemoDbContext.SaveChangesAsync();
            return RedirectToAction("index");
        }


        [HttpGet]
        public async Task<IActionResult> View(string Name)
        {

            var emp =await mvcDemoDbContext.Employees.FirstOrDefaultAsync(x =>  x.Name == Name);
            if (emp != null)
            {
                var viewModel = new UpdateEmployeeVIewModel()
                {
                    Name = emp.Name,
                    Email = emp.Email,
                    Salary = emp.Salary,
                    DataOfBirth = emp.DataOfBirth,
                    DepartMent = emp.DepartMent,

                };
                return await Task.Run(() =>  View("View", viewModel));
            }

            return RedirectToAction("index");

        }





        [HttpPost]
        public async Task<IActionResult> ViewData(UpdateEmployeeVIewModel op)
        {
            var employee = await mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Name == op.Name);

            if (employee != null)
            {
                employee.Name = op.Name;
                employee.Email = op.Email;
                employee.Salary = op.Salary;
                employee.DataOfBirth = op.DataOfBirth;
                employee.DepartMent = op.DepartMent;

                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("index");
            }

            return RedirectToAction("index");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(UpdateEmployeeVIewModel op)
        {

            var employee = await mvcDemoDbContext.Employees.FirstOrDefaultAsync(x => x.Name == op.Name);



            if (employee != null)
            {

                mvcDemoDbContext.Employees.Remove(employee);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("index");
            }
            return RedirectToAction("index");

        }

    }


}
