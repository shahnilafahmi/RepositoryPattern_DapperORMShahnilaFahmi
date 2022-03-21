using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class MenuItem
    {
        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public string MenuURL { get; set; }

        public int ParentId { get; set; }

        public string SubNode { get; set; }

        public Boolean IsDisplayInMenu { get; set; }

        public int SortOrder { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }

        public string IconClass { get; set; }

        public int ApplicationId { get; set; }
    }
}
