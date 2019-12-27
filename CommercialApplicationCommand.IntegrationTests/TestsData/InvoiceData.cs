using CommercialApplicationCommand.ApplicationLayer.Models.InvoiceItem;
using CommercialApplicationCommand.ApplicationLayer.Models.Invoices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class InvoiceData
    {
        public InvoiceCreateModel SampleCreate;
        public InvoiceDeleteModel SampleDelete;
        public InvoiceData()
        {
            this.SampleCreate = new InvoiceCreateModel
            {
                InvoiceItems = new InvoiceItemCreateModel[]
                {
                    new InvoiceItemCreateModel
                    {
                        Amount = 10,
                        DiscountBasic = 0.035
                    },
                    new InvoiceItemCreateModel
                    {
                        Amount = 18,
                        DiscountBasic = 0.041
                    },
                    new InvoiceItemCreateModel
                    {
                        Amount = 23,
                        DiscountBasic = 0.056
                    },
                    new InvoiceItemCreateModel
                    {
                        Amount = 16,
                        DiscountBasic = 0.021
                    },
                    new InvoiceItemCreateModel
                    {
                        Amount = 8,
                        DiscountBasic = 0.01
                    }
                }
            };

            this.SampleDelete = new InvoiceDeleteModel();
        }
    }
}
