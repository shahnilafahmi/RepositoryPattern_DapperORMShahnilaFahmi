using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class Applications
    {
        public int ApplicationId { get; set; }

        public string ApplicationName { get; set; }
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }

        public List<Applications> roleDropDownList { get; set; } = new List<Applications>();
    }
}
