﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeBenefitMapping
    {
        public int EmployeeBenefitMappingId { get; set; }

        public int EmployeeId { get; set; }

        public int BenefitId { get; set; }
        public decimal GrossSalary { get; set; }

        public Boolean Checked { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
