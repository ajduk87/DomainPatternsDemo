using CommercialApplicationCommand.ApplicationLayer.Models.SellingProgram;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class SellingProgramData
    {
        public SellingProgramCreateModel SampleCreate;
        public SellingProgramUpdateModel SampleUpdate;
        public SellingProgramDeleteModel SampleDelete;

        public SellingProgramData()
        {
            this.SampleCreate = new SellingProgramCreateModel
            {
                SellingProgram = "Selling Program Create",
                SellingCondition = "Selling Program Condition Create",
                DayForPaying = 45
            };

            this.SampleUpdate = new SellingProgramUpdateModel 
            {
                SellingProgram = "Selling Program Update",
                SellingCondition = "Selling Condition Update",
                DayForPaying  = 30
            };

            this.SampleDelete = new SellingProgramDeleteModel();
        }
    }
}
