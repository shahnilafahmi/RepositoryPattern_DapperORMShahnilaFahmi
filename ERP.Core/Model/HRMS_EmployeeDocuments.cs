using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class HRMS_EmployeeDocuments
    {
        public int EmployeeDocumentId { get; set; }

        public int EmployeeId { get; set; }

        public string FileName { get; set; }
        public string FileComments { get; set; }
        public string FileType { get; set; }
        public string FileOriginalName { get; set; }
      
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
