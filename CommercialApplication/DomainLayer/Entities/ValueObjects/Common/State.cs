using CommercialApplicationCommand.DomainLayer.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Entities.ValueObjects.Common
{
    public class State : ValueObject
    {
        public string Content { get; }

        public State(string Content)
        {
            this.Content = Content;
        }

        public static explicit operator State(string state)
        {
            return new State(state);
        }

        public static implicit operator string(State state)
        {
            return state.Content;
        }

        public override string ToString()
        {
            return this.Content;
        }
    }
}
