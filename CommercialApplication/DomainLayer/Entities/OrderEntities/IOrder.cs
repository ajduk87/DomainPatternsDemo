﻿using CommercialApplication.DomainLayer.Entities.ValueObjects.Common;
using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.OrderEntities
{
    public interface IOrder
    {
        Id Id { get; set; }
        CreationDate CreationDate { get; set; }
    }
}