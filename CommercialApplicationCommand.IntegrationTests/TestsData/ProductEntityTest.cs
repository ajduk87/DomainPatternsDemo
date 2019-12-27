using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class ProductEntityTest
    {
        public ProductCreateModel SampleCreate;
        public ProductUpdateModel SampleUpdate;
        public ProductDeleteModel SampleDelete;

        public ProductEntityTest()
        {
            this.SampleCreate = new ProductCreateModel
            {
                Name = "Sample Product",
                UnitCost = new UnitCostModel
                {
                    Value = 90,
                    Currency = "RSD"
                },
                Description = "Description Create",
                ImageUrl = @"https://www.srbijadanas.com/sites/default/files/styles/full_article_image/public/a/t/2019/09/17/1_5.jpg",
                VideoLink = @"http://www.rts.rs/upload/storyBoxFileData/2019/09/17/15008820/hleb-170619.mp4",
                SerialNumber = "13287961"
            };

            this.SampleUpdate = new ProductUpdateModel
            {
                Name = "Sample Product Updated",
                UnitCost = new UnitCostModel
                {
                    Value = 90,
                    Currency = "RSD"
                },
                Description = "Description Update",
                ImageUrl = @"https://www.srbijadanas.com/sites/default/files/styles/full_article_image/public/a/t/2019/09/17/1_5.jpg",
                VideoLink = @"http://www.rts.rs/upload/storyBoxFileData/2019/09/17/15008820/hleb-170619.mp4",
                SerialNumber = "15616819616"
            };

            this.SampleDelete = new ProductDeleteModel();
        }
    }
}
