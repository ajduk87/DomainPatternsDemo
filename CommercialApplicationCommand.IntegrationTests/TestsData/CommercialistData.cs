using CommercialApplicationCommand.ApplicationLayer.Models.Commercialist;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class CommercialistData
    {
        public CommercialistCreateModel SampleCreate;
        public CommercialistUpdateModel SampleUpdate;
        public CommercialistDeleteModel SampleDelete;

        public CommercialistData()
        {
            SampleCreate = new CommercialistCreateModel
            {
                FirstName = "Pera",
                LastName = "Peric",
                Password = "pera",
                Username = "zdera"
            };

            SampleUpdate = new CommercialistUpdateModel
            {
                FirstName = "Nikola",
                LastName = "Peric",
                Password = "pera",
                Username = "zdera"
            };

            SampleDelete = new CommercialistDeleteModel();
        }
    }
}
