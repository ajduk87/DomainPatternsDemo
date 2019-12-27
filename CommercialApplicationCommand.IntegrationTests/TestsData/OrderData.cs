using CommercialApplicationCommand.ApplicationLayer.Models.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommercialApplicationCommand.IntegrationTests.TestsData
{
    public class OrderData
    {
        public OrderCreateModel SampleCreate;
        public OrderUpdateModel SampleUpdate;
        public OrderDeleteModel SampleDelete;

        public OrderData()
        {
            this.SampleCreate = new OrderCreateModel
            {
                orderItems = new OrderItemCreateModel[]
                {
                    new OrderItemCreateModel
                    {
                        Amount = 12,
                        DiscountBasic = 0.05,
                    },
                    new OrderItemCreateModel
                    {
                        Amount = 12,
                        DiscountBasic = 0.07,
                    },
                    new OrderItemCreateModel
                    {
                        Amount = 20,
                        DiscountBasic = 0.03,
                    },
                    new OrderItemCreateModel
                    {
                        Amount = 25,
                        DiscountBasic = 0.03,
                    },
                    new OrderItemCreateModel
                    {
                        Amount = 20,
                        DiscountBasic = 0.03,
                    }
                }
            };
            this.SampleUpdate = new OrderUpdateModel
            {
                orderItems = new OrderItemUpdateModel[]
                {
                    new OrderItemUpdateModel
                    {
                        IsChanged = true,
                        Amount = 18,
                        DiscountBasic = 0.03,
                    },
                    new OrderItemUpdateModel
                    {
                        IsChanged = false,
                        Amount = 12,
                        DiscountBasic = 0.07,
                    },
                    new OrderItemUpdateModel
                    {
                        IsChanged = true,
                        Amount = 27,
                        DiscountBasic = 0.07,
                    },
                    new OrderItemUpdateModel
                    {
                        IsChanged = true,
                        Amount = 22,
                        DiscountBasic = 0.01,
                    },
                    new OrderItemUpdateModel
                    {
                        IsChanged = false,
                        Amount = 20,
                        DiscountBasic = 0.03,
                    }
                }
            };

            this.SampleDelete = new OrderDeleteModel();
        }
    }
}
