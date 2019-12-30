﻿using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;
using System.Collections.Generic;

namespace CommercialApplicationCommand.ApplicationLayer.Models.Invoices
{
    public class InvoiceCreateModel
    {
        public long SellingProgramId { get; set; }
        public long CustomerId { get; set; }
        public long OrderId { get; set; }
        public IEnumerable<InvoiceItemCreateModel> InvoiceItems { get; set; }
    }
}