using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.Action
{
    public class ActionFirstQuarterSpecificProperty : ValueObject
    {
        public string Content { get; set; }

        public ActionFirstQuarterSpecificProperty(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator ActionFirstQuarterSpecificProperty(string actionFirstQuarterSpecificProperty)
        {
            return new ActionFirstQuarterSpecificProperty(actionFirstQuarterSpecificProperty);
        }

        public static implicit operator string(ActionFirstQuarterSpecificProperty actionFirstQuarterSpecificProperty)
        {
            return actionFirstQuarterSpecificProperty.Content;
        }
    }
}
