using CommercialApplicationCommand.ApplicationLayer.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    class ProductDataForOrderAndInvoiceTesting
    {
        public IEnumerable<ProductCreateModel> Products;
        public ProductDataForOrderAndInvoiceTesting()
        {
            this.Products = new ProductCreateModel[] 
            {
                new ProductCreateModel
                {
                    Name = "First Product",
                    UnitCost = new UnitCostModel
                    {
                        Value = 127,
                        Currency = "RSD"
                    },
                    Description = "Description Create",
                    ImageUrl = @"https://www.srbijadanas.com/sites/default/files/styles/full_article_image/public/a/t/2019/09/17/1_5.jpg",
                    VideoLink = @"http://www.rts.rs/upload/storyBoxFileData/2019/09/17/15008820/hleb-170619.mp4",
                    SerialNumber = "13287961"
                },
                new ProductCreateModel
                {
                    Name = "Second Product",
                    UnitCost = new UnitCostModel
                    {
                        Value = 56,
                        Currency = "RSD"
                    },
                    Description = "Description Create",
                    ImageUrl = @"https://www.srbijadanas.com/sites/default/files/styles/full_article_image/public/a/t/2019/09/17/1_5.jpg",
                    VideoLink = @"http://www.rts.rs/upload/storyBoxFileData/2019/09/17/15008820/hleb-170619.mp4",
                    SerialNumber = "13287961"
                },
                new ProductCreateModel
                {
                    Name = "Third Product",
                    UnitCost = new UnitCostModel
                    {
                        Value = 64,
                        Currency = "RSD"
                    },
                    Description = "Description Create",
                    ImageUrl = @"https://www.srbijadanas.com/sites/default/files/styles/full_article_image/public/a/t/2019/09/17/1_5.jpg",
                    VideoLink = @"http://www.rts.rs/upload/storyBoxFileData/2019/09/17/15008820/hleb-170619.mp4",
                    SerialNumber = "13287961"
                },
                new ProductCreateModel
                {
                    Name = "Fourth Product",
                    UnitCost = new UnitCostModel
                    {
                        Value = 87,
                        Currency = "RSD"
                    },
                    Description = "Description Create",
                    ImageUrl = @"https://www.srbijadanas.com/sites/default/files/styles/full_article_image/public/a/t/2019/09/17/1_5.jpg",
                    VideoLink = @"http://www.rts.rs/upload/storyBoxFileData/2019/09/17/15008820/hleb-170619.mp4",
                    SerialNumber = "13287961"
                },
                new ProductCreateModel
                {
                    Name = "Fifth Product",
                    UnitCost = new UnitCostModel
                    {
                        Value = 130,
                        Currency = "RSD"
                    },
                    Description = "Description Create",
                    ImageUrl = @"https://www.srbijadanas.com/sites/default/files/styles/full_article_image/public/a/t/2019/09/17/1_5.jpg",
                    VideoLink = @"http://www.rts.rs/upload/storyBoxFileData/2019/09/17/15008820/hleb-170619.mp4",
                    SerialNumber = "13287961"
                }
            };
        }
    }
}
