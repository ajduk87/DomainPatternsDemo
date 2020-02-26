using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.Action
{
    public class ActionForthQuarterSpecificProperty : ValueObject
    {
        public string Content { get; set; }

        public ActionForthQuarterSpecificProperty(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator ActionForthQuarterSpecificProperty(string actionForthQuarterSpecificProperty)
        {
            return new ActionForthQuarterSpecificProperty(actionForthQuarterSpecificProperty);
        }

        public static implicit operator string(ActionForthQuarterSpecificProperty actionForthQuarterSpecificProperty)
        {
            return actionForthQuarterSpecificProperty.Content;
        }
    }
}
