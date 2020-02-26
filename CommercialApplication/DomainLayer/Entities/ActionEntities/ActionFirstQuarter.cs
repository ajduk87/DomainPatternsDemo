using CommercialApplication.DomainLayer.Entities.ValueObjects.Action;
using CommercialApplicationCommand.DomainLayer.Entities.ActionEntities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ActionEntities
{
    public class ActionFirstQuarter : Action
    {
        public ActionFirstQuarterSpecificProperty ActionFirstQuarterSpecificProperty { get; set; }
    }
}
