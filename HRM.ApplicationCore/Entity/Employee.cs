using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(70)")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
        public DateTime DOB { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string SSN { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? CurrentAddress { get; set; }

        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime EndTime { get; set;}
        public int EmployeeRoleId { get; set; }
        public int EmployeeTypeId { get; set; }
        public int EmployeeStatusId { get; set; }
        public int ManagerId { get; set; }
    }
}
