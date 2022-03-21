using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ERP.Core.Model
{
    public class UserLoginHistory
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public Boolean IsSuccess { get; set; }

        public Boolean IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
