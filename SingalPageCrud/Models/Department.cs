using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SingalPageCrud.Models
{
    public class Department
    {
        [Key]
        public int Did { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Employee> Employee { get; set; }

    }
}
