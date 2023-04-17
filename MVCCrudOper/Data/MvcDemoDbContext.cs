using Microsoft.EntityFrameworkCore;
using MVCCrudOper.Models.Employee;

namespace MVCCrudOper.Data
{
    public class MvcDemoDbContext : DbContext
    {


        public MvcDemoDbContext(DbContextOptions options) : base(options) 
        {
        
        }


        public DbSet<Employee> Employees { get; set; }
    }
}
