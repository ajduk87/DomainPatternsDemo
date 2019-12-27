using CommercialApplicationCommand.ApplicationLayer.Models.CustomerLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class CustomerLocationData
    {
        public CustomerLocationCreateModel SampleCreate;
        public CustomerLocationDeleteModel SampleDelete;
        public CustomerLocationData()
        {
            this.SampleCreate = new CustomerLocationCreateModel();
            this.SampleDelete = new CustomerLocationDeleteModel();
        }
    }
}
