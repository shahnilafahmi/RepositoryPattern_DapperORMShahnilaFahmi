using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public  class TreeViewChildNodes
    {
        public int ParentId { get; set; }

        public int ChildId { get; set; }

        public string ChildName { get; set; }
    }
}
