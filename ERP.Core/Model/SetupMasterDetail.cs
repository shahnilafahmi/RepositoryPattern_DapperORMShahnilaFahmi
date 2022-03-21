using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class SetupMasterDetail
    {
        public int SetupDetailId { get; set; }
        public int SetupMasterId { get; set; }

        public string SetupDetailName { get; set; }

        public string Flex1 { get; set; }
        public string Flex2 { get; set; }
        public string Flex3 { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
