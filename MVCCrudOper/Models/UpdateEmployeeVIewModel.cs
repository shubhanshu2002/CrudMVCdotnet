namespace MVCCrudOper.Models
{
    public class UpdateEmployeeVIewModel
    {
        public string Name { get; set; } = null;
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DataOfBirth { get; set; }
        public string DepartMent { get; set; }
    }
}
