﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Model
{
    public class Currency
    {
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencyCode { get; set; }

        public string ExchangeRate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int ModifiedBy { get; set; }

        public string UserIP { get; set; }
    }
}
