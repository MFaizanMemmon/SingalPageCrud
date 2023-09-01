using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SingalPageCrud.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int Did { get; set; }
        public virtual Department Department { get; set; }


    }
}
