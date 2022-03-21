using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class UserLocationMapping
    {
        public int UserLocationMappingId { get; set; }

        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public int LocationId { get; set; }

        public string  Location { get; set; }
        public string EmployeeName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
