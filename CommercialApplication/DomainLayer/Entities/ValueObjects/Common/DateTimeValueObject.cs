using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common
{
    public class DateTimeValueObject : ValueObject
    {
        public DateTime Content { get; set; }
        public DateTimeValueObject(DateTime Content)
        {
            this.Content = Content;
        }

        public static explicit operator DateTimeValueObject(DateTime dateTime)
        {
            return new DateTimeValueObject(dateTime);
        }

        public static implicit operator DateTime(DateTimeValueObject dateTimeValueObject)
        {
            return dateTimeValueObject.Content;
        }
    }
}
