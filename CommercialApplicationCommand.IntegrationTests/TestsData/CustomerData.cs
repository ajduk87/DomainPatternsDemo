using CommercialApplicationCommand.ApplicationLayer.Models.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class CustomerData
    {
        public CustomerCreateModel SampleCreate;
        public CustomerUpdateModel SampleUpdate;
        public CustomerDeleteModel SampleDelete;

        public CustomerData()
        {
            this.SampleCreate = new CustomerCreateModel
            { 
                Name = "Sample Customer"
            };

            this.SampleUpdate = new CustomerUpdateModel
            {
                Name = "Updated Customer Name"
            };

            this.SampleDelete = new CustomerDeleteModel();
        }
    }
}
