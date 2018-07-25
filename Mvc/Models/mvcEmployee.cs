using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Models
{
    public class mvcEmployee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="This Field is required")]
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}