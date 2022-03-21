using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class DocumentSubType
    {
        public int DocumentSubTypeId { get; set; }

        public int DocumentTypeId { get; set; }
        public string DocumentSubName { get; set; }
        public string DocumentName { get; set; }
        

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
