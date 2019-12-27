using CommercialApplicationCommand.ApplicationLayer.Models.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class ActionData
    {
        public ActionCreateModel SampleCreate;
        public ActionUpdateModel SampleUpdate;
        public ActionDeleteModel SampleDelete;

        public ActionData()
        {
            this.SampleCreate = new ActionCreateModel
            {
                Discount = 0.05,
                ThresholdAmount = 15
            };

            this.SampleUpdate = new ActionUpdateModel
            {
                ThresholdAmount = 12,
                Discount = 0.035
            };

            this.SampleDelete = new ActionDeleteModel();
        }
    }
}
