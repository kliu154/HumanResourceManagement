﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Model.Response
{
    public class JobCategoryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
