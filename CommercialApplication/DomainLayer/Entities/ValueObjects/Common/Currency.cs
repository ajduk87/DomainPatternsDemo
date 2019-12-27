using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplicationCommand.DomainLayer.Entities.ValueObjects.Common
{
    public class Currency : ValueObject
    {
        public string Content { get; set; }

        public Currency(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator Currency(string description)
        {
            return new Currency(description);
        }

        public static implicit operator string(Currency currency)
        {
            return currency.Content;
        }
    }
}
