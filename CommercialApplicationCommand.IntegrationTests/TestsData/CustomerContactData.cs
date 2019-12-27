using CommercialApplicationCommand.ApplicationLayer.Models.CustomerContact;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class CustomerContactData
    {
        public CustomerContactCreateModel SampleCreate;
        public CustomerContactDeleteModel SampleDelete;

        public CustomerContactData()
        {
            this.SampleCreate = new CustomerContactCreateModel();
            this.SampleDelete = new CustomerContactDeleteModel();
        }
    }
}
