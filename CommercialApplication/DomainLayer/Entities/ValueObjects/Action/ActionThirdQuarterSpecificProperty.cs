using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.Action
{
    public class ActionThirdQuarterSpecificProperty : ValueObject
    {
        public string Content { get; set; }

        public ActionThirdQuarterSpecificProperty(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator ActionThirdQuarterSpecificProperty(string actionThirdQuarterSpecificProperty)
        {
            return new ActionThirdQuarterSpecificProperty(actionThirdQuarterSpecificProperty);
        }

        public static implicit operator string(ActionThirdQuarterSpecificProperty actionThirdQuarterSpecificProperty)
        {
            return actionThirdQuarterSpecificProperty.Content;
        }
    }
}
