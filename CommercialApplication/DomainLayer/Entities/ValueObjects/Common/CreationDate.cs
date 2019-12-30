using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.Common
{
    public class CreationDate : ValueObject
    {
        public DateTime Content;

        public CreationDate(DateTime Content)
        {
            this.Content = Content;
        }

        public static explicit operator CreationDate(DateTime creationDate)
        {
            return new CreationDate(creationDate);
        }

        public static implicit operator DateTime(CreationDate creationDate)
        {
            return creationDate.Content;
        }
    }
}
