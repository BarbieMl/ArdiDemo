﻿using Application.Common.Interfaces.Persistence.Queries;
using Domain.Entities;
using Infrastructure.Persistence.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repoistory.Queries
{
    public class MedicalQueryRepository : GenericQueryRepository<MedicalPolicy>, IMedicalQueryRepository
    {
        public MedicalQueryRepository(InsuranceDBContext context)
            : base(context)
        {
        }
    }
}