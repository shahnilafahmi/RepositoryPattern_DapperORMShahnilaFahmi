﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_AdjustmentReason
    {
        public int AdjustmentReasonId { get; set; }

        public string AdjustmentReason { get; set; }

        public int CompanyId { get; set; }
        public int SiteId { get; set; }
       
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
