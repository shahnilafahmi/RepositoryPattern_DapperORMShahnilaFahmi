using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class MenuItemFeature
    {
        public int FeatureId { get; set; }

        public string Feature { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

      
        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }


        public string Id { get; set; }

        public string parent { get; set; }

        public string text { get; set; }

        public Boolean Checked { get; set; }

    }
}
