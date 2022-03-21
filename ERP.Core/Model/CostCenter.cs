using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class CostCenter
    {
        public int CostCenterId { get; set; }

        public int CompanyId { get; set; }

        public string CostCenterName { get; set; }

        public string CompanyName { get; set; }

        public string CostCenterCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
