using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class TMS_DepartmentShift
    {
        public int DepartmentShiftId { get; set; }

        public int DepartmentId { get; set; }

        public int ShiftId { get; set; }

        public int MaxId { get; set; }


        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
