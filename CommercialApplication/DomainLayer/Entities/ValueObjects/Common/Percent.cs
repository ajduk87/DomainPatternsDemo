using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.Common
{
    public class Percent : ValueObject
    {
        public double Content;

        public Percent(double Content)
        {
            this.Content = Content;
        }

        public static explicit operator Percent(double percent)
        {
            return new Percent(percent);
        }

        public static implicit operator double(Percent percent)
        {
            return percent.Content;
        }
    }
}
