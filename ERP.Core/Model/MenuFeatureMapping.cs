using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class MenuFeatureMapping
    {
        public int MenuId { get; set; }

        public string Value { get; set; }

        public int FeatureId { get; set; }

        public string Feature { get; set; }
        public string MenuName { get; set; }

        public string text { get; set; }

        public string id { get; set; }

        public int MenuItemId { get; set; }

        public string parent { get; set; }

        public Boolean Checked { get; set; }

        public int ParentId { get; set; }

        public int CreatedBy { get; set; }

        public int ModifiedBy { get; set; }
        
        public int MenuItemFeatureId { get; set; }
        public int ApplicationId { get; set; }

        public string Label { get; set; }

        public string MenuURL { get; set; }



        public string SubNode { get; set; }

        public List<MenuFeatureMapping> children { get; set; } = new List<MenuFeatureMapping>();

        public List<MenuFeatureMapping> grandchildren { get; set; } = new List<MenuFeatureMapping>();
       

    }

   
}
