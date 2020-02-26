using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.Action
{
    public class ActionSecondQuarterSpecificProperty : ValueObject
    {
        public string Content { get; set; }

        public ActionSecondQuarterSpecificProperty(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator ActionSecondQuarterSpecificProperty(string actionSecondQuarterSpecificProperty)
        {
            return new ActionSecondQuarterSpecificProperty(actionSecondQuarterSpecificProperty);
        }

        public static implicit operator string(ActionSecondQuarterSpecificProperty actionSecondQuarterSpecificProperty)
        {
            return actionSecondQuarterSpecificProperty.Content;
        }
    }
}
