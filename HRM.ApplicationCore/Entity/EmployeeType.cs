﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Entity
{
    public class EmployeeType
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Title { get; set; }

        [Column(TypeName = "varchar(400)")]
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // navigational property
        public Employee Employee { get; set; }
    }
}
