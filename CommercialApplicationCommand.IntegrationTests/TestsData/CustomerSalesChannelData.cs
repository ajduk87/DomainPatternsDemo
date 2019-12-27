using CommercialApplicationCommand.ApplicationLayer.Models.CustomerSalesChannel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class CustomerSalesChannelData
    {
        public CustomerSalesChannelCreateModel SampleCreate;
        public CustomerSalesChannelDeleteModel SampleDelete;

        public CustomerSalesChannelData()
        {
            this.SampleCreate = new CustomerSalesChannelCreateModel();
            this.SampleDelete = new CustomerSalesChannelDeleteModel();
        }
    }
}
