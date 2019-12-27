using CommercialApplicationCommand.ApplicationLayer.Models.SalesChannel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class SalesChannelData
    {
        public SalesChannelCreateModel SampleCreate;
        public SalesChannelUpdateModel SampleUpdate;
        public SalesChannelDeleteModel SampleDelete;

        public SalesChannelData()
        {
            this.SampleCreate = new SalesChannelCreateModel
            {
                Name = "Kafici",
                Description = "Samostalne Usluzne Radnje"
            };

            this.SampleUpdate = new SalesChannelUpdateModel
            {
                Name = "kafici i restorani",
                Description = "SUR"
            };

            this.SampleDelete = new SalesChannelDeleteModel();
        }
    }
}
