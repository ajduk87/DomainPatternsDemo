using CommercialApplicationCommand.ApplicationLayer.Models.CommercialistLocation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class CommercialistLocationData
    {
        public CommercialistLocationCreateModel SampleCreate;
        public CommercialistLocationDeleteModel SampleDelete;

        public CommercialistLocationData()
        {
            this.SampleCreate = new CommercialistLocationCreateModel();
            this.SampleDelete = new CommercialistLocationDeleteModel();
        }
    }
}
