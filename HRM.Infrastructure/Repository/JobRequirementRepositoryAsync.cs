﻿using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Entity;
using HRM.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Infrastructure.Repository
{
    public class JobRequirementRepositoryAsync : BaseRepositoryAsync<JobRequirement>, IJobRequirementRepositoryAsync
    {
        public JobRequirementRepositoryAsync(HRMDbContext _context) : base(_context)
        {
        }
    }
}
