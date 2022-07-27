namespace Acme.Model
{
    public class EmployeeActivity
    {        
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; } 

        
        public int ActivityId { get; set; } 

        public string Comment { get; set; }

    }
}
