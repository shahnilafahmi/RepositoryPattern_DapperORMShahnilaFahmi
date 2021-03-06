using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class Role
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string ApplicationName { get; set; }

        public int ApplicationId { get; set; }

        public Boolean IsFixed { get; set; }

        public int Level { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
